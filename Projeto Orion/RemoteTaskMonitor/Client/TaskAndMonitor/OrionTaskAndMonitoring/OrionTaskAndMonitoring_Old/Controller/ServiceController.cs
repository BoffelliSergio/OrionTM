using System;
using System.ServiceProcess;
using System.Text;

namespace OrionTaskAndMonitoring.Controller
{
    public class ServiceControllerA : ServiceBase
    {
        public static void Main()
        {
            ServiceBase.Run(new ServiceControllerA());
        }


        public ServiceControllerA()
        {
            //InitializeComponent();

            ServiceName = "OrionTaskAndMonitoring";

            //Inibe as funcões de Pausa e Continuacao no painel de servicos
            CanPauseAndContinue = false;

            //TODO
            //probjPrincipal = new Principal();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.

            // TODO: Add code here to start your service.
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // TODO
            //probjPrincipal.Inicia();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.

            // TODO: Add code here to perform any tear-down necessary to stop your service.
            // TODO
            //probjPrincipal.Finaliza();	
        }
    }
}
