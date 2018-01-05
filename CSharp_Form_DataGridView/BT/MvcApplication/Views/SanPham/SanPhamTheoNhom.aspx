<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PagedList.IPagedList<BLLandDAL.Sanpham>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Sản Phẩm Theo Nhóm
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% ViewBag.Action = "SanPhamTheoNhom"; %>
    <% Html.RenderPartial("HienDanhSachSanPham"); %>
</asp:Content>
