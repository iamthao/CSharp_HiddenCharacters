using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace Demo
{
    public partial class FrmPcstFormDynamic : Form
    {
        public FrmPcstFormDynamic()
        {
            InitializeComponent();
            var htmlPanel = new HtmlPanel();
            htmlPanel.Text = "<p><h1>Hello World</h1>This is html rendered text</p>";
            htmlPanel.Dock = DockStyle.Fill;
            Controls.Add(htmlPanel);
        }

        private void FrmPcstFormDynamic_Load(object sender, EventArgs e)
        {

        }
    }
}
