using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL.DAL
{
    class DalHoadon
    {
        public static void ThemHoaDon(Hoadon HoaDon)
        {
            DienmayEntities entities = new DienmayEntities();
            HoaDon.Id = entities.Hoadons.Count() > 0 ? entities.Hoadons.Max(h => h.Id) + 1 : 1;
            int ChiTietHoaDonId = entities.Chitiethoadons.Count() > 0 ? entities.Chitiethoadons.Max(c => c.Id) + 1 : 1;
            foreach (Chitiethoadon CTHD in HoaDon.Chitiethoadons)
            {
                CTHD.Id = ChiTietHoaDonId;
                CTHD.HoadonId = HoaDon.Id;
                ChiTietHoaDonId++;
            }
            entities.Hoadons.AddObject(HoaDon);
            entities.SaveChanges();
        }

        public static List<Hoadon> TatCaHoaDon()
        {
            DienmayEntities entities = new DienmayEntities();
            return (from hoadon in entities.Hoadons
                    select hoadon).ToList();
        }

        public static List<Hoadon> TimTheoTrangThai(int TrangThaiId)
        {
            DienmayEntities entities = new DienmayEntities();
            return (from hoadon in entities.Hoadons
                    where hoadon.TrangthaihoadonId == TrangThaiId
                    select hoadon).ToList();
        }

        public static List<Hoadon> TimTheoNgay(DateTime Ngay)
        {
            DienmayEntities entities = new DienmayEntities();
            return (from hoadon in entities.Hoadons
                    select hoadon).ToList().Where(item => DateTime.Compare(item.Ngaylap.Value.Date, Ngay.Date) == 0).ToList();
        }

        public static Hoadon ThongTinHoaDon(int HoaDonId)
        {
            DienmayEntities entities = new DienmayEntities();
            return (from hoadon in entities.Hoadons
                    where hoadon.Id == HoaDonId
                    select hoadon).FirstOrDefault();
        }

        public static void XoaHoaDon(Hoadon HoaDon)
        {
            DienmayEntities entities = new DienmayEntities();
            foreach (Chitiethoadon ChiTiet in HoaDon.Chitiethoadons)
            {
                Chitiethoadon ChiTietXoa = entities.Chitiethoadons.FirstOrDefault(i => i.Id == ChiTiet.Id);
                entities.Chitiethoadons.DeleteObject(ChiTietXoa);
            }
            entities.SaveChanges();
            Hoadon HoaDonXoa = entities.Hoadons.First(i => i.Id == HoaDon.Id);
            entities.Hoadons.DeleteObject(HoaDonXoa);
            entities.SaveChanges();
        }

        public static void SuaHoaDon(Hoadon HoaDon)
        {
            DienmayEntities entities = new DienmayEntities();
            Hoadon HDSua = entities.Hoadons.FirstOrDefault(hd => hd.Id == HoaDon.Id);
            HDSua.TrangthaihoadonId = HoaDon.TrangthaihoadonId;
            entities.SaveChanges();
        }
    }
}
