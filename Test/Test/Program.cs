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
            var list = new List<Test1>()
            {
                new Test1()
                {
                    Name = "Test 1",
                    Age = 1
                },
                new Test1(){
                     Name = "Test 2",
                    Age = 2
                },
            };


            var q = (from myClass in list
                     select new Test1
                {
                    Name = myClass.Name,
                    Age = myClass.Age,                
                }).ToList();
            var b = 1;
            var a = b;
            b = 2;

            q[0].Age = 3;

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

        public class  Test1
        {
            public string Name { get; set; }
            public int  Age { get; set; }
        }
    }
}
