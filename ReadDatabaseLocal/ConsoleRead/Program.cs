using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemBox.Spreadsheet;

namespace ConsoleRead
{
    class Program
    {
        static void Main(string[] args)
        {

            ReadExcel();
            Console.ReadKey();
        }

        public static void ReadExcel()
        {
            // If using Professional version, put your serial key below.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            ExcelFile ef = ExcelFile.Load("SimpleTemplate.xlsx");

            StringBuilder sb = new StringBuilder();

            // Iterate through all worksheets in an Excel workbook.
            foreach (ExcelWorksheet sheet in ef.Worksheets)
            {
                sb.AppendLine();
                sb.AppendFormat("{0} {1} {0}", new string('-', 25), sheet.Name);

                // Iterate through all rows in an Excel worksheet.
                foreach (ExcelRow row in sheet.Rows)
                {
                    sb.AppendLine();

                    // Iterate through all allocated cells in an Excel row.
                    foreach (ExcelCell cell in row.AllocatedCells)
                    {
                        if (cell.ValueType != CellValueType.Null)
                            sb.Append(string.Format("{0} [{1}]", cell.Value, cell.ValueType).PadRight(25));
                        else
                            sb.Append(new string(' ', 25));
                    }
                }
            }

            Console.WriteLine(sb.ToString());
        }

        public static void SaveExcel()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws = ef.Worksheets.Add("Hello World");

            ws.Cells[0, 0].Value = "English:";
            ws.Cells[0, 1].Value = "Hello";

            ws.Cells[1, 0].Value = "Russian:";
            // Using UNICODE string.
            ws.Cells[1, 1].Value = new string(new char[] { 'a', 'b', 'c' });

            ws.Cells[2, 0].Value = "Chinese:";
            // Using UNICODE string.
            ws.Cells[2, 1].Value = new string(new char[] { 'd', 'e', 'f' });

            ws.Cells[4, 0].Value = "In order to see Russian and Chinese characters you need to have appropriate fonts on your PC.";
            ws.Cells.GetSubrangeAbsolute(4, 0, 4, 7).Merged = true;

            ef.Save("Hello World.xls");
        }
    }
}
