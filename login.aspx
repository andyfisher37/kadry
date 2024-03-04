<%@ Page language="c#" Codebehind="login.aspx.cs" AutoEventWireup="True" Inherits="kadry.login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" УРЛС УМВД России по Ивановской области - авторизация...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<link href="Styles.css" rel="stylesheet">
		<link rel="shortcut icon" href="images/logo2.ico">
	    <style type="text/css">
            .style1
            {
                height: 8px;
            }
        </style>
	</HEAD>
	<BODY text="#000000" bottomMargin="0" vLink="#cc0000" aLink="#6666ff" link="#ff9966" bgColor="#00124b"
		leftMargin="0" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<TABLE height="783" cellSpacing="0" cellPadding="0" width="483" border="0" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD width="483" height="783">
					<form id="Form1" method="post" runat="server">
						<TABLE height="481" cellSpacing="0" cellPadding="0" width="781" border="0" ms_2d_layout="TRUE">
							<TR vAlign="top">
								<TD width="4" height="8"></TD>
								<TD width="777"></TD>
							</TR>
							<TR vAlign="top">
								<TD height="473"></TD>
								<TD>
									<TABLE id="Table2" height="472" cellSpacing="0" cellPadding="0" width="776" border="0">
										<TR>
											<TD width="92" height="97"></TD>
											<TD align="center" vAlign="top" height="97"><FONT face="Tahoma" color="#ffffff" size="1"><IMG height="115" alt="Телефон разработчика - (48-18-42)" src="\images\gerb.gif" width="100"></FONT></TD>
											<TD width="124" height="97"></TD>
										</TR>
										<TR>
											<TD width="92" class="style1"></TD>
											<TD align="center" vAlign="top" class="style1"></TD>
											<TD width="124" class="style1"></TD>
										</TR>
										<TR>
											<TD width="92" height="66"></TD>
											<TD vAlign="top" align="center" height="66">
												<P><FONT face="Tahoma" color="#ffffcc" size="2"><STRONG>Информационная система 
                                                    обработки данных "Кадры"</STRONG></FONT></P>
												<P><FONT face="Tahoma" color="#ffffcc" size="2"><STRONG>Управление МВД России по Ивановской области</STRONG></FONT></P>
                                                <P><FONT face="Tahoma" color="#ffffcc" size="2"><STRONG>&nbsp;Управление по работе с 
                                                    личным составом</STRONG></FONT></P>
											</TD>
											<TD width="124" height="66"></TD>
										</TR>
										<TR>
											<TD width="92"></TD>
											<TD align="center" vAlign="top"><FONT face="Tahoma" color="#ffffff" size="1">
											<br>
											</FONT></TD>
											<TD width="124"></TD>
										</TR>
										<TR>
											<TD width="92" height="13"></TD>
											<TD vAlign="top" align="center" height="13">
												<HR align="center" width="100%" SIZE="1" Color="yellow">
											</TD>
											<TD width="124" height="13"></TD>
										</TR>
										<TR>
											<TD width="92" height="106"></TD>
											<TD align="center" height="106"><FONT face="Tahoma" color="#ffffcc" size="2">
													<%--<TABLE id="Table1" height="72" cellSpacing="0" cellPadding="0" width="305" border="0">
														<TR>
															<TD align="left"><FONT color="#ffffcc" size="2">Имя пользователя:</FONT></TD>
															<TD>
																<asp:TextBox class="maintext" id="UserNameBox" tabIndex="1" runat="server" Font-Names="Verdana"
																	Font-Size="X-Small" ForeColor="Maroon" ToolTip="Имя пользователя" Width="165px" Height="22px"></asp:TextBox></TD>
														</TR>
														<TR>
															<TD align="left"><FONT color="#ffffcc" size="2">Пароль:&nbsp;</FONT></TD>
															<TD><INPUT class="maintext" id="PasswordBox" tabIndex="2" type="password" size="20" name="Password1"
																	runat="server"></TD>
														</TR>
													</TABLE>--%>
												<asp:Login ID="Login1" runat="server" BackColor="#00124B" BorderColor="#0033CC" 
                                                    BorderPadding="4" BorderStyle="Groove" BorderWidth="1px" Font-Names="Verdana" 
                                                    Font-Size="0.8em" ForeColor="#FFFFCC" onauthenticate="Login1_Authenticate" 
                                                    PasswordLabelText="Пароль: " RememberMeText="Запомнить мои учетные данные." 
                                                    ToolTip="Идентифицируйте себя!" UserNameLabelText=" Имя пользователя: ">
                                                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                                                    <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
                                                        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                                                    <TextBoxStyle Font-Size="0.8em" />
                                                    <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
                                                        ForeColor="White" />
                                                </asp:Login>
												</FONT>
											</TD>
											<TD width="124" height="106" align="center"></TD>
										</TR>
										<TR>
											<TD width="92"></TD>
											<TD align="center"><asp:label class="whitemess" id="message" runat="server" Width="513px" Height="32px" Visible="False"></asp:label></TD>
											<TD width="124"></TD>
										</TR>
										<TR>
											<TD width="92"></TD>
											<TD>
												<HR align="center" width="100%" SIZE="1" Color="yellow">
												&nbsp;</TD>
											<TD width="124"></TD>
										</TR>
										<TR>
											<TD width="92"></TD>
											<TD align="center">
												<FONT face="Tahoma" color="#ffffff" size="1">
													<asp:ImageButton id="ImageButton1" alt="Как зарегестрироваться" tabIndex="8" runat="server" ToolTip="Здесь вы узнаете как получить доступ к службе..."
														ImageUrl="/images/btn_howtoreg.gif" onclick="ImageButton1_Click"></asp:ImageButton></FONT>
											</TD>
											<TD width="124">&nbsp;</TD>
										</TR>
										<TR>
											<TD width="92">&nbsp;</TD>
											<TD align="center">
												&nbsp;</TD>
											<TD width="124">&nbsp;</TD>
										</TR>
										<TR>
											<TD align="center" colspan="3" valign="middle"><FONT face="Tahoma" color="#ffffff" size="1">© 2003-2013 Рыбаков А.Ю. Отделение прохождения службы и информационного обеспечения УРЛС УМВД России по Ивановской области (ст.1271 ГПК РФ)
											</FONT></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							&nbsp;&nbsp;&nbsp;
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
	</BODY>
</HTML>
