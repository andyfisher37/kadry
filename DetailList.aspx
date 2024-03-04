<%@ Page language="c#" Codebehind="DetailList.aspx.cs" AutoEventWireup="True" Inherits="kadry.DetailList" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - список сотрудников...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="images/background.gif" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 756px; POSITION: absolute; TOP: 8px; HEIGHT: 584px"
				height="584" cellSpacing="1" cellPadding="1" width="756" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 24px" colSpan="3"><IMG height="18" alt="" src="images/sl-header.gif" width="750" align="top"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" colSpan="3" align="left">
						<asp:Label class="label2" id="FindLabel" runat="server" Width="558px"></asp:Label>&nbsp;
						<asp:HyperLink class="label2" id="secure_label" runat="server" Width="182px" ForeColor="Red"></asp:HyperLink></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 453px" colSpan="3" class="maintext" vAlign="top" align="center">
						<asp:datagrid id=Grid runat="server" Width="747px" BorderWidth="1px" BorderColor="Black" HorizontalAlign="Justify" AutoGenerateColumns="False" BackColor="White" DataMember="Table" DataSource="<%# mainDataSet %>" Height="126px">
							<SelectedItemStyle Font-Size="10px" Font-Names="Verdana" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
								BackColor="#669999"></SelectedItemStyle>
							<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" ForeColor="#000066"
								VerticalAlign="Middle"></ItemStyle>
							<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
								ForeColor="Black" VerticalAlign="Middle" BackColor="#FFFFCC"></HeaderStyle>
							<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
							<Columns>
								<asp:HyperLinkColumn DataNavigateUrlField="key_1" DataNavigateUrlFormatString="DetailPage.aspx?id={0}"
									DataTextField="familiya" SortExpression="familiya" HeaderText="Фамилия">
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
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="voin_zvan" SortExpression="voin_zvan" HeaderText="Звание">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="lich_nom_1" SortExpression="lich_nom_1" HeaderText="Личный номер">
									<HeaderStyle Width="8%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD COLSPAN="2" HEIGHT="27" VALIGN="middle" NOWRAP>
						&nbsp; <IMG SRC="images/bottom.gif" WIDTH="750" HEIGHT="33" USEMAP="#Map" BORDER="0"><MAP NAME="Map"><AREA SHAPE="RECT" COORDS="346,7,743,25" HREF="/About/about.aspx" ALT="Сделано в УРЛС УВД по Ивановской области"
								TITLE="Сделано в УРЛС УВД по Ивановской области"><area shape="RECT" coords="18,5,39,27" href="index.aspx" alt="На главную..." title="На главную..."><area shape="RECT" coords="47,5,68,27" href="/About/about.aspx" alt="Об УРЛС УВД"
								title="Об УРЛС УВД"><area shape="RECT" coords="75,5,97,27" href="/Structure/structure.aspx" alt="Структура органов внутренних дел"
								title="Структура органов внутренних дел"><area shape="RECT" coords="104,5,125,27" href="/Search/search.aspx" alt="Поиск сотрудников"
								title="Поиск сотрудников"><area shape="RECT" coords="132,5,154,27" href="/Vakans/vakansy.aspx" alt="Вакансии" title="Вакансии"><area shape="RECT" coords="161,5,183,26" href="/Nekompl/nekompl.aspx" alt="Некомплект"
								title="Некомплект"><area shape="RECT" coords="190,5,212,26" href="/Kachestv/kachestv.aspx" alt="Качественные показатели"
								title="Качественные показатели"><area shape="RECT" coords="218,5,240,27" href="/Normatives/normatives.aspx" alt="Нормативные документы"
								title="Нормативные документы"><area shape="RECT" coords="247,5,269,26" href="/Blanks/blanks.aspx" alt="Бланки служебных документов"
								title="Бланки служебных документов"><area shape="RECT" coords="275,5,297,26" href="/Discipline/discipline.aspx" alt="Дисциплинарная практика"
								title="Дисциплинарная практика"><area shape="RECT" coords="305,5,327,27" href="/Toadmin/toadmin.aspx" alt="Письмо администратору..."
								title="Письмо администратору..."></MAP></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
