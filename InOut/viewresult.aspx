<%@ Page language="c#" Codebehind="viewresult.aspx.cs" AutoEventWireup="True" Inherits="kadry.Viewresult.Viewresult" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Принятые и уволенные...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#990000" aLink="#6666ff" link="#0000ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 759px; HEIGHT: 74px" height="74" cellSpacing="0" cellPadding="0" width="759"
				align="left" border="0">
				<TR>
					<TD class="Header" style="HEIGHT: 23px" align="center" height="23"><asp:label class="label2" id="TitleText" runat="server" Width="607px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 5px" vAlign="top" align="center" height="5"><asp:table id="Table1" runat="server" Width="752px" BorderColor="#404040" Font-Size="XX-Small"
							GridLines="Both" CellPadding="1" CellSpacing="0" BackColor="Azure" Font-Names="Verdana" BorderWidth="1px">
							<asp:TableRow BackColor="PowderBlue" Font-Size="XX-Small" Font-Names="Verdana">
								<asp:TableCell HorizontalAlign="Center" Text="Фамилия"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Имя"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Отчество"></asp:TableCell>
								<asp:TableCell runat="server" HorizontalAlign="Center">Дата рождения</asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Подразделение"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Служба"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Должность"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Звание"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Уволен с..."></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Статья увольнения"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Причина"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="в ОВД с..."></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Приказ"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="№"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата приказа"></asp:TableCell>
							    <asp:TableCell runat="server" HorizontalAlign="Center" 
                                    ToolTip="Номер личного дела">№ л/д</asp:TableCell>
							</asp:TableRow>
						</asp:table>
						<asp:table id="Table2" runat="server" Width="752px" BackColor="Azure" BorderWidth="1px" BorderColor="#404040"
							Font-Size="XX-Small" GridLines="Both" CellPadding="1" CellSpacing="0" Font-Names="Verdana">
							<asp:TableRow BackColor="PowderBlue" Font-Size="XX-Small" Font-Names="Verdana">
								<asp:TableCell HorizontalAlign="Center" Text="Фамилия"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Имя"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Отчество"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Подразделение"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Служба"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Должность"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Звание"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Отком. с..."></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Куда"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="в ОВД с..."></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Приказ"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="№"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата приказа"></asp:TableCell>
							</asp:TableRow>
						</asp:table>
						<asp:table id="Table3" runat="server" Width="752px" BackColor="Azure" BorderWidth="1px" BorderColor="#404040"
							Font-Size="XX-Small" GridLines="Both" CellPadding="1" CellSpacing="0" Font-Names="Verdana">
							<asp:TableRow BackColor="PowderBlue" Font-Size="XX-Small" Font-Names="Verdana">
								<asp:TableCell HorizontalAlign="Center" Text="Фамилия"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Имя"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Отчество"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата рождения"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Подразделение"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Служба"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Должность"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Звание"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата приема"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Приказ"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="№"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата приказа"></asp:TableCell>
							</asp:TableRow>
						</asp:table>
						<asp:table id="Table4" runat="server" Width="752px" BorderWidth="1px" Font-Names="Verdana"
							BackColor="Azure" CellSpacing="0" CellPadding="1" GridLines="Both" Font-Size="XX-Small"
							BorderColor="#404040">
							<asp:TableRow BackColor="PowderBlue" Font-Size="XX-Small" Font-Names="Verdana">
								<asp:TableCell HorizontalAlign="Center" Text="Фамилия"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Имя"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Отчество"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата рождения"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Подразделение"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Служба"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Должность"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Звание"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата приема"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Учебное заведение"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Приказ"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="№"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата приказа"></asp:TableCell>
							</asp:TableRow>
						</asp:table>
						<asp:table id="Table5" runat="server" Width="752px" BorderWidth="1px" Font-Names="Verdana"
							BackColor="Azure" CellSpacing="0" CellPadding="1" GridLines="Both" Font-Size="XX-Small"
							BorderColor="#404040">
							<asp:TableRow BackColor="PowderBlue" Font-Size="XX-Small" Font-Names="Verdana">
								<asp:TableCell HorizontalAlign="Center" Text="Фамилия"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Имя"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Отчество"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата рождения"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Подразделение"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Служба"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Должность"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Звание"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата прибытия"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Откуда прибыл"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Приказ"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="№"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата приказа"></asp:TableCell>
							</asp:TableRow>
						</asp:table>
						<asp:table id="Table6" runat="server" Width="752px" BorderWidth="1px" Font-Names="Verdana"
							BackColor="Azure" CellSpacing="0" CellPadding="1" GridLines="Both" Font-Size="XX-Small"
							BorderColor="#404040">
							<asp:TableRow BackColor="PowderBlue" Font-Size="XX-Small" Font-Names="Verdana">
								<asp:TableCell HorizontalAlign="Center" Text="№ п/п"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Наименование подразделения"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Всего принято"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="В т.ч. нач.состав"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="В т.ч. ряд.состав"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Из них в ОВО"></asp:TableCell>
							</asp:TableRow>
						</asp:table>
						<asp:table id="Table7" runat="server" Width="752px" BorderWidth="1px" Font-Names="Verdana"
							BackColor="Azure" CellSpacing="0" CellPadding="1" GridLines="Both" Font-Size="XX-Small"
							BorderColor="#404040">
							<asp:TableRow BackColor="PowderBlue" Font-Size="XX-Small" Font-Names="Verdana">
								<asp:TableCell HorizontalAlign="Center" Text="№ п/п"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Наименование службы"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Всего принято"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="В т.ч. нач.состав"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="В т.ч. ряд.состав"></asp:TableCell>
							</asp:TableRow>
						</asp:table>
						<asp:table id="Table8" runat="server" Width="752px" BorderColor="#404040" Font-Size="XX-Small"
							GridLines="Both" CellPadding="1" CellSpacing="0" BackColor="Azure" Font-Names="Verdana" 
                            BorderWidth="1px">
							<asp:TableRow BackColor="PowderBlue" Font-Size="XX-Small" Font-Names="Verdana">
								<asp:TableCell HorizontalAlign="Center" Text="Фамилия"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Имя"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Отчество"></asp:TableCell>
								<asp:TableCell runat="server" HorizontalAlign="Center">Дата рождения</asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Подразделение"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Служба"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Должность"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Звание"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Уволен с..."></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Статья увольнения"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Причина"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="в ОВД с..."></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Приказ"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="№"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата приказа"></asp:TableCell>
							</asp:TableRow>
						</asp:table>
						<asp:Label class="maintext" id="CountLabel" runat="server"></asp:Label>
						<br>
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
