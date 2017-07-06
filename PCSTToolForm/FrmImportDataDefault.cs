using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCSTToolForm
{
    public partial class FrmImportDataDefault : Form
    {
        private string pathFileDataDefault = Directory.GetCurrentDirectory() + "\\Data\\df.db";
        public FrmImportDataDefault()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text.Trim()))
            {
                MessageBox.Show("File path is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!File.Exists(txtFilePath.Text))
            {
                MessageBox.Show("File path not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (File.Exists(pathFileDataDefault))
                {
                    File.Delete(pathFileDataDefault);
                }
                File.Copy(txtFilePath.Text, pathFileDataDefault);
                if (File.Exists(pathFileDataDefault))
                {
                    MessageBox.Show("Import successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FileDialog fileDiaLog = new OpenFileDialog { Filter = @"db files (*.db)|*.db" };
            var result = fileDiaLog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFilePath.Text = fileDiaLog.FileName;
            }
        }
    }
}
