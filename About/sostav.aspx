<%@ Page language="c#" Codebehind="sostav.aspx.cs" AutoEventWireup="True" Inherits="kadry.About.sostav" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - о личном сотаве УРЛС УВД</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" vLink="#000000" aLink="#000000" link="#000000" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" MS_POSITIONING="GridLayout"
		bottomMargin="0" bgProperties="fixed" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE height="422" cellSpacing="0" cellPadding="0" width="759" align="left" border="0"
				style="WIDTH: 759px; HEIGHT: 422px">
				<TR>
					<TD align="center" style="HEIGHT: 70px"><IMG SRC="/images/header_small.gif" ALT="Информационная система обработки данных "Кадры"" USEMAP="#Map2"
							BORDER="0"><MAP NAME="Map2"><AREA SHAPE="RECT" COORDS="244,51,499,82" HREF="about.aspx" ALT="УРЛС УВД..." TITLE="УРЛС УВД..."></MAP></TD>
				</TR>
				<TR>
					<TD class="Header" align="center" height="3" vAlign="top" style="HEIGHT: 3px">
						<P>ЛИЧНЫЙ СОСТАВ&nbsp;УправлениЯ кадров</P>
					</TD>
				</TR>
				<TR>
					<TD align="center" vAlign="top" style="HEIGHT: 193px">
						<br>
						<P>
							<asp:DataGrid id=Grid runat="server" Width="744px" DataSource="<%# kadryDataSet %>" AutoGenerateColumns="False" BackColor="White" BorderColor="Black" BorderWidth="1px" DataKeyField="NAM_OF_DOL" DataMember="Aaqq" Height="128px" GridLines="Horizontal">
								<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Blue" VerticalAlign="Middle"></ItemStyle>
								<HeaderStyle Font-Size="XX-Small" Font-Names="verdana" Font-Bold="True" HorizontalAlign="Center"
									ForeColor="Black" BackColor="LemonChiffon"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="NAM_OF_DOL" SortExpression="NAM_OF_DOL" HeaderText="Должность">
										<HeaderStyle Width="30%"></HeaderStyle>
										<ItemStyle ForeColor="Black"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FAMILIYA" SortExpression="FAMILIYA" HeaderText="Фамилия">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle ForeColor="Black"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IMYA" SortExpression="IMYA" HeaderText="Имя">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Center" ForeColor="Black"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="OTCHECTVO" SortExpression="OTCHECTVO" HeaderText="Отчество">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Center" ForeColor="Black"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VOIN_ZVAN" SortExpression="VOIN_ZVAN" HeaderText="Звание">
										<HeaderStyle Width="20%"></HeaderStyle>
										<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Center" ForeColor="Black"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Фото">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:TemplateColumn>
								</Columns>
							</asp:DataGrid></P>
					</TD>
				</TR>
				<TR VALIGN="middle" ALIGN="left">
					<TD COLSPAN="2" HEIGHT="27" VALIGN="middle" NOWRAP>
						&nbsp; <IMG SRC="/images/bottom.gif" WIDTH="750" HEIGHT="33" USEMAP="#Map" BORDER="0"><MAP NAME="Map"><AREA SHAPE="RECT" COORDS="346,7,743,25" HREF="about.aspx" ALT="Сделано в УРЛС УВД по Ивановской области"
								TITLE="Сделано в УРЛС УВД по Ивановской области"><area shape="RECT" coords="18,5,39,27" href="../index.aspx" alt="На главную..." title="На главную..."><area shape="RECT" coords="47,5,68,27" href="about.aspx" alt="Об УРЛС УВД" title="Об УРЛС УВД"><area shape="RECT" coords="75,5,97,27" href="../Structure/structure.aspx" alt="Структура органов внутренних дел"
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
