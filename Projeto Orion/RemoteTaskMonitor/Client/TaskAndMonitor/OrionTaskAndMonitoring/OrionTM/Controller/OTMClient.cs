using System;
using System.Threading;
using System.Configuration;
using System.Windows.Forms;
using OrionTMClient.Infra;

namespace OrionTMClient.Controller
{
    internal class OTMClient : Common
    {
		private bool prblnEnd = false;
        		
		private Int32 privlngTimer;
        private static bool prblnInProcess = false;

		internal OTMClient()
		{
			try
			{
				Core.evtCloseClient +=new CloseClient(Core_evtCloseClient);
				ApplicationPath = Application.StartupPath;
				
                if (ApplicationPath.IndexOf(@"\bin") > 0)
				{
					ApplicationPath = ApplicationPath.Substring(0,ApplicationPath.IndexOf(@"\bin"));
				}

				this.privlngTimer = Convert.ToInt32(ConfigParameters.ReturnClientConfig("WaitTimeBetweenChecks")) * 1000;

				if (this.privlngTimer < 1000)
                {
					this.privlngTimer = 30000;
                }
			}
			catch(Exception Ex)
			{
				LocalLog.Trace.WriteLogText("OTMClient()", "Error parameters...", Ex);
				this.privlngTimer = 60000;
			}
		}

		~OTMClient()
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
                    MainLoop(blinit);
                    blinit = false;	
					
                    if (!Init)
                        Thread.Sleep(this.privlngTimer);
					else
						Thread.Sleep(30000);
				}
			}
			catch (System.Threading.ThreadAbortException)
			{
                LocalLog.Trace.WriteLogText("OTMClient_Execute()", "End Thread execution...");
				return;
			}
			catch(Exception Ex)
			{
                LocalLog.Trace.WriteLogText("OTMClient_Execute()", "Unexpected error during OTMClient execution...", Ex);
			}
		}

        //TODO
		private void MainLoop(bool blInit)
		{
			try
			{
                LocalLog.Trace.WriteLogText("OTMClient_MainLoop()",
                    string.Concat("MainLoop Version=", Common.Version,
                                  "  Config Timeout=", this.privlngTimer.ToString(), "ms"));

                //bool BlInitExecuteProbeOTMClient = parblExecuteProbeOTMClient;

                LocalLog.Trace.WriteLogText("OTMClient_MainLoop() Start.");

                if (!prblnInProcess)
				{
                    prblnInProcess = true;

                    if (Init)
					{
                        ClearTrace cleartrace = new ClearTrace(); 
                        try 
                        {
                            cleartrace.PerformCleaning(); 
                        } 
                        catch (Exception ex) 
                        {
                            LocalLog.Trace.WriteLogText("OTMClient_MainLoop() Unable to clean.[ " + ex.Message + " ]");
                        }

                        cleartrace = null;

                        //Construir aqui algo que seja nencessário no inicio do processo (somente uma vez quando liga o Client)

                        ////Instancia o objeto gerenciador dos arquivos de upload diario
                        //UploadDiarioGer objUploadDiarioGer = new  UploadDiarioGer();
                        //objUploadDiarioGer.VerificaTransmissaoDiaria();
                        ////Destroi a instancia
                        //objUploadDiarioGer = null;

                        Init = false;
                    }

                    if (!Init)
                    {
                        WSConect wsconect = new WSConect();
                        prblnInProcess = wsconect.ConnectTask();

                        //if (!prblnInProcess)
                        //{
                        //    LocalLog.Trace.WriteLogText("OTMClient_MainLoop() There were errors in the execution.");
                        //}
                        wsconect = null;
                    }

                    System.Windows.Forms.Application.DoEvents();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    prblnInProcess = false;

                    LocalLog.Trace.WriteLogText("OTMClient_MainLoop() Finish.");
                }
            }
			catch(Exception Ex)
			{
                LocalLog.Trace.WriteLogText("OTMClient_MainLoop()", "Unexpected error during OTMClient execution.", Ex);
				prblnInProcess = false;
			}
		}
	}
}
