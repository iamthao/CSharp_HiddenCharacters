using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ICSharpCode.SharpZipLib.Zip;

namespace PcstUpdate
{
    public partial class frmMain : Form
    {
        private DirectoryInfo PcstDir;
        private string PCSTToolFormName = "PCSTToolForm.exe";
        private List<string> InogeUpdateFiles = new List<string> {@"Data\as.db"};
        public frmMain()
        {
            InitializeComponent();
            PcstDir = (new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory)).Parent;
            if (!bwUpdate.IsBusy)
            {
                bwUpdate.RunWorkerAsync();
            }
        }

        private void ClearDirectory(string path)
        {
            var di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        private void bwUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (
                    MessageBox.Show(e.Result.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) ==
                    DialogResult.Retry)
                {
                    bwUpdate.RunWorkerAsync();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                var pcstToolForm = Path.Combine(PcstDir.FullName, PCSTToolFormName);
                if (File.Exists(pcstToolForm))
                {
                    var processInfo = new ProcessStartInfo
                    {
                        FileName = PCSTToolFormName,
                        WorkingDirectory = PcstDir.FullName
                    };
                    Process.Start(processInfo);
                }
                Close();
            }
        }

        private void bwUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressDownload.Value = e.ProgressPercentage;
        }

        private void bwUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                bwUpdate.ReportProgress(0);
                string localFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp\\PcstUpdate.zip");
                string versionPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp\\PcstVersion.txt");
                string updatePcstApi = ConfigurationManager.AppSettings["UpdatePcstApi"];
                var webApiConnect = new WebApiConnect(updatePcstApi);

                var objVersion = webApiConnect.SendMessageToWebApi("GetPcstVersion", null);
                var version = (string)objVersion;

                var objFileSize = webApiConnect.SendMessageToWebApi("GetPcstFileSize", null);
                var fileSize = (long)objFileSize;
                bool alreadyDownload = File.Exists(versionPath) && File.ReadAllText(versionPath).Equals(version)
                                       && File.Exists(localFilePath) && fileSize == (new FileInfo(localFilePath)).Length;

                if (alreadyDownload ||
                    webApiConnect.DownloadPcstUpdate(localFilePath, fileSize, bwUpdate.ReportProgress))
                {
                    //Extract
                    var extractDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp\\Extract");
                    
                    if (!Directory.Exists(extractDir))
                        Directory.CreateDirectory(extractDir);
                    else
                    {
                        ClearDirectory(extractDir);
                    }

                    var fastZip = new FastZip();
                    fastZip.ExtractZip(localFilePath, extractDir, null);
                    if (!alreadyDownload)
                    {
                        File.WriteAllText(versionPath, version);
                    }
                    //copy to psct
                    bwUpdate.ReportProgress(100);
                    CopyDirectory(extractDir, PcstDir.FullName);
                    string pcstVersionPath = Path.Combine(PcstDir.FullName, "PcstVersion.txt");
                    File.WriteAllText(pcstVersionPath, version);
                }
                else
                {
                    throw new Exception("Cannot Download PcstUpdate!");
                }
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
            }
        }

        private void CopyDirectory(string root, string dest)
        {
            //exclude pcst update
            if (AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\').ToLower().Equals(dest.ToLower()))
                return;
            foreach (var directory in Directory.GetDirectories(root))
            {
                string dirName = Path.GetFileName(directory);
                if (!Directory.Exists(Path.Combine(dest, dirName)))
                {
                    Directory.CreateDirectory(Path.Combine(dest, dirName));
                }
                CopyDirectory(directory, Path.Combine(dest, dirName));
            }

            foreach (var file in Directory.GetFiles(root))
            {
                if(InogeUpdateFiles.Any(o => file.ToLower().EndsWith(o.ToLower())))
                    continue;
                File.Copy(file, Path.Combine(dest, Path.GetFileName(file)), true);
            }
        }
    }
}
