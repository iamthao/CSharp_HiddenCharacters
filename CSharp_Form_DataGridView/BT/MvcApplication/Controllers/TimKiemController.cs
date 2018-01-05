using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLLandDAL;
using PagedList;
using MvcApplication.Models;

namespace MvcApplication.Controllers
{
    public class TimKiemController : Controller
    {
        public ActionResult TimKiemCoBan(string Key, int Kt = 0, int Page = 1)
        {
            if (Kt == 0 && Key == null)
                RedirectToAction("TatCaSanPham", "SanPham");
            else
            {
                if (Key != null)
                    Session["Key"] = Key;
                else
                    if (Kt == 1)
                        Key = Session["Key"].ToString();
            }
            List<Sanpham> result = Sanpham.TimKiem(Key);
            if (result.Count > 0)
            {
                ViewData["Kiemtradulieu"] = 1;
                ViewData["Tittle"] = "Kết Quả Tìm Kiếm Với Từ Khóa \"" + Key + "\"";
                for (int i = 0; i < result.Count; i++)
                {
                    result[i].Tinhnangchinh = Functions.ThemCodeHTML(result[i].Tinhnangchinh);
                    result[i].HienGia = result[i].Gia.ToString();
                    result[i].HienGia = Functions.ChuyenGia(result[i].HienGia);
                }
            }
            else
            {
                ViewData["Kiemtradulieu"] = 0;
            }
            return View(result.ToPagedList(Page, GlobalVariable.PageSize));
        }

        public ActionResult TimKiemNangCao()
        {
            ViewData["Nhomsanpham"] = Nhomsanpham.TatCaNhomSanPham();
            ViewData["Loaisanpham"] = Loaisanpham.TatCaLoaiSanPham();
            return View();
        }

        public ActionResult KetQua(TimKiemNangCao Key, int Kt = 0, int Page = 1)
        {
            if (Kt == 0 && Key == null)
                RedirectToAction("TatCaSanPham", "SanPham");
            else
            {
                if (Key.TenSP != null && Key.LoaiSanPhamId != 0)
                    Session["TimKiemNangCao"] = Key;
                else
                    if (Kt == 1)
                        Key = (TimKiemNangCao)Session["TimKiemNangCao"];
            }
            List<Sanpham> result = Sanpham.TimKiem(Key.TenSP, Key.LoaiSanPhamId, Key.GiaTu, Key.GiaDen);
            if (result.Count > 0)
            {
                ViewData["Kiemtradulieu"] = 1;
                ViewData["Tittle"] = "Kết Quả Tìm";
                for (int i = 0; i < result.Count; i++)
                {
                    result[i].Tinhnangchinh = Functions.ThemCodeHTML(result[i].Tinhnangchinh);
                    result[i].HienGia = result[i].Gia.ToString();
                    result[i].HienGia = Functions.ChuyenGia(result[i].HienGia);
                }
            }
            else
            {
                ViewData["Kiemtradulieu"] = 0;
            }
            return View(result.ToPagedList(Page, GlobalVariable.PageSize));
        }
    }
}
