<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BLLandDAL.Khachhang>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Đăng Ký Thành Viên
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    function Check() {
        var a = CheckInput();
        var b = Checkusername();
        var c = Checkngay();
        if (a && b && c) {
            return true;
        }
        return false;
    }
    function CheckInput() {
        var result = 1;
        if ($("#UsernameDK").val() == "") {
            result = 0;
            document.getElementById('ErrorUsername').innerHTML = "Chưa Điền Tên Đăng Nhập";
        }
        else
            document.getElementById('ErrorUsername').innerHTML = "";

        if ($("#PasswordDK").val() == "") {
            result = 0;
            document.getElementById('ErrorPassword').innerHTML = "Chưa Điền Mật Khẩu";
        }
        else
            document.getElementById('ErrorPassword').innerHTML = "";

        if ($("#NhapLaiPassword").val() == "") {
            result = 0;
            document.getElementById('ErrorNhapLaiPassword').innerHTML = "Nhập Lại Mật Khẩu";
        }
        else {
            if ($("#NhapLaiPassword").val() != $("#PasswordDK").val()) {
                result = 0;
                document.getElementById('ErrorNhapLaiPassword').innerHTML = "Nhập Lại Mật Khẩu Sai";
            }
            else
                document.getElementById('ErrorNhapLaiPassword').innerHTML = "";
        }

        if ($("#TenKH").val() == "") {
            result = 0;
            document.getElementById('ErrorTenKH').innerHTML = "Chưa Điền Tên";
        }
        else
            document.getElementById('ErrorTenKH').innerHTML = "";

        if ($("#DiaChi").val() == "") {
            result = 0;
            document.getElementById('ErrorDiaChi').innerHTML = "Chưa Điền Địa Chỉ";
        }
        else
            document.getElementById('ErrorDiaChi').innerHTML = "";

        if ($("#Email").val() == "") {
            result = 0;
            document.getElementById('ErrorEmail').innerHTML = "Chưa Điền Email";
        }
        else {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (!re.test($("#Email").val())) {
                result = 0;
                document.getElementById('ErrorEmail').innerHTML = "Email Không Hợp Lệ";
            }
            else
                document.getElementById('ErrorEmail').innerHTML = "";
        }

        if ($("#SDT").val() == "") {
            result = 0;
            document.getElementById('ErrorSDT').innerHTML = "Chưa Điền SĐT";
        }
        else {
            var re = /^[0-9]+$/;
            if (!re.test($("#SDT").val())) {
                result = 0;
                document.getElementById('ErrorSDT').innerHTML = "SĐT Là Số";
            }
            else
                document.getElementById('ErrorSDT').innerHTML = "";
        }

        if ($("#CMND").val() == "") {
            result = 0;
            document.getElementById('ErrorCMND').innerHTML = "Chưa Điền CMND";
        }
        else {
            var re = /^[0-9]+$/;
            if (!re.test($("#CMND").val())) {
                result = 0;
                document.getElementById('ErrorCMND').innerHTML = "CMND Là Số";
            }
            else
                document.getElementById('ErrorCMND').innerHTML = "";
        }
        if (result == 1)
            return true;
        return false;
    }
    function Checkusername() {
        var url = '/KhachHang/DangNhap';
        var input = $("#UsernameDK").val();
        if (input != "") {
            var result;
            $.ajax({
                type: 'POST',
                url: url,
                data: { Username: input },
                dataType: 'html',
                async: false,
                success: function (data) { result = data; }
            });
            switch (result) {
                case '2':
                    document.getElementById('ErrorUsername').innerHTML = 'Tên Đăng Nhập Đã Tồn Tại';
                    return false;
                case '3':
                    document.getElementById('ErrorUsername').innerHTML = '';
                    return true;
            }
        }
        else {
            return false;
        }
    }
    function Checkngay() {
        var text = /^[0-9]+$/;
        var month = $("#Thang").val();
        var day = $("#Ngay").val();
        var year = $("#Nam").val();
        if (month == '0') {
            s = 'Chưa Chọn Tháng';
            document.getElementById('ERRORNgaysinh').innerHTML = s;
            return false;
        }
        if (day == '0') {
            s = 'Chưa Chọn Ngày';
            document.getElementById('ERRORNgaysinh').innerHTML = s;
            return false;
        }
        if (year == '' || year == 'Năm') {
            s = 'Chưa Điền Năm Sinh';
            document.getElementById('ERRORNgaysinh').innerHTML = s;
            return false;
        }
        if (!text.test(year)) {
            s = 'Năm Là Số';
            document.getElementById('ERRORNgaysinh').innerHTML = s;
            return false;
        }
        if (year.length != 4) {
            s = 'Năm Không Hợp Lệ';
            document.getElementById('ERRORNgaysinh').innerHTML = s;
            return false;
        }
        var current_year = new Date().getFullYear();
        if ((year < 1920) || (year > current_year)) {
            s = 'Năm Sinh Từ 1920 - ' + current_year;
            document.getElementById('ERRORNgaysinh').innerHTML = s;
            return false;
        }
        document.getElementById('ERRORNgaysinh').innerHTML = '';
        return true;
    }
