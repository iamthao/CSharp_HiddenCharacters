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
    public class ImportRoleDefault
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
                IXLWorksheet workSheet = workBook.Worksheet(4);

                //Create a new DataTable.
                //DataTable dt = new DataTable();

                List<ExcelRow> dataRows = new List<ExcelRow>();
                //Loop through the Worksheet rows.
                var A = ""; var B = ""; var C = ""; var D = ""; var E = "";
                var F = ""; var G = ""; var H = ""; var I = ""; var J = "";
                var K = ""; var L = ""; var M = ""; var N = ""; var O = "";
                var P = ""; var Q = ""; var R = ""; var S = ""; var T = "";
                var U = ""; var V = ""; var W = ""; var X = ""; var Y = ""; var Z = "";

                var AA = ""; var AB = ""; var AC = ""; var AD = ""; var AE = "";
                var AF = ""; var AG = ""; var AH = ""; var AI = ""; var AJ = "";
                var AK = ""; var AL = ""; var AM = ""; var AN = ""; var AO = "";
                var AP = ""; var AQ = ""; var AR = ""; var AS = ""; var AT = "";
                var AU = ""; var AV = ""; var AW = ""; var AX = ""; var AY = ""; var AZ = "";

                var BA = ""; var BB = "";


                bool firstRow = true;
                #region
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            if (RemoveNumberInString(cell.Address.ToString()) == "A")
                            {
                                A = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "B")
                            {
                                B = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "C")
                            {
                                C = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "D")
                            {
                                D = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "E")
                            {
                                E = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "F")
                            {
                                F = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "G")
                            {
                                G = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "H")
                            {
                                H = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "I")
                            {
                                I = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "J")
                            {
                                J = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "K")
                            {
                                K = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "L")
                            {
                                L = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "M")
                            {
                                M = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "N")
                            {
                                N = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "O")
                            {
                                O = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "P")
                            {
                                P = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "Q")
                            {
                                Q = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "R")
                            {
                                R = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "S")
                            {
                                S = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "T")
                            {
                                T = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "U")
                            {
                                U = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "V")
                            {
                                V = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "W")
                            {
                                W = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "X")
                            {
                                X = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "Y")
                            {
                                Y = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "Z")
                            {
                                Z = cell.Value.ToString();
                            }

                            if (RemoveNumberInString(cell.Address.ToString()) == "AA")
                            {
                                AA = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AB")
                            {
                                AB = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AC")
                            {
                                AC = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AD")
                            {
                                AD = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AE")
                            {
                                AE = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AF")
                            {
                                AF = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AG")
                            {
                                AG = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AH")
                            {
                                AH = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AI")
                            {
                                AI = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AJ")
                            {
                                AJ = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AK")
                            {
                                AK = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AL")
                            {
                                AL = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AM")
                            {
                                AM = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AN")
                            {
                                AN = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AO")
                            {
                                AO = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AP")
                            {
                                AP = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AQ")
                            {
                                AQ = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AR")
                            {
                                AR = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AS")
                            {
                                AS = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AT")
                            {
                                AT = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AU")
                            {
                                AU = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AV")
                            {
                                AV = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AW")
                            {
                                AW = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AX")
                            {
                                AX = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AY")
                            {
                                AY = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AZ")
                            {
                                AZ = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "BA")
                            {
                                BA = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "BB")
                            {
                                BB = cell.Value.ToString();
                            }
                        }
                        firstRow = false;
                        dataRows.Add(new ExcelRow
                        {
                            Menu = ReplaceString(B),
                            DocumentTypeId = ReplaceString(C),
                            DocumentTypeName = ReplaceString(D),

                            AdminView = ReplaceString(E),
                            AdminProcess = ReplaceString(F),
                            AdminCreate = ReplaceString(G),
                            AdminDelete = ReplaceString(H),
                            AdminUpdate = ReplaceString(I),

                            RequestProcessorView = ReplaceString(J),
                            RequestProcessorProcess = ReplaceString(K),
                            RequestProcessorCreate = ReplaceString(L),
                            RequestProcessorDelete = ReplaceString(M),
                            RequestProcessorUpdate = ReplaceString(N),

                            SchedulerView = ReplaceString(O),
                            SchedulerProcess = ReplaceString(P),
                            SchedulerCreate = ReplaceString(Q),
                            SchedulerDelete = ReplaceString(R),
                            SchedulerUpdate = ReplaceString(S),

                            AssessorView = ReplaceString(T),
                            AssessorProcess = ReplaceString(U),
                            AssessorCreate = ReplaceString(V),
                            AssessorDelete = ReplaceString(W),
                            AssessorUpdate = ReplaceString(X),

                            RegionalManagerView = ReplaceString(Y),
                            RegionalManagerProcess = ReplaceString(Z),
                            RegionalManagerCreate = ReplaceString(AA),
                            RegionalManagerDelete = ReplaceString(AB),
                            RegionalManagerUpdate = ReplaceString(AC),

                            MailHandlerView = ReplaceString(AD),
                            MailHandlerProcess = ReplaceString(AE),
                            MailHandlerCreate = ReplaceString(AF),
                            MailHandlerDelete = ReplaceString(AG),
                            MailHandlerUpdate = ReplaceString(AH),

                            ProviderView = ReplaceString(AI),
                            ProviderProcess = ReplaceString(AJ),
                            ProviderCreate = ReplaceString(AK),
                            ProviderDelete = ReplaceString(AL),
                            ProviderUpdate = ReplaceString(AM),

                            CallCenterSupportView = ReplaceString(AN),
                            CallCenterSupportProcess = ReplaceString(AO),
                            CallCenterSupportCreate = ReplaceString(AP),
                            CallCenterSupportDelete = ReplaceString(AQ),
                            CallCenterSupportUpdate = ReplaceString(AR),

                            AppealStaffView = ReplaceString(AS),
                            AppealStaffProcess = ReplaceString(AT),
                            AppealStaffCreate = ReplaceString(AU),
                            AppealStaffDelete = ReplaceString(AV),
                            AppealStaffUpdate = ReplaceString(AW),

                            StateUserView = ReplaceString(AX),
                            StateUserProcess = ReplaceString(AY),
                            StateUserCreate = ReplaceString(AZ),
                            StateUserDelete = ReplaceString(BA),
                            StateUserUpdate = ReplaceString(BB),
                        });
                    }
                    else
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            if (RemoveNumberInString(cell.Address.ToString()) == "A")
                            {
                                A = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "B")
                            {
                                B = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "C")
                            {
                                C = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "D")
                            {
                                D = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "E")
                            {
                                E = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "F")
                            {
                                F = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "G")
                            {
                                G = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "H")
                            {
                                H = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "I")
                            {
                                I = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "J")
                            {
                                J = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "K")
                            {
                                K = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "L")
                            {
                                L = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "M")
                            {
                                M = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "N")
                            {
                                N = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "O")
                            {
                                O = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "P")
                            {
                                P = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "Q")
                            {
                                Q = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "R")
                            {
                                R = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "S")
                            {
                                S = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "T")
                            {
                                T = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "U")
                            {
                                U = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "V")
                            {
                                V = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "W")
                            {
                                W = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "X")
                            {
                                X = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "Y")
                            {
                                Y = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "Z")
                            {
                                Z = cell.Value.ToString();
                            }

                            if (RemoveNumberInString(cell.Address.ToString()) == "AA")
                            {
                                AA = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AB")
                            {
                                AB = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AC")
                            {
                                AC = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AD")
                            {
                                AD = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AE")
                            {
                                AE = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AF")
                            {
                                AF = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AG")
                            {
                                AG = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AH")
                            {
                                AH = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AI")
                            {
                                AI = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AJ")
                            {
                                AJ = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AK")
                            {
                                AK = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AL")
                            {
                                AL = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AM")
                            {
                                AM = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AN")
                            {
                                AN = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AO")
                            {
                                AO = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AP")
                            {
                                AP = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AQ")
                            {
                                AQ = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AR")
                            {
                                AR = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AS")
                            {
                                AS = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AT")
                            {
                                AT = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AU")
                            {
                                AU = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AV")
                            {
                                AV = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AW")
                            {
                                AW = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AX")
                            {
                                AX = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AY")
                            {
                                AY = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "AZ")
                            {
                                AZ = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "BA")
                            {
                                BA = cell.Value.ToString();
                            }
                            if (RemoveNumberInString(cell.Address.ToString()) == "BB")
                            {
                                BB = cell.Value.ToString();
                            }
                        }
                        dataRows.Add(new ExcelRow
                        {
                            Menu = ReplaceString(B),
                            DocumentTypeId = ReplaceString(C),
                            DocumentTypeName = ReplaceString(D),

                            AdminView = ReplaceString(E),
                            AdminProcess = ReplaceString(F),
                            AdminCreate = ReplaceString(G),
                            AdminDelete = ReplaceString(H),
                            AdminUpdate = ReplaceString(I),

                            RequestProcessorView = ReplaceString(J),
                            RequestProcessorProcess = ReplaceString(K),
                            RequestProcessorCreate = ReplaceString(L),
                            RequestProcessorDelete = ReplaceString(M),
                            RequestProcessorUpdate = ReplaceString(N),

                            SchedulerView = ReplaceString(O),
                            SchedulerProcess = ReplaceString(P),
                            SchedulerCreate = ReplaceString(Q),
                            SchedulerDelete = ReplaceString(R),
                            SchedulerUpdate = ReplaceString(S),

                            AssessorView = ReplaceString(T),
                            AssessorProcess = ReplaceString(U),
                            AssessorCreate = ReplaceString(V),
                            AssessorDelete = ReplaceString(W),
                            AssessorUpdate = ReplaceString(X),

                            RegionalManagerView = ReplaceString(Y),
                            RegionalManagerProcess = ReplaceString(Z),
                            RegionalManagerCreate = ReplaceString(AA),
                            RegionalManagerDelete = ReplaceString(AB),
                            RegionalManagerUpdate = ReplaceString(AC),

                            MailHandlerView = ReplaceString(AD),
                            MailHandlerProcess = ReplaceString(AE),
                            MailHandlerCreate = ReplaceString(AF),
                            MailHandlerDelete = ReplaceString(AG),
                            MailHandlerUpdate = ReplaceString(AH),

                            ProviderView = ReplaceString(AI),
                            ProviderProcess = ReplaceString(AJ),
                            ProviderCreate = ReplaceString(AK),
                            ProviderDelete = ReplaceString(AL),
                            ProviderUpdate = ReplaceString(AM),

                            CallCenterSupportView = ReplaceString(AN),
                            CallCenterSupportProcess = ReplaceString(AO),
                            CallCenterSupportCreate = ReplaceString(AP),
                            CallCenterSupportDelete = ReplaceString(AQ),
                            CallCenterSupportUpdate = ReplaceString(AR),

                            AppealStaffView = ReplaceString(AS),
                            AppealStaffProcess = ReplaceString(AT),
                            AppealStaffCreate = ReplaceString(AU),
                            AppealStaffDelete = ReplaceString(AV),
                            AppealStaffUpdate = ReplaceString(AW),

                            StateUserView = ReplaceString(AX),
                            StateUserProcess = ReplaceString(AY),
                            StateUserCreate = ReplaceString(AZ),
                            StateUserDelete = ReplaceString(BA),
                            StateUserUpdate = ReplaceString(BB),
                        });
                    }
                }
                #endregion

                //var listFull = dataRows;
                //list role
                ListRole = dataRows[1];

                File.WriteAllText(PathFileExport, String.Empty);

                GenDataAdministrator(dataRows);
                GenDataRequestProcessor(dataRows);
                GenDataScheduler(dataRows);
                GenDataAssessor(dataRows);
                GenDataRegionalManager(dataRows);
                GenDataMailHandler(dataRows);
                GenDataProvider(dataRows);
                GenDataCallCenterSupport(dataRows);
                GenDataAppealStaff(dataRows);
                GenDataStateUser(dataRows);

                return true;
            }
        }

        public static bool GenDataAdministrator(List<ExcelRow> listExcelRows)
        {
            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                stream.WriteLine("/*Administrator*/");

                var a = "INSERT INTO `libris`.`rolefunction` (`RoleId`,`SecurityOperationId`,`DocumentTypeId`,`CreatedById`," +
                    "`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`)VALUES";
                stream.WriteLine(a);
                for (int i = 0; i < listExcelRows.Count; i++)
                {
                    if (i > 4)
                    {
                        if (listExcelRows[i].AdminView == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.AdminView, (int)Operation.View, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].AdminProcess == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.AdminView, (int)Operation.Process, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].AdminCreate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.AdminView, (int)Operation.Create, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].AdminDelete == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.AdminView, (int)Operation.Delete, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].AdminUpdate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.AdminView, (int)Operation.Update, listExcelRows[i].DocumentTypeId));
                        }
                    }
                }

                stream.WriteLine("");
            }
            return true;
        }

        public static bool GenDataRequestProcessor(List<ExcelRow> listExcelRows)
        {
            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                stream.WriteLine("/*Request Processor*/");

                var a = "INSERT INTO `libris`.`rolefunction` (`RoleId`,`SecurityOperationId`,`DocumentTypeId`,`CreatedById`," +
                    "`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`)VALUES";
                stream.WriteLine(a);
                for (int i = 0; i < listExcelRows.Count; i++)
                {
                    if (i > 4)
                    {
                        if (listExcelRows[i].RequestProcessorView == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.RequestProcessorView, (int)Operation.View, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].RequestProcessorProcess == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.RequestProcessorView, (int)Operation.Process, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].RequestProcessorCreate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.RequestProcessorView, (int)Operation.Create, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].RequestProcessorDelete == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.RequestProcessorView, (int)Operation.Delete, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].RequestProcessorUpdate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.RequestProcessorView, (int)Operation.Update, listExcelRows[i].DocumentTypeId));
                        }
                    }
                }

                stream.WriteLine("");
            }
            return true;
        }

        public static bool GenDataScheduler(List<ExcelRow> listExcelRows)
        {
            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                stream.WriteLine("/*Scheduler*/");

                var a = "INSERT INTO `libris`.`rolefunction` (`RoleId`,`SecurityOperationId`,`DocumentTypeId`,`CreatedById`," +
                    "`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`)VALUES";
                stream.WriteLine(a);
                for (int i = 0; i < listExcelRows.Count; i++)
                {
                    if (i > 4)
                    {
                        if (listExcelRows[i].SchedulerView == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.SchedulerView, (int)Operation.View, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].SchedulerProcess == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.SchedulerView, (int)Operation.Process, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].SchedulerCreate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.SchedulerView, (int)Operation.Create, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].SchedulerDelete == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.SchedulerView, (int)Operation.Delete, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].SchedulerUpdate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.SchedulerView, (int)Operation.Update, listExcelRows[i].DocumentTypeId));
                        }
                    }
                }

                stream.WriteLine("");
            }
            return true;
        }

        public static bool GenDataAssessor(List<ExcelRow> listExcelRows)
        {
            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                stream.WriteLine("/*Assessor*/");

                var a = "INSERT INTO `libris`.`rolefunction` (`RoleId`,`SecurityOperationId`,`DocumentTypeId`,`CreatedById`," +
                    "`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`)VALUES";
                stream.WriteLine(a);
                for (int i = 0; i < listExcelRows.Count; i++)
                {
                    if (i > 4)
                    {
                        if (listExcelRows[i].AssessorView == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.AssessorView, (int)Operation.View, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].AssessorProcess == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.AssessorView, (int)Operation.Process, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].AssessorCreate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.AssessorView, (int)Operation.Create, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].AssessorDelete == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.AssessorView, (int)Operation.Delete, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].AssessorUpdate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.AssessorView, (int)Operation.Update, listExcelRows[i].DocumentTypeId));
                        }
                    }
                }

                stream.WriteLine("");
            }
            return true;
        }

        public static bool GenDataRegionalManager(List<ExcelRow> listExcelRows)
        {
            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                stream.WriteLine("/*Regional Manager*/");

                var a = "INSERT INTO `libris`.`rolefunction` (`RoleId`,`SecurityOperationId`,`DocumentTypeId`,`CreatedById`," +
                    "`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`)VALUES";
                stream.WriteLine(a);
                for (int i = 0; i < listExcelRows.Count; i++)
                {
                    if (i > 4)
                    {
                        if (listExcelRows[i].RegionalManagerView == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.RegionalManagerView, (int)Operation.View, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].RegionalManagerProcess == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.RegionalManagerView, (int)Operation.Process, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].RegionalManagerCreate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.RegionalManagerView, (int)Operation.Create, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].RegionalManagerDelete == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.RegionalManagerView, (int)Operation.Delete, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].RegionalManagerUpdate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.RegionalManagerView, (int)Operation.Update, listExcelRows[i].DocumentTypeId));
                        }
                    }
                }

                stream.WriteLine("");
            }
            return true;
        }

        public static bool GenDataMailHandler(List<ExcelRow> listExcelRows)
        {
            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                stream.WriteLine("/*Mail Handler*/");

                var a = "INSERT INTO `libris`.`rolefunction` (`RoleId`,`SecurityOperationId`,`DocumentTypeId`,`CreatedById`," +
                    "`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`)VALUES";
                stream.WriteLine(a);
                for (int i = 0; i < listExcelRows.Count; i++)
                {
                    if (i > 4)
                    {
                        if (listExcelRows[i].MailHandlerView == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.MailHandlerView, (int)Operation.View, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].MailHandlerProcess == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.MailHandlerView, (int)Operation.Process, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].MailHandlerCreate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.MailHandlerView, (int)Operation.Create, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].MailHandlerDelete == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.MailHandlerView, (int)Operation.Delete, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].MailHandlerUpdate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.MailHandlerView, (int)Operation.Update, listExcelRows[i].DocumentTypeId));
                        }
                    }
                }

                stream.WriteLine("");
            }
            return true;
        }

        public static bool GenDataProvider(List<ExcelRow> listExcelRows)
        {
            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                stream.WriteLine("/*Provider*/");

                var a = "INSERT INTO `libris`.`rolefunction` (`RoleId`,`SecurityOperationId`,`DocumentTypeId`,`CreatedById`," +
                    "`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`)VALUES";
                stream.WriteLine(a);
                for (int i = 0; i < listExcelRows.Count; i++)
                {
                    if (i > 4)
                    {
                        if (listExcelRows[i].ProviderView == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.ProviderView, (int)Operation.View, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].ProviderProcess == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.ProviderView, (int)Operation.Process, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].ProviderCreate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.ProviderView, (int)Operation.Create, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].ProviderDelete == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.ProviderView, (int)Operation.Delete, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].ProviderUpdate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.ProviderView, (int)Operation.Update, listExcelRows[i].DocumentTypeId));
                        }
                    }
                }

                stream.WriteLine("");
            }
            return true;
        }

        public static bool GenDataCallCenterSupport(List<ExcelRow> listExcelRows)
        {
            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                stream.WriteLine("/*Call Center Support*/");

                var a = "INSERT INTO `libris`.`rolefunction` (`RoleId`,`SecurityOperationId`,`DocumentTypeId`,`CreatedById`," +
                    "`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`)VALUES";
                stream.WriteLine(a);
                for (int i = 0; i < listExcelRows.Count; i++)
                {
                    if (i > 4)
                    {
                        if (listExcelRows[i].CallCenterSupportView == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.CallCenterSupportView, (int)Operation.View, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].CallCenterSupportProcess == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.CallCenterSupportView, (int)Operation.Process, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].CallCenterSupportCreate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.CallCenterSupportView, (int)Operation.Create, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].CallCenterSupportDelete == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.CallCenterSupportView, (int)Operation.Delete, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].CallCenterSupportUpdate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.CallCenterSupportView, (int)Operation.Update, listExcelRows[i].DocumentTypeId));
                        }
                    }
                }

                stream.WriteLine("");
            }
            return true;
        }

        public static bool GenDataAppealStaff(List<ExcelRow> listExcelRows)
        {
            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                stream.WriteLine("/*Appeal Staff*/");

                var a = "INSERT INTO `libris`.`rolefunction` (`RoleId`,`SecurityOperationId`,`DocumentTypeId`,`CreatedById`," +
                    "`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`)VALUES";
                stream.WriteLine(a);
                for (int i = 0; i < listExcelRows.Count; i++)
                {
                    if (i > 4)
                    {
                        if (listExcelRows[i].AppealStaffView == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.AppealStaffView, (int)Operation.View, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].AppealStaffProcess == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.AppealStaffView, (int)Operation.Process, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].AppealStaffCreate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.AppealStaffView, (int)Operation.Create, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].AppealStaffDelete == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.AppealStaffView, (int)Operation.Delete, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].AppealStaffUpdate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.AppealStaffView, (int)Operation.Update, listExcelRows[i].DocumentTypeId));
                        }
                    }
                }

                stream.WriteLine("");
            }
            return true;
        }

        public static bool GenDataStateUser(List<ExcelRow> listExcelRows)
        {
            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                stream.WriteLine("/*State User*/");

                var a = "INSERT INTO `libris`.`rolefunction` (`RoleId`,`SecurityOperationId`,`DocumentTypeId`,`CreatedById`," +
                    "`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`)VALUES";
                stream.WriteLine(a);
                for (int i = 0; i < listExcelRows.Count; i++)
                {
                    if (i > 4)
                    {
                        if (listExcelRows[i].StateUserView == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.StateUserView, (int)Operation.View, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].StateUserProcess == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.StateUserView, (int)Operation.Process, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].StateUserCreate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.StateUserView, (int)Operation.Create, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].StateUserDelete == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.StateUserView, (int)Operation.Delete, listExcelRows[i].DocumentTypeId));
                        }
                        if (listExcelRows[i].StateUserUpdate == "Yes")
                        {
                            stream.WriteLine(CreateStringInsert(ListRole.StateUserView, (int)Operation.Update, listExcelRows[i].DocumentTypeId));
                        }
                    }
                }

                stream.WriteLine("");
            }
            return true;
        }

        public class ExcelRow
        {
            public string Menu { get; set; } //B
            public string DocumentTypeId { get; set; } //C

            public string DocumentTypeName { get; set; } //D

            public string AdminView { get; set; }
            public string AdminProcess { get; set; }
            public string AdminCreate { get; set; }
            public string AdminDelete { get; set; }
            public string AdminUpdate { get; set; }

            public string RequestProcessorView { get; set; }
            public string RequestProcessorProcess { get; set; }
            public string RequestProcessorCreate { get; set; }
            public string RequestProcessorDelete { get; set; }
            public string RequestProcessorUpdate { get; set; }

            public string SchedulerView { get; set; }
            public string SchedulerProcess { get; set; }
            public string SchedulerCreate { get; set; }
            public string SchedulerDelete { get; set; }
            public string SchedulerUpdate { get; set; }

            public string AssessorView { get; set; }
            public string AssessorProcess { get; set; }
            public string AssessorCreate { get; set; }
            public string AssessorDelete { get; set; }
            public string AssessorUpdate { get; set; }

            public string RegionalManagerView { get; set; }
            public string RegionalManagerProcess { get; set; }
            public string RegionalManagerCreate { get; set; }
            public string RegionalManagerDelete { get; set; }
            public string RegionalManagerUpdate { get; set; }

            public string MailHandlerView { get; set; }
            public string MailHandlerProcess { get; set; }
            public string MailHandlerCreate { get; set; }
            public string MailHandlerDelete { get; set; }
            public string MailHandlerUpdate { get; set; }

            public string ProviderView { get; set; }
            public string ProviderProcess { get; set; }
            public string ProviderCreate { get; set; }
            public string ProviderDelete { get; set; }
            public string ProviderUpdate { get; set; }

            public string CallCenterSupportView { get; set; }
            public string CallCenterSupportProcess { get; set; }
            public string CallCenterSupportCreate { get; set; }
            public string CallCenterSupportDelete { get; set; }
            public string CallCenterSupportUpdate { get; set; }

            public string AppealStaffView { get; set; }
            public string AppealStaffProcess { get; set; }
            public string AppealStaffCreate { get; set; }
            public string AppealStaffDelete { get; set; }
            public string AppealStaffUpdate { get; set; }

            public string StateUserView { get; set; }
            public string StateUserProcess { get; set; }
            public string StateUserCreate { get; set; }
            public string StateUserDelete { get; set; }
            public string StateUserUpdate { get; set; }


        }

        public static string ReplaceString(string test)
        {
            return test.Replace("'", "''");
        }

        public static string RemoveNumberInString(string str)
        {
            return Regex.Replace(str, "[0-9]", "");
        }

        public static string CreateStringInsert(string roleId, int operationId, string documentId)
        {
            return "('" + roleId + "', '" + operationId + "','" + documentId + "','" + CreateById + "','" + LastUserId + "','" + LastTime + "','" + CreatedOn + "','" + LastModified + "'),";
        }

        public enum Operation
        {
            View = 1,
            Process = 2,
            Create = 3,
            Delete = 4,
            Update = 5
        }
    }
}
