using System;
using System.Threading;
using System.Configuration;
using System.Windows.Forms;
using OrionTMClient.Infra;
using System.Collections.Generic;
using System.Text;
using OrionTMClient.Entity;

namespace OrionTMClient.Controller
{
    internal class OTMHeartBeat : Common
    {
        private bool prblnEnd = false;

        private Int32 privlngTimer;
        private static bool prblnInProcess = false;
        
        internal OTMHeartBeat()
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
                LocalLog.Trace.WriteLogText("OTMHeartBeat()", "Error parameters...", Ex);
                this.privlngTimer = 60000;
            }
        }

        ~OTMHeartBeat()
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
                    MainLoopHeartBeat(blinit);
                    blinit = false;

                    if (!Init)
                        Thread.Sleep(this.privlngTimer);
                    else
                        Thread.Sleep(30000);
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                LocalLog.Trace.WriteLogText("OTMHeartBeat_Execute()", "End Thread execution...");
                return;
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("OTMHeartBeat_Execute()", "Unexpected error during OTMHeartBeat execution...", Ex);
            }
        }

        private void MainLoopHeartBeat(bool blInit)
        {
            try
            {
                LocalLog.Trace.WriteLogText("OTMHeartBeat_MainLoopHeartBeat()",
                    string.Concat("OTMHeartBeat Version=", Common.Version,
                                  "  Config Timeout=", this.privlngTimer.ToString(), "ms"));

                LocalLog.Trace.WriteLogText("OTMHeartBeat_MainLoopHeartBeat() Start.");

                if (!prblnInProcess)
                {
                    prblnInProcess = true;

                    if (Init)
                    {
                        Init = false;
                    }

                    if (!Init)
                    {
                        WSConect wsconect = new WSConect();
                        prblnInProcess = wsconect.ConnectHeartBeat();

                        if (!prblnInProcess)
                        {
                            LocalLog.Trace.WriteLogText("OTMHeartBeat_MainLoopHeartBeat() There were errors in the execution.");
                        }
                        wsconect = null;
                    }

                    System.Windows.Forms.Application.DoEvents();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    prblnInProcess = false;

                    LocalLog.Trace.WriteLogText("OTMHeartBeat_MainLoopHeartBeat() Finish.");
                }
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("OTMHeartBeat_MainLoopHeartBeat()", "Unexpected error during OTMHeartBeat execution.", Ex);
                prblnInProcess = false;
            }
        }
    }
}
