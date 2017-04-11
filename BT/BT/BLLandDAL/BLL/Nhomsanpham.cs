using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL
{
    public partial class Nhomsanpham
    {
        public static List<Nhomsanpham> TatCaNhomSanPham()
        {
            return DAL.DalNhomsanpham.TatCaNhomSanPham();
        }
    }
}
