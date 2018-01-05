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
    public partial class FBaoCao : Form
    {
        public FBaoCao()
        {
            InitializeComponent();
        }

        private void BTThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTLapBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                if (DTTuNgay.Value < DTDenNgay.Value)
                {
                    List<Hoadon> ListHoaDon = Hoadon.TatCaHoaDon().Where(hd => hd.Ngaylap.Value.Date >= DTTuNgay.Value.Date && hd.Ngaylap.Value.Date <= DTDenNgay.Value.Date).ToList();
                    List<BCDoanhThu> List = new List<BCDoanhThu>();
                    string Titile = "Danh Sách Hóa Đơn";
                    foreach (Hoadon HD in ListHoaDon)
                    {
                        BCDoanhThu BCDT = new BCDoanhThu();
                        BCDT.IDHOADON = HD.Id;
                        BCDT.IDKHACHHANG = (int)HD.KhachhangId;
                        BCDT.TENKHACHHANG = HD.Khachhang.Tenkh;
                        BCDT.NGAYLAP = HD.Ngaylap.Value;
                        BCDT.THANHTIEN = (int)HD.Tongtien;
                        List.Add(BCDT);
                    }
                    if (List.Count == 0)
                    {
                        BCDoanhThu BCDT = new BCDoanhThu();
                        BCDT.IDHOADON = 0;
                        BCDT.IDKHACHHANG = 0;
                        BCDT.TENKHACHHANG = "---------------------";
                        BCDT.NGAYLAP = DateTime.Today.Date;
                        BCDT.THANHTIEN = 0;
                        List.Add(BCDT);
                        Titile = "Không Có Hóa Đơn";
                    }

                    CRDoanhThu CR = new CRDoanhThu();
                    DateTime TuNgay = DTTuNgay.Value.Date;
                    DateTime DenNgay = DTDenNgay.Value.Date;

                    CrystalDecisions.Windows.Forms.CrystalReportViewer CRVHienThi = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                    CRVHienThi.ReportSource = CR;
                    CRVHienThi.Dock = DockStyle.Fill;

                    CR.SetDataSource(List);
                    CR.SetParameterValue("TuNgay", TuNgay.Date);
                    CR.SetParameterValue("DenNgay", DenNgay.Date);
                    CR.SetParameterValue("Titile", Titile);

                    Form HienBaoCao = new Form();
                    HienBaoCao.Text = "Báo Cáo Doanh Thu";
                    HienBaoCao.Controls.Add(CRVHienThi);
                    HienBaoCao.WindowState = FormWindowState.Maximized;
                    HienBaoCao.ShowDialog();
                    CR.Close();
                }
                else
                    MessageBox.Show("Ngày Từ Lớn Hơn Ngày Đến!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Đã Xãy Ra Lỗi!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
