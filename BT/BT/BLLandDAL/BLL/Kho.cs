using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL
{
    public partial class Kho
    {
        public static List<Kho> TatCaKho()
        {
            return DAL.DalKho.TatCaKho();
        }
    }
}
