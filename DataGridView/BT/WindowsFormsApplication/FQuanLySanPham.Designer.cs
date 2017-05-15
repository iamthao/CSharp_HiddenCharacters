namespace WindowsFormsApplication
{
    partial class FQuanLySanPham
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
            this.PBHinh = new System.Windows.Forms.PictureBox();
            this.BTXoa = new System.Windows.Forms.Button();
            this.BTSua = new System.Windows.Forms.Button();
            this.BTLuu = new System.Windows.Forms.Button();
            this.TBChiTiet = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TBTinhNangChinh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DTNgayBan = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.CBLoaiSP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBGia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BTChonHinh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TBTenSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GVSanPham = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhNangChinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiTiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTThoat = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBHinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PBHinh);
            this.groupBox1.Controls.Add(this.BTXoa);
            this.groupBox1.Controls.Add(this.BTSua);
            this.groupBox1.Controls.Add(this.BTLuu);
            this.groupBox1.Controls.Add(this.TBChiTiet);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TBTinhNangChinh);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.DTNgayBan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CBLoaiSP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TBGia);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.BTChonHinh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TBTenSP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 326);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sản Phẩm";
            // 
            // PBHinh
            // 
            this.PBHinh.Location = new System.Drawing.Point(352, 51);
            this.PBHinh.Name = "PBHinh";
            this.PBHinh.Size = new System.Drawing.Size(254, 254);
            this.PBHinh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBHinh.TabIndex = 17;
            this.PBHinh.TabStop = false;
            // 
            // BTXoa
            // 
            this.BTXoa.Location = new System.Drawing.Point(256, 282);
            this.BTXoa.Name = "BTXoa";
            this.BTXoa.Size = new System.Drawing.Size(62, 23);
            this.BTXoa.TabIndex = 16;
            this.BTXoa.Text = "Xóa";
            this.BTXoa.UseVisualStyleBackColor = true;
            this.BTXoa.Click += new System.EventHandler(this.BTXoa_Click);
            // 
            // BTSua
            // 
            this.BTSua.Location = new System.Drawing.Point(188, 283);
            this.BTSua.Name = "BTSua";
            this.BTSua.Size = new System.Drawing.Size(62, 23);
            this.BTSua.TabIndex = 15;
            this.BTSua.Text = "Sửa";
            this.BTSua.UseVisualStyleBackColor = true;
            this.BTSua.Click += new System.EventHandler(this.BTSua_Click);
            // 
            // BTLuu
            // 
            this.BTLuu.Location = new System.Drawing.Point(120, 283);
            this.BTLuu.Name = "BTLuu";
            this.BTLuu.Size = new System.Drawing.Size(62, 23);
            this.BTLuu.TabIndex = 14;
            this.BTLuu.Text = "Thêm";
            this.BTLuu.UseVisualStyleBackColor = true;
            this.BTLuu.Click += new System.EventHandler(this.BTLuu_Click);
            // 
            // TBChiTiet
            // 
            this.TBChiTiet.Location = new System.Drawing.Point(120, 206);
            this.TBChiTiet.Multiline = true;
            this.TBChiTiet.Name = "TBChiTiet";
            this.TBChiTiet.Size = new System.Drawing.Size(198, 70);
            this.TBChiTiet.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tính Năng Chính";
            // 
            // TBTinhNangChinh
            // 
            this.TBTinhNangChinh.Location = new System.Drawing.Point(120, 130);
            this.TBTinhNangChinh.Multiline = true;
            this.TBTinhNangChinh.Name = "TBTinhNangChinh";
            this.TBTinhNangChinh.Size = new System.Drawing.Size(198, 70);
            this.TBTinhNangChinh.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tính Năng Chính";
            // 
            // DTNgayBan
            // 
            this.DTNgayBan.Location = new System.Drawing.Point(120, 104);
            this.DTNgayBan.Name = "DTNgayBan";
            this.DTNgayBan.Size = new System.Drawing.Size(198, 20);
            this.DTNgayBan.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ngày Bán";
            // 
            // CBLoaiSP
            // 
            this.CBLoaiSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBLoaiSP.FormattingEnabled = true;
            this.CBLoaiSP.Location = new System.Drawing.Point(120, 77);
            this.CBLoaiSP.Name = "CBLoaiSP";
            this.CBLoaiSP.Size = new System.Drawing.Size(198, 21);
            this.CBLoaiSP.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Loại Sản Phẩm";
            // 
            // TBGia
            // 
            this.TBGia.Location = new System.Drawing.Point(120, 51);
            this.TBGia.Name = "TBGia";
            this.TBGia.Size = new System.Drawing.Size(198, 20);
            this.TBGia.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Giá";
            // 
            // BTChonHinh
            // 
            this.BTChonHinh.Location = new System.Drawing.Point(393, 23);
            this.BTChonHinh.Name = "BTChonHinh";
            this.BTChonHinh.Size = new System.Drawing.Size(75, 23);
            this.BTChonHinh.TabIndex = 3;
            this.BTChonHinh.Text = "Chọn Hình";
            this.BTChonHinh.UseVisualStyleBackColor = true;
            this.BTChonHinh.Click += new System.EventHandler(this.BTChonHinh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hình";
            // 
            // TBTenSP
            // 
            this.TBTenSP.Location = new System.Drawing.Point(120, 25);
            this.TBTenSP.Name = "TBTenSP";
            this.TBTenSP.Size = new System.Drawing.Size(198, 20);
            this.TBTenSP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Sản Phẩm";
            // 
            // GVSanPham
            // 
            this.GVSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TenSP,
            this.Gia,
            this.LoaiSP,
            this.Hinh,
            this.NgayBan,
            this.TinhNangChinh,
            this.ChiTiet});
            this.GVSanPham.Location = new System.Drawing.Point(12, 344);
            this.GVSanPham.Name = "GVSanPham";
            this.GVSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GVSanPham.Size = new System.Drawing.Size(640, 208);
            this.GVSanPham.TabIndex = 1;
            this.GVSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVSanPham_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 70;
            // 
            // TenSP
            // 
            this.TenSP.DataPropertyName = "Tensp";
            this.TenSP.HeaderText = "Tên";
            this.TenSP.Name = "TenSP";
            this.TenSP.Width = 70;
            // 
            // Gia
            // 
            this.Gia.DataPropertyName = "Gia";
            this.Gia.HeaderText = "Gia";
            this.Gia.Name = "Gia";
            this.Gia.Width = 70;
            // 
            // LoaiSP
            // 
            this.LoaiSP.DataPropertyName = "Tenloaisp";
            this.LoaiSP.HeaderText = "Loại";
            this.LoaiSP.Name = "LoaiSP";
            this.LoaiSP.Width = 70;
            // 
            // Hinh
            // 
            this.Hinh.DataPropertyName = "Hinh";
            this.Hinh.HeaderText = "Hinh";
            this.Hinh.Name = "Hinh";
            this.Hinh.Width = 70;
            // 
            // NgayBan
            // 
            this.NgayBan.DataPropertyName = "Ngayban";
            this.NgayBan.HeaderText = "Ngày Bán";
            this.NgayBan.Name = "NgayBan";
            // 
            // TinhNangChinh
            // 
            this.TinhNangChinh.DataPropertyName = "Tinhnangchinh";
            this.TinhNangChinh.HeaderText = "Tính Năng Chính";
            this.TinhNangChinh.Name = "TinhNangChinh";
            this.TinhNangChinh.Width = 120;
            // 
            // ChiTiet
            // 
            this.ChiTiet.DataPropertyName = "Chitiet";
            this.ChiTiet.HeaderText = "Chi Tiết";
            this.ChiTiet.Name = "ChiTiet";
            this.ChiTiet.Width = 120;
            // 
            // BTThoat
            // 
            this.BTThoat.Location = new System.Drawing.Point(577, 558);
            this.BTThoat.Name = "BTThoat";
            this.BTThoat.Size = new System.Drawing.Size(75, 23);
            this.BTThoat.TabIndex = 2;
            this.BTThoat.Text = "Thoat";
            this.BTThoat.UseVisualStyleBackColor = true;
            this.BTThoat.Click += new System.EventHandler(this.BTThoat_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "OpenFile";
            // 
            // FQuanLySanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(666, 595);
            this.Controls.Add(this.BTThoat);
            this.Controls.Add(this.GVSanPham);
            this.Controls.Add(this.groupBox1);
            this.Name = "FQuanLySanPham";
            this.Text = "Quản Lý Sản Phẩm";
            this.Load += new System.EventHandler(this.FQuanLySanPham_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBHinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox PBHinh;
        private System.Windows.Forms.Button BTXoa;
        private System.Windows.Forms.Button BTSua;
        private System.Windows.Forms.Button BTLuu;
        private System.Windows.Forms.TextBox TBChiTiet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBTinhNangChinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DTNgayBan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBLoaiSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTChonHinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBTenSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView GVSanPham;
        private System.Windows.Forms.Button BTThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TinhNangChinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiTiet;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
    }
}

