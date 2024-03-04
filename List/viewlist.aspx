<%@ Page language="c#" Codebehind="viewlist.aspx.cs" AutoEventWireup="True" Inherits="kadry.List.viewlist" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - списки личного состава...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#990000" aLink="#6666ff" link="#0000ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 952px; HEIGHT: 64px" height="64" cellSpacing="0" cellPadding="0" width="952"
				align="left" border="0">
				<TR>
					<TD class="Header" style="HEIGHT: 23px" align="center" height="23"><asp:label class="label2" id="TitleText" runat="server" Width="607px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 36px" vAlign="top" align="center" height="36"><asp:table id="Table" runat="server" Width="950px" BorderColor="#404040" Font-Size="XX-Small"
							GridLines="Both" CellPadding="1" CellSpacing="0" BackColor="Azure" Font-Names="Verdana" BorderWidth="1px">
							<asp:TableRow BackColor="PowderBlue" Font-Size="XX-Small" Font-Names="Verdana">
								<asp:TableCell HorizontalAlign="Center" Text="Подразделение"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Служба"></asp:TableCell>
								<asp:TableCell Width="25%" HorizontalAlign="Center" Text="Должность"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Фамилия"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Имя"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Отчество"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Звание"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата рождения"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Образование"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Профиль"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="в ОВД с..."></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="В должности"></asp:TableCell>
							</asp:TableRow>
						</asp:table>
						<asp:Label class="maintext" id="CountLabel" runat="server"></asp:Label>
					</TD>
				</TR>
				<TR vAlign="middle" align="left">
					<TD vAlign="middle" noWrap align="center" colSpan="1" height="27"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
