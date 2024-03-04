<%@ Page language="c#" Codebehind="net_stat.aspx.cs" AutoEventWireup="True" Inherits="UK.net_stat" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - сетевая статистика...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="Styles.css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<font class="Header">
				<center>Краткая статистика сетевой активности пользователей ИАС УРЛС УВД</center>
			</font>
			<hr>
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="320" border="0">
				<TR class="maintext">
					<TD style="WIDTH: 228px" align="right"><STRONG><FONT color="#3300cc">Общее количество 
								запросов:</FONT></STRONG></TD>
					<TD style="WIDTH: 70px" align="center"><asp:label class="maintext" id="total_query" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD class="maintext" style="WIDTH: 228px" align="right">&nbsp;&nbsp;&nbsp;<EM>&nbsp;<FONT color="#990000">- 
								в.т.ч. в текущем месяце:</FONT></EM></TD>
					<TD style="WIDTH: 70px" align="center"><asp:label class="maintext" id="month_query" runat="server" Width="64px"></asp:label></TD>
				</TR>
				<TR>
					<TD class="maintext" style="WIDTH: 228px" align="right">&nbsp;&nbsp;&nbsp;<EM>&nbsp;<FONT color="#990000">- 
								в.т.ч. сегодня:</FONT></EM></TD>
					<TD class="maintext" style="WIDTH: 70px" align="center">
						<asp:label class="maintext" id="today_query" runat="server" Width="64px"></asp:label></TD>
				</TR>
			</TABLE>
			<br>
			<asp:Table id="Table" runat="server" CssClass="maintext" ForeColor="#0000C0" GridLines="Horizontal"
				BorderWidth="0px" CellPadding="1" CellSpacing="1" BorderColor="#404040"></asp:Table>
			<br>
			<hr>
			<font class="label"><a href="index.aspx">[Вернуться на главную страницу]</a></font>
		</form>
	</body>
</HTML>
