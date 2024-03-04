<%@ Page language="c#" Codebehind="CertControl.aspx.cs" AutoEventWireup="false" Inherits="kadry.Control.cert_control" codePage="65001"%>
<%@ Register assembly="obout_Calendar2_Net" namespace="OboutInc.Calendar2" tagprefix="obout" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - контроль своевременности замены 
			служебных удостоверений...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
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
					<TD class="Header" style="HEIGHT: 3px" vAlign="top" align="center" height="3">КОНТРОЛЬ&nbsp;СЛУЖЕБНЫХ 
						УДОСТОВЕРЕНИЙ</TD>
				</TR>
				<TR>
					<TD class="maintext" style="HEIGHT: 355px" vAlign="top" align="center">
						<P>&nbsp;
							<TABLE id="Table1" style="WIDTH: 767px; height: 242px;" cellSpacing="0" 
                                cellPadding="0" bgColor="#D1D1D1" border="0">
								<TR>
									<TD class="maintext" style="WIDTH: 15px;" vAlign="middle" align="left"></TD>
									<TD class="maintext" vAlign="middle" align="left">
										<STRONG><FONT color="#ff0000">1.</FONT></STRONG> Список 
											утраченных служебных удостоверений с
                                            <input readonly="true" type="text" ID="Date1" style="height:20px;width:70px" />
						    			    <obout:Calendar ID="Calendar1" runat="server" StyleFolder="/styles/default" 
								            DatePickerMode="true" TextBoxId="Date1" DatePickerImagePath ="/styles/date_picker1.gif" 
                                            DateFormat="dd.MM.yyyy" ShowHourSelector="False" ShowMinuteSelector="False" />
									
                                            &nbsp;по :

                                            <input readonly="true" type="text" ID="Date2" style="height:20px;width:70px" />
						    			    <obout:Calendar ID="Calendar2" runat="server" StyleFolder="/styles/default" 
								            DatePickerMode="true" TextBoxId="Date2" DatePickerImagePath ="/styles/date_picker1.gif" 
                                            DateFormat="dd.MM.yyyy" ShowHourSelector="False" ShowMinuteSelector="False" />

									</TD>
									<TD style="HEIGHT: 53px" vAlign="middle" align="left"><asp:imagebutton id="Btn1" runat="server" ImageUrl="../images/btn_sp.gif"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px;" vAlign="middle" align="left"></TD>
									<TD class="maintext" style="WIDTH: 374px;" vAlign="middle" align="left"
										colSpan="2">
										<HR SIZE="1" style="WIDTH: 745px; HEIGHT: 1px">
										</TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; " vAlign="middle" align="left"></TD>
									<TD class="maintext" vAlign="middle" align="left"><STRONG><FONT color="#ff0000">2.</FONT></STRONG>
										Список удостоверений с истекшим сроком действия: (+
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="maintext" Width="45px">0</asp:TextBox>
&nbsp;дней просрочки)</TD>
									<TD  vAlign="middle" align="left"><asp:imagebutton id="Btn2" runat="server" ImageUrl="../images/btn_sp.gif"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; " vAlign="middle" align="left"></TD>
									<TD class="maintext" style="WIDTH: 275px;" vAlign="middle" align="left"
										colSpan="2">
										<HR style="WIDTH: 745px; HEIGHT: 1px" SIZE="1">
									</TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; " vAlign="middle" align="left"></TD>
									<TD class="maintext" vAlign="middle" align="left"><STRONG><FONT color="#ff0000">3.</FONT></STRONG>
										Список сотрудников, служебные удостоверения которых подлежат замене (по различным 
                                        основаниям):</TD>
									<TD  vAlign="middle" align="left"><asp:imagebutton id="Btn3" runat="server" ImageUrl="../images/btn_sp.gif"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; " vAlign="middle" align="left"></TD>
									<TD class="maintext" style="WIDTH: 475px;" vAlign="middle" align="left"
										colSpan="2">
										<HR style="WIDTH: 745px; HEIGHT: 1px" SIZE="1">
									</TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 15px; HEIGHT: 1px" vAlign="middle" align="right"></TD>
									<TD class="maintext" style="WIDTH: 643px; HEIGHT: 1px" vAlign="middle" align="center"><FONT color="#cc0033" size="1">&nbsp;* 
											В виду большого объема данных в АИС &quot;Удостоверение&quot;, некоторые запросы могут занять значитильное 
											время...</FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15px; " align="center"></TD>
									<TD style="WIDTH: 643px;" align="left"><asp:label id="FindLabel" runat="server" CssClass="label" Width="368px"></asp:label></TD>
									<TD ></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15px;" align="left" colSpan="3"></TD>
								</TR>
							</TABLE>
						</P>
						<asp:datagrid id=Grid runat="server" Width="806px" DataSource="<%# archDataSet %>" DataMember="Table" ToolTip="Нажми на Фамилию и просмотри служебную карточку сотрудника..." Height="52px" HorizontalAlign="Center" Font-Names="Verdana" BackColor="White" BorderWidth="1px" BorderColor="Black" AutoGenerateColumns="False">
							<SelectedItemStyle Font-Size="10px" Font-Names="Verdana" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
								BackColor="#669999"></SelectedItemStyle>
							<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" ForeColor="#000066"
								VerticalAlign="Middle"></ItemStyle>
							<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
								ForeColor="Black" VerticalAlign="Middle" BackColor="#FFFFCC"></HeaderStyle>
							<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
							<Columns>
								<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="KEY_1" DataNavigateUrlFormatString="../DetailPage.aspx?id={0}"
									DataTextField="FAMILIYA" SortExpression="KEY_1" HeaderText="Фамилия">
									<HeaderStyle Width="9%"></HeaderStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="imya" HeaderText="Имя">
									<HeaderStyle Width="9%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="otchectvo" HeaderText="Отчество">
									<HeaderStyle Width="9%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="podrazdel" SortExpression="podrazdel" HeaderText="Подразделение">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="nam_of_slu" SortExpression="nam_of_slu" HeaderText="Служба">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Статус"></asp:TemplateColumn>
								<asp:BoundColumn DataField="data_uvol" SortExpression="DATA_UVOL" HeaderText="Дата (ув., отк., ...)"
									DataFormatString="{0:d}">
									<HeaderStyle Width="7%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="voin_zvan" SortExpression="voin_zvan" HeaderText="Звание">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="lich_nom_1" SortExpression="lich_nom_1" HeaderText="Личный номер">
									<HeaderStyle Width="8%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="certificate" SortExpression="certificate" HeaderText="Удостоверение"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
                        <br />
                        <br>
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
