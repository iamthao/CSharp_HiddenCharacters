using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcstLib.Struct
{
    public static class Config
    {
        public static string PathData;
        public static string EncriptKey;
        public static string DataFile;
        static Config()
        {
            PathData = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datas");
            EncriptKey = @"!C@a#m$i%n^o&I*S(";
            DataFile = "data.xml";
        }
    }
}
