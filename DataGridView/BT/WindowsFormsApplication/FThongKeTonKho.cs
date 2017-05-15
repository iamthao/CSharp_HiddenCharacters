using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLLandDAL;
using BLLandDAL.BaoCao;

namespace WindowsFormsApplication
{
    public partial class FThongKeTonKho : Form
    {
        List<Sanpham> ListSanPham = new List<Sanpham>();
        List<Sanpham> ListSanPhamThongKe = new List<Sanpham>();

        public FThongKeTonKho()
        {
            InitializeComponent();
        }

        private void BTTim_Click(object sender, EventArgs e)
        {
            if (TBTenSP.Text.Length > 0)
            {
                ListSanPham = Sanpham.TimKiem(TBTenSP.Text);
                GVSanPham.AutoGenerateColumns = false;
                GVSanPham.DataSource = ListSanPham;
            }
            else
                MessageBox.Show("Chưa Điền Tên Sản Phẩm Cần Tìm!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BTTatCa_Click(object sender, EventArgs e)
        {
            LoadSanPham();
        }

        private void BTQuaPhai_Click(object sender, EventArgs e)
        {
            try
            {
                if (GVSanPham.Rows.Count > 0)
                {
                    if (!TimSanPhamTrongGVThongKeSanPham(Convert.ToInt32(GVSanPham.SelectedCells[0].Value.ToString())))
                    {
                        Sanpham SP = new Sanpham();
                        SP.Id = Convert.ToInt32(GVSanPham.SelectedCells[0].Value.ToString());
                        SP.Tensp = GVSanPham.SelectedCells[1].Value.ToString();
                        ListSanPhamThongKe.Add(SP);
                        HienGVThongKeSanPham();
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

        private void BTQuaPhaiHet_Click(object sender, EventArgs e)
        {
            try
            {
                if (GVSanPham.Rows.Count > 0)
                {
                    for (int i = 0; i < GVSanPham.Rows.Count; i++)
                    {
                        if (!TimSanPhamTrongGVThongKeSanPham(Convert.ToInt32(GVSanPham.Rows[i].Cells[0].Value.ToString())))
                        {
                            Sanpham SP = new Sanpham();
                            SP.Id = Convert.ToInt32(GVSanPham.Rows[i].Cells[0].Value.ToString());
                            SP.Tensp = GVSanPham.Rows[i].Cells[1].Value.ToString();
                            ListSanPhamThongKe.Add(SP);
                            HienGVThongKeSanPham();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Đã Xãy Ra Lỗi!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTQuaTrai_Click(object sender, EventArgs e)
        {
            if (GVThongKeSanPham.Rows.Count > 0)
            {
                foreach (Sanpham SP in ListSanPhamThongKe)
                    if (SP.Id == Convert.ToInt32(GVThongKeSanPham.SelectedRows[0].Cells[0].Value.ToString()))
                    {
                        ListSanPhamThongKe.Remove(SP);
                        break;
                    }
                HienGVThongKeSanPham();
            }
        }

        private void BTQuaTraiHet_Click(object sender, EventArgs e)
        {
            ListSanPhamThongKe = new List<Sanpham>();
            HienGVThongKeSanPham();
        }

        private void BTThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                if (DTNgay.Value.Date <= DateTime.Today.Date)
                {
                    if (ListSanPhamThongKe.Count > 0)
                    {
                        ListSanPhamThongKe = Chitietkho.ThongKeSanPhamTonKho(ListSanPhamThongKe, DTNgay.Value);
                        HienThongKe();
                    }
                    else
                        MessageBox.Show("Chưa Chọn Sản Phẩm Cần Thống Kê!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Ngày Sẽ Thống Kê Lơn Hơn Ngày Hiện Tại!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Đã Xãy Ra Lỗi!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FThongKeTonKho_Load(object sender, EventArgs e)
        {
            LoadSanPham();
        }

        private void BTXuatBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                if (DTNgay.Value.Date <= DateTime.Today.Date)
                {
                    if (ListSanPhamThongKe.Count > 0)
                    {
                        ListSanPhamThongKe = Chitietkho.ThongKeSanPhamTonKho(ListSanPhamThongKe, DTNgay.Value);
                        List<BCSanPhamTon> List = new List<BCSanPhamTon>();
                        foreach (Sanpham SP in ListSanPhamThongKe)
                        {
                            BCSanPhamTon SPTon = new BCSanPhamTon();
                            SPTon.ID = SP.Id;
                            SPTon.TEN = SP.Tensp;
                            SPTon.SOLUONGTON = SP.SoLuongTon;
                            List.Add(SPTon);
                        }
                        CRSanPhamTon CR = new CRSanPhamTon();
                        DateTime Ngay = DTNgay.Value.Date;

                        CrystalDecisions.Windows.Forms.CrystalReportViewer CRVHienThi = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                        CRVHienThi.ReportSource = CR;
                        CRVHienThi.Dock = DockStyle.Fill;
                        CR.SetDataSource(List);
                        CR.SetParameterValue("Ngay", Ngay.Date);

                        Form HienBaoCao = new Form();
                        HienBaoCao.Text = "Báo Cáo Sản Phẩm Tồn";
                        HienBaoCao.Controls.Add(CRVHienThi);
                        HienBaoCao.WindowState = FormWindowState.Maximized;
                        HienBaoCao.ShowDialog();
                        CR.Close();
                    }
                    else
                        MessageBox.Show("Chưa Chọn Sản Phẩm Cần Thống Kê!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Ngày Sẽ Thống Kê Lơn Hơn Ngày Hiện Tại!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Đã Xãy Ra Lỗi!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadSanPham()
        {
            ListSanPham = Sanpham.TatCaSanPham();
            GVSanPham.AutoGenerateColumns = false;
            GVSanPham.DataSource = ListSanPham;
        }

        public bool TimSanPhamTrongGVThongKeSanPham(int SanPhamId)
        {
            foreach (Sanpham SP in ListSanPhamThongKe)
                if (SP.Id == SanPhamId)
                    return true;
            return false;
        }

        public void HienGVThongKeSanPham()
        {
            if (ListSanPhamThongKe != null)
            {
                var bind = ListSanPhamThongKe.Select(a => new
                {
                    Id = a.Id,
                    TenSP = a.Tensp
                }).OrderBy(item => item.Id).ToList();
                GVThongKeSanPham.AutoGenerateColumns = false;
                GVThongKeSanPham.DataSource = bind;
            }
            else
                GVThongKeSanPham.DataSource = null;
        }

        public void HienThongKe()
        {
            if (ListSanPhamThongKe != null)
            {
                var bind = ListSanPhamThongKe.Select(a => new
                {
                    Id = a.Id,
                    TenSP = a.Tensp,
                    SoLuong = a.SoLuongTon
                }).OrderBy(item => item.Id).ToList();
                GVThongKeSanPham.AutoGenerateColumns = false;
                GVThongKeSanPham.DataSource = bind;
            }
            else
                GVThongKeSanPham.DataSource = null;
        }
    }
}
