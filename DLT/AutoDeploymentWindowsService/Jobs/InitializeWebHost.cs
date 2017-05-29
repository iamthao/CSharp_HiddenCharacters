using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    public class InitializeWebHost : JobMasterFile
    {
        private readonly IDeploymentJobService _deploymentJobService;
        private readonly IIISHostingHelper _iisHostingHelper;
        private readonly IDiagnosticService _diagnosticService;

        public InitializeWebHost(IDiagnosticService diagnosticService, IEmailHandler emailHandler, IIISHostingHelper iisHostingHelper, IDeploymentJobService deploymentJobService)
            : base(diagnosticService, emailHandler, iisHostingHelper, deploymentJobService)
        {
            _deploymentJobService = deploymentJobService;
            _iisHostingHelper = iisHostingHelper;
            _diagnosticService = diagnosticService;
        }
        protected override void DoWork(object state)
        {
            var mainCancellationTokenSource = new CancellationToken();
            try
            {
                var certString = ConfigurationManager.AppSettings["CertString"];
                var isUrlWebAppHttps = false;
                var tasks = new List<Task>();
                var deploymentJobs = _deploymentJobService.Get(p => p.Server.Code == ServerId
                    && (p.IsCopySourceDone ?? false)
                    && (p.JobType == (int)JobType.WebApi || p.JobType == (int)JobType.WebApp)
                    && (p.IsStart ?? false)
                    && !(p.IsDone ?? false))
                    .OrderBy(p => p.FailCount)
                    .Take(2).ToList();

                var listJobUpdated = new List<DeploymentJob>();

                var timeout = new TimeSpan(0, 5, 0);
                foreach (var job in deploymentJobs)
                {
                    var localJob = job;
                    var t = Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            #region process data
                            var dbName = localJob.Configuration.DatabaseName;
                            var loginName = localJob.Configuration.DatabaseUsername;
                            var loginPassword = EncryptHelper.Decrypt(localJob.Configuration.DatabasePassword);
                            var istenant = localJob.Deployment != null && localJob.Deployment.Product != null &&
                                           (localJob.Deployment.Product.IsTenant ?? false);
                            var tempWebDomainName = localJob.Configuration.WebDomainName ?? "";
                            var tempWebApiDomainName = localJob.Configuration.WebApiDomainName ?? "";

                            if (!tempWebDomainName.Contains("http") && !tempWebDomainName.Contains("https"))
                                tempWebDomainName = "http://" + tempWebDomainName + "/";
                            else
                            {
                                tempWebDomainName = tempWebDomainName + "/";                               
                            }

                            if (tempWebDomainName.Contains("https"))
                            {
                                isUrlWebAppHttps = true;
                            }


                            if (!tempWebApiDomainName.Contains("http") )
                                tempWebApiDomainName = "http://" + tempWebApiDomainName + "/";
                            else
                            {
                                tempWebApiDomainName = tempWebApiDomainName + "/";
                            }

                            // Get host name for SignupDomain
                            var hostDomain = new Uri(tempWebDomainName).Host;
                            if (hostDomain.StartsWith("www"))
                                hostDomain = hostDomain.Remove(0, 4);
                            hostDomain = "." + hostDomain;
                            var con = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString);
                            var connStringWeb =
                                string.Format(
                                    "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};MultipleActiveResultSets=True",
                                    con.DataSource, dbName, loginName, loginPassword);
                            #endregion

                            #region add web app (AdminDb/FranchiseeDb)
                            if (localJob.JobType == (int)JobType.WebApp)
                            {
                                try
                                {
                                    var configWeb = OpenConfigFile(localJob.Configuration.DestinationWebPath + @"\\Web.config");
                                    if (configWeb != null && configWeb.HasFile)
                                    {
                                        var sectionWebConn = (ConnectionStringsSection)configWeb.GetSection("connectionStrings");
                                        if (sectionWebConn != null && sectionWebConn.ConnectionStrings["AdminDb"] != null) sectionWebConn.ConnectionStrings["AdminDb"].ConnectionString = connStringWeb;
                                        // get SignupDomain
                                        if (configWeb.AppSettings.Settings["SignupDomain"] != null) configWeb.AppSettings.Settings["SignupDomain"].Value = hostDomain;
                                        // get productId
                                        if (configWeb.AppSettings.Settings["ProductDeploymentId"] != null) configWeb.AppSettings.Settings["ProductDeploymentId"].Value = localJob.Deployment.ProductId.ToString();
                                        if (configWeb.AppSettings.Settings["Url"] != null) configWeb.AppSettings.Settings["Url"].Value = tempWebDomainName;
                                        if (configWeb.AppSettings.Settings["EmailFromDisplayName"] != null) configWeb.AppSettings.Settings["EmailFromDisplayName"].Value = localJob.Deployment.Product.Name;

                                        if (localJob.Deployment != null && localJob.Deployment.Product != null && (localJob.Deployment.Product.IsTenant ?? false))
                                        {
                                            if (localJob.Deployment.DeploymentType == (int)DeploymentType.Franchisee)
                                            {
                                                var product = localJob.Deployment.Product;
                                                var apiDomain = SuggestionNameHelper.GetWebApiDomainName(product.Domain, true, (int)DeploymentType.Admin, "", "");

                                                var deploymentAdmin = product.Deployments.Where(p => p.DeploymentType == (int)DeploymentType.Admin).ToList();
                                                if (deploymentAdmin.Any() && deploymentAdmin.First().DeploymentJobs.Any(p => p.JobType == (int)JobType.WebApi))
                                                {
                                                    apiDomain =
                                                        deploymentAdmin.First()
                                                            .DeploymentJobs.First(p => p.JobType == (int)JobType.WebApi)
                                                            .Configuration.WebApiDomainName;
                                                }
                                                if (apiDomain.Substring(apiDomain.Length - 1, 1) != @"/") apiDomain = apiDomain + @"/";
                                                if (configWeb.AppSettings.Settings["WebApiUrl"] != null) configWeb.AppSettings.Settings["WebApiUrl"].Value = apiDomain;
                                            }

                                            if (tempWebApiDomainName.Substring(tempWebApiDomainName.Length - 1, 1) != @"/") tempWebApiDomainName = tempWebApiDomainName + @"/";
                                            if (configWeb.AppSettings.Settings["WebApiUrlFranchisee"] != null) configWeb.AppSettings.Settings["WebApiUrlFranchisee"].Value = tempWebApiDomainName;
                                        }
                                        else
                                        {
                                            if (configWeb.AppSettings.Settings["WebApiUrl"] != null) configWeb.AppSettings.Settings["WebApiUrl"].Value = tempWebApiDomainName + "/";
                                        }

                                        if (!string.IsNullOrEmpty(localJob.Configuration.EmailAddress) && configWeb.AppSettings.Settings["EmailFrom"] != null) configWeb.AppSettings.Settings["EmailFrom"].Value = localJob.Configuration.EmailAddress;
                                        if (!string.IsNullOrEmpty(localJob.Configuration.EmailPassword) && configWeb.AppSettings.Settings["Password"] != null) configWeb.AppSettings.Settings["Password"].Value = EncryptHelper.Decrypt(localJob.Configuration.EmailPassword);
                                        if (!string.IsNullOrEmpty(localJob.Configuration.EmailHost) && configWeb.AppSettings.Settings["Host"] != null) configWeb.AppSettings.Settings["Host"].Value = localJob.Configuration.EmailHost;
                                        if (localJob.Configuration.EmailPort != null && localJob.Configuration.EmailPort != 0 && configWeb.AppSettings.Settings["Port"] != null) configWeb.AppSettings.Settings["Port"].Value = localJob.Configuration.EmailPort.ToString();

                                        if (istenant && localJob.Deployment.DeploymentType == (int)DeploymentType.Franchisee)
                                        {
                                            if (configWeb.AppSettings.Settings["DeploymentMode"] != null) configWeb.AppSettings.Settings["DeploymentMode"].Value = "franchisee";
                                            if (sectionWebConn.ConnectionStrings["FranchiseeDb"] != null) sectionWebConn.ConnectionStrings["FranchiseeDb"].ConnectionString = connStringWeb;
                                        }
                                        else if (istenant && localJob.Deployment.DeploymentType == (int)DeploymentType.Admin)
                                        {
                                            if (configWeb.AppSettings.Settings["DeploymentMode"] != null) configWeb.AppSettings.Settings["DeploymentMode"].Value = "camino";
                                        }

                                        configWeb.Save();
                                    }
                                }
                                catch { }

                                var uri = new Uri(tempWebDomainName);
                                if (localJob.Configuration.IsCreateDomain ?? false) _iisHostingHelper.RemoveHost(uri.Host);
                                //_iisHostingHelper.AddHost(uri.Host, uri.Host, localJob.Configuration.DestinationWebPath, 80, timeout, false, !string.IsNullOrEmpty(uri.Scheme) && uri.Scheme.ToLower() == "https", certString);
                                _iisHostingHelper.AddHost(uri.Host, uri.Host, localJob.Configuration.DestinationWebPath, 80, timeout, false, isUrlWebAppHttps, certString);
                            }
                            #endregion

                            #region add webapi host
                            if (localJob.JobType == (int)JobType.WebApi)
                            {
                                try
                                {
                                    var configWebApi = OpenConfigFile(localJob.Configuration.DestinationWebApiPath + @"\\Web.config");
                                    if (configWebApi != null && configWebApi.HasFile)
                                    {
                                        var sectionWebApiConn = (ConnectionStringsSection)configWebApi.GetSection("connectionStrings");
                                        if (sectionWebApiConn != null) sectionWebApiConn.ConnectionStrings["AdminDb"].ConnectionString = connStringWeb;
                                        if (configWebApi.AppSettings.Settings["Url"] != null) configWebApi.AppSettings.Settings["Url"].Value = tempWebApiDomainName;
                                        if (configWebApi.AppSettings.Settings["EmailFromDisplayName"] != null) configWebApi.AppSettings.Settings["EmailFromDisplayName"].Value = localJob.Deployment.Product.Name;
                                        if (!string.IsNullOrEmpty(localJob.Configuration.EmailAddress) && configWebApi.AppSettings.Settings["EmailFrom"] != null) configWebApi.AppSettings.Settings["EmailFrom"].Value = localJob.Configuration.EmailAddress;
                                        if (!string.IsNullOrEmpty(localJob.Configuration.EmailPassword) && configWebApi.AppSettings.Settings["Password"] != null) configWebApi.AppSettings.Settings["Password"].Value = EncryptHelper.Decrypt(localJob.Configuration.EmailPassword);
                                        if (!string.IsNullOrEmpty(localJob.Configuration.EmailHost) && configWebApi.AppSettings.Settings["Host"] != null) configWebApi.AppSettings.Settings["Host"].Value = localJob.Configuration.EmailHost;
                                        if (localJob.Configuration.EmailPort != null && localJob.Configuration.EmailPort != 0 && configWebApi.AppSettings.Settings["Port"] != null) configWebApi.AppSettings.Settings["Port"].Value = localJob.Configuration.EmailPort.ToString();

                                        var product = localJob.Deployment.Product;
                                        var deploymentAdmin = product.Deployments.Where(p => p.DeploymentType == (int)DeploymentType.Admin).ToList();
                                        var apiDomain = SuggestionNameHelper.GetWebApiDomainName(product.Domain, true, (int)DeploymentType.Admin, "", "");
                                        if (deploymentAdmin.Any() && deploymentAdmin.First().DeploymentJobs.Any(p => p.JobType == (int)JobType.WebApi))
                                        {
                                            apiDomain =
                                                deploymentAdmin.First()
                                                    .DeploymentJobs.First(p => p.JobType == (int)JobType.WebApi)
                                                    .Configuration.WebApiDomainName;
                                        }
                                        if (apiDomain.Substring(apiDomain.Length - 1, 1) != @"/") apiDomain = apiDomain + @"/";
                                        if (configWebApi.AppSettings.Settings["WebApiUrl"] != null) configWebApi.AppSettings.Settings["WebApiUrl"].Value = apiDomain;
                                        configWebApi.Save();
                                    }
                                }
                                catch { }
                                var uri = new Uri(tempWebApiDomainName);
                                if (localJob.Configuration.IsCreateDomain ?? false) _iisHostingHelper.RemoveHost(uri.Host);
                                _iisHostingHelper.AddHost(uri.Host, uri.Host, localJob.Configuration.DestinationWebApiPath, 80, timeout, true, !string.IsNullOrEmpty(uri.Scheme) && uri.Scheme.ToLower() == "https");
                                
                            }
                            #endregion

                            #region other config
                            foreach (var additionConfig in localJob.AdditionConfigs)
                            {
                                try
                                {
                                    var otherConfig =
                                        OpenConfigFile(localJob.Configuration.DestinationWebApiPath + @"\\Web.config");
                                    if (otherConfig != null && otherConfig.HasFile)
                                    {
                                        if (otherConfig.AppSettings.Settings[additionConfig.KeyConfigValue] != null)
                                            otherConfig.AppSettings.Settings[additionConfig.KeyConfigValue].Value =
                                                additionConfig.ReplaceByValue;
                                    }
                                    otherConfig.Save();
                                }
                                catch { }
                            }

                            #endregion

                            //confirm
                            localJob.IsDone = true;
                        }
                        catch (Exception ex)
                        {
                            localJob.FailCount = (localJob.FailCount ?? 0) + 1;
                            _diagnosticService.Error(ex);
                        }

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