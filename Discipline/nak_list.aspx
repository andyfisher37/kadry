<%@ Page language="c#" Codebehind="nak_list.aspx.cs" AutoEventWireup="True" Inherits="kadry.Discipline.nak_list" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>nak_list</title>
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
			<TABLE cellSpacing="0" cellPadding="0" width="712" align="left" border="0" HSPACE="0" VSPACE="0">
				<TR>
					<TD style="WIDTH: 848px; HEIGHT: 58px" vAlign="top" align="center" colSpan="19"><IMG alt="" src="/images/header_small.gif" width="750" useMap="#Map2" border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP></TD>
				</TR>
				<TR vAlign="top">
					<TD vAlign="top" align="center" colSpan="1" height="16" rowSpan="1"><SPAN class="Header">СПИСОЧНАЯ 
							ПРОВЕРКА НА ВЗЫСКАНИЯ</SPAN></TD>
				</TR>
				<TR vAlign="top">
					<TD style="HEIGHT: 421px" vAlign="top" noWrap align="center" colSpan="1" height="421"
						rowSpan="1">
						<P class="maintext"><br>
							<TABLE id="Table2" style="WIDTH: 731px; HEIGHT: 96px" cellSpacing="0" cellPadding="0" width="731"
								border="0">
								<TR>
									<TD class="label2" style="HEIGHT: 13px" align="center">
										<P><FONT class="Attantion" color="#ff0000">ВНИМАНИЕ:</FONT></P>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 64px">
										<P class="label2">&nbsp;&nbsp;&nbsp;&nbsp; В данной задаче Вы можете проверить на 
											наличие взысканий сразу несколько сотрудников. Количество сотрудников в списке 
											не ограничено! Протокол проверки списка - формируется автоматически и 
											направляется в отделение прохождения службы и информационного обеспечения 
											управления кадров УВД (каб.№427). При наличии данного протокола Вы можете 
											значительно ускорить процесс визирования "листа согласования" для проекта 
											приказа...</P>
									</TD>
								</TR>
								<TR>
									<TD>
										<hr>
									</TD>
								</TR>
								<TR>
									<TD class="UserInfo">Правила набора списка:</TD>
								</TR>
								<TR>
									<TD class="smalltext">
										<P>Набирается:&nbsp;Фамилия Имя Отчество полностью в именительном падеже, через 
											пробел. Никаких инициалов. Никаких запятых и точек - только ФИО. Один сотрудник 
											на строку. <FONT color="#ff9900"><STRONG>ПРИМЕР:</STRONG></FONT></P>
									</TD>
								</TR>
								<TR>
									<TD class="smalltext"><FONT color="#009900"><STRONG><EM>Иванов Иван Иванович</EM></STRONG></FONT></TD>
								</TR>
								<TR>
									<TD class="smalltext"><FONT color="#009900"><STRONG><EM>Петров Степан Сергеевич</EM></STRONG></FONT></TD>
								</TR>
								<TR>
									<TD class="smalltext"><FONT color="#009900"><STRONG><EM>Сидоров Дмитрий Иванович</EM></STRONG></FONT></TD>
								</TR>
							</TABLE>
						</P>
						<TABLE id="Table1" style="WIDTH: 706px; HEIGHT: 350px" cellSpacing="0" cellPadding="0"
							width="706" bgColor="#D1D1D1" border="0">
							<TR>
								<TD class="maintext" align="center"><STRONG><FONT color="#0000ff">список проверяемых 
											сотрудников:</FONT></STRONG></TD>
								<TD class="maintext" align="center"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 374px; HEIGHT: 279px" align="center"><TEXTAREA id="TEXTAREA" style="WIDTH: 489px; HEIGHT: 283px" name="List" rows="17" cols="58"
										runat="server">
									</TEXTAREA></TD>
								<TD style="WIDTH: 374px; HEIGHT: 279px" align="center">
									<P class="maintext"><asp:label id="Label1" runat="server">Автор проверки:</asp:label><asp:textbox id="UserName" runat="server" Width="201px" ForeColor="DarkGreen" Font-Italic="True"></asp:textbox></P>
									<P><asp:imagebutton id="ClearList" runat="server" ToolTip="Очистить список" ImageUrl="/images/btn_clear.gif" onclick="ClearList_Click"></asp:imagebutton></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 374px; HEIGHT: 14px" vAlign="top" align="center">
								</TD>
								<TD style="WIDTH: 374px; HEIGHT: 14px" vAlign="top" align="center"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 374px; HEIGHT: 11px" vAlign="top" align="center"><asp:imagebutton id="ImageButton2" runat="server" ToolTip="Проверка текущего списка на взыскания"
										ImageUrl="/images/btn_go_sp.gif" onclick="ImageButton2_Click"></asp:imagebutton></TD>
								<TD style="WIDTH: 374px; HEIGHT: 11px" vAlign="top" align="center"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 374px" align="center">&nbsp;</TD>
								<TD style="WIDTH: 374px" align="center"></TD>
							</TR>
						</TABLE>
						<br>
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
