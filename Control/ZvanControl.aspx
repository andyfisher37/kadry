<%@ Page language="c#" Codebehind="ZvanControl.aspx.cs" AutoEventWireup="True" Inherits="kadry.Control.zvan_control" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - контроль присвоения званий (для 
			зональных сотрудников)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
					<TD class="Header" style="HEIGHT: 3px" vAlign="top" align="center" height="3">КОНТРОЛЬ 
						ПРИСВОЕНИЯ&nbsp;ЗВАНИЙ</TD>
				</TR>
				<TR>
					<TD class="maintext" style="HEIGHT: 355px" vAlign="top" align="center">
						<P>
							<TABLE id="Table1" style="WIDTH: 692px; HEIGHT: 376px" cellSpacing="0" cellPadding="0"
								width="692" bgColor="#D1D1D1" border="0">
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 18px" vAlign="middle" align="left"></TD>
									<TD class="maintext" style="WIDTH: 574px; HEIGHT: 18px" vAlign="middle" align="left">
                                        Фильтр по 
										подразделениям:</TD>
									<TD style="HEIGHT: 18px" vAlign="middle" align="center"></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 16px" vAlign="middle" align="left"></TD>
									<TD class="maintext" style="WIDTH: 574px; HEIGHT: 16px" vAlign="middle" align="left">
										<asp:DropDownList id="podrList" runat="server" Width="550px" 
                                            DataSource="<%# podrDataSet %>" DataTextField="PODRAZDEL" 
                                            DataValueField="KEY_OF_POD" AutoPostBack="True" CssClass="label2" 
                                            onselectedindexchanged="podrList_SelectedIndexChanged">
										</asp:DropDownList>
										<br />
                                        <asp:Label ID="podchLabel" runat="server" Text="подчиненное-&gt;" 
                                            Visible="False"></asp:Label>
										<asp:DropDownList id="podchList" runat="server" Width="445px" 
                                            DataTextField="NAIMENOVAN" DataValueField="KEY_OF_NAI" Visible="False" 
                                            CssClass="label2" DataSourceID="podchDataSource">
										</asp:DropDownList>
                                        <asp:SqlDataSource ID="podchDataSource" runat="server" 
                                            ConnectionString="DSN=KADRY;DefaultDir=C:\KADRY;DriverId=277;FIL=dBase 5.0;MaxBufferSize=2048;PageTimeout=0;" 
                                            ProviderName="System.Data.Odbc" 
                                            SelectCommand="SELECT [NAIMENOVAN], [KEY_OF_NAI] FROM [NAIMEN]">
                                        </asp:SqlDataSource>
                                    </TD>
									<TD style="HEIGHT: 16px" vAlign="middle" align="center"></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 16px" vAlign="middle" align="left">
                                        &nbsp;</TD>
									<TD class="maintext" style="WIDTH: 574px; HEIGHT: 16px" vAlign="middle" align="left"
										colSpan="2">
										Фильтр по службе:</TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 16px" vAlign="middle" align="left">
                                        &nbsp;</TD>
									<TD class="maintext" style="WIDTH: 574px; HEIGHT: 16px" vAlign="middle" align="left"
										colSpan="2">
										<asp:DropDownList ID="sluzList" runat="server" CssClass="label2" 
                                            DataSourceID="sluzDataSource" DataTextField="NAM_OF_SLU" 
                                            DataValueField="KEY_OF_SLU" Width="550px">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="sluzDataSource" runat="server" 
                                            ConnectionString="DSN=KADRY;DefaultDir=C:\KADRY;DriverId=277;FIL=dBase 5.0;MaxBufferSize=2048;PageTimeout=0;" 
                                            ProviderName="System.Data.Odbc" 
                                            SelectCommand="SELECT [NAM_OF_SLU], [KEY_OF_SLU] FROM [SLUZBA]">
                                        </asp:SqlDataSource>
                                    </TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 16px" vAlign="middle" align="left"></TD>
									<TD class="maintext" style="WIDTH: 574px; HEIGHT: 16px" vAlign="middle" align="left"
										colSpan="2">
										<HR style="WIDTH: 100%; HEIGHT: 1px" SIZE="1">
										&nbsp;</TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 4px" vAlign="middle" align="left"></TD>
									<TD class="maintext" style="WIDTH: 574px; HEIGHT: 4px" vAlign="middle" align="left"><STRONG><FONT color="#ff0000">1.</FONT></STRONG>
										Список <U>стажеров</U>, которым&nbsp;по истечении&nbsp; испытательного срока не 
										присвоено специальное звание (величина исп.срока берется на момент приема на службу):</TD>
									<TD style="HEIGHT: 4px" vAlign="middle" align="center"><asp:imagebutton id="Button1" runat="server" ImageUrl="../images/btn_sp.gif" onclick="Button1_Click"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 10px" vAlign="middle" align="left"></TD>
									<TD class="maintext" style="WIDTH: 275px; HEIGHT: 10px" vAlign="middle" align="left"
										colSpan="2">
										<HR style="WIDTH: 100%; HEIGHT: 1px" SIZE="1">
									</TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 49px" vAlign="middle" align="left"></TD>
									<TD class="maintext" style="WIDTH: 574px; HEIGHT: 49px" vAlign="middle" align="left"><STRONG><FONT color="#ff0000">2.</FONT></STRONG>
										Список&nbsp;сотрудников назначенных на <U>офицерские должности</U>, но не имеющих 
										специальных званий:</TD>
									<TD style="HEIGHT: 49px" vAlign="middle" align="center"><asp:imagebutton id="Button2" runat="server" ImageUrl="../images/btn_sp.gif" onclick="Button2_Click"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 7px" vAlign="middle" align="left"></TD>
									<TD class="maintext" style="WIDTH: 275px; HEIGHT: 7px" vAlign="middle" align="left"
										colSpan="2">
										<HR style="WIDTH: 98%; HEIGHT: 1px" SIZE="1">
										&nbsp;</TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 32px" vAlign="middle" align="left"></TD>
									<TD class="maintext" style="WIDTH: 574px; HEIGHT: 32px" vAlign="middle" align="left"><STRONG><FONT color="#ff0000">3.</FONT></STRONG>
										Список аттестованных сотрудников, которым не присвоено <U>очередное</U> специальное звание 
										по истечении необходимого срока выслуги:</TD>
									<TD style="HEIGHT: 32px" vAlign="bottom" align="center"><asp:imagebutton id="Button3" runat="server" ImageUrl="../images/btn_sp.gif" onclick="Button3_Click"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 35px" vAlign="middle" align="left"></TD>
									<TD class="maintext" style="WIDTH: 574px; HEIGHT: 35px" vAlign="middle" align="left">
										<P>Фильтр по званиям:
											<asp:dropdownlist id="ZvanList1" runat="server" Width="211px">
												<asp:ListItem Value="0">Все</asp:ListItem>
												<asp:ListItem Value="1">Офицерские</asp:ListItem>
												<asp:ListItem Value="2">Рядового состава</asp:ListItem>
											</asp:dropdownlist></P>
									</TD>
									<TD style="HEIGHT: 35px" vAlign="middle" align="center"></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 7px" vAlign="middle" align="left"></TD>
									<TD class="maintext" style="WIDTH: 574px; HEIGHT: 7px" vAlign="middle" align="left">
										<P>
											<asp:CheckBox class="label2" id="CheckPotolok" runat="server" Width="504px" 
                                                Text='учитывать предельное звание по должности'></asp:CheckBox></P>
									</TD>
									<TD style="HEIGHT: 7px" vAlign="middle" align="center"></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 1px" vAlign="middle" align="left"></TD>
									<TD class="maintext" style="WIDTH: 574px; HEIGHT: 1px" vAlign="middle" align="left">
										<P>
											<asp:CheckBox class="label2" id="CheckNak" runat="server" Width="510px" 
                                                Text="показывать имеющих дисциплинарные взыскания"></asp:CheckBox></P>
									</TD>
									<TD style="HEIGHT: 1px" vAlign="middle" align="center"></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 2px" vAlign="middle" align="right"></TD>
									<TD class="maintext" style="WIDTH: 275px; HEIGHT: 2px" vAlign="middle" align="right"
										colSpan="2">
										<HR style="WIDTH: 98%; HEIGHT: 1px" SIZE="1">
										&nbsp;</TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 29px" vAlign="middle" align="right"></TD>
									<TD class="maintext" style="WIDTH: 574px; HEIGHT: 29px" vAlign="middle" align="left"><STRONG><FONT color="#ff0000">4.</FONT></STRONG>Контрольный 
										список сотрудников, которым в <U>текущем месяце</U>, должно быть присвоено 
										специальное звание:&nbsp;</TD>
									<TD style="HEIGHT: 29px" vAlign="bottom" align="center">
										<P><asp:imagebutton id="Button4" runat="server" ImageUrl="../images/btn_sp.gif" 
                                                onclick="Button4_Click"></asp:imagebutton></P>
									</TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 29px" vAlign="middle" align="right"></TD>
									<TD class="maintext" style="WIDTH: 574px; HEIGHT: 29px" vAlign="middle" align="left">
										<P>Фильтр по званиям:
											<asp:dropdownlist id="ZvanList2" runat="server" Width="211px">
												<asp:ListItem Value="0">Все</asp:ListItem>
												<asp:ListItem Value="1">Офицерские</asp:ListItem>
												<asp:ListItem Value="2">Рядового состава</asp:ListItem>
											</asp:dropdownlist></P>
									</TD>
									<TD style="HEIGHT: 29px" vAlign="middle" align="left"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15px; HEIGHT: 6px" align="center"></TD>
									<TD style="WIDTH: 574px; HEIGHT: 6px" align="center"></TD>
									<TD style="HEIGHT: 6px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15px; HEIGHT: 6px" align="center"></TD>
									<TD style="WIDTH: 574px; HEIGHT: 6px" align="left"><asp:label id="FindLabel" runat="server" Width="368px" CssClass="label"></asp:label></TD>
									<TD style="HEIGHT: 6px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15px; HEIGHT: 7px" align="left" colSpan="3"></TD>
								</TR>
							</TABLE>
						</P>
						<asp:datagrid id=Grid runat="server" Width="743px" BackColor="AntiqueWhite" CellPadding="2" BorderWidth="1px" BorderColor="Black" AutoGenerateColumns="False" DataMember="Table" DataSource="<%# ctrlDataSet %>" DataKeyField="KEY_1">
							<ItemStyle Font-Size="10px" Font-Names="Verdana"></ItemStyle>
							<HeaderStyle Font-Size="11px" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
								ForeColor="#660000"></HeaderStyle>
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
								<asp:BoundColumn DataField="VOIN_ZVAN" SortExpression="VOIN_ZVAN" HeaderText="Звание">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATA_PRSV" SortExpression="DATA_PRSV" HeaderText="Присвоено" DataFormatString="{0:d}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PODRAZDEL" SortExpression="PODRAZDEL" HeaderText="Подразделение">
									<ItemStyle Font-Size="8px" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NAM_OF_SLU" SortExpression="NAM_OF_SLU" HeaderText="Служба">
									<ItemStyle Font-Size="8px" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NAM_OF_DOL" SortExpression="NAM_OF_DOL" HeaderText="Должность">
									<ItemStyle Font-Size="8px" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATA_POST" SortExpression="DATA_POST" HeaderText="в ОВД с.." DataFormatString="{0:d}">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ISP_SROK" SortExpression="ISP_SROK" HeaderText="Исп. срок">
									<HeaderStyle Width="2px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATA_VDOLZ" SortExpression="DATA_VDOLZ" HeaderText="В долж. с" DataFormatString="{0:d}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="dateX" SortExpression="dateX" HeaderText="Предп.дата присв." DataFormatString="{0:d}">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IsNak" SortExpression="IsNak" HeaderText="Неснятые взыскания">
									<HeaderStyle Width="2%"></HeaderStyle>
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
