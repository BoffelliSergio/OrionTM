using OrionTMClient.Entity;
using OrionTMClient.Infra;
using System;
using System.IO;
using System.Xml;
using OrionTMClient.Interface;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace OrionTMClient.Controller
{
    internal class ExecScript : Common
    {
        private ScriptParameter probjScriptParameter;
        private ScriptStatistic probjScriptStatistic;
        private GenerateLogEvent probjEvtLog;
        private OrionEquipment probjOrionEquipment;

        internal ExecScript()
        {
        }

        ~ExecScript()
        {
        }

        internal void Execute()
        {
            try
            {
                bool blStatus = false;
                this.probjOrionEquipment = OrionEquipment;
                LocalLog.Trace.WriteLogText("ExecScript_Execute()", "Start the script process.");
                ApplicationPath = System.Windows.Forms.Application.StartupPath;
                this.probjwsOrion = new WSOrion.MainServerOrionTM();
                this.probjWSConnect = new WSConect();

                this.probjScriptParameter = new ScriptParameter(Convert.ToInt32(this.probjOrionEquipment.IdTask), Convert.ToString(Status.Start), "");
                this.probjWSConnect.Send(ref this.probjScriptParameter);

                if (this.probjScriptParameter.Status == Convert.ToString(Status.Start))
                {
                    if (!UpdateStatus(this.probjScriptParameter.Sequence, Status.Send))
                    {
                        return;
                    }
                }

                if (ExecuteScript(this.probjScriptParameter.TextScript))
                {
                    blStatus = true;
                }


                if (blStatus)
                {
                    if (!UpdateStatus(this.probjScriptParameter.Sequence, Status.ExecuteOk))
                    {
                        return;
                    }
                }
                else
                {
                    if (!UpdateStatus(this.probjScriptParameter.Sequence, Status.ExecuteError))
                    {
                        return;
                    }

                }

                LocalLog.Trace.WriteLogText("ExecScript_Execute()", "Process Ended.");
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("ExecScript_Execute()", "Unexpected error occurs on Upload...", Ex);

                if (!UpdateStatus(this.probjScriptParameter.Sequence, Status.ExecuteError))
                {
                    return;
                }
            }
            finally
            {
                this.probjwsOrion = null;
                this.probjScriptParameter = null;
                this.probjScriptStatistic = null;

                this.probjWSConnect = null;
                this.probjEvtLog = null;
                this.probjOrionEquipment = null;
            }
        }

        private bool UpdateStatus(int paintSequence, Status paStatus)
        {
            LocalLog.Trace.WriteLogText("ExecScript_SendPermission()", "");

            try
            {
                this.probjScriptStatistic = new ScriptStatistic(paintSequence, Convert.ToString(paStatus));
                this.probjWSConnect.Send(ref probjScriptStatistic);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ExecuteScript(string paStrScript)
        {
            try
            {
                string[] strCommands = paStrScript.Split(new char[] {'\n'});

                Guid guid = Guid.NewGuid();
                ApplicationPath = System.Windows.Forms.Application.StartupPath;

                string strBatName = string.Concat(guid, ".bat");
                string strPathBatFile = string.Concat(ApplicationPath.ToString(), string.Concat(@"\Script\", strBatName));

                using (StreamWriter sw = File.CreateText(strPathBatFile))
                {
                    foreach (string strCommand in strCommands)
                    {
                        sw.WriteLine(strCommand);
                        sw.WriteLine();
                    }

                    sw.Flush();
                    sw.Close();
                }


                int ExitCode;
                ProcessStartInfo ProcessInfo;
                Process process;

                ProcessInfo = new ProcessStartInfo("cmd.exe", "/c " + strPathBatFile);
                ProcessInfo.CreateNoWindow = true;
                ProcessInfo.UseShellExecute = false;
                ProcessInfo.WorkingDirectory = Application.StartupPath + "\\Script";
                ProcessInfo.RedirectStandardError = true;
                ProcessInfo.RedirectStandardOutput = false;

                process = Process.Start(ProcessInfo);
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.WaitForExit();
                
                ExitCode = process.ExitCode;

                process.Close();
                process.Dispose();

                if (File.Exists(strPathBatFile)) 
                {
                    File.Delete(strPathBatFile);
                }

                return true;
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("ExecScript_ExecuteScript()", Ex.ToString());
                return false;
            }
        }

    }
}
