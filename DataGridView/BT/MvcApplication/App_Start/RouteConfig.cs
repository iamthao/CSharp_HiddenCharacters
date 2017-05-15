using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "San Pham Theo Nhom",
                "SanPham/SanPhamTheoNhom/{NhomsanphamId}",
                new { controller = "SanPham", action = "SanPhamTheoNhom", NhomsanphamId = UrlParameter.Optional }
            );

            routes.MapRoute(
                "San Pham Theo Loai",
                "SanPham/SanPhamTheoLoai/{LoaisanphamId}",
                new { controller = "SanPham", action = "SanPhamTheoLoai", LoaisanphamId = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Chi Tiet San Pham",
                "SanPham/ChiTietSanPham/{Id}",
                new { controller = "SanPham", action = "ChiTietSanPham", Id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "SanPham", action = "TatCaSanPham", id = UrlParameter.Optional } // Parameter defaults
            );
        }
    }
}