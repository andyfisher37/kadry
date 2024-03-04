<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="moving_view.aspx.cs" Inherits="kadry.Control.moving_view" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Информационная система обработки данных "Кадры" - движение л/с...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
<body text="#000000" bottomMargin="0" vLink="#990000" aLink="#6666ff" link="#0000ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
    <form id="form1" runat="server">
    			<TABLE style="WIDTH: 759px; HEIGHT: 74px" height="74" cellSpacing="0" cellPadding="0" width="759"
				align="left" border="0">
				<TR>
					<TD style="HEIGHT: 5px" vAlign="top" align="center" height="5"><asp:label class="label2" id="TitleText" runat="server" Width="607px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 5px" vAlign="top" align="center" height="5"><asp:table id="Table1" runat="server" Width="752px" BorderColor="#404040" Font-Size="XX-Small"
							GridLines="Both" CellPadding="1" CellSpacing="0" BackColor="Azure" Font-Names="Verdana" BorderWidth="1px">
							<asp:TableRow BackColor="PowderBlue" Font-Size="XX-Small" Font-Names="Verdana">
								<asp:TableCell HorizontalAlign="Center" Text="Фамилия"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Имя"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Отчество"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Звание"></asp:TableCell>
								<asp:TableCell runat="server" HorizontalAlign="Center">Предыдущая должность...</asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" 
                                    Text="Должность в настоящее время"></asp:TableCell>
								<asp:TableCell runat="server" HorizontalAlign="Center">Дата назначения</asp:TableCell>
							    <asp:TableCell runat="server" HorizontalAlign="Center">Нал.закл.<br>психолога.</asp:TableCell>
							</asp:TableRow>
						</asp:table>
						<asp:table id="Table2" runat="server" Width="752px" BorderColor="#404040" Font-Size="XX-Small"
							GridLines="Both" CellPadding="1" CellSpacing="0" BackColor="Azure" Font-Names="Verdana" 
                            BorderWidth="1px">
							<asp:TableRow BackColor="PowderBlue" Font-Size="XX-Small" Font-Names="Verdana">
								<asp:TableCell HorizontalAlign="Center" Text="Фамилия"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Имя"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Отчество"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Звание"></asp:TableCell>
								<asp:TableCell runat="server" HorizontalAlign="Center">Предыдущая должность<br>(и служба)...</asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" 
                                    Text="Должность в настоящее время &lt;br&gt;(и служба)"></asp:TableCell>
								<asp:TableCell runat="server" HorizontalAlign="Center">Дата назначения</asp:TableCell>
							    <asp:TableCell runat="server" HorizontalAlign="Center">Нал.закл.<br>психолога.</asp:TableCell>
							</asp:TableRow>
						</asp:table>
						<asp:Label class="maintext" id="CountLabel" runat="server"></asp:Label>
						<br>
					</TD>
				</TR>
				<TR vAlign="middle" align="left">
					<TD vAlign="middle" noWrap align="center" height="27">&nbsp; </TD>
				</TR>
			</TABLE>
                <div>
                    <table style="width: 100%;">
                         <tr>
                            <td>
                                &nbsp;
                            </td>
                         </tr>
                   </table>
                </div>
    </form>
</body>
</html>
