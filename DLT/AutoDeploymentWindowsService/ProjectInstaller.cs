using System.ComponentModel;
using System.Diagnostics;
using System.ServiceProcess;

namespace AutoDeploymentWindowsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            const string serviceName = "DltWindowsService";
            const string serviceDescription = "DltWindowsService";

            serviceProcessInstaller1 = new ServiceProcessInstaller();
            QuickSpatchWindowsServiceInstaller = new ServiceInstaller();
            //Create Instance of EventLogInstaller
            var myEventLogInstaller = new EventLogInstaller
            {
                Source = serviceName,
                Log = "Application"
            };

            //# Service Account Information
            serviceProcessInstaller1.Account = ServiceAccount.LocalSystem;
            serviceProcessInstaller1.Username = null;
            serviceProcessInstaller1.Password = null;

            //# Service Information
            QuickSpatchWindowsServiceInstaller.ServiceName = serviceName;
            QuickSpatchWindowsServiceInstaller.DisplayName = serviceName;
            QuickSpatchWindowsServiceInstaller.Description = serviceDescription;
            QuickSpatchWindowsServiceInstaller.StartType = ServiceStartMode.Automatic;

            Installers.Add(serviceProcessInstaller1);
            Installers.Add(QuickSpatchWindowsServiceInstaller);
            // Add myEventLogInstaller to the Installers Collection.
            Installers.Add(myEventLogInstaller);
        }

        private void RetrieveServiceName()
        {
            var serviceName = this.Context.Parameters["servicename"];
            if (string.IsNullOrEmpty(serviceName)) return;

            this.QuickSpatchWindowsServiceInstaller.ServiceName = serviceName;
            this.QuickSpatchWindowsServiceInstaller.DisplayName = serviceName;
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            RetrieveServiceName();
            base.Install(stateSaver);
        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            RetrieveServiceName();
            base.Uninstall(savedState);
        }
    }
}
