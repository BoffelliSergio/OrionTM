using System;
using System.Collections;
using System.IO;
using System.Threading;
using OrionTMClient.Entity;
using OrionTMClient.Infra;
using OrionTMClient.Infra.ZipLib;
using OrionTMClient.Interface;
using ICSharpCode.SharpZipLib.Zip;

namespace OrionTMClient.Controller
{
    internal class UploadOnLine : Common
    {
        private UploadOnLineParameter probjUploadOnLineParameter;
        private UploadOnLineStatistic probjUploaOnLineStatistic;
        private UploadOnLineSend probUploadOnLineSend;
        private OrionEquipment probjOrionEquipment;
        private FileInfo probjFileInfo;

        private string prstrFileGenerate;
        private string prstrPathUploadOnline;
        private string prstrPathUploadOnlineTemp;
        private string prtrDestinationPathAndFile;
        private long prstrCRC32File;
        private FileStream probjFileStream;
        private BinaryReader probjBinaryReader;
        private GenerateLogEvent probjEvtLog;

        private ArrayList ALOut = new ArrayList();

        internal UploadOnLine()
        {
        }
               
        ~UploadOnLine()
        {
        }

        internal void Execute()
        {
            try
            {
                this.probjOrionEquipment = OrionEquipment;

                LocalLog.Trace.WriteLogText("UploadOnLine_Execute()", "Start the online upload process.");
                ApplicationPath = System.Windows.Forms.Application.StartupPath;

                this.probjwsOrion = new WSOrion.MainServerOrionTM();
                this.probjZipLib = new ZipLib();
                this.prstrPathUploadOnline = Path.Combine(ApplicationPath, "UploadOnline");
                this.prstrPathUploadOnlineTemp = Path.Combine(this.prstrPathUploadOnline, "temp");

                this.probjWSConnect = new WSConect();
                this.probjUploadOnLineParameter = new UploadOnLineParameter(Convert.ToInt32(this.probjOrionEquipment.IdTask), Convert.ToString(Status.Start));
                this.probjWSConnect.Send(ref this.probjUploadOnLineParameter);

                if (this.probjUploadOnLineParameter.Status == Convert.ToString(Status.Start))
                {
                    Guid guid = Guid.NewGuid();
                    this.prstrFileGenerate = string.Concat("Req_OnLine_", Convert.ToString(this.probjUploadOnLineParameter.Sequence), "_", guid, ".zip");
                    this.prtrDestinationPathAndFile = Path.Combine(this.prstrPathUploadOnline, this.prstrFileGenerate);

                    if (!GenerateFileToUpload(this.probjUploadOnLineParameter))
                    {
                        return;
                    }

                    this.probjUploadOnLineParameter.Status = Convert.ToString(Status.Send);
                    
                    //// Atualiza o Status 
                    //if (!UpdateStatus(this.probjUploadOnLineParameter.Sequence , Status.Send))
                    //{
                    //    return;
                    //}

                    //Calcula o CRC doArquivo
                    if (!CalculateCRC32File(this.prtrDestinationPathAndFile))
                    {
                        LocalLog.Trace.WriteLogText("UploadOnLine_Execute()", string.Concat("Unexpected error on file CRC calculator. File name:", this.prstrFileGenerate, ". Verify!!!  File discard..."), this.probjZipLib.Error);

                        // Atualiza o Status 
                        if (!UpdateStatus(this.probjUploadOnLineParameter.Sequence, Status.ExecuteCRCError))
                        {
                            return;
                        }

                        return;
                    }
                }

                this.probjFileInfo = new FileInfo(this.prtrDestinationPathAndFile);

                this.probUploadOnLineSend = new UploadOnLineSend(this.probjUploadOnLineParameter.Sequence, Convert.ToString(Status.Send));
                this.probUploadOnLineSend.FileName = this.probjFileInfo.Name;
                this.probUploadOnLineSend.TotalSize = this.probjFileInfo.Length;
                this.probUploadOnLineSend.CRCFile = this.prstrCRC32File;
                this.probUploadOnLineSend.StartSending = true;
                this.probUploadOnLineSend.Sequence = this.probjUploadOnLineParameter.Sequence;
                //this.probUploadOnLineSend.SizeBuffer = 3072;
                this.probUploadOnLineSend.SizeBuffer = 4096;
                this.probUploadOnLineSend.Delay = 0;         
                
                if (!Upload(this.probUploadOnLineSend, this.probjFileInfo))
                {
                    return;
                }

                File.Delete(this.prtrDestinationPathAndFile);

                if (this.probjFileInfo != null)
                {
                    this.probjFileInfo = null;
                }

                LocalLog.Trace.WriteLogText("UploadOnLine_Execute()", "Process Ended.");

                if (!UpdateStatus(this.probjUploadOnLineParameter.Sequence, Status.ExecuteOk))
                {
                    return;
                }
            }
            catch (Exception Ex)
            {
                if (!UpdateStatus(this.probjUploadOnLineParameter.Sequence, Status.ExecuteError))
                {
                    return;
                }



                LocalLog.Trace.WriteLogText("UploadOnLine_Execute()", "Unexpected error occurs on Upload...", Ex);
            }
            finally
            {
                this.probjwsOrion = null;
                this.probjZipLib = null;
                this.probjUploadOnLineParameter = null;
                this.probjUploaOnLineStatistic = null;
                this.probUploadOnLineSend = null;

                this.probjWSConnect = null;
                this.probjEvtLog = null;
                this.probjFileInfo = null;
                this.probjFileStream = null;
                this.probjBinaryReader = null;
            }
        }

