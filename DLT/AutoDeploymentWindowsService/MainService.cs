using System;
using System.ComponentModel;
using System.Configuration;
using System.ServiceProcess;
using Autofac;
using Framework.Service.Diagnostics;
using Microsoft.Owin.Hosting;

namespace AutoDeploymentWindowsService
{
    public partial class MainService : ServiceBase
    {
        private readonly RegisterJob _reg;
        private readonly IDiagnosticService _diagnosticService;

        public MainService(IDiagnosticService diagnosticService)
        {
            InitializeComponent();
            _diagnosticService = diagnosticService;
            _reg = new RegisterJob();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _reg.Run();

                #region backgroundWorkerSignalR
                var backgroundWorkerSignalR = new BackgroundWorker
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };
                backgroundWorkerSignalR.DoWork += (sender, eventArgs) =>
                {
                    var url = ConfigurationManager.AppSettings["SignalRUrl"];
                    WebApp.Start(url);
                };

                if (!backgroundWorkerSignalR.IsBusy)
                {
                    // Start the asynchronous operation.
                    backgroundWorkerSignalR.RunWorkerAsync();
                }

                #endregion

                _diagnosticService.Info("Service start");
            }
            catch (Exception ex)
            {
                _diagnosticService.Error(ex);
            }
        }

        protected override void OnStop()
        {
            _reg.Stop();
            _diagnosticService.Info("Service stop");
            base.OnStop();
        }
    }
}
