
using AutoDeploymentWindowsService.Jobs;
using Autofac;

namespace AutoDeploymentWindowsService
{
    public class RegisterJob
    {
        private readonly ILifetimeScope _scope;

        private readonly CopySource _cs;
        private readonly InitializeDatabase _idb;
        private readonly InitializeWebHost _iwh;
        private readonly InitializeWindowService _iws;
        private readonly UninstallJob _us;

        public RegisterJob()
        {
            _scope = ContainerConfig.Configure().BeginLifetimeScope();
            _cs = _scope.Resolve<CopySource>();
            _idb = _scope.Resolve<InitializeDatabase>();
            _iwh = _scope.Resolve<InitializeWebHost>();
            _iws = _scope.Resolve<InitializeWindowService>();
            _us = _scope.Resolve<UninstallJob>();
        }
        

        public void Run()
        {
            _cs.Run();
            _idb.Run();
            _iwh.Run();
            _iws.Run();
            _us.Run();
        }

        public void Stop()
        {
            _cs.Dispose();
            _idb.Dispose();
            _iwh.Dispose();
            _iws.Dispose();
            _us.Dispose();
        }

        ~RegisterJob()
        {
            _scope.Dispose();
        }
    }
}