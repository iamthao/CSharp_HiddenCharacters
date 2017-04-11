using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    public class TimKiemNangCao
    {
        private string tensp;
        public string TenSP
        {
            get { return tensp; }
            set { tensp = value; }
        }

        private int loaisanphamid;
        public int LoaiSanPhamId
        {
            get { return loaisanphamid; }
            set { loaisanphamid = value; }
        }

        private float giatu;
        public float GiaTu
        {
            get { return giatu; }
            set { giatu = value; }
        }

        private float giaden;
        public float GiaDen
        {
            get { return giaden; }
            set { giaden = value; }
        }
    }
}