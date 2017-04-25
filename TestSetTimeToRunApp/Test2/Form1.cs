using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            SetUpTimer(new TimeSpan(17, 06, 00));
        }

        private static System.Threading.Timer timer;
        private  void SetUpTimer(TimeSpan alertTime)
        {
            DateTime current = DateTime.Now;
            TimeSpan timeToGo = alertTime - current.TimeOfDay;
            if (timeToGo < TimeSpan.Zero)
            {
                return;//time already passed
            }
            timer = new System.Threading.Timer(x =>
            {
                SomeMethodRunsAt1600();
            }, null, timeToGo, Timeout.InfiniteTimeSpan);
        }

        private  void SomeMethodRunsAt1600()
        {
            var now = DateTime.Now;
            //Console.WriteLine(now.ToString("MM/dd/yyyy HH:mm:ss"));
            LogText(now);

            SetUpTimer(new TimeSpan(now.Hour, now.Minute, now.Second + 15));

        }

        private void textBox1_VisibleChanged(object sender, EventArgs e)
        {
            if (txtResult.Visible)
            {
                txtResult.SelectionStart = txtResult.TextLength;
                txtResult.ScrollToCaret();
            }
        }

        delegate void SetTextCallback(DateTime now);
        public void LogText(DateTime now)
        {
             this.Invoke(new MethodInvoker(delegate
             {
                 txtResult.AppendText(Environment.NewLine + now.ToString("MM/dd/yyyy HH:mm:ss"));

                 txtResult.ScrollToCaret();
             }));    
        }
    }
}
