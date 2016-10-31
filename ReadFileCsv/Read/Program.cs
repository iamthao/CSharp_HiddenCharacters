using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadFileCsv;

namespace Read
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadCsv.ReadFileCsv("D:\\TestCsv.csv");
            Console.ReadLine();
        }
    }
}
