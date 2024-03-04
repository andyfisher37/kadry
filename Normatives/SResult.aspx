<%@ Page language="c#" Codebehind="SResult.aspx.cs" AutoEventWireup="false" Inherits="UK.Normatives.SResult" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационно-аналитическая служба УК УВД - резултаты поиска по базе нормативных документов...</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#990033" aLink="#0033ff" link="#ff3300" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 744px; HEIGHT: 590px" height="590" cellSpacing="0" cellPadding="0"
				width="744" align="left" border="0">
				<TR>
					<TD style="WIDTH: 737px; HEIGHT: 70px" align="center">
						<IMG alt="" src="/images/header3.gif" width="750" useMap="#Map2" border="0"><MAP name="Map2"><AREA title="УК УВД..." shape="RECT" alt="УК УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP></TD>
				</TR>
				<TR>
					<TD class="Header" style="WIDTH: 737px; HEIGHT: 26px" vAlign="top" align="center" height="26">Результаты 
						поиска по нормативным ДОКУМЕНТам</TD>
				</TR>
				<TR>
					<td align="center" vAlign="top">
						<P>
							<asp:Label class="Attantion" id="FindLabel" runat="server" Width="392px"></asp:Label></P>
						<asp:DataGrid id=Grid runat="server" AutoGenerateColumns="False" DataSource="<%# dv %>" BorderWidth="1px" BorderColor="DarkSlateGray" Width="750px" BackColor="Snow" CellPadding="1" PageSize="15" AllowCustomPaging="True">
							<ItemStyle Font-Size="10px" Font-Names="verdana" ForeColor="Black" VerticalAlign="Middle"></ItemStyle>
							<HeaderStyle Font-Size="11px" Font-Names="verdana" Font-Bold="True" HorizontalAlign="Center"
								ForeColor="#000099" BackColor="LemonChiffon"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="№">
									<HeaderStyle Width="4%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Содержание...">
									<HeaderStyle Width="80%"></HeaderStyle>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="VPath" DataNavigateUrlFormatString="{0}" DataTextField="VPath"
									HeaderText="Файл">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle Font-Size="9px" Font-Names="Verdana" HorizontalAlign="Center" ForeColor="#33CCFF"></ItemStyle>
								</asp:HyperLinkColumn>
								<asp:TemplateColumn HeaderText="Размер (Кб)">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="DocKeywords"></asp:TemplateColumn>
							</Columns>
							<PagerStyle NextPageText="[&amp;gt;]" Font-Bold="True" PrevPageText="[&amp;lt;]" HorizontalAlign="Left"
								Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></td>
				</TR>
				<TR VALIGN="middle" ALIGN="left">
					<TD COLSPAN="2" HEIGHT="27" VALIGN="middle" NOWRAP style="WIDTH: 737px">
						<IMG SRC="/images/bottom.gif" WIDTH="750" HEIGHT="33" USEMAP="#Map" BORDER="0"><MAP NAME="Map"><AREA SHAPE="RECT" COORDS="346,7,743,25" HREF="../About/about.aspx" ALT="Сделано в УК УВД Ивановской области"
								TITLE="Сделано в УК УВД Ивановской области"><area shape="RECT" coords="18,5,39,27" href="../index.aspx" alt="На главную..." title="На главную..."><area shape="RECT" coords="47,5,68,27" href="../About/about.aspx" alt="Об управлении кадров"
								title="Об управлении кадров"><area shape="RECT" coords="75,5,97,27" href="../Structure/structure.aspx" alt="Структура органов внутренних дел"
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
