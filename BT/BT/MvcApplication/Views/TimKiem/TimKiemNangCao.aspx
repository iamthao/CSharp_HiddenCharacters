<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication.Models.TimKiemNangCao>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Tìm Kiếm Nâng Cao
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    function KiemTraFormTKNC() {
        var result = 1;
        if ($("#TextBoxTenSP").val() == '') {
            result = 0;
            document.getElementById('ErrorTenSP').innerHTML = 'Chưa Điền Tên Sản Phẩm';
        }
        else
            document.getElementById('ErrorTenSP').innerHTML = '';
        if ($("#LoaisanphamId").val() == '-1') {
            result = 0;
            document.getElementById('ErrorLoaisanpham').innerHTML = 'Chưa Chọn Loại Sản Phẩm';
        }
        else
            document.getElementById('ErrorLoaisanpham').innerHTML = '';
        if ($("#TextBoxGiaTu").val() == "") {
            result = 0;
            document.getElementById('ErrorGiaTu').innerHTML = "Chưa Điền Giá Từ";
        }
        else {
            var re = /^[0-9]+$/;
            if (!re.test($("#TextBoxGiaTu").val())) {
                result = 0;
                document.getElementById('ErrorGiaTu').innerHTML = "Giá Từ Là Số";
            }
            else
                document.getElementById('ErrorGiaTu').innerHTML = "";
        }
        if ($("#TextBoxGiaDen").val() == "") {
            result = 0;
            document.getElementById('ErrorGiaDen').innerHTML = "Chưa Điền Giá Đến";
        }
        else {
            var re = /^[0-9]+$/;
            if (!re.test($("#TextBoxGiaDen").val())) {
                result = 0;
                document.getElementById('ErrorGiaDen').innerHTML = "Giá Đến Là Số";
            }
            else
                document.getElementById('ErrorGiaDen').innerHTML = "";
        }
        if (result == 1)
            return true;
        return false;
    }
    function LoaiSanPhamChange() {
        if ($("#LoaisanphamId").val() != '-1')
            document.getElementById('ErrorLoaisanpham').innerHTML = '';
        else
            document.getElementById('ErrorLoaisanpham').innerHTML = 'Chưa Chọn Loại Sản Phẩm';
    }
</script>
<% using (Html.BeginForm("KetQua", "TimKiem", FormMethod.Post, new { name = "FormTKNC", id = "FormTKNC", onsubmit = "return KiemTraFormTKNC();" }))
   { %>
<table width="710" class="boxct" align="center">
    <tr>
        <td align="center" height="25" colspan="4" class="title">Tìm Nâng Cao</td>
    </tr>
    <tr>
        <td width="10%"></td>
        <td width="25%" class="chusanpham" align="left">Tên Sản Phẩm</td>
        <td width="35%"><%: Html.TextBoxFor(m => m.TenSP, htmlAttributes: new { Id = "TextBoxTenSP", name = "TextBoxTenSP" }) %></td>
        <td width="30%"><span class="Errormessage" id="ErrorTenSP"></span></td>
    </tr>
    <tr>
        <td></td><td class="chusanpham" align="left">Chọn Loại Sản Phẩm</td>
        <td>
            <select name="LoaisanphamId" id="LoaisanphamId" onchange="LoaiSanPhamChange();">
                <option value="-1">[Chọn Loại Sản Phẩm]</option>
                <% foreach (var nhom in (List<BLLandDAL.Nhomsanpham>)ViewData["Nhomsanpham"])
                   { %>
                    <optgroup label="<%= nhom.Tennhomsp %>">
                    <% foreach (var loai in (List<BLLandDAL.Loaisanpham>)ViewData["Loaisanpham"])
                       { %>
                        <% if (nhom.Id == loai.NhomspId)
                           { %>
                            <option value="<%= loai.Id %>"><%= loai.Tenloaisp %></option>
                        <%} %>
                    <% } %>
                    </optgroup>
                <%} %>
            </select>
        </td>
        <td><span class="Errormessage" id="ErrorLoaisanpham"></span></td>
    </tr>
    <tr>
        <td></td><td class="chusanpham" align="left">Giá Từ</td>
        <td><%: Html.TextBoxFor(m => m.GiaTu, htmlAttributes: new { id = "TextBoxGiaTu", name = "TextBoxGiaTu" }) %></td><td><span class="Errormessage" id="ErrorGiaTu"></span></td>
    </tr>
    <tr>
        <td></td><td class="chusanpham" align="left">Giá Đến</td>
        <td><%: Html.TextBoxFor(m => m.GiaDen, htmlAttributes: new { id = "TextBoxGiaDen", name = "TextBoxGiaDen" }) %></td><td><span class="Errormessage" id="ErrorGiaDen"></span></td>
    </tr>
    <tr>
        <td></td><td></td>
        <td><input name="tncSubmit" type="submit" value="Tìm" /></td><td></td>
    </tr>
</table>
<% } %>
</asp:Content>
