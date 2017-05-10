using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFunction
{
    class StringIsDateTime
    {
        public DateTime? StrIsDateTime(string valStr)
        {                     
            try
            {
                //var valDate = DateTime.ParseExact(valStr, "MM/dd/yyyy", provider);
                DateTime dt = DateTime.Parse(valStr, new CultureInfo("en-US"));
                return dt;
            }
            catch (FormatException)
            {
                return null;
            }
        }
    }
}
