<%@ Page language="c#" Codebehind="Education.aspx.cs" AutoEventWireup="false" Inherits="kadry.Education.Education" %>
<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - статистика по образованию 
			сотрудников ГРУОВД области</title>
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
			<TABLE style="WIDTH: 832px; HEIGHT: 664px" height="664" cellSpacing="0" cellPadding="0"
				width="832" align="left" border="0">
				<TR>
					<TD style="HEIGHT: 102px" vAlign="top" align="center" height="102"><IMG alt="" 
                            src="/images/header_small.gif" border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP>
					</TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 1px" align="center" height="1">СТАТИСТИКА, 
						ОБРАЗОВАНИе</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 432px" vAlign="top" align="center"><br>
						<TABLE id="Table1" style="WIDTH: 614px; HEIGHT: 336px" cellSpacing="0" cellPadding="0"
							width="614" bgColor="#D1D1D1" border="0">
							<TR>
								<TD class="maintext" style="WIDTH: 155px; HEIGHT: 34px" align="right">Степень 
									образования:</TD>
								<TD style="WIDTH: 421px; HEIGHT: 34px"><asp:dropdownlist id="stepList" tabIndex="1" runat="server" Font-Bold="True" ForeColor="Maroon" Width="414px">
										<asp:ListItem Value="0" Selected="True">Любая</asp:ListItem>
										<asp:ListItem Value="10">Высшее</asp:ListItem>
										<asp:ListItem Value="20">Среднее-специальное</asp:ListItem>
										<asp:ListItem Value="30">Среднее</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 34px" vAlign="middle" align="center"></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 155px; HEIGHT: 34px" align="right">Учебное 
									заведение:</TD>
								<TD style="WIDTH: 421px; HEIGHT: 34px"><asp:dropdownlist id=uczList tabIndex=2 runat="server" Font-Bold="True" ForeColor="Maroon" Width="414px" DataMember="SLVUCZ" DataValueField="P2" DataTextField="P1" DataSource="<%# obrDataSet %>"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 34px" vAlign="middle" align="center"></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 155px; HEIGHT: 34px" align="right">Подразделение:</TD>
								<TD style="WIDTH: 421px; HEIGHT: 34px"><asp:dropdownlist id=podrList tabIndex=3 runat="server" Font-Bold="True" ForeColor="Maroon" Width="412px" DataMember="Table" DataValueField="KEY_OF_POD" DataTextField="PODRAZDEL" DataSource="<%# podrDataSet %>"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 34px" vAlign="middle" align="center"></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 155px; HEIGHT: 34px" align="right">Служба:</TD>
								<TD style="WIDTH: 421px; HEIGHT: 34px"><asp:dropdownlist id=sluzList tabIndex=4 runat="server" Font-Bold="True" ForeColor="Maroon" Width="412px" DataMember="Table" DataValueField="KEY_OF_SLU" DataTextField="NAM_OF_SLU" DataSource="<%# sluzDataSet %>"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 34px" vAlign="middle" align="center"></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 155px; HEIGHT: 34px" align="right">Должность:</TD>
								<TD style="WIDTH: 421px; HEIGHT: 34px"><asp:dropdownlist id="dolzList" tabIndex="5" runat="server" Font-Bold="True" ForeColor="Maroon" Width="412px">
										<asp:ListItem Value="0" Selected="True">Любые должности</asp:ListItem>
										<asp:ListItem Value="1">Руководство</asp:ListItem>
										<asp:ListItem Value="2">Старший и средний нач. состав</asp:ListItem>
										<asp:ListItem Value="3">Младший нач.состав</asp:ListItem>
										<asp:ListItem Value="4">Вольнонаемный состав</asp:ListItem>
										<asp:ListItem Value="5">Только аттестованные</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 34px" vAlign="middle" align="center"></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 155px; HEIGHT: 34px" align="right">Год окончания 
									УЗ:</TD>
								<TD style="WIDTH: 421px; HEIGHT: 34px"><asp:dropdownlist id="znakList" tabIndex="6" runat="server" Font-Bold="True" ForeColor="Maroon">
										<asp:ListItem Value="?" Selected="True">?</asp:ListItem>
										<asp:ListItem Value="=">=</asp:ListItem>
										<asp:ListItem Value="&gt;">&gt;</asp:ListItem>
										<asp:ListItem Value="&lt;">&lt;</asp:ListItem>
										<asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
										<asp:ListItem Value="&lt;=">&lt;=</asp:ListItem>
									</asp:dropdownlist><asp:textbox id="YearBox" tabIndex="7" runat="server" Font-Bold="True" ForeColor="Maroon" Width="64px"></asp:textbox></TD>
								<TD style="HEIGHT: 34px" vAlign="middle" align="center"></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 155px; HEIGHT: 34px" align="right">Специальность:</TD>
								<TD style="WIDTH: 421px; HEIGHT: 34px"><asp:dropdownlist id=kvaList tabIndex=8 runat="server" Font-Bold="True" ForeColor="Maroon" Width="412px" DataMember="SLVKVA" DataValueField="P2" DataTextField="P1" DataSource="<%# kvaDataSet %>"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 34px" vAlign="middle" align="center"></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 155px; HEIGHT: 34px" align="right">Профиль 
									образования:</TD>
								<TD style="WIDTH: 421px; HEIGHT: 34px"><asp:dropdownlist id="profList" tabIndex="9" runat="server" Font-Bold="True" ForeColor="Maroon" Width="412px">
										<asp:ListItem Value="0" Selected="True">Любой профиль</asp:ListItem>
										<asp:ListItem Value="Юридическое">Юридическое</asp:ListItem>
										<asp:ListItem Value="Экономическое">Экономическое</asp:ListItem>
										<asp:ListItem Value="Техническое">Техническое</asp:ListItem>
										<asp:ListItem Value="Медицинское">Медицинское</asp:ListItem>
										<asp:ListItem Value="Пожарное">Пожарное</asp:ListItem>
										<asp:ListItem Value="Военное">Военное</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 34px" vAlign="middle" align="center"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3">
									<P><FONT size="1">категория сотрудников:</FONT>
										<asp:radiobutton class="label" id="RadioButton1" tabIndex="12" runat="server" Width="92px" ToolTip="Работающие по настоящее время"
											Checked="True" GroupName="TypeSearch" Text="- действующие" CssClass="label" AutoPostBack="True"></asp:radiobutton>
										<asp:radiobutton class="maintext" id="RadioButton2" tabIndex="13" runat="server" Width="68px" ToolTip="Уволенные..."
											GroupName="TypeSearch" Text="- архив" CssClass="label" AutoPostBack="True"></asp:radiobutton>
										<asp:radiobutton class="maintext" id="RadioButton3" tabIndex="14" runat="server" Width="68px" ToolTip="Находящиеся за штатом (или в декрете)"
											GroupName="TypeSearch" Text="- резерв" CssClass="label" AutoPostBack="True"></asp:radiobutton>
										<asp:radiobutton id="RadioButton4" tabIndex="15" runat="server" Width="124px" ToolTip="Откомандированные в другие области или ведомства"
											GroupName="TypeSearch" Text="- откомандированные" CssClass="label" AutoPostBack="True"></asp:radiobutton></P>
								</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3">
									<asp:imagebutton id="ImageButton5" runat="server" ImageUrl="../images/btn_stat.gif"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3">
									&nbsp;</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3">
									<asp:ImageButton ID="ImageButton6" runat="server" 
                                        ImageUrl="../images/btn_list.gif" onclick="ImageButton6_Click" />
                                    <br />
                                    <br />
                                    <asp:ImageButton ID="ImageButton7" runat="server" 
                                        ImageUrl="../images/btn_list1.gif" onclick="Button1_Click" />
                                </TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3">
									&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 155px" align="left" colSpan="3">
									<asp:Label class="label2" id="ResLabel" runat="server" Width="560px"></asp:Label></TD>
							</TR>
						</TABLE>
						<br>
						<asp:datagrid id=Grid runat="server" Width="816px" DataSource="<%# listDataSet %>" ToolTip="Нажми на Фамилию и просмотри служебную карточку сотрудника..." Font-Names="Verdana" BorderWidth="1px" BorderColor="Black" HorizontalAlign="Center" AutoGenerateColumns="False" BackColor="White" Height="52px">
							<SelectedItemStyle Font-Size="10px" Font-Names="Verdana" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
								BackColor="#669999"></SelectedItemStyle>
							<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" ForeColor="#000066"
								VerticalAlign="Middle"></ItemStyle>
							<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
								ForeColor="Black" VerticalAlign="Middle" BackColor="#FFFFCC"></HeaderStyle>
							<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
							<Columns>
								<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="KEY_1" DataNavigateUrlFormatString="../DetailPage.aspx?id={0}"
									DataTextField="FAMILIYA" SortExpression="FAMILIYA" HeaderText="Фамилия">
									<HeaderStyle Width="9%"></HeaderStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="imya" HeaderText="Имя">
									<HeaderStyle Width="9%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="otchectvo" HeaderText="Отчество">
									<HeaderStyle Width="9%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="data_rozd" SortExpression="data_rozd" HeaderText="Дата рождения" DataFormatString="{0:d}">
									<HeaderStyle Width="7%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="podrazdel" SortExpression="podrazdel" HeaderText="Подразделение">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="nam_of_slu" SortExpression="nam_of_slu" HeaderText="Служба">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="nam_of_dol" SortExpression="nam_of_dol" HeaderText="Должность">
									<HeaderStyle Width="25%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="voin_zvan" SortExpression="voin_zvan" HeaderText="Звание">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="P1" SortExpression="P1" HeaderText="Образ.учреждение"></asp:BoundColumn>
								<asp:BoundColumn DataField="DAT_OKUZ" SortExpression="DAT_OKUZ" HeaderText="Год окончания" DataFormatString="{0:d}">
									<HeaderStyle Width="3%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:datagrid><br>
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
                                 <AREA title="Качественные показатели" shape="RECT" alt="Качественные показатели" coords="575,0,650,33"	href="../Quality/Quality.aspx">
                                 <AREA title="Дисциплинарная практика" shape="RECT" alt="Дисциплинарная практика" coords="700,0,775,33"	href="../Discipline/discipline.aspx">
                                 </MAP></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
