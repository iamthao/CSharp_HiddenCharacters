using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL.DAL
{
    class DalSanpham
    {
        public static void ThemSanPham(Sanpham sanpham)
        {
            DienmayEntities entities = new DienmayEntities();
            entities.Sanphams.AddObject(sanpham);
            entities.SaveChanges();
        }

        public static void SuaSanPham(Sanpham sanpham)
        {
            DienmayEntities entities = new DienmayEntities();
            Sanpham spsua = entities.Sanphams.FirstOrDefault(i => i.Id == sanpham.Id);
            spsua.Tensp = sanpham.Tensp;
            spsua.Gia = sanpham.Gia;
            spsua.Tinhnangchinh = sanpham.Tinhnangchinh;
            spsua.Chitiet = sanpham.Chitiet;
            spsua.Hinh = sanpham.Hinh;
            spsua.LoaisanphamId = sanpham.LoaisanphamId;
            spsua.Ngayban = sanpham.Ngayban;
            entities.SaveChanges();
        }

        public static void XoaSanPham(Sanpham sanpham)
        {
            DienmayEntities entities = new DienmayEntities();
            Sanpham spxoa = entities.Sanphams.FirstOrDefault(i => i.Id == sanpham.Id);
            entities.Sanphams.DeleteObject(spxoa);
            entities.SaveChanges();
        }

        public static int TaoId()
        {
            DienmayEntities entities = new DienmayEntities();
            int Id = entities.Sanphams.Count() > 0 ? entities.Sanphams.Max(c => c.Id) + 1 : 1;
            return Id;
        }

        public static List<Sanpham> TatCaSanPham()
        {
            DienmayEntities entities = new DienmayEntities();
            return (from sanpham in entities.Sanphams select sanpham).ToList();
        }

        public static Sanpham ChiTietSanPham(int Id)
        {
            DienmayEntities entities = new DienmayEntities();
            return (from sanpham in entities.Sanphams
                    where sanpham.Id == Id
                    select sanpham).FirstOrDefault();
        }

        public static List<Sanpham> SanPhamTheoLoai(int LoaisanphamId)
        {
            DienmayEntities entities = new DienmayEntities();
            return (from sanpham in entities.Sanphams
                    where sanpham.LoaisanphamId == LoaisanphamId
                    select sanpham).ToList();
        }

        public static List<Sanpham> SanPhamTheoNhom(int NhomsanphamId)
        {
            DienmayEntities entities = new DienmayEntities();
            return (from sanpham in entities.Sanphams
                    where sanpham.Loaisanpham.Nhomsanpham.Id == NhomsanphamId
                    select sanpham).ToList();
        }

        public static List<Sanpham> TimKiem(string Key)
        {
            DienmayEntities entities = new DienmayEntities();
            return (from sanpham in entities.Sanphams
                    where sanpham.Tensp.Contains(Key)
                    select sanpham).ToList();
        }

        public static List<Sanpham> TimKiem(string TenSP, int LoaisanphamId, float GiaTu, float GiaDen)
        {
            DienmayEntities entities = new DienmayEntities();
            return (from sanpham in entities.Sanphams
                    where sanpham.Tensp.Contains(TenSP) && sanpham.Gia >= GiaTu
                    && sanpham.Gia <= GiaDen && sanpham.LoaisanphamId == LoaisanphamId
                    select sanpham).ToList();
        }
    }
}
