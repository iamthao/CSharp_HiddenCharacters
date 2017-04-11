using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLLandDAL;
using System.IO;

namespace WindowsFormsApplication
{
    public partial class FQuanLySanPham : Form
    {
        List<Sanpham> listsanpham;
        List<Loaisanpham> listloaisanpham = Loaisanpham.TatCaLoaiSanPham();
        Sanpham sanpham;
        string PathImg = Path.GetFullPath("..\\..\\..\\MvcApplication\\Content\\Img\\Product");
        string PathDB = "~/Content/Img/Product/";

        public FQuanLySanPham()
        {
            InitializeComponent();
            PBHinh.Image = Properties.Resources.NoImage;
        }

        private void BTThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FQuanLySanPham_Load(object sender, EventArgs e)
        {
            sanpham = new Sanpham();
            CBLoaiSP.Items.Add("---Chọn Loại Sản Phẩm---");
            foreach (Loaisanpham loaisp in listloaisanpham)
                CBLoaiSP.Items.Add(loaisp.Tenloaisp);
            CBLoaiSP.SelectedIndex = 0;
            LoadSanPham();
        }

        private void BTChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "JPG (*.jpg)|*.jpg|JPEG (*.jpeg)|*.jpeg|BMP (*.bmp)|*.bmp|PNG (*.png)|*.png";
            OpenFileDialog.Multiselect = false;
            OpenFileDialog.Title = "Chọn Hình";
            DialogResult Result = OpenFileDialog.ShowDialog();
            if (Result == DialogResult.OK)
            {
                sanpham.PathAnh = OpenFileDialog.FileName;
                sanpham.TenAnh = Path.GetFileName(sanpham.PathAnh);
                sanpham.DoiAnh = true;
                string ext = Path.GetExtension(OpenFileDialog.FileName);
                while (File.Exists(Path.Combine(PathImg, sanpham.TenAnh)))
                    sanpham.TenAnh = Functions.RandomName(15) + ext;
                PBHinh.Image = new Bitmap(OpenFileDialog.FileName);
            }
        }

