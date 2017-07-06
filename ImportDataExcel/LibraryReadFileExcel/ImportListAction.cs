using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Repository;

namespace LibraryReadFileExcel
{
    public class ImportListAction
    {
        public static int CreateById = 1;
        public static int LastUserId = 1;
        public static string LastTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        public static string CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        public static string LastModified = "1";


        public static List<int> ListIdMilestoneAdd = new List<int>();
        public static List<int> ListIdMilestoneUpdate = new List<int>();

        public static List<int> ListIdMilestoneStatusAdd = new List<int>();
        public static List<int> ListIdMilestoneStatusUpdate = new List<int>();

        public static List<int> ListIdTaskAdd = new List<int>();
        public static List<int> ListIdTaskUpdate = new List<int>();

        public static List<int> ListIdActionAdd = new List<int>();
        public static List<int> ListIdActionUpdate = new List<int>();

        public static List<TaskAction> ListTaskActionAdd = new List<TaskAction>();
        public static List<TaskAction> ListTaskActionUpdate = new List<TaskAction>();

        public static string PathFileExcel = "";
        public static string PathFileExport = "";

        public static void CleanAllList()
        {
            ListIdMilestoneAdd = new List<int>();
            ListIdMilestoneUpdate = new List<int>();

            ListIdMilestoneStatusAdd = new List<int>();
            ListIdMilestoneStatusUpdate = new List<int>();

            ListIdTaskAdd = new List<int>();
            ListIdTaskUpdate = new List<int>();

            ListIdActionAdd = new List<int>();
            ListIdActionUpdate = new List<int>();

            ListTaskActionAdd = new List<TaskAction>();
            ListTaskActionUpdate = new List<TaskAction>();
        }
        public static bool RunAction(string inputStr, string outputStr)
        {
            CleanAllList();
            PathFileExcel = inputStr;
            PathFileExport = outputStr;
            return ReadFileExcel();
        }

        public static bool ReadFileExcel()
        {
            using (XLWorkbook workBook = new XLWorkbook(PathFileExcel))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Create a new DataTable.
                //DataTable dt = new DataTable();

                List<ExcelRow> dataRows = new List<ExcelRow>();
                //Loop through the Worksheet rows.
                var A = ""; var B = ""; var C = ""; var D = ""; var E = "";
                var F = ""; var G = ""; var H = ""; var I = ""; var J = "";
                var K = ""; var L = ""; var M = ""; var N = ""; var O = "";
                var P = ""; var Q = ""; var R = "";

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
                            if (cell.Address.ToString().Contains("J"))
                            {
                                J = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("K"))
                            {
                                K = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("L"))
                            {
                                L = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("M"))
                            {
                                M = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("N"))
                            {
                                N = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("O"))
                            {
                                O = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("P"))
                            {
                                P = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("Q"))
                            {
                                Q = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("R"))
                            {
                                R = cell.Value.ToString();
                            }

                        }
                        firstRow = false;
                        dataRows.Add(new ExcelRow
                        {
                            IdMilestone = ReplaceString(A),
                            MilestoneName = ReplaceString(B),
                            IdMilestoneStatus = ReplaceString(C),
                            MilestoneStatusName = ReplaceString(D),
                            IdTask = ReplaceString(E),
                            TaskName = ReplaceString(F),
                            TaskNumber = ReplaceString(G),
                            Step = ReplaceString(H),
                            Type = ReplaceString(I),
                            IdAction = ReplaceString(J),
                            ActionName = ReplaceString(K),
                            ActionNumber = ReplaceString(L),
                            EventType = ReplaceString(M),
                            ExcuteType = ReplaceString(N),
                            RouteName = ReplaceString(O),
                            Descripttion = ReplaceString(P),
                            DocumentTypeKey = ReplaceString(Q),
                            OperationAction = ReplaceString(R),
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
                            if (cell.Address.ToString().Contains("J"))
                            {
                                J = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("K"))
                            {
                                K = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("L"))
                            {
                                L = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("M"))
                            {
                                M = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("N"))
                            {
                                N = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("O"))
                            {
                                O = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("P"))
                            {
                                P = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("Q"))
                            {
                                Q = cell.Value.ToString();
                            }
                            if (cell.Address.ToString().Contains("R"))
                            {
                                R = cell.Value.ToString();
                            }
                        }
                        dataRows.Add(new ExcelRow
                        {
                            IdMilestone = ReplaceString(A),
                            MilestoneName = ReplaceString(B),
                            IdMilestoneStatus = ReplaceString(C),
                            MilestoneStatusName = ReplaceString(D),
                            IdTask = ReplaceString(E),
                            TaskName = ReplaceString(F),
                            TaskNumber = ReplaceString(G),
                            Step = ReplaceString(H),
                            Type = ReplaceString(I),
                            IdAction = ReplaceString(J),
                            ActionName = ReplaceString(K),
                            ActionNumber = ReplaceString(L),
                            EventType = ReplaceString(M),
                            ExcuteType = ReplaceString(N),
                            RouteName = ReplaceString(O),
                            Descripttion = ReplaceString(P),
                            DocumentTypeKey = ReplaceString(Q),
                            OperationAction = ReplaceString(R),
                        });
                    }
                }
                #endregion
                dataRows.RemoveAt(0);

