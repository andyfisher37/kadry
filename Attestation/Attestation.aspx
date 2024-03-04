<%@ Page language="c#" Codebehind="Attestation.aspx.cs" AutoEventWireup="True" Inherits="kadry.Attestation.Attestation" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Аттестация сотрудников...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="LEFT: 0px; POSITION: absolute; TOP: 0px" tabIndex="23" cellSpacing="0" cellPadding="0"
				width="753" align="left" border="0">
				<TBODY>
					<TR vAlign="top">
						<TD style="HEIGHT: 85px" vAlign="top" align="center" colSpan="19"><IMG alt="Информационная система обработки данных "Кадры"" src="/images/header_small.gif" border="0"></TD>
					</TR>
					<TR vAlign="top">
						<TD style="HEIGHT: 15px" vAlign="top" align="center" height="15">
							<P class="Header" align="center">А Т Т Е С Т А Ц И И</P>
						</TD>
					</TR>
					<TR vAlign="top">
						<TD tabIndex="0" vAlign="top" align="center" style="HEIGHT: 513px">
							<P tabIndex="16"><A href="howtosearch.htm"></A></P>
							&nbsp;
							<TABLE class="maintext" id="Table1" tabIndex="0" cellSpacing="1" cellPadding="1" align="center"
								bgColor="#D1D1D1" border="0" style="WIDTH: 690px; HEIGHT: 262px" cols="1">
								<TR>
									<TD class="label2" vAlign="middle" align="center" style="HEIGHT: 2px">Поиск 
										действующих сотрудников и редактирование параметров аттестаций:</TD>
								</TR>
								<TR>
									<TD class="maintext" vAlign="middle" align="center" style="HEIGHT: 6px">
										<TABLE id="Table2" style="WIDTH: 282px; HEIGHT: 96px" cellSpacing="0" cellPadding="0" width="282"
											border="0">
											<TR>
												<TD class="maintext" align="right">Фамилия:</TD>
												<TD>
													<asp:textbox id="first_name" tabIndex="1" runat="server" Font-Names="Verdana" Font-Bold="True"
														ForeColor="#C00000" ToolTip="Введите фамилию" Width="144px" Font-Size="X-Small" ontextchanged="first_name_TextChanged"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="maintext" align="right">Имя:</TD>
												<TD>
													<asp:textbox id="name" tabIndex="2" runat="server" Font-Names="Verdana" Font-Bold="True" ForeColor="#C00000"
														ToolTip="Имя" Width="144px" Font-Size="X-Small" ontextchanged="name_TextChanged"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="maintext" align="right">Отчество:</TD>
												<TD>
													<asp:textbox id="last_name" tabIndex="3" runat="server" Font-Names="Verdana" Font-Bold="True"
														ForeColor="#C00000" ToolTip="Отчество" Width="144px" Font-Size="X-Small" ontextchanged="last_name_TextChanged"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="maintext" align="right">№ Личного дела:</TD>
												<TD>
													<asp:textbox id="file_num" runat="server" Font-Names="Verdana" Font-Bold="True" ForeColor="#C00000"
														ToolTip="№ личного дела" Width="64px" Font-Size="X-Small"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="maintext" align="center" style="HEIGHT: 8px"><asp:imagebutton id="GoBtn" runat="server" ToolTip="Давайте поищем!" ImageUrl="../images/iskat.gif"
											alt=" Поиск " onclick="GoBtn_Click"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD align="center" height="8" style="HEIGHT: 8px">
										<HR align="center" width="99.72%" color="#660033" SIZE="2" style="WIDTH: 99.72%; HEIGHT: 2px">
									</TD>
								</TR>
								<TR>
									<TD class="maintext" vAlign="bottom" align="left" width="213" height="14">
										<P><asp:label id="FindLabel" runat="server" Font-Size="XX-Small" Width="328px" ForeColor="Black"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD vAlign="bottom" align="left" width="213" height="14"></TD>
								</TR>
							</TABLE>
							<P tabIndex="16">&nbsp;<asp:datagrid id="Grid" runat="server" Width="736px" ToolTip="Нажми на Фамилию и оформи аттестацию"
									Font-Names="Verdana" Height="52px" BorderWidth="1px" BorderColor="Black" HorizontalAlign="Center" AutoGenerateColumns="False"
									BackColor="White" DataSource="<%# viewDataSet %>" DataMember="Table">
									<SelectedItemStyle Font-Size="10px" Font-Names="Verdana" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
										BackColor="#669999"></SelectedItemStyle>
									<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" ForeColor="#000066"
										VerticalAlign="Middle"></ItemStyle>
									<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
										ForeColor="Black" VerticalAlign="Middle" BackColor="#FFFFCC"></HeaderStyle>
									<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
									<Columns>
										<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="KEY_1" DataNavigateUrlFormatString="MainAttestation.aspx?id={0}&amp;date=0"
											DataTextField="FAMILIYA" SortExpression="FAMILIYA" HeaderText="Фамилия">
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
										<asp:BoundColumn DataField="nam_of_dol" SortExpression="nam_of_dol" HeaderText="Должность">
											<HeaderStyle Width="15%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="voin_zvan" SortExpression="voin_zvan" HeaderText="Звание">
											<HeaderStyle Width="10%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Сведения об аттестациях">
											<ItemStyle Font-Size="9px" Font-Names="Verdana" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
								</asp:datagrid></P>
							<P tabIndex="16">&nbsp;</P>
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