        private bool GenerateFileToUpload(UploadOnLineParameter paObject)
        {
            try
            {
                string[] strFileName = paObject.FileName.Split(';');
                string[] strFilePathTemp = paObject.FilePath.Split(';');
                string[] strFileType = paObject.FileType.Split(';');
                string[] strFileDate = paObject.FileDate.Split(';');
                string[] strFileMask = paObject.FileMask.Split(';');
                string[] strFileByType = paObject.FileByType.Split(';');
                bool blByFolder = false;

                string[] strFilePath = new string[strFilePathTemp.Length];

                for (int a = 0; a < strFilePathTemp.Length; a++)
                {
                    string normalizedPath = strFilePathTemp[a].TrimEnd(new char[] { '\\' });
                    strFilePath[a] = normalizedPath;
                }

                LocalLog.Trace.WriteLogText("UploadOnLine_GenerateFileToUpload()", string.Concat("Generate file: ", this.prstrFileGenerate));

                //Apagar todos os arquivos da pasta \UploadOnline\temp
                string[] strFileList = Directory.GetFiles(this.prstrPathUploadOnlineTemp, @"*.*");
                foreach (string strFileUpload in strFileList)
                {
                    File.Delete(strFileUpload);
                }

                strFileList = null;

                for (int i = 0; i < strFileName.Length; i++)
                {
                    string stFileNameAndType = string.Concat(strFileName[i].ToLower(), strFileType[i].ToLower());
                    string stFileName = strFileName[i].ToLower();
                    string strFileFolderName = strFilePath[i].ToLower();

                    if (stFileNameAndType == "eventlog")
                    {
                        this.probjEvtLog = new GenerateLogEvent();
                        this.probjEvtLog.GenerateEventFile(this.prstrPathUploadOnlineTemp, DateTime.Now.Date, false);
                        this.probjEvtLog = null;
                    }
                    else
                    {
                        if (strFileMask[i].Trim() != "")
                        {
                            // Nome do Arquivo renomeado.
                            //Nome tem que ter "[]"
                            //A mascara será recolocada dentro do arquivo
                            stFileName = strFileName[i].ToLower().Replace("[", strFileMask[i].Trim()).Replace("]", "").Replace("[", "");
                        }

                        stFileName = string.Concat(stFileName, ".", strFileType[i]);
                        stFileName = stFileName.ToLower();

                        //tratar byfolder com máscara
                        if (strFilePath[i].Trim().IndexOf("[") > 0 && strFilePath[i].Trim().IndexOf("]") > 0)
                        {
                            if (strFileMask[i].Trim() != "")
                            {
                                // Nome da pastarenomeada.
                                //Nome da pasta tem que ter "[]"
                                //A mascara será recolocada dentro do path
                                strFileFolderName = strFileFolderName.Replace("[", strFileMask[i].Trim()).Replace("]", "");
                            }
                        }

                        switch (strFileByType[i].Trim().ToLower())
                        {
                            case "byname":
                            case "bydate":

                                //Tratar o nome do arquivo por mascara da data se existir.
                                if (strFileDate[i].ToLower().Trim() != "")
                                {
                                    //bydate
                                    string strResultHour = "00:00:00";
                                    DateTime dtFileDateTime = Convert.ToDateTime(string.Concat(Convert.ToDateTime(strFileDate[i].ToLower()).ToString("dd/MM/yyyy"), " ", Convert.ToDateTime(strResultHour).ToString("HH:mm:ss")));

                                    string strYear = dtFileDateTime.Year.ToString();
                                    string strYearSmall = strYear.Substring(2, 2);
                                    string strMonth = dtFileDateTime.Month.ToString("00");
                                    string strDay = dtFileDateTime.Day.ToString("00");

                                    if (stFileName.IndexOf("yyyy") > 0)
                                    {
                                        stFileName = stFileName.Replace("yyyy", strYear);
                                    }
                                    else if (stFileName.IndexOf("yy") > 0)
                                    {
                                        stFileName = stFileName.Replace("yyyy", strYearSmall);
                                    }

                                    if (stFileName.IndexOf("mm") > 0)
                                    {
                                        stFileName = stFileName.Replace("mm", strMonth);
                                    }

                                    if (stFileName.IndexOf("dd") > 0)
                                    {
                                        stFileName = stFileName.Replace("dd", strDay);
                                    }
                                }

                                string[] strFileNameOne = new string[1];
                                strFileNameOne[0] = stFileName;
                                CopyFiles(strFileNameOne, strFilePath[i].ToLower());
                                break;

                            case "byfolder":
                                if (strFileDate[i].ToLower().Trim() != "")
                                {
                                    if (strFileDate[i].ToLower().Trim().IndexOf("|") > 0)
                                    {
                                        //byrangedate
                                        string[] strDateStartEnd = strFileDate[i].ToLower().Trim().Split('|');

                                        string strResultHour = "00:00:00";
                                        DateTime dtDateStart = Convert.ToDateTime(string.Concat(Convert.ToDateTime(strDateStartEnd[0]).ToString("dd/MM/yyyy"), " ", Convert.ToDateTime(strResultHour).ToString("HH:mm:ss")));
                                        DateTime dtDateEnd = Convert.ToDateTime(string.Concat(Convert.ToDateTime(strDateStartEnd[1]).ToString("dd/MM/yyyy"), " ", Convert.ToDateTime(strResultHour).ToString("HH:mm:ss")));

                                        TimeSpan ts = (dtDateEnd - dtDateStart);
                                        double QDays = ts.TotalDays;
                                        int intQDays = Convert.ToInt32(QDays + 1);

                                        string[] strFoldersNames = new string[intQDays];

                                        for (int j = 0; j <= intQDays; j++)
                                        {
                                            string stFolderNameTemp = strFileFolderName;

                                            if (DateTime.Compare(dtDateEnd.Date, dtDateStart.Date) >= 0)
                                            {
                                                string strYear = dtDateStart.Year.ToString();
                                                string strYearSmall = strYear.Substring(2, 2);
                                                string strMonth = dtDateStart.Month.ToString("00");
                                                string strDay = dtDateStart.Day.ToString("00");

                                                if (stFolderNameTemp.IndexOf("yyyy") > 0)
                                                {
                                                    stFolderNameTemp = stFolderNameTemp.Replace("yyyy", strYear);
                                                }
                                                else if (stFolderNameTemp.IndexOf("yy") > 0)
                                                {
                                                    stFolderNameTemp = stFolderNameTemp.Replace("yyyy", strYearSmall);
                                                }

                                                if (stFolderNameTemp.IndexOf("mm") > 0)
                                                {
                                                    stFolderNameTemp = stFolderNameTemp.Replace("mm", strMonth);
                                                }

                                                if (stFolderNameTemp.IndexOf("dd") > 0)
                                                {
                                                    stFolderNameTemp = stFolderNameTemp.Replace("dd", strDay);
                                                }

                                                strFoldersNames[j] = stFolderNameTemp;
                                                dtDateStart.AddDays(1);
                                            }
                                        }

                                        blByFolder = true;
                                        CopyFolders(strFoldersNames, this.prstrPathUploadOnlineTemp);
                                    }
                                    else
                                    {
                                        string strResultHour = "00:00:00";
                                        DateTime dtFileDateTime = Convert.ToDateTime(string.Concat(Convert.ToDateTime(strFileDate[i].ToLower()).ToString("dd/MM/yyyy"), " ", Convert.ToDateTime(strResultHour).ToString("HH:mm:ss")));

                                        string strYear = dtFileDateTime.Year.ToString();
                                        string strYearSmall = strYear.Substring(2, 2);
                                        string strMonth = dtFileDateTime.Month.ToString("00");
                                        string strDay = dtFileDateTime.Day.ToString("00");

                                        if (strFileFolderName.IndexOf("yyyy") > 0)
                                        {
                                            strFileFolderName = strFileFolderName.Replace("yyyy", strYear);
                                        }
                                        else if (strFileFolderName.IndexOf("yy") > 0)
                                        {
                                            strFileFolderName = strFileFolderName.Replace("yyyy", strYearSmall);
                                        }

                                        if (strFileFolderName.IndexOf("mm") > 0)
                                        {
                                            strFileFolderName = strFileFolderName.Replace("mm", strMonth);
                                        }

                                        if (strFileFolderName.IndexOf("dd") > 0)
                                        {
                                            strFileFolderName = strFileFolderName.Replace("dd", strDay);
                                        }

                                        string[] strFolderNameOne = new string[1];
                                        strFolderNameOne[0] = strFileFolderName;
                                        blByFolder = true;
                                        CopyFolders(strFolderNameOne, this.prstrPathUploadOnlineTemp);
                                    }
                                }
                                else
                                {
                                    string[] strFolderNameOne = new string[1];
                                    strFolderNameOne[0] = strFileFolderName;
                                    blByFolder = true;
                                    CopyFolders(strFolderNameOne, this.prstrPathUploadOnlineTemp);
                                }

                                break;

                            case "byrangedate":
                                //Tratar o nome do arquivo por mascara da data se existir.
                                if (strFileDate[i].ToLower().Trim() != "")
                                {
                                    if (strFileDate[i].ToLower().Trim().IndexOf("|") > 0)
                                    {
                                        //byrangedate
                                        string[] strDateStartEnd = strFileDate[i].ToLower().Trim().Split('|');

                                        string strResultHour = "00:00:00";
                                        DateTime dtDateStart = Convert.ToDateTime(string.Concat(Convert.ToDateTime(strDateStartEnd[0]).ToString("dd/MM/yyyy"), " ", Convert.ToDateTime(strResultHour).ToString("HH:mm:ss")));
                                        DateTime dtDateEnd = Convert.ToDateTime(string.Concat(Convert.ToDateTime(strDateStartEnd[1]).ToString("dd/MM/yyyy"), " ", Convert.ToDateTime(strResultHour).ToString("HH:mm:ss")));

                                        TimeSpan ts = (dtDateEnd - dtDateStart);
                                        double QDays = ts.TotalDays;
                                        int intQDays = Convert.ToInt32(QDays);

                                        string[] strFileNames = new string[intQDays + 1];

                                        for (int j = 0; j <= intQDays; j++)
                                        {
                                            string stFileNameTemp = stFileName;

                                            if (DateTime.Compare(dtDateEnd.Date, dtDateStart.Date) >= 0)
                                            {
                                                string strYear = dtDateStart.Year.ToString();
                                                string strYearSmall = strYear.Substring(2, 2);
                                                string strMonth = dtDateStart.Month.ToString("00");
                                                string strDay = dtDateStart.Day.ToString("00");

                                                if (stFileNameTemp.IndexOf("yyyy") > 0)
                                                {
                                                    stFileNameTemp = stFileNameTemp.Replace("yyyy", strYear);
                                                }
                                                else if (stFileNameTemp.IndexOf("yy") > 0)
                                                {
                                                    stFileNameTemp = stFileNameTemp.Replace("yyyy", strYearSmall);
                                                }

                                                if (stFileNameTemp.IndexOf("mm") > 0)
                                                {
                                                    stFileNameTemp = stFileNameTemp.Replace("mm", strMonth);
                                                }

                                                if (stFileNameTemp.IndexOf("dd") > 0)
                                                {
                                                    stFileNameTemp = stFileNameTemp.Replace("dd", strDay);
                                                }

                                                strFileNames[j] = stFileNameTemp;
                                                dtDateStart = dtDateStart.AddDays(1);
                                            }
                                        }

                                        CopyFiles(strFileNames, strFilePath[i].ToLower());
                                    }
                                }
                                break;

                            default:

                                break;
                        }
                    }
                }

                if (Directory.Exists(this.prstrPathUploadOnlineTemp))
                {
                    //Zipar e colocar na pasta \UploadOnline
                    if (!blByFolder)
                    {
                        string[] strFiles = Directory.GetFiles(this.prstrPathUploadOnlineTemp);
                        string[] strPathAndFiles = new string[strFiles.Length];

                        for (int m = 0; m < strFiles.Length; m++)
                        {
                            strPathAndFiles[m] = Path.Combine(this.prstrPathUploadOnlineTemp, strFiles[m]);
                        }

                        if (CompressFolder(strPathAndFiles, this.prtrDestinationPathAndFile))
                        {
                            LocalLog.Trace.WriteLogText("UploadOnLine_GenerateFileToUpload() ByFolder", string.Concat("Successfully file compress. File:", this.prtrDestinationPathAndFile));
                        }
                        else
                        {
                            LocalLog.Trace.WriteLogText("UploadOnLine_GenerateFileToUpload() ByFolder", string.Concat("Unexpected error occurs.", this.prtrDestinationPathAndFile));
                        }

                        foreach (string strFileAndFile in strPathAndFiles)
                        {
                            File.Delete(strFileAndFile);
                        }
                    }
                    else
                    {
                        GetFoldersDirectories(this.prstrPathUploadOnlineTemp);

                        string[] strPathAndFiles = new string[this.ALOut.Count];

                        for (int k = 0; k < this.ALOut.Count; k++)
                        {
                            strPathAndFiles[k] = Path.Combine(this.prstrPathUploadOnlineTemp, this.ALOut[k].ToString());
                        }

                        if (CompressFolder(strPathAndFiles, this.prtrDestinationPathAndFile))
                        {
                            LocalLog.Trace.WriteLogText("UploadOnLine_GenerateFileToUpload()", string.Concat("Successfully file compress. File:", this.prtrDestinationPathAndFile));
                        }
                        else
                        {
                            LocalLog.Trace.WriteLogText("UploadOnLine_GenerateFileToUpload()", string.Concat("Unexpected error occurs.", this.prtrDestinationPathAndFile));
                        }

                        for (int n = 0; n < this.ALOut.Count; n++)
                        {
                            File.Delete(this.ALOut[n].ToString());
                        }

                        this.ALOut = null;
                    }
                }

                if (!File.Exists(this.prtrDestinationPathAndFile))
                {
                    LocalLog.Trace.WriteLogText("UploadOnLine_GenerateFileToUpload()", "Output file does not exixts.");

                    LocalLog.Trace.WriteLogText("UploadOnLine_GenerateFileToUpload()", string.Concat("File not found: ", this.prstrFileGenerate));

                    return false;
                }

                return true;
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("UploadOnLine_GenerateFileToUpload()", "Unexpected error occurs.", Ex);

                this.probjZipLib = null;

                //this.probjWSConnect = new WSConect();
                //this.probjUploadOnLineParameter = new UploadOnLineParameter(Convert.ToInt32(this.probjOrionEquipment.IdTask), Convert.ToString(Status.ExecuteError));
                //this.probjWSConnect.Send(ref this.probjUploadOnLineParameter);

                return false;
            }
            //finally
            //{
            //    this.probjUploadOnLineParameter = null;
            //    this.probjwsOrion = null;
            //    this.probjUploaOnLineStatistic = null;
            //    this.probUploadOnLineSend = null;
            //    this.probjOrionEquipment = null;
            //    this.probjFileInfo = null;
            //}
        }

