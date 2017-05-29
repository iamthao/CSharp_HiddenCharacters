using System;
using System.ServiceProcess;
using Autofac;

namespace AutoDeploymentWindowsService
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //var reg = new RegisterJob();
            //reg.Run();
            ////reg.Stop();
            //Console.ReadLine();

            using (var scope = ContainerConfig.Configure().BeginLifetimeScope())
            {
                var servicesToRun = new ServiceBase[]
                {
                    scope.Resolve<MainService>()
                };
                ServiceBase.Run(servicesToRun);
            }
        }
    }
}
