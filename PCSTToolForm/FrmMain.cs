using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using PcstLib.Services;
using PcstLib.Sqlite;
using PcstLib.Sqlite.Entities;
using PcstLib.Sqlite.ValueObject;
using PcstLib.Utility;
using PCSTToolForm.SelfHost;
using PCSTToolForm.Update;

namespace PCSTToolForm
{
    public partial class FrmMain : Form
    {

        private const int pageSize = 20;
        private readonly AssessmentService _assessmentService = new AssessmentService();
        readonly BindingSource bs = new BindingSource();
        private bool _autoUpdate = true;

        //delegate void UpdateGridHandler();
        private string pathFileScriptTemp = Directory.GetCurrentDirectory() + "\\Resource\\pcst\\pcstTemp.js";
        private string pathFileScriptSource = Directory.GetCurrentDirectory() + "\\Resource\\pcst\\pcst.js";
        private System.Windows.Forms.Timer CheckUpdateTimer = new System.Windows.Forms.Timer();
        public FrmMain()
        {
            var url = "";
            string urlWeb = ConfigurationManager.AppSettings["UrlWeb"];
            if (!string.IsNullOrEmpty(urlWeb))
            {
                url = urlWeb;
            }
            //If File Temp not exist is copy (the first)
            if (!File.Exists(pathFileScriptTemp))
            {
                File.Copy(pathFileScriptSource, pathFileScriptTemp);
            }

            string pcstVersionPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PcstVersion.txt");
            var currentVersion = "1.0.0.0";
            if (File.Exists(pcstVersionPath))
            {
                currentVersion = File.ReadAllText(pcstVersionPath);
            }

            InitializeComponent();
            this.Text = "PCST Tool v" + currentVersion + " - " + url;

            bwCheckUpdate.RunWorkerAsync();
            CheckUpdateTimer.Tick += CheckUpdateTimer_Tick;
            CheckUpdateTimer.Interval = 5*60*1000;//5 minutes
            CheckUpdateTimer.Start();
        }

        void CheckUpdateTimer_Tick(object sender, EventArgs e)
        {
            if(!bwCheckUpdate.IsBusy)
                bwCheckUpdate.RunWorkerAsync();
        }

        private string _baseAddress = "http://localhost";
        private string _port = "9000";
        private bool SelfHost()
        {
            try
            {
                string baseAddress = _baseAddress + ":" + _port + "/";
                // Start OWIN host 
                var api = WebApp.Start<Startup>(url: baseAddress);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("The default port " + _port + " was occupied by some other application!", "Error");
                return false;
            }
        }
        //public ChromiumWebBrowser chromeBrowser;

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //CefSettings settings = new CefSettings();
        //// Initialize cef with the provided settings
        //Cef.Initialize(settings);
        //// Create a browser component
        //chromeBrowser = new ChromiumWebBrowser("http://www.google.com.vn/");
        //// Add it to the form and fill it to the form window.
        //this.Controls.Add(chromeBrowser);
        //chromeBrowser.Dock = DockStyle.Fill;
        //}

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var form = new FrmInputName(this);
            //form.FormBorderStyle = FormBorderStyle.FixedDialog;
            //form.StartPosition = FormStartPosition.CenterParent;
            form.Show(this);

            //var form = new FrmPcstForm(0,this);
            //form.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if(SelfHost())
                InitDataForGrid();
            else
                Close();
        }

        public class CbbPageSize
        {
            public int Value { get; set; }
            public string DisplayName { get; set; }
        }
        public void InitDataForGrid()
        {
            //int totalRecords;
            //dgvAssessment.DataSource = _assessmentService.GetAllAssessment(pageSize, 0, out totalRecords);
            //bs.DataSource = new PageOffsetList(pageSize, totalRecords);
            //bindingNavigator1.BindingSource = bs;
            //bs.PositionChanged += bindingSource1_CurrentChanged;
            List<CbbPageSize> cbbPageSize = new List<CbbPageSize>
            {
                new CbbPageSize
                {
                    DisplayName = "15", Value = 15
                },
                new CbbPageSize
                {
                    DisplayName = "25", Value = 25
                },
                new CbbPageSize
                {
                    DisplayName = "50", Value = 50
                }
            };

            if (toolStripComboBox1.ComboBox != null)
            {
                toolStripComboBox1.ComboBox.DataSource = cbbPageSize;
                toolStripComboBox1.ComboBox.DisplayMember = "DisplayName";
                toolStripComboBox1.ComboBox.ValueMember = "Value";
            }

            // toolStripComboBox1.
            bindingNavigator1.BindingSource = bs;
            bs_PositionChanged(bs, EventArgs.Empty);
        }

