using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
           
            SetUpTimer(new TimeSpan(16, 41, 00));
            Console.ReadLine();
        }
        private static System.Threading.Timer timer;
        private static void SetUpTimer(TimeSpan alertTime)
        {
            DateTime current = DateTime.Now;
            TimeSpan timeToGo = alertTime - current.TimeOfDay;
            if (timeToGo < TimeSpan.Zero)
            {
                return;//time already passed
            }
            timer = new System.Threading.Timer(x =>
            {
                SomeMethodRunsAt1600();
            }, null, timeToGo, Timeout.InfiniteTimeSpan);
        }

        private static void SomeMethodRunsAt1600()
        {
            var now = DateTime.Now;
            Console.WriteLine(now.ToString("MM/dd/yyyy HH:mm:ss"));

            SetUpTimer(new TimeSpan(now.Hour, now.Minute, now.Second + 15));
           
        }
    }
}
