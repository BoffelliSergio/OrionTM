using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace OrionTMClient
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller processInstaller;

        public ProjectInstaller()
        {
            processInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            serviceInstaller = new System.ServiceProcess.ServiceInstaller();

            // Service will run under system account
            processInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;

            // Service will have Start Type of Manual
            serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;

            serviceInstaller.ServiceName = "OrionTMClient";

            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
        }
    }
}
