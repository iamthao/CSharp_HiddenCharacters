using Autofac;
using Common;

namespace AutoDeploymentWindowsService
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            var coreModule = new CoreModule();
            builder.RegisterModule(coreModule);
            var appModule = new ApplicationModule();
            builder.RegisterModule(appModule);

            var container = builder.Build();

            return container;
        }
    }
}
