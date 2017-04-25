using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CreateFile.GendataDefault
{
    public class MySqlDataBakup : IDisposable
    {
        private string _connectionString;
        private MySqlConnection _mySqlConnection;
        private MySqlCommand _mySqlCommand;
        private MySqlBackup _mySqlBackup;

        public MySqlDataBakup(string connectionString)
        {
            _connectionString = connectionString;
            _mySqlConnection = new MySqlConnection(connectionString);
            _mySqlCommand = new MySqlCommand();
            _mySqlBackup = new MySqlBackup(_mySqlCommand);

        }


        public bool IsConnected(out Exception exception)
        {
            try
            {
                _mySqlConnection.Open();
                exception = null;
                return _mySqlConnection.State == ConnectionState.Open;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public string BackupTable(string tableName)
        {
            _mySqlCommand.Connection = _mySqlConnection;
            _mySqlConnection.Open();
            _mySqlBackup.ExportInfo.ExcludeTables = new List<string> { tableName };
            _mySqlBackup.ExportInfo.ExportTableStructure = true;
            _mySqlBackup.ExportInfo.ExportRows = true;
            var result = _mySqlBackup.ExportToString();
            return result;
        }

        public void Dispose()
        {
            _connectionString = null;
            if (_mySqlBackup != null)
            {
                _mySqlBackup.Dispose();
            }
            if (_mySqlCommand != null)
            {
                _mySqlCommand.Dispose();
            }
            if (_mySqlConnection != null)
            {
                _mySqlConnection.Dispose();
            }
        }
    }
}
