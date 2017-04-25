﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace CreateFile.GendataDefault
{

    public static class GenerateDefaultData
    {
        private const string StrConnect = "Connect";
        private const string StrDisconnect = "Disconnect";
        private const string StrGenerate = "Generate";
        private const string StrCancel = "Generate";
        private static MySqlDataBakup _mySqlDataBakup;
        private static string _connectionString;
        private const int Take = 5000;
        private static int _skip;

        private static string _conn = "";

        private static string _saveTo = "";

        public static void ExcuteGenerate()
        {
            var startGenerate = true;
            string connectionStringKey = ConfigurationManager.AppSettings["ConnectionString"];
            if (string.IsNullOrEmpty(connectionStringKey))
            {
                startGenerate = false;
                Console.WriteLine("ConnectionString not found in App.config");
            }
            string saveToKey = ConfigurationManager.AppSettings["SaveTo"];
            if (string.IsNullOrEmpty(saveToKey))
            {
                startGenerate = false;
                Console.WriteLine("SaveTo not found in App.config");
            }

            if (startGenerate)
            {
                _conn = connectionStringKey;
                _saveTo = saveToKey;
                var start = DateTime.Now;
                Console.WriteLine( start.ToString("MM/dd/yyyy HH:mm:ss") + ": Start Generate" );
                ConnectDatabase();
                InitFileDb();
                Generate();
                var end = DateTime.Now;
                Console.WriteLine( end.ToString("MM/dd/yyyy HH:mm:ss")+ ": End Generate" );
                Console.WriteLine("Total Generate: " + (end - start).TotalSeconds + " s\n");
            }
           
        }

        private static void ConnectDatabase()
        {
            _mySqlDataBakup = new MySqlDataBakup(_conn);
            Exception ex;
            if (!_mySqlDataBakup.IsConnected(out ex))
            {

            }
            else
            {
                _connectionString = _conn;
            }

            if (_mySqlDataBakup != null)
            {
                _mySqlDataBakup.Dispose();
            }
        }
        private static void InitFileDb()
        {
            if (File.Exists(_saveTo))
            {
                File.Delete(_saveTo);
                File.Create(_saveTo).Close(); 
            }        
        }

        private static void Generate()
        {
            RunPrimaryLanguage();
            RunCounty();
            RunIcd();
            RunNpi();
            RunRoute();
            RunFrequency();
            RunSection();
            RunSectionQuestion();
            RunProviderAgency();
            RunProviderMpi();
        }

        #region
        private static void RunPrimaryLanguage()
        {        
            using (var mysqlProvider = new MySqlDataProvider(_connectionString))
            {
                string script = string.Empty, strScriptSqlite = string.Empty;
                DataTable table;
                var total = mysqlProvider.GetCount(ScriptMySqlHelper.TableLanguageCount);
                _skip = 0;
                if (total > Take)
                {
                    while (_skip < total)
                    {
                        script = string.Format(ScriptMySqlHelper.TableLanguage, _skip, Take);
                        table = mysqlProvider.GetDataTable(script);
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableLanguage, _saveTo);
                        strScriptSqlite = ScriptSqliteHelper.InsertLanguageSchedule + table.GetScript(ScriptSqliteHelper.InsertLanguageValue, 3);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableLanguage, _skip, total);

                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableLanguage, _saveTo);
                    strScriptSqlite = ScriptSqliteHelper.InsertLanguageSchedule + table.GetScript(ScriptSqliteHelper.InsertLanguageValue, 3);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                }

            }
        }

        private static void RunCounty()
        {           
            using (var mysqlProvider = new MySqlDataProvider(_connectionString))
            {
                string script, strScriptSqlite;
                DataTable table;
                var total = mysqlProvider.GetCount(ScriptMySqlHelper.TableCountyCount);
                _skip = 0;
                if (total > Take)
                {
                    while (_skip < total)
                    {
                        script = string.Format(ScriptMySqlHelper.TableCounty, _skip, Take);
                        table = mysqlProvider.GetDataTable(script);
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableCounty, _saveTo);
                        strScriptSqlite = ScriptSqliteHelper.InsertCountySchedule + table.GetScript(ScriptSqliteHelper.InsertCountyValue, 3);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableCounty, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableCounty, _saveTo);
                    strScriptSqlite = ScriptSqliteHelper.InsertCountySchedule + table.GetScript(ScriptSqliteHelper.InsertCountyValue, 3);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                }

            }
        }

        private static void RunIcd()
        {
            using (var mysqlProvider = new MySqlDataProvider(_connectionString))
            {
                string script, strScriptSqlite;
                DataTable table;
                var total = mysqlProvider.GetCount(ScriptMySqlHelper.TableIcdCount);
                _skip = 0;
                if (total > Take)
                {
                    while (_skip < total)
                    {
                        script = string.Format(ScriptMySqlHelper.TableIcd, _skip, Take);
                        table = mysqlProvider.GetDataTable(script);
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableIcd, _saveTo);
                        strScriptSqlite = ScriptSqliteHelper.InsertIcdSchedule + table.GetScript(ScriptSqliteHelper.InsertIcdValue, 3);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableIcd, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableIcd, _saveTo);
                    strScriptSqlite = ScriptSqliteHelper.InsertIcdSchedule + table.GetScript(ScriptSqliteHelper.InsertIcdValue, 3);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                }

            }
        }

        private static void RunNpi()
        {
            using (var mysqlProvider = new MySqlDataProvider(_connectionString))
            {
                string script, strScriptSqlite;
                DataTable table;
                var total = mysqlProvider.GetCount(ScriptMySqlHelper.TablePhysicanNpiCount);
                _skip = 0;
                if (total > Take)
                {
                    while (_skip < total)
                    {
                        script = string.Format(ScriptMySqlHelper.TablePhysicanNpi, _skip, Take);
                        table = mysqlProvider.GetDataTable(script);
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TablePhysicanNpi, _saveTo);
                        strScriptSqlite = ScriptSqliteHelper.InsertPhysicanNpiSchedule + table.GetScript(ScriptSqliteHelper.InsertPhysicanNpiValue, 17);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TablePhysicanNpi, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TablePhysicanNpi, _saveTo);
                    strScriptSqlite = ScriptSqliteHelper.InsertPhysicanNpiSchedule + table.GetScript(ScriptSqliteHelper.InsertPhysicanNpiValue, 17);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                }

            }
        }

        private static void RunRoute()
        {
            using (var mysqlProvider = new MySqlDataProvider(_connectionString))
            {
                string script, strScriptSqlite;
                DataTable table;
                var total = mysqlProvider.GetCount(ScriptMySqlHelper.TableRouteCount);
                _skip = 0;
                if (total > Take)
                {
                    while (_skip < total)
                    {
                        script = string.Format(ScriptMySqlHelper.TableRoute, _skip, Take);
                        table = mysqlProvider.GetDataTable(script);
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableRoute, _saveTo);
                        strScriptSqlite = ScriptSqliteHelper.InsertRouteSchedule + table.GetScript(ScriptSqliteHelper.InsertRouteValue, 3);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableRoute, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableRoute, _saveTo);
                    strScriptSqlite = ScriptSqliteHelper.InsertRouteSchedule + table.GetScript(ScriptSqliteHelper.InsertRouteValue, 3);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                }

            }
        }

        private static void RunFrequency()
        {
            using (var mysqlProvider = new MySqlDataProvider(_connectionString))
            {
                string script, strScriptSqlite;
                DataTable table;
                var total = mysqlProvider.GetCount(ScriptMySqlHelper.TableFrequencyCount);
                _skip = 0;
                if (total > Take)
                {
                    while (_skip < total)
                    {
                        script = string.Format(ScriptMySqlHelper.TableFrequency, _skip, Take);
                        table = mysqlProvider.GetDataTable(script);
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableFrequency, _saveTo);
                        strScriptSqlite = ScriptSqliteHelper.InsertFrequencySchedule + table.GetScript(ScriptSqliteHelper.InsertFrequencyValue, 3);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableFrequency, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableFrequency, _saveTo);
                    strScriptSqlite = ScriptSqliteHelper.InsertFrequencySchedule + table.GetScript(ScriptSqliteHelper.InsertFrequencyValue, 3);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                }

            }
        }

        private static void RunSection()
        {
            using (var mysqlProvider = new MySqlDataProvider(_connectionString))
            {
                string script, strScriptSqlite;
                DataTable table;
                var total = mysqlProvider.GetCount(ScriptMySqlHelper.TableSectionCount);
                _skip = 0;
                if (total > Take)
                {
                    while (_skip < total)
                    {
                        script = string.Format(ScriptMySqlHelper.TableSection, _skip, Take);
                        table = mysqlProvider.GetDataTable(script);
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableSection, _saveTo);
                        strScriptSqlite = ScriptSqliteHelper.InsertSectionSchedule + table.GetScript(ScriptSqliteHelper.InsertSectionValue, 5);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableSection, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableSection, _saveTo);
                    strScriptSqlite = ScriptSqliteHelper.InsertSectionSchedule + table.GetScript(ScriptSqliteHelper.InsertSectionValue, 5);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                }

            }
        }

        private static void RunSectionQuestion()
        {
            using (var mysqlProvider = new MySqlDataProvider(_connectionString))
            {
                string script, strScriptSqlite;
                DataTable table;
                var total = mysqlProvider.GetCount(ScriptMySqlHelper.TableSectionQuestionCount);
                _skip = 0;
                if (total > Take)
                {
                    while (_skip < total)
                    {
                        script = string.Format(ScriptMySqlHelper.TableSectionQuestion, _skip, Take);
                        table = mysqlProvider.GetDataTable(script);
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableSectionQuestion, _saveTo);
                        strScriptSqlite = ScriptSqliteHelper.InsertSectionQuestionSchedule + table.GetScript(ScriptSqliteHelper.InsertSectionQuestionValue, 26);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableSectionQuestion, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableSectionQuestion, _saveTo);
                    strScriptSqlite = ScriptSqliteHelper.InsertSectionQuestionSchedule + table.GetScript(ScriptSqliteHelper.InsertSectionQuestionValue, 26);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                }

            }

        }

        private static void RunProviderAgency()
        {
            using (var mysqlProvider = new MySqlDataProvider(_connectionString))
            {
                string script, strScriptSqlite;
                DataTable table;
                var total = mysqlProvider.GetCount(ScriptMySqlHelper.TableProviderAgencyCount);
                _skip = 0;
                if (total > Take)
                {
                    while (_skip < total)
                    {
                        script = string.Format(ScriptMySqlHelper.TableProviderAgency, _skip, Take);
                        table = mysqlProvider.GetDataTable(script);
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableProviderAgency, _saveTo);
                        strScriptSqlite = ScriptSqliteHelper.InsertProviderAgencySchedule + table.GetScript(ScriptSqliteHelper.InsertProviderAgencyValue, 15);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableProviderAgency, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableProviderAgency, _saveTo);
                    strScriptSqlite = ScriptSqliteHelper.InsertProviderAgencySchedule + table.GetScript(ScriptSqliteHelper.InsertProviderAgencyValue, 15);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                }

            }

        }

        private static void RunProviderMpi()
        {
            using (var mysqlProvider = new MySqlDataProvider(_connectionString))
            {
                string script, strScriptSqlite;
                DataTable table;
                var total = mysqlProvider.GetCount(ScriptMySqlHelper.TableProviderMpiCount);
                _skip = 0;
                if (total > Take)
                {
                    while (_skip < total)
                    {
                        script = string.Format(ScriptMySqlHelper.TableProviderMpi, _skip, Take);
                        table = mysqlProvider.GetDataTable(script);
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableProviderMpi, _saveTo);
                        strScriptSqlite = ScriptSqliteHelper.InsertProviderMpiSchedule + table.GetScript(ScriptSqliteHelper.InsertProviderMpiValue, 15);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableProviderMpi, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableProviderMpi, _saveTo);
                    strScriptSqlite = ScriptSqliteHelper.InsertProviderMpiSchedule + table.GetScript(ScriptSqliteHelper.InsertProviderMpiValue, 15);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, _saveTo);
                }

            }

        }
        #endregion
    }
}
