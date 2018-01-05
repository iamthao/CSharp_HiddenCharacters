using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLLandDAL;

namespace BLLandDAL.DAL
{
    class DalKho
    {
        public static List<Kho> TatCaKho()
        {
            DienmayEntities entities = new DienmayEntities();
            return (from kho in entities.Khoes
                    select kho).ToList();
        }
    }
}
