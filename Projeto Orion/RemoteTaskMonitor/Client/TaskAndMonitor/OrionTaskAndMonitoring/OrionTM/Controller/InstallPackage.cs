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
    internal class InstallPackage : Common
    {
        private string prstrPathDownloadPackage;
        private string prstrPathDownloadPackageTemp;
        private string prtrDestinationPathAndFile;
        
        internal InstallPackage()
        {
        }

        ~InstallPackage()
        {
        }

        internal bool Execute()
        {
            bool result = false;

            try
            {
                LocalLog.Trace.WriteLogText("InstallPackage_Execute()", "Start the install package process.");
                
                string[] InstallPackageData = ReadEquipmentXmlPackageInstallation();
                
                //Verifica se é data/hora para instalação
                //Existe package
                if (InstallPackageData[0].ToLower() != "n")
                {
                    string strInstallationPackage = InstallPackageData[0].Trim();
                    string strInstalationDateTime = InstallPackageData[1].Trim();

                    ApplicationPath = System.Windows.Forms.Application.StartupPath;

                    this.prstrPathDownloadPackage = Path.Combine(ApplicationPath, "DownloadPackage");
                    this.prstrPathDownloadPackageTemp = Path.Combine(this.prstrPathDownloadPackage, "Temp");
                    this.prtrDestinationPathAndFile = Path.Combine(this.prstrPathDownloadPackage, strInstallationPackage);

                    //Data e hora ok para a instalação
                    if (VerifyDateHourInstallation(strInstalationDateTime))
                    {
                        LocalLog.Trace.WriteLogText("InstallPackage_Execute()", string.Concat("The package ", strInstallationPackage, " will be installed now."));
                        
                        if (ExecuteScriptCopyFilesBat())
                        {
                            LocalLog.Trace.WriteLogText("InstallPackage_Execute()", string.Concat("The package ", strInstallationPackage, " is succefully installed."));
                        }

                        //Escreve no XMLEquipment.xml o valor default para o package.
                        if (WriteInEquipmentXmlPackageInstallation("N", ""))
                        {
                            LocalLog.Trace.WriteLogText("InstallPackage_Execute_WriteInEquipmentXmlPackageInstalation()", string.Concat("The XMLEquipment.xml file is updated "));
                        }

                        //Exclui a pasta
                        DeleteInstalationPackageFiles();
                    }
                    else
                    {
                        LocalLog.Trace.WriteLogText("InstallPackage_Execute()", string.Concat("The package ", strInstallationPackage, " will be installed in ", strInstalationDateTime));
                    }
                }
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("InstallPackage_Execute()", "An error occured on execute on Install Package.", Ex);
                result = false;
            }

            return result;
        }

        private bool VerifyDateHourInstallation(string strInstalationDateTime)
        {
            DateTime DateHourInstalation = new DateTime();
            DateTime DateHourNow = new DateTime();
            
            DateHourInstalation = Convert.ToDateTime(strInstalationDateTime);
            DateHourNow = DateTime.Now;

            if (DateHourNow >= DateHourInstalation)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private bool ExecuteScriptCopyFilesBat()
        {
            try
            {
                LocalLog.Trace.WriteLogText("DownloadPackage_ExecuteScriptCopyFilesBat()", "Start.");

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
        
        private string[] ReadEquipmentXmlPackageInstallation()
        {
            string[] output = new string[2];

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
                        output[0] = node.InnerText;
                    }

                    if (node.Name == "InstalationDateTime")
                    {
                        output[1] = node.InnerText;
                    }
                }

                XmlDoc.Save(strPathXml);
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("WriteInEquipmentXmlPackageInstalation() Exception: ", Ex.ToString());
            }

            return output;
        }

        private bool DeleteInstalationPackageFiles()
        {
            if (Directory.Exists(this.prstrPathDownloadPackageTemp))
            {
                RecursiveDelete(this.prstrPathDownloadPackageTemp);
                return true;
            }

            return false;
        }

        public void RecursiveDelete(string strPathTodelete)
        {
            try
            {
                if (!Directory.Exists(strPathTodelete))
                {
                    return;
                }

                string[] dirs = Directory.GetDirectories(strPathTodelete);
                
                foreach (string dir in dirs)
                {
                    RecursiveDelete(dir);
                }

                var files = Directory.GetFiles(strPathTodelete);

                foreach (var file in files)
                {
                    try
                    {
                        if (System.IO.File.Exists(file))
                        {
                            System.IO.File.Delete(file);
                            LocalLog.Trace.WriteLogText("RecursiveDelete_executing() File deleted:", file.ToString());

                        }
                    }
                    catch (Exception Ex)
                    {
                    LocalLog.Trace.WriteLogText("RecursiveDelete_executing() Exception: ", Ex.ToString());
                    }
                }
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("RecursiveDelete() Exception: ", Ex.ToString());
            }

        }



    }
}
