namespace WindowsFormsApplication
{
    partial class FNhapHang
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
            this.TBGhiChu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DTNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.CBNhaCC = new System.Windows.Forms.ComboBox();
            this.CBKho = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GVDanhSachSP = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTHienTatCa = new System.Windows.Forms.Button();
            this.BTTim = new System.Windows.Forms.Button();
            this.TBTenSP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LBTongTien = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TBGia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.GVChiTietNhap = new System.Windows.Forms.DataGridView();
            this.IdSPNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSPNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTCapNhat = new System.Windows.Forms.Button();
            this.TBSoLuong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BTQuaPhai = new System.Windows.Forms.Button();
            this.BTQuaTrai = new System.Windows.Forms.Button();
            this.BTLapPhieuNhap = new System.Windows.Forms.Button();
            this.BTThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVDanhSachSP)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVChiTietNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TBGhiChu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DTNgayNhap);
            this.groupBox1.Controls.Add(this.CBNhaCC);
            this.groupBox1.Controls.Add(this.CBKho);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(908, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Nhập Hàng";
            // 
            // TBGhiChu
            // 
            this.TBGhiChu.Location = new System.Drawing.Point(98, 53);
            this.TBGhiChu.Multiline = true;
            this.TBGhiChu.Name = "TBGhiChu";
            this.TBGhiChu.Size = new System.Drawing.Size(790, 76);
            this.TBGhiChu.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ghi Chú";
            // 
            // DTNgayNhap
            // 
            this.DTNgayNhap.Location = new System.Drawing.Point(738, 27);
            this.DTNgayNhap.Name = "DTNgayNhap";
            this.DTNgayNhap.Size = new System.Drawing.Size(150, 20);
            this.DTNgayNhap.TabIndex = 5;
            // 
            // CBNhaCC
            // 
            this.CBNhaCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBNhaCC.FormattingEnabled = true;
            this.CBNhaCC.Location = new System.Drawing.Point(421, 26);
            this.CBNhaCC.Name = "CBNhaCC";
            this.CBNhaCC.Size = new System.Drawing.Size(150, 21);
            this.CBNhaCC.TabIndex = 4;
            // 
            // CBKho
            // 
            this.CBKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBKho.FormattingEnabled = true;
            this.CBKho.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CBKho.Location = new System.Drawing.Point(98, 26);
            this.CBKho.Name = "CBKho";
            this.CBKho.Size = new System.Drawing.Size(150, 21);
            this.CBKho.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(650, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày Nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhà Cung Cấp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kho";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GVDanhSachSP);
            this.groupBox2.Controls.Add(this.BTHienTatCa);
            this.groupBox2.Controls.Add(this.BTTim);
            this.groupBox2.Controls.Add(this.TBTenSP);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 363);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Sản Phẩm";
            // 
            // GVDanhSachSP
            // 
            this.GVDanhSachSP.AllowUserToAddRows = false;
            this.GVDanhSachSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVDanhSachSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TenSP});
            this.GVDanhSachSP.Location = new System.Drawing.Point(17, 83);
            this.GVDanhSachSP.MultiSelect = false;
            this.GVDanhSachSP.Name = "GVDanhSachSP";
            this.GVDanhSachSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GVDanhSachSP.Size = new System.Drawing.Size(318, 261);
            this.GVDanhSachSP.TabIndex = 4;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id Sản Phẩm";
            this.Id.Name = "Id";
            // 
            // TenSP
            // 
            this.TenSP.DataPropertyName = "Tensp";
            this.TenSP.HeaderText = "Tên Sản Phẩm";
            this.TenSP.Name = "TenSP";
            this.TenSP.Width = 110;
            // 
            // BTHienTatCa
            // 
            this.BTHienTatCa.Location = new System.Drawing.Point(260, 53);
            this.BTHienTatCa.Name = "BTHienTatCa";
            this.BTHienTatCa.Size = new System.Drawing.Size(75, 23);
            this.BTHienTatCa.TabIndex = 3;
            this.BTHienTatCa.Text = "Hiện Tất Cả";
            this.BTHienTatCa.UseVisualStyleBackColor = true;
            this.BTHienTatCa.Click += new System.EventHandler(this.BTHienTatCa_Click);
            // 
            // BTTim
            // 
            this.BTTim.Location = new System.Drawing.Point(98, 53);
            this.BTTim.Name = "BTTim";
            this.BTTim.Size = new System.Drawing.Size(75, 23);
            this.BTTim.TabIndex = 2;
            this.BTTim.Text = "Tìm";
            this.BTTim.UseVisualStyleBackColor = true;
            this.BTTim.Click += new System.EventHandler(this.BTTim_Click);
            // 
            // TBTenSP
            // 
            this.TBTenSP.Location = new System.Drawing.Point(98, 27);
            this.TBTenSP.Name = "TBTenSP";
            this.TBTenSP.Size = new System.Drawing.Size(237, 20);
            this.TBTenSP.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tên Sản Phẩm";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LBTongTien);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.TBGia);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.GVChiTietNhap);
            this.groupBox3.Controls.Add(this.BTCapNhat);
            this.groupBox3.Controls.Add(this.TBSoLuong);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(447, 166);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(473, 363);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi Tiết Nhập";
            // 
            // LBTongTien
            // 
            this.LBTongTien.AutoSize = true;
            this.LBTongTien.ForeColor = System.Drawing.Color.Blue;
            this.LBTongTien.Location = new System.Drawing.Point(76, 58);
            this.LBTongTien.Name = "LBTongTien";
            this.LBTongTien.Size = new System.Drawing.Size(42, 13);
            this.LBTongTien.TabIndex = 8;
            this.LBTongTien.Text = "NoText";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Tổng Tiền";
            // 
            // TBGia
            // 
            this.TBGia.Location = new System.Drawing.Point(303, 27);
            this.TBGia.Name = "TBGia";
            this.TBGia.Size = new System.Drawing.Size(150, 20);
            this.TBGia.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(264, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Giá";
            // 
            // GVChiTietNhap
            // 
            this.GVChiTietNhap.AllowUserToAddRows = false;
            this.GVChiTietNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVChiTietNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdSPNhap,
            this.TenSPNhap,
            this.SoLuong,
            this.Gia});
            this.GVChiTietNhap.Location = new System.Drawing.Point(17, 83);
            this.GVChiTietNhap.Name = "GVChiTietNhap";
            this.GVChiTietNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GVChiTietNhap.Size = new System.Drawing.Size(436, 261);
            this.GVChiTietNhap.TabIndex = 5;
            this.GVChiTietNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVChiTietNhap_CellClick);
            // 
            // IdSPNhap
            // 
            this.IdSPNhap.DataPropertyName = "Id";
            this.IdSPNhap.HeaderText = "Id Sản Phẩm";
            this.IdSPNhap.Name = "IdSPNhap";
            // 
            // TenSPNhap
            // 
            this.TenSPNhap.DataPropertyName = "TenSP";
            this.TenSPNhap.HeaderText = "Tên Sản Phẩm";
            this.TenSPNhap.Name = "TenSPNhap";
            this.TenSPNhap.Width = 110;
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
            // 
            // BTCapNhat
            // 
            this.BTCapNhat.Location = new System.Drawing.Point(378, 53);
            this.BTCapNhat.Name = "BTCapNhat";
            this.BTCapNhat.Size = new System.Drawing.Size(75, 23);
            this.BTCapNhat.TabIndex = 2;
            this.BTCapNhat.Text = "Cập Nhật";
            this.BTCapNhat.UseVisualStyleBackColor = true;
            this.BTCapNhat.Click += new System.EventHandler(this.BTCapNhat_Click);
            // 
            // TBSoLuong
            // 
            this.TBSoLuong.Location = new System.Drawing.Point(77, 27);
            this.TBSoLuong.Name = "TBSoLuong";
            this.TBSoLuong.Size = new System.Drawing.Size(128, 20);
            this.TBSoLuong.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Số Lượng";
            // 
            // BTQuaPhai
            // 
            this.BTQuaPhai.Location = new System.Drawing.Point(374, 274);
            this.BTQuaPhai.Name = "BTQuaPhai";
            this.BTQuaPhai.Size = new System.Drawing.Size(67, 32);
            this.BTQuaPhai.TabIndex = 3;
            this.BTQuaPhai.Text = ">";
            this.BTQuaPhai.UseVisualStyleBackColor = true;
            this.BTQuaPhai.Click += new System.EventHandler(this.BTQuaPhai_Click);
            // 
            // BTQuaTrai
            // 
            this.BTQuaTrai.Location = new System.Drawing.Point(374, 377);
            this.BTQuaTrai.Name = "BTQuaTrai";
            this.BTQuaTrai.Size = new System.Drawing.Size(67, 32);
            this.BTQuaTrai.TabIndex = 4;
            this.BTQuaTrai.Text = "<";
            this.BTQuaTrai.UseVisualStyleBackColor = true;
            this.BTQuaTrai.Click += new System.EventHandler(this.BTQuaTrai_Click);
            // 
            // BTLapPhieuNhap
            // 
            this.BTLapPhieuNhap.Location = new System.Drawing.Point(665, 535);
            this.BTLapPhieuNhap.Name = "BTLapPhieuNhap";
            this.BTLapPhieuNhap.Size = new System.Drawing.Size(105, 23);
            this.BTLapPhieuNhap.TabIndex = 5;
            this.BTLapPhieuNhap.Text = "Lập Phiếu Nhập";
            this.BTLapPhieuNhap.UseVisualStyleBackColor = true;
            this.BTLapPhieuNhap.Click += new System.EventHandler(this.BTLapPhieuNhap_Click);
            // 
            // BTThoat
            // 
            this.BTThoat.Location = new System.Drawing.Point(815, 535);
            this.BTThoat.Name = "BTThoat";
            this.BTThoat.Size = new System.Drawing.Size(105, 23);
            this.BTThoat.TabIndex = 6;
            this.BTThoat.Text = "Thoát";
            this.BTThoat.UseVisualStyleBackColor = true;
            this.BTThoat.Click += new System.EventHandler(this.BTThoat_Click);
            // 
            // FNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(939, 576);
            this.Controls.Add(this.BTThoat);
            this.Controls.Add(this.BTLapPhieuNhap);
            this.Controls.Add(this.BTQuaTrai);
            this.Controls.Add(this.BTQuaPhai);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FNhapHang";
            this.Text = "Nhập Hàng";
            this.Load += new System.EventHandler(this.FNhapHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVDanhSachSP)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVChiTietNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TBGhiChu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DTNgayNhap;
        private System.Windows.Forms.ComboBox CBNhaCC;
        private System.Windows.Forms.ComboBox CBKho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView GVDanhSachSP;
        private System.Windows.Forms.Button BTHienTatCa;
        private System.Windows.Forms.Button BTTim;
        private System.Windows.Forms.TextBox TBTenSP;
        private System.Windows.Forms.Button BTCapNhat;
        private System.Windows.Forms.TextBox TBSoLuong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BTQuaPhai;
        private System.Windows.Forms.Button BTQuaTrai;
        private System.Windows.Forms.DataGridView GVChiTietNhap;
        private System.Windows.Forms.Button BTLapPhieuNhap;
        private System.Windows.Forms.Button BTThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.TextBox TBGia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSPNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSPNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.Label LBTongTien;
        private System.Windows.Forms.Label label8;
    }
}