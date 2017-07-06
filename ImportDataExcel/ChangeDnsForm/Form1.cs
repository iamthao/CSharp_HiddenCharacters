using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestFunction;

namespace ChangeDnsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(1000, 500);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            var cardName = txtCardName.Text;
            var dns1 = txtDns1.Text;
            var dns2 = txtDns2.Text;
            SetDnsNetwork.RunChangeDns(cardName, dns1, dns2);
            var frmSuccess = new InformationForm();
            frmSuccess.Show();
            
        }

        public void CloseForm()
        {
            Application.Exit();
        }
    }
}
