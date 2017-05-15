using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BLLandDAL;

namespace MvcApplication.Models
{
    public class Functions
    {
        public static string ChuyenGia(string gia)
        {
            string s = "";
            long dem = 1;
            for (int i = gia.Length - 1; i >= 0; i--)
            {
                if (dem % 3 == 0 && dem != gia.Length)
                {
                    s = s + gia[i] + '.';
                }
                else
                    s = s + gia[i];
                dem++;
            }
            string str = "";
            for (int i = 0; i < s.Length; i++)
                str = str + s[s.Length - i - 1];
            return str;
        }

        public static string ThemCodeHTML(string s)
        {
            s = "<div class=\"chusanpham\">- " + s + "</div>";
            s = s.Replace(". ", "</div><div class=\"chusanpham\">- ");
            return s;
        }

        public static int TimSPTrongGioHang(int Id, DataTable dt)
        {
            int hang = -1;
            for (int i = 0; i < dt.Rows.Count; i++)
                if (Convert.ToInt32(dt.Rows[i]["Id"].ToString()) == Id)
                {
                    hang = i;
                    break;
                }
            return hang;
        }

        public static bool TimSPTrongGioHang(int SanPhamId, Hoadon HoaDon)
        {
            foreach (Chitiethoadon CTHD in HoaDon.Chitiethoadons)
                if (CTHD.SanphamId == SanPhamId)
                    return true;
            return false;
        }

        public static void XoaSPTrongGioHang(int SanPhamId, Hoadon HoaDon)
        {
            foreach (Chitiethoadon CTHD in HoaDon.Chitiethoadons)
                if (CTHD.SanphamId == SanPhamId)
                {
                    HoaDon.Chitiethoadons.Remove(CTHD);
                    break;
                }
        }
    }
}