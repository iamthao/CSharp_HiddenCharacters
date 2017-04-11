using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication
{
    class Functions
    {
        public static string RandomName(int n)
        {
            string Name = "";
            Random Random = new Random();
            int Num;
            while (Name.Length < n)
            {
                Num = Random.Next(1, 3);
                if (Num == 1)
                {
                    Num = Random.Next(65, 91);
                    Name = Name + Convert.ToChar(Num);
                }
                else
                {
                    Num = Random.Next(0, 10);
                    Name = Name + Num.ToString();
                }
            }
            return Name;
        }

        public static bool IsNumeric(string s)
        {
            int output;
            return int.TryParse(s, out output);
        }
    }
}
