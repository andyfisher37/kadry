<%@ Page language="c#" Codebehind="PhotoList.aspx.cs" AutoEventWireup="True" Inherits="UK.PhotoList" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - просмотр фотографий сотрудников 
			по списку...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="0">
				<TR>
					<TD align="center" colSpan="3"><IMG alt="" src="/images/pl-header.gif"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" colSpan="3">
						<asp:Table id="Table" runat="server" CssClass="maintext" Width="748px" GridLines="Both" HorizontalAlign="Center"
							BorderColor="Gray" BorderStyle="Solid" CellPadding="0" CellSpacing="0" BorderWidth="1px">
							<asp:TableRow VerticalAlign="Top" HorizontalAlign="Center">
								<asp:TableCell Text="Фото"></asp:TableCell>
								<asp:TableCell Text="Фамилия"></asp:TableCell>
								<asp:TableCell Text="Имя"></asp:TableCell>
								<asp:TableCell Text="Отчество"></asp:TableCell>
							</asp:TableRow>
						</asp:Table>
					</TD>
				</TR>
				<TR>
					<MAP NAME="btm_line_Map"></MAP>
					<TD align="center" colSpan="3">
						<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="\images\btm_line.gif" onclick="ImageButton1_Click"></asp:ImageButton></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
