<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<script type="text/javascript" language="javascript">
    function Timkiem() {
        if ($("#Key").val() == 'Từ Khóa' || $("#Key").val() == '') {
            alert('Chưa Điền Từ Khóa');
            return false;
        }
        return true;
    }
</script>
<table width="1000" cellspacing="0" cellpadding="0" border="0" align="center">
	<tr>
    	<td>
        	<div align="left" style="width:1000;">
                <span><a class="menu_nav current_menu" href="<%= ResolveClientUrl("~/SanPham/TatCaSanPham") %>">Trang chủ</a></span>
                <span class="menu_nav2">|</span>
            	<span><a class="menu_nav" href="<%= ResolveClientUrl("~/SanPham/SanPhamTheoNhom") %>/1">ĐIỆN TỬ</a></span>
                <span class="menu_nav2">|</span>
                <span><a class="menu_nav" href="<%= ResolveClientUrl("~/SanPham/SanPhamTheoNhom") %>/2">ĐIỆN LẠNH</a></span>
				<span class="menu_nav2">|</span>
                <span><a class="menu_nav " href="javascript:void(0)">GIA DỤNG</a></span>
				<span class="menu_nav2">|</span>
                <span><a class="menu_nav" href="javascript:void(0)">VI TÍNH</a></span>
				<span class="menu_nav2">|</span>
                <span><a class="menu_nav" href="javascript:void(0)">DI ĐỘNG</a></span>
				<span class="menu_nav2">|</span>
                <span><a class="menu_nav" href="javascript:void(0)">VIỄN THÔNG</a></span>
            </div>
            <div>
            	<table width="1000" cellspacing="0" cellpadding="0" border="0" align="center">
                	<tr height="40" bgcolor="#005398">
                    	<td width="500">
                        	<div align="left">
                                <% using (Html.BeginForm("TimKiemCoBan", "TimKiem", FormMethod.Post, new { name = "FormTK", id = "FormTK", onsubmit = "return Timkiem();" }))
                                   { %>
                            	<span class="menuchuxanh" style="padding-left:15px">Tìm Kiếm</span>
                                <span><input type="text" size="15" value="Từ Khóa" onblur="if(this.value=='')this.value='Từ Khóa';" onfocus="if(this.value=='Từ Khóa')this.value='';" name="Key" id="Key" /></span>
                                <span><input type="submit" value="Tìm" /></span>
                                <% } %>
                            </div>
                        </td>
                        <td></td>
                        <td style="text-align: right; padding-right:15px;">
                            <span><a class="menuchuxanh" href="<%= ResolveClientUrl("~/TimKiem/TimKiemNangCao") %>">Tìm Nâng Cao</a></span>
                            <span><a class="menuchuxanh" href="<%= ResolveClientUrl("~/GioHang/Index") %>">Giỏ Hàng</a></span>
                        </td>
                    </tr>
                    <tr>
                    	<td colspan="3">
                            <div align="center" style="text-align: center; padding: 5px 0px 5px 0px;">
                            	<a href="javascript:void(0)"><img width="617" height="36" src="<%= ResolveClientUrl("~/Content/Img/HTSTDM.jpg") %>" alt="" /></a>
                        		<a href="javascript:void(0)"><img width="377" height="36" src="<%= ResolveClientUrl("~/Content/Img/GHTN.jpg") %>" alt="" /></a>
                            </div>
                        </td>     
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>