using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Utility;
using System.IO;
using System.Text.RegularExpressions;

namespace GanData
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = Guid.NewGuid().ToString();
            //var b = EncryptHelper.Base64Encode(a);
            //var c = EncryptHelper.Encrypt(a, "6fyrda1a4139gc41");

            //var str = "23:59";
            //Console.WriteLine(CheckDate(DateTime.Now.ToShortDateString() +" "+ str));

            string filePath = @"D:\logtest.txt";
            var path = System.IO.Path.GetDirectoryName(filePath);
            var newName = path + "logtestTemp.txt";

            if (File.Exists(newName))
            {
                File.Delete(newName);
            }
            System.IO.File.Copy(filePath,  newName);

            //string[] lines = File.ReadAllLines(filePath);
            //for (int i = 0; i < lines.Length; i++)
            //{
            //    lines[i] = lines[i].Replace("vm.AssessmentName = null;", "vm.AssessmentName = null;thao");
            //}

            //File.WriteAllLines(filePath, lines);
            //using (StreamWriter stream = File.AppendText(filePath))
            //{
            //    string[] lines = File.ReadAllLines(filePath);
            //    for (int i = 0; i < lines.Length; i++)
            //    {
            //        lines[i] = lines[i].Replace("vm.AssessmentName = null;", "vm.AssessmentName = null;");
            //    }

            //    File.WriteAllLines(filePath, lines);
            //    stream.Close();
            //}

            var r = new Random();
            var myValues = new List<int>{}; // Will work with array or list
            var time1 = Convert.ToDateTime("2017-03-23 16:29:46");
            var time2 = Convert.ToDateTime("2017-03-23 18:28:40");
            TimeSpan span = time2 - time1;
            double totalMinutes = span.TotalMinutes;

            var a =  Convert.ToInt32(Regex.Replace("Field01", "[^0-9]+", string.Empty));
            //for (int i = 0; i <= 4; i++)
            //{
            //    myValues.Add(i);
            //}

            //var b = RandomListInt(myValues,6).FirstOrDefault();

            //

            Console.WriteLine(TryParseIntFromStr("1we3"));
            Console.ReadKey();
        }

        private static  bool ValidateDate(string date)
        {
            var provider = CultureInfo.InvariantCulture;
            try
            {
                var valDate = DateTime.ParseExact(date, "MM/dd/yyyy", null);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private static bool CheckDate(String date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date, new CultureInfo("en-US"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static List<int> RandomListInt(List<int> listInt, int ranger)
        {
            if (listInt.Count == 0)
            {
                return new List<int>();
            }
            var random = new Random();
            var randomValues = Enumerable.Range(0, ranger)
               .Select(e => listInt[random.Next(listInt.Count)]).ToList();
            return randomValues;
        }

        public static int? TryParseIntFromStr(string input)
        {
            int valInt;
            if (int.TryParse(input, out valInt))
            {
                return valInt;
            }
            return null;
        }
    }
}
