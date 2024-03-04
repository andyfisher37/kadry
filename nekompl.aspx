<%@ Page language="c#" Codebehind="nekompl.aspx.cs" AutoEventWireup="false" Inherits="UK.nekompl" codePage="1251"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Управление кадров - некомплект личного состава...</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="images/background.gif" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 706px; HEIGHT: 628px" height="628" cellSpacing="0" cellPadding="0"
				width="706" align="center" border="0" VSPACE="0" HSPACE="0">
				<TR>
					<TD height="150"><IMG height="151" alt="" src="images/header2-1.gif" width="750" useMap="#Map2" border="0"><MAP name="Map2"><AREA title="УК УВД..." shape="RECT" alt="УК УВД..." coords="249,74,494,102" href="about.aspx"></MAP></TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 10px" align="center" height="10">СВЕДЕНИЯ о 
						некомплекте личного состава в ОВД&nbsp;ИВАНОВСКОЙ ОБЛАСТИ</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 412px" vAlign="top" align="center"><br>
						<TABLE class="maintext" id="Table1" style="WIDTH: 596px; HEIGHT: 67px" cellSpacing="1"
							cellPadding="1" width="596" bgColor="peachpuff" border="0">
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 27px" align="right" colSpan="1" rowSpan="1">Подразделение:</TD>
								<TD style="WIDTH: 427px; HEIGHT: 27px"><asp:dropdownlist id=podrList runat="server" DataMember="Table" DataValueField="KEY_OF_POD" DataTextField="PODRAZDEL" DataSource="<%# podrDataSet %>" Font-Size="7pt" Font-Names="Verdana" Width="416px" ForeColor="#C00000" CssClass="maintext">
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 27px" align="center"><asp:button id="AddPodrBtn" runat="server" Text=" + "></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 25px" align="right">Служба:</TD>
								<TD style="WIDTH: 427px; HEIGHT: 25px"><asp:dropdownlist id=sluzList runat="server" DataMember="Table" DataValueField="KEY_OF_SLU" DataTextField="NAM_OF_SLU" DataSource="<%# sluzDataSet %>" Font-Size="7pt" Font-Names="Verdana" Width="416px" ForeColor="#C00000" CssClass="maintext">
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 25px" align="center"><asp:button id="AddSluzBtn" runat="server" Text=" + "></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 23px" align="right">Должности:</TD>
								<TD style="WIDTH: 427px; HEIGHT: 23px"><asp:dropdownlist id=dolzList runat="server" DataMember="Table" DataValueField="P3" DataTextField="NAM_OF_DOL" DataSource="<%# dolzDataSet %>" Font-Size="7pt" Font-Names="Verdana" Width="416px" ForeColor="#C00000" CssClass="maintext">
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 23px" align="center"><asp:button id="AddDolzBtn" runat="server" Text=" + "></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px" align="right">Источник финансирования:</TD>
								<TD style="WIDTH: 427px"><asp:dropdownlist id=istList runat="server" DataMember="Table" DataValueField="CODE" DataTextField="TEXT" DataSource="<%# istDataSet %>" Font-Size="7pt" Font-Names="Verdana" Width="416px" ForeColor="#C00000" CssClass="maintext">
									</asp:dropdownlist></TD>
								<TD align="center"><asp:button id="AddIstBtn" runat="server" Text=" + "></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px"></TD>
								<TD style="WIDTH: 427px"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px" align="center"><asp:button id="GoBtn" runat="server" Width="112px" Text="ОК"></asp:button></TD>
								<TD style="WIDTH: 427px"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px"></TD>
								<TD style="WIDTH: 427px"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px" colSpan="3"><asp:label id="InfoLabel" runat="server" Width="576px" CssClass="label"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px" colSpan="3"><asp:label id="ListLabel" runat="server" Width="576px" CssClass="label"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="middle" noWrap colSpan="2" height="27"><IMG height="33" src="images/bottom.gif" width="750" useMap="#Map" border="0"><MAP name="Map"><AREA title="На главную" shape="RECT" alt="На главную" coords="60,5,82,26" href="index.aspx"><AREA title='Поисковая система "КАДРЫ"' shape="RECT" alt='Поисковая система "КАДРЫ"' coords="119,5,141,28"
								href="search.aspx"><AREA title="Структура ОВД области" shape="RECT" alt="Структура ОВД области" coords="148,5,170,26"
								href="structure.aspx"><AREA title="Некомплект" shape="RECT" alt="Некомплект" coords="178,5,200,25" href="nekompl.aspx"><AREA title="Дисциплинарная практика" shape="RECT" alt="Дисциплинарная практика" coords="208,5,230,26"
								href="discipline.aspx"><AREA title="Регистрация..." shape="RECT" alt="Регистрация..." coords="239,5,261,27" href="register.aspx"><AREA title="Сделано в УК УВД Ивановской области" shape="RECT" alt="Сделано в УК УВД Ивановской области"
								coords="346,7,743,25" href="about.aspx"><AREA title="Администратору УК..." shape="RECT" alt="Администратору УК..." coords="89,5,111,27"
								href="toadmin.aspx"></MAP></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
