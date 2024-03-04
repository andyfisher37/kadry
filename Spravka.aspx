<%@ Page language="c#" Codebehind="Spravka.aspx.cs" AutoEventWireup="True" Inherits="UK.Spravka" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Справка о прохождении службы...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="C#" name="CODE_LANGUAGE">
		<link href="Styles.css" rel="stylesheet">
	    
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1"	cellSpacing="0" cellPadding="0" border="0" width="800">
				<TR>
					<TD align="center">
                    <IMG style="WIDTH: 135px; HEIGHT: 75px" height="75" alt="герб" src="images/gerb2.gif" width="135">
                    </TD>
					<TD align="right" rowspan="11" valign="top">
					<P>Для предоставления по месту требования</P>
					</TD>
				</TR>
				<TR>
					<TD align="center"><STRONG>МВД РОСCИИ</STRONG></TD>
				</TR>
				<TR>
					<TD align="center"><STRONG>УПРАВЛЕНИЕ МИНИСТЕРСТВА<br />
                        ВНУТРЕННИХ ДЕЛ<br />
                                        &nbsp;РОССИЙСКОЙ ФЕДЕРАЦИИ</STRONG></TD>
				</TR>
				<TR>
					<TD align="center"><STRONG>ПО ИВАНОВСКОЙ ОБЛАСТИ</STRONG></TD>
				</TR>
				<TR>
					<TD align="center">(УМВД России по 
						Ивановской области)</TD>
				</TR>
				<TR>
					<TD align="center"><FONT size="2">пр.Ленина д.37, 
							г.Иваново, 153002</FONT></TD>
				</TR>
				<TR>
					<TD align="center">&nbsp;</TD>
				</TR>
				<TR>
					<TD align="center">УПРАВЛЕНИЕ ПО РАБОТЕ<br />
                        С ЛИЧНЫМ СОСТАВОМ</TD>
				</TR>
				<TR>
					<TD align="center" >&nbsp;</TD>
				</TR>
				<TR>
					<TD align="center" >от &quot;___&quot;____________№_________<br />
                        на №________ от &quot;___&quot;__________</TD>
				</TR>
				<TR>
					<TD align="center" >&nbsp;</TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0" width="800">
				<TR>
					<TD align="center" colSpan="3">
                        <br />
                        <br />
                        С П Р А В К А №________<br />
                        <br />
                        </TD>
				</TR>
				<TR>
					<TD colSpan="3" align="justify">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="Name" runat="server"></asp:label>, 
						действительно&nbsp;
						<asp:Label id="status" runat="server"></asp:Label>
						&nbsp;в органах внутренних дел&nbsp;с
						<asp:label id="DataPost" runat="server"></asp:label>&nbsp;по 
						<asp:Label ID="DataEnd" runat="server" ></asp:Label>.
                        <asp:Label ID="UvolInfo" runat="server"></asp:Label>
                    </TD>
				</TR>
				<TR>
					<TD colspan="3">
                        <br />
                    </TD>
				</TR>
				<TR>
					<TD>
                        <asp:Label ID="ruk_dol" runat="server"></asp:Label>
                    </TD>
					<TD></TD>
					<TD align="right">
                        &nbsp;
					</TD>
				</TR>
				<TR>
					<TD>
                        <asp:Label ID="ruk_zvan" runat="server"></asp:Label>
                    </TD>
					<TD></TD>
					<TD align="right">
                        <asp:Label ID="ruk_name" runat="server"></asp:Label>
                        </TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
