<%@ Page language="c#" Codebehind="Quality.aspx.cs" AutoEventWireup="false" Inherits="kadry.Quality.Quality" codePage="65001"%>
<%@ Import Namespace="obout_ASPTreeView_2_NET" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Статистика, качественные характеристики...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#cc0000" aLink="#6666ff" link="#ff9966" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" align="left" border="0"
				style="WIDTH: 700px; HEIGHT: 200px">
				<TR>
					<TD style="HEIGHT: 102px" vAlign="top" align="center" height="102">
						<IMG SRC="/images/header_small.gif" ALT="Информационная система обработки данных "Кадры"" USEMAP="#Map2"
							BORDER="0"><MAP NAME="Map2"><AREA SHAPE="RECT" COORDS="244,51,499,82" HREF="../About/about.aspx" ALT="УРЛС УВД..." TITLE="УРЛС УВД..."></MAP>
					</TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 1px" align="center" height="1">СТАТИСТИКА, Качественные 
						ПОКАЗАТЕЛИ</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 100px" vAlign="top" align="center">
						<br>
                        <ASP:Literal id="Tree1" EnableViewState="false" runat="server" />
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 10px" vAlign="top" align="center">
						&nbsp;</TD>
				</TR>
				<TR VALIGN="middle" ALIGN="left">
					<TD vAlign="top" noWrap align="center" height="27"><IMG height="33" alt="Панель быстрых переходов..." src="../images/bottom.gif" 
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
