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
            var createDate = DateTime.UtcNow.ToString("MMM dd,yyyy");
            Console.WriteLine(createDate);
            Console.ReadLine();
        }
    }
}
