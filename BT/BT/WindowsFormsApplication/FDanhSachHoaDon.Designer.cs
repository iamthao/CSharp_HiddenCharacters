namespace WindowsFormsApplication
{
    partial class FDanhSachHoaDon
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
            this.BTTrangThaiHD = new System.Windows.Forms.Button();
            this.CBTrangThaiHD = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BTNgay = new System.Windows.Forms.Button();
            this.DTNgayHD = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.GVHoaDon = new System.Windows.Forms.DataGridView();
            this.IdHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThaiHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTHienTatCa = new System.Windows.Forms.Button();
            this.BTChiTiet = new System.Windows.Forms.Button();
            this.BTXoa = new System.Windows.Forms.Button();
            this.BTThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTTrangThaiHD);
            this.groupBox1.Controls.Add(this.CBTrangThaiHD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Theo Trạng Thái Hóa Đơn";
            // 
            // BTTrangThaiHD
            // 
            this.BTTrangThaiHD.Location = new System.Drawing.Point(386, 28);
            this.BTTrangThaiHD.Name = "BTTrangThaiHD";
            this.BTTrangThaiHD.Size = new System.Drawing.Size(75, 23);
            this.BTTrangThaiHD.TabIndex = 2;
            this.BTTrangThaiHD.Text = "Tìm";
            this.BTTrangThaiHD.UseVisualStyleBackColor = true;
            this.BTTrangThaiHD.Click += new System.EventHandler(this.BTTrangThaiHD_Click);
            // 
            // CBTrangThaiHD
            // 
            this.CBTrangThaiHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBTrangThaiHD.FormattingEnabled = true;
            this.CBTrangThaiHD.Location = new System.Drawing.Point(142, 30);
            this.CBTrangThaiHD.Name = "CBTrangThaiHD";
            this.CBTrangThaiHD.Size = new System.Drawing.Size(186, 21);
            this.CBTrangThaiHD.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trạng Thái Hóa Đơn";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BTNgay);
            this.groupBox2.Controls.Add(this.DTNgayHD);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(14, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 79);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm Theo Ngày";
            // 
            // BTNgay
            // 
            this.BTNgay.Location = new System.Drawing.Point(386, 33);
            this.BTNgay.Name = "BTNgay";
            this.BTNgay.Size = new System.Drawing.Size(75, 23);
            this.BTNgay.TabIndex = 3;
            this.BTNgay.Text = "Tìm";
            this.BTNgay.UseVisualStyleBackColor = true;
            this.BTNgay.Click += new System.EventHandler(this.BTNgay_Click);
            // 
            // DTNgayHD
            // 
            this.DTNgayHD.Location = new System.Drawing.Point(142, 32);
            this.DTNgayHD.Name = "DTNgayHD";
            this.DTNgayHD.Size = new System.Drawing.Size(186, 20);
            this.DTNgayHD.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ngày Hóa Đơn";
            // 
            // GVHoaDon
            // 
            this.GVHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdHD,
            this.IdKH,
            this.TenKH,
            this.TrangThaiHD,
            this.TongTien,
            this.NgayHD});
            this.GVHoaDon.Location = new System.Drawing.Point(14, 181);
            this.GVHoaDon.Name = "GVHoaDon";
            this.GVHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GVHoaDon.Size = new System.Drawing.Size(509, 227);
            this.GVHoaDon.TabIndex = 2;
            // 
            // IdHD
            // 
            this.IdHD.DataPropertyName = "IdHD";
            this.IdHD.HeaderText = "Id HD";
            this.IdHD.Name = "IdHD";
            this.IdHD.Width = 60;
            // 
            // IdKH
            // 
            this.IdKH.DataPropertyName = "IdKH";
            this.IdKH.HeaderText = "Id KH";
            this.IdKH.Name = "IdKH";
            this.IdKH.Width = 60;
            // 
            // TenKH
            // 
            this.TenKH.DataPropertyName = "TenKH";
            this.TenKH.HeaderText = "Tên KH";
            this.TenKH.Name = "TenKH";
            this.TenKH.Width = 70;
            // 
            // TrangThaiHD
            // 
            this.TrangThaiHD.DataPropertyName = "TrangThaiHD";
            this.TrangThaiHD.HeaderText = "Trạng Thái Hóa Đơn";
            this.TrangThaiHD.Name = "TrangThaiHD";
            this.TrangThaiHD.Width = 130;
            // 
            // TongTien
            // 
            this.TongTien.DataPropertyName = "TongTien";
            this.TongTien.HeaderText = "Tổng Tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.Width = 80;
            // 
            // NgayHD
            // 
            this.NgayHD.DataPropertyName = "Ngay";
            this.NgayHD.HeaderText = "Ngày";
            this.NgayHD.Name = "NgayHD";
            // 
            // BTHienTatCa
            // 
            this.BTHienTatCa.Location = new System.Drawing.Point(130, 414);
            this.BTHienTatCa.Name = "BTHienTatCa";
            this.BTHienTatCa.Size = new System.Drawing.Size(75, 23);
            this.BTHienTatCa.TabIndex = 4;
            this.BTHienTatCa.Text = "Hiện Tất Cả";
            this.BTHienTatCa.UseVisualStyleBackColor = true;
            this.BTHienTatCa.Click += new System.EventHandler(this.BTHienTatCa_Click);
            // 
            // BTChiTiet
            // 
            this.BTChiTiet.Location = new System.Drawing.Point(238, 414);
            this.BTChiTiet.Name = "BTChiTiet";
            this.BTChiTiet.Size = new System.Drawing.Size(75, 23);
            this.BTChiTiet.TabIndex = 5;
            this.BTChiTiet.Text = "Chi Tiết";
            this.BTChiTiet.UseVisualStyleBackColor = true;
            this.BTChiTiet.Click += new System.EventHandler(this.BTChiTiet_Click);
            // 
            // BTXoa
            // 
            this.BTXoa.Location = new System.Drawing.Point(345, 414);
            this.BTXoa.Name = "BTXoa";
            this.BTXoa.Size = new System.Drawing.Size(75, 23);
            this.BTXoa.TabIndex = 7;
            this.BTXoa.Text = "Xóa";
            this.BTXoa.UseVisualStyleBackColor = true;
            this.BTXoa.Click += new System.EventHandler(this.BTXoa_Click);
            // 
            // BTThoat
            // 
            this.BTThoat.Location = new System.Drawing.Point(449, 414);
            this.BTThoat.Name = "BTThoat";
            this.BTThoat.Size = new System.Drawing.Size(75, 23);
            this.BTThoat.TabIndex = 8;
            this.BTThoat.Text = "Thoát";
            this.BTThoat.UseVisualStyleBackColor = true;
            this.BTThoat.Click += new System.EventHandler(this.BTThoat_Click);
            // 
            // FDanhSachHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(536, 450);
            this.Controls.Add(this.BTThoat);
            this.Controls.Add(this.BTXoa);
            this.Controls.Add(this.BTChiTiet);
            this.Controls.Add(this.BTHienTatCa);
            this.Controls.Add(this.GVHoaDon);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FDanhSachHoaDon";
            this.Text = "Quản Lý Hóa Đơn";
            this.Load += new System.EventHandler(this.FDanhSachHoaDon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTTrangThaiHD;
        private System.Windows.Forms.ComboBox CBTrangThaiHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BTNgay;
        private System.Windows.Forms.DateTimePicker DTNgayHD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView GVHoaDon;
        private System.Windows.Forms.Button BTHienTatCa;
        private System.Windows.Forms.Button BTChiTiet;
        private System.Windows.Forms.Button BTXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThaiHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayHD;
        private System.Windows.Forms.Button BTThoat;
    }
}