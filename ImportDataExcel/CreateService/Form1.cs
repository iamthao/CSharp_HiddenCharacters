using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChangeDnsForm;
using TestFunction;

namespace CreateService
{
    public partial class Form1 : Form
    {
        private FileDialog _fileDialog;
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(700, 500);
            _fileDialog = new OpenFileDialog { Filter = @".CSV Files (.exe)|*.exe" };
            //btnUninstall.Enabled = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var result = _fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPath.Text = _fileDialog.FileName;
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            var comd1 = "sc.exe create " + txtName.Text + " binPath= \"" + txtPath.Text + "\"";
            ExecuteCommandLine.ExecuteCommand(comd1);

            var comd2 = "net start \"" + txtName.Text + "\"";
            ExecuteCommandLine.ExecuteCommand(comd2);

            //btnInstall.Enabled = false;
            //btnUninstall.Enabled = true;
            var frmSuccess = new InformationForm();
            frmSuccess.Show();
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            var comd2 = "net stop  \"" + txtName.Text + "\"";
            ExecuteCommandLine.ExecuteCommand(comd2);

            var comd = "sc delete \"" + txtName.Text + "\"";
            ExecuteCommandLine.ExecuteCommand(comd);
            //btnInstall.Enabled = true;
            //btnUninstall.Enabled = false;
            var frmSuccess = new InformationForm();
            frmSuccess.Show();
        }
    }
}
