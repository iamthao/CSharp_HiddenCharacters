using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipFile_SharpCompress
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile_SharpCompress();
            Console.WriteLine("Success!");
            Console.ReadLine();
        }
        private static void ZipFile_SharpCompress()
        {
            string filePathOfNewFolder = @"D:\TestZip\pcst";
            string zipFilePath = @"D:\TestZip\pcst_1.zip";

            Console.WriteLine("Start " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            if (File.Exists(zipFilePath))
            {
                File.Delete(zipFilePath);
            }

            using (Ionic.Zlib. zip = new ZipFile())
            {
                // add this map file into the "images" directory in the zip archive
                zip.AddFile("c:\\images\\personal\\7440-N49th.png", "images");
                // add the report into a different directory in the archive
                zip.AddFile("c:\\Reports\\2008-Regional-Sales-Report.pdf", "files");
                zip.AddFile("ReadMe.txt");
                zip.Save("MyZipFile.zip");
            }

            Console.WriteLine("End " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
        }
    }
}
