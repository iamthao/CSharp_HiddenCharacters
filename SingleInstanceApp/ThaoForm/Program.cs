using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThaoForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        /// 
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

       [STAThread]
        static void Main()
        {
            Mutex mutex = new System.Threading.Mutex(false, "ThaoForm");
            try
            {
                if (mutex.WaitOne(0, false))
                {
                    // Run the application
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
                else
                {
                    //MessageBox.Show("An instance of the application is already running.");
                    //bringToFront("Form1");
                    // Bring other instance to front and exit. 
                   
                    Process current = Process.GetCurrentProcess();
                    var listProcess = Process.GetProcessesByName(current.ProcessName);

                    var allProcceses = Process.GetProcesses();


                    var i = 0;
                    var processIdText = "";
                    var title = "";
                    foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                    {
                        i++;
                        var path = process.MainModule.FileName.ToString();
                        if (process.Id != current.Id)
                        {
                            processIdText = processIdText + process.Id + ";";
                            title = title + process.MainWindowTitle;
                            if (!string.IsNullOrEmpty(process.MainWindowTitle))
                                bringToFront(process.MainWindowTitle);
                            return;
                        }
                    }
                    //var text ="- current process " +  current.ProcessName 
                    //    + "\n - Number process " + i
                    //    + " - " + processIdText + " - Title " + title
                    //    + "\n- CurrentId " + current.Id;
                    // MessageBox.Show(text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                if (mutex != null)
                {
                    mutex.Close();
                    mutex = null;
                }
            } 

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }

       public static void bringToFront(string title)
       {
           // Get a handle to the Calculator application.
           IntPtr handle = FindWindow(null, title);

           // Verify that Calculator is a running process.
           if (handle == IntPtr.Zero)
           {
               return;
           }

           // Make Calculator the foreground application
           SetForegroundWindow(handle);
       }
    }
}
