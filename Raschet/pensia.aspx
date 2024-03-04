<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Page language="c#" Codebehind="pensia.aspx.cs" AutoEventWireup="false" Inherits="kadry.Raschet.pensia" codePage="65001"%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - расчет на пенсию...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	    <style type="text/css">
            .style1
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                width: 110px;
            }
        </style>
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#000000" aLink="#000000" link="#000000" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 584px; POSITION: absolute; TOP: 8px; HEIGHT: 103px"
				cellSpacing="0" cellPadding="0" width="584" bgColor="antiquewhite" border="0">
				<TR>
					<TD class="Header" vAlign="middle" align="center" colSpan="3">Дополнительные 
						параметры для расчета выслуги лет:</TD>
				</TR>
				<TR>
					<TD class="Header" vAlign="middle" align="center" colSpan="3"><hr>
					</TD>
				</TR>
				<TR>
					<TD class="Header" vAlign="middle" align="center" colSpan="3">
						<asp:Label class="UserInfo" id="FIO" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD class="Header" vAlign="middle" align="center" colSpan="3">&nbsp;</TD>
				</TR>
				<TR>
					<TD class="style1" align="center">
						Дата расчета:</TD>
					<TD class="maintext" align="center">
						<ew:MaskedTextBox id="Date" tabIndex="5" runat="server" ToolTip="Дата расчета" 
                            Text="01.01.2004" Mask="99.99.9999"
							RequiredErrorText="Необходима дата..." RequiredErrorMessage="Необходима дата..." ErrorText="Неправильная дата"
							ErrorMessage="Неправильная дата" Font-Bold="True" ForeColor="#400000" Font-Names="Verdana" Width="100px"
							Font-Size="X-Small"></ew:MaskedTextBox></TD>
					<TD class="maintext" align="center">
						<asp:ImageButton id="GoButton" runat="server" ToolTip="Сделать расчет" ImageUrl="/images/btn_pensia.gif"></asp:ImageButton></TD>
				</TR>
				</TABLE>
		</form>
	</body>
</HTML>
