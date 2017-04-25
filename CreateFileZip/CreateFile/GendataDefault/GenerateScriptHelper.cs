﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateFile.GendataDefault
{
    public static class GenerateScriptHelper
    {
        public static string GetScript(this DataTable table, string script, int totalCol)
        {
            var result = string.Empty;
            foreach (DataRow row in table.Rows)
            {
                var result1 = "";
                var resultRow = script;
                for (int i = 0; i < totalCol; i++)
                {
                    var a = row[i];
                    if (string.IsNullOrEmpty(row[i].ToString()))
                    {
                        resultRow = resultRow.Replace("|" + i + "|", "NULL");
                    }
                    else
                    {
                        resultRow = resultRow.Replace("|" + i + "|", "'" + row[i].ToString().Replace("'", "''") + "'");
                    }

                    result1 += resultRow;
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
