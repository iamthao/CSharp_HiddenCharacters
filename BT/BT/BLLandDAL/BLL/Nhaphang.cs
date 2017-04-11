using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL
{
    public partial class Nhaphang
    {
        public void ThemPhieuNhap()
        {
            DAL.DalNhaphang.ThemPhieuNhap(this);
            DAL.DalChitietkho.ThemSanPhamVaoKho(this.Chitietnhaphangs.ToList(), (DateTime)this.Ngaynhap);
        }
    }
}
