using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;
using OrionTMClient.Infra;

namespace OrionTMClient.Controller
{
    public class TestConsole
    {
        private static Thread prthrOrionTMClient;
        private static OTMClient probjOTMClient;
        private static OTMHeartBeat probjOTMHeartBeat;
        private static Thread prthrOrionTMHeartBeat;

        [STAThread]
        public static void Main(string[] args)
        {
            Common obj = new Common();
            string str;

            str = obj.ReturnInstalledDrive();

            bool blnFim = false;

            LocalLog.Trace = new LocalLog(ConfigParameters.ReturnClientConfig("PathTrace"));

            string test = System.AppDomain.CurrentDomain.BaseDirectory.ToString();

            int intStrDriver = test.LastIndexOf(@":") + 1;

            test = test.Substring(0, intStrDriver);

            LocalLog.Trace.WriteLogText(string.Concat("execution time=", DateTime.Now));

            //OTMHeartBeat probjOTMHeartBeat = new OTMHeartBeat();
            //probjOTMHeartBeat.Execute();

            //OTMClient probjOTMClient = new OTMClient();
            //probjOTMClient.Execute();

            //probjOTMHeartBeat = new OTMHeartBeat();
            //prthrOrionTMHeartBeat = new Thread(new ThreadStart(probjOTMHeartBeat.Execute));
            //prthrOrionTMHeartBeat.Start();

            //probjOTMClient = new OTMClient();
            //prthrOrionTMClient = new Thread(new ThreadStart(probjOTMClient.Execute));
            //prthrOrionTMClient.Start();

            InstallPackage installpackage = new InstallPackage();
            installpackage.Execute();




            while (!blnFim)
            {
                Console.Write("To finish press 'ok'\r\n");
                string strTeclado = Console.ReadLine();

                if (strTeclado.ToLower() == "ok")
                {
                    Console.Write("\r\nWait, finishing...");
                    Core.End("Console");
                    blnFim = true;
                }
            }
        }
    }
}