        private bool CompressFolder(string[] pastrPathAndFiles, string pastrDestinationPathAndFile)   //strPathAndFiles ,this.prtrDestinationPathAndFile
        {
            try
            {
                using (ZipOutputStream s = new ZipOutputStream(File.Create(pastrDestinationPathAndFile)))
                {
                    s.SetLevel(6); // 0-9, 9 being the highest compression
                    byte[] buffer = new byte[4096];

                    foreach (string file in pastrPathAndFiles)
                    {
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);

                        using (FileStream fs = File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            }
                            while (sourceBytes > 0);
                        }
                    }

                    s.Finish();
                    s.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void CopyFiles(string[] pastrFileName, string pastrFilePath)
        {
            //Localizar os arquivos.
            //copiar para a pasta \UploadOnline\temp
            foreach (string strFileName in pastrFileName)
            {
                string strPathAndFileNameAndType = Path.Combine(pastrFilePath.ToLower(), strFileName.ToLower());

                if (File.Exists(strPathAndFileNameAndType))
                {
                    File.Copy(strPathAndFileNameAndType, Path.Combine(this.prstrPathUploadOnlineTemp, strFileName), true);
                }
                else
                {
                    LocalLog.Trace.WriteLogText("UploadOnLine_GenerateFileToUpload()", string.Concat("File not found: ", strPathAndFileNameAndType));
                }
            }
        }

        private void CopyFolders(string[] pastrFolderNames, string pastrPathUploadOnlineTemp)
        {
            foreach (string strFolderName in pastrFolderNames)
            {
                string strFolderNametemp = strFolderName.ToLower();

                if (strFolderNametemp.IndexOf("temp") > 0)
                {
                    strFolderNametemp = strFolderNametemp.Replace("temp",@"\temp");
                }
                
                string strTemp = strFolderNametemp.Substring(0, 3).ToLower();
                string strTargetPath = strFolderNametemp.Replace(strTemp.Replace("temp",@"\temp"), pastrPathUploadOnlineTemp);

                if (Directory.GetDirectories(strFolderName, "*", SearchOption.AllDirectories).Length > 0)
                {
                    foreach (string dirPath in Directory.GetDirectories(strFolderName, "*", SearchOption.AllDirectories))
                    {
                        string strNewPath = Path.Combine(strTargetPath, dirPath.Replace(strFolderNametemp, ""));
                        Directory.CreateDirectory(strNewPath);

                        foreach (string strFile in Directory.GetFiles(strFolderName, "*.*", SearchOption.AllDirectories))
                        {
                            FileInfo strFileInfo = new FileInfo(strFile);
                            File.Copy(strFile, string.Concat(strNewPath, @"\", strFileInfo.Name), true);
                        }
                    }
                }
                else
                {
                    foreach (string strFile in Directory.GetFiles(strFolderName, "*.*", SearchOption.AllDirectories))
                    {
                        Directory.CreateDirectory(strTargetPath);

                        FileInfo strFileInfo = new FileInfo(strFile);
                        File.Copy(strFile, string.Concat(strTargetPath, @"\", strFileInfo.Name) , true);
                    }
                }

            }
        }

        private void GetFoldersDirectories(string strFolderName)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(strFolderName);

            FileInfo[] Files = dirinfo.GetFiles();
            foreach (FileInfo fileinfo in Files)
            {
                this.ALOut.Add(fileinfo.FullName);
            }

            string[] strDiretoriesTemp = Directory.GetDirectories(strFolderName);

            DirectoryInfo[] directories = dirinfo.GetDirectories();

            foreach (var directory in directories)
            {
                GetFoldersDirectories(directory.FullName);
            };
        }

        private bool UpdateStatus(int paintSequqnce, Status paStatus)
        {
            LocalLog.Trace.WriteLogText("UploadOnLine_SendPermission()", "");

            try
            {
                this.probjUploaOnLineStatistic = new UploadOnLineStatistic(paintSequqnce, Convert.ToString(paStatus));
                this.probjWSConnect.Send(ref probjUploaOnLineStatistic);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool CalculateCRC32File(string pastrDestinationPathAndFile)
        {
            try
            {
                this.probjZipLib = new ZipLib();
                this.prstrCRC32File = this.probjZipLib.CRC32File(this.prtrDestinationPathAndFile);
                this.probjZipLib = null;
                return true;
            }
            catch
            {
                return false;
            }
        }
            
        private bool Upload(UploadOnLineSend paobjUploadOnLineSend, FileInfo paobjFileInfo)
        {
            try
            {
                LocalLog.Trace.WriteLogText("UploadOnLine_Upload()", string.Concat("Start sending: ", paobjUploadOnLineSend.FileName));

                DateTime dtStartDate = DateTime.Now;
                DateTime dtNextUpdate = DateTime.Now.AddMinutes(5);

                int DateTimeNow = 0;
                int intSizeBuffer = 0;

                if (!UpdateStatus(this.probjUploadOnLineParameter.Sequence, Status.Send))
                {
                    return false;
                }

                DateTimeNow = Convert.ToInt16(DateTime.Now.Hour);
                intSizeBuffer = this.probUploadOnLineSend.SizeBuffer;

                this.probjFileStream = new FileStream(paobjFileInfo.ToString(), FileMode.Open, FileAccess.Read, FileShare.Read, intSizeBuffer);
                this.probjBinaryReader = new BinaryReader(this.probjFileStream);

                Int64 lngMissingAmount = paobjFileInfo.Length;
                while (lngMissingAmount > 0)
                {
                    DateTimeNow = Convert.ToInt16(DateTime.Now.Hour);

                    if (lngMissingAmount > intSizeBuffer)
                    {
                        paobjUploadOnLineSend.FileData = new byte[intSizeBuffer];
                    }
                    else
                    {
                        paobjUploadOnLineSend.FileData = new byte[lngMissingAmount];
                    }
                    
                    int intBytesRead = this.probjBinaryReader.Read(paobjUploadOnLineSend.FileData, 0, paobjUploadOnLineSend.FileData.Length);
                    
                    if (intBytesRead <= 0)
                    {
                        break;
                    }

                    lngMissingAmount -= intBytesRead;

                    if (!this.probjWSConnect.Send(ref paobjUploadOnLineSend))
                    {
                        this.probjwsOrion = null;
                        paobjUploadOnLineSend = null;

                        this.probjBinaryReader.Close();
                        this.probjFileStream.Close();

                        this.probjBinaryReader = null;
                        this.probjFileStream = null;

                        return false;
                    }

                    paobjUploadOnLineSend.StartSending = false;

                    if (dtNextUpdate <= DateTime.Now)
                    {
                        if (!UpdateStatus(this.probjUploadOnLineParameter.Sequence, Status.Send))
                        {
                            return false;
                        }

                        dtNextUpdate = DateTime.Now.AddMinutes(5);
                    }

                    //if (this.probUploadOnLineSend.Delay > 0)
                    //{
                    //    Thread.Sleep(this.probUploadOnLineSend.Delay);
                    //}
                    Thread.Sleep(50);

                    System.Windows.Forms.Application.DoEvents();
                }

                this.probjBinaryReader.Close();
                this.probjFileStream.Close();

                
                if (!UpdateStatus(this.probjUploadOnLineParameter.Sequence, Status.ExecuteOk))
                {
                    return false;
                }

                LocalLog.Trace.WriteLogText("UploadOnLine_Upload()", "Successfully send file.");

                return true;
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("UploadOnLine_Upload()", "Unexpected error occurs on upload", Ex);
                return false;
            }
        }
    }
}
