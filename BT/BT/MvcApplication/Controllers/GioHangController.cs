using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MvcApplication.Models;
using BLLandDAL;

namespace MvcApplication.Controllers
{
    public class GioHangController : Controller
    {
        Hoadon HoaDon = new Hoadon();

        public ActionResult Index()
        {
            if (Session["Giohang"] != null)
            {
                HoaDon = Session["Giohang"] as Hoadon;
                float TongTien = 0;
                foreach (Chitiethoadon CTHD in HoaDon.Chitiethoadons)
                    TongTien = TongTien + CTHD.Tong;
                HoaDon.Tongtien = TongTien;
                ViewData["Kiemtradulieu"] = 1;
            }
            else
                ViewData["Kiemtradulieu"] = 0;
            return View(HoaDon);
        }

        [HttpPost]
        public int ThemGioHang(int Id, int Soluong = 1)
        {
            int Trangthai = 0;
            if (Session["Giohang"] == null)
                HoaDon = new Hoadon();
            else
                HoaDon = Session["Giohang"] as Hoadon;
            if (Functions.TimSPTrongGioHang(Id, HoaDon))
                Trangthai = 1;
            else
            {
                Sanpham sanpham = Sanpham.ChiTietSanPham(Id);
                sanpham.SoLuongTon = sanpham.SoLuongTonKho(DateTime.Now);
                if (sanpham.SoLuongTon >= Soluong)
                {
                    Chitiethoadon CTHD = new Chitiethoadon();
                    CTHD.SanphamId = sanpham.Id;
                    CTHD.Sanpham = new Sanpham();
                    CTHD.Sanpham.Tensp = sanpham.Tensp;
                    CTHD.Gia = sanpham.Gia;
                    CTHD.Soluong = Soluong;
                    CTHD.Tong = (float)sanpham.Gia * Soluong;
                    HoaDon.Chitiethoadons.Add(CTHD);
                    Trangthai = 2;
                }
                else
                    Trangthai = 3;
            }
            Session["Giohang"] = HoaDon;
            return Trangthai;
        }

        public ActionResult Xoa(int SanPhamId)
        {
            HoaDon = Session["Giohang"] as Hoadon;
            if (Functions.TimSPTrongGioHang(SanPhamId, HoaDon))
                Functions.XoaSPTrongGioHang(SanPhamId, HoaDon);
            else
                return RedirectToAction("Index", "GioHang");
            if (HoaDon.Chitiethoadons.Count > 0)
                Session["Giohang"] = HoaDon;
            else
                Session["Giohang"] = null;
            return RedirectToAction("Index", "GioHang");
        }

        public int ThanhToan()
        {
            int Trangthai = 0;
            if (Session["TenKhachHang"] == null)
                Trangthai = 1;
            else
            {
                Hoadon HD = (Hoadon)Session["Giohang"];
                HoaDon.TrangthaihoadonId = 1;
                HoaDon.KhachhangId = (int)Session["KhachHangId"];
                float TongTien = 0;
                foreach (Chitiethoadon CTHD in HD.Chitiethoadons)
                {
                    TongTien = TongTien + CTHD.Tong;
                    Chitiethoadon CT = new Chitiethoadon();
                    CT.SanphamId = CTHD.SanphamId;
                    CT.Gia = CTHD.Gia;
                    CT.Soluong = CTHD.Soluong;
                    HoaDon.Chitiethoadons.Add(CT);
                }
                HoaDon.Tongtien = TongTien;
                HoaDon.Ngaylap = DateTime.Today;
                HoaDon.ThemHoaDon();
                Session["Giohang"] = null;
                Trangthai = 2;
            }
            return Trangthai;
        }
    }
}
