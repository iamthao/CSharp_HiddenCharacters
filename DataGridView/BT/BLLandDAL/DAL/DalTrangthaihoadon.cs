using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLLandDAL;

namespace BLLandDAL.DAL
{
    class DalTrangthaihoadon
    {
        public static List<Trangthaihoadon> TatCaTrangThaiHoaDon()
        {
            DienmayEntities entities = new DienmayEntities();
            return (from trangthai in entities.Trangthaihoadons
                    select trangthai).ToList();
        }
    }
}
