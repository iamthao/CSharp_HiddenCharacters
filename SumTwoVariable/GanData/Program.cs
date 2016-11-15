using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanData
{
    class Program
    {
        static void Main(string[] args)
        {
            ////var day = 1;
            ////var startClient = new DateTime(2016, 11, 09, 0, 0, 0);
            var endClient = new DateTime(2016, 11, 09, 23, 59, 59);

            ////var startDate = startClient.AddDays(1- day);

            var expiredTime = Math.Round((endClient - DateTime.UtcNow.AddMinutes(420)).TotalSeconds);
            Console.WriteLine(expiredTime);
            //if (configValue != null)
            //{
                var value = 1;//Convert.ToInt32(configValue.Value);
                expiredTime = expiredTime + (value - 1) * 86400;
            //}
                Console.WriteLine(expiredTime);
           
            Console.ReadKey();
        }
    }
}
