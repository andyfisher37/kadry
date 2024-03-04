<%@ Page language="c#" Codebehind="search.aspx.cs" AutoEventWireup="false" Inherits="kadry.search" codePage="65001"   enableViewState="True"%>
<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>

	<head>
		<title>Информационная система обработки данных "Кадры" - поиск...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<link href="../Styles.css" rel="stylesheet"/>
   	    <style type="text/css">
            .style1
            {
                width: 155px;
            }
            .style2
            {
                width: 207px;
            }
        </style>
   	</head>

	<body text="#000000" bottommargin="0" vlink="#ff66ff" alink="#66ffff" 
        link="#3333ff" bgproperties="fixed"
		bgcolor="#ffffff" leftmargin="0" background="/images/background.gif" topmargin="0"
		rightmargin="0" ms_positioning="GridLayout" class="maintext">
		<form id="Form1" method="post" runat="server">

			<table style="LEFT: 0px; POSITION: absolute; TOP: 0px" tabindex="23" height="721" cellspacing="0"
				cellpadding="0" width="800" align="left" border="0">
				<tbody>
					<tr valign="top">
						<td style="HEIGHT: 85px" valign="top" align="center" colspan="19">
                            <img alt="Информационная система обработки данных "Кадры"" 
                                src="/images/header_small.gif" border="0"/></td>
					</tr>
					<tr valign="top">
						<td style="HEIGHT: 15px" valign="top" align="center" height="15">
							<p class="Header" align="center">ПоискОВАЯ СИСТЕМА</p>
						</td>
					</tr>
					<tr valign="top">
						<td tabindex="0" valign="top" align="center">
							<table class="maintext" id="Table1" tabindex="0" cellspacing="1" 
                                cellpadding="1" align="center"
								bgcolor="#D1D1D1" border="0" style="WIDTH: 860px; HEIGHT: 356px">
								<tr>
									<td valign="middle" align="right" class="style1">Фамилия:</td>
									<td class="style2" >
                                        <asp:textbox id="first_name" tabindex="1" runat="server" 
                                            Font-Size="X-Small" Width="177px" ToolTip="Фамилия"
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana"></asp:textbox></td>
									<td align="right">Подразделение:<br />
                                        
                                        </td>
									<td>
                                        <asp:dropdownlist id="podrList" tabindex="7" runat="server" 
                                            Font-Size="7pt" Width="300px" ForeColor="#C00000" Font-Names="Verdana" 
                                            DataMember="Table" DataTextField="PODRAZDEL" DataValueField="KEY_OF_POD" 
                                            DataSource="<%# podrDataSet %>" AutoPostBack="True">
                                            </asp:dropdownlist>
                                        
                                    </td>
								</tr>
								<tr>
									<td align="right" height="2" class="style1">Имя:</td>						
                                    <td class="style2"><asp:textbox id="name" tabindex="2" runat="server" 
                                            Font-Size="X-Small" Width="177px" ToolTip="Имя"
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana"></asp:textbox></td>
									<td align="right" height="2"><a href="..//sluzhelp.htm"><img id="img1" alt="Информация об объединении некоторых служб при выполнении запросов..."
												src="..//images/btn_help.gif" border="0"/></a>&nbsp;Служба:</td>
									<td height="2"><asp:dropdownlist id="sluzList" tabindex="8" 
                                            runat="server" Font-Size="7pt" Width="300px" ForeColor="#C00000" 
                                            Font-Names="Verdana" DataMember="Table" DataTextField="NAM_OF_SLU" 
                                            DataValueField="KEY_OF_SLU" DataSource="<%# sluzDataSet %>"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td align="right" height="3" class="style1">Отчество:</td>
									<td height="3" class="style2" ><asp:textbox id="last_name" tabindex="3" 
                                            runat="server" Font-Size="X-Small" Width="177px" ToolTip="Отчество"
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana"></asp:textbox></td>
									<td align="right" height="3">Категория 
										должностей:</td>
									<td height="3" ><asp:dropdownlist id="dolzList" tabindex="9" 
                                            runat="server" Font-Size="7pt" Width="300px" ForeColor="#C00000"
											Font-Names="Verdana">
											<asp:ListItem Value="0" Selected="True">Любые должности</asp:ListItem>
											<asp:ListItem Value="-1">Только аттестованные</asp:ListItem>
											<asp:ListItem Value="1">Руководство (от нач.отделения и выше)</asp:ListItem>
											<asp:ListItem Value="2">Старший и средний нач.состав</asp:ListItem>
											<asp:ListItem Value="3">Младший нач.состав</asp:ListItem>
											<asp:ListItem Value="4">Работники, служащие</asp:ListItem>
										    <asp:ListItem Value="5">Федеральные гражданские государственные служащие</asp:ListItem>
										</asp:dropdownlist></td>
								</tr>
								<tr>
									<td align="right" height="7" class="style1">Дата 
										рождения:</td>
									<td height="7" class="style2" ><asp:dropdownlist id="rznakList" runat="server" Width="50" ForeColor="#0000C0" Font-Bold="True" Font-Names="Verdana">
											<asp:ListItem Value="0" Selected="True">любая</asp:ListItem>
											<asp:ListItem Value="=">=</asp:ListItem>
											<asp:ListItem Value="&gt;">&gt;</asp:ListItem>
											<asp:ListItem Value="&lt;">&lt;</asp:ListItem>
											<asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
											<asp:ListItem Value="&lt;=">&lt;=</asp:ListItem>
											<asp:ListItem Value="&lt;&gt;">&lt;&gt;</asp:ListItem>
										</asp:dropdownlist>&nbsp;<ew:maskedtextbox id="DateBorn" runat="server" 
                                            Font-Size="X-Small" Width="100px" ForeColor="#0000C0"
											Font-Bold="True" Font-Names="Verdana" EnableViewState="False" Mask="99.99.9999" 
                                            ToolTip="Дата рождения (ДД.ММ.ГГГГ)"></ew:maskedtextbox></td>
									<td align="right" height="7">Должность:</td>
									<td height="7"><asp:dropdownlist id="DolzList2" tabindex="9" 
                                            runat="server" Font-Size="7pt" Width="300px" ForeColor="#C00000" 
                                            Font-Names="Verdana" DataTextField="NAM_OF_DOL" DataValueField="P3" 
                                            DataSource="<%# dolzDataSet %>">
										</asp:dropdownlist></td>
								</tr>
								<tr>
									<td align="right" height="7" class="style1">Личный 
										номер(а):</td>
									<td height="7" class="style2" ><asp:textbox id="num_1" tabindex="4" runat="server" Font-Size="X-Small" Width="32" ToolTip="Симольная часть личного номера"
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana"></asp:textbox>-<asp:textbox 
                                            id="num_2" tabindex="3" runat="server" Font-Size="X-Small" 
                                            Width="58px" ToolTip="числовая часть личного номера"
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana" Height="22px"></asp:textbox>
                                        по<asp:textbox id="num_3" 
                                            tabindex="3" runat="server" Font-Size="X-Small" 
                                            Width="58px" ToolTip="поиск по диапазону номеров..."
											ForeColor="#C00000" Font-Bold="True" Font-Names="Verdana" Height="22px"></asp:textbox></td>
									<td align="right" height="7">Национальность:</td>
									<td height="7"><asp:dropdownlist id="nacList" 
                                            tabindex="10" runat="server" Font-Size="7pt" Width="300px" ForeColor="#C00000" 
                                            Font-Names="Verdana" DataMember="Table" DataTextField="NACION" 
                                            DataValueField="KEY_OF_NAC" DataSource="<%# nationDataSet %>">
										</asp:dropdownlist></td>
								</tr>
								<tr>
									<td  align="right" height="16" class="style1">№ нагрудного знака (полиции):</td>
									<td  valign="middle" align="left" height="16" class="style2">
                                        <asp:textbox id="file_num0" runat="server" Font-Size="X-Small" Width="177px" ForeColor="#C00000"
											Font-Bold="True" Font-Names="Verdana" ToolTip="№ личного дела"></asp:textbox></td>
									<td  align="right" height="16">Специальное 
										звание:</td>
									<td  align="left" height="16"><asp:dropdownlist id="zvanList" 
                                            tabindex="10" runat="server" Font-Size="7pt" Width="300px" ForeColor="#C00000" 
                                            Font-Names="Verdana" DataMember="Table" DataTextField="VOIN_ZVAN" 
                                            DataValueField="KEY_ZVAN" DataSource="<%# zvanDataSet %>">
										</asp:dropdownlist></td>
								</tr>
								<tr>
									<td  align="right" height="16" class="style1">№ удостоверения:</td>
									<td  valign="middle" align="left" height="16" class="style2">
                                        <asp:textbox id="file_num1" runat="server" Font-Size="X-Small" Width="177px" ForeColor="#C00000"
											Font-Bold="True" Font-Names="Verdana" ToolTip="№ личного дела"></asp:textbox></td>
									<td  align="right" height="16">Уровень 
										образования:</td>
									<td  align="left" height="16"><asp:dropdownlist id="Obraz_List" 
                                            tabindex="10" runat="server" Font-Size="7pt" Width="300px" ForeColor="#C00000"
											Font-Names="Verdana" DataMember="Table">
											<asp:ListItem Value="0">Не имеет значения</asp:ListItem>
											<asp:ListItem Value="10">Высшее</asp:ListItem>
											<asp:ListItem Value="20">Среднее-специальное</asp:ListItem>
											<asp:ListItem Value="30">Среднее</asp:ListItem>
										</asp:dropdownlist></td>
								</tr>
								<tr>
									<td  align="right" height="16" class="style1">№ 
										личного дела:</td>
									<td  valign="middle" align="left" height="16" class="style2">
                                        <asp:textbox id="file_num" runat="server" Font-Size="X-Small" Width="70px" ForeColor="#C00000"
											Font-Bold="True" Font-Names="Verdana" ToolTip="№ личного дела"></asp:textbox></td>
									<td  align="right" height="16">Тип 
										образования:</td>
									<td  align="left" height="16"><asp:dropdownlist id="Type_obr_list" 
                                            tabindex="10" runat="server" Font-Size="7pt" Width="300px" ForeColor="#C00000"
											Font-Names="Verdana" DataMember="Table">
											<asp:ListItem Value="0">Не имеет значения</asp:ListItem>
											<asp:ListItem Value="Юридическое">Юридическое</asp:ListItem>
											<asp:ListItem Value="Экономическое">Экономическое</asp:ListItem>
											<asp:ListItem Value="Техническое">Техническое</asp:ListItem>
											<asp:ListItem Value="Медицинское">Медицинское</asp:ListItem>
											<asp:ListItem Value="Педагогическое">Педагогическое</asp:ListItem>
											<asp:ListItem Value="Военное">Военное</asp:ListItem>
											<asp:ListItem Value="Пожарное">Пожарное</asp:ListItem>
										</asp:dropdownlist></td>
								</tr>
								<tr>
									<td  align="right" height="15" class="style1">№ трудовой книжки:</td>
									<td  valign="middle" align="left" height="15" class="style2">
                                        <asp:textbox id="file_num2" runat="server" Font-Size="X-Small" Width="177px" ForeColor="#C00000"
											Font-Bold="True" Font-Names="Verdana" ToolTip="№ личного дела"></asp:textbox></td>
									<td  align="right" height="15">Окончил УЗ:</td>
									<td  align="left" height="15">
                                        <asp:dropdownlist id="Type_obr_list0" 
                                            tabindex="10" runat="server" Font-Size="7pt" Width="300px" ForeColor="#C00000"
											Font-Names="Verdana" DataMember="Table">
											<asp:ListItem Value="0">Не имеет значения</asp:ListItem>
											<asp:ListItem Value="Юридическое">Юридическое</asp:ListItem>
											<asp:ListItem Value="Экономическое">Экономическое</asp:ListItem>
											<asp:ListItem Value="Техническое">Техническое</asp:ListItem>
											<asp:ListItem Value="Медицинское">Медицинское</asp:ListItem>
											<asp:ListItem Value="Педагогическое">Педагогическое</asp:ListItem>
											<asp:ListItem Value="Военное">Военное</asp:ListItem>
											<asp:ListItem Value="Пожарное">Пожарное</asp:ListItem>
										</asp:dropdownlist></td>
								</tr>
								<tr>
									<td  align="right" height="15" class="style1">№ военного билета:</td>
									<td  valign="middle" align="left" height="15" class="style2">
                                        <asp:textbox id="file_num3" runat="server" Font-Size="X-Small" Width="177px" ForeColor="#C00000"
											Font-Bold="True" Font-Names="Verdana" ToolTip="№ личного дела"></asp:textbox></td>
									<td  align="right" height="15">Год окончания УЗ:</td>
									<td  align="left" height="15">
                                        <asp:textbox id="file_num4" runat="server" Font-Size="X-Small" Width="70px" ForeColor="#C00000"
											Font-Bold="True" Font-Names="Verdana" ToolTip="№ личного дела"></asp:textbox></td>
								</tr>
								<tr>
									<td  align="right" height="15" class="style1">В 
                                        должности с:</td>
									<td  valign="middle" align="left" height="15" class="style2">
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
										</asp:dropdownlist>&nbsp;<ew:maskedtextbox id="VDDate" runat="server" Font-Names="Verdana" 
                                            Font-Bold="True" ForeColor="#0000C0"
											Width="100px" Font-Size="X-Small" Mask="99.99.9999" EnableViewState="False" 
                                            ToolTip="Дата назначения на должность"></ew:maskedtextbox></td>
									<td  align="right" height="15">&nbsp;</td>
									<td  align="left" height="15">
										<asp:CheckBox ID="CheckDecret" runat="server" 
                                            Text="Находится в отпуске по уходу за ребенком" />
                                    </td>
								</tr>
								<tr>
									<td  align="right" height="7" class="style1">
										<asp:Label id="SLabel" runat="server">Дата увольнения (откомандирования)</asp:Label></td>
									<td  valign="middle" align="left" height="7" class="style2">
										<asp:dropdownlist id="sznakList" runat="server" Font-Names="Verdana" Font-Bold="True" ForeColor="#0000C0"
											Width="50">
											<asp:ListItem Value="0" Selected="True">любая</asp:ListItem>
											<asp:ListItem Value="=">=</asp:ListItem>
											<asp:ListItem Value="&gt;">&gt;</asp:ListItem>
											<asp:ListItem Value="&lt;">&lt;</asp:ListItem>
											<asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
											<asp:ListItem Value="&lt;=">&lt;=</asp:ListItem>
											<asp:ListItem Value="&lt;&gt;">&lt;&gt;</asp:ListItem>
										</asp:dropdownlist>&nbsp;<ew:maskedtextbox id="SDate" runat="server" Font-Names="Verdana" 
                                            Font-Bold="True" ForeColor="#0000C0"
											Width="100px" Font-Size="X-Small" Mask="99.99.9999" EnableViewState="False" 
                                            ToolTip="Дата увольнения (откомандирования)"></ew:maskedtextbox></td>
									<td  align="right" height="7">&nbsp;</td>
									<td  align="left" height="7">
                                        <asp:CheckBox ID="prizCheckBox" runat="server" 
                                            Text="Призывники (не служившие в ВС до 27 лет)" />
                                    </td>
								</tr>
								<tr>
									<td align="right" height="5" class="style1">&nbsp;</td>
									<td  valign="middle" align="left" height="5" class="style2">
										&nbsp;</td>
									<td align="right" height="5">&nbsp;</td>
									<td  align="left" height="5">
                                        <asp:CheckBox ID="prizCheckBox0" runat="server" 
                                            Text="Зачислен в резерв кадров" />
                                    </td>
								</tr>
								<tr>
									<td  align="right" height="5" class="style1"></td>
									<td  valign="middle" align="left" height="5" class="style2">
										&nbsp;</td>
									<td  align="right" height="5" colspan="2">
                                        &nbsp;</td>
								</tr>
								<tr>
									<td  align="right" height="5" colspan="4">
										<p align="center"><font size="1">категория сотрудников:</font>
											<asp:radiobutton id="RadioButton1" tabindex="12" runat="server" Width="140px" ToolTip="Работающие по настоящее время"
												Checked="True" GroupName="TypeSearch" Text="- действующие" CssClass="label" AutoPostBack="True"></asp:radiobutton><asp:radiobutton id="RadioButton2" tabindex="13" runat="server" Width="140px" ToolTip="Уволенные..."
												GroupName="TypeSearch" Text="- архив" CssClass="label" AutoPostBack="True"></asp:radiobutton><asp:radiobutton id="RadioButton3" tabindex="14" runat="server" Width="140px" ToolTip="Находящиеся за штатом (или в декрете)"
												GroupName="TypeSearch" Text="- резерв" CssClass="label" AutoPostBack="True"></asp:radiobutton><asp:radiobutton id="RadioButton4" tabindex="15" runat="server" Width="140px" ToolTip="Откомандированные в другие области или ведомства"
												GroupName="TypeSearch" Text="- откомандированные" CssClass="label" AutoPostBack="True"></asp:radiobutton></p>
									</td>
								</tr>
								<tr align="center">
									<td class="maintext" style="HEIGHT: 5px" valign="bottom" align="center" 
                                        colspan="4" height="5">Сортировать результаты по: <asp:DropDownList ID="orderList" 
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
                                    </td>
								</tr>
								<tr>
									<td class="maintext" valign="middle" align="center" colspan="4" style="HEIGHT: 1px">
										&nbsp;</td>
								</tr>
								<tr>
									<td class="maintext" align="center" colspan="4"><asp:imagebutton id="GoBtn" 
                                            runat="server" ToolTip="искать" ImageUrl="../images/iskat.gif"
											AlternateText="Искать..." onclick="GoBtn_Click1"></asp:imagebutton></td>
								</tr>
								<tr>
									<td align="center" colspan="4" height="8" style="HEIGHT: 8px">
										<hr align="center" width="100%" color="#660033" size="2"/>
										<a href="help.htm"><font size="1">[основные правила поиска]</font></a>
									</td>
								</tr>
								<tr>
									<td align="right" colspan="4" height="3"><font face="Verdana" size="1"><asp:hyperlink id="secure_text" runat="server" ToolTip="Подробнее об ограничениях..." ForeColor="Red"></asp:hyperlink></font></td>
								</tr>
								<tr>
									<td class="maintext" valign="bottom" align="left" colspan="4" height="14">
										<p><asp:label id="FindLabel" runat="server" Font-Size="XX-Small" Width="728px" ForeColor="Black"></asp:label></p>
									</td>
								</tr>
								<tr>
									<td valign="bottom" align="center" colspan="4" height="14">
                                        <asp:imagebutton id="Photos_view" runat="server" ImageUrl="..//images/btn_get_photos.gif"
											AlternateText="фотографии..." style="text-align: center"></asp:imagebutton>
                                        <asp:SqlDataSource ID="uvDataSource" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:IASConnectionString %>" 
                                            ProviderName="<%$ ConnectionStrings:IASConnectionString.ProviderName %>" 
                                            SelectCommand="SELECT date_notification_print, date_notification_give FROM Notification WHERE id = @key">
                                        </asp:SqlDataSource>
                                    </td>
								</tr>
							</table>
							<p tabindex="16"><asp:datagrid id="Grid" runat="server" Width="746px" 
                                    ToolTip="Нажми на Фамилию и просмотри служебную карточку сотрудника..." 
                                    Font-Names="Verdana" DataMember="Table" DataSource="<%# mainDataSet %>" 
                                    Height="52px" BorderWidth="1px" BorderColor="Black" HorizontalAlign="Center" 
                                    AutoGenerateColumns="False" BackColor="White">
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
									<pagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></pagerStyle>
								</asp:datagrid></p>
							<p tabindex="16">
                                <asp:ImageButton ID="ExcelCopyButton" runat="server" 
                                    ImageUrl="..\images\btn_excel.gif" onclick="ExcelCopyButton_Click" 
                                    Visible="False" />
