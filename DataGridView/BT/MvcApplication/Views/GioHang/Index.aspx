<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BLLandDAL.Hoadon>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% if (ViewData["Kiemtradulieu"].ToString() == "1")
   {%>
<script type="text/javascript">
    function ThanhToan() {
        var url = '/GioHang/ThanhToan';
        var result;
        $.ajax({
            type: 'POST',
            url: url,
            dataType: 'html',
            async: false,
            success: function (data) { result = data; }
        });
        switch (result) {
            case '0':
                alert('Đã Xảy Ra Lỗi!');
                document.location = '/SanPham/TatCaSanPham';
                break;
            case '1':
                alert('Vui Lòng Đăng Nhập');
                break;
            case '2':
                alert('Sản Phẩm Sẽ Được Giao Đến Sớm Nhất!');
                document.location = '/SanPham/TatCaSanPham';
                break;
        }
    }
</script>
<table width="710" class="boxct" align="center">
    <tr>
        <td class="title" align="left">Thông Tin Giỏ Hàng</td>
    </tr>
    <tr>
        <td>
            <table class="boxct1" width="100%">
                <thead>
                    <tr class="menubg">
                        <th>Id</th>
                        <th>Tên</th>
                        <th>Giá</th>
                        <th>Số Lượng</th>
                        <th>Thành Tiền</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (BLLandDAL.Chitiethoadon CTHD in Model.Chitiethoadons)
                       { %>
                        <tr class="chusanpham">
                            <td><%= CTHD.SanphamId %></td>
                            <td><%= CTHD.Sanpham.Tensp %></td>
                            <td><%= CTHD.Gia %></td>
                            <td><%= CTHD.Soluong %></td>
                            <td><%= Convert.ToInt64(CTHD.Tong) %></td>
                            <td><%= Html.ActionLink("Xóa", "Xoa", "Giohang", new { SanPhamId = CTHD.SanphamId }, new { @class = "number", onclick = "return confirm('Bạn Có Chắc?');" })%></td>
                        </tr>
                    <%} %>
                </tbody>
            </table> 
        </td>
    </tr>
    <tr>
        <td>
            <table class="boxct1" width="100%">
                <tr class="chusanpham">
                    <td align="right">Tổng Tiền: <%= Convert.ToInt64(Model.Tongtien) %> VNĐ</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <a href="<%= ResolveClientUrl("~/GioHang/ThanhToan") %>"><input type="button" value="Thanh Toán" onclick="ThanhToan(); return false;" /></a>
        </td>
    </tr>
</table>
<% } else { %>
<table width="710" class="boxct" align="center">
    <tr>
        <td class="title" align="left">Thông Tin Giỏ Hàng</td>
    </tr>
    <tr>
        <td>
            <table class="boxct1" width="100%">
                <tr>
                    <td class="chusanpham">Giỏ Hàng Rỗng</td>
                </tr>
            </table>
        </td>
    </tr>
</table>       
<% } %>
</asp:Content>

