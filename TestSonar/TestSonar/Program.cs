using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace TestSonar
{
    public class Program
    {
        protected Program()
        {
        }

        static void Main(string[] args)
        {
            //var test =456;
            double a = 0.00000001;
            double b = 2.333;
            double c = 0.0;
            Console.WriteLine("double a = 0.0001 is {0}", NearlyEqual(a, 0));
            Console.WriteLine("double b = 2.333 is {0}", NearlyEqual(b, 0));
            Console.WriteLine("double c = 0.0 is {0}", NearlyEqual(c, 0));
            //GetById(1);
            Console.WriteLine("Success");
            Console.ReadKey();
        }
      

        public static void DoSomething(string obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(obj);
            }
            // ...
        }

        public static bool NearlyEqual(double f1, double f2)
        {
            if (Math.Abs(f1) < 0.0000001)
            {
                var a = Math.Abs(f1);
                Console.WriteLine(" Math.Abs(f1) = {0}", Math.Abs(f1));
            }
            // Equal if they are within 0.00001 of each other
            Console.WriteLine("double f1 = {0}, double f2 = {1}, abs = {2}", f1, f2, Math.Abs(f1 - f2));
            return Math.Abs(f1 - f2) < 0.0000001;
        }


        
    }
}
