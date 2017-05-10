using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFunction
{
    class StringIsBool
    {
        public bool? StrIsBool(string valStr)
        {
            if (string.IsNullOrEmpty(valStr))
            {
                return null;
            }
            bool valBool;
            if (bool.TryParse(valStr, out valBool))
            {
                return valBool;
            }

            return null;
        }
    }
}
