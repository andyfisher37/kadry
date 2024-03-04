<%@ Page language="c#" Codebehind="PersFileControl.aspx.cs" AutoEventWireup="True" Inherits="kadry.Control.pfile_control" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - контроль регистрации личных дел 
			сотрудников номенклатуры УВД</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	    
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
						<P>КОНТРОЛЬ Регистрации личных дел сотрудников номенклатуры&nbsp;НАЧАЛЬНИКА уМвд</P>
					</TD>
				</TR>
				<TR>
					<TD class="maintext" style="HEIGHT: 355px" vAlign="top" align="center">
						<P>&nbsp;
							<TABLE id="Table1" style="WIDTH: 741px; HEIGHT: 171px" cellSpacing="0" 
                                cellPadding="0" bgColor="#D1D1D1" border="0">
								<TR>
									<TD class="style6" vAlign="middle" align="left"></TD>
									<TD class="style10" vAlign="middle" align="left"></TD>
									<TD vAlign="middle" align="center" class="style9"></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 27px" vAlign="middle" align="left">
                                        &nbsp;</TD>
									<TD class="maintext" vAlign="middle" align="left"><STRONG><FONT color="#ff0000">1.</FONT></STRONG> 
                                        Список личных дел аттестованных сотрудников,
                                        находящихся на хранении в УРЛС:</TD>
									<TD style="HEIGHT: 27px" vAlign="middle" align="center">
                                        <asp:imagebutton id="Button3" runat="server" ImageUrl="../images/btn_sp.gif" 
                                            onclick="Button3_Click"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 27px" vAlign="middle" align="left">
                                        &nbsp;</TD>
									<TD class="maintext" vAlign="middle" align="left"><STRONG><FONT color="#ff0000">2.</FONT></STRONG>
                                        Список личных дел вольнонаемных сотрудников,
                                        находящихся на хранении в УРЛС:</TD>
									<TD style="HEIGHT: 27px" vAlign="middle" align="center">
                                        <asp:imagebutton id="Button4" runat="server" ImageUrl="../images/btn_sp.gif" 
                                            onclick="Button4_Click"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="style13" vAlign="middle" align="left"></TD>
									<TD class="maintext" vAlign="middle" align="left"><STRONG><FONT color="#ff0000">3.</FONT></STRONG>
										Список сотрудников номенклатуры начальника УМВД, личные дела которых 
										не зарегестрированы в УРЛС:</TD>
									<TD vAlign="middle" align="center" class="style14"><asp:imagebutton id="Button2" runat="server" ImageUrl="../images/btn_sp.gif" onclick="Button2_Click"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 7px" vAlign="middle" align="left"></TD>
									<TD class="maintext" style="WIDTH: 275px; HEIGHT: 7px" vAlign="middle" align="left"
										colSpan="2">
										&nbsp;</TD>
								</TR>
								<TR>
									<TD align="center" class="style11"></TD>
									<TD align="left" class="style4"><asp:label id="FindLabel" runat="server" Width="368px" CssClass="label"></asp:label></TD>
									<TD class="style12"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15px; HEIGHT: 7px" align="left" colSpan="3"></TD>
								</TR>
							</TABLE>
						</P>
						<asp:datagrid id=Grid runat="server" Width="743px" BackColor="White" CellPadding="2" BorderWidth="1px" BorderColor="Black" AutoGenerateColumns="False" DataMember="Table" DataSource="<%# pfileDataSet %>" >
							<ItemStyle Font-Size="10px" Font-Names="Verdana"></ItemStyle>
							<HeaderStyle Font-Size="11px" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
								ForeColor="#660000" BackColor="AntiqueWhite"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NOMLICHDEL" SortExpression="NOMLICHDEL" HeaderText="№ л/д">
									<HeaderStyle Width="2%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
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
								<asp:BoundColumn DataField="VOIN_ZVAN" SortExpression="VOIN_ZVAN" HeaderText="Звание"></asp:BoundColumn>
								<asp:BoundColumn DataField="PODRAZDEL" SortExpression="PODRAZDEL" HeaderText="Подразделение">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle Font-Size="8px" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NAM_OF_SLU" SortExpression="NAM_OF_SLU" HeaderText="Служба">
									<ItemStyle Font-Size="8px" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NAM_OF_DOL" SortExpression="NAM_OF_DOL" HeaderText="Должность">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle Font-Size="8px" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATA_VDOLZ" SortExpression="DATA_VDOLZ" HeaderText="В должности с..."
									DataFormatString="{0:d}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
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
