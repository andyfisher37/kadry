<%@ Page language="c#" Codebehind="DetailNak.aspx.cs" AutoEventWireup="True" Inherits="kadry.Discipline.DetailNak" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - просмотр взысканий...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 674px; POSITION: absolute; TOP: 8px; HEIGHT: 584px"
				height="584" cellSpacing="1" cellPadding="1" width="674" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 2px" colSpan="3" vAlign="top" align="center"><IMG height="18" alt="" src="/images/d1-header.gif" width="782" align="left" style="WIDTH: 782px; HEIGHT: 18px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 8px" colSpan="3" align="center">
						<asp:Label class="label" id="FindLabel" runat="server" Width="744px"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 471px" colSpan="3" class="maintext" vAlign="top" align="center">
						<P><BR>
							<asp:DataGrid id=Grid runat="server" Width="752px" DataSource="<%# nakazDataSet %>" BackColor="White" AutoGenerateColumns="False" BorderColor="Black" BorderWidth="1px" DataKeyField="FAMILIYA" DataMember="Table">
								<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Black" VerticalAlign="Middle"></ItemStyle>
								<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
									ForeColor="#000066" BackColor="#FFFFCC"></HeaderStyle>
								<Columns>
									<asp:HyperLinkColumn DataNavigateUrlField="KEY_1" DataNavigateUrlFormatString="../DetailPage.aspx?id={0}"
										DataTextField="FAMILIYA" HeaderText="Фамилия">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:HyperLinkColumn>
									<asp:BoundColumn DataField="IMYA" SortExpression="IMYA" HeaderText="Имя">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="OTCHECTVO" SortExpression="OTCHECTVO" HeaderText="Отчество">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PODRAZDEL" SortExpression="PODRAZDEL" HeaderText="Подразделение"></asp:BoundColumn>
									<asp:BoundColumn DataField="NAM_OF_SLU" SortExpression="NAM_OF_SLU" HeaderText="Служба"></asp:BoundColumn>
									<asp:BoundColumn DataField="NAM_OF_DOL" SortExpression="NAM_OF_DOL" HeaderText="Должность"></asp:BoundColumn>
									<asp:BoundColumn DataField="P1" SortExpression="P1" HeaderText="Взыскание">
										<ItemStyle Font-Size="8px" Font-Bold="True" HorizontalAlign="Center" ForeColor="#FF0033"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DAT_NALOZ" SortExpression="DAT_NALOZ" HeaderText="Наложено" DataFormatString="{0:d}">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="P11" SortExpression="P11" HeaderText="Приказ ОВД"></asp:BoundColumn>
									<asp:BoundColumn DataField="N_PRIK_NAL" SortExpression="N_PRIK_NAL" HeaderText="№">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SODERZANIE" SortExpression="SODERZANIE" HeaderText="За что...">
										<ItemStyle Font-Size="8px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DAT_SNIAT" SortExpression="DAT_SNIAT" HeaderText="Снято" DataFormatString="{0:d}">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DATA_POST" SortExpression="DATA_POST" HeaderText="в ОВД с..." DataFormatString="{0:d}"></asp:BoundColumn>
								</Columns>
							</asp:DataGrid></P>
						<P>
                            <asp:ImageButton ID="ExcelCopyButton" runat="server" 
                                ImageUrl="..\images\btn_excel.gif" onclick="ExcelCopyButton_Click" />
&nbsp;<asp:ImageButton ID="WordCopyButton" runat="server" ImageUrl="..\images\btn_word.gif" 
                                onclick="WordCopyButton_Click" />
                        </P>
						<P>
							<TABLE id="Table2" style="WIDTH: 838px; HEIGHT: 22px" cellSpacing="1" cellPadding="1"
								align="center" border="0">
								<TR>
									<TD align="left" colSpan="3">
										<asp:Label class="label2" id="count_label" runat="server" Width="552px"></asp:Label></TD>
								</TR>
							</TABLE>
						</P>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR VALIGN="middle" ALIGN="left">
					<TD COLSPAN="2" HEIGHT="27" VALIGN="middle" NOWRAP>
						&nbsp; <IMG SRC="../images/bottom.gif" WIDTH="750" HEIGHT="33" USEMAP="#Map" BORDER="0"><MAP NAME="Map"><AREA SHAPE="RECT" COORDS="346,7,743,25" HREF="../About/about.aspx" ALT="Сделано в УРЛС УВД по Ивановской области"
								TITLE="Сделано в УРЛС УВД по Ивановской области"><area shape="RECT" coords="18,5,39,27" href="../index.aspx" alt="На главную..." title="На главную..."><area shape="RECT" coords="47,5,68,27" href="../About/about.aspx" alt="Об УРЛС УВД"
								title="Об УРЛС УВД"><area shape="RECT" coords="75,5,97,27" href="../Structure/structure.aspx" alt="Структура органов внутренних дел"
								title="Структура органов внутренних дел"><area shape="RECT" coords="104,5,125,27" href="../Search/search.aspx" alt="Поиск сотрудников"
								title="Поиск сотрудников"><area shape="RECT" coords="132,5,154,27" href="../Vakans/vakansy.aspx" alt="Вакансии"
								title="Вакансии"><area shape="RECT" coords="161,5,183,26" href="../Nekompl/nekompl.aspx" alt="Некомплект"
								title="Некомплект"><area shape="RECT" coords="190,5,212,26" href="../Kachestv/kachestv.aspx" alt="Качественные показатели"
								title="Качественные показатели"><area shape="RECT" coords="218,5,240,27" href="../Normatives/normatives.aspx" alt="Нормативные документы"
								title="Нормативные документы"><area shape="RECT" coords="247,5,269,26" href="../Blanks/blanks.aspx" alt="Бланки служебных документов"
								title="Бланки служебных документов"><area shape="RECT" coords="275,5,297,26" href="../Discipline/discipline.aspx" alt="Дисциплинарная практика"
								title="Дисциплинарная практика"><area shape="RECT" coords="305,5,327,27" href="../Toadmin/toadmin.aspx" alt="Письмо администратору..."
								title="Письмо администратору..."></MAP></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
