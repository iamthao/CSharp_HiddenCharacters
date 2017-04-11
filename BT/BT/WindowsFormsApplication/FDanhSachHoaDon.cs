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
    public partial class FDanhSachHoaDon : Form
    {
        List<Hoadon> ListHD;
        List<Trangthaihoadon> ListTrangThaiHD = Trangthaihoadon.TatCaTrangThaiHoaDon();
        Hoadon HoaDon = new Hoadon();

        public FDanhSachHoaDon()
        {
            InitializeComponent();
        }

        private void BTTrangThaiHD_Click(object sender, EventArgs e)
        {
            if (CBTrangThaiHD.Text == "---Chọn Trạng Thái Hóa Đơn---")
            {
                MessageBox.Show("Chưa Chọn Trạng Thái Hóa Đơn!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CBTrangThaiHD.Focus();
            }
            else
            {
                int TrangThaiId = ListTrangThaiHD.Where(trangthai => trangthai.Tentthd == CBTrangThaiHD.Text).Select(item => item.Id).FirstOrDefault();
                ListHD = Hoadon.TimTheoTrangThai(TrangThaiId);
                BindItems();
            }
        }

        private void BTNgay_Click(object sender, EventArgs e)
        {
            ListHD = Hoadon.TimTheoNgay(DTNgayHD.Value);
            BindItems();
        }

        private void BTHienTatCa_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

        private void BTChiTiet_Click(object sender, EventArgs e)
        {
            if (GVHoaDon.Rows.Count > 0)
            {
                HoaDon = Hoadon.ThongTinHoaDon(Convert.ToInt32(GVHoaDon.SelectedCells[0].Value.ToString()));
                FHoaDon FHoaDon = new FHoaDon(HoaDon);
                FHoaDon.sendMessage = new FHoaDon.SendMessage(LoadHoaDon);
                FHoaDon.ShowDialog();
            }
        }

        private void FDanhSachHoaDon_Load(object sender, EventArgs e)
        {
            CBTrangThaiHD.Items.Add("---Chọn Trạng Thái Hóa Đơn---");
            foreach (Trangthaihoadon trangthai in ListTrangThaiHD)
                CBTrangThaiHD.Items.Add(trangthai.Tentthd);
            CBTrangThaiHD.SelectedIndex = 0;
            LoadHoaDon();
        }

        private void BTXoa_Click(object sender, EventArgs e)
        {
            if (GVHoaDon.Rows.Count > 0)
            {
                if (ListTrangThaiHD.Where(trangthai => trangthai.Tentthd == GVHoaDon.SelectedCells[3].Value.ToString()).Select(item => item.Id).FirstOrDefault() != 3)
                {
                    if (MessageBox.Show("Bạn Có Chắc Không?", "Xóa Hóa Đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            HoaDon = Hoadon.ThongTinHoaDon(Convert.ToInt32(GVHoaDon.SelectedCells[0].Value.ToString()));
                            if (HoaDon.TrangthaihoadonId != 3)
                            {
                                HoaDon.XoaHoaDon();
                                LoadHoaDon();
                                MessageBox.Show("Xóa Hóa Đơn Thành Công", "Thông Báo");
                            }
                            else
                                MessageBox.Show("Không Thể Xóa Hóa Đơn Đã Giao!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch
                        {
                            MessageBox.Show("Đã Xãy Ra Lỗi!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Không Thể Xóa Hóa Đơn Đã Giao!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void BTThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadHoaDon()
        {
            ListHD = Hoadon.TatCaHoaDon();
            BindItems();
        }

        public void BindItems()
        {
            if (ListHD != null)
            {
                var bind = ListHD.Select(a => new
                {
                    IdHD = a.Id,
                    IdKH = a.KhachhangId,
                    TenKH = a.Khachhang.Tenkh,
                    TrangThaiHD = a.Trangthaihoadon.Tentthd,
                    TongTien = a.Tongtien,
                    Ngay = a.Ngaylap
                }).ToList();
                GVHoaDon.DataSource = bind;
            }
            else
                GVHoaDon.DataSource = null;
        }
    }
}
