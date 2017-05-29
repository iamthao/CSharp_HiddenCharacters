using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Framework.DomainModel.Common;
using Framework.DomainModel.Entities;
using Framework.Service.Diagnostics;
using Framework.Utility;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using ServiceLayer.Common;
using ServiceLayer.Interfaces;
using Server = Microsoft.SqlServer.Management.Smo.Server;
using User = Microsoft.SqlServer.Management.Smo.User;

namespace AutoDeploymentWindowsService.Jobs
{
    public class InitializeDatabase : JobMasterFile
    {
        private readonly IDeploymentJobService _deploymentJobService;
        private readonly IDiagnosticService _diagnosticService;

        public InitializeDatabase(IDiagnosticService diagnosticService, IEmailHandler emailHandler, IIISHostingHelper iisHostingHelper, IDeploymentJobService deploymentJobService)
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
                    && p.JobType == (int)JobType.Database
                    && (p.IsCopySourceDone ?? false)
                    && (p.IsStart ?? false)
                    && !(p.IsDone ?? false))
                    .OrderBy(p => p.FailCount)
                    .Take(2).ToList();

                var listJobUpdated = new List<DeploymentJob>();

                foreach (var job in deploymentJobs)
                {
                    var localJob = job;
                    var t = Task.Factory.StartNew(() =>
                    {
                        var dbName = localJob.Configuration.DatabaseName;
                        var loginName = localJob.Configuration.DatabaseUsername;
                        var loginPassword = EncryptHelper.Decrypt(localJob.Configuration.DatabasePassword);
                        var pass = PasswordHelper.HashString("123456", "camino");

                        var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString);
                        var file = new FileInfo(localJob.Configuration.SqlScriptPath);
                        var script = file.OpenText().ReadToEnd();
                        script = script.Replace("{{DATABASE_NAME}}", dbName)
                        .Replace("{{FRANCHISEE_ADMIN_NAME}}", "camino")
                        .Replace("{{FRANCHISEE_ADMIN_PASSWORD}}", pass)
                        .Replace("{{FRANCHISEE_ADMIN_EMAIL}}", "admin@caminois.com");


                        var server = new Server(new ServerConnection(conn));

                        try
                        {
                            server.ConnectionContext.ExecuteNonQuery(script);
                            using (var scope = new TransactionScope())
                            {
                                var db = server.Databases[dbName];
                                var login = server.Logins[loginName];
                                if (login == null)
                                {
                                    // Creating Logins
                                    login = new Login(server, loginName) { LoginType = LoginType.SqlLogin, PasswordPolicyEnforced = false };
                                    login.Create(loginPassword);
                                    login.DefaultDatabase = dbName;
                                    login.Alter();
                                }

                                // Creating Users in the database for the logins created
                                if (db.Users[loginName] != null) return;
                                var dbUser = new User(db, loginName)
                                {
                                    UserType = UserType.SqlLogin,
                                    Login = login.Name,
                                };
                                dbUser.Create();
                                dbUser.AddToRole("db_owner");

                                localJob.IsDone = true;
                                scope.Complete();
                            }

                        }
                        catch (Exception exception)
                        {
                            server = new Server(new ServerConnection(conn));
                            server.KillAllProcesses(dbName);
                            server.KillDatabase(dbName);
                            var db = server.Databases[dbName];
                            db.Drop();
                            localJob.IsDone = false;
                            localJob.FailCount = (localJob.FailCount ?? 0) + 1;
                            _diagnosticService.Error(exception);
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