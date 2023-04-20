using System;
using System.Threading;
using System.Configuration;
using OrionTMClient.Infra;


namespace OrionTMClient.Controller
{
	internal class Probe : Common
	{
		private bool prblnEnd = false;
		private Int32 prlngTimer;
        private static bool prblnInProcess = false;

		internal Probe()
		{
			try
			{
				Core.evtCloseProbe +=new CloseProbe(Core_evtCloseProbe);
                ApplicationPath = System.Windows.Forms.Application.StartupPath;

				if (ApplicationPath.IndexOf(@"\bin") > 0)
				{
					ApplicationPath = ApplicationPath.Substring(0,ApplicationPath.IndexOf(@"\bin"));
				}

				this.prlngTimer = 30000;
			}
			catch(Exception Ex)
			{
                LocalLog.Trace.WriteLogText("Probe()", "Error while getting parameters...", Ex);

				this.prlngTimer = 30000;
			}
		}

		~Probe()
		{
		}

        //TO DO
        private void Core_evtCloseProbe()
        {
        //    this.prblnEnd = true;

        //    //if (this.probjUDP != null)
        //    //{
        //    //    this.probjUDP.evtMessageReceived -=new MessageReceived(probjUDP_evtMessageReceived);
        //    //    this.probjUDP.evtErrorReceived -=new Error(probjUDP_evtErrorReceived);
        //    //    this.probjUDP.Done();
        //    //    this.probjUDP = null;
        //    //}
        }

		internal void Execute()
		{
			try
			{
				bool blinit = false;

                while (!this.prblnEnd)
				{
					Thread.Sleep(this.prlngTimer);
                    LoopProbeOTMClientExtern(blinit);
                    blinit = false;
				}
			}
			catch (System.Threading.ThreadAbortException)
			{
                LocalLog.Trace.WriteLogText("ProbeExecute()", "End of thread execution...");
				return;
			}
			catch(Exception Ex)
			{
                LocalLog.Trace.WriteLogText("ProbeExecute()", "Unexpected error during probe execution...", Ex);
			}
		}

        //TODO
		private void LoopProbeOTMClientExtern(bool parblinit)
		{
			try
			{
				LocalLog.Trace.WriteLogText("LoopProbeOTMClientExternImed() Execution OTMClient Init of process");
                LocalLog.Trace.WriteLogText("LoopProbeOTMClientExtern() parblinit=", parblinit.ToString());

                int count = 0;

                while (prblnInProcess && count < 10)
                {
                    Thread.Sleep(10000);
                    count = count + 1;
                }
                
                //Verifica se nao existe nenhum processo em andamento
                if (!prblnInProcess)
				{
					bool blExecuteOTMClient = false;
					bool blUpdateTerIni = false;

                    prblnInProcess = true;

					// Verifica se o ter.ini esta configurado para execucao do tntcli
                    //SondaTntCli probjExecutaTntCli = new SondaTntCli();
                    //blExecutaTntCli = probjExecutaTntCli.GetExecutaTntCli(); 
		
                    //probjExecutaTntCli = null;

                    LocalLog.Trace.WriteLogText(string.Concat("LoopProbeOTMClientExtern() blExecuteOTMClient=", blExecuteOTMClient.ToString()));

                    if (blExecuteOTMClient)
					{
                        //SondaTntCli classeAlteraTerIni = new SondaTntCli();
                        //blUpdateTerIni = classeAlteraTerIni.SetExecutaTntCli(0); 
		
						//Libera o processamento
						System.Windows.Forms.Application.DoEvents();

                        blUpdateTerIni = false;
					}
                    					
					prblnInProcess = false;

                    LocalLog.Trace.WriteLogText("LoopProbeOTMClientExtern() Execution OTMClient End of process");
				}
                else
                {
                    LocalLog.Trace.WriteLogText("LoopProbeOTMClientExtern()", "Could not send immediate probe waiting to send again...");

                    prblnInProcess = false;
                }	
            }
            catch (Exception Ex)
			{
                LocalLog.Trace.WriteLogText("LoopProbeOTMClientExtern()", "Unexpected error during OTMClient processing...", Ex);
                prblnInProcess = false;
			}
		}	

