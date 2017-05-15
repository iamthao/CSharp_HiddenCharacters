using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLLandDAL;

namespace BLLandDAL.DAL
{
    class DalNhaphang
    {
        public static void ThemPhieuNhap(Nhaphang NhapHang)
        {
            DienmayEntities entities = new DienmayEntities();
            NhapHang.Id = entities.Nhaphangs.Count() > 0 ? entities.Nhaphangs.Max(h => h.Id) + 1 : 1;
            int ChiTietNhapHangId = entities.Chitietnhaphangs.Count() > 0 ? entities.Chitietnhaphangs.Max(h => h.Id) + 1 : 1;
            foreach (Chitietnhaphang CTNH in NhapHang.Chitietnhaphangs)
            {
                CTNH.Id = ChiTietNhapHangId;
                CTNH.NhaphangId = NhapHang.Id;
                ChiTietNhapHangId++;
            }
            entities.Nhaphangs.AddObject(NhapHang);
            entities.SaveChanges();
        }
    }
}
