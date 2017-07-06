using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeDnsForm
{
    public partial class InformationForm : Form
    {
        public InformationForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(1035, 535);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm1 = new Form1();
            frm1.CloseForm();
            
        }
    }
}
