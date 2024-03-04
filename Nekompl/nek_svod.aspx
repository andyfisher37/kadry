<%@ Page language="c#" Codebehind="nek_svod.aspx.cs" AutoEventWireup="True" Inherits="kadry.Nekompl.nek_svod" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Сводная таблица 
			укомплектованности ОВД Ивановской области (по ГРУОВД) </title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table2" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 1000px; POSITION: absolute; TOP: 8px; HEIGHT: 176px"
					cellSpacing="1" cellPadding="1" width="1000" border="0">
					<TR>
						<TD style="HEIGHT: 7px" vAlign="top" align="center" colSpan="4"><asp:label id="TitleText" runat="server" CssClass="Header"></asp:label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 72px" align="center" colSpan="4">
							<HR>
							<TABLE class="smalltext" id="Table4" style="WIDTH: 982px; HEIGHT: 24px" cellSpacing="0"
								cellPadding="0" width="982" border="0">
								<TR>
									<TD class="smalltext" style="HEIGHT: 15px" align="center">ГРУОВД области и аппарат 
										УВД</TD>
									<TD style="HEIGHT: 15px" align="center"></TD>
									<TD style="HEIGHT: 15px" align="center">Подразделения непосредственно подчиненные 
										УВД по Ивановской области</TD>
								</TR>
								<TR>
									<TD vAlign="middle" align="center"><asp:table id="Table" runat="server" ToolTip="Нажми на наименование подразделения и узнай подробнее о вакансиях"
											Font-Size="XX-Small" BorderColor="Black" CellSpacing="0" CellPadding="0" GridLines="Both" BorderWidth="1px"></asp:table></TD>
									<TD align="center">&nbsp;</TD>
									<TD vAlign="middle" align="center"><asp:table id="Table1" runat="server" Font-Size="XX-Small" BorderColor="Black" CellSpacing="0"
											CellPadding="0" GridLines="Both" BorderWidth="1px"></asp:table></TD>
								</TR>
							</TABLE>
							&nbsp;</TD>
					</TR>
					<TR>
						<TD class="smalltext" style="HEIGHT: 10px" align="center" colSpan="4">
							<TABLE class="label" id="Table3" style="WIDTH: 316px; HEIGHT: 16px" cellSpacing="0" cellPadding="0"
								width="316" bgColor="cornsilk" border="0">
								<TR>
									<TD align="center" colSpan="2">Дополнительные параметры:</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 11px" align="left">
										<asp:checkbox id="CheckOVO" runat="server" Text="Без учета ОВО" Width="152px"></asp:checkbox></TD>
									<TD style="HEIGHT: 11px" align="left">
										<asp:checkbox id="CheckVN" runat="server" Text="Включить в расчет  в/н состав" Width="160px"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<asp:imagebutton id="BtnRefresh" runat="server" Width="135px" ImageUrl="../images/btn_update.gif" onclick="BtnRefresh_Click"></asp:imagebutton></TD>
								</TR>
							</TABLE>
							<hr>
							&nbsp;</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="4"><asp:label class="smalltext" id="Label2" runat="server" CssClass="smalltext" Width="392px">Отделение прохождения службы и информационного обеспечения УРЛС УВД, тел.: 48-18-42</asp:label></TD>
					</TR>
				</TABLE>
				<br>
				<br>
			</center>
		</form>
	</body>
</HTML>
