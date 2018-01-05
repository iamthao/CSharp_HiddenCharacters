<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% if (Session["TenKhachHang"] != null)
   { %>
<table border="0">
    <tr>
        <td><img src="<%= ResolveClientUrl("~/Content/Img/TVDN.png") %>" width="140" height="100%" alt="Banner Đăng Nhập" /></td>
    </tr>
    <tr>
        <td width="100%" align="left">
            <div align="left" class="chusanpham"><%= Session["TenKhachHang"].ToString()%> Đã Đăng Nhập</div>
            <div align="left" class="chusanpham"><%: Html.ActionLink("Đăng Xuất", "DangXuat", "KhachHang", null, new { @class = "number" } ) %></div>
        </td>
    </tr>
</table>
<% } else { %>
<script type="text/javascript" language="javascript">
    function loginGo() {
        if ($("#Username").val() == 'Tên Đăng Nhập' || $("#Username").val() == '') {
            alert('Chưa Điền Tên Đăng Nhập');
            return false;
        }
        if ($("#Password").val() == 'Mật Khẩu' || $("#Password").val() == '') {
            alert('Chưa Điền Mật Khẩu');
            return false;
        }
        var f = document.FormDN;
        $.post(f.action, $(f).serialize(), function (data) {
            switch (data) {
                case '0':
                case '1':
                    var url = '/SanPham/TatCaSanPham';
                    document.location = url;
                    break;
                case '2':
                    alert('Sai Mật Khẩu');
                    break;
                case '3':
                    alert('Không Có Tên Đăng Nhập Này');
                    break;
            }
        });
    }
</script>
<% using (Html.BeginForm("DangNhap", "KhachHang", FormMethod.Post, new { name = "FormDN", id = "FormDN" }))
   { %>
    <table border="0">
        <tr>
            <td><img src="<%= ResolveClientUrl("~/Content/Img/TVDN.png") %>" width="140" height="100%" alt="Banner Đăng Nhập" /></td>
        </tr>
        <tr>
            <td width="100%" align="left"><input maxlength="20" size="17" type="text" onblur="if(this.value=='')this.value='Tên Đăng Nhập';" onfocus="if(this.value=='Tên Đăng Nhập')this.value='';" value="Tên Đăng Nhập" id="Username" name="Username" /></td>
        </tr>
        <tr>
            <td width="100%" align="left"><input maxlength="20" size="17" type="password" onblur="if(this.value=='')this.value='Mật Khẩu';" onfocus="if(this.value=='Mật Khẩu')this.value='';" value="Mật Khẩu" id="Password" name="Password" /></td>
        </tr>
        <tr>		
			<td align="center">
                <input class="DN" type="submit" value="" onclick="loginGo(); return false;" />
            </td>
        </tr>
        <tr>
            <td>
                <div><a class="munulink" href="javascript:void(0)">Quên Mật Khẩu</a></div>
                <div><a class="munulink" href="<%= ResolveClientUrl("~/KhachHang/DangKy") %>">Đăng Ký</a></div>
            </td>
        </tr>
    </table>  
<% } %>
<% } %>