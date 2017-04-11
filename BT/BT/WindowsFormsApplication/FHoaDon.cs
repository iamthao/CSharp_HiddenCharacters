using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLLandDAL;

namespace WindowsFormsApplication
{
    public partial class FHoaDon : Form
    {
        Hoadon HoaDon;
        List<Trangthaihoadon> ListTrangThaiHD = Trangthaihoadon.TatCaTrangThaiHoaDon();

        public delegate void SendMessage();
        public SendMessage sendMessage;

        private void RunDelegate()
        {
            sendMessage();
        }

        public FHoaDon(Hoadon HoaDon)
        {
            this.HoaDon = HoaDon;
            InitializeComponent();
            CBTrangThai.Items.Add("---Chọn Trạng Thái Hóa Đơn---");
            foreach (Trangthaihoadon trangthai in ListTrangThaiHD)
                CBTrangThai.Items.Add(trangthai.Tentthd);
            CBTrangThai.SelectedIndex = 0;
        }

        private void BTSuaHD_Click(object sender, EventArgs e)
        {
            if (CBTrangThai.Text != "---Chọn Trạng Thái Hóa Đơn---")
            {
                int TrangThaiId = ListTrangThaiHD.Where(trangthai => trangthai.Tentthd == CBTrangThai.Text).Select(item => item.Id).FirstOrDefault();
                if (HoaDon.TrangthaihoadonId != 3)
                {
                    if (HoaDon.TrangthaihoadonId != TrangThaiId)
                    {
                        if (TrangThaiId == 3)
                        {
                            if (MessageBox.Show("Hóa Đơn Đã Giao Không Thể Sửa Lại, Bạn Có Muốn Tiếp Tục?", "Xóa Hóa Đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                try
                                {
                                    HoaDon.TrangthaihoadonId = TrangThaiId;
                                    if(HoaDon.SuaHoaDon())
                                        MessageBox.Show("Sửa Hóa Đơn Thành Công", "Thông Báo");
                                    else
                                        MessageBox.Show("Sản Phẩm Trong Kho Khong Dap Ung Duoc!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch
                                {
                                    MessageBox.Show("Đã Xãy Ra Lỗi!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                HoaDon.TrangthaihoadonId = TrangThaiId;
                                if (HoaDon.SuaHoaDon())
                                    MessageBox.Show("Sửa Hóa Đơn Thành Công", "Thông Báo");
                            }
                            catch
                            {
                                MessageBox.Show("Đã Xãy Ra Lỗi!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Trạng Thái Mới Trùng Trạng Thái Cũ!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Không Thể Sửa Hóa Đơn Đã Giao!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Chưa Chọn Trạng Thái!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BTThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            RunDelegate();
        }

        private void FHoaDon_Load(object sender, EventArgs e)
        {
            LBHoaDonId.Text = HoaDon.Id.ToString();
            DateTime Ngay = HoaDon.Ngaylap.Value;
            LBNgayHD.Text = Ngay.ToString("dd/MM/yyyy");
            LBTongTien.Text = HoaDon.Tongtien.ToString();
            LBKhachHangId.Text = HoaDon.KhachhangId.ToString();
            LBTenKH.Text = HoaDon.Khachhang.Tenkh;
            LBEmail.Text = HoaDon.Khachhang.Email;
            LBSDT.Text = HoaDon.Khachhang.SDT;
            foreach (var item in CBTrangThai.Items)
                if (item.ToString() == HoaDon.Trangthaihoadon.Tentthd)
                {
                    CBTrangThai.SelectedIndex = CBTrangThai.Items.IndexOf(item);
                    break;
                }
            var bind = HoaDon.Chitiethoadons.Select(a => new
            {
                IdSP = a.SanphamId,
                TenSP = a.Sanpham.Tensp,
                SoLuong = a.Soluong,
                Gia = a.Gia,
                ThanhTien = a.Gia * a.Soluong
            }).ToList();
            GVChiTietHD.DataSource = bind;
        }
    }
}
