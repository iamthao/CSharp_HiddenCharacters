using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using PcstLib.Services;
using PcstLib.Sqlite;
using PCSTToolForm.SelfHost;

namespace PCSTToolForm
{
    public partial class FrmMain : Form
    {

        private const int pageSize = 20;
        private readonly AssessmentService _assessmentService = new AssessmentService();
        readonly BindingSource bs = new BindingSource();

        //delegate void UpdateGridHandler();
        private string pathFileScriptTemp = Directory.GetCurrentDirectory() + "\\Resource\\pcst\\pcstTemp.js";
        public FrmMain()
        {
            //If File Temp not exist is copy (the first)
            if (File.Exists(pathFileScriptTemp))
            {
                File.Delete(pathFileScriptTemp);
            }

            InitializeComponent();
        }

        private string _baseAddress = "http://localhost";
        private string _port = "9000";
        private void SelfHost()
        {
            string baseAddress = _baseAddress + ":" + _port + "/";
            // Start OWIN host 
            var api = WebApp.Start<Startup>(url: baseAddress);
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
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);

            //var form = new FrmPcstForm(0,this);
            //form.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            SelfHost();
            InitDataForGrid();
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
            var assessment = _assessmentService.GetById(assessmentId);
            if (assessment != null)
            {
                var form = new FrmExport(assessment);
                form.ShowDialog();
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

        private void btnImportDataDefault_Click(object sender, EventArgs e)
        {
            FrmImportDataDefault import = new FrmImportDataDefault();
            import.FormBorderStyle = FormBorderStyle.FixedDialog;
            import.StartPosition = FormStartPosition.CenterParent;
            import.ShowDialog(this);
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
    }
}
