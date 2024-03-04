<%@ Page language="c#" Codebehind="DetailPage_txt.aspx.cs" AutoEventWireup="True" Inherits="UK.DetailPage_txt" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Служебная карточка...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="0">
				<TR>
					<TD colSpan="3"><IMG style="WIDTH: 632px; HEIGHT: 18px" height="18" alt="Служебная карточка (Форма №2)"
							src="images/sc-header.gif" width="632"></TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="center" colSpan="3"><asp:label id="TitleText" runat="server" Font-Bold="True"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 363px; HEIGHT: 211px" vAlign="top">
						<TABLE id="Table2" style="WIDTH: 472px; HEIGHT: 115px" cellSpacing="0" cellPadding="0"
							border="0">
							<TR>
								<TD style="WIDTH: 117px; HEIGHT: 15px" align="left"><FONT size="2" color="#990033">Дата 
										рождения:</FONT></TD>
								<TD style="WIDTH: 251px; HEIGHT: 15px" align="left"><FONT size="1"><asp:label id="Label1" runat="server"></asp:label></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 117px; HEIGHT: 17px" align="left"><FONT size="2" color="#990033">Место 
										рождения:</FONT></TD>
								<TD style="WIDTH: 251px; HEIGHT: 17px" align="left"><FONT size="1"><asp:label id="Label2" runat="server"></asp:label></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 117px" align="left"><FONT size="2" color="#990033">Национальность:</FONT></TD>
								<TD style="WIDTH: 251px" align="left"><FONT size="1"><asp:label id="Label3" runat="server"></asp:label></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 117px" align="left"><FONT size="2" color="#990033">Личный номер:</FONT></TD>
								<TD style="WIDTH: 251px" align="left"><FONT size="1"><asp:label id="Label4" runat="server"></asp:label></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 117px" vAlign="top" align="left"><FONT size="2" color="#990033">Образование:</FONT></TD>
								<TD style="WIDTH: 251px" align="left"><FONT size="1"><asp:label id="Label5" runat="server"></asp:label></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 117px; HEIGHT: 12px" vAlign="top" align="left"><FONT size="2" color="#990033">Служба 
										в ВС:</FONT></TD>
								<TD style="WIDTH: 251px; HEIGHT: 12px" align="left"><FONT size="1"><asp:label id="Label6" runat="server"></asp:label></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 117px; HEIGHT: 20px" align="left" colSpan="2">
									<hr width="440" SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 117px" align="left"><FONT size="2" color="#990033">Гражданский стаж:</FONT></TD>
								<TD style="WIDTH: 251px" align="left">
									<asp:Table id="workTable" runat="server" BorderWidth="1px" Font-Size="XX-Small" CellPadding="0"
										CellSpacing="0" GridLines="Both" BorderColor="Black" Width="322px">
										<asp:TableRow ForeColor="Navy" Font-Size="XX-Small">
											<asp:TableCell HorizontalAlign="Center" Text="с.."></asp:TableCell>
											<asp:TableCell HorizontalAlign="Center" Text="..по"></asp:TableCell>
											<asp:TableCell HorizontalAlign="Center" Text="должность, организация"></asp:TableCell>
										</asp:TableRow>
									</asp:Table></TD>
							</TR>
						</TABLE>
						<HR width="440" SIZE="1">
					</TD>
					<TD style="WIDTH: 65px; HEIGHT: 211px"></TD>
					<TD vAlign="middle" align="center" style="HEIGHT: 211px">
						<asp:Image id="Photo" runat="server" Height="150px" Width="110px" AlternateText="Фото" BorderWidth="1px"></asp:Image></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 363px; HEIGHT: 11px"><FONT color="#990033" size="2">Служба в органах 
							внутренних дел:</FONT></TD>
					<TD style="WIDTH: 65px; HEIGHT: 11px"></TD>
					<TD align="center" style="HEIGHT: 11px">
						<asp:Label id="Label7" runat="server" Font-Size="XX-Small"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 363px" colSpan="3">
						<asp:Table id="zTable" runat="server" BorderWidth="1px" Width="632px" Font-Size="XX-Small"
							CellPadding="0" CellSpacing="0" GridLines="Both" BorderColor="Black">
							<asp:TableRow ForeColor="Navy">
								<asp:TableCell HorizontalAlign="Center" Text="Звание"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Прик. ОВД"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="№"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата прик."></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Присвоено"></asp:TableCell>
							</asp:TableRow>
						</asp:Table></TD>
				</TR>
				<TR>
					<TD colSpan="3"><FONT color="#990033" size="2">Послужной список: </FONT>
						<asp:label id="Label8" runat="server" Font-Size="XX-Small"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 363px" colSpan="3">
						<asp:Table id="swTable" runat="server" BorderWidth="1px" Width="632px" Font-Size="XX-Small"
							CellPadding="0" CellSpacing="0" GridLines="Both" BorderColor="Black">
							<asp:TableRow ForeColor="Navy">
								<asp:TableCell HorizontalAlign="Center" Text="С..."></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Звание"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Должность"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Подразделение"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Статус"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Прик.ОВД"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="№"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата прик."></asp:TableCell>
							</asp:TableRow>
						</asp:Table></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 363px" colSpan="3"><FONT color="#990033" size="2">Командировки: </FONT>
						<asp:label id="Label9" runat="server" Font-Size="XX-Small"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 363px" colSpan="3">
						<asp:Table id="kTable" runat="server" Width="632px" BorderColor="Black" GridLines="Both" CellSpacing="0"
							CellPadding="0" Font-Size="XX-Small" BorderWidth="1px">
							<asp:TableRow ForeColor="Navy">
								<asp:TableCell HorizontalAlign="Center" Text="с..."></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="..по"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Коэффиц.выслуги"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Легенда"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Приказ"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="от"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="№"></asp:TableCell>
							</asp:TableRow>
						</asp:Table></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 363px" colSpan="3"><FONT color="#990033" size="2">Взыскания: </FONT>
						<asp:label id="Label10" runat="server" Font-Size="XX-Small"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 363px" colSpan="3">
						<asp:Table id="nakTable" runat="server" Width="632px" BorderColor="Black" GridLines="Both"
							CellSpacing="0" CellPadding="0" Font-Size="XX-Small" BorderWidth="1px">
							<asp:TableRow ForeColor="Navy">
								<asp:TableCell HorizontalAlign="Center" Text="Наложено"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Приказ"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="№"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Взыскание"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="За что..."></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Снято"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Кто снял"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="№ Пр."></asp:TableCell>
							</asp:TableRow>
						</asp:Table></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 363px" colSpan="3"><FONT color="#990033" size="2">Поощрения: </FONT>
						<asp:label id="Label11" runat="server" Font-Size="XX-Small"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 363px" colSpan="3">
						<asp:Table id="pooTable" runat="server" Width="632px" BorderColor="Black" GridLines="Both"
							CellSpacing="0" CellPadding="0" Font-Size="XX-Small" BorderWidth="1px">
							<asp:TableRow ForeColor="Navy">
								<asp:TableCell HorizontalAlign="Center" Text="Вид поощрения"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Причина"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Приказ"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="№"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата"></asp:TableCell>
							</asp:TableRow>
						</asp:Table></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 363px"></TD>
					<TD style="WIDTH: 65px"></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
