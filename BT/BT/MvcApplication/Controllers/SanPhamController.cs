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
    public class SanPhamController : Controller
    {
        public ActionResult TatCaSanPham(int Page = 1)
        {
            List<Sanpham> result = Sanpham.TatCaSanPham();
            if (result.Count > 0)
            {
                ViewData["Kiemtradulieu"] = 1;
                ViewData["Tittle"] = "Sản Phẩm";
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

        public ActionResult ChiTietSanPham(int Id)
        {
            Sanpham sanpham = Sanpham.ChiTietSanPham(Id);
            if (sanpham != null)
            {
                ViewData["Kiemtradulieu"] = 1;
                sanpham.Tinhnangchinh = Functions.ThemCodeHTML(sanpham.Tinhnangchinh);
                sanpham.Chitiet = Functions.ThemCodeHTML(sanpham.Chitiet);
                sanpham.HienGia = sanpham.Gia.ToString();
                sanpham.HienGia = Functions.ChuyenGia(sanpham.HienGia);
                sanpham.SoLuongTon = sanpham.SoLuongTonKho(DateTime.Now);
            }
            else
                ViewData["Kiemtradulieu"] = 0;
            return View(sanpham);
        }

        public ActionResult SanPhamTheoLoai(int LoaisanphamId, int Page = 1)
        {
            List<Sanpham> result = Sanpham.SanPhamTheoLoai(LoaisanphamId);
            if (result.Count > 0)
            {
                ViewData["Kiemtradulieu"] = 1;
                ViewData["Tittle"] = Loaisanpham.TatCaLoaiSanPham().Where(lsp => lsp.Id == LoaisanphamId).Select(ten => ten.Tenloaisp).FirstOrDefault();
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

        public ActionResult SanPhamTheoNhom(int NhomsanphamId, int Page = 1)
        {
            List<Sanpham> result = Sanpham.SanPhamTheoNhom(NhomsanphamId);
            if (result.Count > 0)
            {
                ViewData["Kiemtradulieu"] = 1;
                ViewData["Tittle"] = Nhomsanpham.TatCaNhomSanPham().Where(nhom => nhom.Id == NhomsanphamId).Select(item => item.Tennhomsp).FirstOrDefault();
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
