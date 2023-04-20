using OrionTMClient.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Configuration;
using System.Windows.Forms;



namespace OrionTMClient.Controller
{
    internal class OTMInstallPackage : Common
    {
        private bool prblnEnd = false;

        private Int32 privlngTimer;
        private static bool prblnInProcess = false;

        internal OTMInstallPackage()
        {
            try
            {
                Core.evtCloseClient += new CloseClient(Core_evtCloseClient);
                ApplicationPath = Application.StartupPath;

                if (ApplicationPath.IndexOf(@"\bin") > 0)
                {
                    ApplicationPath = ApplicationPath.Substring(0, ApplicationPath.IndexOf(@"\bin"));
                }

                this.privlngTimer = Convert.ToInt32(ConfigParameters.ReturnClientConfig("WaitTimeBetweenChecks")) * 1000;

                if (this.privlngTimer < 1000)
                {
                    this.privlngTimer = 30000;
                }
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("OTMInstallPackage()", "Error parameters...", Ex);
                this.privlngTimer = 60000;
            }
        }

        ~OTMInstallPackage()
        {
        }

        private void Core_evtCloseClient()
        {
            this.prblnEnd = true;
        }

        internal void Execute()
        {
            try
            {
                bool blinit = true;

                while (!this.prblnEnd)
                {
                    MainLoopInstallPackage(blinit);
                    blinit = false;

                    if (!Init)
                        Thread.Sleep(this.privlngTimer);
                    else
                        Thread.Sleep(30000);
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                LocalLog.Trace.WriteLogText("OTMInstallPackage_Execute()", "End Thread execution...");
                return;
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("OTMInstallPackage_Execute()", "Unexpected error during OTMInstallPackage execution...", Ex);
            }
        }

        private void MainLoopInstallPackage(bool blInit)
        {
            try
            {
                LocalLog.Trace.WriteLogText("OTMInstallPackage_MainLoopInstallPackage()",
                    string.Concat("OTMInstallPackage Version=", Common.Version,
                                  "  Config Timeout=", this.privlngTimer.ToString(), "ms"));

                LocalLog.Trace.WriteLogText("OTMInstallPackage_MainLoopInstallPackage() Start.");

                if (!prblnInProcess)
                {
                    prblnInProcess = true;

                    if (Init)
                    {
                        Init = false;
                    }

                    if (!Init)
                    {
                        InstallPackage installpackage = new InstallPackage();
                        prblnInProcess = installpackage.Execute();

                        if (!prblnInProcess)
                        {
                            LocalLog.Trace.WriteLogText("OTMInstallPackage_MainLoopInstallPackage() There were errors in the execution.");
                        }

                        installpackage = null;
                    }

                    System.Windows.Forms.Application.DoEvents();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    prblnInProcess = false;

                    LocalLog.Trace.WriteLogText("OTMInstallPackage_MainLoopInstallPackage() Finish.");
                }
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("OTMInstallPackage_MainLoopInstallPackage()", "Unexpected error during OTMInstallPackage execution.", Ex);
                prblnInProcess = false;
            }
        }
    }
}
