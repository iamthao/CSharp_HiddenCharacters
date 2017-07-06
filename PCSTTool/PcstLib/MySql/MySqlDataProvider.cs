using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PcstLib.MySql
{
    public class MySqlDataProvider:IDisposable
    {
        private string _connectionString;
        

        public MySqlDataProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetDataTable(string commentText)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                using (var command = new MySqlCommand(commentText, connection))
                {
                    connection.Open();
                    using (var reder = command.ExecuteReader())
                    {
                        //Create datatable to hold schema and data seperately
                        //Get schema of our actual table
                        var result = reder.GetSchemaTable();
                        var dt = new DataTable();
                        if (result != null)
                            if (result.Rows.Count > 0)
                                for (int i = 0; i < result.Rows.Count; i++)
                                {
                                    var col = new DataColumn(result.Rows[i]["ColumnName"].ToString(), (Type)result.Rows[i]["DataType"]);
                                    col.AllowDBNull = true;
                                    col.Unique = false;
                                    col.AutoIncrement = false;
                                    dt.Columns.Add(col);
                                }

                        while (reder.Read())
                        {
                            var row = dt.NewRow();
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                row[i] = reder[i];
                            }
                            dt.Rows.Add(row);
                        }
                        return dt;
                    }
                }
            }
        }
        public int GetCount(string commentText)
        {
            var result = 0;
            using (var connection = new MySqlConnection(_connectionString))
            {
                using (var command = new MySqlCommand(commentText, connection))
                {
                    connection.Open();
                    var obj = command.ExecuteScalar();
                    result = (int)(Int64)obj;
                }
            }
            return result;
        }

        public void Dispose()
        {
            _connectionString = null;
        }
    }
}
