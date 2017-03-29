using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryFunction
{
   public class GetNumberFromString
    {
       public static int GetNumberFromStr(string input)
       {
           return Convert.ToInt32(Regex.Replace(input, "[^0-9]+", string.Empty));
       }
    }
}
