using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL
{
    public partial class Sanpham
    {
        private string hiengia;
        public string HienGia
        {
            get { return hiengia; }
            set { hiengia = value; }
        }

        private string pathanh;
        public string PathAnh
        {
            get { return pathanh; }
            set { pathanh = value; }
        }

        private string tenanh;
        public string TenAnh
        {
            get { return tenanh; }
            set { tenanh = value; }
        }

        private bool doianh;
        public bool DoiAnh
        {
            get { return doianh; }
            set { doianh = value; }
        }

        private int soluongton;
        public int SoLuongTon
        {
            get { return soluongton; }
            set { soluongton = value; }
        }

        public static List<Sanpham> TatCaSanPham()
        {
            return DAL.DalSanpham.TatCaSanPham();
        }

        public static Sanpham ChiTietSanPham(int Id)
        {
            return DAL.DalSanpham.ChiTietSanPham(Id);
        }

        public static List<Sanpham> SanPhamTheoLoai(int LoaisanphamId)
        {
            return DAL.DalSanpham.SanPhamTheoLoai(LoaisanphamId);
        }

        public static List<Sanpham> SanPhamTheoNhom(int NhomsanphamId)
        {
            return DAL.DalSanpham.SanPhamTheoNhom(NhomsanphamId);
        }

        public static List<Sanpham> TimKiem(string Key)
        {
            return DAL.DalSanpham.TimKiem(Key);
        }

        public static List<Sanpham> TimKiem(string TenSP, int LoaisanphamId, float GiaTu, float GiaDen)
        {
            return DAL.DalSanpham.TimKiem(TenSP, LoaisanphamId, GiaTu, GiaDen);
        }

        public void ThemSanPham()
        {
            this.Id = DAL.DalSanpham.TaoId();
            DAL.DalSanpham.ThemSanPham(this);
        }

        public void SuaSanPham()
        {
            DAL.DalSanpham.SuaSanPham(this);
        }

        public void XoaSanPham()
        {
            DAL.DalSanpham.XoaSanPham(this);
        }

        public int SoLuongTonKho(DateTime Ngay)
        {
            return DAL.DalChitietkho.ThongKeSanPhamTonKho(this, Ngay);
        }
    }
}
