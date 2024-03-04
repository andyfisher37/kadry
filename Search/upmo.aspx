<%@ Page language="c#" Codebehind="upmo.aspx.cs" AutoEventWireup="True" Inherits="UK.Search.upmo" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Поиск</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<br>
			<center>
				<font face="Verdana" color="#000066" size="3">Поиск в Адресно-Справочной Базе </font>
				<hr>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="1">
					<TR>
						<TD>Фамилия</TD>
						<TD>
							<asp:TextBox id="TextBox1" runat="server"></asp:TextBox></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD>Имя</TD>
						<TD>
							<asp:TextBox id="TextBox2" runat="server"></asp:TextBox></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD>Отчество</TD>
						<TD>
							<asp:TextBox id="TextBox3" runat="server"></asp:TextBox></TD>
						<TD></TD>
					</TR>
				</TABLE>
				<br>
				<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../images/iskat.gif" onclick="ImageButton1_Click"></asp:ImageButton>
				<br>
				<br>
				<hr>
				<asp:Label id="label" runat="server"></asp:Label>
				<asp:DataGrid id="Grid" runat="server" DataSource="<%# upmoDataSet %>" DataMember="T001" BorderColor="#000099" BorderWidth="1px" AutoGenerateColumns="False" Font-Names="Verdana" Width="737px">
					<ItemStyle Font-Size="XX-Small"></ItemStyle>
					<HeaderStyle Font-Size="X-Small"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="FAM" SortExpression="FAM" HeaderText="Фамилия"></asp:BoundColumn>
						<asp:BoundColumn DataField="IMJ" SortExpression="IMJ" HeaderText="Имя"></asp:BoundColumn>
						<asp:BoundColumn DataField="OTCH" SortExpression="OTCH" HeaderText="Отчество"></asp:BoundColumn>
						<asp:BoundColumn DataField="D_ROJD" SortExpression="D_ROJD" HeaderText="День"></asp:BoundColumn>
						<asp:BoundColumn DataField="M_ROJD" SortExpression="M_ROJD" HeaderText="Месяц"></asp:BoundColumn>
						<asp:BoundColumn DataField="Y_ROJD" SortExpression="Y_ROJD" HeaderText="Год"></asp:BoundColumn>
						<asp:BoundColumn DataField="KRAJ" SortExpression="KRAJ" HeaderText="Область"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid>
			</center>
		</form>
	</body>
</HTML>
