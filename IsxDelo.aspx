<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IsxDelo.aspx.cs" Inherits="UK.IsxDelo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Подготовка исходящего УРЛС на личное дело сотрудника...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio 2008">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
    <form id="form1" runat="server">
    <TABLE style="LEFT: 0px; POSITION: absolute; TOP: 0px" tabIndex="23" height="521" cellSpacing="0"
				cellPadding="0" width="753" align="left" border="0">
				<TBODY>
					<TR vAlign="top">
						<TD style="HEIGHT: 85px" vAlign="top" align="center" colSpan="19"><IMG alt="Информационная система обработки данных "Кадры"" src="/images/header_small.gif" border="0"></TD>
					</TR>
					<TR vAlign="top">
						<TD style="HEIGHT: 15px" vAlign="top" align="center" height="15">
							<P class="Header" align="center">ПОДГОТОВКА ИСХОДЯЩЕГО НА ОТПРАВКУ/ПОЛУЧЕНИЕ ЛИЧНОГО 
                                ДЕЛА</P>
						</TD>
					</TR>
					<TR vAlign="top">
						<TD tabIndex="0" vAlign="top" align="center">
							<P tabIndex="16"><A href="howtosearch.htm"></A></P>
							<P tabIndex="16">
								<TABLE id="Table1" style="WIDTH: 725px; HEIGHT: 257px" cellSpacing="0" 
                                    cellPadding="0" border="0" align="center" bgcolor="#FFFFCC" 
                                    class="maintext">
									<TR>
										<TD align="center" bgcolor="#FFCC99" colspan="2">
                                            <asp:RadioButtonList ID="TypeBtn" runat="server" AutoPostBack="True" 
                                                CssClass="maintext" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="0">Отправка</asp:ListItem>
                                                <asp:ListItem Value="1">Получение</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </TD>
									</TR>
									<TR>
										<TD align="left" class="maintext">
											Должность руководителя, наименование подразделения:</TD>
										<TD class="smalltext">
											<asp:TextBox ID="PodrName" runat="server" Width="400px">Начальнику...</asp:TextBox>
                                        </TD>
									</TR>
									<TR>
										<TD align="left" class="maintext">
											Специальное звание руководителя:</TD>
										<TD class="smalltext">
                                            <asp:DropDownList ID="ZvanList" runat="server" Width="400px">
                                                <asp:ListItem>полковнику вн.службы</asp:ListItem>
                                                <asp:ListItem Selected="True">полковнику милиции</asp:ListItem>
                                                <asp:ListItem>подполковнику вн.службы</asp:ListItem>
                                                <asp:ListItem>подполковнику милиции</asp:ListItem>
                                                <asp:ListItem>майору милиции</asp:ListItem>
                                                <asp:ListItem>капитану милиции</asp:ListItem>
                                                <asp:ListItem>старшему лейтенанту милиции</asp:ListItem>
                                                <asp:ListItem>генерал-майору милиции</asp:ListItem>
                                                <asp:ListItem>генерал-лейтенанту вн.службы</asp:ListItem>
                                            </asp:DropDownList>
                                        </TD>
									</TR>
									<TR>
										<TD align="left" class="maintext">
											Инициалы, фамилия руководителя:</TD>
										<TD class="smalltext">
                                            <asp:TextBox ID="PodrRuk" runat="server" Width="400px">И.И.ИВАНОВУ</asp:TextBox>
                                        </TD>
									</TR>
									<TR>
										<TD align="left" colspan="2">
											<asp:CheckBox ID="PrCheck" runat="server" CssClass="maintext" 
                                                Text="Добавить данные из приказа о назначении" Checked="True" />
                                        </TD>
									</TR>
									<TR>
										<TD align="left">
											Инициалы, фамилия исполнителя:</TD>
										<TD class="smalltext">
                                            <asp:TextBox ID="IspText" runat="server" Width="400px"></asp:TextBox>
                                        </TD>
									</TR>
									<TR>
										<TD align="left">
											Телефон исполнителя:</TD>
										<TD class="smalltext">
                                            <asp:TextBox ID="IspPhoneText" runat="server" Width="400px"></asp:TextBox>
                                        </TD>
									</TR>
									<TR>
										<TD align="left">
											Руководитель, подписывающий исходящий:</TD>
										<TD class="smalltext">
                                            <asp:DropDownList ID="RukList" runat="server" Width="400px">
                                                <asp:ListItem Value="Донской">С.Г.Донской</asp:ListItem>
                                                <asp:ListItem Value="Молодкин">М.В.Молодкин</asp:ListItem>
                                                <asp:ListItem Value="Новичков">Н.М.Новичков</asp:ListItem>
                                            </asp:DropDownList>
                                        </TD>
									</TR>
									<TR>
										<TD align="center" colspan="2">
											<asp:Label ID="PrilogLabel" runat="server" style="font-weight: 700" 
                                                Text="Содержание &quot;приложения&quot;:" Visible="False"></asp:Label>
                                        </TD>
									</TR>
									<TR>
										<TD align="left">
											<asp:CheckBox ID="Check1" runat="server" 
                                                Text="количество листов в личном деле:" Visible="False" />
                                        </TD>
										<TD class="smalltext">
                                            <asp:TextBox ID="Text1" runat="server" Visible="False" Width="100px"></asp:TextBox>
                                        </TD>
									</TR>
									<TR>
										<TD align="left">
											<asp:CheckBox ID="Check2" runat="server" 
                                                Text="количество листов материалов &quot;СП&quot;:" Visible="False" />
                                        </TD>
										<TD class="smalltext">
                                            <asp:TextBox ID="Text2" runat="server" Width="100px"></asp:TextBox>
                                        </TD>
									</TR>
									<TR>
										<TD align="left">
											<asp:CheckBox ID="Check3" runat="server" 
                                                Text="личное дело офицера запаса (листов):" Visible="False" />
                                        </TD>
										<TD class="smalltext">
                                            <asp:TextBox ID="Text3" runat="server" Width="100px"> </asp:TextBox>
                                        </TD>
									</TR>
									<TR>
										<TD align="left">
											<asp:CheckBox ID="Check4" runat="server" Text="трудовая книжка (серия, номер):" 
                                                Visible="False" />
                                        </TD>
										<TD class="smalltext">
                                            <asp:TextBox ID="Text4" runat="server" Width="100px"></asp:TextBox>
                                        </TD>
									</TR>
									<TR>
										<TD align="left">
											<asp:CheckBox ID="Check5" runat="server" Text="военный билет (серия, номер):" 
                                                Visible="False" />
                                        </TD>
										<TD class="smalltext">
                                            <asp:TextBox ID="Text5" runat="server" Width="100px"></asp:TextBox>
                                        </TD>
									</TR>
									<TR>
										<TD align="left" colspan="2">
											<asp:CheckBox ID="RetCheck" runat="server" 
                                                Text="По миновании надобности личное дело будет возвращено" />
                                        </TD>
									</TR>
									<TR>
										<TD align="left">
											&nbsp;</TD>
										<TD class="smalltext">&nbsp;</TD>
									</TR>
									<TR>
										<TD colspan="2">
											<asp:Button ID="GoButton" runat="server" onclick="GoButton_Click" 
                                                Text="подготовить" />
                                        </TD>
									</TR>
								</TABLE>
							</P>
                            <P tabIndex="16">
								&nbsp;</P>
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
				</TBODY>
			</TABLE>
    </form>
</body>
</html>
