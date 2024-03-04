<%@ Page language="c#" Codebehind="denied_expl.aspx.cs" AutoEventWireup="True" Inherits="kadry.denied_expl" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - подробнее об ограничениях 
			доступа...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="Styles.css" rel="stylesheet">
	</HEAD>
	<BODY text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 752px; HEIGHT: 348px" height="348" cellSpacing="0" cellPadding="0"
				width="752" align="left" border="0" HSPACE="0" VSPACE="0">
				<TR>
					<TD style="WIDTH: 750px; HEIGHT: 60px" height="60"><IMG alt="" src="/images/header_small.gif" width="750" border="0"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 750px; HEIGHT: 454px" vAlign="top" align="center" class="maintext">
						<P>&nbsp;</P>
						<P class="maintext">
							Уважаемый &nbsp;
							<asp:Label class="Header" id="UserName" runat="server"></asp:Label>
							&nbsp;!</P>
						<P class="maintext">В соответствии с Вашим рапортом, для Вас действуют следующие 
							ограничения на доступ:</P>
						<P class="maintext" align="center">
							<TABLE class="maintext" id="Table1" style="WIDTH: 745px; HEIGHT: 125px" cellSpacing="1"
								cellPadding="1" width="745" bgColor="#D1D1D1" border="0" runat="server">
								<TR>
									<TD style="WIDTH: 200px" align="right"><FONT color="darkblue">Запрещен доступ к 
											службам:</FONT></TD>
									<TD align="left">
										<asp:Label class="smalltext" id="sl_label" runat="server" Width="500px" CssClass="smalltext"></asp:Label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 200px" align="right"><FONT color="darkblue">Разрешен доступ к 
											службам:</FONT></TD>
									<TD align="left">
										<asp:Label class="smalltext" id="sl_label2" runat="server" Width="500px" CssClass="smalltext"></asp:Label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 200px" align="right"><FONT color="darkblue">Подразделениям:</FONT></TD>
									<TD align="left">
										<asp:Label class="smalltext" id="podr_label" runat="server" Width="500px" CssClass="smalltext"></asp:Label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 200px" align="right"><FONT color="darkblue">Структурным 
											подразделениям:</FONT></TD>
									<TD align="left">
										<asp:Label class="smalltext" id="pdr_label" runat="server" Width="500px" CssClass="smalltext"></asp:Label></TD>
								</TR>
							</TABLE>
						</P>
						<P class="maintext" align="center">&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
