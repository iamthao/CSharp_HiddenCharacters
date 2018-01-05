using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL
{
    public partial class Khachhang
    {
        public static Khachhang TimKiemKhachHang(string Username)
        {
            return DAL.DalKhachhang.TimKiemKhachHang(Username);
        }

        public void Them()
        {
            DAL.DalKhachhang.Them(this);
        }
    }
}
