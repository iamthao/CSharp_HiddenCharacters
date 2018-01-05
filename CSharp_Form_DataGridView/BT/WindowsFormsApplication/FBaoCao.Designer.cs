namespace WindowsFormsApplication
{
    partial class FBaoCao
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTLapBaoCao = new System.Windows.Forms.Button();
            this.DTDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DTTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.BTThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTLapBaoCao);
            this.groupBox1.Controls.Add(this.DTDenNgay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DTTuNgay);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Báo Cáo Doanh Thu";
            // 
            // BTLapBaoCao
            // 
            this.BTLapBaoCao.Location = new System.Drawing.Point(479, 52);
            this.BTLapBaoCao.Name = "BTLapBaoCao";
            this.BTLapBaoCao.Size = new System.Drawing.Size(100, 23);
            this.BTLapBaoCao.TabIndex = 4;
            this.BTLapBaoCao.Text = "Lập Báo Cáo";
            this.BTLapBaoCao.UseVisualStyleBackColor = true;
            this.BTLapBaoCao.Click += new System.EventHandler(this.BTLapBaoCao_Click);
            // 
            // DTDenNgay
            // 
            this.DTDenNgay.Location = new System.Drawing.Point(381, 26);
            this.DTDenNgay.Name = "DTDenNgay";
            this.DTDenNgay.Size = new System.Drawing.Size(200, 20);
            this.DTDenNgay.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến Ngày";
            // 
            // DTTuNgay
            // 
            this.DTTuNgay.Location = new System.Drawing.Point(79, 26);
            this.DTTuNgay.Name = "DTTuNgay";
            this.DTTuNgay.Size = new System.Drawing.Size(200, 20);
            this.DTTuNgay.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ Ngày";
            // 
            // BTThoat
            // 
            this.BTThoat.Location = new System.Drawing.Point(527, 112);
            this.BTThoat.Name = "BTThoat";
            this.BTThoat.Size = new System.Drawing.Size(100, 23);
            this.BTThoat.TabIndex = 5;
            this.BTThoat.Text = "Thoát";
            this.BTThoat.UseVisualStyleBackColor = true;
            this.BTThoat.Click += new System.EventHandler(this.BTThoat_Click);
            // 
            // FBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(639, 152);
            this.Controls.Add(this.BTThoat);
            this.Controls.Add(this.groupBox1);
            this.Name = "FBaoCao";
            this.Text = "Báo Cáo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DTDenNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTTuNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTLapBaoCao;
        private System.Windows.Forms.Button BTThoat;
    }
}