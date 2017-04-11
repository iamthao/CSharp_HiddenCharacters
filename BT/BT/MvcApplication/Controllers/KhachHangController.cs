using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLLandDAL;

namespace MvcApplication.Controllers
{
    public class KhachHangController : Controller
    {
        [HttpPost]
        public int DangNhap(string Username, string Password)
        {
            int TrangThai = 0;
            Khachhang khachhang = Khachhang.TimKiemKhachHang(Username);
            if (khachhang != null)
            {
                if (khachhang.Password == Password)
                {
                    if (Session["TenKhachHang"] == null)
                    {
                        Session["KhachHangId"] = khachhang.Id;
                        Session["TenKhachHang"] = khachhang.Tenkh;
                        TrangThai = 1;
                    }
                }
                else
                    TrangThai = 2;
            }
            else
                TrangThai = 3;
            return TrangThai;
        }

        public ActionResult DangXuat()
        {
            Session["KhachHangId"] = null;
            Session["TenKhachHang"] = null;
            return RedirectToAction("TatCaSanPham", "SanPham");
        }

        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public void DangKy(Khachhang khachhang)
        {
            System.Collections.Specialized.NameValueCollection nvc = Request.Form;
            khachhang.Ngaysinh = new DateTime(Convert.ToInt32(nvc["Nam"]), Convert.ToInt32(nvc["Thang"]), Convert.ToInt32(nvc["Ngay"]));
            khachhang.Ghichu = string.Empty;
            khachhang.LoaikhachhangId = 1;
            khachhang.Gioitinh = nvc["Gioitinh"] == null ? "Nữ" : "Nam";
            khachhang.Them();
            Response.Write("<script>alert('Đăng Ký Thành Công'); document.location = '/Sanpham/Tatcasanpham';</script>");
        }
    }
}
