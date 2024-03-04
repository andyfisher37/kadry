<%@ Page language="c#" Codebehind="structure.aspx.cs" AutoEventWireup="True" Inherits="UK.Structure.structure" codePage="65001"%>
<%@ Register assembly="Obout.Ajax.UI" namespace="Obout.Ajax.UI.TreeView" tagprefix="obout" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - штатно-должностная струкутра</title>
		<meta content="True" name="vs_showGrid">
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 769px; HEIGHT: 499px" height="499" cellSpacing="0" 
                cellPadding="0" align="left" border="0" HSPACE="0" VSPACE="0">
				<TR>
					<TD style="WIDTH: 750px; HEIGHT: 89px" height="89"><IMG alt="Информационная система обработки данных "Кадры"" src="/images/header_small.gif" useMap="#Map2"
							border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP></TD>
				</TR>
				<TR>
					<TD class="Header" style="WIDTH: 750px; HEIGHT: 10px" align="center" height="10">штатно-должностная 
                        структура</TD>
				</TR>
				<TR>
					<TD class="style1" vAlign="top" 
                        align="center">

					</TD>
				</TR>
				<TR>
					<TD class="main_text" style="WIDTH: 750px; HEIGHT: 364px" vAlign="top" 
                        align="center">

					    <obout:Tree ID="STree" runat="server" ClientIDMode="AutoID" NodeDropTargets="" 
                            Width="100%">
                        </obout:Tree>

					</TD>
				</TR>
				<TR vAlign="middle" align="left">
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
