<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<table width="1000" align="center" border="0" cellspacing="0" cellpadding="0">
	<tr>
    	<td height="134">
        	<a href="javascript:void(0)"><img width="410" height="134" border="0" src="<%= ResolveClientUrl("~/Content/Img/Logo.png") %>" alt="" /></a>	
        </td>
        <td valign="top">
        	<div align="center" >
                <font color="FF0000">
                    <a class="memutop_over" href="<%= ResolveClientUrl("~/SanPham/TatCaSanPham") %>">Trang chủ</a>
                    <span class="memutop">|</span>
                    <a class="memutop_over" href="javascript:void(0)">Giới thiệu</a>
                    <span class="memutop">|</span>
                    <a class="memutop_over" href="javascript:void(0)">Qui định bảo hành</a>
                    <span class="memutop">|</span>
                    <a class="memutop_over" href="javascript:void(0)">Liên hệ</a>
                </font>
            </div>
            <div align="right">
            	<a href="javascript:void(0)"><img width="510" vspace="" hspace="" height="70" border="0" src="<%= ResolveClientUrl("~/Content/Img/Logo top.gif") %>" alt="" /></a>
            </div>	
        </td>
    </tr>
</table>