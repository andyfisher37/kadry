<%@ Page language="c#" Codebehind="nek_sluz.aspx.cs" AutoEventWireup="True" Inherits="kadry.Nekompl.nek_sluz" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Укомплектованность служб УВД 
			Ивановской области</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table2" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 1000px; POSITION: absolute; TOP: 8px; HEIGHT: 200px"
					cellSpacing="1" cellPadding="1" width="1000" border="0">
					<TR>
						<TD style="HEIGHT: 8px" vAlign="top" align="center" colSpan="4">
							<asp:Label id="TitleText" runat="server" CssClass="Header"></asp:Label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 91px" align="center" colSpan="4">
							<P>
								<HR>
								(страница находится в разработке...)&nbsp;</P>
							<P>
								<TABLE class="smalltext" id="Table4" style="WIDTH: 971px; HEIGHT: 50px" cellSpacing="0"
									cellPadding="0" width="971" border="0">
									<TR>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>
											<asp:Table id="Table" runat="server" BorderWidth="1px" GridLines="Both" CellPadding="0" CellSpacing="0"
												BorderColor="Black" Font-Size="XX-Small" ToolTip="Нажми на наименование подразделения и узнай подробнее о вакансиях"></asp:Table></TD>
										<TD>
											<asp:Table id="Table1" runat="server" BorderWidth="1px" GridLines="Both" CellPadding="0" CellSpacing="0"
												BorderColor="Black" Font-Size="XX-Small"></asp:Table></TD>
									</TR>
								</TABLE>
							</P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 10px" colSpan="4" class="smalltext" align="center">
							<TABLE id="Table3" class="label" style="WIDTH: 316px; HEIGHT: 64px" cellSpacing="0" cellPadding="0"
								width="316" border="0" bgColor="cornsilk">
								<TR>
									<TD align="center" colSpan="2">Дополнительные параметры:</TD>
								</TR>
								<TR>
									<TD align="left">
										<asp:CheckBox id="CheckOVO" runat="server" Text="С разбивкой на н/с и р/с" Width="152px"></asp:CheckBox></TD>
									<TD align="left">
										<asp:CheckBox id="CheckVN" runat="server" Text="Включить в расчет  в/н состав" Width="160px"></asp:CheckBox></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<asp:ImageButton id="BtnRefresh" runat="server" ImageUrl="../images/btn_update.gif"></asp:ImageButton></TD>
								</TR>
							</TABLE>
							<hr>
							&nbsp;</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="4">
							<asp:Label id="Label2" runat="server" CssClass="smalltext" Width="392px" class="smalltext">Отделение прохождения службы и информационного обеспечения УРЛС УВД, тел.: 48-18-42</asp:Label></TD>
					</TR>
				</TABLE>
				<br>
				<br>
			</center>
		</form>
	</body>
</HTML>
