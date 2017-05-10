using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFunction
{
    class Program
    {
        static void Main(string[] args)
        {

            var a = new Test
            {
                Index = 1,
                Name = "Thao"
            };

            //SetPropValueFromObject.SetPropValue(a, "Name","Test");
            Console.WriteLine(GetPropValueFromObject.GetPropValue(a, "Name"));
            Console.ReadLine();
        }


        public class  Test
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }
    }
}
