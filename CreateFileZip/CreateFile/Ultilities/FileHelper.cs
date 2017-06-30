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
    }
}
