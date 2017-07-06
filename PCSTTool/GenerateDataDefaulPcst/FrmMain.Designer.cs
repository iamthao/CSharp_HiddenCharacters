namespace GenerateDataDefaulPcst
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtSaveSQLiteFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.chkLanguage = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIcd = new System.Windows.Forms.CheckBox();
            this.chkCounty = new System.Windows.Forms.CheckBox();
            this.chkNpi = new System.Windows.Forms.CheckBox();
            this.chkRoute = new System.Windows.Forms.CheckBox();
            this.chkFrequency = new System.Windows.Forms.CheckBox();
            this.chkSection = new System.Windows.Forms.CheckBox();
            this.chkSectionQuestion = new System.Windows.Forms.CheckBox();
            this.grbGenerateInfo = new System.Windows.Forms.GroupBox();
            this.lblGenerate = new System.Windows.Forms.Label();
            this.grbDbStore = new System.Windows.Forms.GroupBox();
            this.btnGenerateDataSote = new System.Windows.Forms.Button();
            this.txtSqliteData = new System.Windows.Forms.TextBox();
            this.btnBrowserData = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ckProviderAgency = new System.Windows.Forms.CheckBox();
            this.ckProviderMpi = new System.Windows.Forms.CheckBox();
            this.grbGenerateInfo.SuspendLayout();
            this.grbDbStore.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(697, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(109, 6);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(582, 20);
            this.txtConnectionString.TabIndex = 1;
            this.txtConnectionString.Text = "server=172.16.100.15;port=3306;database=libris;uid=sa;password=C@mino123";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "MySql Connection";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(6, 79);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtSaveSQLiteFile
            // 
            this.txtSaveSQLiteFile.Location = new System.Drawing.Point(103, 44);
            this.txtSaveSQLiteFile.Name = "txtSaveSQLiteFile";
            this.txtSaveSQLiteFile.Size = new System.Drawing.Size(802, 20);
            this.txtSaveSQLiteFile.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Save SQLite File";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(921, 41);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(60, 23);
            this.btnBrowser.TabIndex = 6;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // chkLanguage
            // 
            this.chkLanguage.AutoSize = true;
            this.chkLanguage.BackColor = System.Drawing.SystemColors.Control;
            this.chkLanguage.Checked = true;
            this.chkLanguage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLanguage.Location = new System.Drawing.Point(103, 19);
            this.chkLanguage.Name = "chkLanguage";
            this.chkLanguage.Size = new System.Drawing.Size(74, 17);
            this.chkLanguage.TabIndex = 7;
            this.chkLanguage.Text = "Language";
            this.chkLanguage.UseVisualStyleBackColor = false;
            this.chkLanguage.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tables:";
            // 
            // chkIcd
            // 
            this.chkIcd.AutoSize = true;
            this.chkIcd.Checked = true;
            this.chkIcd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIcd.Location = new System.Drawing.Point(248, 19);
            this.chkIcd.Name = "chkIcd";
            this.chkIcd.Size = new System.Drawing.Size(44, 17);
            this.chkIcd.TabIndex = 9;
            this.chkIcd.Text = "ICD";
            this.chkIcd.UseVisualStyleBackColor = true;
            this.chkIcd.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkCounty
            // 
            this.chkCounty.AutoSize = true;
            this.chkCounty.Checked = true;
            this.chkCounty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCounty.Location = new System.Drawing.Point(183, 19);
            this.chkCounty.Name = "chkCounty";
            this.chkCounty.Size = new System.Drawing.Size(59, 17);
            this.chkCounty.TabIndex = 10;
            this.chkCounty.Text = "County";
            this.chkCounty.UseVisualStyleBackColor = true;
            this.chkCounty.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkNpi
            // 
            this.chkNpi.AutoSize = true;
            this.chkNpi.BackColor = System.Drawing.SystemColors.Control;
            this.chkNpi.Checked = true;
            this.chkNpi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNpi.Location = new System.Drawing.Point(298, 19);
            this.chkNpi.Name = "chkNpi";
            this.chkNpi.Size = new System.Drawing.Size(44, 17);
            this.chkNpi.TabIndex = 11;
            this.chkNpi.Text = "NPI";
            this.chkNpi.UseVisualStyleBackColor = false;
            this.chkNpi.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkRoute
            // 
            this.chkRoute.AutoSize = true;
            this.chkRoute.Checked = true;
            this.chkRoute.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRoute.Location = new System.Drawing.Point(348, 19);
            this.chkRoute.Name = "chkRoute";
            this.chkRoute.Size = new System.Drawing.Size(55, 17);
            this.chkRoute.TabIndex = 12;
            this.chkRoute.Text = "Route";
            this.chkRoute.UseVisualStyleBackColor = true;
            this.chkRoute.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkFrequency
            // 
            this.chkFrequency.AutoSize = true;
            this.chkFrequency.Checked = true;
            this.chkFrequency.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFrequency.Location = new System.Drawing.Point(409, 19);
            this.chkFrequency.Name = "chkFrequency";
            this.chkFrequency.Size = new System.Drawing.Size(76, 17);
            this.chkFrequency.TabIndex = 13;
            this.chkFrequency.Text = "Frequency";
            this.chkFrequency.UseVisualStyleBackColor = true;
            this.chkFrequency.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkSection
            // 
            this.chkSection.AutoSize = true;
            this.chkSection.Checked = true;
            this.chkSection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSection.Location = new System.Drawing.Point(491, 19);
            this.chkSection.Name = "chkSection";
            this.chkSection.Size = new System.Drawing.Size(62, 17);
            this.chkSection.TabIndex = 14;
            this.chkSection.Text = "Section";
            this.chkSection.UseVisualStyleBackColor = true;
            this.chkSection.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkSectionQuestion
            // 
            this.chkSectionQuestion.AutoSize = true;
            this.chkSectionQuestion.Checked = true;
            this.chkSectionQuestion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSectionQuestion.Location = new System.Drawing.Point(559, 19);
            this.chkSectionQuestion.Name = "chkSectionQuestion";
            this.chkSectionQuestion.Size = new System.Drawing.Size(107, 17);
            this.chkSectionQuestion.TabIndex = 15;
            this.chkSectionQuestion.Text = "Section Question";
            this.chkSectionQuestion.UseVisualStyleBackColor = true;
            this.chkSectionQuestion.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // grbGenerateInfo
            // 
            this.grbGenerateInfo.Controls.Add(this.lblGenerate);
            this.grbGenerateInfo.Controls.Add(this.chkIcd);
            this.grbGenerateInfo.Controls.Add(this.ckProviderMpi);
            this.grbGenerateInfo.Controls.Add(this.ckProviderAgency);
            this.grbGenerateInfo.Controls.Add(this.chkSectionQuestion);
            this.grbGenerateInfo.Controls.Add(this.btnGenerate);
            this.grbGenerateInfo.Controls.Add(this.chkSection);
            this.grbGenerateInfo.Controls.Add(this.txtSaveSQLiteFile);
            this.grbGenerateInfo.Controls.Add(this.chkFrequency);
            this.grbGenerateInfo.Controls.Add(this.label2);
            this.grbGenerateInfo.Controls.Add(this.chkRoute);
            this.grbGenerateInfo.Controls.Add(this.btnBrowser);
            this.grbGenerateInfo.Controls.Add(this.chkNpi);
            this.grbGenerateInfo.Controls.Add(this.chkLanguage);
            this.grbGenerateInfo.Controls.Add(this.chkCounty);
            this.grbGenerateInfo.Controls.Add(this.label3);
            this.grbGenerateInfo.Enabled = false;
            this.grbGenerateInfo.Location = new System.Drawing.Point(15, 33);
            this.grbGenerateInfo.Name = "grbGenerateInfo";
            this.grbGenerateInfo.Size = new System.Drawing.Size(998, 110);
            this.grbGenerateInfo.TabIndex = 16;
            this.grbGenerateInfo.TabStop = false;
            this.grbGenerateInfo.Text = "Generate Default Info";
            // 
            // lblGenerate
            // 
            this.lblGenerate.AutoSize = true;
            this.lblGenerate.Location = new System.Drawing.Point(87, 84);
            this.lblGenerate.Name = "lblGenerate";
            this.lblGenerate.Size = new System.Drawing.Size(71, 13);
            this.lblGenerate.TabIndex = 16;
            this.lblGenerate.Text = "Generating ...";
            this.lblGenerate.Visible = false;
            // 
            // grbDbStore
            // 
            this.grbDbStore.Controls.Add(this.btnGenerateDataSote);
            this.grbDbStore.Controls.Add(this.txtSqliteData);
            this.grbDbStore.Controls.Add(this.btnBrowserData);
            this.grbDbStore.Controls.Add(this.label4);
            this.grbDbStore.Location = new System.Drawing.Point(12, 160);
            this.grbDbStore.Name = "grbDbStore";
            this.grbDbStore.Size = new System.Drawing.Size(1001, 87);
            this.grbDbStore.TabIndex = 17;
            this.grbDbStore.TabStop = false;
            this.grbDbStore.Text = "Generate Dabase Store";
            // 
            // btnGenerateDataSote
            // 
            this.btnGenerateDataSote.Location = new System.Drawing.Point(6, 56);
            this.btnGenerateDataSote.Name = "btnGenerateDataSote";
            this.btnGenerateDataSote.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateDataSote.TabIndex = 17;
            this.btnGenerateDataSote.Text = "Generate";
            this.btnGenerateDataSote.UseVisualStyleBackColor = true;
            this.btnGenerateDataSote.Click += new System.EventHandler(this.btnGenerateDataSote_Click);
            // 
            // txtSqliteData
            // 
            this.txtSqliteData.Location = new System.Drawing.Point(103, 19);
            this.txtSqliteData.Name = "txtSqliteData";
            this.txtSqliteData.Size = new System.Drawing.Size(805, 20);
            this.txtSqliteData.TabIndex = 4;
            // 
            // btnBrowserData
            // 
            this.btnBrowserData.Location = new System.Drawing.Point(924, 16);
            this.btnBrowserData.Name = "btnBrowserData";
            this.btnBrowserData.Size = new System.Drawing.Size(60, 23);
            this.btnBrowserData.TabIndex = 6;
            this.btnBrowserData.Text = "Browser";
            this.btnBrowserData.UseVisualStyleBackColor = true;
            this.btnBrowserData.Click += new System.EventHandler(this.btnBrowserData_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Save SQLite File";
            // 
            // ckProviderAgency
            // 
            this.ckProviderAgency.AutoSize = true;
            this.ckProviderAgency.Checked = true;
            this.ckProviderAgency.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckProviderAgency.Location = new System.Drawing.Point(682, 19);
            this.ckProviderAgency.Name = "ckProviderAgency";
            this.ckProviderAgency.Size = new System.Drawing.Size(104, 17);
            this.ckProviderAgency.TabIndex = 15;
            this.ckProviderAgency.Text = "Provider Agency";
            this.ckProviderAgency.UseVisualStyleBackColor = true;
            this.ckProviderAgency.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // ckProviderMpi
            // 
            this.ckProviderMpi.AutoSize = true;
            this.ckProviderMpi.Checked = true;
            this.ckProviderMpi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckProviderMpi.Location = new System.Drawing.Point(801, 19);
            this.ckProviderMpi.Name = "ckProviderMpi";
            this.ckProviderMpi.Size = new System.Drawing.Size(85, 17);
            this.ckProviderMpi.TabIndex = 15;
            this.ckProviderMpi.Text = "Provider Mpi";
            this.ckProviderMpi.UseVisualStyleBackColor = true;
            this.ckProviderMpi.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 259);
            this.Controls.Add(this.grbDbStore);
            this.Controls.Add(this.grbGenerateInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.btnConnect);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Data Defaul PCST";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.grbGenerateInfo.ResumeLayout(false);
            this.grbGenerateInfo.PerformLayout();
            this.grbDbStore.ResumeLayout(false);
            this.grbDbStore.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtSaveSQLiteFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.CheckBox chkLanguage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIcd;
        private System.Windows.Forms.CheckBox chkCounty;
        private System.Windows.Forms.CheckBox chkNpi;
        private System.Windows.Forms.CheckBox chkRoute;
        private System.Windows.Forms.CheckBox chkFrequency;
        private System.Windows.Forms.CheckBox chkSection;
        private System.Windows.Forms.CheckBox chkSectionQuestion;
        private System.Windows.Forms.GroupBox grbGenerateInfo;
        private System.Windows.Forms.Label lblGenerate;
        private System.Windows.Forms.GroupBox grbDbStore;
        private System.Windows.Forms.Button btnGenerateDataSote;
        private System.Windows.Forms.TextBox txtSqliteData;
        private System.Windows.Forms.Button btnBrowserData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckProviderMpi;
        private System.Windows.Forms.CheckBox ckProviderAgency;
    }
}

