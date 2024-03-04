<%@ Page language="c#" Codebehind="List.aspx.cs" AutoEventWireup="True" Inherits="kadry.List.List" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Списки...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#990000" aLink="#6666ff" link="#0000ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE height="344" cellSpacing="0" cellPadding="0" width="759" align="left" border="0"
				style="WIDTH: 759px; HEIGHT: 344px">
				<TR>
					<TD style="HEIGHT: 102px" vAlign="top" align="center" height="102">
						<IMG SRC="/images/header_small.gif" ALT="Информационная система обработки данных "Кадры"" USEMAP="#Map2"
							BORDER="0"><MAP NAME="Map2"><AREA SHAPE="RECT" COORDS="244,51,499,82" HREF="../About/about.aspx" ALT="УРЛС УВД..." TITLE="УРЛС УВД..."></MAP>
					</TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 23px" align="center" height="23">
						СПИСКИ...</TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 207px" vAlign="top" align="center" height="207">
						<TABLE id="Table1" style="WIDTH: 728px; HEIGHT: 98px" cellSpacing="0" cellPadding="0" width="728"
							bgColor="#D1D1D1" border="0">
							<TR>
								<TD class="maintext" style="WIDTH: 218px; HEIGHT: 4px" align="right" colSpan="2"><FONT color="#000099"></FONT><FONT color="#000099"></FONT></TD>
							</TR>
							<TR>
								<TD class="maintext" align="center" colSpan="2"><FONT color="#000099">Составить список 
										личного состава по следующей категории:</FONT></TD>
							</TR>
							<TR>
								<TD class="maintext" align="center" colSpan="2">
									<asp:DropDownList id=catList runat="server" ForeColor="#400000" DataMember="Table" DataTextField="NAME_FORM" DataValueField="TEXT_QRY" DataSource="<%# catDataSet %>" Width="722px" Font-Names="Verdana" Font-Size="XX-Small">
									</asp:DropDownList></TD>
							</TR>
							<TR>
								<TD class="smalltext" style="HEIGHT: 33px" vAlign="top" align="left" colSpan="2"><FONT color="#ff0000">* 
										Категории соответствуют кадровым группам отчета по форме <STRONG><U>1-К</U></STRONG>
										(Приказ МВД России от16 июля 2002 г.&nbsp;№ 679 )</FONT></TD>
							</TR>
							<TR>
								<TD class="maintext" align="center" colSpan="2">
									<asp:ImageButton id="BtnList" runat="server" ImageUrl="/images/btn_get_spis.gif" onclick="BtnList_Click"></asp:ImageButton></TD>
							</TR>
						</TABLE>
						<br>
						<br>
						<br>
					</TD>
				</TR>
				<TR VALIGN="middle" ALIGN="left">
					<TD COLSPAN="2" HEIGHT="27" VALIGN="middle" NOWRAP align="center">
						&nbsp; <IMG SRC="../images/bottom.gif" WIDTH="750" HEIGHT="33" USEMAP="#Map" BORDER="0"><MAP NAME="Map"><AREA SHAPE="RECT" COORDS="346,7,743,25" HREF="../About/about.aspx" ALT="Сделано в УРЛС УВД по Ивановской области"
								TITLE="Сделано в УРЛС УВД по Ивановской области"><area shape="RECT" coords="18,5,39,27" href="../index.aspx" alt="На главную..." title="На главную..."><area shape="RECT" coords="47,5,68,27" href="../About/about.aspx" alt="Об УРЛС УВД"
								title="Об УРЛС УВД"><area shape="RECT" coords="75,5,97,27" href="../Structure/structure.aspx" alt="Структура органов внутренних дел"
								title="Структура органов внутренних дел"><area shape="RECT" coords="104,5,125,27" href="../Search/search.aspx" alt="Поиск сотрудников"
								title="Поиск сотрудников"><area shape="RECT" coords="132,5,154,27" href="../Vakans/vakansy.aspx" alt="Вакансии"
								title="Вакансии"><area shape="RECT" coords="161,5,183,26" href="../Nekompl/nekompl.aspx" alt="Некомплект"
								title="Некомплект"><area shape="RECT" coords="190,5,212,26" href="kachestv.aspx" alt="Качественные показатели"
								title="Качественные показатели"><area shape="RECT" coords="218,5,240,27" href="../Normatives/normatives.aspx" alt="Нормативные документы"
								title="Нормативные документы"><area shape="RECT" coords="247,5,269,26" href="../Blanks/blanks.aspx" alt="Бланки служебных документов"
								title="Бланки служебных документов"><area shape="RECT" coords="275,5,297,26" href="../Discipline/discipline.aspx" alt="Дисциплинарная практика"
								title="Дисциплинарная практика"><area shape="RECT" coords="305,5,327,27" href="../Toadmin/toadmin.aspx" alt="Письмо администратору..."
								title="Письмо администратору..."></MAP></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
