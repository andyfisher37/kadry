<%@ Page language="c#" Codebehind="vakansy.aspx.cs" AutoEventWireup="True" Inherits="kadry.Vakansy" codePage="65001"%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - вакансии</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	    <style type="text/css">
            .style2
            {
                font-size: 9px;
                page-break-before: auto;
                word-spacing: normal;
                page-break-after: auto;
                color: #0000CC;
                text-indent: 0%;
                font-family: Verdana, Helvetica, sans-serif;
                white-space: normal;
                height: 27px;
                text-align: center;
            }
            .style3
            {
                font-weight: bold;
                text-decoration: underline;
            }
            .style5
            {
                height: 149px;
            }
            .style6
            {
                height: 367px;
            }
            .style7
            {
                height: 23px;
            }
            .style8
            {
                height: 2px;
            }
            .style9
            {
                width: 63px;
            }
            .style10
            {
                width: 276px;
            }
        </style>
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" MARGINWIDTH="0"
		MARGINHEIGHT="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 800px; HEIGHT: 600px" cellSpacing="0" cellPadding="0" width="759"
				align="left" border="0" VSPACE="0" HSPACE="0">
				<TR>
					<TD style="HEIGHT: 49px" align="center" height="49"><IMG alt="" src="/images/header_small.gif" width="750" border="0"></TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 4px" align="center" height="4">СПИСКИ ВАКАНСИЙ</TD>
                                    <asp:SqlDataSource ID="odbcDataSource" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                                        SelectCommand="SELECT VOIN_ZVAN, KEY_ZVAN FROM ZVANIE.DBF WHERE KEY_ZVAN BETWEEN 1 AND 15 ORDER BY KEY_ZVAN">
                                    </asp:SqlDataSource>
				</TR>
				<TR>
					<TD vAlign="top" align="center" class="style6">
						<TABLE class="maintext" id="Table1" style="WIDTH: 730px; height: 298px;" cellSpacing="1"
							cellPadding="1" bgColor="#D1D1D1" border="0" align="center">
							<TR>
								<TD align="left" class="style2" colspan="3">*Информация по вакантным должностям 
                                    может изменяться <span class="style3">ежедневно</span>, о действительном наличии 
                                    вакансии необходимо уточнять в кадровых подразделениях!</TD>
							</TR>
							<TR>
								<TD align="right" CssClass="maintext" class="style10">Подразделение:</TD>
								<TD colspan="2"><asp:dropdownlist id=podrList runat="server" Width="400px" Font-Bold="True" 
                                        ForeColor="#C00000" Font-Names="Verdana" DataSource="<%# podrDataSet %>" 
                                        DataTextField="PODRAZDEL" DataValueField="KEY_OF_POD" DataMember="Table" 
                                        CssClass="label2">
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD align="right" CssClass="maintext" class="style10">Служба:</TD>
								<TD colspan="2" ><asp:dropdownlist id=sluzList runat="server" Width="400px" Font-Bold="True" 
                                        ForeColor="#C00000" Font-Names="Verdana" DataSource="<%# sluzDataSet %>" 
                                        DataTextField="NAM_OF_SLU" DataValueField="KEY_OF_SLU" DataMember="Table" 
                                        CssClass="label2">
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD align="right" CssClass="maintext" class="style10">Должности:</TD>
								<TD colspan="2"><asp:dropdownlist id="dolzList" runat="server" Width="400px" Font-Bold="True" ForeColor="#C00000"
										Font-Names="Verdana" CssClass="label2">
										<asp:ListItem Value="0" Selected="True">Все должности (атт.+вольн.)</asp:ListItem>
										<asp:ListItem Value="5">Только аттестованные</asp:ListItem>
										<asp:ListItem Value="1">Руководство (от нач.отделения)</asp:ListItem>
										<asp:ListItem Value="2">Старший и средний нач.состав</asp:ListItem>
										<asp:ListItem Value="3">Младший нач.состав</asp:ListItem>
										<asp:ListItem Value="4">Работники</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD align="right" CssClass="maintext" class="style10">Источник финансирования:</TD>
								<TD style="HEIGHT: 18px" colspan="2"><asp:dropdownlist id=istList runat="server" Width="300px" 
                                        Font-Bold="True" ForeColor="#C00000" Font-Names="Verdana" 
                                        DataSource="<%# istDataSet %>" DataTextField="TEXT" DataValueField="CODE" 
                                        DataMember="Table" CssClass="label2">
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD align="right" CssClass="maintext" class="style10">Группа предназначения: &nbsp;</TD>
								<TD style="HEIGHT: 18px" colspan="2"><asp:dropdownlist id="grupList" runat="server" 
                                        Width="300px" Font-Bold="True" ForeColor="#C00000"
										Font-Names="Verdana" CssClass="label2">
										<asp:ListItem Value="0">Не имеет значения (все группы)</asp:ListItem>
										<asp:ListItem Value="2">2, 3, 4 группа</asp:ListItem>
										<asp:ListItem Value="3">3 и 4 группа</asp:ListItem>
										<asp:ListItem Value="4">только 4 группа</asp:ListItem>
									</asp:dropdownlist>&nbsp;<A href="..//vvkhelp.htm"><IMG alt="" 
                                        src="..//images/btn_help.gif" border="0" height="15" width="15"></A></TD>
							</TR>
							<TR>
								<TD align="right" CssClass="maintext" class="style10">Категория должностей:</TD>
								<TD style="HEIGHT: 18px" colspan="2">
									<asp:DropDownList ID="inPoliceList" runat="server" Font-Bold="True" 
                                        Font-Names="Verdana" ForeColor="#C00000" Width="292px" CssClass="label2">
                                        <asp:ListItem Selected="True" Value="0">Не имеет значения</asp:ListItem>
                                        <asp:ListItem Value="1">Полиция</asp:ListItem>
                                        <asp:ListItem Value="2">Иные органы внутренних дел</asp:ListItem>
                                    </asp:DropDownList>
                                </TD>
							</TR>
							<TR>
								<TD align="right" CssClass="maintext" class="style10">Предельное звание :</TD>
								<TD style="HEIGHT: 18px" colspan="2">
									<asp:DropDownList id="cList" runat="server" Font-Bold="True" 
                                        Font-Names="Verdana" ForeColor="#C00000" CssClass="label2">
										<asp:ListItem Value="0">только</asp:ListItem>
										<asp:ListItem Value="1">от</asp:ListItem>
										<asp:ListItem Value="2">до</asp:ListItem>
									</asp:DropDownList>
									<asp:DropDownList ID="zvanList" runat="server" Width="220px" DataTextField="VOIN_ZVAN" 
                                        DataValueField="KEY_ZVAN" DataSourceID="odbcDataSource" Font-Bold="True" 
                                        Font-Names="Verdana" ForeColor="#C00000" CssClass="label2">
                                    </asp:DropDownList>
                                </TD>
							</TR>
							<TR>
								<TD align="right" CssClass="maintext" class="style10">Отбор вакансий по дате:</TD>
								<TD class="style9" >
									<asp:DropDownList ID="dZnak" runat="server" Width="150px" CssClass="label2">
                                        <asp:ListItem Selected="True" Value="0">не имеет значения</asp:ListItem>
                                        <asp:ListItem Value="1">&gt;=</asp:ListItem>
                                        <asp:ListItem Value="2">&lt;=</asp:ListItem>
                                    </asp:DropDownList>
                                </TD>
								<TD >
                                    &nbsp;</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5px" align="center" colSpan="3">
									<HR width="100%" SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD align="left" colSpan="3">
                                    <asp:checkbox id="Check1" runat="server" Width="420px" 
                                        CssClass="label2" Text='Отображать "вилку" оклада по должности' 
                                        Visible="False"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD align="left" colSpan="3">
                                    <asp:checkbox id="Check2" runat="server" Width="420px" 
                                        CssClass="label2" Text="Отображать потолок по званию" Visible="False"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD align="left" colSpan="3">
									<asp:checkbox id="Check3" runat="server" Width="420px" Text="Группировать одинаковые должности"
										CssClass="label2" Visible="False"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 27px" align="center" colSpan="3"><P><asp:imagebutton id="ImageButton1" runat="server" AlternateText="список вакансий по должностям" ImageUrl="/images/btn_vakansy.gif" onclick="ImageButton1_Click"></asp:imagebutton></P>
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 24px" align="center" colSpan="3" valign="middle"><P>
                                    <asp:imagebutton id="ImageButton2" runat="server" 
                                        AlternateText="сводная таблица вакансий" ImageUrl="/images/btn_vakansy2.gif" 
                                        onclick="ImageButton2_Click" Visible="False"></asp:imagebutton></P>
								</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3">
									<P><asp:imagebutton id="ImageButton3" runat="server" AlternateText="подбор вакансии для кандидата" ImageUrl="/images/btn_vakansy3.gif"
											Visible="False" onclick="ImageButton3_Click"></asp:imagebutton></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 199px" colSpan="3">
                                    <asp:label id="L_info" runat="server" 
                                        Width="694px" CssClass="label2" Height="16px"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" class="style8">
						<asp:label id="TitleGrid" runat="server" CssClass="label2"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" class="style7">
                                <asp:ImageButton ID="ExcelCopyButton" runat="server" 
                                    ImageUrl="..\images\btn_excel.gif" onclick="ExcelCopyButton_Click" 
                                    Visible="False" />
&nbsp;&nbsp; <asp:ImageButton ID="WordCopyButton" runat="server" ImageUrl="..\images\btn_word.gif" 
                                    onclick="WordCopyButton_Click" Visible="False" />
					</TD>
				</TR>
				<TR vAlign="middle" align="left">
					<TD vAlign="top" noWrap align="center" height="27"><IMG height="33" alt="Панель быстрых переходов..." src="../images/bottom.gif" 
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
