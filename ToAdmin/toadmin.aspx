<%@ Page language="c#" Codebehind="toadmin.aspx.cs" AutoEventWireup="True" Inherits="kadry.ToAdmin.toadmin" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<title>Информационная система обработки данных "Кадры" - письмо администратору...</title>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
	<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
	<meta name="CODE_LANGUAGE" Content="C#">
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
	<link href="/Styles.css" rel="stylesheet">
		<body text="#000000" vLink="#000000" aLink="#000000" link="#000000" bgColor="#ffffff"
			leftMargin="0" background="/images/background.gif" topMargin="0" MS_POSITIONING="GridLayout"
			bottomMargin="0" bgProperties="fixed" rightMargin="0">
			<TABLE height="762" cellSpacing="0" cellPadding="0" width="593" border="0" ms_2d_layout="TRUE">
				<TR vAlign="top">
					<TD width="593" height="762">
						<form id="Form1" method="post" runat="server">
							<TABLE height="591" cellSpacing="0" cellPadding="0" width="760" border="0" ms_2d_layout="TRUE">
								<TR vAlign="top">
									<TD width="760" height="591">
										<TABLE height="590" cellSpacing="0" cellPadding="0" width="759" align="left" border="0">
											<TR>
												<TD align="center" height="70"><IMG SRC="/images/header_small.gif" ALT="Информационная система обработки данных "Кадры"" USEMAP="#Map2"
														BORDER="0"><MAP NAME="Map2"><AREA SHAPE="RECT" COORDS="244,51,499,82" HREF="../About/about.aspx" ALT="УРЛС УВД..." TITLE="УРЛС УВД..."></MAP></TD>
											</TR>
											<TR>
												<TD class="Header" align="center" height="3" vAlign="top">
													администратору...</TD>
											</TR>
											<TR>
												<TD align="center">
													<table border="1" align="center" bgColor="#D1D1D1" cellSpacing="0" cellPadding="0" height="260"
														width="565">
														<tr>
															<td align="right" width="151" height="31"><FONT face="Arial" size="2"><STRONG>От кого:</STRONG></FONT></td>
															<td width="358" height="31"><INPUT id="From" type="text" maxLength="100" size="60" runat="server"></td>
														</tr>
														<tr>
															<td align="right" width="151" height="5"><FONT face="Arial" size="2"><STRONG>Тема:</STRONG></FONT></td>
															<td width="358" height="5"><INPUT id="Subject" type="text" maxLength="256" size="60" runat="server"></td>
														</tr>
														<tr>
															<td align="right" width="151" height="172"><FONT face="Arial" size="2"><STRONG>Содержание:</STRONG></FONT></td>
															<td width="358" height="172">
																<P><TEXTAREA id="Text" rows="10" cols="45" runat="server">
																	</TEXTAREA></P>
															</td>
														</tr>
														<tr>
															<td align="right" width="151"><FONT face="Arial" size="2"><STRONG>Контактная информация:</STRONG></FONT></td>
															<td width="358"><INPUT id="Contact" type="text" maxLength="256" size="60" runat="server"></td>
														</tr>
													    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
													</table>
													<P>
														<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="/images/btn_sendmail.gif" onclick="ImageButton1_Click"></asp:ImageButton>
													</P>
													<P>
														<asp:Label class="admin_text" id="Info" runat="server" Width="490px" Visible="False"></asp:Label></P>
												</TD>
											</TR>
											<TR VALIGN="middle" ALIGN="left">
												<TD COLSPAN="2" HEIGHT="27" VALIGN="middle" NOWRAP>
													&nbsp; <IMG SRC="/images/bottom.gif" WIDTH="750" HEIGHT="33" USEMAP="#Map" BORDER="0"><MAP NAME="Map"><AREA SHAPE="RECT" COORDS="346,7,743,25" HREF="../About/about.aspx" ALT="Сделано в УРЛС УВД по Ивановской области"
															TITLE="Сделано в УРЛС УВД по Ивановской области"><area shape="RECT" coords="18,5,39,27" href="../index.aspx" alt="На главную..." title="На главную..."><area shape="RECT" coords="47,5,68,27" href="../About/about.aspx" alt="Об УРЛС УВД"
															title="Об УРЛС УВД"><area shape="RECT" coords="75,5,97,27" href="../Structure/structure.aspx" alt="Структура органов внутренних дел"
															title="Структура органов внутренних дел"><area shape="RECT" coords="104,5,125,27" href="../Search/search.aspx" alt="Поиск сотрудников"
															title="Поиск сотрудников"><area shape="RECT" coords="132,5,154,27" href="../Vakans/vakansy.aspx" alt="Вакансии"
															title="Вакансии"><area shape="RECT" coords="161,5,183,26" href="../Nekompl/nekompl.aspx" alt="Некомплект"
															title="Некомплект"><area shape="RECT" coords="190,5,212,26" href="../Kachestv/kachestv.aspx" alt="Качественные показатели"
															title="Качественные показатели"><area shape="RECT" coords="218,5,240,27" href="../Normatives/normatives.aspx" alt="Нормативные документы"
															title="Нормативные документы"><area shape="RECT" coords="247,5,269,26" href="../Blanks/blanks.aspx" alt="Бланки служебных документов"
															title="Бланки служебных документов"><area shape="RECT" coords="275,5,297,26" href="../Discipline/discipline.aspx" alt="Дисциплинарная практика"
															title="Дисциплинарная практика"><area shape="RECT" coords="305,5,327,27" href="../Toadmin/toadmin.aspx" alt="Письмо администратору..."
															title="Письмо администратору..."></MAP></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</form>
					</TD>
				</TR>
			</TABLE>
		</body>
</HTML>
