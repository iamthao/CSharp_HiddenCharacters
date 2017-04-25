using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateFile.GendataDefault;

namespace CreateFile
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateDefaultData.ExcuteGenerate();
            ZipFile_Compression();
            Console.WriteLine("Success!");
            Console.ReadLine();
        }


        private static void ZipFile_Compression()
        {
            var startZip = true;
            string sourceZipKey = ConfigurationManager.AppSettings["SourceZip"];
            if (string.IsNullOrEmpty(sourceZipKey))
            {
                startZip = false;
                Console.WriteLine("SourceZip not found in App.config");
            }
            string targetZipKey = ConfigurationManager.AppSettings["TargetZip"];
            if (string.IsNullOrEmpty(targetZipKey))
            {
                startZip = false;
                Console.WriteLine("TargetZip not found in App.config");
            }

            if (startZip)
            {
                string filePathOfNewFolder = sourceZipKey;
                string zipFilePath = targetZipKey;

                var start = DateTime.Now;
                Console.WriteLine(start.ToString("MM/dd/yyyy HH:mm:ss") + ": Start Zip");
                if (File.Exists(zipFilePath))
                {
                    File.Delete(zipFilePath);
                }

                ZipFile.CreateFromDirectory(filePathOfNewFolder, zipFilePath);

                var end = DateTime.Now;
                Console.WriteLine(end.ToString("MM/dd/yyyy HH:mm:ss") + ": End Zip");
                Console.WriteLine("Total Zip: " + (end - start).TotalSeconds + " s");
            }
            
        }

       
    }
}