                File.WriteAllText(PathFileExport, String.Empty);

                GenScriptMilestone(dataRows);
                GenScriptMilestoneStatus(dataRows);
                GenScriptTask(dataRows);
                GenScriptAction(dataRows);
                GenScriptTaskAction(dataRows);

                return true;
            }
        }

        public class ExcelRow
        {
            public string IdMilestone { get; set; }
            public string MilestoneName { get; set; }

            public string IdMilestoneStatus { get; set; }
            public string MilestoneStatusName { get; set; }

            public string IdTask { get; set; }
            public string TaskName { get; set; }
            public string TaskNumber { get; set; }
            public string Step { get; set; }
            public string Type { get; set; }

            public string IdAction { get; set; }
            public string ActionName { get; set; }
            public string ActionNumber { get; set; }
            public string EventType { get; set; }
            public string ExcuteType { get; set; }
            public string RouteName { get; set; }
            public string Descripttion { get; set; }

            public string DocumentTypeKey { get; set; }
            public string OperationAction { get; set; }
        }
        public class TaskAction
        {
            public string IdTask { get; set; }
            public string IdAction { get; set; }
        }

        public static string ReplaceString(string test)
        {
            return test.Replace("'", "''");
        }
        //Gen script
        public static bool GenScriptMilestone(List<ExcelRow> listExcelRows)
        {
            var milestoneRepository = new MilestoneRepository();
            var id = 0;

            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                foreach (var item in listExcelRows)
                {
                    if (!string.IsNullOrEmpty(item.IdMilestone) && !string.IsNullOrEmpty(item.MilestoneName))
                    {
                        id = Convert.ToInt32(item.IdMilestone);
                        var data = milestoneRepository.GetById(id);

                        if (data == null)
                        {
                            if (!ListIdMilestoneAdd.Contains(id))
                            {
                                ListIdMilestoneAdd.Add(id);
                                stream.WriteLine(
                                    "INSERT INTO `milestone`(`Id`,`Name`,`CreatedById`,`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`) " +
                                    "VALUES ({0},'{1}',{2},{3},'{4}','{5}','{6}');",
                                    item.IdMilestone, item.MilestoneName, CreateById, LastUserId, LastTime, CreatedOn,
                                    LastModified);
                            }
                        }
                        else
                        {
                            if (!ListIdMilestoneUpdate.Contains(id))
                            {
                                ListIdMilestoneUpdate.Add(id);
                                stream.WriteLine("UPDATE `milestone` SET `Name` = '{0}' WHERE `Id` = {1};",
                                    item.MilestoneName, id);
                            }
                        }
                    }
                }
                stream.WriteLine();
                return true;
            }
        }

        public static bool GenScriptMilestoneStatus(List<ExcelRow> listExcelRows)
        {
            var milestoneStatusRepository = new MilestoneStatusRepository();
            var id = 0;

            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                foreach (var item in listExcelRows)
                {
                    if (!string.IsNullOrEmpty(item.IdMilestone) && !string.IsNullOrEmpty(item.MilestoneName)
                        && !string.IsNullOrEmpty(item.IdMilestoneStatus) && !string.IsNullOrEmpty(item.MilestoneStatusName))
                    {
                        id = Convert.ToInt32(item.IdMilestoneStatus);
                        var data = milestoneStatusRepository.GetById(id);
                        if (data == null)
                        {
                            if (!ListIdMilestoneStatusAdd.Contains(id))
                            {
                                ListIdMilestoneStatusAdd.Add(id);
                                stream.WriteLine(
                                    "INSERT INTO `milestonestatus` (`Id`,`MilestoneId`,`Name`,`CreatedById`," +
                                    "`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`) " +
                                    "VALUES ({0},{1},'{2}',{3},{4},'{5}','{6}','{7}');",
                                    item.IdMilestoneStatus, item.IdMilestone, item.MilestoneStatusName, CreateById,
                                    LastUserId, LastTime, CreatedOn, LastModified);
                            }
                        }
                        else
                        {
                            if (!ListIdMilestoneStatusUpdate.Contains(id))
                            {
                                ListIdMilestoneStatusUpdate.Add(id);
                                stream.WriteLine(
                                    "UPDATE `milestonestatus` SET `MilestoneId` = {0},`Name` = '{1}' WHERE `Id` = {2};",
                                    item.IdMilestone, item.MilestoneStatusName, id);
                            }
                        }
                    }
                }
                stream.WriteLine();
                return true;
            }
        }

        public static bool GenScriptTask(List<ExcelRow> listExcelRows)
        {
            var libTaskRepository = new LibTaskRepository();
            var id = 0;

            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                foreach (var item in listExcelRows)
                {
                    if (!string.IsNullOrEmpty(item.IdTask) && !string.IsNullOrEmpty(item.TaskName)
                        && !string.IsNullOrEmpty(item.TaskNumber) && !string.IsNullOrEmpty(item.Step)
                        && !string.IsNullOrEmpty(item.Type))
                    {
                        id = Convert.ToInt32(item.IdTask);
                        var data = libTaskRepository.GetById(id);
                        if (data == null)
                        {
                            if (!ListIdTaskAdd.Contains(id))
                            {
                                ListIdTaskAdd.Add(id);
                                stream.WriteLine(
                                    "INSERT INTO `task`(`Id`,`Name`,`TaskNumber`,`MilestoneStatusId`,`Step`,`Type`," +
                                    "`CreatedById`,`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`)" +
                                    " VALUES ({0},'{1}','{2}',{3},{4},{5},{6},{7},'{8}','{9}','{10}');",
                                    item.IdTask, item.TaskName, item.TaskNumber, item.IdMilestoneStatus, item.Step,
                                    item.Type, CreateById, LastUserId, LastTime, CreatedOn, LastModified);

                            }
                        }
                        else
                        {
                            if (!ListIdTaskUpdate.Contains(id))
                            {
                                ListIdTaskUpdate.Add(id);
                                stream.WriteLine(
                                    "UPDATE `task` " +
                                    "SET `Name` = '{0}'," +
                                    "`TaskNumber` = '{1}'," +
                                    "`MilestoneStatusId` = {2}," +
                                    "`Step` = {3}," +
                                    "`Type` = {4} " +
                                    "WHERE `Id` = {5};",
                                     item.TaskName, item.TaskNumber, item.IdMilestoneStatus, item.Step, item.Type, id);
                            }
                        }
                    }
                }
                stream.WriteLine();
                return true;
            }
        }

        public static bool GenScriptAction(List<ExcelRow> listExcelRows)
        {
            var valueNull = 0;
            var libActionRepository = new LibActionRepository();
            var id = 0;

            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                foreach (var item in listExcelRows)
                {
                    if (!string.IsNullOrEmpty(item.IdAction) && !string.IsNullOrEmpty(item.ActionName)
                         && !string.IsNullOrEmpty(item.ActionNumber) && !string.IsNullOrEmpty(item.ExcuteType))
                    {
                        id = Convert.ToInt32(item.IdAction);
                        var data = libActionRepository.GetById(id);
                        if (data == null)
                        {
                            if (!ListIdActionAdd.Contains(id))
                            {
                                ListIdActionAdd.Add(id);
                                stream.WriteLine(
                                    "INSERT INTO `action`(`Id`,`Name`,`ActionNumber`,`ExecuteType`,`RouteName`,`Description`,`DocumentTypeKey`,`OperationAction`," +
                                    "`CreatedById`,`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`) " +
                                    "VALUES ({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');",
                                    item.IdAction, item.ActionName, item.ActionNumber, item.ExcuteType, item.RouteName, "",
                                    !string.IsNullOrEmpty(item.DocumentTypeKey) ? item.DocumentTypeKey : valueNull.ToString(),
                                     !string.IsNullOrEmpty(item.OperationAction) ? item.OperationAction : valueNull.ToString(),
                                    CreateById, LastUserId, LastTime, CreatedOn, LastModified);
                            }
                        }
                        else
                        {
                            if (!ListIdActionUpdate.Contains(id))
                            {
                                ListIdActionUpdate.Add(id);
                                stream.WriteLine(
                                    "UPDATE `action` SET " +
                                    "`Name` = '{0}'," +
                                    "`ActionNumber` = '{1}'," +
                                    "`ExecuteType` = {2}," +
                                    "`Description` = '{3}', " +
                                    "`DocumentTypeKey` = '{4}', " +
                                    "`OperationAction` = '{5}' " +
                                    "WHERE `Id` = {6};",
                                    item.ActionName, item.ActionNumber, item.ExcuteType, "",
                                    !string.IsNullOrEmpty(item.DocumentTypeKey) ? item.DocumentTypeKey : valueNull.ToString(),
                                    !string.IsNullOrEmpty(item.OperationAction) ? item.OperationAction : valueNull.ToString(),
                                    id);
                            }
                        }
                    }
                }
                stream.WriteLine();
                return true;
            }

        }

        public static bool GenScriptTaskAction(List<ExcelRow> listExcelRows)
        {
            var taskActionRepository = new TaskActionRepository();

            int taskId = 0;
            var actionId = 0;
            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                const int eventType = 1;
                foreach (var item in listExcelRows)
                {
                    if (!string.IsNullOrEmpty(item.IdTask) && !string.IsNullOrEmpty(item.IdAction) && !string.IsNullOrEmpty(item.EventType))
                    {
                        taskId = Convert.ToInt32(item.IdTask);
                        actionId = Convert.ToInt32(item.IdAction);

                        var data = taskActionRepository.GetTaskIdAndActionId(taskId, actionId);
                        if (data == null)
                        {
                            if (
                                ListTaskActionAdd.FirstOrDefault(
                                    o => o.IdTask == item.IdTask && o.IdAction == item.IdAction) == null)
                            {
                                ListTaskActionAdd.Add(new TaskAction { IdTask = item.IdTask, IdAction = item.IdAction });
                                stream.WriteLine(
                                    "INSERT INTO `taskaction` (`TaskId`,`ActionId`,`EventType`,`CreatedById`,`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`)" +
                                    " VALUES ({0},{1},{2},{3},{4},'{5}','{6}','{7}');",
                                    item.IdTask, item.IdAction, item.EventType, CreateById, LastUserId, LastTime,
                                    CreatedOn,
                                    LastModified);
                            }
                        }
                        else
                        {
                            if (
                                ListTaskActionUpdate.FirstOrDefault(
                                    o => o.IdTask == item.IdTask && o.IdAction == item.IdAction) == null)
                            {
                                ListTaskActionUpdate.Add(new TaskAction { IdTask = item.IdTask, IdAction = item.IdAction });
                                stream.WriteLine(
                                    "UPDATE `taskaction` SET " +
                                    "`TaskId` = {0}, " +
                                    "`ActionId` = {1}," +
                                    "`EventType` = {2} " +
                                    "WHERE `Id` = {3};",
                                    item.IdTask, item.IdAction, item.EventType, data.Id);
                            }
                        }
                    }
                }
                stream.WriteLine();
                return true;
            }

        }

        public static bool UpdateActionRouteNameActionProperty()
        {
            var libActionRepository = new LibActionRepository();
            using (StreamWriter stream = File.AppendText(PathFileExport))
            {
                var listAction = libActionRepository.GetAll();
                foreach (var item in listAction)
                {

                    stream.WriteLine(
                        "UPDATE `action` SET " +
                        "`RouteName` = '{0}'," +
                        "`ActionProperty` = '{1}'" +
                        "WHERE `Id` = {2};",
                        item.RouteName, item.ActionProperty, item.Id);


                }
                stream.WriteLine();
                return true;
            }

        }

        //public static bool UpdateDocumentTypeAndOperationAction(List<ExcelRow> listExcelRows)
        //{
        //    var actionRepository = new LibActionRepository();

        //    int taskId = 0;
        //    var actionId = 0;
        //    using (StreamWriter stream = File.AppendText(PathFileExport))
        //    {
        //        const int eventType = 1;
        //        foreach (var item in listExcelRows)
        //        {
        //            if (!string.IsNullOrEmpty(item.IdTask) && !string.IsNullOrEmpty(item.IdAction) && !string.IsNullOrEmpty(item.EventType))
        //            {
        //                taskId = Convert.ToInt32(item.IdTask);
        //                actionId = Convert.ToInt32(item.IdAction);

        //                var data = taskActionRepository.GetTaskIdAndActionId(taskId, actionId);
        //                if (data == null)
        //                {
        //                    if (
        //                        ListTaskActionAdd.FirstOrDefault(
        //                            o => o.IdTask == item.IdTask && o.IdAction == item.IdAction) == null)
        //                    {
        //                        ListTaskActionAdd.Add(new TaskAction { IdTask = item.IdTask, IdAction = item.IdAction });
        //                        stream.WriteLine(
        //                            "INSERT INTO `taskaction` (`TaskId`,`ActionId`,`EventType`,`CreatedById`,`LastUserId`,`LastTime`,`CreatedOn`,`LastModified`)" +
        //                            " VALUES ({0},{1},{2},{3},{4},'{5}','{6}','{7}');",
        //                            item.IdTask, item.IdAction, item.EventType, CreateById, LastUserId, LastTime,
        //                            CreatedOn,
        //                            LastModified);
        //                    }
        //                }
        //                else
        //                {
        //                    if (
        //                        ListTaskActionUpdate.FirstOrDefault(
        //                            o => o.IdTask == item.IdTask && o.IdAction == item.IdAction) == null)
        //                    {
        //                        ListTaskActionUpdate.Add(new TaskAction { IdTask = item.IdTask, IdAction = item.IdAction });
        //                        stream.WriteLine(
        //                            "UPDATE `taskaction` SET " +
        //                            "`TaskId` = {0}, " +
        //                            "`ActionId` = {1}," +
        //                            "`EventType` = {2} " +
        //                            "WHERE `Id` = {3};",
        //                            item.IdTask, item.IdAction, item.EventType, data.Id);
        //                    }
        //                }
        //            }
        //        }
        //        stream.WriteLine();
        //        return true;
        //    }
        //}
    }
}
