<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>

<%@ Page language="c#" Codebehind="search.aspx.cs" AutoEventWireup="false" Inherits="UK.search" codePage="65001"   enableViewState="True"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационно-аналитическая служба УРЛС УВД - поиск сотрудников...</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/Styles.css" rel="stylesheet">
	    <style type="text/css">
            .style6
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 5px;
                }
            .style7
            {
                height: 2px;
                width: 153px;
            }
            .style8
            {
                height: 3px;
                width: 153px;
            }
            .style9
            {
                height: 7px;
                width: 153px;
            }
            .style10
            {
                font: bold 7pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #663333;
                height: 16px;
                width: 153px;
            }
            .style11
            {
                font: bold 7pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #663333;
                height: 15px;
                width: 153px;
            }
            .style12
            {
                font: bold 7pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #663333;
                height: 7px;
                width: 153px;
            }
            .style13
            {
                font: bold 7pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #663333;
                height: 5px;
                width: 153px;
            }
            .style20
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 2px;
                width: 147px;
            }
            .style21
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 3px;
                width: 147px;
            }
            .style22
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 7px;
                width: 147px;
            }
            .style23
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 16px;
                width: 147px;
            }
            .style24
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 15px;
                width: 147px;
            }
            .style25
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 5px;
                width: 147px;
            }
            .style26
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 2px;
                width: 137px;
            }
            .style27
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 3px;
                width: 137px;
            }
            .style28
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 7px;
                width: 137px;
            }
            .style29
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 16px;
                width: 137px;
            }
            .style30
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 15px;
                width: 137px;
            }
            .style31
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 5px;
            }
            .style32
            {
                height: 2px;
                width: 332px;
            }
            .style33
            {
                height: 3px;
                width: 332px;
            }
            .style34
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 7px;
                width: 332px;
            }
            .style35
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 16px;
                width: 332px;
            }
            .style36
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 15px;
                width: 332px;
            }
            .style37
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 5px;
                width: 332px;
            }
        </style>
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="LEFT: 0px; POSITION: absolute; TOP: 0px" tabIndex="23" height="721" cellSpacing="0"
				cellPadding="0" width="753" align="left" border="0">
				<TBODY>
					<TR vAlign="top">
						<TD style="HEIGHT: 85px" vAlign="top" align="center" colSpan="19"><IMG alt="Информационно-аналитическая служба УРЛС УВД" src="/images/head_small.gif" border="0"></TD>
					</TR>
					<TR vAlign="top">
						<TD style="HEIGHT: 15px" vAlign="top" align="center" height="15">
							<P class="Header" align="center">Поисковая система "КАДРЫ"</P>
						</TD>
					</TR>
					<TR vAlign="top">
						<TD tabIndex="0" vAlign="top" align="center">
							<TABLE class="maintext" id="Table1" tabIndex="0" cellSpacing="1" 
                                cellPadding="1" align="center"
								bgColor="bisque" border="0" style="WIDTH: 800px; HEIGHT: 356px">
								<TR>
									<TD class="style26" vAlign="middle" align="right">Фамилия:</TD>
									<TD class="style7"><asp:textbox id="first_name" tabIndex="1" runat="server" 
                                            Font-Size="X-Small" Width="152" ToolTip="Фамилия"
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana"></asp:textbox></TD>
									<TD class="style20" align="right">Подразделение:<br />
                                        <asp:Label ID="podchLabel" runat="server" style="font-size: xx-small" 
                                            Text="подчиненное&amp;nbsp;подразделение:" Visible="False"></asp:Label>
                                        </TD>
									<TD class="style32">
                                        <asp:dropdownlist id=podrList tabIndex=7 runat="server" 
                                            Font-Size="7pt" Width="300px" ForeColor="#C00000" Font-Names="Verdana" 
                                            DataMember="Table" DataTextField="PODRAZDEL" DataValueField="KEY_OF_POD" 
                                            DataSource="<%# podrDataSet %>" AutoPostBack="True" 
                                            onselectedindexchanged="podrList_SelectedIndexChanged"></asp:dropdownlist>
                                        &nbsp<asp:Button ID="Button1" runat="server" Height="16px" Text="'''" 
                                            ToolTip="Загрузить список упраздненных подразделений..." 
                                            BackColor="#66CCFF" Font-Bold="True" onclick="Button1_Click" 
                                            Visible="False" />
                                        <br />
                                        <asp:dropdownlist id="podchList" tabIndex="7" runat="server" Font-Size="7pt" 
                                            Width="300px" ForeColor="#C00000" Font-Names="Verdana" Visible="False" 
                                            DataSourceID="podchDataSource" DataTextField="NAIMENOVAN" 
                                            DataValueField="KEY_OF_NAI"></asp:dropdownlist>
                                        <asp:SqlDataSource ID="podchDataSource" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                                            SelectCommand="SELECT [NAIMENOVAN], [KEY_OF_NAI] FROM [NAIMEN]">
                                        </asp:SqlDataSource>
                                    </TD>
								</TR>
								<TR>
									<TD class="style26" align="right" height="2">Имя:						
                                    <TD class="style7"><asp:textbox id="name" tabIndex="2" runat="server" Font-Size="X-Small" Width="152" ToolTip="Имя"
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana"></asp:textbox></TD>
									<TD class="style20" align="right" height="2"><A href="..//sluzhelp.htm"><IMG id="IMG1" alt="Информация об объединении некоторых служб при выполнении запросов..."
												src="..//images/btn_help.gif" border="0"></A>&nbsp;Служба:</TD>
									<TD height="2" class="style32"><asp:dropdownlist id=sluzList tabIndex=8 
                                            runat="server" Font-Size="7pt" Width="300px" ForeColor="#C00000" 
                                            Font-Names="Verdana" DataMember="Table" DataTextField="NAM_OF_SLU" 
                                            DataValueField="KEY_OF_SLU" DataSource="<%# sluzDataSet %>"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="style27" align="right" height="3">Отчество:</TD>
									<TD height="3" class="style8"><asp:textbox id="last_name" tabIndex="3" runat="server" Font-Size="X-Small" Width="152" ToolTip="Отчество"
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana"></asp:textbox></TD>
									<TD class="style21" align="right" height="3">Категория 
										должностей:</TD>
									<TD height="3" class="style33"><asp:dropdownlist id="dolzList" tabIndex="9" 
                                            runat="server" Font-Size="7pt" Width="300px" ForeColor="#C00000"
											Font-Names="Verdana">
											<asp:ListItem Value="0" Selected="True">Любые должности</asp:ListItem>
											<asp:ListItem Value="-1">Только аттестованные</asp:ListItem>
											<asp:ListItem Value="1">Руководство (от нач.отделения и выше)</asp:ListItem>
											<asp:ListItem Value="2">Старший и средний нач.состав</asp:ListItem>
											<asp:ListItem Value="3">Младший нач.состав</asp:ListItem>
											<asp:ListItem Value="4">Работники, служащие</asp:ListItem>
										    <asp:ListItem Value="5">Федеральные гражданские государственные служащие</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="style28" align="right" height="7">Личный 
										номер(а):</TD>
									<TD height="7" class="style9"><asp:textbox id="num_1" tabIndex="4" runat="server" Font-Size="X-Small" Width="32" ToolTip="Симольная часть личного номера"
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana"></asp:textbox>&nbsp;-&nbsp;<asp:textbox 
                                            id="num_2" tabIndex="3" runat="server" Font-Size="X-Small" 
                                            Width="103px" ToolTip="числовая часть личного номера"
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana" Height="22px"></asp:textbox>
                                        <br />&nbsp;&nbsp;&nbsp;&nbsp;по&nbsp;&nbsp;&nbsp;<asp:textbox id="num_3" 
                                            tabIndex="3" runat="server" Font-Size="X-Small" 
                                            Width="100px" ToolTip="поиск по диапазону номеров..."
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana" Height="22px"></asp:textbox></TD>
									<TD class="style22" align="right" height="7">Должность:</TD>
									<TD class="style34" height="7"><asp:dropdownlist id=DolzList2 tabIndex=9 
                                            runat="server" Font-Size="7pt" Width="300px" ForeColor="#C00000" 
                                            Font-Names="Verdana" DataTextField="NAM_OF_DOL" DataValueField="P3" 
                                            DataSource="<%# dolzDataSet %>">
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="style29" align="right" height="16">№ 
										личного дела:</TD>
									<TD class="style10" vAlign="middle" align="left" height="16">
                                        <asp:textbox id="file_num" runat="server" Font-Size="X-Small" Width="70px" ForeColor="#C00000"
											Font-Bold="True" Font-Names="Verdana" ToolTip="№ личного дела"></asp:textbox></TD>
									<TD class="style23" align="right" height="16">Национальность:</TD>
									<TD class="style35" align="left" height="16"><asp:dropdownlist id=nacList 
                                            tabIndex=10 runat="server" Font-Size="7pt" Width="300px" ForeColor="#C00000" 
                                            Font-Names="Verdana" DataMember="Table" DataTextField="NACION" 
                                            DataValueField="KEY_OF_NAC" DataSource="<%# nationDataSet %>">
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="style30" align="right" height="15">Дата 
										рождения:</TD>
									<TD class="style11" vAlign="middle" align="left" height="15"><asp:dropdownlist id="rznakList" runat="server" Width="50" ForeColor="#0000C0" Font-Bold="True" Font-Names="Verdana">
											<asp:ListItem Value="0" Selected="True">любая</asp:ListItem>
											<asp:ListItem Value="=">=</asp:ListItem>
											<asp:ListItem Value="&gt;">&gt;</asp:ListItem>
											<asp:ListItem Value="&lt;">&lt;</asp:ListItem>
											<asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
											<asp:ListItem Value="&lt;=">&lt;=</asp:ListItem>
											<asp:ListItem Value="&lt;&gt;">&lt;&gt;</asp:ListItem>
										</asp:dropdownlist><ew:maskedtextbox id="DateBorn" runat="server" 
                                            Font-Size="X-Small" Width="100px" ForeColor="#0000C0"
											Font-Bold="True" Font-Names="Verdana" EnableViewState="False" Mask="99.99.9999" 
                                            ToolTip="Дата рождения (ДД.ММ.ГГГГ)"></ew:maskedtextbox></TD>
									<TD class="style24" align="right" height="15">Специальное 
										звание:</TD>
									<TD class="style36" align="left" height="15"><asp:dropdownlist id=zvanList 
                                            tabIndex=10 runat="server" Font-Size="7pt" Width="300px" ForeColor="#C00000" 
                                            Font-Names="Verdana" DataMember="Table" DataTextField="VOIN_ZVAN" 
                                            DataValueField="KEY_ZVAN" DataSource="<%# zvanDataSet %>">
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="style28" align="right" height="7">
										<asp:Label id="SLabel" runat="server">Дата увольнения (откомандирования)</asp:Label></TD>
									<TD class="style12" vAlign="middle" align="left" height="7">
										<asp:dropdownlist id="sznakList" runat="server" Font-Names="Verdana" Font-Bold="True" ForeColor="#0000C0"
											Width="50">
											<asp:ListItem Value="0" Selected="True">любая</asp:ListItem>
											<asp:ListItem Value="=">=</asp:ListItem>
											<asp:ListItem Value="&gt;">&gt;</asp:ListItem>
											<asp:ListItem Value="&lt;">&lt;</asp:ListItem>
											<asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
											<asp:ListItem Value="&lt;=">&lt;=</asp:ListItem>
											<asp:ListItem Value="&lt;&gt;">&lt;&gt;</asp:ListItem>
										</asp:dropdownlist>
										<ew:maskedtextbox id="SDate" runat="server" Font-Names="Verdana" 
                                            Font-Bold="True" ForeColor="#0000C0"
											Width="100px" Font-Size="X-Small" Mask="99.99.9999" EnableViewState="False" 
                                            ToolTip="Дата увольнения (откомандирования)"></ew:maskedtextbox></TD>
									<TD class="style22" align="right" height="7">Уровень 
										образования:</TD>
									<TD class="style34" align="left" height="7"><asp:dropdownlist id="Obraz_List" 
                                            tabIndex="10" runat="server" Font-Size="7pt" Width="300px" ForeColor="#C00000"
											Font-Names="Verdana" DataMember="Table">
											<asp:ListItem Value="0">Не имеет значения</asp:ListItem>
											<asp:ListItem Value="10">Высшее</asp:ListItem>
											<asp:ListItem Value="20">Среднее-специальное</asp:ListItem>
											<asp:ListItem Value="30">Среднее</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="style31" align="right" height="5">В 
                                        должности с:</TD>
									<TD class="style13" vAlign="middle" align="left" height="5">
										<asp:dropdownlist id="vdznakList" runat="server" Font-Names="Verdana" 
                                            Font-Bold="True" ForeColor="#0000C0"
											Width="50">
											<asp:ListItem Value="0" Selected="True">любая</asp:ListItem>
											<asp:ListItem Value="=">=</asp:ListItem>
											<asp:ListItem Value="&gt;">&gt;</asp:ListItem>
											<asp:ListItem Value="&lt;">&lt;</asp:ListItem>
											<asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
											<asp:ListItem Value="&lt;=">&lt;=</asp:ListItem>
											<asp:ListItem Value="&lt;&gt;">&lt;&gt;</asp:ListItem>
										</asp:dropdownlist>
										<ew:maskedtextbox id="VDDate" runat="server" Font-Names="Verdana" 
                                            Font-Bold="True" ForeColor="#0000C0"
											Width="100px" Font-Size="X-Small" Mask="99.99.9999" EnableViewState="False" 
                                            ToolTip="Дата назначения на должность"></ew:maskedtextbox></TD>
									<TD class="style25" align="right" height="5">Тип 
										образования:</TD>
									<TD class="style37" align="left" height="5"><asp:dropdownlist id="Type_obr_list" 
                                            tabIndex="10" runat="server" Font-Size="7pt" Width="300px" ForeColor="#C00000"
											Font-Names="Verdana" DataMember="Table">
											<asp:ListItem Value="0">Не имеет значения</asp:ListItem>
											<asp:ListItem Value="Юридическое">Юридическое</asp:ListItem>
											<asp:ListItem Value="Экономическое">Экономическое</asp:ListItem>
											<asp:ListItem Value="Техническое">Техническое</asp:ListItem>
											<asp:ListItem Value="Медицинское">Медицинское</asp:ListItem>
											<asp:ListItem Value="Педагогическое">Педагогическое</asp:ListItem>
											<asp:ListItem Value="Военное">Военное</asp:ListItem>
											<asp:ListItem Value="Пожарное">Пожарное</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="style31" align="right" height="5"></TD>
									<TD class="style13" vAlign="middle" align="left" height="5">
										<asp:DropDownList ID="istList" runat="server" DataSourceID="istDataSource" 
                                            DataTextField="TEXT" DataValueField="CODE" Width="152px" Visible="False">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="istDataSource" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                                            SelectCommand="SELECT [TEXT], [CODE] FROM [SLVISOD]"></asp:SqlDataSource>
                                    </TD>
									<TD class="style6" align="right" height="5" colspan="2">
                                        &nbsp;</TD>
								</TR>
								<TR>
									<TD class="style31" align="left" height="5" colspan="4">
										<asp:CheckBox ID="CheckDecret" runat="server" 
                                            Text="Находится в отпуске по уходу за ребенком" />
                                    </TD>
								</TR>
								<TR>
									<TD class="style31" align="left" height="5" colspan="4">
                                        <asp:CheckBox ID="prizCheckBox" runat="server" 
                                            Text="Призывники (не служившие в ВС до 27 лет)" />
                                    </TD>
								</TR>
								<TR>
									<TD class="style31" align="right" height="5" colspan="4">&nbsp;</TD>
								</TR>
								<TR align="center">
									<TD class="maintext" style="HEIGHT: 5px" vAlign="bottom" align="center" 
                                        colSpan="4" height="5">Сортировать результаты по: <asp:DropDownList ID="orderList" 
                                            runat="server" Height="16px" 
                                            ToolTip="Параметры сортировки" Width="215px" Font-Names="Verdana" 
                                            Font-Size="7pt" ForeColor="#C00000">
                                            <asp:ListItem Selected="True" Value="0">Фамилии, имени, отчеству</asp:ListItem>
                                            <asp:ListItem Value="1">Дате рождения</asp:ListItem>
                                            <asp:ListItem Value="2">Подразделению</asp:ListItem>
                                            <asp:ListItem Value="3">Службе</asp:ListItem>
                                            <asp:ListItem Value="4">Должности</asp:ListItem>
                                            <asp:ListItem Value="5">Званию</asp:ListItem>
                                            <asp:ListItem Value="6">Личному номеру</asp:ListItem>
                                        </asp:DropDownList>
                                    </TD>
								</TR>
								<TR>
									<TD class="maintext" vAlign="middle" align="center" colSpan="4" style="HEIGHT: 1px">
										<P><FONT size="1">категория сотрудников:</FONT>
											<asp:radiobutton class="label" id="RadioButton1" tabIndex="12" runat="server" Width="140px" ToolTip="Работающие по настоящее время"
												Checked="True" GroupName="TypeSearch" Text="- действующие" CssClass="label" AutoPostBack="True"></asp:radiobutton><asp:radiobutton class="maintext" id="RadioButton2" tabIndex="13" runat="server" Width="140px" ToolTip="Уволенные..."
												GroupName="TypeSearch" Text="- архив" CssClass="label" AutoPostBack="True"></asp:radiobutton><asp:radiobutton class="maintext" id="RadioButton3" tabIndex="14" runat="server" Width="140px" ToolTip="Находящиеся за штатом (или в декрете)"
												GroupName="TypeSearch" Text="- резерв" CssClass="label" AutoPostBack="True"></asp:radiobutton><asp:radiobutton id="RadioButton4" tabIndex="15" runat="server" Width="140px" ToolTip="Откомандированные в другие области или ведомства"
												GroupName="TypeSearch" Text="- откомандированные" CssClass="label" AutoPostBack="True"></asp:radiobutton></P>
									</TD>
								</TR>
								<TR>
									<TD class="maintext" align="center" colSpan="4"><asp:imagebutton id="GoBtn" 
                                            runat="server" ToolTip="искать" ImageUrl="../images/iskat.gif" alt=" Поиск "
											AlternateText="Искать..." onclick="GoBtn_Click1"></asp:imagebutton></TD>
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
									<TD class="maintext" vAlign="bottom" align="left" colSpan="4" height="14">
										<P><asp:label id="FindLabel" runat="server" Font-Size="XX-Small" Width="728px" ForeColor="Black"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD vAlign="bottom" align="left" colSpan="4" height="14"><asp:imagebutton id="Photos_view" runat="server" ImageUrl="..//images/btn_get_photos.gif" Visible="False"
											AlternateText="фотографии..."></asp:imagebutton>
                                        <asp:SqlDataSource ID="uvDataSource" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:IASConnectionString %>" 
                                            ProviderName="<%$ ConnectionStrings:IASConnectionString.ProviderName %>" 
                                            SelectCommand="SELECT date_notification_print, date_notification_give FROM Notification WHERE id = @key">
                                        </asp:SqlDataSource>
                                    </TD>
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
										<asp:BoundColumn DataField="TEXT" SortExpression="TEXT" HeaderText="Ист.фин.">
											<HeaderStyle Width="6%"></HeaderStyle>
											<ItemStyle Font-Size="XX-Small" HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="nomlichdel" SortExpression="nomlichdel" HeaderText="№ л/д">
											<HeaderStyle Width="10%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:HyperLinkColumn Text="&gt;" HeaderImageUrl="../images/object.gif" Target="_blank" DataNavigateUrlField="KEY_1"
											DataNavigateUrlFormatString="../AddService.aspx?id={0}" SortExpression="FAMILIYA">
											<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:HyperLinkColumn>
									    
                                        
									</Columns>
									<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
								</asp:datagrid></P>
							<P tabIndex="16">
                                <asp:ImageButton ID="ExcelCopyButton" runat="server" 
                                    ImageUrl="..\images\btn_excel.gif" onclick="ExcelCopyButton_Click" 
                                    Visible="False" />
&nbsp;<asp:ImageButton ID="WordCopyButton" runat="server" ImageUrl="..\images\btn_word.gif" 
                                    onclick="WordCopyButton_Click" Visible="False" />
                            </P>
                            <P tabIndex="16">
                                <asp:Button ID="ObjButton" runat="server" onclick="ObjButton_Click" 
                                    Text="справки-объективки на всех найденных..." Visible="False" />
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
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
