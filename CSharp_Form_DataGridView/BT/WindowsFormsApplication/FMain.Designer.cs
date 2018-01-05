namespace WindowsFormsApplication
{
    partial class FMain
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
            this.BTQuanLySP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNhapHang = new System.Windows.Forms.Button();
            this.BTQuanLyHD = new System.Windows.Forms.Button();
            this.BTBaoCaoDT = new System.Windows.Forms.Button();
            this.BTThongKeTonKho = new System.Windows.Forms.Button();
            this.BTThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTQuanLySP
            // 
            this.BTQuanLySP.Location = new System.Drawing.Point(110, 70);
            this.BTQuanLySP.Name = "BTQuanLySP";
            this.BTQuanLySP.Size = new System.Drawing.Size(297, 52);
            this.BTQuanLySP.TabIndex = 0;
            this.BTQuanLySP.Text = "Quản Lý Sản Phẩm";
            this.BTQuanLySP.UseVisualStyleBackColor = true;
            this.BTQuanLySP.Click += new System.EventHandler(this.BTQuanLySP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(465, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quản Lý Cửa Hàng Điện Máy";
            // 
            // BTNhapHang
            // 
            this.BTNhapHang.Location = new System.Drawing.Point(110, 128);
            this.BTNhapHang.Name = "BTNhapHang";
            this.BTNhapHang.Size = new System.Drawing.Size(297, 52);
            this.BTNhapHang.TabIndex = 2;
            this.BTNhapHang.Text = "Nhập Hàng";
            this.BTNhapHang.UseVisualStyleBackColor = true;
            this.BTNhapHang.Click += new System.EventHandler(this.BTNhapHang_Click);
            // 
            // BTQuanLyHD
            // 
            this.BTQuanLyHD.Location = new System.Drawing.Point(110, 186);
            this.BTQuanLyHD.Name = "BTQuanLyHD";
            this.BTQuanLyHD.Size = new System.Drawing.Size(297, 52);
            this.BTQuanLyHD.TabIndex = 3;
            this.BTQuanLyHD.Text = "Quản Lý Hóa Đơn";
            this.BTQuanLyHD.UseVisualStyleBackColor = true;
            this.BTQuanLyHD.Click += new System.EventHandler(this.BTQuanLyHD_Click);
            // 
            // BTBaoCaoDT
            // 
            this.BTBaoCaoDT.Location = new System.Drawing.Point(110, 244);
            this.BTBaoCaoDT.Name = "BTBaoCaoDT";
            this.BTBaoCaoDT.Size = new System.Drawing.Size(297, 52);
            this.BTBaoCaoDT.TabIndex = 4;
            this.BTBaoCaoDT.Text = "Báo Cáo Doanh Thu";
            this.BTBaoCaoDT.UseVisualStyleBackColor = true;
            this.BTBaoCaoDT.Click += new System.EventHandler(this.BTBaoCaoDT_Click);
            // 
            // BTThongKeTonKho
            // 
            this.BTThongKeTonKho.Location = new System.Drawing.Point(110, 302);
            this.BTThongKeTonKho.Name = "BTThongKeTonKho";
            this.BTThongKeTonKho.Size = new System.Drawing.Size(297, 52);
            this.BTThongKeTonKho.TabIndex = 5;
            this.BTThongKeTonKho.Text = "Thống Kê Tồn Kho";
            this.BTThongKeTonKho.UseVisualStyleBackColor = true;
            this.BTThongKeTonKho.Click += new System.EventHandler(this.BTThongKeTonKho_Click);
            // 
            // BTThoat
            // 
            this.BTThoat.Location = new System.Drawing.Point(110, 360);
            this.BTThoat.Name = "BTThoat";
            this.BTThoat.Size = new System.Drawing.Size(297, 52);
            this.BTThoat.TabIndex = 6;
            this.BTThoat.Text = "Thoát";
            this.BTThoat.UseVisualStyleBackColor = true;
            this.BTThoat.Click += new System.EventHandler(this.BTThoat_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(517, 426);
            this.Controls.Add(this.BTThoat);
            this.Controls.Add(this.BTThongKeTonKho);
            this.Controls.Add(this.BTBaoCaoDT);
            this.Controls.Add(this.BTQuanLyHD);
            this.Controls.Add(this.BTNhapHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTQuanLySP);
            this.Name = "FMain";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTQuanLySP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNhapHang;
        private System.Windows.Forms.Button BTQuanLyHD;
        private System.Windows.Forms.Button BTBaoCaoDT;
        private System.Windows.Forms.Button BTThongKeTonKho;
        private System.Windows.Forms.Button BTThoat;

    }
}