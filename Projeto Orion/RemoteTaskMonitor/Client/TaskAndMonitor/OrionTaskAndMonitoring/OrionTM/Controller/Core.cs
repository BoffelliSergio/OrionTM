using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;
using System.Reflection;
using OrionTMClient.Infra;

namespace OrionTMClient.Controller
{
    public class Core
    {
        private static Thread prthrOrionTMClient;
        private static OTMClient probjOTMClient;
        private static OTMHeartBeat probjOTMHeartBeat;
        private static OTMInstallPackage probjInstallPackage;
        private static Thread prthrOrionTMHeartBeat;

        private static Thread prthrInstallPackage;
        
        public static event OrionTMClient.Controller.CloseClient evtCloseClient;
        
        public Core()
		{
		}

		~Core()
		{
            LocalLog.Trace = null;
            probjOTMClient = null;
            prthrInstallPackage = null;
		}

        public void Init()
        {
            Init("Service");
        }

        static string productVersion = string.Empty;

        public static void Init(string pastrOrigin)
        {
            try
            {
                LocalLog.Trace = new LocalLog(ConfigParameters.ReturnClientConfig("PathTrace"));
                LocalLog.ActiveTrace = ConfigParameters.ReturnClientConfig("ActiveTrace");   

                Assembly objAssInfo = Assembly.GetEntryAssembly();
                if (objAssInfo != null)
                {
                    object[] customAttributes = objAssInfo.GetCustomAttributes(typeof(AssemblyVersionAttribute), false);
                    if ((customAttributes != null) && (customAttributes.Length > 0))
                    {
                        productVersion = ((AssemblyVersionAttribute)customAttributes[0]).Version;
                    }
                    if (string.IsNullOrEmpty(productVersion))
                    {
                        productVersion = string.Empty;
                    }
                }

                Common.Version = productVersion;
                objAssInfo = null;

                LocalLog.Trace.WriteLogText("Core_Init()", "...");
                LocalLog.Trace.WriteLogText("Core_Init()", string.Concat("Starting execution... OrionTMClient version=", Common.Version, "  Start=", pastrOrigin));

                probjOTMHeartBeat = new OTMHeartBeat();
                prthrOrionTMHeartBeat = new Thread(new ThreadStart(probjOTMHeartBeat.Execute));
                prthrOrionTMHeartBeat.Start();

                probjOTMClient = new OTMClient();
                prthrOrionTMClient = new Thread(new ThreadStart(probjOTMClient.Execute));
                prthrOrionTMClient.Start();

                probjInstallPackage = new OTMInstallPackage();
                prthrInstallPackage = new Thread(new ThreadStart(probjInstallPackage.Execute));
                prthrInstallPackage.Start();

                LocalLog.Trace.WriteLogText("Core_Init()", string.Concat("Execution started...", pastrOrigin));
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("Core_Init()", Ex);
            }
        }

        public void End()
        {
            End("Service");
        }

        public static void End(string pastrOrigin)
        {
            try
            {
                LocalLog.Trace.WriteLogText("Core_Init()", string.Concat("Finish execution...", pastrOrigin));

                bool blnFim = false;

                while (!blnFim)
                {
                    if (prthrOrionTMClient != null)
                    {
                        prthrOrionTMClient.Abort();
                        prthrOrionTMClient.Join();
                    }
                    
                    if (prthrOrionTMHeartBeat != null)
                    {
                        prthrOrionTMHeartBeat.Abort();
                        prthrOrionTMHeartBeat.Join();
                    }

                    if (prthrInstallPackage != null)
                    {
                        prthrInstallPackage.Abort();
                        prthrInstallPackage.Join();
                    }

                    if (!prthrOrionTMClient.IsAlive)
                        blnFim = true;
                    else
                        Thread.Sleep(1000);

                    if (!prthrOrionTMHeartBeat.IsAlive)
                        blnFim = true;
                    else
                        Thread.Sleep(1000);

                    if (!prthrInstallPackage.IsAlive)
                        blnFim = true;
                    else
                        Thread.Sleep(1000);
                }

                LocalLog.Trace.WriteLogText("Core_Init()", string.Concat("Finished execution...", pastrOrigin));
                LocalLog.Trace.WriteLogText("Core_Init()", "...");
                
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("Core_Init()", Ex);
            }
        }
    }
}
