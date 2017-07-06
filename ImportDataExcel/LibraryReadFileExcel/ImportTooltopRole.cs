using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace LibraryReadFileExcel
{
    public class ImportTooltopRole
    {
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
                IXLWorksheet workSheet = workBook.Worksheet(6);

                //Create a new DataTable.
                //DataTable dt = new DataTable();

                List<ExcelRow> dataRows = new List<ExcelRow>();
                //Loop through the Worksheet rows.
                var A = ""; var B = ""; var C = ""; var D = ""; var E = "";
                var F = ""; var G = ""; var H = ""; var I = "";

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
                            if (cell.Address.ToString().Contains("F"))
                            {
                                F = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("G"))
                            {
                                G = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("H"))
                            {
                                H = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("I"))
                            {
                                I = cell.Value.ToString();
                            }
                        }
                        firstRow = false;
                        dataRows.Add(new ExcelRow
                        {
                            Menu = B,
                            DocumentType = C,
                            KeyXml = RemoveAllSpace(D),
                            View = ChangeSpecial(E),
                            Process = ChangeSpecial(F),
                            Create = ChangeSpecial(G),
                            Delete = ChangeSpecial(H),
                            Update = ChangeSpecial(I)
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
                            if (cell.Address.ToString().Contains("F"))
                            {
                                F = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("G"))
                            {
                                G = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("H"))
                            {
                                H = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("I"))
                            {
                                I = cell.Value.ToString();
                            }
                        }
                        dataRows.Add(new ExcelRow
                        {
                            Menu = B,
                            DocumentType = C,
                            KeyXml = RemoveAllSpace(D),
                            View = ChangeSpecial(E),
                            Process = ChangeSpecial(F),
                            Create = ChangeSpecial(G),
                            Delete = ChangeSpecial(H),
                            Update = ChangeSpecial(I)
                        });
                    }
                }
                #endregion

                File.WriteAllText(PathFileExport, String.Empty);
                GenXML(dataRows);
                return true;
            }
        }

        public static void GenXML(List<ExcelRow> dataRows)
        {
            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                for (int i = 0; i < dataRows.Count; i++)
                {
                    if (i > 4)
                    {
                        stream.WriteLine("<" + dataRows[i].KeyXml + ">");
                        stream.WriteLine("    <item value=\"1\"> <![CDATA[<div style=\"text-align:left\">" + dataRows[i].View + "1</div>]]></item>");
                        stream.WriteLine("    <item value=\"2\"><![CDATA[<div style=\"text-align:left\">" + dataRows[i].Process + "2</div>]]></item>");
                        stream.WriteLine("    <item value=\"3\"><![CDATA[<div style=\"text-align:left\">" + dataRows[i].Create + "3</div>]]></item>");
                        stream.WriteLine("    <item value=\"4\"><![CDATA[<div style=\"text-align:left\">" + dataRows[i].Delete + "4</div>]]></item>");
                        stream.WriteLine("    <item value=\"5\"><![CDATA[<div style=\"text-align:left\">" + dataRows[i].Update + "5</div>]]></item>");
                        stream.WriteLine("</" + dataRows[i].KeyXml + ">");
                        stream.WriteLine(" ");
                    }
                }
            }
        }
        public class ExcelRow
        {
            public string Menu { get; set; }
            public string DocumentType { get; set; }
            public string KeyXml { get; set; }

            public string View { get; set; }
            public string Process { get; set; }
            public string Create { get; set; }
            public string Delete { get; set; }
            public string Update { get; set; }
        }

        public static string RemoveAllSpace(string str)
        {
            return Regex.Replace(str, @"\s+", "");
        }

        public static string ChangeSpecial(string str)
        {
            return Regex.Replace(str, "\n", "</br>");
        }
    }
}
