using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceTest
{
    public partial class Service1 : ServiceBase
    {
        private Timer _timer = null;
        private static bool _isRunning = false;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _timer = new System.Threading.Timer(Run, null, 0, 30000);
        }

        private void Run(Object state)
        {
            if (!_isRunning)
            {
                _isRunning = true;
                try
                {
                    WriteFile.WriteFileLog();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _isRunning = false;
                }               
            }
        }

        protected override void OnStop()
        {
            _timer.Dispose();
        }
    }
}
