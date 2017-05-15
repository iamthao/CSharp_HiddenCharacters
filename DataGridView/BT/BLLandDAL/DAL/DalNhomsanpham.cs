using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL.DAL
{
    class DalNhomsanpham
    {
        public static List<Nhomsanpham> TatCaNhomSanPham()
        {
            DienmayEntities entities = new DienmayEntities();
            return (from nhomsanpham in entities.Nhomsanphams
                    select nhomsanpham).ToList();
        }
    }
}
