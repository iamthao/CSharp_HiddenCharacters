using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL
{
    public partial class Chitietkho
    {
        public static List<Sanpham> ThongKeSanPhamTonKho(List<Sanpham> ListSanPham, DateTime Ngay)
        {
            return DAL.DalChitietkho.ThongKeSanPhamTonKho(ListSanPham, Ngay);
        }
    }
}
