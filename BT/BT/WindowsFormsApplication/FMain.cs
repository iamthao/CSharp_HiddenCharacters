using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class FMain : Form
    {

        public FMain()
        {
            InitializeComponent();
        }

        private void BTQuanLySP_Click(object sender, EventArgs e)
        {
            FQuanLySanPham Form = new FQuanLySanPham();
            Form.ShowDialog();
        }

        private void BTNhapHang_Click(object sender, EventArgs e)
        {
            FNhapHang Form = new FNhapHang();
            Form.ShowDialog();
        }

        private void BTQuanLyHD_Click(object sender, EventArgs e)
        {
            FDanhSachHoaDon Form = new FDanhSachHoaDon();
            Form.ShowDialog();
        }

        private void BTBaoCaoDT_Click(object sender, EventArgs e)
        {
            FBaoCao Form = new FBaoCao();
            Form.ShowDialog();
        }

        private void BTThongKeTonKho_Click(object sender, EventArgs e)
        {
            FThongKeTonKho Form = new FThongKeTonKho();
            Form.ShowDialog();
        }

        private void BTThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