        //TODO
		//private void ConfigSocket()
        //{
        //    //LocalLog.Trace.WriteLogText("Sonda_ConfigSocket()", string.Concat("Modo", System.Configuration.ConfigurationManager.AppSettings["Modo"]));

        //    ////Verifica se o processo funcionara em modo ATIVO
        //    //if (System.Configuration.ConfigurationManager.AppSettings["Modo"] != "ativo")
        //    //{
        //    //    ////Configura o socket
        //    //    //this.probjUDP.RemoteHost = System.Configuration.ConfigurationManager.AppSettings["RemoteHostUDP"];
        //    //    //this.probjUDP.LocalPort = ParamC18.R3;
				
        //    //    ////Verifica se esta sendo rodado no ambiente de testes
        //    //    //if (this.probjUDP.ComputerName.ToLower() == "dso-alberto")
        //    //    //{
        //    //    //    this.probjUDP.RemotePort = 1441;
        //    //    //}
        //    //    //else
        //    //    //{
        //    //    //    this.probjUDP.LocalPort = ParamC18.Q3;
        //    //    //}
				
        //    //    ////Obtem os eventos de mensagens recebidas e erros
        //    //    //this.probjUDP.evtMessageReceived +=new MessageReceived(probjUDP_evtMessageReceived);
        //    //    //this.probjUDP.evtErrorReceived +=new Error(probjUDP_evtErrorReceived);
			
        //    //    ////Entra em estado de ouvindo porta
        //    //    //this.probjUDP.Listen();
        //    //}
        //}

		private void probjHttp_evtMessageReceived(string pastrMensagem)
		{
			try
			{
                LocalLog.Trace.WriteLogText("Probe_probjHttp_evtMessageReceived()", pastrMensagem);
                CheckHttpMessage(pastrMensagem);
			
			}
			catch(Exception Ex)
			{
                LocalLog.Trace.WriteLogText("Probe_probjHttp_evtMessageReceived()", "Unexpected error during processing...", Ex);
			}
		}

		private void CheckHttpMessage(string pastrMessage)
		{
            try
            {
                prblnInProcess = true;

                LocalLog.Trace.WriteLogText("Probe_CheckHttpMessage()", pastrMessage);

                switch (pastrMessage)
                {
                    case "OnLineUpload":
                        //UploadOnLine objUploadOnLine = new UploadOnLine();
                        //objUploadOnLine.Executa();
                        //objUploadOnLine = null;
                        break;

                    case "DailyUpload":
                        //UploadDiarioTr objUploadDiarioTr = new UploadDiarioTr();
                        //objUploadDiarioTr.Executa();
                        //objUploadDiarioTr = null;
                        break;

                    case "OnLineDownload":
                        //DownloadOnLine objDownloadOnLine = new DownloadOnLine();
                        //objDownloadOnLine.Executa();
                        //objDownloadOnLine = null;
                        break;

                    case "OnLineCommand":
                        //ComandOnLineGer objComandOnLine = new ComandOnLineGer();
                        //objComandOnLine.Executa();
                        //objComandOnLine = null;
                        //ComandOnLineTr objUploadLog = new ComandOnLineTr();
                        //objUploadLog.UploadArqsGerados(true);
                        //objUploadLog = null;
                        break;

                    default:
                        LocalLog.Trace.WriteLogText("Probe_CheckHttpMessage()", "Unrecognized message...", new Exception(pastrMessage));
                        break;
                }

                prblnInProcess = false;
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("Probe_CheckHttpMessage()", "Unexpected error during OTMClient execution...", Ex);

                prblnInProcess = false;
            }
		}
		
		private void probjHttp_evtErrorReceived(Exception paEx)
		{
            LocalLog.Trace.WriteLogText("Probe_probjHttp_evtErrorReceived()", paEx);
		}
	}
}

