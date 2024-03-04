<%@ Page language="c#" Codebehind="guestbook.aspx.cs" AutoEventWireup="True" Inherits="kadry.Guestbook.guestbook" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационно-аналитическая служба УРЛС УВД - Книга отзывов и предложений...</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#000000" aLink="#000000" link="#000000" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 759px; HEIGHT: 590px" height="590" cellSpacing="0" cellPadding="0"
				width="759" align="left" border="0">
				<TR>
					<TD style="HEIGHT: 70px" align="center"><IMG alt="" src="/images/head_small.gif" width="750" useMap="#Map2" border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP></TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 3px" vAlign="top" align="center" height="3">КНИГА 
						ОТЗЫВОВ И ПРЕДЛОЖЕНИЙ</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left">
						<P><br>
							<asp:TextBox id="TextBoxName" runat="server" Width="384px"></asp:TextBox></P>
						<P>
							<asp:TextBox id="TextBoxEMail" runat="server" Width="384px"></asp:TextBox></P>
						<P>
							<asp:TextBox id="TextBoxHomepageTitle" runat="server" Width="384px"></asp:TextBox></P>
						<P>
							<asp:TextBox id="TextBoxHomepageURL" runat="server" Width="384px"></asp:TextBox></P>
						<P>
							<asp:TextBox id="TextBoxLocation" runat="server" Width="384px"></asp:TextBox></P>
						<P>
							<asp:CheckBox id="CheckBoxPrivate" runat="server" Text="Private"></asp:CheckBox></P>
						<P>
							<asp:TextBox id="TextBoxComments" runat="server" Width="544px"></asp:TextBox>&nbsp;
							<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../images/btn_add_sp.gif" onclick="ImageButton1_Click"></asp:ImageButton></P>
						<P>
							<asp:Literal id="LiteralGuests" runat="server"></asp:Literal></P>
					</TD>
				</TR>
				<TR vAlign="middle" align="left">
					<TD vAlign="middle" noWrap colSpan="2" height="27">&nbsp; <IMG height="33" src="/images/bottom.gif" width="750" useMap="#Map" border="0"><MAP name="Map"><AREA title="Сделано в УРЛС УВД по Ивановской области" shape="RECT" alt="Сделано в УРЛС УВД по Ивановской области"
								coords="346,7,743,25" href="../About/about.aspx"><area title="На главную..." shape="RECT" alt="На главную..." coords="18,5,39,27" href="../index.aspx"><area title="Об УРЛС УВД" shape="RECT" alt="Об УРЛС УВД" coords="47,5,68,27"
								href="../About/about.aspx"><area title="Структура органов внутренних дел" shape="RECT" alt="Структура органов внутренних дел"
								coords="75,5,97,27" href="../Structure/structure.aspx"><area title="Поиск сотрудников" shape="RECT" alt="Поиск сотрудников" coords="104,5,125,27"
								href="../Search/search.aspx"><area title="Вакансии" shape="RECT" alt="Вакансии" coords="132,5,154,27" href="../Vakans/vakansy.aspx"><area title="Некомплект" shape="RECT" alt="Некомплект" coords="161,5,183,26" href="../Nekompl/nekompl.aspx"><area title="Качественные показатели" shape="RECT" alt="Качественные показатели" coords="190,5,212,26"
								href="../Kachestv/kachestv.aspx"><area title="Нормативные документы" shape="RECT" alt="Нормативные документы" coords="218,5,240,27"
								href="../Normatives/normatives.aspx"><area title="Бланки служебных документов" shape="RECT" alt="Бланки служебных документов"
								coords="247,5,269,26" href="../Blanks/blanks.aspx"><area title="Дисциплинарная практика" shape="RECT" alt="Дисциплинарная практика" coords="275,5,297,26"
								href="../Discipline/discipline.aspx"><area title="Письмо администратору..." shape="RECT" alt="Письмо администратору..." coords="305,5,327,27"
								href="../Toadmin/toadmin.aspx"></MAP></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
