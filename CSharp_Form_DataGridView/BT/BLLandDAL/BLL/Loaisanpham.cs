using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL
{
    public partial class Loaisanpham
    {
        public static List<Loaisanpham> TatCaLoaiSanPham()
        {
            return DAL.DalLoaisanpham.TatCaLoaiSanPham();
        }
    }
}
