using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL.DAL
{
    class DalNhacungcap
    {
        public static List<Nhacungcap> TatCaNhaCungCap()
        {
            DienmayEntities entities = new DienmayEntities();
            return (from nhacungcap in entities.Nhacungcaps
                    select nhacungcap).ToList();
        }
    }
}
