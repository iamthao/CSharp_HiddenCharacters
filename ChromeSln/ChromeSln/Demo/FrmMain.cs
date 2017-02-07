using System;
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
using Demo.SelfHost;
using Microsoft.Owin.Hosting;

namespace Demo
{
    public partial class FrmMain : Form
    {
        private string _baseAddress = "http://localhost";
        private string _port = "9000";
        public FrmMain()
        {
            InitializeComponent();
            
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            SelfHost();
        }

        private void SelfHost()
        {
            string baseAddress = _baseAddress + ":" + _port + "/";
            // Start OWIN host 
            var api = WebApp.Start<Startup>(url: baseAddress);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void btnShowPCST_Click(object sender, EventArgs e)
        {
            var form = new FrmPcstForm();
            form.ShowDialog();
        }

        private void btnPcstDynamic_Click(object sender, EventArgs e)
        {
            var form = new FrmPcstFormDynamic();
            form.ShowDialog();
        }
    }

    
}
