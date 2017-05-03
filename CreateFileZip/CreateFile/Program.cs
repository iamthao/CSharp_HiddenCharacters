using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CreateFile.GendataDefault;

namespace CreateFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var listMess = new List<string>();
            List<string> outMessGen;
            GenerateDefaultData.ExcuteGenerate(out outMessGen);

            List<string> outMessZip;
            ZipFile_Compression(out outMessZip);

            if (outMessGen.Count>0)
            {
                listMess.AddRange(outMessGen);
            }
            if (outMessZip.Count > 0)
            {
                listMess.AddRange(outMessZip);
            }

            WriteFileLog(listMess);

            Console.WriteLine("Success!!!");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }


        private static void ZipFile_Compression(out List<string> mess)
        {
            mess = new List<string>();
            var startZip = true;
            string sourceZipKey = ConfigurationManager.AppSettings["SourceZip"];
            if (string.IsNullOrEmpty(sourceZipKey))
            {
                startZip = false;
                Console.WriteLine("SourceZip not found in App.config");
                mess.Add("SourceZip not found in App.config");
            }
            string targetZipKey = ConfigurationManager.AppSettings["TargetZip"];
            if (string.IsNullOrEmpty(targetZipKey))
            {
                startZip = false;
                Console.WriteLine("TargetZip not found in App.config");
                mess.Add("TargetZip not found in App.config");
            }

            if (startZip)
            {
                string filePathOfNewFolder = sourceZipKey;
                string zipFilePath = targetZipKey;

                var start = DateTime.Now;
                Console.WriteLine(start.ToString("MM-dd-yyyy HH:mm:ss") + ": Start Zip");
                mess.Add(start.ToString("MM-dd-yyyy HH:mm:ss") + ": Start Zip");

                if (File.Exists(zipFilePath))
                {
                    File.Delete(zipFilePath);
                }

                ZipFile.CreateFromDirectory(filePathOfNewFolder, zipFilePath);

                var end = DateTime.Now;
                Console.WriteLine(end.ToString("MM-dd-yyyy HH:mm:ss") + ": End Zip");
                Console.WriteLine("Total Zip: " + (end - start).TotalSeconds + " s");
                mess.Add(end.ToString("MM-dd-yyyy HH:mm:ss") + ": End Zip");
                mess.Add("Total Zip: " + (end - start).TotalSeconds + " s\n");
            }
            
        }

        private static string WriteFileLog(List<string> listMess)
        {
            if (listMess.Count() > 0)
            {
                string dirpathLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
                if (!Directory.Exists(dirpathLog))
                {
                    Directory.CreateDirectory(dirpathLog);
                }

                var fileName = DateTime.Now.ToString("MM-dd-yyyy");
                var pathLog = Path.Combine(dirpathLog, fileName + ".log");
                if (!File.Exists(pathLog))
                {
                    File.Create(pathLog).Close();
                }

                using (StreamWriter stream = File.AppendText(pathLog))
                {

                    foreach (var item in listMess)
                    {
                        stream.WriteLine(item);
                    }


                }

                return pathLog;
            }
            return "";
        }
       
    }
}
