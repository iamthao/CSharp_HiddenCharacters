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
using CreateFile.Ultilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace CreateFile
{
    class Program
    {
        public static string _versionPcstOld = "";
        public static string _versionPcstNew = "1.0.0.0";

        static void Main(string[] args)
        {
            var listMess = new List<string>();

            //Gen new data
            List<string> outMessGen;
            GenerateDefaultData.ExcuteGenerate(out outMessGen);

            //kiem tra data co change
            List<string> outCheckChange;
            var exportNew = CheckChangeNumberRecordChange(out outCheckChange);

            List<string> outMessZip = new List<string>();
            List<string> outMessCopyFile = new List<string>();
            if (exportNew)
            {              
                //Gen file zip to Tool
                ZipFile_Compression(out outMessZip);

                //Copy file tu Tool to Notificatin aand rename to PcstUpdate.zip
                ZipFile_CopyFileToNotification(out outMessCopyFile);               
            }

            if (outMessGen.Count > 0)
            {
                listMess.AddRange(outMessGen);
            }
            if (outCheckChange.Count > 0)
            {
                listMess.AddRange(outCheckChange);
            }
            if (outMessZip.Count > 0)
            {
                listMess.AddRange(outMessZip);
            }
            if (outMessCopyFile.Count > 0)
            {
                listMess.AddRange(outMessCopyFile);
            }

            listMess.Add("Export new version: " + exportNew);
            WriteFileLog(listMess);

            Console.WriteLine("Success!!! ");
            //Console.ReadKey();
            Thread.Sleep(2000);
            Environment.Exit(0);
        }

        private static void ZipFile_CopyFileToNotification(out List<string> mess)
        {
            mess = new List<string>();
            var startCopy = true;
            string sourcePathFileZip = ConfigurationManager.AppSettings["TargetZip"];
            if (string.IsNullOrEmpty(sourcePathFileZip))
            {
                startCopy = false;
                Console.WriteLine("TargetZip not found in App.config");
                mess.Add("TargetZip not found in App.config");
            }
            string pathFolderNotificationKey = ConfigurationManager.AppSettings["NotificationApiPath"];
            if (string.IsNullOrEmpty(pathFolderNotificationKey))
            {
                startCopy = false;
                Console.WriteLine("NotificationApiPath not found in App.config");
                mess.Add("NotificationApiPath not found in App.config");
            }
            if (startCopy)
            {
                var start = DateTime.Now;
                Console.WriteLine(start.ToString("MM-dd-yyyy HH:mm:ss") + ": Start Copy");
                mess.Add(start.ToString("MM-dd-yyyy HH:mm:ss") + ": Start Copy");


                if (File.Exists(sourcePathFileZip))
                {
                    var pathNotification = Path.Combine(pathFolderNotificationKey, "PcstUpdate.zip");
                    if (File.Exists(pathNotification))
                    {
                        File.Delete(pathNotification);
                    }

                    System.IO.File.Copy(sourcePathFileZip, pathNotification);

                    //read file version
                    var pathVersion = Path.Combine(pathFolderNotificationKey, "PcstVersion.txt");
                    if (!File.Exists(pathVersion))
                    {
                        File.Create(pathVersion).Close();
                    }

                    FileHelper.WriteFile(pathVersion, _versionPcstNew);
                }

                var end = DateTime.Now;
                Console.WriteLine(end.ToString("MM-dd-yyyy HH:mm:ss") + ": End Copy");
                Console.WriteLine("Total Zip: " + (end - start).TotalSeconds + " s");
                mess.Add(end.ToString("MM-dd-yyyy HH:mm:ss") + ": End Copy");
                mess.Add("Total Copy: " + (end - start).TotalSeconds + " s\n");
            }

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
            string sourcePathFileZip = ConfigurationManager.AppSettings["TargetZip"];
            if (string.IsNullOrEmpty(sourcePathFileZip))
            {
                startZip = false;
                Console.WriteLine("TargetZip not found in App.config");
                mess.Add("TargetZip not found in App.config");
            }


            if (startZip)
            {
                //read file version
                var pathVersion = Path.Combine(sourceZipKey, "PcstVersion.txt");
                if (!File.Exists(pathVersion))
                {
                    File.Create(pathVersion).Close();
                }

                _versionPcstOld = File.ReadAllText(pathVersion);
                _versionPcstNew = UpgradeVersion.UpgradeVersionText(_versionPcstOld);

                FileHelper.WriteFile(pathVersion, _versionPcstNew);


                string filePathOfNewFolder = sourceZipKey;
                string zipFilePath = sourcePathFileZip;

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

        private static void WriteFileLog(List<string> listMess)
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
            }
        }

        private static bool CheckChangeNumberRecordChange(out List<string> listMess)
        {
            listMess = new List<string>();
            var hasChange = false;
            var listTableName = new List<string> { "Route", "PrimaryLanguage", "County", "Icd", "Npi", "Frequency", "Section", "SectionQuestion", "ProviderAgency", "ProviderMpi" };

            foreach (var item in listTableName)
            {               
                var newText = FileHelper.ReadFileInFolderLogFileTableDatabase(item + "_New.txt");
                var oldText = FileHelper.ReadFileInFolderLogFileTableDatabase(item + "_Old.txt");

                if (!newText.Equals(oldText))
                {
                    //Write again old file
                    FileHelper.WriteFileInFolderLogFileTableDatabase(item + "_Old.txt", newText);
                    hasChange = true;
                    //Console.WriteLine(item);
                    listMess.Add("Table " + item + " has changed.");
                }
            }

            return hasChange;
        }
        
    }
}
