<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PagedList.IPagedList<BLLandDAL.Sanpham>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Trang Chủ
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% ViewBag.Action = "TatCaSanPham"; %>
    <% Html.RenderPartial("HienDanhSachSanPham"); %>
</asp:Content>
