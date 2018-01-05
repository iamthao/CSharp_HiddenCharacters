using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;

namespace AddWebToISS
{
    public class IisHelper
    {
        public static void AddNewWeb(string webSiteName, string hostDomain, string physicalPath, int port, TimeSpan connectionTimeOut, bool isApiWeb = false, bool isSsl = false, string certString = "")
        {
            var iisManager = new ServerManager();
            if (CheckDomainExist(webSiteName))
            {
                RemoveHost(webSiteName);
            }

            physicalPath = physicalPath.Replace(@"\\", @"\").Replace(@"\\", @"\");
            var sites = iisManager.Sites;

            var bindingInformartion = string.Format("*:{0}:{1}", port, hostDomain);
            var bindingInformartion2 = string.Format("*:{0}:{1}", port, "www." + hostDomain);

            var site = sites.Add(webSiteName, "http", bindingInformartion, physicalPath);
            site.Bindings.Add(bindingInformartion2, "http");
            site.Limits.ConnectionTimeout = connectionTimeOut;

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
        }

        public static void RemoveHost(string webSiteName)
        {
            var iisManager = new ServerManager();
            var sites = iisManager.Sites;

            var st = sites[webSiteName];
            if (st != null) iisManager.Sites.Remove(st);

            var pool = iisManager.ApplicationPools[webSiteName];
            if (pool != null) iisManager.ApplicationPools.Remove(pool);

            iisManager.CommitChanges();
        }

        public static bool CheckDomainExist(string webSiteName)
        {
            ServerManager serverManager = new ServerManager();
            if (serverManager.Sites.Any(o => o.Name.ToLower().Equals(webSiteName.ToLower())))
            {
                return true;
            }
            if (serverManager.ApplicationPools.Any(o => o.Name.ToLower().Equals(webSiteName.ToLower())))
            {
                return true;
            }           
            return false;
        }
    }
}
