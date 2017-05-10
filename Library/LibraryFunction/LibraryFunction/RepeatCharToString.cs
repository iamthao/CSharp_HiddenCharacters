using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFunction
{
    public class RepeatCharToString
    {
        public static string RepeatCharToStr(string chr, int count)
        {
            return string.Concat(Enumerable.Repeat(chr, count));
        }
    }
}
