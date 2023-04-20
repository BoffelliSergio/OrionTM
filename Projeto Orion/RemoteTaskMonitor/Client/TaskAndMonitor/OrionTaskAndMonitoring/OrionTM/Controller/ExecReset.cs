using OrionTMClient.Entity;
using OrionTMClient.Infra;
using System;
using System.IO;
using System.Xml;
using OrionTMClient.Interface;
using System.Diagnostics;

namespace OrionTMClient.Controller
{
    internal class ExecReset : Common
    {
        private ResetParameter probjResetParameter;
        private ResetStatistic probjResetStatistic;
        private GenerateLogEvent probjEvtLog;
        private OrionEquipment probjOrionEquipment;
        internal ExecReset()
        {
        }

        ~ExecReset()
        {
        }

        internal void Execute()
        {
            try
            {
                bool blStatus = false;

                this.probjOrionEquipment = OrionEquipment;
                LocalLog.Trace.WriteLogText("ExecReset_Execute()", "Start the reset process.");
                
                this.probjwsOrion = new WSOrion.MainServerOrionTM();
                
                this.probjWSConnect = new WSConect();
                this.probjResetParameter = new ResetParameter(Convert.ToInt32(this.probjOrionEquipment.IdTask), Convert.ToString(Status.Start), 1);
                this.probjWSConnect.Send(ref this.probjResetParameter);

                if (this.probjResetParameter.Status == Convert.ToString(Status.Start))
                {
                    if (!UpdateStatus(this.probjResetParameter.Sequence, Status.Send))
                    {
                        return;
                    }
                }

                //Equipment Shudown
                if (this.probjResetParameter.TypeReset == Convert.ToInt16(TypeReset.ShutDown))
                {
                    if (ShutDownEquipment())
                    {
                        blStatus = true;
                    }
                }

                //Application Restart
                if (this.probjResetParameter.TypeReset == Convert.ToInt16(TypeReset.Application))
                {
                    if (WriteEquipmentXml("S"))
                    {
                        blStatus = true;
                    }
                }

                if (blStatus)
                {
                    if (!UpdateStatus(this.probjResetParameter.Sequence, Status.ExecuteOk))
                    {
                        return;
                    }
                }
                else 
                {
                    if (!UpdateStatus(this.probjResetParameter.Sequence, Status.ExecuteError))
                    {
                        return;
                    }
                }

                LocalLog.Trace.WriteLogText("UploadOnLine_Execute()", "Process Ended.");
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("UploadOnLine_Execute()", "Unexpected error occurs on Upload...", Ex);

                if (!UpdateStatus(this.probjResetParameter.Sequence, Status.ExecuteError))
                {
                    return;
                }
            }
            finally
            {
                this.probjwsOrion = null;
                this.probjResetParameter = null;
                this.probjResetStatistic = null;
                
                this.probjWSConnect = null;
                this.probjEvtLog = null;
                this.probjOrionEquipment = null;
            }
        }
        
        private bool UpdateStatus(int paintSequqnce, Status paStatus)
        {
            LocalLog.Trace.WriteLogText("UploadOnLine_SendPermission()", "");

            try
            {
                this.probjResetStatistic = new ResetStatistic(paintSequqnce, Convert.ToString(paStatus));
                this.probjWSConnect.Send(ref probjResetStatistic);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool WriteEquipmentXml(string strBootYesNo)
        {
            try
            {
                string strDriver = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                string strPathXml = Path.Combine(strDriver, "XMLEquipment.xml");  

                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.Load(strPathXml);

                foreach (XmlNode node in XmlDoc.DocumentElement.ChildNodes)
                {
                    if (node.Name == "BOOT")
                    {
                        node.InnerText = strBootYesNo;
                        break;
                    }
                }

                XmlDoc.Save(strPathXml);

                return true;
            }
            catch(Exception Ex)
            {
                LocalLog.Trace.WriteLogText("WriteEquipmantXml() Exception: ", Ex.ToString());

                return false;
            }
        }

        private bool ShutDownEquipment()
        {
            try
            {
                ApplicationPath = System.Windows.Forms.Application.StartupPath;
                string strPathBatFile = string.Concat(ApplicationPath.ToString(), string.Concat(@"\Reset\ShudownEquipment.bat"));

                int ExitCode;
                ProcessStartInfo ProcessInfo;
                Process process;

                ProcessInfo = new ProcessStartInfo("cmd.exe", "/c " + strPathBatFile);
                ProcessInfo.CreateNoWindow = true;
                ProcessInfo.UseShellExecute = false;
                ProcessInfo.WorkingDirectory = ApplicationPath + "\\Reset";
                ProcessInfo.RedirectStandardError = true;
                ProcessInfo.RedirectStandardOutput = false;

                process = Process.Start(ProcessInfo);
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.WaitForExit();

                ExitCode = process.ExitCode;

                process.Close();
                process.Dispose();

                return true;
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("UploadOnLine_ShutDownEquipment()", Ex.ToString());
                return false;
            }
        }

    }
}
