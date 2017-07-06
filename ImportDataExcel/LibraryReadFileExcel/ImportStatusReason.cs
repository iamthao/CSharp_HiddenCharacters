using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace LibraryReadFileExcel
{
    public class ImportStatusReason
    {
        public static int CreateById = 1;
        public static int LastUserId = 1;
        public static string LastTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        public static string CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        public static string LastModified = "1";

        public static string PathFileExcel = "";
        public static string PathFileExport = "";

        public static ExcelRow ListRole = new ExcelRow();
        public static bool RunAction(string inputStr, string outputStr)
        {
            PathFileExcel = inputStr;
            PathFileExport = outputStr;
            return ReadFileExcel();
        }

        public static bool ReadFileExcel()
        {
            using (XLWorkbook workBook = new XLWorkbook(PathFileExcel))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(7);

                //Create a new DataTable.
                //DataTable dt = new DataTable();

                List<ExcelRow> dataRows = new List<ExcelRow>();
                //Loop through the Worksheet rows.
                var A = ""; var B = ""; var C = ""; var D = ""; var E = "";

                bool firstRow = true;
                #region
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            if (cell.Address.ToString().Contains("A"))
                            {
                                A = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("B"))
                            {
                                B = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("C"))
                            {
                                C = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("D"))
                            {
                                D = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("E"))
                            {
                                E = cell.Value.ToString();
                            }

                        }
                        firstRow = false;
                        dataRows.Add(new ExcelRow
                        {
                            Id = A,
                            Task = B,
                            Summary = C,
                            Category = D,
                            Description = E,
                        });
                    }
                    else
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            if (cell.Address.ToString().Contains("A"))
                            {
                                A = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("B"))
                            {
                                B = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("C"))
                            {
                                C = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("D"))
                            {
                                D = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("E"))
                            {
                                E = cell.Value.ToString();
                            }
                        }
                        dataRows.Add(new ExcelRow
                        {
                            Id = A,
                            Task = B,
                            Summary = C,
                            Category = D,
                            Description = E,
                        });
                    }
                }
                #endregion

                //var listFull = dataRows;
                return GenData(dataRows);
            }
        }

        public static bool GenData(List<ExcelRow> listExcelRows)
        {
            File.WriteAllText(PathFileExport, String.Empty);
            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                var a = "INSERT INTO `statusreason` (`Id`,`Summary`,`Category`,`Description`,`CreatedById`,`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`,`IsDefault`)VALUES";
                stream.WriteLine(a);
                for (int i = 0; i < listExcelRows.Count; i++)
                {
                    if (i > 0)
                    {
                        var id = Convert.ToInt32(listExcelRows[i].Id);
                        stream.WriteLine(CreateStringInsert(id, listExcelRows[i].Summary, listExcelRows[i].Category, listExcelRows[i].Description));
                    }
                }

                stream.WriteLine("");
            }
            return true;
        }

        public static string CreateStringInsert(int id, string summary, string category, string description)
        {
            return "('" + id + "', '" + summary + "','" + category + "','" + description + "','" + CreateById + "','" + LastUserId + "','" + LastTime + "','" + CreatedOn + "','" + LastModified + "',1),";
        }

        public class ExcelRow
        {
            public string Id { get; set; }
            public string Task { get; set; }
            public string Summary { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
        }
    }
}
