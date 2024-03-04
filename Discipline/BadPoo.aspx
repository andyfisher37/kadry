<%@ Page language="c#" Codebehind="BadPoo.aspx.cs" AutoEventWireup="True" Inherits="kadry.Discipline.BadPoo" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BadPoo</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="712" align="left" border="0" HSPACE="0" VSPACE="0">
				<TR>
					<TD style="WIDTH: 848px; HEIGHT: 58px" vAlign="top" align="center" colSpan="19"><IMG alt="" src="/images/header_small.gif" width="750" useMap="#Map2" border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP></TD>
				</TR>
				<TR vAlign="top">
					<TD vAlign="top" align="center" colSpan="1" height="16" rowSpan="1"><SPAN class="Header">список 
							поощренных сотрудников, имеющих <U>неснятые</U> дисциплинарные взыскания...</SPAN></TD>
				</TR>
				<TR vAlign="top">
					<TD style="HEIGHT: 421px" vAlign="top" noWrap align="center" colSpan="1" height="421"
						rowSpan="1">
						<asp:Label class="label2" id="Info" runat="server"></asp:Label>
						<asp:Table id="Table" runat="server" Width="745px" Font-Names="Verdana" Font-Size="XX-Small"
							BorderColor="Black" BorderWidth="1px" CellPadding="0" CellSpacing="0" GridLines="Both">
							<asp:TableRow HorizontalAlign="Center">
								<asp:TableCell Text="Фамилия"></asp:TableCell>
								<asp:TableCell Text="Имя"></asp:TableCell>
								<asp:TableCell Text="Отчество"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Left" Text="Подразделение"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Left" Text="Должность"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Left" Text="Неснятые взыскания"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Left" Text="Поощрения"></asp:TableCell>
							</asp:TableRow>
						</asp:Table>
					</TD>
				</TR>
				<TR vAlign="middle" align="left">
					<TD vAlign="top" noWrap align="center" colSpan="2" height="27"><IMG height="33" alt="Панель быстрых переходов..." src="../images/bottom.gif" 
								useMap="#Map" border="0"><MAP name="Map">
                                 <AREA title="На главную..." shape="RECT" alt="На главную..." coords="25,0,100,33" href="../index.aspx">
                                 <AREA title="Поиск сотрудников" shape="RECT" alt="Поиск сотрудников" coords="150,0,200,33"	href="../Search/search.aspx">
                                 <AREA title="Штатно-должностная книга" shape="RECT" alt="Штатно-должностная книга" coords="250,0,325,33"	href="../Structure/orgstr.aspx">
                                 <AREA title="Вакансии" shape="RECT" alt="Вакансии" coords="325,0,425,33" href="../Vakans/vakansy.aspx">
                                 <AREA title="Некомплект" shape="RECT" alt="Некомплект" coords="475,0,550,33" href="../Nekompl/nekompl.aspx">
                                 <AREA title="Качественные показатели" shape="RECT" alt="Качественные показатели" coords="575,0,650,33"	href="../Kachestv/kachestv.aspx">
                                 <AREA title="Дисциплинарная практика" shape="RECT" alt="Дисциплинарная практика" coords="700,0,775,33"	href="../Discipline/discipline.aspx">
                                 </MAP></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
