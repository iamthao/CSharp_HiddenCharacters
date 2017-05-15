using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL
{
    public partial class Trangthaihoadon
    {
        public static List<Trangthaihoadon> TatCaTrangThaiHoaDon()
        {
            return DAL.DalTrangthaihoadon.TatCaTrangThaiHoaDon();
        }
    }
}
