using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLLandDAL;

namespace BLLandDAL.DAL
{
    class DalChitietkho
    {
        public static void ThemSanPhamVaoKho(List<Chitietnhaphang> ListChiTietNhap, DateTime Ngay)
        {
            DienmayEntities entities = new DienmayEntities();
            int Id = entities.Chitietkhoes.Count() > 0 ? entities.Chitietkhoes.Max(c => c.Id) + 1 : 1;
            int SoLuongCu;
            foreach (Chitietnhaphang CTNH in ListChiTietNhap)
            {
                Chitietkho CTK = entities.Chitietkhoes.OrderByDescending(order => order.Ngay).FirstOrDefault(i => i.SanphamId == CTNH.SanphamId && i.KhoId == CTNH.Nhaphang.KhoId);
                SoLuongCu = CTK == null ? 0 : (int)CTK.Soluong;
                Chitietkho CTKThem = new Chitietkho();
                CTKThem.Id = Id;
                CTKThem.KhoId = CTNH.Nhaphang.KhoId;
                CTKThem.SanphamId = CTNH.SanphamId;
                CTKThem.Soluong = SoLuongCu + CTNH.Soluong;
                CTKThem.Ngay = Ngay;
                entities.Chitietkhoes.AddObject(CTKThem);
                Id++;
            }
            entities.SaveChanges();
        }

        public static void XuatSanPham(List<Chitiethoadon> ListChiTietHD)
        {
            DienmayEntities entities = new DienmayEntities();
            int Id = entities.Chitietkhoes.Count() > 0 ? entities.Chitietkhoes.Max(c => c.Id) + 1 : 1;
            foreach (Chitiethoadon CTHD in ListChiTietHD)
            {
                Chitietkho CTK = entities.Chitietkhoes.OrderByDescending(order => order.Ngay).FirstOrDefault(i => i.SanphamId == CTHD.SanphamId);
                Chitietkho CTKThem = new Chitietkho();
                CTKThem.Id = Id;
                CTKThem.KhoId = 1;
                CTKThem.SanphamId = CTHD.SanphamId;
                CTKThem.Soluong = (int)CTK.Soluong - CTHD.Soluong;
                CTKThem.Ngay = DateTime.Today;
                entities.Chitietkhoes.AddObject(CTKThem);
                Id++;
            }
            entities.SaveChanges();
        }

        public static List<Sanpham> ThongKeSanPhamTonKho(List<Sanpham> ListSanPham, DateTime Ngay)
        {
            DienmayEntities entities = new DienmayEntities();
            List<Chitietkho> ListChiTietKho = new List<Chitietkho>();
            foreach (Kho Kho in entities.Khoes)
            {
                foreach (Sanpham SP in ListSanPham)
                {
                    Chitietkho CTK = entities.Chitietkhoes.OrderByDescending(item => item.Ngay).FirstOrDefault(chitiet => chitiet.KhoId == Kho.Id && chitiet.SanphamId == SP.Id && (chitiet.Ngay.Value <= Ngay));
                    if (CTK != null)
                        ListChiTietKho.Add(CTK);
                }
            }
            List<Sanpham> SanPhamTonKho = new List<Sanpham>();
            foreach (Sanpham SP in ListSanPham)
            {
                Sanpham SPTonKho = new Sanpham();
                SPTonKho.Id = SP.Id;
                SPTonKho.Tensp = SP.Tensp;
                SPTonKho.SoLuongTon = 0;
                foreach (Chitietkho CTK in ListChiTietKho)
                    if (SP.Id == CTK.SanphamId)
                        SPTonKho.SoLuongTon = SPTonKho.SoLuongTon + (int)CTK.Soluong;
                SanPhamTonKho.Add(SPTonKho);
            }
            return SanPhamTonKho;
        }

        public static int ThongKeSanPhamTonKho(Sanpham SP, DateTime Ngay)
        {
            SP.SoLuongTon = 0;
            DienmayEntities entities = new DienmayEntities();
            List<Chitietkho> ListChiTietKho = new List<Chitietkho>();
            foreach (Kho Kho in entities.Khoes)
            {
                Chitietkho CTK = entities.Chitietkhoes.OrderByDescending(item => item.Ngay).FirstOrDefault(chitiet => chitiet.KhoId == Kho.Id && chitiet.SanphamId == SP.Id && (chitiet.Ngay.Value <= Ngay));
                if (CTK != null)
                    ListChiTietKho.Add(CTK);
            }
            foreach (Chitietkho CTK in ListChiTietKho)
                if (SP.Id == CTK.SanphamId)
                    SP.SoLuongTon = SP.SoLuongTon + (int)CTK.Soluong;
            return SP.SoLuongTon;
        }
    }
}