&nbsp;<asp:ImageButton ID="WordCopyButton" runat="server" ImageUrl="..\images\btn_word.gif" 
                                    onclick="WordCopyButton_Click" Visible="False" />
                            </p>
                            <p tabindex="16">
                                <asp:Button ID="ObjButton" runat="server" onclick="ObjButton_Click" Visible="False" />
                            </p>
						</td>
					</tr>
					<tr valign="middle" align="left">
						<td valign="top" align="center" colspan="2" height="27"><img height="33" alt="Панель быстрых переходов..." src="../images/bottom.gif" 
								usemap="#Map" border="0"/><map name="Map" id="map">
                                 <area title="На главную..." shape="rect" alt="На главную..." coords="25,0,100,33" href="../index.aspx"/>
                                 <area title="Поиск сотрудников" shape="rect" alt="Поиск сотрудников" coords="150,0,200,33"	href="../Search/search.aspx"/>
                                 <area title="Штатно-должностная книга" shape="rect" alt="Штатно-должностная книга" coords="250,0,325,33"	href="../Structure/orgstr.aspx"/>
                                 <area title="Вакансии" shape="rect" alt="Вакансии" coords="325,0,425,33" href="../Vakans/vakansy.aspx"/>
                                 <area title="Некомплект" shape="rect" alt="Некомплект" coords="475,0,550,33" href="../Nekompl/nekompl.aspx"/>
                                 <area title="Качественные показатели" shape="rect" alt="Качественные показатели" coords="575,0,650,33"	href="../Kachestv/kachestv.aspx"/>
                                 <area title="Дисциплинарная практика" shape="rect" alt="Дисциплинарная практика" coords="700,0,775,33"	href="../Discipline/discipline.aspx"/>
                                 </map></td>
					</tr>
				</tbody>
			</table>
		</form>
	</body>
</html>
