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
using ReadFileCsv;

namespace ReadCsvForm
{
    public partial class Form1 : Form
    {
        private FileDialog _fileDialog;
        private FileInfo _fileInfo;
        private int _readLengthByte = 1024 * 1024;
        private byte[] _byteFiles;
        private long _lengthByte = 0;
        private int _offset = 0;
        public Form1()
        {
            InitializeComponent();
            _fileDialog = new OpenFileDialog { Filter = @".CSV Files (.csv)|*.csv" };
            txtResult.ScrollBars = ScrollBars.Vertical;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var result = _fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPath.Text = _fileDialog.FileName;
            }
            
        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            txtResult.SelectionStart = txtResult.Text.Length;
            txtResult.ScrollToCaret();
            txtResult.Refresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtPath.Text))
            {
                MessageBox.Show(@"The file does not existed.");
            }
            _fileInfo = new FileInfo(txtPath.Text);
            _lengthByte = _fileInfo.Length;
            List<ReadCsv.User> list = new List<ReadCsv.User>();
            ReadCsv.ReadFileCsv(txtPath.Text, ref list);
            foreach (var item in list)
            {
                txtResult.AppendText(item.Id + " - " + item.Name + " - " + item.Phone);
                txtResult.AppendText(Environment.NewLine);
            }
        }


    }
}
