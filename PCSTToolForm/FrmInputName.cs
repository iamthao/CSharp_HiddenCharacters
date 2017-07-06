using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PcstLib.Services;
using PcstLib.Sqlite;
using PcstLib.Utility;

namespace PCSTToolForm
{
    public partial class FrmInputName : Form
    {
        private readonly AssessmentService _assessmentService = new AssessmentService();
        public FrmMain _frmMain;
        public FrmInputName(FrmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(400, 300);
        }
        public FrmInputName()
        {
            InitializeComponent();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFileName.Text.Trim()))
            {
                MessageBox.Show("File name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!CaculatorHelper.CheckFileNameValid(txtFileName.Text))
            {
                MessageBox.Show("File name is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (CheckNameExist(txtFileName.Text))
            {
                MessageBox.Show("File name already existed in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var fileName = txtFileName.Text;
                this.Close();
                var id = _assessmentService.NewRecord(fileName);
                _frmMain.RefreshDataForGridFromAnotherForm();

                var frmPcst = new FrmPcstForm(id, _frmMain);
                frmPcst.ShowDialog();
            }
        }

        private bool CheckNameExist(string fileName)
        {
            return _assessmentService.CheckNameExist(fileName);
        }


    }
}
