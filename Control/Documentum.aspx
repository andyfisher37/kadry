<%@ Page language="c#" Codebehind="Documentum.aspx.cs" AutoEventWireup="false" Inherits="kadry.Control.Documentum" codePage="65001"%>
<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Делопроизводство...</title>
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#990000" aLink="#6666ff" link="#0000ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 751px; HEIGHT: 376px" height="376" cellSpacing="0" cellPadding="0"
				width="751" align="left" border="0">
				<TR>
					<TD style="WIDTH: 740px; HEIGHT: 58px" vAlign="top" align="center" height="58"><IMG alt="Информационная система обработки данных "Кадры"" src="/images/header_small.gif" useMap="#Map2"
							border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP>&nbsp;
					</TD>
				</TR>
				<TR>
					<TD class="Header" style="WIDTH: 740px; HEIGHT: 21px" align="center" height="21">Делопроизводство
						<EM>(в разработке...)</EM></TD>
				</TR>
				<TR>
					<td style="WIDTH: 740px; HEIGHT: 221px" vAlign="top" align="center">
						<TABLE class="maintext" id="Table1" cellSpacing="0" cellPadding="0" border="0" align="center">
							<TR>
								<TD vAlign="top" noWrap align="center"><STRONG><FONT color="orangered">Всего с&nbsp;</FONT></STRONG>
									<asp:label id="Date" runat="server" Width="88px" Font-Bold="True"></asp:label><STRONG><FONT color="orangered">&nbsp; 
											зарегестрировано:
											<asp:label id="total_number" runat="server" Width="103px" Font-Bold="True" ForeColor="Black"></asp:label>приказов 
											&lt;&lt;по личному составу&gt;&gt;.</FONT></STRONG></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center">
									<HR style="WIDTH: 737px; HEIGHT: 1px" color="#000099" SIZE="1">
									<TABLE class="maintext" id="Table2" cellSpacing="0" cellPadding="0" width="548" bgColor="antiquewhite"
										border="0" style="WIDTH: 548px; HEIGHT: 146px">
										<TR>
											<TD class="label2" align="center" colSpan="2">Поиск приказа &lt;&lt;по личному 
												составу&gt;&gt;</TD>
										</TR>
										<TR>
											<TD class="supersmall" style="HEIGHT: 7px" align="right" colSpan="2"></TD>
										</TR>
										<TR>
											<TD align="right" style="HEIGHT: 27px">Подразделение:</TD>
											<TD style="HEIGHT: 27px">
												<asp:DropDownList id=podrList runat="server" Width="333px" DataSource="<%# slvdocDataSet %>" DataTextField="name" DataValueField="id" class=label2 CssClass="label2">
												</asp:DropDownList></TD>
										</TR>
										<TR>
											<TD align="right">Дата приказа:</TD>
											<TD>
												<ew:MaskedTextBox id="DateDoc" runat="server" Width="90px" Mask="99.99.9999" 
                                                    CssClass="label2"></ew:MaskedTextBox></TD>
										</TR>
										<TR>
											<TD align="right">Номер приказа:</TD>
											<TD>
												<asp:TextBox id="Number" runat="server" Width="90px" CssClass="label2"></asp:TextBox>&nbsp;л/с</TD>
										</TR>
										<TR>
											<TD class="supersmall" colSpan="2"></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="2">
												<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../images/iskat.gif"></asp:ImageButton></TD>
										</TR>
									</TABLE>
									<TABLE id="Table3" style="WIDTH: 548px; HEIGHT: 26px" cellSpacing="0" cellPadding="0" width="548"
										border="1">
										<TR>
											<TD colSpan="3">
												<asp:Label class="UserInfo" id="Info" runat="server" Width="536px"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center"><FONT color="#990000"><STRONG>Таблица предоставления приказов по личному 
											составу за&nbsp;<asp:DropDownList ID="List1" runat="server" 
                                        AutoPostBack="True" onselectedindexchanged="List1_SelectedIndexChanged">
                                    </asp:DropDownList>
&nbsp;год</STRONG></FONT></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center"><asp:datagrid id=Grid runat="server" Width="549px" DataSource="<%# statDataSet %>" AutoGenerateColumns="False" BorderColor="#000099" BorderWidth="1px" CellPadding="0" DataMember="Table" BackColor="White" Height="100px">
										<ItemStyle Font-Size="XX-Small" Font-Names="MS Reference Sans Serif"></ItemStyle>
										<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center"
											VerticalAlign="Middle" BackColor="WhiteSmoke"></HeaderStyle>
										<Columns>
											<asp:HyperLinkColumn Target="_blank" DataTextField="podr" SortExpression="name" HeaderText="Подразделение">
												<HeaderStyle Width="50%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:HyperLinkColumn>
											<asp:BoundColumn DataField="count" SortExpression="count" HeaderText="Всего (шт.)">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" ForeColor="#660000"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="maxnum" SortExpression="maxnum" HeaderText="№ после-днего">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dolgi" SortExpression="dolgi" HeaderText="Отсутствует (шт.)">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="link" SortExpression="link" HeaderText="Подро-бнее">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
					</td>
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
