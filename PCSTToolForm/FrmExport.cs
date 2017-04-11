using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using PcstLib.Encrypt;
using PcstLib.Sqlite.Entities;
using PcstLib.Utility;

namespace PCSTToolForm
{
    public partial class FrmExport : Form
    {
        private Assessment _assessment;
        public FrmExport()
        {
            InitializeComponent();
        }
        public FrmExport(Assessment assessment)
        {
            InitializeComponent();
            _assessment = assessment;
            txtFileName.Text = _assessment.FileName;//+".backup";
        }
        private void btnBrowserData_Click(object sender, EventArgs e)
        {

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtLocation.Text = fbd.SelectedPath;
                   // string[] files = Directory.GetFiles(fbd.SelectedPath);

                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLocation.Text))
            {
                MessageBox.Show("File path is required.", "Error");
            }
            else if (!Directory.Exists(txtLocation.Text))
            {
                MessageBox.Show("File path not found.", "Error");
            }
            else if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("File name is required.", "Error");
            }
            else if (!CaculatorHelper.CheckFileNameValid(txtFileName.Text))
            {
                MessageBox.Show("File name is invalid.", "Error");
            }
            else 
            {
                string encyptKey = ConfigurationManager.AppSettings["EncyptKey"];
                if (string.IsNullOrEmpty(encyptKey))
                {
                    throw new Exception("EncyptKey not found in App.config");
                }
                string path = Path.Combine(txtLocation.Text, txtFileName.Text + ".backup");
                var data = new ExportData
                {
                    AssessmentData = _assessment.AssessmentData,
                    DisclosureFormData = _assessment.DisclosureFormData,
                    MemberNumber = _assessment.Mid

                };
                var json = JsonConvert.SerializeObject(data);
                var decryptData = EncryptHelper.Encrypt(json, encyptKey);

                var export = true;
                if (File.Exists(path))
                {
                    DialogResult dialogResult = MessageBox.Show(
                        "File exists in this folder. Do you want to replace it?", "Information", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        export = true;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        export = false;
                    }
                }
                if (export)
                {
                    using (var fs = File.Open(path, FileMode.OpenOrCreate))
                    {
                        using (StreamWriter s = new StreamWriter(fs))
                            s.WriteLine(decryptData);
                    }
                    MessageBox.Show("Export to file successfully!", "Information");
                    this.Close();
                }

               
            }

        }


        class ExportData
        {
            public string AssessmentData { get; set; }
            public string DisclosureFormData { get; set; }
            public string MemberNumber { get; set; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
       
    }
}
