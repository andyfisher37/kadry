<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Page language="c#" Codebehind="TextSearch.aspx.cs" AutoEventWireup="True" Inherits="UK.Search.TextSearch" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационно-аналитическая служба УРЛС УВД - поиск сотрудников (текстовая 
			версия)</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		leftMargin="0" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="LEFT: 0px; WIDTH: 753px; POSITION: absolute; TOP: 0px; HEIGHT: 448px" tabIndex="23"
				height="448" cellSpacing="0" cellPadding="0" width="753" align="left" border="0">
				<TBODY>
					<TR vAlign="top">
						<TD style="HEIGHT: 20px" vAlign="top" align="center" colSpan="19" class="label2">Информационно-аналитическая 
							служба УРЛС УВД по Ивановской области</TD>
					</TR>
					<TR vAlign="top">
						<TD style="HEIGHT: 15px" vAlign="top" align="center" height="15">
							<P class="Header" align="center">Поисковая система "КАДРЫ" (Текстовая версия)</P>
						</TD>
					</TR>
					<TR vAlign="top">
						<TD tabIndex="0" vAlign="top" align="center" style="HEIGHT: 374px">
							<P tabIndex="16"><A href="howtosearch.htm"></A></P>
							<TABLE class="maintext" id="Table1" tabIndex="0" cellSpacing="1" cellPadding="1" align="center"
								bgColor="bisque" border="0" style="WIDTH: 740px; HEIGHT: 200px">
								<TR>
									<TD class="maintext" vAlign="middle" align="right" style="HEIGHT: 2px">Фамилия:</TD>
									<TD style="HEIGHT: 2px"><asp:textbox id="first_name" tabIndex="1" runat="server" Font-Size="X-Small" Width="152" ToolTip="Введите фамилию"
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana" ontextchanged="first_name_TextChanged"></asp:textbox></TD>
									<TD class="maintext" style="WIDTH: 153px; HEIGHT: 2px" align="right">Подразделение:</TD>
									<TD style="HEIGHT: 2px"><asp:dropdownlist id=podrList tabIndex=7 runat="server" Font-Size="7pt" Width="240" ForeColor="#C00000" Font-Names="Verdana" DataMember="Table" DataTextField="PODRAZDEL" DataValueField="KEY_OF_POD" DataSource="<%# podrDataSet %>"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="maintext" align="right" width="131" height="2" style="HEIGHT: 2px">Имя:</TD>
									<TD style="HEIGHT: 2px"><asp:textbox id="name" tabIndex="2" runat="server" Font-Size="X-Small" Width="152" ToolTip="Имя"
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana" ontextchanged="name_TextChanged"></asp:textbox></TD>
									<TD class="maintext" style="WIDTH: 153px; HEIGHT: 2px" align="right" width="153" height="2"><A href="..//sluzhelp.htm"><IMG id="IMG1" alt="Информация об объединении некоторых служб при выполнении запросов..."
												src="..//images/btn_help.gif" border="0"></A>&nbsp;Служба:</TD>
									<TD height="2" style="HEIGHT: 2px"><asp:dropdownlist id=sluzList tabIndex=8 runat="server" Font-Size="7pt" Width="240" ForeColor="#C00000" Font-Names="Verdana" DataMember="Table" DataTextField="NAM_OF_SLU" DataValueField="KEY_OF_SLU" DataSource="<%# sluzDataSet %>"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="maintext" style="HEIGHT: 3px" align="right" width="131" height="3">Отчество:</TD>
									<TD style="HEIGHT: 3px" width="200" height="3"><asp:textbox id="last_name" tabIndex="3" runat="server" Font-Size="X-Small" Width="152" ToolTip="Отчество"
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana" ontextchanged="last_name_TextChanged"></asp:textbox></TD>
									<TD class="maintext" style="WIDTH: 153px; HEIGHT: 3px" align="right" width="153" height="3">Категория 
										должностей:</TD>
									<TD style="HEIGHT: 3px" height="3"><asp:dropdownlist id="dolzList" tabIndex="9" runat="server" Font-Size="7pt" Width="240" ForeColor="#C00000"
											Font-Names="Verdana">
											<asp:ListItem Value="0" Selected="True">Любые должности</asp:ListItem>
											<asp:ListItem Value="-1">Только аттестованные</asp:ListItem>
											<asp:ListItem Value="1">Руководство (от нач.отделения и выше)</asp:ListItem>
											<asp:ListItem Value="2">Старший и средний нач.состав</asp:ListItem>
											<asp:ListItem Value="3">Младший нач.состав</asp:ListItem>
											<asp:ListItem Value="4">Работники, служащие</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="maintext" style="HEIGHT: 7px" align="right" width="131" height="7">Личный 
										номер:</TD>
									<TD style="HEIGHT: 7px" width="200" height="7"><asp:textbox id="num_1" tabIndex="4" runat="server" Font-Size="X-Small" Width="32" ToolTip="Симольная часть личного номера"
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana"></asp:textbox>-
										<asp:textbox id="num_2" tabIndex="3" runat="server" Font-Size="X-Small" Width="112px" ToolTip="Числовая часть личного номера"
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana"></asp:textbox></TD>
									<TD class="maintext" style="WIDTH: 153px; HEIGHT: 7px" align="right" width="153" height="7"></TD>
									<TD class="maintext" style="HEIGHT: 7px" height="7"></TD>
								</TR>
								<TR>
									<TD class="maintext" vAlign="middle" align="center" colSpan="4" style="HEIGHT: 1px">
										<P><FONT size="1">категория сотрудников:</FONT>
											<asp:radiobutton class="label" id="RadioButton1" tabIndex="12" runat="server" Width="140px" ToolTip="Работающие по настоящее время"
												Checked="True" GroupName="TypeSearch" Text="- действующие" CssClass="label"></asp:radiobutton><asp:radiobutton class="maintext" id="RadioButton2" tabIndex="13" runat="server" Width="140px" ToolTip="Уволенные..."
												GroupName="TypeSearch" Text="- архив" CssClass="label"></asp:radiobutton><asp:radiobutton class="maintext" id="RadioButton3" tabIndex="14" runat="server" Width="140px" ToolTip="Находящиеся за штатом (или в декрете)"
												GroupName="TypeSearch" Text="- резерв" CssClass="label"></asp:radiobutton><asp:radiobutton id="RadioButton4" tabIndex="15" runat="server" Width="140px" ToolTip="Откомандированные в другие области или ведомства"
												GroupName="TypeSearch" Text="- откомандированные" CssClass="label"></asp:radiobutton></P>
									</TD>
								</TR>
								<TR>
									<TD class="maintext" align="center" colSpan="4" style="HEIGHT: 16px">
										<asp:Button id="GoBtn" runat="server" Text="поиск" ToolTip="Давай поищем!" onclick="GoBtn_Click"></asp:Button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="4" height="8" style="HEIGHT: 8px">
										<HR align="center" width="100%" color="#660033" SIZE="2">
										<A href="help.htm"><FONT size="1">[основные правила поиска]</FONT></A>
									</TD>
								</TR>
								<TR>
									<TD align="right" colSpan="4" height="3"><FONT face="Verdana" size="1"><asp:hyperlink id="secure_text" runat="server" ToolTip="Подробнее об ограничениях..." ForeColor="Red"></asp:hyperlink></FONT></TD>
								</TR>
								<TR>
									<TD class="maintext" vAlign="bottom" align="left" width="213" colSpan="4" height="14">
										<P><asp:label id="FindLabel" runat="server" Font-Size="XX-Small" Width="728px" ForeColor="Black"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD vAlign="bottom" align="left" width="213" colSpan="4" height="14"></TD>
								</TR>
							</TABLE>
							<P tabIndex="16"><asp:datagrid id=Grid runat="server" Width="736px" ToolTip="Нажми на Фамилию и просмотри служебную карточку сотрудника..." Font-Names="Verdana" DataMember="Table" DataSource="<%# mainDataSet %>" Height="52px" BorderWidth="1px" BorderColor="Black" HorizontalAlign="Center" AutoGenerateColumns="False" BackColor="White">
									<SelectedItemStyle Font-Size="10px" Font-Names="Verdana" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
										BackColor="#669999"></SelectedItemStyle>
									<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" ForeColor="#000066"
										VerticalAlign="Middle"></ItemStyle>
									<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
										ForeColor="Black" VerticalAlign="Middle" BackColor="#FFFFCC"></HeaderStyle>
									<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
									<Columns>
										<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="KEY_1" DataNavigateUrlFormatString="../DetailPage_s.aspx?id={0}"
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
											<HeaderStyle Width="15%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="voin_zvan" SortExpression="voin_zvan" HeaderText="Звание">
											<HeaderStyle Width="10%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="lich_nom_1" SortExpression="lich_nom_1" HeaderText="Личный номер">
											<HeaderStyle Width="8%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
									<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
								</asp:datagrid></P>
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
</HTML>
