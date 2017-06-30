using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateFile.Ultilities
{
    public class UpgradeVersion
    {
        public static string UpgradeVersionText(string verOld)
        {
            var verNew = "1.0.0.0";

            if (string.IsNullOrEmpty(verOld))
            {
                return verNew;
            }

            var arr = verOld.Split('.');
            if (arr.Count() == 4)
            {
                if (CheckIsNumber(arr[0]) && CheckIsNumber(arr[1]) && CheckIsNumber(arr[2]) && CheckIsNumber(arr[3]))
                {
                    var n1 = Convert.ToInt32(arr[0]);
                    var n2 = Convert.ToInt32(arr[1]);
                    var n3 = Convert.ToInt32(arr[2]);
                    var n4 = Convert.ToInt32(arr[3]);

                    if (n4 >= 99)
                    {
                        n4 = 0;
                        if (n3 >= 99)
                        {
                            n3 = 0;
                            if (n2 >= 99)
                            {
                                n2 = 0;
                                n1++;
                            }
                            else
                            {
                                n2++;
                            }
                        }
                        else
                        {
                            n3++;
                        }
                    }
                    else
                    {
                        n4++;
                    }
                    verNew = n1 + "." + n2 + "." + n3 + "." + n4;
                }
            }
            return verNew;
        }

        public static bool CheckIsNumber(string number)
        {
            int n;
            bool isNumeric = int.TryParse(number, out n);
            return isNumeric;
        }
    }
}