        private void BTLuu_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                LayThongTinSanPham();
                string destFile = System.IO.Path.Combine(PathImg, sanpham.TenAnh);
                try
                {
                    sanpham.ThemSanPham();
                    if (sanpham.DoiAnh)
                        File.Copy(sanpham.PathAnh, destFile);
                    LoadSanPham();
                    Reset();
                    MessageBox.Show("Thêm Sản Phẩm Thành Công", "Thông Báo");
                }
                catch
                {
                    MessageBox.Show("Đã Xãy Ra Lỗi!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BTSua_Click(object sender, EventArgs e)
        {
            if (sanpham.Id == 0)
                MessageBox.Show("Chưa Chọn Sản Phẩm Cần Sửa!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (KiemTra())
                {
                    LayThongTinSanPham();
                    string destFile = System.IO.Path.Combine(PathImg, sanpham.TenAnh);
                    try
                    {
                        sanpham.SuaSanPham();
                        if (sanpham.DoiAnh)
                            File.Copy(sanpham.PathAnh, destFile);
                        LoadSanPham();
                        Reset();
                        MessageBox.Show("Sửa Sản Phẩm Thành Công", "Thông Báo");
                    }
                    catch
                    {
                        MessageBox.Show("Đã Xãy Ra Lỗi!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BTXoa_Click(object sender, EventArgs e)
        {
            if (sanpham.Id == 0)
                MessageBox.Show("Chưa Chọn Sản Phẩm Cần Xóa!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (MessageBox.Show("Bạn Có Chắc Không?", "Xóa Sản Phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        sanpham.XoaSanPham();
                        LoadSanPham();
                        Reset();
                        MessageBox.Show("Xóa Sản Phẩm Thành Công", "Thông Báo");
                    }
                    catch
                    {
                        MessageBox.Show("Đã Xãy Ra Lỗi!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public bool KiemTra()
        {
            if (TBTenSP.Text.Length == 0)
            {
                MessageBox.Show("Chưa Điền Tên Sản Phẩm!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TBTenSP.Focus();
                return false;
            }
            if (sanpham.PathAnh == null)
            {
                MessageBox.Show("Chưa Chọn Hình!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BTChonHinh.Focus();
                return false;
            }
            if (TBGia.Text.Length == 0)
            {
                MessageBox.Show("Chưa Điền Giá!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TBGia.Focus();
                return false;
            }
            if (!Functions.IsNumeric(TBGia.Text))
            {
                MessageBox.Show("Giá Là Số Nguyên!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TBGia.Focus();
                return false;
            }
            if (CBLoaiSP.Text == "---Chọn Loại Sản Phẩm---")
            {
                MessageBox.Show("Chưa Chọn Loại Sản Phẩm!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CBLoaiSP.Focus();
                return false;
            }
            if (TBTinhNangChinh.Text.Length == 0)
            {
                MessageBox.Show("Chưa Chưa Điền Tính Năng Chính!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CBLoaiSP.Focus();
                return false;
            }
            if (TBChiTiet.Text.Length == 0)
            {
                MessageBox.Show("Chưa Chưa Điền Chi Tiết!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CBLoaiSP.Focus();
                return false;
            }
            return true;
        }

        public void LoadSanPham()
        {
            listsanpham = Sanpham.TatCaSanPham();
            if (listsanpham != null)
            {
                var bind = listsanpham.Select(a => new
                {
                    Id = a.Id,
                    Tensp = a.Tensp,
                    Gia = a.Gia,
                    Tenloaisp = a.Loaisanpham.Tenloaisp,
                    Hinh = a.Hinh,
                    Ngayban = a.Ngayban,
                    Tinhnangchinh = a.Tinhnangchinh,
                    Chitiet = a.Chitiet
                }).ToList();
                GVSanPham.DataSource = bind;
            }
            else
                GVSanPham.DataSource = null;
        }

        public void Reset()
        {
            sanpham = new Sanpham();
            TBTenSP.Text = "";
            TBGia.Text = "";
            TBTinhNangChinh.Text = "";
            TBChiTiet.Text = "";
            CBLoaiSP.SelectedIndex = 0;
            PBHinh.Image = Properties.Resources.NoImage;
            DTNgayBan.Value = DateTime.Today;
        }

        public void LayThongTinSanPham()
        {
            sanpham.Tensp = TBTenSP.Text;
            sanpham.Gia = Convert.ToDouble(TBGia.Text);
            sanpham.Ngayban = DTNgayBan.Value;
            sanpham.Tinhnangchinh = TBTinhNangChinh.Text;
            sanpham.Chitiet = TBChiTiet.Text;
            sanpham.Hinh = PathDB + sanpham.TenAnh;
            sanpham.LoaisanphamId = listloaisanpham.Where(loai => loai.Tenloaisp == CBLoaiSP.Text).Select(item => item.Id).FirstOrDefault();
        }

        private void GVSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TBTenSP.Text = GVSanPham.SelectedCells[1].Value.ToString();
            TBGia.Text = GVSanPham.SelectedCells[2].Value.ToString();
            TBTinhNangChinh.Text = GVSanPham.SelectedCells[6].Value.ToString();
            TBChiTiet.Text = GVSanPham.SelectedCells[7].Value.ToString();
            int loaisanpham = listloaisanpham.Where(loai => loai.Tenloaisp == GVSanPham.SelectedCells[3].Value.ToString()).Select(item => item.Id).FirstOrDefault();
            CBLoaiSP.SelectedIndex = loaisanpham;
            DTNgayBan.Value = DateTime.Parse(GVSanPham.SelectedCells[5].Value.ToString());
            string TenAnh = GVSanPham.SelectedCells[4].Value.ToString().Substring(PathDB.Length);
            string DuongDanAnh = Path.Combine(PathImg, TenAnh);
            PBHinh.Image = new Bitmap(DuongDanAnh);
            sanpham.Id = Convert.ToInt32(GVSanPham.SelectedCells[0].Value.ToString());
            sanpham.TenAnh = TenAnh;
            sanpham.PathAnh = DuongDanAnh;
            sanpham.DoiAnh = false;
        }
    }
}