        public void LoadAssessmentGrid()
        {
            bs_PositionChanged(bs, EventArgs.Empty);
            //bindingSource1_CurrentChanged(null, null);
        }

        /// <summary>
        /// Handle event Export/Edit/Delete for Assessment grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAssessment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var assessmentId = senderGrid.Rows[e.RowIndex].Cells["Id"].Value;
            if (assessmentId == null) return;
            switch (senderGrid.Columns[e.ColumnIndex].Name)
            {
                case "Export":
                    ExportAssessment((int)assessmentId);
                    break;
                case "Edit":
                    EditAssessment((int)assessmentId);
                    break;
                case "Delete":
                    DeleteAssessment((int)assessmentId);
                    break;
            }
        }

        private void ExportAssessment(int assessmentId)
        {
            string encyptKey = ConfigurationManager.AppSettings["EncyptKey"];
            if (string.IsNullOrEmpty(encyptKey))
            {
                throw new Exception("EncyptKey not found in App.config");
            }

            var assessment = _assessmentService.GetById(assessmentId);
            if (assessment != null)
            {
                var isShowExportForm = true;
                var listError = new List<MessageErrorVo>();

                var dataJsonDiscloseData = new DisclosureFormVo();
                var dataJsonAssessment = new AssessmentDataVo();

                if (string.IsNullOrEmpty(assessment.DisclosureFormData))
                {
                    isShowExportForm = false;
                    var errorMsg = "To export assessment, please input data fully to Disclosure Form.\n";                    
                    MessageBox.Show(errorMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!string.IsNullOrEmpty(assessment.DisclosureFormData))
                {
                    var decryptDiscloseData = EncryptHelper.Decrypt(assessment.DisclosureFormData, encyptKey);
                    dataJsonDiscloseData = JsonConvert.DeserializeObject<DisclosureFormVo>(decryptDiscloseData);

                    if (!string.IsNullOrEmpty(assessment.AssessmentData))
                    {
                        var decryptAssessment = EncryptHelper.Decrypt(assessment.AssessmentData, encyptKey);
                        dataJsonAssessment = JsonConvert.DeserializeObject<AssessmentDataVo>(decryptAssessment);
                    }

                    var listErrorDisclosureForm = _assessmentService.CheckInValidDisclosureForm(dataJsonDiscloseData);
                    listError = _assessmentService.CheckInValidBeforeExport(dataJsonDiscloseData, dataJsonAssessment);

                    if (listErrorDisclosureForm != null && listErrorDisclosureForm.Count > 0)
                    {
                        if (listError != null && listError.Count > 0)
                        {
                            listErrorDisclosureForm.AddRange(listError);
                        }
                        isShowExportForm = false;
                        var errorMsg = "To export assessment, please input data fully to Disclosure Form.\n" +
                                      "Following business rules are failed:\n";
                        foreach (var item in listErrorDisclosureForm)
                        {
                            errorMsg += " - " + item.MessageError.Replace("(Disclosure Form)", "") + "\n";
                        }
                        MessageBox.Show(errorMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                   
                    else if (listError != null && listError.Count > 0)
                    {
                        isShowExportForm = false;
                        var errorMsg = "Following business rules are failed:\n";
                        foreach (var item in listError)
                        {
                            errorMsg += " - " + item.MessageError.Replace("(Disclosure Form)", "") + "\n";
                        }
                        MessageBox.Show(errorMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                
                if (isShowExportForm)
                {
                    var form = new FrmExport(assessment);
                    form.ShowDialog();
                }
                
            }
            

        }

        private void DeleteAssessment(int assessmentId)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this assessment?",
                                     "Confirm Message",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                var flag = _assessmentService.DeleteAssessment(assessmentId);
                if (flag)
                {
                    LoadAssessmentGrid();
                    MessageBox.Show("Delete assessment successfully", "Notification", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
            }

        }

        public void EditAssessment(int assessmentId)
        {
            var form = new FrmPcstForm(assessmentId, this);
            form.ShowDialog();
        }

        #region grid paging
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                // The desired page has changed, so fetch the page of records using the "Current" offset 
                int total;
                int pageNum = (int)bs.Position > 0 ? (int)bs.Position : 0;

                var lst = _assessmentService.GetAllAssessment(pageSize, pageNum, out total);
                if (lst.Count > 0)
                {
                    dgvAssessment.DataSource = lst;

                }
                else if (pageNum > 1)
                {
                    bs.Position = pageNum - 1;
                    bs.DataSource = new PageOffsetList(pageSize, total);
                }

            }));
        }

        public class PageOffsetList : IListSource
        {
            public bool ContainsListCollection
            {
                get;
                protected set;
            }
            private int TotalRecords = 0;
            private int pageSize = 0;
            public PageOffsetList(int pageSize, int total)
            {
                this.TotalRecords = total;
                this.pageSize = pageSize;
            }
            public IList GetList()
            {
                // Return a list of page offsets based on "totalRecords" and "pageSize"   
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < TotalRecords; offset = offset + pageSize)
                {
                    pageOffsets.Add(offset);
                }
                return pageOffsets;
            }
        }
        #endregion

        private void btnImportAssessment_Click(object sender, EventArgs e)
        {
            FrmImport importAssessment = new FrmImport(this);
            importAssessment.FormBorderStyle = FormBorderStyle.FixedDialog;
            importAssessment.StartPosition = FormStartPosition.CenterParent;
            importAssessment.ShowDialog(this);
        }

        public void RefreshDataForGridFromAnotherForm()
        {
            LoadAssessmentGrid();
        }

        private void dgvAssessment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex < 0) return;

            var assessmentId = senderGrid.Rows[e.RowIndex].Cells["Id"].Value;
            if (assessmentId == null) return;
            EditAssessment((int)assessmentId);
        }

        //Start THAO
        #region
        public int total = 0;
        public int skip = 0;
        public int take = 20;
        public int page = 0;

        void bs_PositionChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.ComboBox != null)
            {
                var selected = (CbbPageSize)toolStripComboBox1.ComboBox.SelectedItem;
                if (selected != null && selected.Value != null)
                {
                    take = selected.Value;
                }
                
            }

            this.Invoke(new MethodInvoker(delegate
            {
               if (bs.Position <= 0)
               {
                   page = 0;
                   skip = page * take;
                   var data = _assessmentService.GetAllAssessmentThao(skip, take, out total);
                   bs.DataSource = new PageOffsetList(take, total);
                   dgvAssessment.DataSource = data;
               }
               else
               {
                   page = bs.Position;
                   skip = page * take;
                   var data = _assessmentService.GetAllAssessmentThao(skip, take, out total);
                   bs.DataSource = new PageOffsetList(take, total);

                   while (data.Count == 0)
                   {
                       page = bs.Position;
                       skip = page * take;
                       data = _assessmentService.GetAllAssessmentThao(skip, take, out total);
                       bs.DataSource = new PageOffsetList(take, total);
                   }
                   if (data.Count > 0)
                       dgvAssessment.DataSource = data;
               }
           }));
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            page = 0;
            bs_PositionChanged(bs, EventArgs.Empty);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            page = bs.Position - 1;
            bs_PositionChanged(bs, EventArgs.Empty);
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            page = bs.Position + 1;
            bs_PositionChanged(bs, EventArgs.Empty);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            var data = _assessmentService.GetAllAssessment(take, 0, out total);
            page = total / take - 1;
            bs_PositionChanged(bs, EventArgs.Empty);
        }

        private void bindingNavigatorPositionItem_Leave(object sender, EventArgs e)
        {
            page = bs.Position - 1;
            bs_PositionChanged(bs, EventArgs.Empty);
        }

        #endregion

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = bs.Position;
            bs_PositionChanged(bs, EventArgs.Empty);
        }
        
        //End

        private void bwCheckUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string updatePcstApi = ConfigurationManager.AppSettings["UpdatePcstApi"];
                if (!string.IsNullOrEmpty(updatePcstApi))
                {
                    var webApiConnect = new WebApiConnect(updatePcstApi);
                    var objVersion = webApiConnect.SendMessageToWebApi("GetPcstVersion", null);
                    var version = (string) objVersion;

                    var oldVersion = "1.0.0.0";
                    string pcstVersionPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PcstVersion.txt");
                    if (File.Exists(pcstVersionPath))
                    {
                        oldVersion = File.ReadAllText(pcstVersionPath);
                    }
                    if (!version.Equals(oldVersion))
                    {
                        e.Result = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            
        }

        private void bwCheckUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && (int)e.Result == 1)
            {
                btnUpdateNewVersion.Enabled = true;
                if (Application.OpenForms.Count == 1 && Application.OpenForms.OfType<FrmMain>().Any() && _autoUpdate)
                {
                    //auto update
                    btnUpdateNewVersion_Click(null, null);
                }
            }
            _autoUpdate = false;
        }

        private void btnUpdateNewVersion_Click(object sender, EventArgs e)
        {
            string pcstUpdateName = "PcstUpdate.exe";
            string pcstUpdateDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PcstUpdate");
            var pcstUpdate = Path.Combine(pcstUpdateDir, pcstUpdateName);
            if (File.Exists(pcstUpdate))
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = pcstUpdateName,
                    WorkingDirectory = pcstUpdateDir
                };
                Process.Start(processInfo);
                CheckUpdateTimer.Dispose();
                Close();
            }
        }
    }
}
