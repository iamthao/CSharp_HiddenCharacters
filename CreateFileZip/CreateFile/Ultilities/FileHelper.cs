using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CreateFile.Ultilities
{
    public class FileHelper
    {
        public static void WriteFile(string path, string content)
        {
            File.WriteAllText(path, String.Empty);
            using (StreamWriter stream = File.AppendText(path))
            {
                stream.Write(content);
            }
        }

        public static void WriteFileInFolderLogFileTableDatabase(string fileName, string content)
        {
            var pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFileTableDatabase", fileName);
            File.WriteAllText(pathFile, String.Empty);
            using (StreamWriter stream = File.AppendText(pathFile))
            {
                stream.Write(content);
            }
        }

        public static string ReadFileInFolderLogFileTableDatabase(string fileName)
        {
            var pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFileTableDatabase", fileName);
            if (File.Exists(pathFile))
            {
                return File.ReadAllText(pathFile);
            }
            return "";
        }
    }

}
