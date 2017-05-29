using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace InstallService
{
    public class ServiceHelper
    {
        public static void InstallAndStartService(string servicePath, string serviceName)
        {
            try
            {
                ServiceController serviceController = GetServiceControl(serviceName);
                if (serviceController == null)
                {
                    InstallService(servicePath,serviceName);
                    serviceController = GetServiceControl(serviceName);
                }
                if (serviceController != null && serviceController.Status != ServiceControllerStatus.Running)
                {
                    serviceController.Start();
                    serviceController.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 5, 0));
                }           
            }
            catch (Exception ex)
            {
                // Error
            }
        }

        private static ServiceController GetServiceControl(string strServiceName)
        {
            ServiceController[] services = ServiceController.GetServices();

            return services.FirstOrDefault(controller => controller.ServiceName.Equals(strServiceName));
        }

        private static void InstallService1(string servicePath, string serviceName)
        {
            ManagedInstallerClass.InstallHelper(new string[] { servicePath });          
        }
        private static void InstallService(string servicePath, string serviceName)
        {
            var addArg = "";
            if (!string.IsNullOrEmpty(serviceName))
            {
                addArg = " /servicename=\"" + serviceName + "\" ";
            }
            var installUtilPath = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
            var proc = new Process
            {
                StartInfo =
                {
                    FileName = Path.Combine(installUtilPath, "installutil.exe"),
                    Arguments = addArg + servicePath + " /i",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                }
            };

            proc.Start();
            var result = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();
        }

        //Remove service
        public static void StopService(string servicePath, string serviceName)
        {
            try
            {
                ServiceController checkController = GetServiceControl(serviceName);
                if (checkController != null)
                {
                    ServiceController controller = new ServiceController(serviceName);

                    if (checkController.Status != ServiceControllerStatus.Stopped)
                    {
                        controller.Stop();
                        controller.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 5, 0));
                    }                 
                }
                UninstallService(servicePath,serviceName);
            }
            catch (Exception ex)
            {               
                //Error
            }
        }

        private static void UninstallService1(string servicePath)
        {
            ManagedInstallerClass.InstallHelper(new string[] { "/u", servicePath });
        }
        private static void UninstallService(string servicePath, string serviceName)
        {
            var addArg = "";
            if (!string.IsNullOrEmpty(serviceName))
            {
                addArg = " /servicename=\"" + serviceName + "\" ";
            }

            var installUtilPath = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
            var proc = new Process
            {
                StartInfo =
                {
                    FileName = Path.Combine(installUtilPath, "installutil.exe"),
                    Arguments = addArg + servicePath + " /u",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                }
            };

            proc.Start();
            proc.WaitForExit();
        }
    }
}
