using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFunction
{
    public class ExecuteCommandLine
    {
        public static void ExecuteCommand(string command)
        {
            var proc1 = new ProcessStartInfo();
            string anyCommand;
            proc1.UseShellExecute = true;

            proc1.WorkingDirectory = @"C:\Windows\System32";

            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + command;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);
        }
    }
}
