<%@ Page language="c#" Codebehind="Exchange.aspx.cs" AutoEventWireup="True" Inherits="UK.Exchange" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационно-аналитическа служба УРЛС УВД - обмен файлами...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 104; LEFT: 8px; WIDTH: 824px; POSITION: absolute; TOP: 8px; HEIGHT: 176px"
				cellSpacing="1" cellPadding="1" width="824" border="0" bgColor="moccasin">
				<TR>
					<TD align="center" colSpan="3"><STRONG><FONT color="#990033">Отправка файлов...</FONT></STRONG></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"><hr>
					</TD>
				</TR>
				<TR>
					<TD align="right"><FONT size="2">От кого, примечание...</FONT></TD>
					<TD>
						<asp:TextBox id="At_TextBox" runat="server" Width="600px"></asp:TextBox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right"><FONT size="2">Что посылаем:</FONT></TD>
					<TD><INPUT style="WIDTH: 600px; HEIGHT: 22px" type="file" size="80" id="File1" name="File1"
							runat="server"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right"><FONT size="2">Кому:</FONT></TD>
					<TD>
						<asp:DropDownList id="AdrList" runat="server" Width="520px">
							<asp:ListItem Value="1" Selected="True">Новичков Н.М. (\\Carhevski\ОБЩАЯ ПАПКА\*.*)</asp:ListItem>
							<asp:ListItem Value="2">Власов А.А. (\\Alexey\ОБЩАЯ ПАПКА\*.*)</asp:ListItem>
							<asp:ListItem Value="3">Лукин И.Р. (\\Comp405_2\Общая папка\*.*)</asp:ListItem>
							<asp:ListItem Value="4">Орехов В.Б. (Рабочий стол)</asp:ListItem>
							<asp:ListItem Value="5">Москалев А.Е. (сетевая папка\*.*)</asp:ListItem>
							<asp:ListItem Value="6">Куликова Л.Ю. (\\Comp4\D\*.*)</asp:ListItem>
							<asp:ListItem Value="7">Глазков О.Д. (\\Comp409\общая папка\*.*)</asp:ListItem>
							<asp:ListItem Value="8">Быков М.Б. (\\Инспекция\общая папка\)</asp:ListItem>
							<asp:ListItem Value="9">Бабанова М.В. (\\Comp405_2\Общая папка\*.*)</asp:ListItem>
							<asp:ListItem Value="10">Баранов А.С. (\\Comp409\Общая папка\*.*)</asp:ListItem>
							<asp:ListItem Value="11">Трунов С.А. (\\Comp409\Общая папка\*.*)</asp:ListItem>
							<asp:ListItem Value="12">Психологи (\\Психолог\общая папка\*.*)</asp:ListItem>
							<asp:ListItem Value="13">Куликов Д.В. (\\Куликов\общая папка\*.*)</asp:ListItem>
						</asp:DropDownList></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"><hr>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="/images/btn_send.gif" onclick="ImageButton1_Click"></asp:ImageButton></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
