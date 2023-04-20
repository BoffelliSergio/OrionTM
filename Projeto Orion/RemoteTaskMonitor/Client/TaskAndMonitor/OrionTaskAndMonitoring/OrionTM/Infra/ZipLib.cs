using System;
using System.Collections;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Zip.Compression;

namespace OrionTMClient.Infra.ZipLib
{
    public class ZipLib
    {
        //Lista dos sub-diretorios e arquivos de um diretorio
        private ArrayList prarrListDir;

        //Lista dos tipos sub-diretorios e arquivos de um diretorio
        private ArrayList prarrListType;

        //Lista dos arquivos do arquivo compactado
        private ArrayList prarrListComp;

        //Erro ocorrido durante o processo
        public Exception Error;

        //Dados informativos
        private long prlngCRC32;
        private Int64 prlngOriginalSize;

        public ZipLib()
        {
        }

        ~ZipLib()
        {
        }

        public ArrayList ListDir { get { return this.prarrListDir; } }
        public ArrayList ListType { get { return this.prarrListType; } }
        public ArrayList ListComp { get { return this.prarrListComp; } }
        public long CRC32
        {
            get
            {
                return this.prlngCRC32;
            }
        }
        public string CRC32Hex
        {
            get
            {
                return Convert.ToString(this.prlngCRC32, 16);
            }
        }
        public long CRC32File(string pastrFile)
        {
            FileStream objFileStream;
            BinaryReader objBinaryReader;

            try
            {
                Crc32 objCrc32 = new Crc32();

                FileInfo objFile = new FileInfo(pastrFile);
                this.prlngOriginalSize = objFile.Length;

                objFileStream = new FileStream(pastrFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                objBinaryReader = new BinaryReader(objFileStream);

                objCrc32.Update(objBinaryReader.ReadBytes((int)objFile.Length));

                objBinaryReader.Close();
                objFileStream.Close();

                this.prlngCRC32 = objCrc32.Value;

                return this.prlngCRC32;
            }
            catch (Exception Ex)
            {
                this.Error = Ex;
                return 0;
            }
        }

        public bool Compress(string pastrPathIn, string pastrFileOut)
        {
            return Compress(new string[] { pastrPathIn }, pastrFileOut);
        }

        public bool Compress(string[] pastrPathIn, string pastrFileOut)
        {
            FileStream objFileStream = null;
            FileStream objFileOutput = null;
            BinaryReader objBinaryReader = null;
            BinaryWriter objWriter = null;

            try
            {
                this.prarrListComp = new ArrayList();

                pastrFileOut = pastrFileOut.Replace(" ", "_");

                objFileOutput = new FileStream(pastrFileOut, FileMode.Create);

                using (GZipOutputStream objGZipStreamt = new GZipOutputStream(objFileOutput, 10240))
                {
                    for (int i = 0; i < pastrPathIn.Length; i++)
                    {
                        ObtemListDir(pastrPathIn[i]);

                        if (this.prarrListDir.Count > 0)
                        {
                            string strType;
                            string strRootFullName = "";

                            objWriter = new BinaryWriter(objGZipStreamt);

                            for (int j = 0; j < this.prarrListDir.Count; j++)
                            {
                                strType = (string)this.prarrListType[j];
                                switch (strType)
                                {
                                    case "PathComp":
                                    case "RootName":
                                        objWriter.Write(strType);
                                        objWriter.Write((string)this.prarrListDir[j]);
                                        break;

                                    case "RootFullName":
                                        objWriter.Write(strType);
                                        strRootFullName = (string)this.prarrListDir[j];
                                        objWriter.Write(strRootFullName);
                                        break;

                                    case "Dir":
                                        objWriter.Write(strType);
                                        objWriter.Write(((string)this.prarrListDir[j]).Replace(strRootFullName, ""));
                                        this.prarrListComp.Add((string)this.prarrListDir[j]);
                                        break;

                                    case "File":
                                        objWriter.Write(strType);
                                        string strPathFile = (string)this.prarrListDir[j];
                                        FileInfo objFile = new FileInfo(strPathFile);
                                        objFileStream = new FileStream(objFile.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
                                        objBinaryReader = new BinaryReader(objFileStream);

                                        objWriter.Write(objFile.DirectoryName.Replace(strRootFullName, ""));
                                        objWriter.Write(objFile.Name);
                                        objWriter.Write(objFile.Length);
                                        objWriter.Write(objBinaryReader.ReadBytes((int)objFile.Length));

                                        this.prarrListComp.Add(objFile.FullName);

                                        objFile = null;

                                        break;
                                }
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception Ex)
            {
                this.Error = Ex;
                return false;
            }
            finally
            {
                this.prarrListDir = null;
                this.prarrListType = null;

                if (objFileStream != null)
                    objFileStream.Close();

                if (objBinaryReader != null)
                    objBinaryReader.Close();

                if (objFileOutput != null)
                    objFileOutput.Close();


                objFileStream = null;
                objBinaryReader = null;
                objFileOutput = null;
                objWriter = null;
            }
        }

        public bool DeCompress(string pastrFileIn)
        {
            return DeCompress(pastrFileIn, "", "", false, true);
        }

        public bool DeCompress(string pastrFileIn, string pastrPathOut)
        {
            return DeCompress(pastrFileIn, pastrPathOut, "", false, true);
        }

        public bool DeCompress(string pastrFileIn, string pastrPathOut, string pastrFileOut)
        {
            return DeCompress(pastrFileIn, pastrPathOut, pastrFileOut, true, true);
        }

        public bool DeCompress(string pastrFileIn, string pastrPathOut, string pastrFileOut, bool pablnFilesOnly, bool pablnReplace)
        {
            FileStream objFileStream = null;

            try
            {
                this.prarrListComp = new ArrayList();

                objFileStream = new FileStream(pastrFileIn, FileMode.Open, FileAccess.Read, FileShare.Read);

                using (GZipInputStream objGZipStreamt = new GZipInputStream(objFileStream))
                {
                    BinaryReader objReader = new BinaryReader(objGZipStreamt);
                    bool blnFim = false;

                    string strType;
                    string strPathComp;
                    string strRoot;
                    string strRootFullName;
                    string strDir;
                    string strFilePath;
                    string strFileName;
                    long lngFileLength;
                    long lngQtdFiles = 0;

                    string strRootOut = "";
                    string strPathOut;

                    try
                    {
                        while (!blnFim)
                        {
                            strType = objReader.ReadString();

                            switch (strType)
                            {
                                case "PathComp":
                                    strPathComp = objReader.ReadString();
                                    break;

                                case "RootName":
                                    strRoot = objReader.ReadString();
                                    break;

                                case "RootFullName":
                                    strRootFullName = objReader.ReadString();

                                    if (pastrPathOut != "")
                                        strRootOut = pastrPathOut;
                                    else
                                        strRootOut = strRootFullName;

                                    break;

                                case "Dir":
                                    strDir = objReader.ReadString();
                                    this.prarrListComp.Add(strDir);

                                    strPathOut = Path.Combine(strRootOut, strDir);

                                    if (!pablnFilesOnly && !Directory.Exists(strPathOut))
                                        Directory.CreateDirectory(strPathOut);

                                    break;

                                case "File":
                                    lngQtdFiles++;
                                    strFilePath = objReader.ReadString();
                                    strFileName = objReader.ReadString();
                                    lngFileLength = objReader.ReadInt64();
                                    this.prarrListComp.Add(Path.Combine(strFilePath, strFileName));

                                    if (!pablnFilesOnly)
                                    {
                                        strPathOut = Path.Combine(strRootOut, strFilePath);

                                        if (!Directory.Exists(strPathOut))
                                            Directory.CreateDirectory(strPathOut);
                                    }
                                    else
                                    {
                                        if (!Directory.Exists(strRootOut))
                                            Directory.CreateDirectory(strRootOut);

                                        strPathOut = strRootOut;
                                    }

                                    if (pastrFileOut != "")
                                    {
                                        strPathOut = Path.Combine(strPathOut, pastrFileOut);

                                        if (lngQtdFiles > 1)
                                        {
                                            this.Error = new Exception(String.Concat("Foi passado o parametro do nome do arquivo destino, ",
                                                "porém o arquivo compactado possui outros arquivos. Neste caso voce deverá chamar esse método não passando o nome ",
                                                "do arquivo destino para que os arquivos sejam descompactados com o nome original"));
                                            return false;
                                        }
                                    }
                                    else
                                        strPathOut = Path.Combine(strPathOut, strFileName);

                                    if (File.Exists(strPathOut))
                                    {
                                        if (pablnReplace)
                                        {
                                            File.Delete(strPathOut);
                                        }
                                        else
                                        {
                                            objReader.ReadBytes((int)lngFileLength);
                                            break;
                                        }
                                    }

                                    BinaryWriter objFileOut = new BinaryWriter(File.Create(strPathOut));

                                    if (lngFileLength > 0)
                                    {
                                        objFileOut.Write(objReader.ReadBytes((int)lngFileLength));
                                        objFileOut.Flush();
                                    }
                                    objFileOut.Close();

                                    break;
                            }
                        }
                    }
                    catch (System.IO.EndOfStreamException) { }
                    catch (Exception Ex)
                    {
                        this.Error = Ex;
                        return false;
                    }
                    finally
                    {
                        if (objFileStream != null)
                            objFileStream.Close();

                        objGZipStreamt.Close();

                        objFileStream = null;
                    }
                }

                return true;
            }
            catch (Exception Ex)
            {
                this.Error = Ex;
                return false;
            }
        }

        public void ObtemListDir(string pastrPath)
        {
            this.prarrListDir = new ArrayList();
            this.prarrListType = new ArrayList();

            this.prarrListDir.Add(pastrPath);
            this.prarrListType.Add("PathComp");

            if (File.Exists(pastrPath))
            {
                FileInfo objFile = new FileInfo(pastrPath);

                this.prarrListDir.Add(objFile.Directory.Root.Name);
                this.prarrListType.Add("RootName");
                this.prarrListDir.Add(objFile.Directory.Root.FullName);
                this.prarrListType.Add("RootFullName");

                this.prarrListDir.Add(pastrPath);
                this.prarrListType.Add("File");
                return;
            }

            if (!Directory.Exists(pastrPath)) return;

            DirectoryInfo objDir = new DirectoryInfo(pastrPath);
            this.prarrListDir.Add(objDir.Root.Name);
            this.prarrListType.Add("RootName");
            this.prarrListDir.Add(objDir.Root.FullName);
            this.prarrListType.Add("RootFullName");

            AnalisaDir(pastrPath);
        }

        private void AnalisaDir(string pastrDir)
        {
            this.prarrListDir.Add(pastrDir);
            this.prarrListType.Add("Dir");

            string[] strListaArqs = Directory.GetFiles(pastrDir);

            foreach (string strPathArq in strListaArqs)
            {
                this.prarrListDir.Add(strPathArq);
                this.prarrListType.Add("File");
            }

            string[] strListaDirs = Directory.GetDirectories(pastrDir);

            foreach (string strPathDir in strListaDirs)
            {
                AnalisaDir(strPathDir);
            }
        }
    }
}
