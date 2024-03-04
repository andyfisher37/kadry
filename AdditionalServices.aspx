<%@ Page language="c#" Codebehind="AdditionalServices.aspx.cs" AutoEventWireup="True" Inherits="kadry.AdditionalServices" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Дополнительные сервисы...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="Styles.css" rel="stylesheet">
	</HEAD>
	<BODY oncontextmenu="nomenu();" text="#000000" bottomMargin="0" vLink="#cc0000" aLink="#6666ff"
		link="#ff9966" bgProperties="fixed" bgColor="#ffffff" leftMargin="0" background="images/background.gif"
		topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="WIDTH: 720px; HEIGHT: 128px" cellSpacing="0" cellPadding="0"
				width="720" border="0">
				<TR>
					<TD><IMG alt="" src="/images/header_small.gif"></TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 1px" vAlign="top" align="center">ДОПОЛНИТЕЛЬНЫЕ 
                        СЕРВИСЫ</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 348px" vAlign="middle" align="center">
						<TABLE id="Table2" style="WIDTH: 503px; HEIGHT: 342px" cellSpacing="0" cellPadding="0"
							width="503" border="0">
							<TR>
								<TD>
									<asp:ImageButton id="ImageButton2" runat="server" ImageUrl="/images/btn_zvancontrol.gif" AlternateText="контроль присвоения званий" onclick="ImageButton2_Click"></asp:ImageButton></TD>
								<TD>
									<asp:ImageButton id="ImageButton3" runat="server" ImageUrl="/images/btn_certcontrol.gif" AlternateText="контроль служебных удостоверений" onclick="ImageButton3_Click"></asp:ImageButton></TD>
								<TD>
									<asp:ImageButton id="ImageButton4" runat="server" ImageUrl="/images/btn_doccontrol.gif" AlternateText="документооборот" onclick="ImageButton4_Click"></asp:ImageButton></TD>
							</TR>
							<TR>
								<TD>
									<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="/images/btn_pfilecontrol.gif" AlternateText="контроль регистрации личных дел" onclick="ImageButton1_Click"></asp:ImageButton></TD>
								<TD>
									<asp:ImageButton id="ImageButton5" runat="server" ImageUrl="/images/btn_sokrcontrol.gif" AlternateText="контроль сокращенных сотрудников" onclick="ImageButton5_Click"></asp:ImageButton></TD>
								<TD>
									<asp:ImageButton id="ImageButton6" runat="server" ImageUrl="/images/btn_inoutcontrol.gif" AlternateText="информация по принятым и уволенным" onclick="ImageButton6_Click"></asp:ImageButton></TD>
							</TR>
							<TR>
								<TD>
									<asp:ImageButton ID="ImageButton12" runat="server" 
                                        AlternateText="контроль первоначалки" ImageUrl="/images/btn_firsted.gif" 
                                        ToolTip="Контроль прохождения первоначальной подготовки..." 
                                        onclick="ImageButton12_Click" />
                                </TD>
								<TD>
									<asp:ImageButton id="ImageButton11" runat="server" 
                                        ImageUrl="/images/btn_moving.gif" 
                                        AlternateText="контроль перемещений личного состава..." 
                                        onclick="ImageButton11_Click"></asp:ImageButton></TD>
								<TD>
									<asp:ImageButton ID="ImageButton13" runat="server" 
                                        AlternateText="АИС Боеготовность" ImageUrl="/images/btn_sbp_stat.gif" 
                                        onclick="ImageButton13_Click" 
                                        ToolTip="Статистика боевой, физической и спец.подготовки..." />
                                </TD>
							</TR>
							<TR>
								<TD>
									<asp:ImageButton id="ImageButton7" runat="server" ImageUrl="/images/btn_hotcontrol.gif" AlternateText='командировки в "СКР"...' onclick="ImageButton7_Click"></asp:ImageButton></TD>
								<TD>
									<asp:ImageButton id="ImageButton10" runat="server" AlternateText="Аттестации..." ImageUrl="/images/btn_attestat.gif" onclick="ImageButton10_Click"></asp:ImageButton></TD>
								<TD>
									<asp:ImageButton ID="ImageButton14" runat="server" 
                                        ImageUrl="../images/btn_uvcontrol.gif" onclick="ImageButton14_Click" 
                                        ToolTip="Контроль сроков уведомлений..." />
                                </TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD>
									<asp:ImageButton id="ImageButton8" runat="server" ImageUrl="/images/btn_metody.gif" AlternateText="методические материалы" onclick="ImageButton8_Click"></asp:ImageButton></TD>
								<TD>&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
