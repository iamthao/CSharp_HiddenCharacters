using AutoDeploymentWindowsService.Jobs;
using Autofac;
using Database.Persistance.Tenants;
using AutoDeploymentWindowsService.Common;
using Framework.Service.Diagnostics;
using Framework.Utility;
using ServiceLayer;
using ServiceLayer.Interfaces;

namespace AutoDeploymentWindowsService
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            RegisterSystemServices(builder);
            RegisterServices(builder);
            RegisterHelper(builder);
            RegisterJob(builder);
        }

        private void RegisterSystemServices(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(MasterFileService<>)).As(typeof(IMasterFileService<>));
            builder.RegisterType<ServiceDeploymentService>().As<IDeploymentService>().InstancePerLifetimeScope();
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<DiagnosticService>().As<IDiagnosticService>();
            builder.RegisterType<DeploymentJobService>().As<IDeploymentJobService>();
            builder.RegisterType<ConfigurationService>().As<IConfigurationService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<GridConfigService>().As<IGridConfigService>();
            builder.RegisterType<EmailHandler>().As<IEmailHandler>();
        }

        private void RegisterHelper(ContainerBuilder builder)
        {
            builder.RegisterType<IISHostingHelper>().As<IIISHostingHelper>();
        }

        private void RegisterJob(ContainerBuilder builder)
        {
            builder.RegisterType<MainService>().AsSelf();
            builder.RegisterType<InitializeDatabase>().AsSelf();
            builder.RegisterType<CopySource>().AsSelf();
            builder.RegisterType<InitializeWebHost>().AsSelf();
            builder.RegisterType<InitializeWindowService>().AsSelf();
            builder.RegisterType<UninstallJob>().AsSelf();
        }
    }
}
