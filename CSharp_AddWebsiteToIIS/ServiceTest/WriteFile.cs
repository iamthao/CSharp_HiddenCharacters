using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTest
{
    public class WriteFile
    {
        public static void WriteFileLog()
        {
            string dirpathLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            if (!Directory.Exists(dirpathLog))
            {
                Directory.CreateDirectory(dirpathLog);
            }

            var pathLog = Path.Combine(dirpathLog, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
            if (!File.Exists(pathLog))
            {
                File.Create(pathLog).Close();
            }

            using (StreamWriter stream = File.AppendText(pathLog))
            {
                stream.WriteLine(DateTime.Now);
            }
        }
    }
}
