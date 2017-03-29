using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFunction
{
    public class StringIsNumber
    {
        public int? StrIsNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;

            int valInt;
            if (int.TryParse(input, out valInt))
            {
                return valInt;
            }
            return null;
        }
    }
}
