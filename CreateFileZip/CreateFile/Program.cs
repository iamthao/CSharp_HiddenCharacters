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
        private static string _connectionString;
        private static string _conn = "";
        private static MySqlDataBakup _mySqlDataBakup;
        public static string _versionPcstOld = "";
        public static string _versionPcstNew = "1.0.0.0";

        static void Main(string[] args)
        {
            var listMess = new List<string>();

            string connectionStringKey = ConfigurationManager.AppSettings["ConnectionString"];
            _conn = connectionStringKey;

            //kiem tra data co change
            var exportNew = true;//CheckChangeNumberRecordChange();
            if (exportNew)
            {
                //Gen new data
                List<string> outMessGen;
                GenerateDefaultData.ExcuteGenerate(out outMessGen);

                //Gen file zip to Tool
                List<string> outMessZip;
                ZipFile_Compression(out outMessZip);

                //Copy file tu Tool to Notificatin aand rename to PcstUpdate.zip
                List<string> outMessCopyFile;
                ZipFile_CopyFileToNotification(out outMessCopyFile);


                if (outMessGen.Count > 0)
                {
                    listMess.AddRange(outMessGen);
                }
                if (outMessZip.Count > 0)
                {
                    listMess.AddRange(outMessZip);
                }
                if (outMessCopyFile.Count > 0)
                {
                    listMess.AddRange(outMessCopyFile);
                }

                WriteFileLog(listMess);
            }

            Console.WriteLine("Success!!!");
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

        private static bool CheckChangeNumberRecordChange()
        {
            string numberRecordPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NumberRecord.txt");
            var numberRecordStr = "";

            //Neu ton tai doc ra
            if (File.Exists(numberRecordPath))
            {
                numberRecordStr = File.ReadAllText(numberRecordPath);
            }
            //ko ton tai tao moi , viet data moi 
            else
            {
                if (!File.Exists(numberRecordPath))
                {
                    File.Create(numberRecordPath).Close();
                }

                WriteAgainNumberRecord(numberRecordPath, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                return true;
            }

            //Neu ton tai ma empty 
            if (string.IsNullOrEmpty(numberRecordStr))
            {
                WriteAgainNumberRecord(numberRecordPath, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                return true;
            }
            else
            {
                var dataJson = JsonConvert.DeserializeObject<NumberRecord>(numberRecordStr);
                //read database
                ConnectDatabase();
                var totalLanguage = 0;
                var totalCounty = 0;
                var totalIcd = 0;
                var totalNpi = 0;
                var totalRoute = 0;
                var totalFrequency = 0;
                var totalSection = 0;
                var totalSectionQuestion = 0;
                var totalPhysicanNpi = 0;
                var totalProviderAgency = 0;
                var totalProviderMpi = 0;

                using (var mysqlProvider = new MySqlDataProvider(_connectionString))
                {
                    totalLanguage = mysqlProvider.GetCount(ScriptMySqlHelper.TableLanguageCount);
                    totalCounty = mysqlProvider.GetCount(ScriptMySqlHelper.TableCountyCount);
                    totalIcd = mysqlProvider.GetCount(ScriptMySqlHelper.TableIcdCount);
                    totalNpi = mysqlProvider.GetCount(ScriptMySqlHelper.TableNpiCount);
                    totalRoute = mysqlProvider.GetCount(ScriptMySqlHelper.TableRouteCount);
                    totalFrequency = mysqlProvider.GetCount(ScriptMySqlHelper.TableFrequencyCount);
                    totalSection = mysqlProvider.GetCount(ScriptMySqlHelper.TableSectionCount);
                    totalSectionQuestion = mysqlProvider.GetCount(ScriptMySqlHelper.TableSectionQuestionCount);
                    totalPhysicanNpi = mysqlProvider.GetCount(ScriptMySqlHelper.TablePhysicanNpiCount);
                    totalProviderAgency = mysqlProvider.GetCount(ScriptMySqlHelper.TableProviderAgencyCount);
                    totalProviderMpi = mysqlProvider.GetCount(ScriptMySqlHelper.TableProviderMpiCount);
                }

                if (totalLanguage != dataJson.Language || totalCounty != dataJson.County || totalIcd != dataJson.Icd ||
                    totalNpi != dataJson.Npi || totalRoute != dataJson.Route || totalFrequency != dataJson.Frequency ||
                    totalSection != dataJson.Section || totalSectionQuestion != dataJson.SectionQuestion
                    || totalPhysicanNpi != dataJson.PhysicanNpi || totalProviderAgency != dataJson.ProviderAgency
                    || totalProviderMpi != dataJson.ProviderMpi)
                {
                    WriteAgainNumberRecord(numberRecordPath, totalLanguage, totalCounty, totalIcd, totalNpi, totalRoute, totalFrequency,
                                    totalSection, totalSectionQuestion, totalPhysicanNpi, totalProviderAgency, totalProviderMpi);
                    return true;
                }
            }
            return false;
        }

        private static void WriteAgainNumberRecord(string numberRecordPath, int language, int county, int icd, int npi, int route,
                                                    int frequency, int section, int sectionQuestion, int physicanNpi, int providerAgency, int providerMpi)
        {
            File.WriteAllText(numberRecordPath, String.Empty);

            var numberRecord = new NumberRecord
            {
                Language = language,
                County = county,
                Icd = icd,
                Npi = npi,
                Route = route,
                Frequency = frequency,
                Section = section,
                SectionQuestion = sectionQuestion,
                PhysicanNpi = physicanNpi,
                ProviderAgency = providerAgency,
                ProviderMpi = providerMpi
            };

            using (StreamWriter stream = File.AppendText(numberRecordPath))
            {
                stream.WriteLine(JsonConvert.SerializeObject(numberRecord));
            }
        }

        public class NumberRecord
        {
            public int Language { get; set; }
            public int County { get; set; }
            public int Icd { get; set; }
            public int Npi { get; set; }
            public int Route { get; set; }
            public int Frequency { get; set; }
            public int Section { get; set; }
            public int SectionQuestion { get; set; }
            public int PhysicanNpi { get; set; }
            public int ProviderAgency { get; set; }
            public int ProviderMpi { get; set; }
        }

        private static void ConnectDatabase()
        {
            _mySqlDataBakup = new MySqlDataBakup(_conn);
            Exception ex;
            if (!_mySqlDataBakup.IsConnected(out ex))
            {

            }
            else
            {
                _connectionString = _conn;
            }

            if (_mySqlDataBakup != null)
            {
                _mySqlDataBakup.Dispose();
            }
        }

    }
}
