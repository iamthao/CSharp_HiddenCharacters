using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HiddenCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"test
test
test\n\n"; // this is your input string
            string output = StripControlChars(input);
            Console.WriteLine(output);
            Console.ReadLine();
        }

        static public string StripControlChars(string s)
        {
            return Regex.Replace(s, @"[^\x20-\x7F]", "<br>");
        }
    }
}
