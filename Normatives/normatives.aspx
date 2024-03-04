<%@ Page language="c#" Codebehind="normatives.aspx.cs" AutoEventWireup="false" Inherits="kadry.Normatives.normatives" %>
<%@ Import Namespace="obout_ASPTreeView_2_NET" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - сборник нормативных документов</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>

	<body text="#000000" bottomMargin="0" vLink="#000000" aLink="#000000" link="#000000" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 736px; HEIGHT: 597px" height="597" cellSpacing="0" cellPadding="0"
				width="736" align="left" border="0">
				<TR>
					<TD style="WIDTH: 739px; HEIGHT: 70px" align="center"><IMG alt="" src="/images/header_small.gif" width="750" useMap="#Map2" border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP></TD>
				</TR>
				<TR>
					<TD class="Header" style="WIDTH: 739px; HEIGHT: 3px" vAlign="top" align="center" height="3">НОРМАТИВНЫЕ 
						ДОКУМЕНТЫ</TD>
				</TR>
				<TR>
					<TD class="maintext" style="WIDTH: 739px; HEIGHT: 437px" vAlign="top" align="left">
                     <br />
&nbsp;&nbsp;
                    <ASP:Literal id="Tree1" EnableViewState="false" runat="server" />
					<br/>
					<center>
					<p class="Admin_text">
					* Внимание! Большая часть документов сохранена в формате (PDF)<br/>
					Для корректной работы ваш браузер должен поддерживать просмотр PDF файлов.
					</p>
					</center>
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
