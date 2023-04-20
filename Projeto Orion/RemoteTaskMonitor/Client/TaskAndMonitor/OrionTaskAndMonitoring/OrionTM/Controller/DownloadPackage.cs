
using System;
using OrionTMClient.Infra;
using OrionTMClient.Infra.ZipLib;
using System.IO;
using System.IO.Compression;
using System.Threading;
using OrionTMClient.Entity;
using OrionTMClient.Interface;
using ICSharpCode.SharpZipLib.Zip;
using System.Diagnostics;
using static System.Net.WebRequestMethods;
using System.Xml;
using ICSharpCode.SharpZipLib.Core;


namespace OrionTMClient.Controller
{
    internal class DownloadPackage : Common
    {
        private DownloadPackageStatistic probjDownloadPackageStatistic;
        private DownloadPackageSend probjDownloadPackageSend;
        private DownloadPackageParameter probjDownloadPackageParameter;

        private OrionEquipment probjOrionEquipment;
        private FileInfo probjFileInfo;
        private BinaryWriter probjFileOut;
        private string prstrPathDownloadPackage;
        private string prstrPathDownloadPackageTemp;
        private string prstrDiretoryToExclude;
        private string prtrDestinationPathAndFile;
        private string prstrFileGenerate;

        private long prstrCRC32File;
        
        internal DownloadPackage()
        {
        }

        ~DownloadPackage()
        {
        }

