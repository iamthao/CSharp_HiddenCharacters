using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddWebToISS;
using CopyFolderToFolder;
using InstallDatabase;
using InstallService;
using ModifyConfigXml;

namespace TestStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd") + "] Start...");

            var pathSourceRoot = @"D:\TestZip\Source";
            var pathDestinationRoot = @"D:\TestZip\Destination";

            var name = "thao";
            var directoryDestination = Path.Combine(pathDestinationRoot, name);
            if (!Directory.Exists(directoryDestination))
            {
                Directory.CreateDirectory(directoryDestination);
            }
            //Copy Soure web
            var pathSource = Path.Combine(pathSourceRoot, "Web");
            var pathDestination = Path.Combine(directoryDestination, "Web");
            //CopyFolder.CopyFolderToFolder(pathSource, pathDestination);


            //Copy Soure Service
            var serviceName = "AAAA_"+name ;
            var pathSourceService = Path.Combine(pathSourceRoot, "Service");
            var pathDestinationService = Path.Combine(directoryDestination, "Service");
            CopyFolder.CopyFolderToFolder(pathSourceService, pathDestinationService);
            var servicePath = Path.Combine(pathDestinationService, "ServiceTest.exe");
            ServiceHelper.InstallAndStartService(servicePath, serviceName);



            //modify web.config
            //ModifyXml.ModifileXml(pathDestination);


            //Create database
            //var pathFileAdmin = @"D:\TestZip\Source\Database\admin.sql";
            //var pathFileUser = @"D:\TestZip\Source\Database\createuser.sql";
            //InstallDb.RunSqlFile(pathFileAdmin, pathFileUser);


            //New website
            var webSiteName = name + ".vn";
            //var physicalPath = pathDestination;
            //var port = 80;
            //var connectionTimeOut = new TimeSpan(0, 5, 0);
            //var isSsl = false;
            //var certString = "";
            //IisHelper.AddNewWeb(webSiteName, webSiteName, physicalPath, port, connectionTimeOut, false, isSsl, certString);


            //Uninstall All
            //IisHelper.RemoveHost(webSiteName);
            //ServiceHelper.StopService(servicePath, serviceName);

            Console.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd") + "] End");
            Console.WriteLine(" Success!!!");
            Console.ReadLine();
        }

    }
}
