<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewIsx.aspx.cs" Inherits="UK.ViewIsx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Исходящий на личное дело...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		
	    <style type="text/css">
            .style1
            {
                width: 282px;
            }
            .style2
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                width: 282px;
            }
            .style3
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 17px;
                width: 282px;
            }
            .style4
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 23px;
                width: 282px;
            }
            .style5
            {
                width: 30px;
            }
            .style6
            {
            }
        </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
	<form id="form1" runat="server">
    <TABLE id="Table1"
				cellSpacing="0" cellPadding="0" width="664" border="0">
				<TR>
					<TD align="center" class="style1"><IMG style="WIDTH: 136px; HEIGHT: 80px" height="80" alt="" src="images/gerb2.gif" width="136"></TD>
					<TD align="right">
						<asp:Label ID="SecLabel" runat="server" 
                            Text="СЕКРЕТНО&lt;br&gt;Экз.№____&lt;br&gt;(без приложения не секретно)"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD class="style2" align="center"><STRONG>МВД РОСCИИ</STRONG></TD>
					<TD align="center">
                        <asp:Label ID="PodrName" runat="server" Font-Names="Times New Roman" 
                            Font-Size="Medium" 
                            style="font-family: 'Times New Roman', Times, serif; font-size: medium"></asp:Label>
                    </TD>
				</TR>
				<TR>
					<TD class="style2" align="center"><STRONG>УПРАВЛЕНИЕ МИНИСТЕРСТВА ВНУТРЕННИХ ДЕЛ<br />
                        РОССИЙСКОЙ ФЕДЕРАЦИИ</STRONG></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="style2" align="center"><STRONG>ПО ИВАНОВСКОЙ ОБЛАСТИ</STRONG></TD>
					<TD align="center">
                        <asp:Label ID="PodrRuk" runat="server"></asp:Label>
                    </TD>
				</TR>
				<TR>
					<TD class="style3" align="center">(УМВД России по Ивановской области)</TD>
					<TD style="HEIGHT: 17px"></TD>
				</TR>
				<TR>
					<TD class="style4" align="center">УПРАВЛЕНИЕ ПО РАБОТЕ<br />
                        С ЛИЧНЫМ СОСТАВОМ</TD>
					<TD style="HEIGHT: 23px"></TD>
				</TR>
				<TR>
					<TD class="style2" align="center"><FONT size="1">153002, пр.Ленина д.37, г.Иваново</FONT></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="style2" align="center">__________________№_____________</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="style2" align="center">На №___________ от ______________</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD class="style2" align="center">&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
					
			<TABLE id="Table2"
				cellSpacing="0" cellPadding="0" width="664" border="0">
				<TR>
					<TD align="left">
                        &nbsp;&nbsp;&nbsp;<asp:Label ID="FirstLabel" runat="server"></asp:Label>
                        &nbsp;<asp:label id="PersInfo" runat="server" Font-Bold="True"></asp:label>
                    </TD>
				</TR>
				<TR>
					<TD align="left">
                        &nbsp;&nbsp;&nbsp;<asp:Label ID="OtherText" runat="server"></asp:Label>
                        </TD>
				</TR>
				<TR>
					<TD align="left" class="style6">
                        &nbsp;&nbsp;&nbsp;<asp:Label ID="Prilog" runat="server"></asp:Label>
                    </TD>
				</TR>
				</TABLE>
				<br>
				<br>
    <TABLE id="Table2"
				cellSpacing="0" cellPadding="0" width="664" border="0">
				<TR>
					<TD align="left" class="style6">
                        <asp:Label ID="RukDol" runat="server"></asp:Label>
                    </TD>
					<TD class="style5"></TD>
					<TD align="right">
                        <asp:Label ID="RukName" runat="server"></asp:Label>
                    </TD>
				</TR>
			</TABLE>
			<br>
			<br>
			<br>
			<br>
			<br>
			<TABLE id="Table3"
				cellSpacing="0" cellPadding="0" width="664" border="0">
				<TR>
					<TD align="left">
                        <asp:Label ID="Isp" runat="server" Font-Names="Verdana" Font-Size="X-Small"></asp:Label>
                        &nbsp;</TD>
				</TR>
				</TABLE>
    </form>
</body>
</html>
