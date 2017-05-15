<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PagedList.IPagedList<BLLandDAL.Sanpham>>" %>
<%@ Import Namespace="PagedList.Mvc" %>
<% if (ViewData["Kiemtradulieu"].ToString() == "1")
   { %>
   <script type="text/javascript">       ChuyenGia(323123);</script>
    <table width="710" align="center" class="boxct"> 
        <tr>
            <td>
                <table width="100%" align="center" class="boxct1">
                    <tr>
                        <td class="title" align="center"><%= ViewData["Tittle"].ToString() %></td>
                    </tr>
                </table>
            </td>
        </tr>
        <% foreach (var sp in Model)
           { %>
        <tr>
            <td>
                <table width="100%" align="center" class="boxct1">
                    <tr>
                        <td width="120" align="center"><a href="<%: Url.Action("ChiTietSanPham", "SanPham") %>/<%= sp.Id %>"><img align="middle" width="120" height="120" src="<%= ResolveClientUrl(sp.Hinh) %>" alt="" /></a></td>
		                <td width="400" align="left">
			                <div><a href="<%: Url.Action("ChiTietSanPham", "SanPham") %>/<%= sp.Id %>" class="menubg"><%= sp.Tensp %></a></div>
			                <div><%= sp.Tinhnangchinh %></div>
			                <div align="left"><a class="menubg" href="<%: Url.Action("ChiTietSanPham", "SanPham") %>/<%= sp.Id %>">Chi Tiết...</a></div>
                        </td>
		                <td>
			                <div class="chusanpham" align="center">Giá:</div>
			                <div class="chusanpham" align="center"><font color="FF0000"><%= sp.HienGia %></font></div>
			                <div class="chusanpham" align="center">VNĐ</div>
		                </td>
	                </tr>
                </table>
            </td>
        </tr>
        <% } %>
        <tr>
            <td align="right"><%= Html.PagedListPager(Model, Page => Url.Action(ViewBag.Action, new { Page, Kt = 1 }))%></td>
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
<% }%>