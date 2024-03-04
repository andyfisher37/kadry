<%@ Page language="c#" Codebehind="HotVak.aspx.cs" AutoEventWireup="True" Inherits="kadry.Vakans.HotVak" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - 50 самых "старых" вакансий!</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" MARGINWIDTH="0"
		MARGINHEIGHT="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<div class="Header">50 Самых "старых" вакансий УВД по Ивановской области!
				</div>
				<hr>
				<asp:datagrid id=Grid runat="server" DataSource="<%# hotvakDataSet %>" DataMember="Table" AutoGenerateColumns="False" BorderColor="Black" BorderWidth="1px" BackColor="LemonChiffon" Font-Names="Verdana" Width="857px">
					<ItemStyle Font-Size="XX-Small"></ItemStyle>
					<HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" ForeColor="Black"
						BackColor="Moccasin"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="№">
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="PODRAZDEL" SortExpression="PODRAZDEL" HeaderText="Подразделение">
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="NAM_OF_SLU" SortExpression="NAM_OF_SLU" HeaderText="Служба">
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="NAM_OF_DOL" SortExpression="NAM_OF_DOL" HeaderText="Должность">
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="TEXT" SortExpression="TEXT" HeaderText="Ист.фин.">
							<HeaderStyle Width="5%"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center" ForeColor="#006633"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="DATA_VAK" SortExpression="DATA_VAK" HeaderText="Дата вакансии" DataFormatString="{0:d}">
							<ItemStyle HorizontalAlign="Center" ForeColor="#CC0033"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
				</asp:datagrid>
				<br>
				<hr>
			</center>
		</form>
	</body>
</HTML>
