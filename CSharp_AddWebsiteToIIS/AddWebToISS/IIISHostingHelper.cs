using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Web.Administration;

namespace AddWebToISS
{
    public interface IIISHostingHelper
    {
        void AddHost(string webSiteName, string hostDomain, string physicalPath, int port, TimeSpan connectionTimeOut, bool isApiWeb = false, bool isSsl = false, string certString = "");
        void RemoveHost(string webSiteName);
    }
    public class IISHostingHelper : IIISHostingHelper
    {
        public void AddHost(string webSiteName, string hostDomain, string physicalPath, int port, TimeSpan connectionTimeOut, bool isApiWeb = false, bool isSsl = false, string certString = "")
        {
            var iisManager = new ServerManager();
            physicalPath = physicalPath.Replace(@"\\", @"\").Replace(@"\\", @"\");
            var sites = iisManager.Sites;

            var bindingInformartion = string.Format("*:{0}:{1}", port, hostDomain);
            var bindingInformartion2 = string.Format("*:{0}:{1}", port, "www." + hostDomain);

            var site = sites.Add(webSiteName, "http", bindingInformartion, physicalPath);
            site.Bindings.Add(bindingInformartion2, "http");
            site.Limits.ConnectionTimeout = connectionTimeOut;

            if (isSsl && !string.IsNullOrEmpty(certString))
            {

                var bindingInformartionSsl = string.Format("*:{0}:{1}", 443, hostDomain);
                var bindingInformartion2Ssl = string.Format("*:{0}:{1}", 443, "www." + hostDomain);


                var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadOnly);
                foreach (X509Certificate2 mCert in store.Certificates)
                {

                    var certStr = certString;

                    if (mCert.Thumbprint != null && mCert.Thumbprint.ToUpper().Contains(certStr))
                    {
                        var bindingCollection = site.Bindings;
                        var binding = site.Bindings.CreateElement("binding");
                        binding["protocol"] = "https";
                        binding["sslFlags"] = 0;
                        binding["certificateHash"] = mCert.GetCertHashString(); // Enter your cert thumbprint value
                        binding["certificateStoreName"] = "My"; // This is generally the strore name for all certs
                        binding["bindingInformation"] = bindingInformartionSsl;
                        bindingCollection.Add(binding);


                        var binding1 = site.Bindings.CreateElement("binding");
                        binding1["protocol"] = "https";
                        binding1["sslFlags"] = 0;
                        binding1["certificateHash"] = mCert.GetCertHashString(); // Enter your cert thumbprint value
                        binding1["certificateStoreName"] = "My"; // This is generally the strore name for all certs
                        binding1["bindingInformation"] = bindingInformartion2Ssl;
                        bindingCollection.Add(binding1);
                        break;
                    }

                }

                store.Close();

                //site.Bindings.Add(bindingInformartionSsl, "https");
                //site.Bindings.Add(bindingInformartion2Ssl, "https");
                site.Limits.ConnectionTimeout = connectionTimeOut;
            }

            iisManager.ApplicationPools.Add(webSiteName);
            if (isApiWeb)
            {
                foreach (var applicationPool in iisManager.ApplicationPools)
                {
                    applicationPool.AutoStart = true;
                    applicationPool.ProcessModel.IdleTimeout = new TimeSpan(24, 0, 0);
                }
            }

            site.ApplicationDefaults.ApplicationPoolName = webSiteName;

            iisManager.CommitChanges();

            //iisManager.Sites[webSiteName].Start();
        }

        public void RemoveHost(string webSiteName)
        {
            var iisManager = new ServerManager();
            var sites = iisManager.Sites;

            var st = sites[webSiteName];
            if (st != null) iisManager.Sites.Remove(st);

            var pool = iisManager.ApplicationPools[webSiteName];
            if (pool != null) iisManager.ApplicationPools.Remove(pool);

            iisManager.CommitChanges();
        }
    }
}
