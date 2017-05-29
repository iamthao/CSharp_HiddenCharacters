using System;
using System.Configuration;
using System.IO;
using System.Web.Configuration;
using Autofac;
using Framework.Service.Diagnostics;
using Framework.Utility;
using ServiceLayer.Interfaces;

namespace AutoDeploymentWindowsService.Jobs
{
    public class JobMasterFile
    {
        protected readonly AppSettingsReader AppSettingsReader = new AppSettingsReader();
        private System.Threading.Timer _timer;
        public TimeSpan Interval { get; set; }

        protected string ServerId { get; set; }

        private readonly IDiagnosticService _diagnosticService;
        private readonly IEmailHandler _emailHandler;
        private readonly IIISHostingHelper _iisHostingHelper;
        private readonly IDeploymentJobService _deploymentJobService;

        protected JobMasterFile(IDiagnosticService diagnosticService, IEmailHandler emailHandler, IIISHostingHelper iisHostingHelper, IDeploymentJobService deploymentJobService)
        {
            _diagnosticService = diagnosticService;
            _emailHandler = emailHandler;
            _iisHostingHelper = iisHostingHelper;
            _deploymentJobService = deploymentJobService;
            ServerId = AppSettingsReader.GetValue("ServerId", typeof(string)).ToString();
        }

        protected void SetTimeSpan(TimeSpan timeSpan)
        {
            Interval = timeSpan;
        }

        /// <summary>
        /// Job container
        /// </summary>
        /// <param name="state"></param>
        protected virtual void DoWork(Object state)
        {
            throw new NotImplementedException();
        }

        public virtual void Run()
        {
            //TODO: Edit when release
            var tsInterval = new TimeSpan(0, 0, 30);
            if (Interval == TimeSpan.Zero)
            {
                Interval = tsInterval;
            }

            _timer = new System.Threading.Timer(DoWork, null, Interval, Interval);
           //DoWork(new object());
        }

        public virtual void Dispose()
        {
            if (_timer == null) return;
            _timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            _timer.Dispose();
            _timer = null;
        }

        protected Configuration OpenConfigFile(string configPath)
        {
            var configFile = new FileInfo(configPath);
            var vdm = new VirtualDirectoryMapping(configFile.DirectoryName, true, configFile.Name);
            var wcfm = new WebConfigurationFileMap();
            wcfm.VirtualDirectories.Add("/", vdm);
            return WebConfigurationManager.OpenMappedWebConfiguration(wcfm, "/");
        }
    }
}
