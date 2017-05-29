using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Framework.DomainModel.Common;
using Framework.DomainModel.Entities;
using Framework.Service.Diagnostics;
using Framework.Utility;
using ServiceLayer.Interfaces;

namespace AutoDeploymentWindowsService.Jobs
{
    public class CopySource : JobMasterFile
    {
        private readonly IDeploymentJobService _deploymentJobService;
        private readonly IDiagnosticService _diagnosticService;

        public CopySource(IDiagnosticService diagnosticService, IEmailHandler emailHandler, IIISHostingHelper iisHostingHelper, IDeploymentJobService deploymentJobService)
            : base(diagnosticService, emailHandler, iisHostingHelper, deploymentJobService)
        {
            _deploymentJobService = deploymentJobService;
            _diagnosticService = diagnosticService;
        }
        protected override void DoWork(object state)
        {
            var mainCancellationTokenSource = new CancellationToken();
            try
            {
                var tasks = new List<Task>();
                var deploymentJobs = _deploymentJobService.Get(p => p.Server.Code == ServerId
                    && !(p.IsCopySourceDone ?? false)
                    && (p.IsStart ?? false))
                    .OrderBy(p => p.FailCount)
                    .Take(3).ToList();

                if (!deploymentJobs.Any()) return;

                var listJobUpdated = new List<DeploymentJob>();

                foreach (var job in deploymentJobs)
                {
                    var localJob = job;
                    var t = Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            //source
                            var serviceSource = localJob.Configuration.SourceWindowServicePath;
                            var webSource = localJob.Configuration.SourceWebPath;
                            var webApiSource = localJob.Configuration.SourceWebApiPath;

                            //destination
                            var serviceDest = localJob.Configuration.DestinationWindowServicePath;
                            var webDest = localJob.Configuration.DestinationWebPath;
                            var webDestApi = localJob.Configuration.DestinationWebApiPath;

                            if (localJob.JobType == (int)JobType.WebApp)
                            {
                                if (!Directory.Exists(webDest)) Directory.CreateDirectory(webDest);
                                FileAndFolderHelper.DirectoryCopy(webSource, webDest);
                            }
                            if (localJob.JobType == (int)JobType.WebApi)
                            {
                                if (!Directory.Exists(webDestApi)) Directory.CreateDirectory(webDestApi);
                                FileAndFolderHelper.DirectoryCopy(webApiSource, webDestApi);

                            }
                            if (localJob.JobType == (int)JobType.WindowService)
                            {
                                if (!Directory.Exists(serviceDest)) Directory.CreateDirectory(serviceDest);
                                FileAndFolderHelper.DirectoryCopy(serviceSource, serviceDest);
                            }
                            localJob.IsCopySourceDone = true;
                        }
                        catch (Exception ex)
                        {
                            localJob.FailCount = (localJob.FailCount ?? 0) + 1;
                            _diagnosticService.Error(ex);
                        }

                        //localJob.ServiceProcessing = false;
                        listJobUpdated.Add(localJob);
                    }, mainCancellationTokenSource);

                    tasks.Add(t);
                }

                Task.WaitAll(tasks.ToArray(), mainCancellationTokenSource);
                _deploymentJobService.UpdateListJobs(listJobUpdated);
            }
            catch (Exception ex)
            {
                _diagnosticService.Error(ex);
            }
        }
    }
}