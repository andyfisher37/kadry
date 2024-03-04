<%@ Page language="c#" Codebehind="orgstr.aspx.cs" AutoEventWireup="True" Inherits="kadry.Structure.orgstr" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - организационно-штатная 
			структура...</title>
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
			<TABLE style="WIDTH: 802px; HEIGHT: 320px" height="320" cellSpacing="0" 
                cellPadding="0" align="left" border="0">
				<TR>
					<TD style="WIDTH: 740px; HEIGHT: 2px" vAlign="top" align="center" height="2"><IMG alt="Информационная система обработки данных "Кадры"" src="/images/header_small.gif" useMap="#Map2"
							border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP>
					</TD>
				</TR>
				<TR>
					<TD class="Header" style="WIDTH: 740px; HEIGHT: 22px" vAlign="top" align="center" height="22">
                        организационно-штатная структура (ШТАТНО-ДОЛЖНОСТНАЯ 
						КНИГА)</TD>
				</TR>
				<TR>
					<TD class="smalltext" style="WIDTH: 740px; HEIGHT: 280px" vAlign="top" align="center"
						height="280">
						<TABLE id="Table1" style="WIDTH: 777px; HEIGHT: 175px" cellSpacing="0" 
                            cellPadding="0" bgColor="#D1D1D1" border="0" class="maintext">
							<TR>
								<TD class="style5" align="right">Подразделение:</TD>
								<TD class="style8" align="right">&nbsp;</TD>
								<TD class="style1">
                                    <asp:dropdownlist id=podrList runat="server" 
                                        DataValueField="KEY_OF_POD" DataTextField="PODRAZDEL" 
                                        DataSource="<%# podrDataSet %>" Width="470px" AutoPostBack="True" 
                                        CssClass="label2" onselectedindexchanged="podrList_SelectedIndexChanged" 
                                        Height="21px">
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="style5" align="right">
                                    <asp:Label ID="podchLabel" runat="server" Text="подчиненное подразделение:" 
                                        Visible="False"></asp:Label>
                                </TD>
								<TD class="style8" align="right">
                                    &nbsp;</TD>
								<TD class="style1">
                                    <asp:DropDownList ID="podchList" runat="server" CssClass="label2" 
                                        DataSourceID="podchDataSource" DataTextField="NAIMENOVAN" 
                                        DataValueField="KEY_OF_NAI" Height="21px" Visible="False" Width="470px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="podchDataSource" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:oldKADRYConnectionString %>" 
                                        ProviderName="<%$ ConnectionStrings:oldKADRYConnectionString.ProviderName %>" 
                                        SelectCommand="SELECT [KEY_OF_NAI], [NAIMENOVAN] FROM [NAIMEN]">
                                    </asp:SqlDataSource>
                                </TD>
							</TR>
							<TR>
								<TD class="style6" align="right">Служба:</TD>
								<TD class="style9" align="right">&nbsp;</TD>
								<TD class="style2"><asp:dropdownlist id=sluzList runat="server" 
                                        DataValueField="KEY_OF_SLU" DataTextField="NAM_OF_SLU" 
                                        DataSource="<%# sluzDataSet %>" Width="360px" CssClass="label2" 
                                        Height="21px">
									</asp:dropdownlist>&nbsp;<A href="..//sluzhelp.htm"><IMG id="IMG1" alt="Информация об объединении некоторых служб при выполнении запросов..."
											src="..//images/btn_help.gif" border="0"></A></TD>
							</TR>
							<TR>
								<TD class="style6" align="right">&nbsp;</TD>
								<TD class="style9" align="right">&nbsp;</TD>
								<TD class="style2">
                                    <asp:CheckBox ID="ChSl" runat="server" Checked="True" CssClass="maintext" 
                                        Text="Объединять &quot;глобальные службы&quot;" />
                                </TD>
							</TR>
							<TR>
								<TD class="style7" align="right"><FONT class="maintext" size="3">Категория 
										должностей:</FONT></TD>
								<TD class="style10" align="right">&nbsp;</TD>
								<TD class="style3">
                                    <asp:dropdownlist id="dolzList" runat="server" 
                                        Width="360px" CssClass="label2" Height="21px">
										<asp:ListItem Value="0" Selected="True">Все должности (атт. + вольн.)</asp:ListItem>
										<asp:ListItem Value="1">Только аттестованные</asp:ListItem>
										<asp:ListItem Value="2">Только руководство (от нач.отделения и выше)</asp:ListItem>
										<asp:ListItem Value="3">Старший и средний нач.состав</asp:ListItem>
										<asp:ListItem Value="4">Младший нач.состав (рядовой)</asp:ListItem>
										<asp:ListItem Value="5">Вольнонаемный состав (работники)</asp:ListItem>
									    <asp:ListItem Value="6">Федеральные гражданские государственные служащие</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="style5" align="right">Предельное специальное звание:</TD>
								<TD class="style8" align="right">&nbsp;</TD>
								<TD class="style4">
									<asp:DropDownList id="cList" runat="server" CssClass="label2" Height="21px">
										<asp:ListItem Value="0">только</asp:ListItem>
										<asp:ListItem Value="1">от</asp:ListItem>
										<asp:ListItem Value="2">до</asp:ListItem>
									</asp:DropDownList>
									<asp:dropdownlist id="zvanList" runat="server" Width="291px" 
                                        DataSource="<%# zvDataSet %>" DataTextField="VOIN_ZVAN" 
                                        DataValueField="KEY_ZVAN" CssClass="label2" Height="21px">
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="style5" align="right">&nbsp;</TD>
								<TD class="style8" align="right">&nbsp;</TD>
								<TD class="style4">
									<asp:CheckBox ID="CheckSokr" runat="server" CssClass="maintext" 
                                        Text="Показывать только сокращенные должности" />
                                </TD>
							</TR>
							<TR>
								<TD class="style5" align="right">&nbsp;</TD>
								<TD class="style8" align="right">&nbsp;</TD>
								<TD class="style4">
									<asp:CheckBox ID="CheckNoSokr" runat="server" CssClass="maintext" 
                                        Text="Показывать только НЕСОКРАЩЕННЫЕ должности" />
                                </TD>
							</TR>
							<TR>
								<TD class="style5" align="right">Стиль отображения:</TD>
								<TD class="style8" align="right">&nbsp;</TD>
								<TD class="style4">
									<asp:CheckBox ID="ViewType1" runat="server" Checked="True" CssClass="maintext" 
                                        Text="Табличный" AutoPostBack="True" 
                                        oncheckedchanged="ViewType1_CheckedChanged" />
                                    <asp:CheckBox ID="ViewType2" runat="server" CssClass="maintext" 
                                        Text="Иерархический" AutoPostBack="True" 
                                        oncheckedchanged="ViewType2_CheckedChanged" />
                                </TD>
							</TR>
							<TR>
								<TD class="style13" align="right">&nbsp;</TD>
								<TD class="style12" align="right">&nbsp;</TD>
								<TD class="style14">
									&nbsp;</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><asp:imagebutton id="Button_next" runat="server" ImageUrl="..//images/btn_view.gif" onclick="Button_next_Click"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><asp:label class="label2" id="Result" runat="server"></asp:label></TD>
							</TR>
						</TABLE>
						<P><FONT color="#ff0066"></FONT>&nbsp;<FONT color="#ff0066">*Приказ МВД РФ от 26 июля 1996 г. № 446дсп п.4.1.4.
									Штатно-должностная книга и должностная карточка предназначены 
							для <U>оперативного контроля</U> за укомплектованностью штатных должностей 
							рядового, начальствующего состава, гражданского персонала, а также качественным 
							составом кадров.</P>
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
