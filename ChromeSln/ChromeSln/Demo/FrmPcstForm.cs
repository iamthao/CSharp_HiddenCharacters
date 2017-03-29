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
using CefSharp;
using CefSharp.WinForms;

namespace Demo
{
    public partial class FrmPcstForm : Form
    {
        private ChromiumWebBrowser _chromeBrowser;
        private EventPcstForm _eventPcstForm;
        private string _path = string.Empty;
        public FrmPcstForm()
        {
            InitializeComponent();
            InitializeChromium();
        }

        private void FrmPcstForm_Load(object sender, EventArgs e)
        {
            
            
        }

        private void CloseForm()
        {
            this.Invoke(new Action(Close));
        }


        private void InitializeChromium()
        {
            _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resource", "test.html");
            if (!Cef.IsInitialized)
            {
                var cefSettings = new CefSettings();
                Cef.Initialize(cefSettings);
            }

            _chromeBrowser = new ChromiumWebBrowser(_path);
            
            _chromeBrowser.LoadingStateChanged += ChromeBrowserOnLoadingStateChanged;
            _eventPcstForm = new EventPcstForm(_chromeBrowser, CloseForm);
            _chromeBrowser.RegisterJsObject("winformObj", _eventPcstForm);

            Controls.Add(_chromeBrowser);
            _chromeBrowser.Dock = DockStyle.Fill;
            ChromeDevToolsSystemMenu.CreateSysMenu(this);


        }

        private void ChromeBrowserOnLoadingStateChanged(object sender, LoadingStateChangedEventArgs loadingStateChangedEventArgs)
        {
            //Loading complete.
            if (loadingStateChangedEventArgs.CanReload)
            {
                var sb = new StringBuilder();
                sb.AppendLine("function getDataPcst() {");
                sb.AppendLine("     // create a JS object");
                sb.AppendLine("     var person = {firstName:'John', lastName:'Maclaine', age:23, eyeColor:'blue'};");
                sb.AppendLine("");
                sb.AppendLine("     // Important: convert object to string before returning to C#");
                sb.AppendLine("     return JSON.stringify(person);");
                sb.AppendLine("}");
                _chromeBrowser.ExecuteScriptAsync(sb.ToString());
            }

        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // Test if the About item was selected from the system menu
            if ((m.Msg == ChromeDevToolsSystemMenu.WM_SYSCOMMAND) && ((int)m.WParam == ChromeDevToolsSystemMenu.SYSMENU_CHROME_DEV_TOOLS))
            {
                _chromeBrowser.ShowDevTools();
            }
        }
    }

    
}
