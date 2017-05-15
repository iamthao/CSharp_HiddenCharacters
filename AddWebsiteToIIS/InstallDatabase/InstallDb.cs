using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace InstallDatabase
{
    public class InstallDb
    {
        public static void RunSqlFile(string pathFileAdmin, string pathFileUser)
        {
            var file = new FileInfo(pathFileAdmin);
            var scriptAdmin = file.OpenText().ReadToEnd();
            var a = ExcuteMysql(scriptAdmin);

            //create user
            var fileUser = new FileInfo(pathFileUser);
            var scriptUser = fileUser.OpenText().ReadToEnd();
            var b = ExcuteMysql(scriptUser);
        }

        private static int ExcuteMysql(string sql)
        {
            var _connectionStr = "server=localhost;port=3306;database=test;uid=root;password=root";
            MySqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new MySqlConnection(_connectionStr);
                sqlConnection.Open();
                int result;
                using (var sqlComment = new MySqlCommand(sql, sqlConnection))
                {
                    result = sqlComment.ExecuteNonQuery();
                }
                return result;
            }
            catch (Exception ex)
            {
                
                return 0;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }
    }
}
