using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFileCsv
{
    public class ReadCsv
    {
        private static List<int> _linstIndexColumn = new List<int> { 0, 1,2 };
        private static long _countColumn = 0;

        public static void ReadFileCsv(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                String line;
                var index = 0;
                var flag = false;//xac dinh dong dau tien
                while ((line = sr.ReadLine()) != null)
                {
                    index++;
                    if (!flag)
                    {
                        flag = true;                       
                        continue;
                    }

                    string[] lines = line.Split(',');
                    var result = "";

                    _countColumn = _linstIndexColumn.Count;

                    var isFirstColumn = true;
                    for (int i = 0; i < _countColumn; i++)
                    {
                        var no = _linstIndexColumn[i];
                        var dataColumn = lines[no];
                        if (isFirstColumn)
                        {
                            result += dataColumn;
                            isFirstColumn = false;
                        }
                        else
                        {
                            result += " - " + dataColumn;
                        }
                    }
                    Console.WriteLine(result);
                }
                
            }    
        }
    }
}
