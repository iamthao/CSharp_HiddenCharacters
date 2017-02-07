using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Utility;

namespace GanData
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Guid.NewGuid().ToString();
            var b = EncryptHelper.Base64Encode(a);
            var c = EncryptHelper.Encrypt(a, "6fyrda1a4139gc41");

            var str = "23:59";
            Console.WriteLine(CheckDate(DateTime.Now.ToShortDateString() +" "+ str));
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
    }
}
