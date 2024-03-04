<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="borntoday.aspx.cs" Inherits="kadry.BornToday.borntoday" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Сегодня день рождения...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" background="../images/background.gif" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 769px; POSITION: absolute; TOP: 8px; HEIGHT: 344px"
				cellSpacing="1" cellPadding="1" width="769" border="0">
				<TR>
					<TD style="HEIGHT: 37px"></TD>
					<TD class="label2" style="HEIGHT: 37px" vAlign="middle" align="center">
						<P><asp:label id="TitleText" runat="server" Width="533px" class="Header"></asp:label></P>
						<P class="maintext">
							<TABLE id="Table2" style="WIDTH: 208px; HEIGHT: 104px" cellSpacing="0" cellPadding="0"
								width="208" bgColor="peachpuff" border="0">
								<TR>
									<TD class="label2" align="center">Параметры выборки:</TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:Button id="ThisMonth" runat="server" Text="в этом месяце..." Width="144px"></asp:Button></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:Button id="Today" runat="server" Width="144px" Text="сегодня.."></asp:Button></TD>
								</TR>
								<TR>
									<TD align="center">с
										<ew:MaskedTextBox id="Date1" runat="server" Width="57px" Font-Names="Verdana" Font-Size="X-Small"
											Mask="99.99" ForeColor="#0000C0" ToolTip="день, месяц"></ew:MaskedTextBox>&nbsp;по
										<ew:MaskedTextBox id="Date2" runat="server" Width="56px" Font-Names="Verdana" Font-Size="X-Small"
											Mask="99.99" ForeColor="#0000C0" ToolTip="день, месяц"></ew:MaskedTextBox>&nbsp;
										<asp:Button id="WithDate" runat="server" Text="?"></asp:Button></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;&nbsp;&nbsp;</P>
                        <P class="maintext">
							Действующие сотрудники:</P>
					</TD>
					</P>
					</TD>
					<TD style="HEIGHT: 37px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 264px"></TD>
					<TD style="HEIGHT: 264px" vAlign="top" align="center">
						<P><asp:datagrid id="Grid" runat="server" DataSource="<%# bornDataSet %>" DataMember="Table" AutoGenerateColumns="False" BorderColor="Black" BorderWidth="1px" Font-Names="Verdana" BackColor="LemonChiffon" Width="747px">
								<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" VerticalAlign="Middle"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
									BackColor="#FFFF99"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="FAMILIYA" SortExpression="FAMILIYA" HeaderText="Фамилия">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IMYA" SortExpression="IMYA" HeaderText="Имя">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="OTCHECTVO" SortExpression="OTCHECTVO" HeaderText="Отчество">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PODRAZDEL" SortExpression="PODRAZDEL" HeaderText="Подразделение">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAM_OF_SLU" SortExpression="NAM_OF_SLU" HeaderText="Служба">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAM_OF_DOL" SortExpression="NAM_OF_DOL" HeaderText="Должность">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VOIN_ZVAN" SortExpression="VOIN_ZVAN" HeaderText="Звание">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DATA_ROZD" SortExpression="DATA_ROZD" HeaderText="Дата рождения" DataFormatString="{0:d}">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></P>
						<P>
							<asp:Label class="label2" id="Count" runat="server" Width="372px"></asp:Label></P>
                        <P class="maintext">
							Уволенные сотрудники:</P>
                        <asp:datagrid id=Grid2 runat="server" DataSource="<%# bornDataSet2 %>" 
                            DataMember="Table" AutoGenerateColumns="False" BorderColor="Black" 
                            BorderWidth="1px" Font-Names="Verdana" BackColor="LemonChiffon" 
                            Width="747px">
								<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" VerticalAlign="Middle"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
									BackColor="#FFFF99"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="FAMILIYA" SortExpression="FAMILIYA" HeaderText="Фамилия">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IMYA" SortExpression="IMYA" HeaderText="Имя">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="OTCHECTVO" SortExpression="OTCHECTVO" HeaderText="Отчество">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PODRAZDEL" SortExpression="PODRAZDEL" HeaderText="Подразделение">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAM_OF_SLU" SortExpression="NAM_OF_SLU" HeaderText="Служба">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAM_OF_DOL" SortExpression="NAM_OF_DOL" HeaderText="Должность">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VOIN_ZVAN" SortExpression="VOIN_ZVAN" HeaderText="Звание">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DATA_ROZD" SortExpression="DATA_ROZD" HeaderText="Дата рождения" DataFormatString="{0:d}">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid>
					    <br />
							<asp:Label class="label2" id="Count2" runat="server" Width="372px"></asp:Label>
					</TD>
					<TD style="HEIGHT: 264px"></TD>
				</TR>
				<TR>
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
