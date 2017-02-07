namespace Demo
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
            this.btnShowPCST = new System.Windows.Forms.Button();
            this.btnPcstDynamic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowPCST
            // 
            this.btnShowPCST.Location = new System.Drawing.Point(382, 149);
            this.btnShowPCST.Name = "btnShowPCST";
            this.btnShowPCST.Size = new System.Drawing.Size(75, 23);
            this.btnShowPCST.TabIndex = 0;
            this.btnShowPCST.Text = "Show PCST";
            this.btnShowPCST.UseVisualStyleBackColor = true;
            this.btnShowPCST.Click += new System.EventHandler(this.btnShowPCST_Click);
            // 
            // btnPcstDynamic
            // 
            this.btnPcstDynamic.Location = new System.Drawing.Point(681, 149);
            this.btnPcstDynamic.Name = "btnPcstDynamic";
            this.btnPcstDynamic.Size = new System.Drawing.Size(125, 23);
            this.btnPcstDynamic.TabIndex = 1;
            this.btnPcstDynamic.Text = "Show PCST Dynamic";
            this.btnPcstDynamic.UseVisualStyleBackColor = true;
            this.btnPcstDynamic.Click += new System.EventHandler(this.btnPcstDynamic_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.btnPcstDynamic);
            this.Controls.Add(this.btnShowPCST);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowPCST;
        private System.Windows.Forms.Button btnPcstDynamic;
    }
}

