using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ModifyConfigXml
{
    public class ModifyXml
    {
        public static void ModifileXml(string pathFile)
        {
            var configWeb = OpenConfigFile(Path.Combine(pathFile,"Web.config"));
            if (configWeb != null && configWeb.HasFile)
            {
                var sectionWebConn = (ConnectionStringsSection)configWeb.GetSection("connectionStrings");

                if (sectionWebConn != null && sectionWebConn.ConnectionStrings["AdminDb"] != null)
                    sectionWebConn.ConnectionStrings["AdminDb"].ConnectionString = "server=localhost;port=3306;database=test;uid=root;password=root";

                if (configWeb.AppSettings.Settings["EmailFromDisplayName"] != null) 
                    configWeb.AppSettings.Settings["EmailFromDisplayName"].Value = "Thao Email";

                if (configWeb.AppSettings.Settings["Url"] != null)
                    configWeb.AppSettings.Settings["Url"].Value = "thao.vn";

                configWeb.Save();
            }
        }

        protected static Configuration OpenConfigFile(string configPath)
        {
            var configFile = new FileInfo(configPath);
            var vdm = new VirtualDirectoryMapping(configFile.DirectoryName, true, configFile.Name);
            var wcfm = new WebConfigurationFileMap();
            wcfm.VirtualDirectories.Add("/", vdm);
            return WebConfigurationManager.OpenMappedWebConfiguration(wcfm, "/");
        }
    }
}
