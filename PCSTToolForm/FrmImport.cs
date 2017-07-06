using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using PcstLib.Services;
using PcstLib.Sqlite.ValueObject;
using PcstLib.Utility;

namespace PCSTToolForm
{
    public partial class FrmImport : Form
    {
        public FrmMain _frmMain;
        public FrmImport(FrmMain frmMain)
        {
            _frmMain = frmMain;
            InitializeComponent();

        }
        public FrmImport()
        {
            InitializeComponent();
           
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FileDialog fileDiaLog = new OpenFileDialog { Filter = @"db files (*.backup)|*.backup" };
            var result = fileDiaLog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFilePathImport.Text = fileDiaLog.FileName;

                txtFileName.Text = Path.GetFileNameWithoutExtension(txtFilePathImport.Text);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {        
            string encyptKey = ConfigurationManager.AppSettings["EncyptKey"];
            if (string.IsNullOrEmpty(encyptKey))
            {
                MessageBox.Show("EncyptKey not found in App.config.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txtFilePathImport.Text.Trim()))
            {
                MessageBox.Show("File path is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!File.Exists(txtFilePathImport.Text))
            {
                MessageBox.Show("File path can not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txtFileName.Text.Trim()))
            {
                MessageBox.Show("File name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (CheckNameExist(txtFileName.Text.Trim()))
            {
                MessageBox.Show("File name already existed in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string text = File.ReadAllText(txtFilePathImport.Text);

                var dataDecrypt = EncryptHelper.Decrypt(text, encyptKey);
                AssessmentService assessmentService = new AssessmentService();
                var id = assessmentService.ImportData(txtFileName.Text, dataDecrypt);
                if (id > 0)
                {
                    MessageBox.Show("Import successfully!", "Information");
                    this.Close();
                    _frmMain.RefreshDataForGridFromAnotherForm();
                }
                else
                {
                    MessageBox.Show("Import failed!", "Error");
                }
            }
        }

        private bool CheckNameExist(string fileName)
        {
            AssessmentService assessmentService = new AssessmentService();
            return assessmentService.CheckNameExist(fileName);
        }
    }
}
