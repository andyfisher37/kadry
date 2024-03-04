<%@ Page language="c#" Codebehind="Vysluga.aspx.cs" AutoEventWireup="false" Inherits="UK.Vysluga" codePage="65001"%>
<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Примерный расчет выслуги лет 
			сотрудника...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="images/background.gif" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 736px; POSITION: absolute; TOP: 0px; HEIGHT: 574px"
				cellSpacing="0" cellPadding="0" width="736" border="0">
				<TR>
					<TD style="HEIGHT: 5px" colSpan="3">
						<P><IMG alt="" src="\images\v_top.gif"></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" vAlign="middle" align="center" colSpan="3"><asp:label id="TitleLabel" runat="server" Width="480px" CssClass="Header"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 525px" vAlign="top" align="center" colSpan="3">
						<P>в разработке...</P>
						<P><FONT face="Verdana" color="#000099" size="2">
								<TABLE id="Table3" style="WIDTH: 382px; HEIGHT: 36px" cellSpacing="1" cellPadding="1"
									border="0">
									<TR>
										<TD><FONT color="#000099" size="2">Дата расчета:</FONT></TD>
										<TD><ew:maskedtextbox id="DateBox" runat="server" Width="87px" Mask="99.99.9999" Font-Names="Verdana"
												Font-Bold="True" ForeColor="Maroon" CssClass="label2"></ew:maskedtextbox></TD>
										<TD><asp:imagebutton id="ImageButton1" runat="server" ImageUrl="/images/btn_update.gif"></asp:imagebutton></TD>
									</TR>
								</TABLE>
							</FONT>
						</P>
						<TABLE class="maintext" id="Table1" style="WIDTH: 592px; HEIGHT: 88px" borderColor="#000000"
							cellSpacing="0" cellPadding="0" width="592" border="1">
							<TR>
								<TD colSpan="4">Выслуга лет на
									<asp:label class="DateText" id="DateLabel" runat="server" Width="80px"></asp:label>&nbsp;в 
									Вооруженных Силах и органах внутренних дел составляет:</TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD align="center"><FONT color="#000099"><STRONG>лет</STRONG></FONT></TD>
								<TD align="center"><FONT color="#000099"><STRONG>месяцев</STRONG></FONT></TD>
								<TD align="center"><STRONG><FONT color="#000099">дней</FONT></STRONG></TD>
							</TR>
							<TR>
								<TD>В календарном исчислении:</TD>
								<TD align="center"><asp:label id="year_total" runat="server" Width="74px"></asp:label></TD>
								<TD align="center"><asp:label id="month_total" runat="server" Width="74px"></asp:label></TD>
								<TD align="center"><asp:label id="day_total" runat="server" Width="74px"></asp:label></TD>
							</TR>
							<TR>
								<TD>&nbsp;&nbsp; <FONT color="#990033">В том числе в ВС:</FONT></TD>
								<TD align="center"><asp:label id="year_army" runat="server" Width="74px"></asp:label></TD>
								<TD align="center"><asp:label id="month_army" runat="server" Width="74px"></asp:label></TD>
								<TD align="center"><asp:label id="day_army" runat="server" Width="74px"></asp:label></TD>
							</TR>
							<TR>
								<TD>&nbsp;&nbsp; <FONT color="#990033">В том числе в ОВД</FONT>:</TD>
								<TD align="center"><asp:label id="year_ovd" runat="server" Width="74px"></asp:label></TD>
								<TD align="center"><asp:label id="month_ovd" runat="server" Width="74px"></asp:label></TD>
								<TD align="center"><asp:label id="day_ovd" runat="server" Width="74px"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3"><IMG height="33" src="images/bottom.gif" width="750" useMap="#Map" border="0"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
