<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %><%@ Page language="c#" Codebehind="regform.aspx.cs" AutoEventWireup="True" Inherits="kadry.ReRegistration.regform" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>regform</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 688px; POSITION: absolute; TOP: 0px; HEIGHT: 534px"
				cellSpacing="1" cellPadding="1" width="688" border="0">
				<TR>
					<TD class="Header" style="HEIGHT: 110px" align="center" colSpan="3">
						<P><IMG alt="" src="../images/Rereg.gif"></P>
						<P>
							<hr>
						<P></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 49px" align="center" colSpan="3">
						<P><FONT face="Times" size="2">&nbsp; </FONT>
							<asp:label id="TitleText" runat="server" Font-Names="Verdana" Font-Size="X-Small" ForeColor="Maroon"
								Width="674px" class="admin_text"></asp:label></P>
						<P><FONT face="Times" size="2">&nbsp;С уважением, (<FONT color="#000066">администратор</FONT>)</FONT></P>
						<hr>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 1px; HEIGHT: 185px"></TD>
					<TD align="center" class="label2" style="HEIGHT: 185px">
						<TABLE class="maintext" id="Table2" style="WIDTH: 479px; HEIGHT: 152px" cellSpacing="0"
							cellPadding="0" width="479" bgColor="#ffe4c4" border="0">
							<TR>
								<TD class="maintext" style="WIDTH: 154px; HEIGHT: 27px" align="right">Старый 
									пароль:</TD>
								<TD class="maintext" align="left" style="WIDTH: 158px; HEIGHT: 27px">
									<asp:TextBox id="OldPassword" runat="server"></asp:TextBox></TD>
								<TD class="maintext" style="WIDTH: 158px; HEIGHT: 27px" align="left"></TD>
							</TR>
							<TR>
								<TD class="maintext" align="center" colSpan="3" style="HEIGHT: 12px">
									<HR>
								</TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 154px; HEIGHT: 29px" align="right">Новый пароль:</TD>
								<TD class="maintext" align="left" style="WIDTH: 158px; HEIGHT: 29px">
									<asp:TextBox id="NewPassword1" runat="server"></asp:TextBox></TD>
								<TD class="maintext" style="WIDTH: 158px; HEIGHT: 29px" align="left">
									<asp:Button id="GenPass" runat="server" Width="149px" Text="предложить пароль..." onclick="GenPass_Click"></asp:Button></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 154px; HEIGHT: 29px" align="right">Подтверждение 
									пароля:</TD>
								<TD class="maintext" align="left" style="WIDTH: 158px; HEIGHT: 29px">
									<asp:TextBox id="NewPassword2" runat="server"></asp:TextBox></TD>
								<TD class="maintext" style="WIDTH: 158px; HEIGHT: 29px" align="left"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3" style="HEIGHT: 39px">
									<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../images/btn_next.gif" onclick="ImageButton1_Click"></asp:ImageButton></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3">
									<asp:Label class="Attantion" id="Result" runat="server" Width="460px"></asp:Label></TD>
							</TR>
						</TABLE>
						<P>*Введенный пароль должен&nbsp;содержать не менее 6 символов !</P>
					</TD>
					<TD style="HEIGHT: 185px"></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<hr>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
