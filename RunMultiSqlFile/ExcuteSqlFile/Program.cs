using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Repository;
using System.IO;
using System.Configuration;

namespace ExcuteSqlFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var listFiles = Directory.GetFiles(@"D:\TestZip\SqlFile", "*.sql");
            var listFileNames = listFiles.Select(file => new FileInfo
            {
                Path = file, FileName = Path.GetFileNameWithoutExtension(file)
            }).ToList();

            listFileNames = listFileNames.OrderBy(o=>o.FileName).ToList();

            var databaseVersionRepository = new DatabaseVersionRepository();
            var data = databaseVersionRepository.FirstOrDefault();
            if (data != null && !string.IsNullOrEmpty(data.Version))
            {
                foreach (var item in listFileNames)
                {
                    if (CheckVersionToRun.CheckVersion(data.Version, item.FileName))
                    {
                        ExcuteSqlFile(item.Path);
                    }
                }
                
            }

            Log("Done");
            Console.ReadKey();
        }


        public static void ExcuteSqlFile(string pathFile)
        {
            var sqlConnectionString = ConfigurationManager.ConnectionStrings["TestMysql"].ConnectionString;

            string script = File.ReadAllText(pathFile);

            try
            {
                using (var sqlConnection = new MySqlConnection(sqlConnectionString))
                {
                    sqlConnection.Open();
                    using (var sqlComment = new MySqlCommand(script, sqlConnection))
                    {
                        sqlComment.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        public class FileInfo
        {
            public string Path { get; set; }
            public string FileName { get; set; }
        }

        public static void Log(string text)
        {
            Console.WriteLine("[{0}] - {1}",DateTime.Now,text);
        }
    }   
}
