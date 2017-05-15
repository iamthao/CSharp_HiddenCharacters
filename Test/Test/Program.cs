using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        private static void Main(string[] args)
        {
            var list = new List<MyClass>()
            {
                new MyClass()
                {
                    Start = DateTime.Now.AddHours(-2),
                },
                new MyClass(){
                    Start = DateTime.Now.AddHours(-10),
                    End = DateTime.Now.AddHours(-2),
                },
            };

            var q = from myClass in list
                select new MyClassVo
                {
                    Start = myClass.StartNotNull,
                    End = myClass.EndNotNull,
                    TimeSpanStart = myClass.TimeSpanStart
                };

            Console.ReadLine();
        }
    

        public class MyClass
        {
            public DateTime? Start { get; set; }
            public DateTime? End { get; set; }

            public DateTime Now
            {
                get { return DateTime.Now; }
            }
            public DateTime StartNotNull
            {
                get
                {
                    if (Start != null)
                    {
                        return Start.GetValueOrDefault(); 
                    }
                    return DateTime.Now;
                }
            }
            public DateTime EndNotNull
            {
                get
                {
                    if (End != null)
                    {
                        return End.GetValueOrDefault(); 
                    }
                    return DateTime.Now;
                }
            }

            public double TimeSpanStart
            {
                get
                {
                    DateTime epoch = new DateTime(2010, 1, 1, 0, 0, 0, 0).ToLocalTime();
                    TimeSpan span = (StartNotNull - epoch);
                    return (double)Convert.ToDouble(span.TotalSeconds);
                }
            }
        }

        public class MyClassVo
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public TimeSpan Duration { get; set; }
            public double TimeSpanStart { get; set; }
        }
    }
}
