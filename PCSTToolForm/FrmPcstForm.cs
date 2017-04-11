using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Microsoft.Owin.Hosting;
using PCSTToolForm.SelfHost;
using System.IO;

namespace PCSTToolForm
{
    public partial class FrmPcstForm : Form
    {

        private ChromiumWebBrowser _chromeBrowser;

        private EventPcstForm _eventPcstForm;
        private string _path = string.Empty;
        private string pathFileScriptSource = Directory.GetCurrentDirectory() + "\\Resource\\pcst\\pcst.js";
        private string pathFileScriptTemp = Directory.GetCurrentDirectory() + "\\Resource\\pcst\\pcstTemp.js";

        public int _assessmentId;
        public FrmMain _frmMain;
        public FrmPcstForm(int assessmentId, FrmMain frmMain)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.Manual;
            Location = new Point(100, 50);
            _assessmentId = assessmentId;
            _frmMain = frmMain;

            InitializeChromium();
        }

        public FrmPcstForm()
        {            
            InitializeComponent();

            StartPosition = FormStartPosition.Manual;
            Location = new Point(100, 50);
            //_assessmentId = assessmentId;
            
            InitializeChromium();
        }

        private void EditFileScriptPcst()
        {
            //If File Temp not exist is copy (the first)
            if (!File.Exists(pathFileScriptTemp))
            {
                File.Copy(pathFileScriptSource, pathFileScriptTemp);
            }
                                          
            //If File Source exist is delete and then copy again
            if (File.Exists(pathFileScriptSource))
            {
                File.Delete(pathFileScriptSource);
            }
            File.Copy(pathFileScriptTemp, pathFileScriptSource);

            string[] lines = File.ReadAllLines(pathFileScriptSource);
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace("var assessmentId = 0;", "var assessmentId = "+ _assessmentId+";");
            }

            File.WriteAllLines(pathFileScriptSource, lines);

        }

        private void FrmPcstForm_Load(object sender, EventArgs e)
        {
            //SelfHost();

        }

        private void CloseForm()
        {
            this.Invoke(new Action(Close));
        }

        private void InitializeChromium()
        {
            //Edit file to add script
            EditFileScriptPcst();
            _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resource", "PCSTForm.html");
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
            //if (loadingStateChangedEventArgs.CanReload)
            //{
                //var sb = new StringBuilder();
                //sb.AppendLine("function activate() {");
                //sb.AppendLine("     $http.get('http://localhost:9000/api/Assessment?id=' +" + _assessmentId + " ).then(function (result) {");
                //sb.AppendLine("         if (result && result.data) {");
                //sb.AppendLine("             vm.RequestNo = result.data.RequestNo;");
                //sb.AppendLine("             vm.AssessmentPcsId = result.data.AssessmentPcsId;");
                //sb.AppendLine("             vm.AssessmentName = result.data.AssessmentName;");
                //sb.AppendLine("             vm.RequestId = result.data.Id;");
                //sb.AppendLine("             vm.PcsVersion = result.data.PcsVersion;");
                //sb.AppendLine("             handleSectionList(result.data);");
                //sb.AppendLine("         }");
                //sb.AppendLine("     });");
                //sb.AppendLine("     installGridPhysician();");
                //sb.AppendLine(" }");              
                //_chromeBrowser.ExecuteScriptAsync(sb.ToString());
            //}

            //var sb = new StringBuilder();
            //sb.AppendLine("function activate123() {");

            //sb.AppendLine(" }");
            //_chromeBrowser.ExecuteScriptAsync(sb.ToString());
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
