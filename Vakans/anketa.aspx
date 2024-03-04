<%@ Page language="c#" Codebehind="anketa.aspx.cs" AutoEventWireup="True" Inherits="kadry.Vakans.anketa" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - параметры для подбора 
			вакансии...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout"
		MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 676px; HEIGHT: 604px" height="604" cellSpacing="0" cellPadding="0"
				width="676" align="left" border="0" HSPACE="0" VSPACE="0">
				<TR>
					<TD style="HEIGHT: 90px" align="center" height="90" vAlign="top"><IMG alt="" src="/images/header_small.gif" width="750" useMap="#Map2" border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP></TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 28px" align="center" height="28" vAlign="top">ПАРАМЕТРЫ 
						ДЛЯ ПОДБОРА ВАКАНСИИ...</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" style="HEIGHT: 330px">
						<P>
							<TABLE class="maintext" id="Table1" style="WIDTH: 584px; HEIGHT: 265px" cellSpacing="1"
								cellPadding="1" width="584" bgColor="#D1D1D1" border="0">
								<TR>
									<TD class="maintext" style="WIDTH: 247px; HEIGHT: 17px" align="right"><FONT color="#000000">Образование:</FONT></TD>
									<TD style="HEIGHT: 17px">
										<asp:DropDownList id="TypeObrazList" runat="server" Width="240px" Font-Bold="True" ForeColor="Maroon"
											Font-Names="Tahoma" Font-Size="9pt">
											<asp:ListItem Value="0" Selected="True">Не имеет значения</asp:ListItem>
											<asp:ListItem Value="10">Высшее</asp:ListItem>
											<asp:ListItem Value="20">Среднее специальное</asp:ListItem>
											<asp:ListItem Value="30">Среднее</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 247px; HEIGHT: 4px" align="right">Профиль образования:</TD>
									<TD style="HEIGHT: 4px">
										<asp:DropDownList id="ProfObrazList" runat="server" Width="240px" Font-Bold="True" ForeColor="Maroon"
											Font-Names="Tahoma" Font-Size="9pt">
											<asp:ListItem Value="0" Selected="True">Не имеет значения</asp:ListItem>
											<asp:ListItem Value="Юридическое">Юридическое</asp:ListItem>
											<asp:ListItem Value="Экономическое">Экономическое</asp:ListItem>
											<asp:ListItem Value="Техническое">Техническое</asp:ListItem>
											<asp:ListItem Value="Медицинское">Медицинское</asp:ListItem>
											<asp:ListItem Value="Педагогическое">Педагогическое</asp:ListItem>
											<asp:ListItem Value="Военное">Военное</asp:ListItem>
											<asp:ListItem Value="Пожарное">Пожарное</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 247px; HEIGHT: 11px" align="right"><FONT color="#000000">Возраст:</FONT></TD>
									<TD style="HEIGHT: 11px">
										<asp:TextBox id="AgeBox" runat="server" Width="88px" Font-Bold="True" ForeColor="Maroon" Font-Names="Tahoma"
											Font-Size="9pt"></asp:TextBox>&nbsp;лет</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 247px; HEIGHT: 31px" align="right"><FONT color="#000000">Пол:</FONT></TD>
									<TD style="HEIGHT: 31px">
										<asp:DropDownList id="SexList" runat="server" Width="88px" Font-Bold="True" ForeColor="Maroon" Font-Names="Tahoma"
											Font-Size="9pt">
											<asp:ListItem Value="0" Selected="True">Мужской</asp:ListItem>
											<asp:ListItem Value="1">Женский</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 247px; HEIGHT: 12px" align="right">Рост:</TD>
									<TD style="HEIGHT: 12px">
										<asp:TextBox id="SizeBox" runat="server" Width="88px" Font-Bold="True" ForeColor="Maroon" Font-Names="Tahoma"
											Font-Size="9pt"></asp:TextBox>&nbsp;см.</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 247px; HEIGHT: 12px" align="right">Оклад (по должности) от:</TD>
									<TD style="HEIGHT: 12px">
										<asp:TextBox id="OkladBox" runat="server" Width="88px" Font-Bold="True" ForeColor="Maroon" Font-Names="Tahoma"
											Font-Size="9pt">1100</asp:TextBox>&nbsp;руб.</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 247px; HEIGHT: 6px" align="right">Служба в ВС:</TD>
									<TD style="HEIGHT: 6px">
										<asp:DropDownList id="SluzbaList" runat="server" Width="88px" Font-Bold="True" ForeColor="Maroon"
											Font-Names="Tahoma" Font-Size="9pt">
											<asp:ListItem Value="Да">Да</asp:ListItem>
											<asp:ListItem Value="Нет" Selected="True">Нет</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 247px; HEIGHT: 8px" align="right">Участие в боевых действиях:</TD>
									<TD style="HEIGHT: 8px">
										<asp:DropDownList id="BDList" runat="server" Width="88px" Font-Bold="True" ForeColor="Maroon" Font-Names="Tahoma"
											Font-Size="9pt">
											<asp:ListItem Value="Да">Да</asp:ListItem>
											<asp:ListItem Value="Нет" Selected="True">Нет</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 247px; HEIGHT: 9px" align="right"><FONT color="#000000">Ограничения 
											по здоровью:</FONT></TD>
									<TD style="HEIGHT: 9px">
										<asp:DropDownList id="HealthList" runat="server" Width="240px" Font-Bold="True" ForeColor="Maroon"
											Font-Names="Tahoma" Font-Size="9pt">
											<asp:ListItem Value="0" Selected="True">Нет ограничений</asp:ListItem>
											<asp:ListItem Value="1">1 - группа предназначения</asp:ListItem>
											<asp:ListItem Value="2">2 - группа предназначения</asp:ListItem>
											<asp:ListItem Value="3">3 - группа предназначения</asp:ListItem>
											<asp:ListItem Value="4">4 - группа предназначения</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 247px" align="right">Опыт руководящей работы:</TD>
									<TD>
										<asp:DropDownList id="BossList" runat="server" Width="88px" Font-Bold="True" ForeColor="Maroon" Font-Names="Tahoma"
											Font-Size="9pt">
											<asp:ListItem Value="Да">Да</asp:ListItem>
											<asp:ListItem Value="Нет" Selected="True">Нет</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 247px; HEIGHT: 8px" align="right">Наличие водительских прав:</TD>
									<TD style="HEIGHT: 8px">
										<asp:DropDownList id="VodilaList" runat="server" Width="88px" Font-Bold="True" ForeColor="Maroon"
											Font-Names="Tahoma" Font-Size="9pt">
											<asp:ListItem Value="Да">Да</asp:ListItem>
											<asp:ListItem Value="Нет" Selected="True">Нет</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 247px; HEIGHT: 15px" align="right">Место службы:</TD>
									<TD style="HEIGHT: 15px">
										<asp:DropDownList id="PlaceList" runat="server" Width="240px" Font-Bold="True" ForeColor="Maroon"
											Font-Names="Tahoma" Font-Size="9pt">
											<asp:ListItem Value="0" Selected="True">Не имеет значения</asp:ListItem>
											<asp:ListItem Value="IN (1,2,3,4,5,10,28,29,30,31,32,54,312)">только г.Иваново</asp:ListItem>
											<asp:ListItem Value="NOT IN (1,2,3,4,5,10,28,29,30,31,32,54,312)">кроме г.Иваново</asp:ListItem>
											<asp:ListItem Value="1">только аппарат УВД</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<HR width="100%" SIZE="1">
									</TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<asp:ImageButton id="NextButton" runat="server" ImageUrl="/images/btn_next.gif" onclick="NextButton_Click"></asp:ImageButton></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"></TD>
								</TR>
								<TR>
									<TD align="left" colSpan="2">
										<asp:Label id="Result" runat="server"></asp:Label></TD>
								</TR>
							</TABLE>
						</P>
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
