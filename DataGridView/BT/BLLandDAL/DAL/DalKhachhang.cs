using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL.DAL
{
    class DalKhachhang
    {
        public static Khachhang TimKiemKhachHang(string Username)
        {
            DienmayEntities entitise = new DienmayEntities();
            return (from kh in entitise.Khachhangs
                    where kh.Username == Username
                    select kh).FirstOrDefault();
        }

        public static void Them(Khachhang khachhang)
        {
            DienmayEntities entities = new DienmayEntities();
            khachhang.Id = entities.Khachhangs.Count() > 0 ? entities.Khachhangs.Max(c => c.Id) + 1 : 1;
            entities.Khachhangs.AddObject(khachhang);
            entities.SaveChanges();
        }
    }
}
