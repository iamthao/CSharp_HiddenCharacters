using System;
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
using System.Windows.Forms;
using PcstLib.MySql;

namespace GenerateDataDefaulPcst
{
    public partial class FrmMain : Form
    {
        private const string StrConnect = "Connect";
        private const string StrDisconnect = "Disconnect";
        private const string StrGenerate = "Generate";
        private const string StrCancel = "Generate";
        private MySqlDataBakup _mySqlDataBakup;
        private BackgroundWorker _worker;
        private string _connectionString;
        private const int Take = 5000;
        private int _skip;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == StrConnect)
            {
                _mySqlDataBakup = new MySqlDataBakup(txtConnectionString.Text);
                Exception ex;
                if (!_mySqlDataBakup.IsConnected(out ex))
                {
                    MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btnConnect.Text = StrDisconnect;
                    grbGenerateInfo.Enabled = true;
                    _connectionString = txtConnectionString.Text;
                }
            }
            else
            {
                if (_mySqlDataBakup != null)
                {
                    _mySqlDataBakup.Dispose();
                }
                btnConnect.Text = StrConnect;
                grbGenerateInfo.Enabled = false;
            }
           
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            var saveFileDiaLog = new SaveFileDialog();
            saveFileDiaLog.Filter = @"db files (*.db)|*.db";
            if (saveFileDiaLog.ShowDialog() == DialogResult.OK)
            {
                txtSaveSQLiteFile.Text = saveFileDiaLog.FileName;
                saveFileDiaLog.OpenFile().Close();
            }
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSaveSQLiteFile.Text) && File.Exists(txtSaveSQLiteFile.Text))
            {
                if (btnGenerate.Text == StrGenerate)
                {
                    btnGenerate.Text = StrCancel;
                    lblGenerate.Visible = true;
                    btnGenerate.Enabled = false;
                    Generate();
                }
                else
                {
                    btnGenerate.Text = StrGenerate;
                    lblGenerate.Visible = false;
                    btnGenerate.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(@"Please selected save SQLite file.");
            }
        }

        private void Generate()
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += WorkerOnDoWork;
            _worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
            _worker.RunWorkerAsync();
        }

        private void WorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            btnGenerate.Text = StrGenerate;
            lblGenerate.Visible = false;
        }

        private void WorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            InitFileDb();
            if (chkLanguage.Checked)
            {
                RunPrimaryLanguage();
            }
            if (chkCounty.Checked)
            {
                RunCounty();
            }
            if (chkIcd.Checked)
            {
                RunIcd();
               
            }
            if (chkNpi.Checked)
            {
                RunNpi();
            }
            if (chkRoute.Checked)
            {
                RunRoute();
            }
            if (chkFrequency.Checked)
            {
                RunFrequency();
            }
            if (chkSection.Checked)
            {
                RunSection();
            }
            if (chkSectionQuestion.Checked)
            {
                RunSectionQuestion();
            }
        }

        private void InitFileDb()
        {
            File.Delete(txtSaveSQLiteFile.Text);
            File.Create(txtSaveSQLiteFile.Text).Close();
        }

        private void RunPrimaryLanguage()
        {
            chkLanguage.BackColor = SystemColors.MenuHighlight;
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
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableLanguage, txtSaveSQLiteFile.Text);
                        strScriptSqlite = ScriptSqliteHelper.InsertLanguageSchedule + table.GetScript(ScriptSqliteHelper.InsertLanguageValue, 3);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableLanguage, _skip, total);

                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableLanguage, txtSaveSQLiteFile.Text);
                    strScriptSqlite = ScriptSqliteHelper.InsertLanguageSchedule + table.GetScript(ScriptSqliteHelper.InsertLanguageValue, 3);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                }
                
            }
            chkLanguage.BackColor = SystemColors.Control;
        }

        private void RunCounty()
        {
            chkCounty.BackColor = SystemColors.MenuHighlight;
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
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableCounty, txtSaveSQLiteFile.Text);
                        strScriptSqlite = ScriptSqliteHelper.InsertCountySchedule + table.GetScript(ScriptSqliteHelper.InsertCountyValue, 3);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableCounty, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableCounty, txtSaveSQLiteFile.Text);
                    strScriptSqlite = ScriptSqliteHelper.InsertCountySchedule + table.GetScript(ScriptSqliteHelper.InsertCountyValue, 3);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                }

            }
            chkCounty.BackColor = SystemColors.Control;
        }

        private void RunIcd()
        {
            chkIcd.BackColor = SystemColors.MenuHighlight;
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
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableIcd, txtSaveSQLiteFile.Text);
                        strScriptSqlite = ScriptSqliteHelper.InsertIcdSchedule + table.GetScript(ScriptSqliteHelper.InsertIcdValue, 3);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableIcd, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableIcd, txtSaveSQLiteFile.Text);
                    strScriptSqlite = ScriptSqliteHelper.InsertIcdSchedule + table.GetScript(ScriptSqliteHelper.InsertIcdValue, 3);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                }

            }
            chkIcd.BackColor = SystemColors.Control;
        }

        private void RunNpi()
        {
            chkNpi.BackColor = SystemColors.MenuHighlight;
            using (var mysqlProvider = new MySqlDataProvider(_connectionString))
            {
                string script, strScriptSqlite;
                DataTable table;
                var total = mysqlProvider.GetCount(ScriptMySqlHelper.TableNpiCount);
                _skip = 0;
                if (total > Take)
                {
                    while (_skip < total)
                    {
                        script = string.Format(ScriptMySqlHelper.TableNpi, _skip, Take);
                        table = mysqlProvider.GetDataTable(script);
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableNpi, txtSaveSQLiteFile.Text);
                        strScriptSqlite = ScriptSqliteHelper.InsertNpiSchedule + table.GetScript(ScriptSqliteHelper.InsertNpiValue, 16);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableNpi, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableNpi, txtSaveSQLiteFile.Text);
                    strScriptSqlite = ScriptSqliteHelper.InsertNpiSchedule + table.GetScript(ScriptSqliteHelper.InsertNpiValue, 16);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                }

            }
            chkNpi.BackColor = SystemColors.Control;
        }

        private void RunRoute()
        {
            chkRoute.BackColor = SystemColors.MenuHighlight;
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
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableRoute, txtSaveSQLiteFile.Text);
                        strScriptSqlite = ScriptSqliteHelper.InsertRouteSchedule + table.GetScript(ScriptSqliteHelper.InsertRouteValue, 3);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableRoute, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableRoute, txtSaveSQLiteFile.Text);
                    strScriptSqlite = ScriptSqliteHelper.InsertRouteSchedule + table.GetScript(ScriptSqliteHelper.InsertRouteValue, 3);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                }

            }
            chkRoute.BackColor = SystemColors.Control;
        }

        private void RunFrequency()
        {
            chkFrequency.BackColor = SystemColors.MenuHighlight;
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
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableFrequency, txtSaveSQLiteFile.Text);
                        strScriptSqlite = ScriptSqliteHelper.InsertFrequencySchedule + table.GetScript(ScriptSqliteHelper.InsertFrequencyValue, 3);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableFrequency, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableFrequency, txtSaveSQLiteFile.Text);
                    strScriptSqlite = ScriptSqliteHelper.InsertFrequencySchedule + table.GetScript(ScriptSqliteHelper.InsertFrequencyValue, 3);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                }

            }
            chkFrequency.BackColor = SystemColors.Control;
        }

        private void RunSection()
        {
            chkSection.BackColor = SystemColors.MenuHighlight;
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
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableSection, txtSaveSQLiteFile.Text);
                        strScriptSqlite = ScriptSqliteHelper.InsertSectionSchedule + table.GetScript(ScriptSqliteHelper.InsertSectionValue, 5);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableSection, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableSection, txtSaveSQLiteFile.Text);
                    strScriptSqlite = ScriptSqliteHelper.InsertSectionSchedule + table.GetScript(ScriptSqliteHelper.InsertSectionValue, 5);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                }

            }
            chkSection.BackColor = SystemColors.Control;
        }

        private void RunSectionQuestion()
        {
            chkSectionQuestion.BackColor = SystemColors.MenuHighlight;
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
                        GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableSectionQuestion, txtSaveSQLiteFile.Text);
                        strScriptSqlite = ScriptSqliteHelper.InsertSectionQuestionSchedule + table.GetScript(ScriptSqliteHelper.InsertSectionQuestionValue, 24);
                        GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                        _skip += Take;
                    }
                }
                else
                {
                    script = string.Format(ScriptMySqlHelper.TableSectionQuestion, _skip, total);
                    table = mysqlProvider.GetDataTable(script);
                    GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableSectionQuestion, txtSaveSQLiteFile.Text);
                    strScriptSqlite = ScriptSqliteHelper.InsertSectionQuestionSchedule + table.GetScript(ScriptSqliteHelper.InsertSectionQuestionValue, 24);
                    GenerateScriptHelper.SaveSqliteDb(strScriptSqlite, txtSaveSQLiteFile.Text);
                }

            }
            chkSectionQuestion.BackColor = SystemColors.Control;
        }

        private void btnBrowserData_Click(object sender, EventArgs e)
        {
            var saveFileDiaLog = new SaveFileDialog();
            saveFileDiaLog.Filter = @"db files (*.db)|*.db";
            if (saveFileDiaLog.ShowDialog() == DialogResult.OK)
            {
                txtSqliteData.Text = saveFileDiaLog.FileName;
                saveFileDiaLog.OpenFile().Close();
            }
        }

        private void btnGenerateDataSote_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSqliteData.Text) && File.Exists(txtSqliteData.Text))
            {
                if (btnGenerate.Text == StrGenerate)
                {
                    btnGenerate.Text = StrCancel;
                    btnGenerate.Enabled = false;
                    GenerateData();
                }
                else
                {
                    btnGenerateDataSote.Text = StrGenerate;
                    btnGenerateDataSote.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(@"Please selected save SQLite file.");
            }
        }

        private void GenerateData()
        {
            File.Delete(txtSqliteData.Text);
            File.Create(txtSqliteData.Text).Close();
            GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableAssessment, txtSqliteData.Text);
            GenerateScriptHelper.SaveSqliteDb(ScriptSqliteHelper.TableAssessmentSectionQuestion, txtSqliteData.Text);
        }
    }
}
