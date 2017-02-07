using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateDataDefaulPcst
{
    public static class GenerateScriptHelper
    {
        public static string GetScript(this DataTable table, string script, int totalCol)
        {
            var result = string.Empty;
            foreach (DataRow row in table.Rows)
            {
                var resultRow = script;
                for (int i = 0; i < totalCol; i++)
                {
                    resultRow = resultRow.Replace("{" + i + "}", "'" + row[i].ToString().Replace("'", "''") + "'");
                }
                result += resultRow + ",";
            }
            result = result.TrimEnd(',') + ";";
            return result;
        }

        public static void SaveSqliteDb(string script, string filePath)
        {
            var connectionString = "data source=" + filePath;
            using (var sqlite = new SQLiteConnection(connectionString))
            {
                using (var cmd = new SQLiteCommand(sqlite))
                {
                    sqlite.Open();
                    cmd.CommandText = script;
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
