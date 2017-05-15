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
    public partial class FNhapHang : Form
    {
        List<Sanpham> ListSanPham = new List<Sanpham>();
        List<Kho> ListKho = Kho.TatCaKho();
        List<Nhacungcap> ListNhaCungCap = Nhacungcap.TatCaNhaCungCap();
        Nhaphang NhapHang = new Nhaphang();
        double TongTien = 0;

        public FNhapHang()
        {
            InitializeComponent();
            CBKho.Items.Add("---Chọn Kho---");
            foreach(Kho kho in ListKho)
                CBKho.Items.Add(kho.Tenkho);
            CBKho.SelectedIndex = 0;
            CBNhaCC.Items.Add("---Chọn Nhà Cung Cấp---");
            foreach (Nhacungcap nhacungcap in ListNhaCungCap)
                CBNhaCC.Items.Add(nhacungcap.Tenncc);
            CBNhaCC.SelectedIndex = 0;
            LBTongTien.Text = TongTien.ToString();
        }

        private void BTTim_Click(object sender, EventArgs e)
        {
            if (TBTenSP.Text.Length > 0)
            {
                ListSanPham = Sanpham.TimKiem(TBTenSP.Text);
                GVDanhSachSP.AutoGenerateColumns = false;
                GVDanhSachSP.DataSource = ListSanPham;
            }
            else
                MessageBox.Show("Chưa Điền Tên Sản Phẩm Cần Tìm!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BTHienTatCa_Click(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
        }

        private void BTCapNhat_Click(object sender, EventArgs e)
        {
            if (GVChiTietNhap.Rows.Count > 0)
            {
                if (GVChiTietNhap.SelectedRows.Count == 1)
                {
                    if (KiemTraCapNhat())
                    {
                        foreach (Chitietnhaphang CTNH in NhapHang.Chitietnhaphangs)
                        {
                            if (CTNH.SanphamId == Convert.ToInt32(GVChiTietNhap.SelectedRows[0].Cells[0].Value.ToString()))
                            {
                                CTNH.Soluong = Convert.ToInt32(TBSoLuong.Text);
                                CTNH.Gia = Convert.ToDouble(TBGia.Text);
                                break;
                            }
                        }
                        TinhTongTien();
                        HienChiTietNhap();
                    }
                }
                else
                    MessageBox.Show("Chỉ Chọn 1 Sản Phẩm!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTQuaPhai_Click(object sender, EventArgs e)
        {
            try
            {
                if (GVDanhSachSP.Rows.Count > 0)
                {
                    if (!TimSanPhamTrongChiTietNhap(Convert.ToInt32(GVDanhSachSP.SelectedCells[0].Value.ToString())))
                    {
                        Chitietnhaphang CTNH = new Chitietnhaphang();
                        CTNH.SanphamId = Convert.ToInt32(GVDanhSachSP.SelectedCells[0].Value.ToString());
                        CTNH.Soluong = 1;
                        CTNH.Gia = 0;
                        NhapHang.Chitietnhaphangs.Add(CTNH);
                        HienChiTietNhap();
                    }
                    else
                        MessageBox.Show("Sản Phẩm Đã Có Trong Danh Sách!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Đã Xãy Ra Lỗi!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTQuaTrai_Click(object sender, EventArgs e)
        {
            XoaSanPhamTrongChiTietNhap();
        }

        private void BTLapPhieuNhap_Click(object sender, EventArgs e)
        {
            if (KiemTraLapPhieuNhap())
            {
                try
                {
                    int KhoId = ListKho.Where(kho => kho.Tenkho == CBKho.Text).Select(item => item.Id).FirstOrDefault();
                    int NhaCungCapId = ListNhaCungCap.Where(nhacungcap => nhacungcap.Tenncc == CBNhaCC.Text).Select(item => item.Id).FirstOrDefault();
                    NhapHang.KhoId = KhoId;
                    NhapHang.NhacungcapId = NhaCungCapId;
                    NhapHang.Tongtien = TongTien;
                    NhapHang.Ngaynhap = DTNgayNhap.Value;
                    NhapHang.Ghichu = TBGhiChu.Text;
                    NhapHang.ThemPhieuNhap();
                    MessageBox.Show("Thêm Phiếu Nhập Thành Công", "Thông Báo");
                    Reset();
                }
                catch
                {
                    MessageBox.Show("Đã Xãy Ra Lỗi!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BTThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FNhapHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
        }

        private void GVChiTietNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GVChiTietNhap.Rows.Count > 0)
            {
                if (GVChiTietNhap.SelectedRows.Count == 1)
                {
                    TBSoLuong.Text = GVChiTietNhap.SelectedRows[0].Cells[2].Value.ToString();
                    TBGia.Text = GVChiTietNhap.SelectedRows[0].Cells[3].Value.ToString();
                }
            }
        }

        public void LoadDanhSachSanPham()
        {
            ListSanPham = Sanpham.TatCaSanPham();
            GVDanhSachSP.AutoGenerateColumns = false;
            GVDanhSachSP.DataSource = ListSanPham;
        }

        public bool TimSanPhamTrongChiTietNhap(int SanPhamId)
        {
            foreach (Chitietnhaphang CTHD in NhapHang.Chitietnhaphangs)
                if (CTHD.SanphamId == SanPhamId)
                    return true;
            return false;
        }

        public void HienChiTietNhap()
        {
            if (NhapHang.Chitietnhaphangs != null)
            {
                var bind = NhapHang.Chitietnhaphangs.Select(a => new
                {
                    Id = a.SanphamId,
                    TenSP = ListSanPham.Where(sp => sp.Id == a.SanphamId).Select(item => item.Tensp).FirstOrDefault(),
                    SoLuong = a.Soluong,
                    Gia = a.Gia
                }).OrderBy(item => item.Id).ToList();
                GVChiTietNhap.AutoGenerateColumns = false;
                GVChiTietNhap.DataSource = bind;
            }
            else
                GVChiTietNhap.DataSource = null;
        }

        public void XoaSanPhamTrongChiTietNhap()
        {
            try
            {
                for (int i = GVChiTietNhap.SelectedRows.Count - 1; i >= 0; i--)
                {
                    foreach (Chitietnhaphang CTNH in NhapHang.Chitietnhaphangs)
                    {
                        if (CTNH.SanphamId == Convert.ToInt32(GVChiTietNhap.SelectedRows[i].Cells[0].Value.ToString()))
                        {
                            NhapHang.Chitietnhaphangs.Remove(CTNH);
                            break;
                        }
                    }
                }
                TinhTongTien();
                HienChiTietNhap();
            }
            catch
            {
                MessageBox.Show("Đã Xãy Ra Lỗi!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool KiemTraCapNhat()
        {
            if (TBSoLuong.Text.Length == 0)
            {
                MessageBox.Show("Chưa Nhập Số Lượng!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Functions.IsNumeric(TBSoLuong.Text))
            {
                MessageBox.Show("Số Lượng Không Hợp Lệ!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (TBGia.Text.Length == 0)
            {
                MessageBox.Show("Chưa Nhập Giá!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Functions.IsNumeric(TBGia.Text))
            {
                MessageBox.Show("Giá Không Hợp Lệ!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool KiemTraLapPhieuNhap()
        {
            if (CBKho.Text == "---Chọn Kho---")
            {
                MessageBox.Show("Chưa Chọn Kho!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (CBNhaCC.Text == "---Chọn Nhà Cung Cấp---")
            {
                MessageBox.Show("Chưa Chọn Nhà Cung Cấp!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (DTNgayNhap.Value.Date > DateTime.Today.Date)
            {
                MessageBox.Show("Ngày Nhập Lớn Hơn Ngày Hiện Tại!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (NhapHang.Chitietnhaphangs.Count == 0)
            {
                MessageBox.Show("Chi Tiết Nhập Chưa Có!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            foreach (Chitietnhaphang CTNH in NhapHang.Chitietnhaphangs)
            {
                if (CTNH.Gia == 0)
                {
                    MessageBox.Show("Có Sản Phẩm Chưa Điền Giá!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        public void TinhTongTien()
        {
            TongTien = 0;
            if (NhapHang.Chitietnhaphangs != null)
            {
                foreach (Chitietnhaphang CTNH in NhapHang.Chitietnhaphangs)
                    TongTien = TongTien + (double)(CTNH.Gia * CTNH.Soluong);
            }
            LBTongTien.Text = TongTien.ToString();
        }

        public void Reset()
        {
            CBKho.SelectedIndex = 0;
            CBNhaCC.SelectedIndex = 0;
            DTNgayNhap.Value = DateTime.Today;
            TBGhiChu.Text = "";
            NhapHang = new Nhaphang();
            TBSoLuong.Text = "";
            TBGia.Text = "";
            TongTien = 0;
            LBTongTien.Text = TongTien.ToString();
            HienChiTietNhap();
        }
    }
}