</script>
    <% using (Html.BeginForm("DangKy", "KhachHang", FormMethod.Post, new { name = "FormDK", id = "FormDK", onsubmit = "return Check();" }))
       { %>
       <table width="710" border="0" align="center" class="boxct">
            <tr>
                <td align="center" height="25" colspan="4" class="title">Đăng Ký</td>
            </tr>
            <tr>
                <td width="10%"></td>
                <td width="25%" class="chusanpham" align="left">Tên Đăng Nhập</td>
                <td width="35%"><%: Html.TextBoxFor(m => m.Username, htmlAttributes: new { maxlength = 15, id = "UsernameDK" }) %></td>
                <td width="30%"><span class="Errormessage" id="ErrorUsername"></span></td>
            </tr>
            <tr>
                <td></td>
                <td class="chusanpham" align="left">Mật Khẩu</td>
                <td><%: Html.PasswordFor(m => m.Password, htmlAttributes: new { maxlength = 15, id = "PasswordDK" }) %></td>
                <td><span class="Errormessage" id="ErrorPassword"></span></td>
            </tr>
            <tr>
                <td></td>
                <td class="chusanpham" align="left">Nhập Lại Mật Khẩu</td>
                <td><input type="password" id="NhapLaiPassword" /></td>
                <td><span class="Errormessage" id="ErrorNhapLaiPassword"></span></td>
            </tr>
            <tr>
                <td></td>
                <td class="chusanpham" align="left">Họ Tên</td>
                <td><%: Html.TextBoxFor(m => m.Tenkh, htmlAttributes: new { id = "TenKH" })%></td>
                <td><span class="Errormessage" id="ErrorTenKH"></span></td>
            </tr>
            <tr>
                <td></td>
                <td class="chusanpham" align="left">Giới Tính</td>
                <td class="chusanpham"><input type="checkbox" name="Gioitinh" value="Nam" />Nam</td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td class="chusanpham" align="left">Địa Chỉ</td>
                <td><%: Html.TextBoxFor(m => m.Diachi, htmlAttributes: new { id = "DiaChi" })%></td>
                <td><span class="Errormessage" id="ErrorDiaChi"></span></td>
            </tr>
            <tr>
                <td></td>
                <td class="chusanpham" align="left">Email</td>
                <td><%: Html.TextBoxFor(m => m.Email, htmlAttributes: new { id = "Email" })%></td>
                <td><span class="Errormessage" id="ErrorEmail"></span></td>
            </tr>
            <tr>
                <td></td>
                <td class="chusanpham" align="left">SĐT</td>
                <td><%: Html.TextBoxFor(m => m.SDT, htmlAttributes: new { id = "SDT" })%></td>
                <td><span class="Errormessage" id="ErrorSDT"></span></td>
            </tr>
<script type="text/javascript">
    function Datechange() {
        var Num = 31;
        var Thang = document.getElementById('Thang');
        switch (Thang.options[Thang.selectedIndex].value) {
            case '1':
            case '3':
            case '5':
            case '7':
            case '8':
            case '10':
            case '12':
                Num = 31;
                break;
            case '4':
            case '6':
            case '9':
            case '11':
                Num = 30;
                break;
            case '2':
                Num = 28;
                break;
        }
        var Ngay = document.getElementById('Ngay');
        Ngay.options.length = 0;
        Ngay.options[Ngay.options.length] = new Option('Ngày', 0);
        for (var i = 1; i <= Num; i++) {
            Ngay.options[Ngay.options.length] = new Option(i, i);
        }
        Ngay.selectedIndex = 0;
    }
</script>
            <tr>
                <td></td>
                <td class="chusanpham" align="left">Ngày Sinh:</td>
                <td>
                    <select name="Thang" id="Thang" onchange="Datechange();">
                        <option value="0">Tháng</option>
						<option value="1">Tháng 1</option>
						<option value="2">Tháng 2</option>
						<option value="3">Tháng 3</option>
						<option value="4">Tháng 4</option>
						<option value="5">Tháng 5</option>
						<option value="6">Tháng 6</option>
						<option value="7">Tháng 7</option>
						<option value="8">Tháng 8</option>
						<option value="9">Tháng 9</option>
						<option value="10">Tháng 10</option>
						<option value="11">Tháng 11</option>
						<option value="12">Tháng 12</option>
                    </select>
                    <select name="Ngay" id="Ngay">
                        <option value="0">Ngày</option>
						<option value="1">1</option>
						<option value="2">2</option>
						<option value="3">3</option>
						<option value="4">4</option>
						<option value="5">5</option>
						<option value="6">6</option>
						<option value="7">7</option>
						<option value="8">8</option>
						<option value="9">9</option>
						<option value="10">10</option>
						<option value="11">11</option>
						<option value="12">12</option>
						<option value="13">13</option>
						<option value="14">14</option>
						<option value="15">15</option>
						<option value="16">16</option>
						<option value="17">17</option>
						<option value="18">18</option>
						<option value="19">19</option>
						<option value="20">20</option>
						<option value="21">2 1</option>
						<option value="22">22</option>
						<option value="23">23</option>
						<option value="24">24</option>
						<option value="25">25</option>
						<option value="26">26</option>
						<option value="27">27</option>
						<option value="28">28</option>
						<option value="29">29</option>
						<option value="30">30</option>
						<option value="31">31</option>
                    </select>
                    <input type="text" name="Nam" onblur="if(this.value=='')this.value='Năm'; Checkngay();" onfocus="if(this.value=='Năm')this.value='';" value="Năm" size="4" maxlength="4" id="Nam"/>
                </td>
                <td><span class="Errormessage" id="ERRORNgaysinh"></span></td>
            </tr>
            <tr>
                <td></td>
                <td class="chusanpham" align="left">CMND</td>
                <td><%: Html.TextBoxFor(m => m.CMND, htmlAttributes: new { id = "CMND" })%></td>
                <td><span class="Errormessage" id="ErrorCMND"></span></td>
            </tr>
            <tr>
                <td></td><td></td>
                <td><input type="submit" value="Đăng Ký" /></td><td></td>
            </tr>
        </table>
    <% } %>
</asp:Content>
