<%@ Page language="c#" Codebehind="Disc_stat.aspx.cs" AutoEventWireup="false" Inherits="kadry.Discipline.Disc_stat" codePage="65001"%>
<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - краткая статистика по 
			дисциплинарной практике...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	    <style type="text/css">
            .style1
            {
                height: 30px;
                width: 23px;
            }
        </style>
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 700px; HEIGHT: 592px" cellSpacing="0" cellPadding="0"
				align="left" border="0" VSPACE="0" HSPACE="0">
				<TBODY>
					<TR>
						<TD style="WIDTH: 848px; HEIGHT: 79px" vAlign="top" align="center" colSpan="19"><IMG alt="" src="/images/header_small.gif" width="750" useMap="#Map2" border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP></TD>
					</TR>
					<TR vAlign="top" align="center">
						<TD style="HEIGHT: 3px" vAlign="top" align="center" colSpan="1" height="3" rowSpan="1"><SPAN class="Header">КРАТКАя 
								статистика по Дисциплинарной практике</SPAN></TD>
					</TR>
					<TR vAlign="top" align="left">
						<TD style="HEIGHT: 350px" vAlign="top" noWrap align="center" colSpan="1" height="350"
							rowSpan="1">
							<BLOCKQUOTE>
								<P>
									<TABLE class="maintext" id="Table1" style="WIDTH: 738px; HEIGHT: 1px" cellSpacing="1"
										cellPadding="1" bgColor="#D1D1D1" border="0">
										<TR>
											<TD align="left" class="style1">Период:
											</TD>
											<TD style="WIDTH: 341px; HEIGHT: 38px" vAlign="middle" align="center" colSpan="2">с...&nbsp;
												<ew:MaskedTextBox id="Date1" runat="server" ToolTip="Дата начала периода" 
                                                    Font-Bold="True" ForeColor="Blue"
													Font-Names="Verdana" Width="92px" Mask="99.99.9999" Text="01.01.2004"></ew:MaskedTextBox>&nbsp;г.&nbsp;по&nbsp;
												<ew:MaskedTextBox id="Date2" runat="server" ToolTip="Дата конца периода" 
                                                    Font-Bold="True" ForeColor="Blue"
													Font-Names="Verdana" Width="92px" Mask="99.99.9999" Text="01.01.2004"></ew:MaskedTextBox>&nbsp;г.</TD>
										</TR>
										<TR>
											<TD class="smalltext" style="WIDTH: 173px; HEIGHT: 1px" vAlign="middle" align="right"
												colSpan="3"></TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center" colSpan="3"><asp:imagebutton id="pooBtn" runat="server" ToolTip="Вывести статистику по  поощрениям..." ImageUrl="/images/btn_stat.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD class="smalltext" style="WIDTH: 173px; HEIGHT: 1px" vAlign="middle" align="right"
												colSpan="3"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 126px" vAlign="middle" align="left" colSpan="3"><asp:label id="FindLabel" runat="server" Width="552px" CssClass="label"></asp:label></TD>
										</TR>
									</TABLE>
		</form>
		</P></BLOCKQUOTE>
		<P class="maintext">&nbsp;
			<TABLE id="Table2" style="WIDTH: 739px; HEIGHT: 72px" cellSpacing="1" cellPadding="1" width="739"
				border="0">
				<TR>
					<TD class="label2" style="HEIGHT: 11px" align="center" width="50%" vAlign="bottom"><FONT color="#0033ff">Распределение 
							количества взысканий среди сотрудников УВД по Ивановской области по <FONT style="BACKGROUND-COLOR: #ffff66">
								службам</FONT>:</FONT></TD>
					<TD class="label2" style="HEIGHT: 11px" width="50%" align="center" vAlign="bottom"><FONT color="#009900">Распределение 
							количества&nbsp;поощрений среди сотрудников УВД по Ивановской области по <FONT style="BACKGROUND-COLOR: #ffff66">
								службам</FONT>:</FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 348px; HEIGHT: 125px" vAlign="top" align="center"><asp:datagrid id=Grid1 runat="server" Width="359px" Font-Names="Verdana" DataSource="<%# stat_sl_DataSet %>" AutoGenerateColumns="False" BorderColor="Black" BorderWidth="1px" BackColor="FloralWhite" DataMember="SLUZBA">
							<ItemStyle Font-Size="XX-Small"></ItemStyle>
							<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="#990000"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="№">
									<HeaderStyle Width="4%"></HeaderStyle>
									<ItemStyle Font-Size="9px" HorizontalAlign="Center"></ItemStyle>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="NAM_OF_SLU" SortExpression="NAM_OF_SLU" HeaderText="Наименование службы">
									<HeaderStyle HorizontalAlign="Center" Width="76%"></HeaderStyle>
									<ItemStyle Font-Size="10px" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Expr1" SortExpression="Expr1" HeaderText="Количество взысканий">
									<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									<ItemStyle Font-Size="10px" HorizontalAlign="Center" ForeColor="#0000CC" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
					<TD style="HEIGHT: 125px" vAlign="top" align="center" width="50%">
						<asp:DataGrid id=Grid2 runat="server" Font-Names="Verdana" DataSource="<%# stat_sl_DataSet %>" AutoGenerateColumns="False" BorderColor="Black" BorderWidth="1px" BackColor="FloralWhite" DataMember="SLUZBA">
							<ItemStyle Font-Size="XX-Small"></ItemStyle>
							<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="#990000"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="№">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Font-Size="9%" HorizontalAlign="Center"></ItemStyle>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="NAM_OF_SLU" SortExpression="NAM_OF_SLU" HeaderText="Наименование службы">
									<HeaderStyle HorizontalAlign="Center" Width="75%"></HeaderStyle>
									<ItemStyle Font-Size="10px" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Expr1" SortExpression="Expr1" HeaderText="Количество поощрений">
									<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									<ItemStyle Font-Size="10px" HorizontalAlign="Center" ForeColor="#0000CC" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 348px; HEIGHT: 7px"></TD>
					<TD width="50%" style="HEIGHT: 7px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 348px" class="label2" align="center" vAlign="bottom"><FONT color="#0033ff">Распределение 
							количества взысканий среди сотрудников УВД по Ивановской области по <FONT style="BACKGROUND-COLOR: #ffff66">
								подразделениям</FONT>:</FONT></TD>
					<TD width="50%" align="center" class="label2" vAlign="bottom"><FONT color="#009900">Распределение 
							количества&nbsp;поощрений среди сотрудников УВД по Ивановской области по <FONT style="BACKGROUND-COLOR: #ffff66">
								подразделениям</FONT>:</FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 348px" vAlign="top">
						<asp:datagrid id=Grid3 runat="server" Width="359px" Font-Names="Verdana" DataSource="<%# stat_pdr_DataSet %>" AutoGenerateColumns="False" BorderColor="Black" BorderWidth="1px" BackColor="FloralWhite" DataMember="PODRAZD">
							<ItemStyle Font-Size="XX-Small"></ItemStyle>
							<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="#990000"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="№">
									<HeaderStyle Width="4%"></HeaderStyle>
									<ItemStyle Font-Size="9px" HorizontalAlign="Center"></ItemStyle>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="PODRAZDEL" SortExpression="PODRAZDEL" HeaderText="Наименование подразделения">
									<HeaderStyle HorizontalAlign="Center" Width="76%"></HeaderStyle>
									<ItemStyle Font-Size="10px" HorizontalAlign="Left" ForeColor="Black" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Expr1" SortExpression="Expr1" HeaderText="Количество взысканий">
									<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									<ItemStyle Font-Size="10px" HorizontalAlign="Center" ForeColor="#0000CC" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
					<TD width="50%" vAlign="top">
						<asp:DataGrid id=Grid4 runat="server" Font-Names="Verdana" DataSource="<%# stat_pdr_DataSet %>" AutoGenerateColumns="False" BorderColor="Black" BorderWidth="1px" BackColor="FloralWhite" DataMember="PODRAZD">
							<ItemStyle Font-Size="XX-Small"></ItemStyle>
							<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="#990000"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="№">
									<HeaderStyle Width="4%"></HeaderStyle>
									<ItemStyle Font-Size="9px" HorizontalAlign="Center"></ItemStyle>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="PODRAZDEL" SortExpression="PODRAZDEL" HeaderText="Ниаменование подразделения">
									<HeaderStyle HorizontalAlign="Center" Width="76%"></HeaderStyle>
									<ItemStyle Font-Size="10px" HorizontalAlign="Left" ForeColor="Black" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Expr1" SortExpression="Expr1" HeaderText="Количество поощрений">
									<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									<ItemStyle Font-Size="10px" HorizontalAlign="Center" ForeColor="#0000CC" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
		</P>
		&nbsp;</TD></TR>
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
		</TBODY></TABLE></FORM>
	</body>
</HTML>
