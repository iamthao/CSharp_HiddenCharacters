using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCSTToolForm
{
    enum ShowWindowEnum
    {
        Hide = 0,
        ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
        Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
        Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
        Restore = 9, ShowDefault = 10, ForceMinimized = 11
    };
    struct Windowplacement
    {
        public int length;
        public int flags;
        public int showCmd;
        public System.Drawing.Point ptMinPosition;
        public System.Drawing.Point ptMaxPosition;
        public System.Drawing.Rectangle rcNormalPosition;
    }
    static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref Windowplacement lpwndpl);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>       
        
        [STAThread]
        static void Main()
        {
            var pcsttoolProcess = Process.GetProcessesByName("pcsttoolform");

            if (pcsttoolProcess.Length>1)
            {
                var bProcess = pcsttoolProcess.OrderBy(o => o.StartTime).FirstOrDefault();
                var placement = new Windowplacement();
                GetWindowPlacement(bProcess.MainWindowHandle, ref placement);
                if (placement.showCmd == 2)
                {
                    ShowWindow(bProcess.MainWindowHandle, ShowWindowEnum.Restore);
                }
                SetForegroundWindow(bProcess.MainWindowHandle);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
