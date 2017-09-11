using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcuteSqlFile
{
    public static class CheckVersionToRun
    {
        public static bool CheckVersion(string currentVersion, string versionToCheck)
        {
            var arrCurrent = Convert.ToInt32(currentVersion.Replace(".",""));
            var arrCheck = Convert.ToInt32(versionToCheck.Replace(".", ""));

            if (arrCurrent < arrCheck)
            {
                return true;
            }

            return false;
        }

      
    }
}
