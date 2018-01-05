using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLandDAL
{
    public partial class Hoadon
    {
        public void ThemHoaDon()
        {
            DAL.DalHoadon.ThemHoaDon(this);
        }

        public static List<Hoadon> TatCaHoaDon()
        {
            return DAL.DalHoadon.TatCaHoaDon();
        }

        public static List<Hoadon> TimTheoTrangThai(int TrangThaiId)
        {
            return DAL.DalHoadon.TimTheoTrangThai(TrangThaiId);
        }

        public static List<Hoadon> TimTheoNgay(DateTime Ngay)
        {
            return DAL.DalHoadon.TimTheoNgay(Ngay);
        }

        public static Hoadon ThongTinHoaDon(int HoaDonId)
        {
            return DAL.DalHoadon.ThongTinHoaDon(HoaDonId);
        }

        public void XoaHoaDon()
        {
            DAL.DalHoadon.XoaHoaDon(this);
        }

        public bool SuaHoaDon()
        {
            if (this.TrangthaihoadonId == 3)
            {
                List<Sanpham> List = new List<Sanpham>();
                foreach (Chitiethoadon CTHD in this.Chitiethoadons)
                {
                    Sanpham SP = new Sanpham();
                    SP.Id = (int)CTHD.SanphamId;
                    List.Add(SP);
                }
                List = DAL.DalChitietkho.ThongKeSanPhamTonKho(List, DateTime.Now);
                foreach (Chitiethoadon CTHD in this.Chitiethoadons)
                {
                    foreach (Sanpham SP in List)
                    {
                        if (CTHD.SanphamId == SP.Id)
                            if (CTHD.Soluong > SP.SoLuongTon)
                                return false;
                    }
                }
                DAL.DalChitietkho.XuatSanPham(this.Chitiethoadons.ToList());
            }
            DAL.DalHoadon.SuaHoaDon(this);
            return true;
        }
    }
}
