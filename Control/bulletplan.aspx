<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bulletplan.aspx.cs" Inherits="kadry.Control.BulletPlan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Информационная система обработки данных "Кадры" - Расчет численности сотрудников для планирования стрельб</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <link href="/Styles.css" rel="stylesheet">
</head>
<body text="#000000" bottomMargin="0" vLink="#cc66ff" aLink="#0066ff" link="#0000ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
    <form id="form1" runat="server">
    <TABLE style="WIDTH: 759px; HEIGHT: 590px" height="590" cellSpacing="0" cellPadding="0"
				width="759" align="left" border="0">
				<TR>
					<TD style="HEIGHT: 70px" align="center"><IMG alt="" src="/images/header_small.gif" width="750" useMap="#Map2" border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP></TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 3px" vAlign="top" align="center" height="3">Расчет численности сотрудников для планирования стрельб</TD>
				</TR>
				<TR>
					<TD class="maintext" style="HEIGHT: 355px" vAlign="top" align="center">
						<P>
							<asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Расчет" 
                                ImageUrl="..//images/btn_load_data.gif" onclick="ImageButton1_Click" 
                                ToolTip="Расчет!" />
                        </P>
						<asp:Label ID="Title1" runat="server" CssClass="maintext"></asp:Label>
						<br>
					    <asp:table id="Table" runat="server" Width="752px" BorderColor="Black" Font-Size="XX-Small"
							GridLines="Both" CellPadding="1" CellSpacing="0" BackColor="#CCCCCC" Font-Names="Verdana" 
                            BorderWidth="1px">
							<asp:TableRow BackColor="PowderBlue" Font-Size="XX-Small" Font-Names="Verdana">
								<asp:TableCell HorizontalAlign="Center" Text="Наименование подразделения"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Штат всего"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Факт всего"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Штат &quot;с оружием&quot;"></asp:TableCell>
								<asp:TableCell runat="server" HorizontalAlign="Center">Факт &quot;с оружием&quot;</asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" 
                                    Text="Штат &quot;без оружия&quot;"></asp:TableCell>
								<asp:TableCell runat="server" HorizontalAlign="Center">Факт &quot;без оружия&quot;</asp:TableCell>
							</asp:TableRow>
						</asp:table>
					    <br />
                        <asp:Label ID="Title2" runat="server" CssClass="maintext"></asp:Label>
					    <asp:table id="Table2" runat="server" Width="752px" BorderColor="Black" Font-Size="XX-Small"
							GridLines="Both" CellPadding="1" CellSpacing="0" BackColor="#CCCCCC" Font-Names="Verdana" 
                            BorderWidth="1px">
							<asp:TableRow BackColor="PowderBlue" Font-Size="XX-Small" Font-Names="Verdana">
								<asp:TableCell HorizontalAlign="Center" Text="Наименование подразделения"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Штат всего"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Факт всего"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Штат &quot;с оружием&quot;"></asp:TableCell>
								<asp:TableCell runat="server" HorizontalAlign="Center">Факт &quot;с оружием&quot;</asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" 
                                    Text="Штат &quot;без оружия&quot;"></asp:TableCell>
								<asp:TableCell runat="server" HorizontalAlign="Center">Факт &quot;без оружия&quot;</asp:TableCell>
							</asp:TableRow>
						</asp:table>
					</TD>
				</TR>
				<TR vAlign="middle" align="left">
					<TD vAlign="middle" noWrap colSpan="2" height="27">&nbsp; </TD>
				</TR>
			</TABLE>
    </form>
</body>
</html>
