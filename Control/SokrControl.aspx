<%@ Page language="c#" Codebehind="SokrControl.aspx.cs" AutoEventWireup="True" Inherits="kadry.Control.sokr_control" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - контроль сокращенных 
			должностей...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	    <style type="text/css">
            .style1
            {
                width: 15px;
                height: 36px;
            }
            .style2
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                width: 465px;
                height: 36px;
            }
            .style3
            {}
            .style4
            {
                width: 15px;
                height: 37px;
            }
            .style5
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                width: 465px;
                height: 37px;
            }
            .style7
            {
                height: 40px;
            }
            .style8
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                width: 465px;
                height: 40px;
            }
            .style11
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 27px;
                width: 465px;
            }
        </style>
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#cc66ff" aLink="#0066ff" link="#0000ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 759px; HEIGHT: 590px" height="590" cellSpacing="0" cellPadding="0"
				width="759" align="left" border="0">
				<TR>
					<TD style="HEIGHT: 70px" align="center"><IMG alt="" src="/images/header_small.gif" width="750" useMap="#Map2" border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP></TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 3px" vAlign="top" align="center" height="3">
						<P>
							КОНТРОЛЬ СОКРАЩЕННЫХ 
                            СОТРУДНИКОВ</P>
					</TD>
				</TR>
				<TR>
					<TD class="maintext" style="HEIGHT: 355px" vAlign="top" align="center">
						<P>&nbsp;
							<TABLE id="Table1" style="WIDTH: 744px; HEIGHT: 168px" cellSpacing="0" 
                                cellPadding="0" bgColor="#D1D1D1" border="0">
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 27px" vAlign="middle" align="left"></TD>
									<TD class="style11" vAlign="middle" align="left"><STRONG><FONT color="#ff0000">1.</FONT></STRONG>
										Список&nbsp;сотрудников (работников), сокращенных в результате организационно-штатных 
                                        мероприятий:</TD>
									<TD style="HEIGHT: 27px" vAlign="middle" align="center"><asp:imagebutton id="Button1" runat="server" ImageUrl="../images/btn_sp.gif" onclick="Button1_Click"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 12px" vAlign="middle" align="center"
										colSpan="3">
										<HR style="WIDTH: 737px; " SIZE="1">
									</TD>
								</TR>
								<TR>
									<TD align="center" class="style1"></TD>
									<TD class="style2" align="left">Сортировка 
										результатов по:
										<asp:DropDownList class="label2" id="SortList" runat="server" CssClass="label2" 
                                            Width="460px" AutoPostBack="True" 
                                            onselectedindexchanged="SortList_SelectedIndexChanged">
											<asp:ListItem Value="0">Ф.И.О.</asp:ListItem>
											<asp:ListItem Value="1">Подразделению</asp:ListItem>
											<asp:ListItem Value="2">Должности</asp:ListItem>
											<asp:ListItem Value="3">Дате сокращения</asp:ListItem>
											<asp:ListItem Value="4">Источнику финансирования</asp:ListItem>
										</asp:DropDownList></TD>
									<TD align="center" class="style3" rowspan="3">
                                        &nbsp;</TD>
								</TR>
								<TR>
									<TD align="center" class="style4"></TD>
									<TD class="style5" align="left">Категория 
                                        должностей:<asp:DropDownList ID="DolzList" runat="server" CssClass="label2" 
                                            Width="460px" Height="16px">
                                            <asp:ListItem Selected="True" Value="0">Все (аттестованные + вольнонаемные)</asp:ListItem>
                                            <asp:ListItem Value="1">Только аттестованные</asp:ListItem>
                                            <asp:ListItem Value="2">Старший и средний начсостав</asp:ListItem>
                                            <asp:ListItem Value="3">Младший и рядовой начсостав</asp:ListItem>
                                            <asp:ListItem Value="4">Только вольнонаемные</asp:ListItem>
                                        </asp:DropDownList>
                                    </TD>
								</TR>
								<TR>
									<TD align="center" class="style7"></TD>
									<TD class="style8" align="left">Служба:<br />
                                        <asp:DropDownList ID="sluzList" runat="server" Height="16px" Width="460px" 
                                            CssClass="label2" DataTextField="NAM_OF_SLU" DataValueField="KEY_OF_SLU">
                                        </asp:DropDownList>
                                    </TD>
								</TR>
								
								<TR>
									<TD align="center" class="maintext" colspan="3">&nbsp;</TD>
								</TR>
								
								<TR>
									<TD style="WIDTH: 15px; HEIGHT: 7px" align="center" colSpan="3">
										<asp:label id="FindLabel" runat="server" Width="731px" CssClass="label"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15px; HEIGHT: 7px" align="left" colSpan="3"></TD>
								</TR>
							</TABLE>
						</P>
						<asp:datagrid id=Grid runat="server" Width="640px" BackColor="White" 
                            CellPadding="2" BorderWidth="1px" BorderColor="Black" 
                            AutoGenerateColumns="False" DataMember="Table" 
                            DataSource="<%# sokrDataSet %>" >
							<ItemStyle Font-Size="10px" Font-Names="Verdana"></ItemStyle>
							<HeaderStyle Font-Size="11px" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
								ForeColor="#660000" BackColor="AntiqueWhite"></HeaderStyle>
							<Columns>
								<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="KEY_1" DataNavigateUrlFormatString="..//DetailPage.aspx?id={0}"
									DataTextField="FAMILIYA" HeaderText="Фамилия">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="IMYA" SortExpression="IMYA" HeaderText="Имя">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OTCHECTVO" SortExpression="OTCHECTVO" HeaderText="Отчество">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATA_ROZD" SortExpression="DATA_ROZD" 
                                    HeaderText="Дата рождения" DataFormatString="{0:d}">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Образование">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="VOIN_ZVAN" SortExpression="VOIN_ZVAN" HeaderText="Звание">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Подразделение">
									<HeaderStyle Width="30%"></HeaderStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Должность">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Инф.о сокращении"></asp:TemplateColumn>
							</Columns>
							<PagerStyle Position="Top"></PagerStyle>
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
                                 <AREA title="Качественные показатели" shape="RECT" alt="Качественные показатели" coords="575,0,650,33"	href="../Kachestv/kachestv.aspx">
                                 <AREA title="Дисциплинарная практика" shape="RECT" alt="Дисциплинарная практика" coords="700,0,775,33"	href="../Discipline/discipline.aspx">
                                 </MAP></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
