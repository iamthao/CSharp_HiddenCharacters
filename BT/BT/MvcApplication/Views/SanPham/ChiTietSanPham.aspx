<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BLLandDAL.Sanpham>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Chi Tiết Sản Phẩm
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% if (ViewData["Kiemtradulieu"].ToString() == "1")
   {%>

<script type="text/javascript" language="javascript">
    function CartGo() {
        var f = document.FGiohang;
        $.post(f.action, $(f).serialize(), function (data) {
            switch (data) {
                case '1':
                    alert('Sản Phẩm Đã Có Trong Giỏ Hàng');
                    break;
                case '2':
                    alert('Đã Thêm Vào Giỏ Hàng');
                    break;
                case '3':
                    alert('Số Lượng Đặt Mua Lớn Hơn Số Lượng Tồn');
                    break;
            }
        });
    }
</script>
<table width="710" align="center" class="boxct">
    <tr>
        <td>
            <table width="100%" cellspacing="0" align="center" class="boxct1">
                <tr>
                    <td class="title" align="center"><font size="3"><%= Model.Tensp %></font></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" cellspacing="0" align="center">
                <tr>
                    <td align="center"><img align="middle" width="300" height="300" src="<%= ResolveClientUrl(Model.Hinh) %>" alt=""/></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" cellspacing="0" align="center" class="boxct1">
                <tr>
                    <td class="title" align="left">Tính Năng Chính</td>
                </tr>
                <tr>
                    <td align="left"><%= Model.Tinhnangchinh %></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" cellspacing="0" align="center" class="boxct1">
                <tr>
                    <td align="left" width="200"><div class="title">Giá:<font color="FF0000"> <%= Model.HienGia %> </font>VNĐ</div></td>
                </tr>
                <% if (Model.SoLuongTon > 0)
                   {%>
                <tr>
                    <td class="title">Còn Lại: <font color="FF0000"><%= Model.SoLuongTon %></font> Cái</td>
                </tr>
                <tr>
                    <td class="title" align="left">
                        <% using (Html.BeginForm("ThemGioHang", "GioHang", FormMethod.Post, new { name = "FGiohang", id = "FGiohang" }))
                           { %>
                            <input type="hidden" name="Id" value="<%= Model.Id %>"/>
                            <div>
                                Số Lượng
                                <select name="Soluong" id="Select1">
                                <% for (int i = 1; i <= Model.SoLuongTon; i++)
                                   {%>
                                    <option value="<%= i %>"><%= i %></option>
                                <% } %>
                                </select>
                            </div>
                            <div><input class="Cart" type="submit" value="" onclick="CartGo(); return false;" /></div>
                        <% } %>
                    </td>
                </tr>
                <% }
                   else
                   {%>
                <tr>
                    <td class="title"><font color="FF0000">Hết Hàng</font></td>
                </tr>
                <% } %>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" cellspacing="0" align="center" class="boxct1">
                <tr>
                    <td class="title" align="left">Chi Tiết</td>
                </tr>
                <tr>
                    <td align="left"><%= Model.Chitiet %></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<% }
   else
   {%>
    <table width="710" align="center" class="boxct">
        <tr>
            <td>
                <table width="100%" align="center" class="boxct1">
                    <tr>
                        <td class="title" align="center">Không Có Dữ Liệu</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
<% } %>
</asp:Content>
