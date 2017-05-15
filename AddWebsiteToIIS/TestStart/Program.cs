using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddWebToISS;
using CopyFolderToFolder;
using InstallDatabase;
using ModifyConfigXml;

namespace TestStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("["+DateTime.Now.ToString("yyyy-MM-dd")+"] Start...");
            var pathSource = @"D:\TestZip\Source\Web";
            var pathDestination = @"D:\TestZip\Destination\Web_1";
            
            //Copy Soure
            CopyFolder.CopyFolderToFolder(pathSource,pathDestination);
            
            //modify web.config
            ModifyXml.ModifileXml(pathDestination);
            
            //Create database
            var pathFileAdmin = @"D:\TestZip\Source\Database\admin.sql";
            var pathFileUser = @"D:\TestZip\Source\Database\createuser.sql";
            InstallDb.RunSqlFile(pathFileAdmin, pathFileUser);


            //New website
            var webSiteName = "thao1.vn";
            var physicalPath = pathDestination;
            var port = 80;
            var connectionTimeOut = new TimeSpan(0, 5, 0);
            var isSsl = false;
            var certString = "";
            IisHelper.AddNewWeb(webSiteName, webSiteName, physicalPath, port, connectionTimeOut, false, isSsl, certString);

            //remove website
            //IisHelper.RemoveHost(webSiteName);

            Console.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd") + "] End");
            Console.WriteLine(" Success!!!");
            Console.ReadLine();
        }
    }
}
