using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFunction
{
    public class ConvertStringToInt
    {
        public static int TryParseIntFromStr(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            int valInt;
            if (int.TryParse(input, out valInt))
            {
                return valInt;
            }
            return 0;
        }
    }
}
