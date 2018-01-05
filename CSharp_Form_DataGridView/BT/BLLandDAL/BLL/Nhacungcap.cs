using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL
{
    public partial class Nhacungcap
    {
        public static List<Nhacungcap> TatCaNhaCungCap()
        {
            return DAL.DalNhacungcap.TatCaNhaCungCap();
        }
    }
}
