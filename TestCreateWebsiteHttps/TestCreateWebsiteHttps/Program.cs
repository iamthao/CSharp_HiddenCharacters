using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Web.Administration;

namespace TestCreateWebsiteHttps
{
    public interface IIISHostingHelper
    {
        void AddHost(string webSiteName, string hostDomain, string physicalPath, int port, TimeSpan connectionTimeOut, bool isApiWeb = false, bool isSsl = false);
        void RemoveHost(string webSiteName);
    }
    public class IISHostingHelper : IIISHostingHelper
    {
        public void AddHost(string webSiteName, string hostDomain, string physicalPath, int port, TimeSpan connectionTimeOut, bool isApiWeb = false, bool isSsl = false)
        {
            var iisManager = new ServerManager();
            physicalPath = physicalPath.Replace(@"\\", @"\").Replace(@"\\", @"\");
            var sites = iisManager.Sites;

            var bindingInformartion = string.Format("*:{0}:{1}", port, hostDomain);
            var bindingInformartion2 = string.Format("*:{0}:{1}", port, "www." + hostDomain);

            var site = sites.Add(webSiteName, "http", bindingInformartion, physicalPath);
            site.Bindings.Add(bindingInformartion2, "http");
            site.Limits.ConnectionTimeout = connectionTimeOut;

            //add certificate
            //X509Certificate2 certificate = new X509Certificate2(@"D:\Cert\cernew.cer");

            //X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);           
            //store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadWrite);           
            //store.Add(certificate);
            //store.Close();

            if (isSsl)
            {
                var bindingInformartionSsl = string.Format("*:{0}:{1}", 443, hostDomain);
                var bindingInformartion2Ssl = string.Format("*:{0}:{1}", 443, "www." + hostDomain);
                site.Bindings.Add(bindingInformartionSsl, "https");
                site.Bindings.Add(bindingInformartion2Ssl, "https");
                //site.Bindings.Add(bindingInformartionSsl, certificate.GetCertHash(), "Thao Test");
                //site.Bindings.Add(bindingInformartion2Ssl, certificate.GetCertHash(), "Thao Test");
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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start {0}", DateTime.Now);
            var timeout = new TimeSpan(0, 1, 0);
            //var webName = "test.thao.local";
            //var hostDomainName = "test.thao.local";
            //string physicalPath = "D:\\Deloyment\\Quickspatch";
            var webName = "";
            var hostDomainName = "";
            string physicalPath = @"D:\DestinationDeployment\quickspatchvietnam\annual50\webapp\webapp";
            int portNumber = 80;
            TimeSpan connectionTimeOut = timeout;
            bool isApiWeb = false;
            bool isSsl = true;
            var list = new List<string> {"aaa", "aaaa"};
            var a = new IISHostingHelper();
            foreach (var item in list)
            {
                webName = item + ".quickspatchvietnam.local";
                hostDomainName = item + ".quickspatchvietnam.local";
                Console.WriteLine(webName +" ----"+ hostDomainName);
                a.AddHost(webName, hostDomainName, physicalPath, 80, connectionTimeOut, false, true);
            }
           

           
            //a.AddHost(webName, hostDomainName, physicalPath, 80, connectionTimeOut,false,true);
            Console.WriteLine("End {0}", DateTime.Now);
            Console.ReadLine();
        }
    }
}
