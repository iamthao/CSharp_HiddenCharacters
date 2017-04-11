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
            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("File name is required.", "Error", MessageBoxButtons.OK);
            }
            else if (!CaculatorHelper.CheckFileNameValid(txtFileName.Text))
            {
                MessageBox.Show("File name is invalid.", "Error", MessageBoxButtons.OK);
            }
            else
            {             
                this.Close();          
                var id = _assessmentService.NewRecord(txtFileName.Text);
                _frmMain.RefreshDataForGridFromAnotherForm();

                var frmPcst = new FrmPcstForm(id, _frmMain);
                frmPcst.Show();
            }
        }



    }
}
