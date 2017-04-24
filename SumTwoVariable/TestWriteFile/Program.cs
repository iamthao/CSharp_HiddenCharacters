using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mime;
using System.Reflection;

namespace TestWriteFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathIn = "D:\\ImportFile\\PCIA_ELG_PROD_20170324.txt";
            var list = new string[] { "1", "2", "3" };
            WriteFileLog(pathIn, list);

            Console.WriteLine("Completed.");
            Console.ReadKey();
        }

        public static void WriteFileLog(string pathIn, string[] listMess)
        {
            string dirpathLog = Directory.GetCurrentDirectory()+"\\logs\\";
            var fileName = Path.GetFileNameWithoutExtension(pathIn);
            var pathLog = Path.Combine(dirpathLog, fileName + ".log");
            if (!Directory.Exists(dirpathLog))
            {
                Directory.CreateDirectory(dirpathLog);
            }
            if (!File.Exists(pathLog))
            {
                File.Create(pathLog).Close();
            }                   
            using (StreamWriter stream = File.AppendText(pathLog))
            {
                if (listMess.Count() > 0)
                {
                    foreach (var item in listMess)
                    {
                      stream.WriteLine(item);
                    }
                }
                
            }

        }
    }
    
}
