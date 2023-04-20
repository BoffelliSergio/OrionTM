using System;
using System.Collections.Generic;
using System.ServiceProcess;

namespace OrionTMClient.Controller
{
    public class ServiceControler: ServiceBase
    {
        private Core probjCore; 

        public static void Main()
        {
            ServiceBase.Run(new ServiceControler());
        }

        public ServiceControler()
		{
            ServiceName = "OrionTMClient";

			CanPauseAndContinue = false;

            probjCore = new Core();
		}

        protected override void OnStart(string[] args)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            probjCore.Init();
        }

        protected override void OnStop()
        {
            probjCore.End();
        }
    }
}
