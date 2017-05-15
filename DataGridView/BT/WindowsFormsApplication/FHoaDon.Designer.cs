namespace WindowsFormsApplication
{
    partial class FHoaDon
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
            this.LBTongTien = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LBNgayHD = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CBTrangThai = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LBHoaDonId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LBSDT = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.LBTenKH = new System.Windows.Forms.Label();
            this.LBEmail = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LBKhachHangId = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.GVChiTietHD = new System.Windows.Forms.DataGridView();
            this.IdSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTSuaHD = new System.Windows.Forms.Button();
            this.BTThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVChiTietHD)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LBTongTien);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LBNgayHD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CBTrangThai);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.LBHoaDonId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hóa Đơn";
            // 
            // LBTongTien
            // 
            this.LBTongTien.AutoSize = true;
            this.LBTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTongTien.ForeColor = System.Drawing.Color.Blue;
            this.LBTongTien.Location = new System.Drawing.Point(373, 55);
            this.LBTongTien.Name = "LBTongTien";
            this.LBTongTien.Size = new System.Drawing.Size(59, 20);
            this.LBTongTien.TabIndex = 7;
            this.LBTongTien.Text = "NoText";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tổng Tiền";
            // 
            // LBNgayHD
            // 
            this.LBNgayHD.AutoSize = true;
            this.LBNgayHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBNgayHD.ForeColor = System.Drawing.Color.Blue;
            this.LBNgayHD.Location = new System.Drawing.Point(108, 55);
            this.LBNgayHD.Name = "LBNgayHD";
            this.LBNgayHD.Size = new System.Drawing.Size(59, 20);
            this.LBNgayHD.TabIndex = 5;
            this.LBNgayHD.Text = "NoText";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày:";
            // 
            // CBTrangThai
            // 
            this.CBTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBTrangThai.FormattingEnabled = true;
            this.CBTrangThai.Location = new System.Drawing.Point(377, 24);
            this.CBTrangThai.Name = "CBTrangThai";
            this.CBTrangThai.Size = new System.Drawing.Size(200, 21);
            this.CBTrangThai.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trạng Thái Hóa Đơn";
            // 
            // LBHoaDonId
            // 
            this.LBHoaDonId.AutoSize = true;
            this.LBHoaDonId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBHoaDonId.ForeColor = System.Drawing.Color.Blue;
            this.LBHoaDonId.Location = new System.Drawing.Point(108, 22);
            this.LBHoaDonId.Name = "LBHoaDonId";
            this.LBHoaDonId.Size = new System.Drawing.Size(59, 20);
            this.LBHoaDonId.TabIndex = 1;
            this.LBHoaDonId.Text = "NoText";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hóa Đơn Id:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LBSDT);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.LBTenKH);
            this.groupBox2.Controls.Add(this.LBEmail);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.LBKhachHangId);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(607, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Khách Hàng";
            // 
            // LBSDT
            // 
            this.LBSDT.AutoSize = true;
            this.LBSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBSDT.ForeColor = System.Drawing.Color.Blue;
            this.LBSDT.Location = new System.Drawing.Point(373, 55);
            this.LBSDT.Name = "LBSDT";
            this.LBSDT.Size = new System.Drawing.Size(59, 20);
            this.LBSDT.TabIndex = 8;
            this.LBSDT.Text = "NoText";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(335, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "SĐT:";
            // 
            // LBTenKH
            // 
            this.LBTenKH.AutoSize = true;
            this.LBTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTenKH.ForeColor = System.Drawing.Color.Blue;
            this.LBTenKH.Location = new System.Drawing.Point(373, 22);
            this.LBTenKH.Name = "LBTenKH";
            this.LBTenKH.Size = new System.Drawing.Size(59, 20);
            this.LBTenKH.TabIndex = 6;
            this.LBTenKH.Text = "NoText";
            // 
            // LBEmail
            // 
            this.LBEmail.AutoSize = true;
            this.LBEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBEmail.ForeColor = System.Drawing.Color.Blue;
            this.LBEmail.Location = new System.Drawing.Point(108, 55);
            this.LBEmail.Name = "LBEmail";
            this.LBEmail.Size = new System.Drawing.Size(59, 20);
            this.LBEmail.TabIndex = 5;
            this.LBEmail.Text = "NoText";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Email:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tên Khách Hàng:";
            // 
            // LBKhachHangId
            // 
            this.LBKhachHangId.AutoSize = true;
            this.LBKhachHangId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBKhachHangId.ForeColor = System.Drawing.Color.Blue;
            this.LBKhachHangId.Location = new System.Drawing.Point(108, 22);
            this.LBKhachHangId.Name = "LBKhachHangId";
            this.LBKhachHangId.Size = new System.Drawing.Size(59, 20);
            this.LBKhachHangId.TabIndex = 1;
            this.LBKhachHangId.Text = "NoText";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Khách Hàng Id:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 221);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Chi Tiết Sản Phẩm Đặt Mua";
            // 
            // GVChiTietHD
            // 
            this.GVChiTietHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVChiTietHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdSP,
            this.TenSP,
            this.SoLuong,
            this.Gia,
            this.ThanhTien});
            this.GVChiTietHD.Location = new System.Drawing.Point(12, 237);
            this.GVChiTietHD.Name = "GVChiTietHD";
            this.GVChiTietHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GVChiTietHD.Size = new System.Drawing.Size(607, 280);
            this.GVChiTietHD.TabIndex = 8;
            // 
            // IdSP
            // 
            this.IdSP.DataPropertyName = "IdSP";
            this.IdSP.HeaderText = "Id Sản Phẩm";
            this.IdSP.Name = "IdSP";
            // 
            // TenSP
            // 
            this.TenSP.DataPropertyName = "TenSP";
            this.TenSP.HeaderText = "Tên Sản Phẩm";
            this.TenSP.Name = "TenSP";
            this.TenSP.Width = 120;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.Name = "SoLuong";
            // 
            // Gia
            // 
            this.Gia.DataPropertyName = "Gia";
            this.Gia.HeaderText = "Giá";
            this.Gia.Name = "Gia";
            this.Gia.Width = 120;
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "Thành Tiền";
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.Width = 120;
            // 
            // BTSuaHD
            // 
            this.BTSuaHD.Location = new System.Drawing.Point(405, 523);
            this.BTSuaHD.Name = "BTSuaHD";
            this.BTSuaHD.Size = new System.Drawing.Size(75, 23);
            this.BTSuaHD.TabIndex = 9;
            this.BTSuaHD.Text = "Sửa";
            this.BTSuaHD.UseVisualStyleBackColor = true;
            this.BTSuaHD.Click += new System.EventHandler(this.BTSuaHD_Click);
            // 
            // BTThoat
            // 
            this.BTThoat.Location = new System.Drawing.Point(544, 523);
            this.BTThoat.Name = "BTThoat";
            this.BTThoat.Size = new System.Drawing.Size(75, 23);
            this.BTThoat.TabIndex = 10;
            this.BTThoat.Text = "Thoát";
            this.BTThoat.UseVisualStyleBackColor = true;
            this.BTThoat.Click += new System.EventHandler(this.BTThoat_Click);
            // 
            // FHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(631, 556);
            this.Controls.Add(this.BTThoat);
            this.Controls.Add(this.BTSuaHD);
            this.Controls.Add(this.GVChiTietHD);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FHoaDon";
            this.Text = "Thông Tin Hóa Đơn";
            this.Load += new System.EventHandler(this.FHoaDon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVChiTietHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBNgayHD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBTrangThai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LBHoaDonId;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LBEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LBKhachHangId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LBSDT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LBTenKH;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView GVChiTietHD;
        private System.Windows.Forms.Button BTSuaHD;
        private System.Windows.Forms.Button BTThoat;
        private System.Windows.Forms.Label LBTongTien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
    }
}