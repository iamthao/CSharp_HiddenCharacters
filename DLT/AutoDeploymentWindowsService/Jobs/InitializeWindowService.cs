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
using Autofac;
using Framework.DomainModel.Common;
using Framework.DomainModel.Entities;
using Framework.Service.Diagnostics;
using Framework.Utility;
using ServiceLayer.Interfaces;

namespace AutoDeploymentWindowsService.Jobs
{
    public class InitializeWindowService : JobMasterFile
    {
        private readonly IDeploymentJobService _deploymentJobService;
        private readonly IDiagnosticService _diagnosticService;

        public InitializeWindowService(IDiagnosticService diagnosticService, IEmailHandler emailHandler, IIISHostingHelper iisHostingHelper, IDeploymentJobService deploymentJobService)
            : base(diagnosticService, emailHandler, iisHostingHelper, deploymentJobService)
        {
            _deploymentJobService = deploymentJobService;
            _diagnosticService = diagnosticService;
        }

        protected override void DoWork(object state)
        {
            try
            {
                var tasks = new List<Task>();
                var deploymentJobs = _deploymentJobService.Get(p => p.Server.Code == ServerId
                                                                    && (p.IsCopySourceDone ?? false)
                                                                    && p.JobType == (int)JobType.WindowService
                                                                    && (p.IsStart ?? false)
                                                                    && !(p.IsDone ?? false))
                                                                    .OrderBy(p => p.FailCount)
                                                                    .Take(3).ToList();

                if (!deploymentJobs.Any()) return;

                var listJobUpdated = new List<DeploymentJob>();

                foreach (var job in deploymentJobs)
                {
                    var localJob = job;
                    var t = Task.Factory.StartNew(() =>
                    {
                        #region job implement
                        try
                        {
                            var serviceDest = localJob.Configuration.DestinationWindowServicePath;
                            var dbName = localJob.Configuration.DatabaseName;
                            var loginName = localJob.Configuration.DatabaseUsername;
                            var loginPassword = EncryptHelper.Decrypt(localJob.Configuration.DatabasePassword);

                            var con =
                                new SqlConnectionStringBuilder(
                                    ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString);
                            var connStringWeb =
                                string.Format(
                                    "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};MultipleActiveResultSets=True",
                                    con.DataSource, dbName, loginName, loginPassword);

                            //service
                            var configService =
                                OpenConfigFile(serviceDest + @"\" + localJob.Configuration.ServiceFileName + ".config");
                            if (configService.HasFile)
                            {
                                var sectionService =
                                    (ConnectionStringsSection)configService.GetSection("connectionStrings");
                                if (sectionService.ConnectionStrings["AdminDb"] != null)
                                {
                                    sectionService.ConnectionStrings["AdminDb"].ConnectionString = connStringWeb;
                                }

                                if (configService.AppSettings.Settings["ServiceName"] == null)
                                {
                                    configService.AppSettings.Settings.Add("ServiceName", localJob.Configuration.ServiceName);
                                }
                                else
                                {
                                    configService.AppSettings.Settings["ServiceName"].Value = localJob.Configuration.ServiceName;
                                }

                                foreach (var additionConfig in localJob.AdditionConfigs)
                                {
                                    if (configService.AppSettings.Settings[additionConfig.KeyConfigValue] != null)
                                        configService.AppSettings.Settings[additionConfig.KeyConfigValue].Value = additionConfig.ReplaceByValue;
                                }
                                configService.Save();
                            }

                            StartService(serviceDest + @"\" + localJob.Configuration.ServiceFileName,
                                localJob.Configuration.ServiceName);
                            localJob.IsDone = true;
                        }
                        catch (Exception ex)
                        {
                            localJob.FailCount = (localJob.FailCount ?? 0) + 1;
                            _diagnosticService.Error(ex);
                        }
                        #endregion

                        listJobUpdated.Add(localJob);
                    });

                    tasks.Add(t);
                }

                Task.WaitAll(tasks.ToArray());
                _deploymentJobService.UpdateListJobs(listJobUpdated);
            }
            catch (Exception ex)
            {
                _diagnosticService.Error(ex);
            }
        }

        private void StartService(string servicePath, string serviceName)
        {
            var serviceController = GetServiceControl(serviceName);
            if (serviceController == null)
            {
                InstallService(servicePath, serviceName);
                serviceController = GetServiceControl(serviceName);
            }

            if (serviceController != null && serviceController.Status != ServiceControllerStatus.Running) serviceController.Start();
        }

        private void InstallService(string servicePath, string serviceName)
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

        private ServiceController GetServiceControl(string strServiceName)
        {
            var services = ServiceController.GetServices();

            return services.FirstOrDefault(controller => controller.ServiceName.Equals(strServiceName));
        }
    }
}