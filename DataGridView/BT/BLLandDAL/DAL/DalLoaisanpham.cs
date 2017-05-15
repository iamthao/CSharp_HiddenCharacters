using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL.DAL
{
    class DalLoaisanpham
    {
        public static List<Loaisanpham> TatCaLoaiSanPham()
        {
            DienmayEntities entities = new DienmayEntities();
            return (from loaisanpham in entities.Loaisanphams
                    select loaisanpham).ToList();
        }
    }
}
