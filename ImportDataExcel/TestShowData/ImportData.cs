using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using LibraryReadFileExcel;
using Newtonsoft.Json;

namespace TestShowText
{
    public partial class ImportData : Form
    {

        private FileDialog _fileDialog;
        private FileDialog _fileDialog2;
        private const string msgOpeningFile = "File is openning by other program. Please close file to continues.";
        private const int color1 = 95;
        private const int color2 = 186;
        private const int color3 = 125;
        public ImportData()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            this.Location = new Point(150, 270);
            //txtContent.ScrollBars = ScrollBars.Vertical;
            _fileDialog = new OpenFileDialog { Filter = @"Excel Files (.xls;.xlsx)|*.xls;*.xlsx" };
            _fileDialog2 = new OpenFileDialog { Filter = @"SQL Files (.sql)|*.sql" };
            lbStatus.Text = "n/a";            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var result = _fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPath.Text = _fileDialog.FileName;
            }
        }
        

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            //txtContent.SelectionStart = txtContent.Text.Length;
            //txtContent.ScrollToCaret();
            //txtContent.Refresh();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
           // System.Windows.Forms.Clipboard.SetText(txtContent.Text);
            //txtContent.AppendText(a);
            //txtContent.AppendText(Environment.NewLine);
        }

        public enum TypeStatus
        {
            Processing =1,
            Successfully =2
        }
        public  void SetColorStatus(TypeStatus type)
        {
            if (TypeStatus.Processing == type)
            {
                lbStatus.Text = "Processing...";
                lbStatus.ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (TypeStatus.Successfully == type)
            {
                lbStatus.Text = "Successfully.";
                lbStatus.ForeColor = Color.FromArgb(color1, color2, color3);
            }
            
        }
        private void btnOutput_Click(object sender, EventArgs e)
        {
            var result = _fileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPathOutput.Text = _fileDialog2.FileName;
            }
        }

        private void btnImportStatusReason_Click(object sender, EventArgs e)
        {
            if (IsFileinUse(txtPath.Text))
            {
                MessageBox.Show(msgOpeningFile, "Information", MessageBoxButtons.OK);
            }
            else
            {
                SetColorStatus(TypeStatus.Processing);
                if (ImportStatusReason.RunAction(txtPath.Text, txtPathOutput.Text))
                {
                    SetColorStatus(TypeStatus.Successfully);
                }
            }
        }

        private void btnImportListAction_Click(object sender, EventArgs e)
        {
            if (IsFileinUse(txtPath.Text))
            {
                MessageBox.Show(msgOpeningFile, "Information", MessageBoxButtons.OK);
            }
            else
            {
                SetColorStatus(TypeStatus.Processing);

                if (ImportListAction.RunAction(txtPath.Text, txtPathOutput.Text))
                {
                    SetColorStatus(TypeStatus.Successfully);                    
                } 
            }
            
        }

        private void btnTooltipRole_Click(object sender, EventArgs e)
        {
            if (IsFileinUse(txtPath.Text))
            {
                MessageBox.Show(msgOpeningFile, "Information",
                    MessageBoxButtons.OK);
            }
            else
            {
                SetColorStatus(TypeStatus.Processing);

                if (ImportTooltopRole.RunAction(txtPath.Text, txtPathOutput.Text))
                {
                    SetColorStatus(TypeStatus.Successfully);
                }
            }
        }

        private void btnImportRoleDefault_Click(object sender, EventArgs e)
        {
            if (IsFileinUse(txtPath.Text))
            {
                MessageBox.Show(msgOpeningFile, "Information",
                    MessageBoxButtons.OK);
            }
            else
            {
                SetColorStatus(TypeStatus.Processing);

                if (ImportRoleDefault.RunAction(txtPath.Text, txtPathOutput.Text))
                {
                    SetColorStatus(TypeStatus.Successfully);
                }
            }
        }

        private bool IsFileinUse(string pathFile)
        {
            FileInfo file = new FileInfo(pathFile);
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        private void btnModifyCsv_Click(object sender, EventArgs e)
        {

        }
       
        
    }
}
