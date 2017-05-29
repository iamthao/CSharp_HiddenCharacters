using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using Framework.DomainModel.Common;
using Framework.DomainModel.Entities;
using Framework.Service.Diagnostics;
using Framework.Utility;
using Microsoft.SqlServer.Management.Common;
using ServiceLayer.Interfaces;
using Server = Microsoft.SqlServer.Management.Smo.Server;

namespace AutoDeploymentWindowsService.Jobs
{
    public class UninstallJob : JobMasterFile
    {
        private readonly IDeploymentJobService _deploymentJobService;
        private readonly IDiagnosticService _diagnosticService;
        private readonly IIISHostingHelper _iisHostingHelper;

        public UninstallJob(IDiagnosticService diagnosticService, IEmailHandler emailHandler, IIISHostingHelper iisHostingHelper, IDeploymentJobService deploymentJobService)
            : base(diagnosticService, emailHandler, iisHostingHelper, deploymentJobService)
        {
            _deploymentJobService = deploymentJobService;
            _diagnosticService = diagnosticService;
            _iisHostingHelper = iisHostingHelper;
        }

        protected override void DoWork(object state)
        {
            var mainCancellationTokenSource = new CancellationToken();
            try
            {
                var tasks = new List<Task>();
                var deploymentJobs = _deploymentJobService.Get(p => p.Server.Code == ServerId
                    && (p.MarkToRemove ?? false)
                    && !(p.IsRemoveDone ?? false)).Take(3).ToList();

                if (!deploymentJobs.Any()) return;

                var listJobUpdated = new List<DeploymentJob>();

                foreach (var job in deploymentJobs)
                {
                    var localJob = job;
                    var t = Task.Factory.StartNew(() =>
                    {
                        //path
                        var serviceDest = localJob.Configuration.DestinationWindowServicePath;
                        var webDest = localJob.Configuration.DestinationWebPath;
                        var webDestApi = localJob.Configuration.DestinationWebApiPath;

                        //uninstall servie
                        if (localJob.JobType == (int)JobType.WindowService && Directory.Exists(serviceDest))
                        {
                            try
                            {
                                StopService(localJob.Configuration.ServiceName, serviceDest + @"\" + localJob.Configuration.ServiceFileName);
                                if (Directory.Exists(serviceDest)) Directory.Delete(serviceDest, true);
                            }
                            catch (Exception exception)
                            {
                                _diagnosticService.Error(exception);
                            }
                        }

                        //unstall host
                        if (localJob.JobType == (int)JobType.WebApp)
                        {
                            if (!localJob.Configuration.WebDomainName.Contains("http"))
                                localJob.Configuration.WebDomainName = "http://" + localJob.Configuration.WebDomainName + "/";

                            var uri = new Uri(localJob.Configuration.WebDomainName);
                            _iisHostingHelper.RemoveHost(uri.Host);
                            if (Directory.Exists(webDest)) Directory.Delete(webDest, true);
                        }
                        if (localJob.JobType == (int)JobType.WebApi)
                        {
                            if (!localJob.Configuration.WebApiDomainName.Contains("http"))
                                localJob.Configuration.WebApiDomainName = "http://" + localJob.Configuration.WebApiDomainName + "/";

                            var uri = new Uri(localJob.Configuration.WebApiDomainName);
                            _iisHostingHelper.RemoveHost(uri.Host);
                            if (Directory.Exists(webDestApi)) Directory.Delete(webDestApi, true);
                        }

                        //delete database
                        if (localJob.JobType == (int)JobType.Database)
                        {
                            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString);
                            var server = new Server(new ServerConnection(conn));
                            var db = server.Databases[localJob.Configuration.DatabaseName];
                            if (db != null)
                            {
                                server.KillAllProcesses(localJob.Configuration.DatabaseName);
                                server.KillDatabase(localJob.Configuration.DatabaseName);
                                db.Drop();
                            }
                            var login = server.Logins[localJob.Configuration.DatabaseUsername];
                            if (login != null) login.Drop();
                        }

                        localJob.IsCopySourceDone = false;
                        localJob.IsRemoveDone = true;

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

        #region function
        private bool StopService(string serviceName, string servicePath)
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
                UninstallService(servicePath, serviceName);
                return true;
            }
            catch (Exception ex)
            {
                _diagnosticService.Error(ex);
                return false;
            }
        }

        private void UninstallService(string servicePath, string serviceName)
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
            //ManagedInstallerClass.InstallHelper(new string[] { "/u", servicePath });
        }

        public ServiceController GetServiceControl(string strServiceName)
        {
            ServiceController[] services = ServiceController.GetServices();

            foreach (ServiceController controller in services)
            {
                if (controller.ServiceName.Equals(strServiceName))
                {
                    return controller;
                }
            }
            return null;
        }
        #endregion
    }
}