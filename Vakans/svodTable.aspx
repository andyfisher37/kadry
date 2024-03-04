<%@ Page language="c#" Codebehind="svodTable.aspx.cs" AutoEventWireup="True" Inherits="kadry.Vakans.svodTable" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - сводная таблица вакансий</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="TitleText" runat="server" CssClass="maintext"></asp:Label>
			<br>
			<asp:datagrid id="Grid" runat="server" BorderWidth="1px" BorderColor="Black" CellPadding="2" CssClass="maintext">
				<ItemStyle Font-Size="XX-Small" Font-Names="Tahoma" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Center" ForeColor="#330033"
					VerticalAlign="Middle"></HeaderStyle>
			</asp:datagrid>
			<br>
			<asp:Label id="Label1" runat="server" CssClass="smalltext">Отделение прохождения службы и информационного обеспечения УРЛС УВД (48-18-42)</asp:Label>
		</form>
	</body>
</HTML>
