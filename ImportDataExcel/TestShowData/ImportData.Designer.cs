namespace TestShowText
{
    partial class ImportData
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
            this.btnImportStatusReason = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPathOutput = new System.Windows.Forms.TextBox();
            this.btnOutput = new System.Windows.Forms.Button();
            this.btnImportListAction = new System.Windows.Forms.Button();
            this.btnTooltipRole = new System.Windows.Forms.Button();
            this.btnImportRoleDefault = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnImportStatusReason
            // 
            this.btnImportStatusReason.Location = new System.Drawing.Point(171, 62);
            this.btnImportStatusReason.Name = "btnImportStatusReason";
            this.btnImportStatusReason.Size = new System.Drawing.Size(138, 23);
            this.btnImportStatusReason.TabIndex = 1;
            this.btnImportStatusReason.Text = "Import Status Reason";
            this.btnImportStatusReason.UseVisualStyleBackColor = true;
            this.btnImportStatusReason.Click += new System.EventHandler(this.btnImportStatusReason_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Path Input";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(74, 6);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(453, 20);
            this.txtPath.TabIndex = 4;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(533, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(94, 23);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "Input...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Path Out";
            // 
            // txtPathOutput
            // 
            this.txtPathOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathOutput.Location = new System.Drawing.Point(74, 32);
            this.txtPathOutput.Name = "txtPathOutput";
            this.txtPathOutput.Size = new System.Drawing.Size(453, 20);
            this.txtPathOutput.TabIndex = 7;
            // 
            // btnOutput
            // 
            this.btnOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutput.Location = new System.Drawing.Point(533, 30);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(94, 23);
            this.btnOutput.TabIndex = 8;
            this.btnOutput.Text = "Output...";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnImportListAction
            // 
            this.btnImportListAction.Location = new System.Drawing.Point(15, 62);
            this.btnImportListAction.Name = "btnImportListAction";
            this.btnImportListAction.Size = new System.Drawing.Size(138, 23);
            this.btnImportListAction.TabIndex = 9;
            this.btnImportListAction.Text = "Import List Action";
            this.btnImportListAction.UseVisualStyleBackColor = true;
            this.btnImportListAction.Click += new System.EventHandler(this.btnImportListAction_Click);
            // 
            // btnTooltipRole
            // 
            this.btnTooltipRole.Location = new System.Drawing.Point(326, 62);
            this.btnTooltipRole.Name = "btnTooltipRole";
            this.btnTooltipRole.Size = new System.Drawing.Size(138, 23);
            this.btnTooltipRole.TabIndex = 10;
            this.btnTooltipRole.Text = "Import TooltipRole";
            this.btnTooltipRole.UseVisualStyleBackColor = true;
            this.btnTooltipRole.Click += new System.EventHandler(this.btnTooltipRole_Click);
            // 
            // btnImportRoleDefault
            // 
            this.btnImportRoleDefault.Location = new System.Drawing.Point(489, 62);
            this.btnImportRoleDefault.Name = "btnImportRoleDefault";
            this.btnImportRoleDefault.Size = new System.Drawing.Size(138, 23);
            this.btnImportRoleDefault.TabIndex = 11;
            this.btnImportRoleDefault.Text = "Import Role Default";
            this.btnImportRoleDefault.UseVisualStyleBackColor = true;
            this.btnImportRoleDefault.Click += new System.EventHandler(this.btnImportRoleDefault_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Status: ";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(71, 97);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(67, 17);
            this.lbStatus.TabIndex = 13;
            this.lbStatus.Text = "lbStatus";
            // 
            // ImportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 120);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnImportRoleDefault);
            this.Controls.Add(this.btnTooltipRole);
            this.Controls.Add(this.btnImportListAction);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.txtPathOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImportStatusReason);
            this.Name = "ImportData";
            this.Text = "Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportStatusReason;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPathOutput;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Button btnImportListAction;
        private System.Windows.Forms.Button btnTooltipRole;
        private System.Windows.Forms.Button btnImportRoleDefault;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbStatus;
    }
}