        internal void Execute()
        {

            try
            {
                LocalLog.Trace.WriteLogText("DownloadPackage_Execute()", "Start the download package process.");
                this.probjOrionEquipment = OrionEquipment;

                if (ExecuteDownload())
                {
                    if (MakeFilesAvailable())
                    {
                        if (this.probjDownloadPackageParameter.InstalationDateHour.ToLower() == "imed")
                        {
                            LocalLog.Trace.WriteLogText("DownloadPackage_Execute()", string.Concat("The package ", this.probjDownloadPackageParameter.FileNamePackage, " will be installed immediately."));
                            if (ExecuteScriptCopyFilesBat())
                            {
                                LocalLog.Trace.WriteLogText("DownloadPackage_Execute()", string.Concat("The package ", this.probjDownloadPackageParameter.FileNamePackage, " is succefully installed."));
                            }

                            if (!UpdateStatus(this.probjDownloadPackageParameter.Sequence, Status.ExecuteOk))
                            {
                                return;
                            }
                        }
                        else
                        {
                            //Escreve no XMLEquipment.xml data,hora e qual package será instalado.
                            if (WriteInEquipmentXmlPackageInstallation(this.probjDownloadPackageParameter.FileNamePackage, this.probjDownloadPackageParameter.InstalationDateHour))
                            {
                                LocalLog.Trace.WriteLogText("DownloadPackage_Execute_WriteInEquipmentXmlPackageInstalation()", string.Concat("The package ", this.probjDownloadPackageParameter.FileNamePackage, " will be installed on ", this.probjDownloadPackageParameter.InstalationDateHour));
                            }

                            if (!UpdateStatus(this.probjDownloadPackageParameter.Sequence, Status.ExecuteOk))
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (!UpdateStatus(this.probjDownloadPackageParameter.Sequence, Status.ExecuteError))
                        {
                            return;
                        }
                    }
                }
                else
                {
                    if (!UpdateStatus(this.probjDownloadPackageParameter.Sequence, Status.ExecuteError))
                    {
                        return;
                    }
                }
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("DownloadPackage_Execute()", "An error occured on execute on Download Package.", Ex);
                
                if (!UpdateStatus(this.probjDownloadPackageParameter.Sequence, Status.ExecuteError))
                {
                    return;
                }
            }
            finally
            { 
                this.probjwsOrion = null;
                this.probjZipLib = null;
                this.probjDownloadPackageParameter = null;
                this.probjDownloadPackageStatistic = null;
                this.probjDownloadPackageSend = null;
                this.probjWSConnect = null;
                this.probjFileInfo = null;
            }
        }

        private bool ExecuteDownload()
        {
            try
            {
                this.probjOrionEquipment = OrionEquipment;

                LocalLog.Trace.WriteLogText("DownloadPackage_ExecuteDownload() start");
    
                this.probjwsOrion = new WSOrion.MainServerOrionTM();
                this.probjZipLib = new ZipLib();
                this.probjWSConnect = new WSConect();
                
                ApplicationPath = System.Windows.Forms.Application.StartupPath;

                LocalLog.Trace.WriteLogText("DownloadPackage_ExecuteDownload() Parameter will be receive.");

                this.probjDownloadPackageParameter = new DownloadPackageParameter(Convert.ToInt32(this.probjOrionEquipment.IdTask), Convert.ToString(Status.Start));
                this.probjWSConnect.Send(ref this.probjDownloadPackageParameter);

                LocalLog.Trace.WriteLogText("DownloadPackage_ExecuteDownload() Parameter received.");

                if (this.probjDownloadPackageParameter.Status == Convert.ToString(Status.Start))
                {
                    if (!this.probjDownloadPackageParameter.FileNamePackage.ToLower().Contains(".zip"))
                    {
                        this.prstrFileGenerate = string.Concat(probjDownloadPackageParameter.FileNamePackage.ToLower(), ".zip");
                    }
                    else
                    {
                        this.prstrFileGenerate = probjDownloadPackageParameter.FileNamePackage.ToLower();
                    }

                    this.prstrPathDownloadPackage = Path.Combine(ApplicationPath, "DownloadPackage");
                    this.prstrPathDownloadPackageTemp = Path.Combine(this.prstrPathDownloadPackage, "Temp");
                    this.prtrDestinationPathAndFile = Path.Combine(this.prstrPathDownloadPackage, this.prstrFileGenerate);


                    //return true;
                    this.prstrDiretoryToExclude = this.prstrPathDownloadPackageTemp;

                    if (!Directory.Exists(this.prstrPathDownloadPackageTemp))
                    {
                        Directory.CreateDirectory(this.prstrPathDownloadPackageTemp);
                    }

                    LocalLog.Trace.WriteLogText("DownloadOnLine_ExecutaDownload()", string.Concat("Defines a file name:", this.prstrFileGenerate));

                    this.probjDownloadPackageStatistic = new DownloadPackageStatistic();
                    this.probjDownloadPackageStatistic.Sequence = this.probjDownloadPackageParameter.Sequence;
                    
                    LocalLog.Trace.WriteLogText("DownloadPackage_ExecuteDownload()", string.Concat("File:", this.probjDownloadPackageParameter.FileNamePackage));

                    this.probjDownloadPackageSend = new DownloadPackageSend();
                    this.probjDownloadPackageSend.FileName = this.probjDownloadPackageParameter.FileNamePackage;
                    this.probjDownloadPackageSend.Sequence = this.probjDownloadPackageParameter.Sequence;
                    this.probjDownloadPackageSend.InitialPosition = 0;
                    //this.probjDownloadPackageSend.SizeBuffer = 3072;
                    this.probjDownloadPackageSend.SizeBuffer = 4096;
                    this.probjDownloadPackageSend.Status = Convert.ToString(Status.Start);
                    this.probjDownloadPackageSend.EndedFileSend = false;
                    this.probjDownloadPackageSend.TotalSize = 0;
                    this.probjDownloadPackageSend.CRCFile = 0;

                    if (!this.probjWSConnect.Send(ref this.probjDownloadPackageSend))
                    {
                        return false;
                    }

                    //Verifica se o arquivo ja existe na pasta de download
                    if (System.IO.File.Exists(this.prtrDestinationPathAndFile))
                    {
                        LocalLog.Trace.WriteLogText("DownloadPackage_ExecuteDownload()", string.Concat("File exists in ", this.prtrDestinationPathAndFile));
                        this.probjFileInfo = new FileInfo(this.prtrDestinationPathAndFile);
                        
                        if (this.prtrDestinationPathAndFile.Length == this.probjDownloadPackageSend.SizeBuffer)
                        {
                            LocalLog.Trace.WriteLogText("DownloadPackage_ExecuteDownload()", "File totaly send. Verifying CRC...");

                            //Verify CRC
                            CalculateCRC32File(this.prtrDestinationPathAndFile);

                            if (this.prstrCRC32File == probjDownloadPackageSend.CRCFile)
                            {
                                LocalLog.Trace.WriteLogText("DownloadPackage_ExecuteDownload()", "CRC Ok!!! Update Statistic.");

                                this.probjDownloadPackageStatistic.Status = Convert.ToString(Status.ExecuteCRCOk);
                            }
                            else
                            {
                                LocalLog.Trace.WriteLogText("DownloadPackage_ExecuteDownload()", "CRC error!! Update Statistic.");

                                this.probjDownloadPackageStatistic.Status = Convert.ToString(Status.ExecuteCRCError);

                                System.IO.File.Delete(this.prtrDestinationPathAndFile);
                            }

                            this.probjWSConnect.Send(ref this.probjDownloadPackageStatistic);
                        }
                        else
                        {
                            LocalLog.Trace.WriteLogText("DownloadPackage_ExecuteDownload()", string.Concat("File is receiving in ", prtrDestinationPathAndFile));
                            this.probjFileInfo = new FileInfo(prtrDestinationPathAndFile);

                            if (this.probjFileInfo.Length <= 0 || this.probjFileInfo.Length > this.probjDownloadPackageSend.TotalSize)
                            {
                                LocalLog.Trace.WriteLogText("DownloadPackage_ExecuteDownload()", "Receiving file fail, excludethe file.");

                                System.IO.File.Delete(prtrDestinationPathAndFile);
                            }
                            else
                            {
                                LocalLog.Trace.WriteLogText("DownloadPackage_ExecuteDownload()", "Continue receiving the file.");

                                this.probjDownloadPackageSend.InitialPosition = this.probjFileInfo.Length;
                            }
                        }
                    }

                    if (!Download(this.probjDownloadPackageSend))
                    {
                        return false;
                    }

                }
            }
            catch (Exception Ex)
            {
                return false;
            }
            
            return true;
        }

        private bool Download(DownloadPackageSend paobjPackageSend)
        {
            LocalLog.Trace.WriteLogText("DownloadPackage_Download()", string.Concat("Start receive: ", paobjPackageSend.FileName));

            if (!this.probjWSConnect.Send(ref paobjPackageSend))
            {
                return false;
            }

            DateTime dtStartDate = DateTime.Now;
            DateTime dtNextUpdate = DateTime.Now.AddMinutes(5);

            int DateTimeNow = 0;

            Int64 lngMissingAmount = paobjPackageSend.TotalSize - paobjPackageSend.InitialPosition;
            
            if (paobjPackageSend.InitialPosition == 0)
            {
                this.probjFileOut = new BinaryWriter(System.IO.File.Create(this.prtrDestinationPathAndFile));
            }
            else
            {
                this.probjFileOut = new BinaryWriter(System.IO.File.OpenWrite(this.prtrDestinationPathAndFile));
                this.probjFileOut.Seek(0, SeekOrigin.End);
            }

            try
            {
                this.probjDownloadPackageStatistic.Status = Convert.ToString(Status.Send);
                if (!this.probjWSConnect.Send(ref this.probjDownloadPackageStatistic))
                {
                    return false;
                }

                while (lngMissingAmount > 0)
                {
                    DateTimeNow = Convert.ToInt16(DateTime.Now.Hour);

                    paobjPackageSend.EndedFileSend = false;
                    paobjPackageSend.FileData = null;
                    paobjPackageSend.Status = Convert.ToString(Status.Send);

                    if (paobjPackageSend.SizeBuffer > lngMissingAmount)
                    {
                        paobjPackageSend.SizeBuffer = Convert.ToInt32(lngMissingAmount);
                    }

                    LocalLog.Trace.WriteLogText("DownloadPackage_Download() Send before.");
                    
                    if (!this.probjWSConnect.Send(ref paobjPackageSend))
                    {
                        return false;
                    }

                    LocalLog.Trace.WriteLogText("DownloadOnLine_Download() Send after");

                    if (paobjPackageSend.FileData.Length > 0)
                    {
                        this.probjFileOut.Write(paobjPackageSend.FileData, 0, paobjPackageSend.FileData.Length);
                        this.probjFileOut.Flush();
                    }

                    lngMissingAmount -= paobjPackageSend.FileData.Length;
                    paobjPackageSend.InitialPosition += paobjPackageSend.FileData.Length;

                    //this.probjDownloadPackageStatistic
                    //this.probjC4.W += paobjC5.F.Length;


                    if (paobjPackageSend.EndedFileSend && lngMissingAmount > 0)
                    {
                        this.probjFileOut.Close();

                        LocalLog.Trace.WriteLogText("DownloadOnLine_Download()", new Exception(string.Concat("The server is sending a different file Size buffer.",
                            " File Name=", paobjPackageSend.FileData,
                            " Buffer Size =", paobjPackageSend.SizeBuffer,
                            " lngMissingAmount =", lngMissingAmount.ToString())));

                        return false;
                    }

                    if (dtNextUpdate <= DateTime.Now)
                    {
                        LocalLog.Trace.WriteLogText("DownloadPackage_Download() Send dtNextUpdate <= DateTime.Now.");

                        this.probjDownloadPackageStatistic.Status = Convert.ToString(Status.Send);
                        if (!this.probjWSConnect.Send(ref this.probjDownloadPackageStatistic))
                        {
                            return false;
                        }

                        dtNextUpdate = DateTime.Now.AddMinutes(5);
                    }

                    if (paobjPackageSend.Delay > 0)
                    {
                        Thread.Sleep(paobjPackageSend.Delay);
                    }

                    System.Windows.Forms.Application.DoEvents();
                }

                paobjPackageSend.EndedFileSend = true;
                paobjPackageSend.FileData = null;
                paobjPackageSend.Status = Convert.ToString(Status.ExecuteOk);

                LocalLog.Trace.WriteLogText("DownloadPackage_Download() Send EndedFileSend = true");


                if (!this.probjWSConnect.Send(ref paobjPackageSend))
                {
                    return false;
                }

                LocalLog.Trace.WriteLogText("DownloadPackage_Download() Send Status.ExecuteOk");

                this.probjDownloadPackageStatistic.Status = Convert.ToString(Status.ExecuteOk);
                if (!this.probjWSConnect.Send(ref this.probjDownloadPackageStatistic))
                {
                    return false;
                }

                LocalLog.Trace.WriteLogText("DownloadPackage_Download() Send finished.");

                return true;
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("DownloadPackage_Download() Unespected error occured.", Ex);

                this.probjDownloadPackageStatistic.Status = Convert.ToString(Status.ExecuteError);
                if (!this.probjWSConnect.Send(ref this.probjDownloadPackageStatistic))
                {
                    return false;
                }

                return false;
            }
            finally
            {
                this.probjFileOut.Close();
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

        private bool UpdateStatus(int paintSequqnce, Status paStatus)
        {
            LocalLog.Trace.WriteLogText("DownloadPackage_SendPermission()", "");

            try
            {
                this.probjDownloadPackageStatistic = new DownloadPackageStatistic(paintSequqnce, Convert.ToString(paStatus));
                this.probjWSConnect.Send(ref this.probjDownloadPackageStatistic);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool MakeFilesAvailable()
        {
            try
            {
                LocalLog.Trace.WriteLogText("DownloadPackage_MakeFilesAvailable()", "Start.");

                LocalLog.Trace.WriteLogText("DownloadPackage_MakeFilesAvailable()", String.Concat("this.prtrDestinationPathAndFile=", this.prtrDestinationPathAndFile));
                LocalLog.Trace.WriteLogText("DownloadPackage_MakeFilesAvailable()", String.Concat("this.prstrPathDownloadPackageTemp=", this.prstrPathDownloadPackageTemp));

                ExtractZipFile(this.prtrDestinationPathAndFile, this.prstrPathDownloadPackageTemp);

                LocalLog.Trace.WriteLogText("DownloadPackage_MakeFilesAvailable()", "End.");

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ExtractZipFile(string srcFile, string dstFolder)
        {
            ZipFile zf = null;

            try
            {
                LocalLog.Trace.WriteLogText("DownloadPackage_ExtractZipFile()", "Start.");

                FileStream fs = System.IO.File.OpenRead(srcFile);
                zf = new ICSharpCode.SharpZipLib.Zip.ZipFile(fs);

                foreach (ICSharpCode.SharpZipLib.Zip.ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile) continue;     

                    var entryFileName = zipEntry.Name;
                    var buffer = new byte[4096];        
                    var zipStream = zf.GetInputStream(zipEntry);

                    var fullZipToPath = Path.Combine(dstFolder, entryFileName);
                    var directoryName = Path.GetDirectoryName(fullZipToPath);

                    if (directoryName != null && directoryName.Length <= 0) continue;
                    if (directoryName != null) Directory.CreateDirectory(directoryName);

                    using (var streamWriter = System.IO.File.Create(fullZipToPath))
                        StreamUtils.Copy(zipStream, streamWriter, buffer);

                    LocalLog.Trace.WriteLogText("DownloadPackage_ExtractZipFile()", "End.");
                }
            }
            catch (Exception)
            {
                if (zf != null)
                {
                    zf.Close();
                }

                LocalLog.Trace.WriteLogText("DownloadPackage_ExtractZipFile()", "Failed.");

                return false;
            }
            finally
            {
                if (zf != null)
                {
                    zf.Close();
                }
            }

            return true;

        }

        private bool ExecuteScriptCopyFilesBat()
        {
            try
            {
                LocalLog.Trace.WriteLogText("DownloadPackage_ExecuteScriptCopyFilesBat()", "Start.");


                if (Directory.Exists(this.prstrPathDownloadPackageTemp))
                { 
                    //TODO
                    // apagar tudo antes de colocar novos arquivo
                }

                    
                ApplicationPath = System.Windows.Forms.Application.StartupPath;
                string strPathBatFile = string.Concat(this.prstrPathDownloadPackageTemp, @"\copyfiles.bat");

                int ExitCode;
                ProcessStartInfo ProcessInfo;
                Process process;

                ProcessInfo = new ProcessStartInfo("cmd.exe", "/c " + strPathBatFile);
                ProcessInfo.CreateNoWindow = true;
                ProcessInfo.UseShellExecute = false;
                ProcessInfo.WorkingDirectory = this.prstrPathDownloadPackageTemp;
                ProcessInfo.RedirectStandardError = true;
                ProcessInfo.RedirectStandardOutput = false;

                process = Process.Start(ProcessInfo);
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.WaitForExit();

                ExitCode = process.ExitCode;

                process.Close();
                process.Dispose();

                LocalLog.Trace.WriteLogText("DownloadPackage_ExecuteScriptCopyFilesBat()", "End.");


                return true;
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("DownloadPackage_CopyFilesBat()", "An unexpedted error occured", Ex);
                return false;
            }
        }

        private bool WriteInEquipmentXmlPackageInstallation(string strInstalationPackage, string strInstalationDateTime)
        {
            try
            {
                string strDriver = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                string strPathXml = Path.Combine(strDriver, "XMLEquipment.xml");

                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.Load(strPathXml);

                foreach (XmlNode node in XmlDoc.DocumentElement.ChildNodes)
                {
                    if (node.Name == "InstalationPackage")
                    {
                        node.InnerText = strInstalationPackage;
                    }

                    if (node.Name == "InstalationDateTime")
                    {
                        node.InnerText = strInstalationDateTime;
                    }
                }

                XmlDoc.Save(strPathXml);
                return true;
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("WriteInEquipmentXmlPackageInstalation() Exception: ", Ex.ToString());

                return false;
            }
        }
    }
}
