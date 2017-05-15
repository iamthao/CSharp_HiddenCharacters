namespace WindowsFormsApplication
{
    partial class FThongKeTonKho
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
            this.GVSanPham = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTTatCa = new System.Windows.Forms.Button();
            this.BTTim = new System.Windows.Forms.Button();
            this.TBTenSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BTXuatBaoCao = new System.Windows.Forms.Button();
            this.GVThongKeSanPham = new System.Windows.Forms.DataGridView();
            this.IdSPTK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSPTK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTThongKe = new System.Windows.Forms.Button();
            this.DTNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BTQuaPhai = new System.Windows.Forms.Button();
            this.BTQuaPhaiHet = new System.Windows.Forms.Button();
            this.BTQuaTrai = new System.Windows.Forms.Button();
            this.BTQuaTraiHet = new System.Windows.Forms.Button();
            this.BTThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVSanPham)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVThongKeSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GVSanPham);
            this.groupBox1.Controls.Add(this.BTTatCa);
            this.groupBox1.Controls.Add(this.BTTim);
            this.groupBox1.Controls.Add(this.TBTenSP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 431);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Sản Phẩm";
            // 
            // GVSanPham
            // 
            this.GVSanPham.AllowUserToAddRows = false;
            this.GVSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TenSP});
            this.GVSanPham.Location = new System.Drawing.Point(23, 82);
            this.GVSanPham.MultiSelect = false;
            this.GVSanPham.Name = "GVSanPham";
            this.GVSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GVSanPham.Size = new System.Drawing.Size(264, 330);
            this.GVSanPham.TabIndex = 4;
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
            this.TenSP.HeaderText = "Tên Sản Phẩm";
            this.TenSP.Name = "TenSP";
            this.TenSP.Width = 110;
            // 
            // BTTatCa
            // 
            this.BTTatCa.Location = new System.Drawing.Point(212, 53);
            this.BTTatCa.Name = "BTTatCa";
            this.BTTatCa.Size = new System.Drawing.Size(75, 23);
            this.BTTatCa.TabIndex = 3;
            this.BTTatCa.Text = "Tất Cả";
            this.BTTatCa.UseVisualStyleBackColor = true;
            this.BTTatCa.Click += new System.EventHandler(this.BTTatCa_Click);
            // 
            // BTTim
            // 
            this.BTTim.Location = new System.Drawing.Point(104, 53);
            this.BTTim.Name = "BTTim";
            this.BTTim.Size = new System.Drawing.Size(75, 23);
            this.BTTim.TabIndex = 2;
            this.BTTim.Text = "Tìm";
            this.BTTim.UseVisualStyleBackColor = true;
            this.BTTim.Click += new System.EventHandler(this.BTTim_Click);
            // 
            // TBTenSP
            // 
            this.TBTenSP.Location = new System.Drawing.Point(104, 27);
            this.TBTenSP.Name = "TBTenSP";
            this.TBTenSP.Size = new System.Drawing.Size(183, 20);
            this.TBTenSP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Sản Phẩm";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BTXuatBaoCao);
            this.groupBox2.Controls.Add(this.GVThongKeSanPham);
            this.groupBox2.Controls.Add(this.BTThongKe);
            this.groupBox2.Controls.Add(this.DTNgay);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(384, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 431);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thống Kê";
            // 
            // BTXuatBaoCao
            // 
            this.BTXuatBaoCao.Location = new System.Drawing.Point(261, 53);
            this.BTXuatBaoCao.Name = "BTXuatBaoCao";
            this.BTXuatBaoCao.Size = new System.Drawing.Size(95, 23);
            this.BTXuatBaoCao.TabIndex = 3;
            this.BTXuatBaoCao.Text = "Xuất Báo Cáo";
            this.BTXuatBaoCao.UseVisualStyleBackColor = true;
            this.BTXuatBaoCao.Click += new System.EventHandler(this.BTXuatBaoCao_Click);
            // 
            // GVThongKeSanPham
            // 
            this.GVThongKeSanPham.AllowUserToAddRows = false;
            this.GVThongKeSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVThongKeSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdSPTK,
            this.TenSPTK,
            this.Ton});
            this.GVThongKeSanPham.Location = new System.Drawing.Point(30, 82);
            this.GVThongKeSanPham.Name = "GVThongKeSanPham";
            this.GVThongKeSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GVThongKeSanPham.Size = new System.Drawing.Size(326, 330);
            this.GVThongKeSanPham.TabIndex = 3;
            // 
            // IdSPTK
            // 
            this.IdSPTK.DataPropertyName = "Id";
            this.IdSPTK.HeaderText = "Id";
            this.IdSPTK.Name = "IdSPTK";
            this.IdSPTK.Width = 70;
            // 
            // TenSPTK
            // 
            this.TenSPTK.DataPropertyName = "TenSP";
            this.TenSPTK.HeaderText = "Tên Sản Phẩm";
            this.TenSPTK.Name = "TenSPTK";
            this.TenSPTK.Width = 110;
            // 
            // Ton
            // 
            this.Ton.DataPropertyName = "SoLuong";
            this.Ton.HeaderText = "Tồn";
            this.Ton.Name = "Ton";
            // 
            // BTThongKe
            // 
            this.BTThongKe.Location = new System.Drawing.Point(261, 25);
            this.BTThongKe.Name = "BTThongKe";
            this.BTThongKe.Size = new System.Drawing.Size(95, 23);
            this.BTThongKe.TabIndex = 2;
            this.BTThongKe.Text = "Thống Kê";
            this.BTThongKe.UseVisualStyleBackColor = true;
            this.BTThongKe.Click += new System.EventHandler(this.BTThongKe_Click);
            // 
            // DTNgay
            // 
            this.DTNgay.Location = new System.Drawing.Point(65, 27);
            this.DTNgay.Name = "DTNgay";
            this.DTNgay.Size = new System.Drawing.Size(183, 20);
            this.DTNgay.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ngày";
            // 
            // BTQuaPhai
            // 
            this.BTQuaPhai.Location = new System.Drawing.Point(332, 124);
            this.BTQuaPhai.Name = "BTQuaPhai";
            this.BTQuaPhai.Size = new System.Drawing.Size(46, 29);
            this.BTQuaPhai.TabIndex = 2;
            this.BTQuaPhai.Text = ">";
            this.BTQuaPhai.UseVisualStyleBackColor = true;
            this.BTQuaPhai.Click += new System.EventHandler(this.BTQuaPhai_Click);
            // 
            // BTQuaPhaiHet
            // 
            this.BTQuaPhaiHet.Location = new System.Drawing.Point(332, 159);
            this.BTQuaPhaiHet.Name = "BTQuaPhaiHet";
            this.BTQuaPhaiHet.Size = new System.Drawing.Size(46, 29);
            this.BTQuaPhaiHet.TabIndex = 3;
            this.BTQuaPhaiHet.Text = ">>";
            this.BTQuaPhaiHet.UseVisualStyleBackColor = true;
            this.BTQuaPhaiHet.Click += new System.EventHandler(this.BTQuaPhaiHet_Click);
            // 
            // BTQuaTrai
            // 
            this.BTQuaTrai.Location = new System.Drawing.Point(332, 252);
            this.BTQuaTrai.Name = "BTQuaTrai";
            this.BTQuaTrai.Size = new System.Drawing.Size(46, 29);
            this.BTQuaTrai.TabIndex = 4;
            this.BTQuaTrai.Text = "<";
            this.BTQuaTrai.UseVisualStyleBackColor = true;
            this.BTQuaTrai.Click += new System.EventHandler(this.BTQuaTrai_Click);
            // 
            // BTQuaTraiHet
            // 
            this.BTQuaTraiHet.Location = new System.Drawing.Point(332, 287);
            this.BTQuaTraiHet.Name = "BTQuaTraiHet";
            this.BTQuaTraiHet.Size = new System.Drawing.Size(46, 29);
            this.BTQuaTraiHet.TabIndex = 5;
            this.BTQuaTraiHet.Text = "<<";
            this.BTQuaTraiHet.UseVisualStyleBackColor = true;
            this.BTQuaTraiHet.Click += new System.EventHandler(this.BTQuaTraiHet_Click);
            // 
            // BTThoat
            // 
            this.BTThoat.Location = new System.Drawing.Point(695, 449);
            this.BTThoat.Name = "BTThoat";
            this.BTThoat.Size = new System.Drawing.Size(75, 23);
            this.BTThoat.TabIndex = 6;
            this.BTThoat.Text = "Thoát";
            this.BTThoat.UseVisualStyleBackColor = true;
            this.BTThoat.Click += new System.EventHandler(this.BTThoat_Click);
            // 
            // FThongKeTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(782, 489);
            this.Controls.Add(this.BTThoat);
            this.Controls.Add(this.BTQuaTraiHet);
            this.Controls.Add(this.BTQuaTrai);
            this.Controls.Add(this.BTQuaPhaiHet);
            this.Controls.Add(this.BTQuaPhai);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FThongKeTonKho";
            this.Text = "Thống Kê Tồn Kho";
            this.Load += new System.EventHandler(this.FThongKeTonKho_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVSanPham)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVThongKeSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView GVSanPham;
        private System.Windows.Forms.Button BTTatCa;
        private System.Windows.Forms.Button BTTim;
        private System.Windows.Forms.TextBox TBTenSP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView GVThongKeSanPham;
        private System.Windows.Forms.Button BTThongKe;
        private System.Windows.Forms.DateTimePicker DTNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTQuaPhai;
        private System.Windows.Forms.Button BTQuaPhaiHet;
        private System.Windows.Forms.Button BTQuaTrai;
        private System.Windows.Forms.Button BTQuaTraiHet;
        private System.Windows.Forms.Button BTThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSPTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSPTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ton;
        private System.Windows.Forms.Button BTXuatBaoCao;
    }
}