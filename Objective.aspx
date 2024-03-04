<%@ Page language="c#" Codebehind="Objective.aspx.cs" AutoEventWireup="True" Inherits="UK.Objective" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - справка-объективка...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	    <style type="text/css">
            .style1
            {
                font-size: 4.67295e-039;
            }
        </style>
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<!--<form id="Form1" method="post" runat="server">-->
		<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 559px; POSITION: absolute; TOP: 0px"
			cellSpacing="0" cellPadding="0" width="559" align="center" border="0">
			<TR>
				<TD style="WIDTH: 659px; HEIGHT: 58px" vAlign="middle" align="right" colSpan="2" rowSpan="1">
					<P><FONT style="FONT-SIZE: 9px; COLOR: black; LINE-HEIGHT: 9px; FONT-FAMILY: Tahoma, 'Times New Roman', Verdana"><FONT face="Times New Roman"><U>Приложение 
									№3&nbsp;</U><br>
								к Правилам оформления и
								<br>
								ведения личных дел рядового и начальствующего состава
								<br>
								органов внутренних дел Российской Федерации</FONT></FONT></P>
				</TD>
			</TR>
			<TR>
				<TD style="WIDTH: 659px; HEIGHT: 17px" vAlign="top" align="center">
					<P class="style1"><STRONG>С П Р А В К А - О Б Ъ Е К Т И В К А</STRONG></P>
				</TD>
			</TR>
			<TR>
				<TD class="maintext" style="WIDTH: 659px; HEIGHT: 483px" vAlign="top" align="center"
					colSpan="2">
					<TABLE id="Table2" style="WIDTH: 616px; HEIGHT: 576px; font-size: small; font-family: 'Times New Roman', Times, serif;" 
                        borderColor="#000000" cellSpacing="0"
						cellPadding="0" width="616" border="1">
						<TR>
							<TD style="WIDTH: 25px; HEIGHT: 38px" vAlign="middle"><FONT face="Times New Roman" size="2">1.</FONT></TD>
							<TD style="WIDTH: 274px; HEIGHT: 38px"><FONT face="Times New Roman" size="2">Фамилия, 
									имя, отчество</FONT></TD>
							<TD style="HEIGHT: 38px" align="center"><FONT size="2"><asp:label id="text_fio" 
                                    Width="360px" runat="server" Font-Names="Times New Roman"></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 25px; HEIGHT: 40px" vAlign="middle"><FONT face="Times New Roman" size="2">2.</FONT></TD>
							<TD style="WIDTH: 274px; HEIGHT: 40px"><FONT face="Times New Roman" size="2">Специальное 
									(воинское) звание</FONT></TD>
							<TD style="HEIGHT: 40px" align="center"><FONT size="2"><asp:label id="text_zvan" 
                                    Width="360px" runat="server" Font-Names="Times New Roman"></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 25px; HEIGHT: 36px" vAlign="middle"><FONT face="Times New Roman" size="2">3.</FONT></TD>
							<TD style="WIDTH: 274px; HEIGHT: 36px"><FONT face="Times New Roman" size="2">Должность</FONT></TD>
							<TD style="HEIGHT: 36px" align="center"><FONT size="2"><asp:label id="text_dolz" 
                                    Width="360px" runat="server" Font-Names="Times New Roman"></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 25px; HEIGHT: 36px" vAlign="middle"><FONT face="Times New Roman" size="2">4.</FONT></TD>
							<TD style="WIDTH: 274px; HEIGHT: 36px"><FONT face="Times New Roman" size="2">Место 
									службы</FONT></TD>
							<TD style="HEIGHT: 36px" align="center"><FONT size="2"><asp:label id="text_podr" 
                                    Width="360px" runat="server" Font-Names="Times New Roman"></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 25px; HEIGHT: 36px" vAlign="middle"><FONT face="Times New Roman" size="2">5.</FONT></TD>
							<TD style="WIDTH: 274px; HEIGHT: 36px"><FONT face="Times New Roman" size="2">Число, 
									месяц и год рождения</FONT></TD>
							<TD style="HEIGHT: 36px" align="center"><FONT size="2">
                                <asp:label id="text_borndate" Width="360px" runat="server" 
                                    Font-Names="Times New Roman"></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 25px; HEIGHT: 36px" vAlign="middle"><FONT face="Times New Roman" size="2">6.</FONT></TD>
							<TD style="WIDTH: 274px; HEIGHT: 36px"><FONT face="Times New Roman" size="2">Национальность</FONT></TD>
							<TD style="HEIGHT: 36px" align="center"><FONT size="2"><asp:label id="text_nation" 
                                    Width="360px" runat="server" Font-Names="Times New Roman"></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 25px; HEIGHT: 33px" vAlign="middle"><FONT face="Times New Roman" size="2">7.</FONT></TD>
							<TD style="WIDTH: 274px; HEIGHT: 33px"><FONT face="Times New Roman" size="2">Семейное 
									положение</FONT></TD>
							<TD style="HEIGHT: 33px" align="center"><FONT size="2"><asp:label id="text_family" 
                                    Width="360px" runat="server" Font-Names="Times New Roman"></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 25px; HEIGHT: 34px" vAlign="middle"><FONT face="Times New Roman" size="2">8.</FONT></TD>
							<TD style="WIDTH: 274px; HEIGHT: 34px"><FONT face="Times New Roman" size="2">Место 
									рождения</FONT></TD>
							<TD style="HEIGHT: 34px" align="center"><FONT size="2">
                                <asp:label id="text_bornplace" Width="360px" runat="server" 
                                    Font-Names="Times New Roman"></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 25px; HEIGHT: 37px" vAlign="middle"><FONT face="Times New Roman" size="2">9.</FONT></TD>
							<TD style="WIDTH: 274px; HEIGHT: 37px"><FONT face="Times New Roman" size="2">Образование</FONT></TD>
							<TD style="HEIGHT: 37px" align="center"><FONT size="2"><asp:label id="text_typeobr" 
                                    Width="360px" runat="server" Font-Names="Times New Roman"></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 25px; HEIGHT: 49px" vAlign="middle"><FONT face="Times New Roman" size="2">10.</FONT></TD>
							<TD style="WIDTH: 274px; HEIGHT: 49px">
								<P class="MsoNormal"><SPAN style="FONT-SIZE: 12pt; COLOR: black; mso-bidi-font-size: 10.0pt"><FONT face="Times New Roman" size="2">Какое 
											образовательное учреждение и когда окончил, специальность и квалификация по 
											образованию</FONT></SPAN></P>
							</TD>
							<TD style="HEIGHT: 49px" align="center"><FONT size="2"><asp:label id="text_uchzav" 
                                    Width="360px" runat="server" Font-Names="Times New Roman"></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 25px; HEIGHT: 43px" vAlign="middle"><FONT face="Times New Roman" size="2">11.</FONT></TD>
							<TD style="WIDTH: 274px; HEIGHT: 43px">
								<P class="MsoNormal"><SPAN style="FONT-SIZE: 12pt; COLOR: black; mso-bidi-font-size: 10.0pt"><FONT size="2"><FONT face="Times New Roman">Какими 
												иностранными языками и языками народов Российской Федерации и в какой степени 
												владеет
												<o:p></o:p></FONT></FONT></SPAN></P>
							</TD>
							<TD style="HEIGHT: 43px" align="center"><FONT size="2"><asp:label id="text_lang" 
                                    Width="360px" runat="server" Font-Names="Times New Roman"></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 25px; HEIGHT: 38px" vAlign="middle"><FONT face="Times New Roman" size="2">12.</FONT></TD>
							<TD style="WIDTH: 274px; HEIGHT: 38px">
								<P class="MsoNormal"><SPAN style="FONT-SIZE: 12pt; COLOR: black; mso-bidi-font-size: 10.0pt"><FONT size="2"><FONT face="Times New Roman">Учёная 
												степень и учёное звание
												<o:p></o:p></FONT></FONT></SPAN></P>
							</TD>
							<TD style="HEIGHT: 38px" align="center"><FONT size="2"><asp:label id="text_uchst" 
                                    Width="360px" runat="server" Font-Names="Times New Roman"></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 25px; HEIGHT: 33px" vAlign="middle"><FONT face="Times New Roman" size="2">13.</FONT></TD>
							<TD style="WIDTH: 274px; HEIGHT: 33px">
								<P class="MsoNormal"><SPAN style="FONT-SIZE: 12pt; COLOR: black; mso-bidi-font-size: 10.0pt"><FONT size="2"><FONT face="Times New Roman">Наличие 
												спортивной квалификации и специальных навыков
												<o:p></o:p></FONT></FONT></SPAN></P>
							</TD>
							<TD style="HEIGHT: 33px" align="center"><FONT size="2"><asp:label id="text_sport" 
                                    Width="360px" runat="server" Font-Names="Times New Roman"></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 25px; HEIGHT: 39px" vAlign="middle"><FONT face="Times New Roman" size="2">14.</FONT></TD>
							<TD style="WIDTH: 274px; HEIGHT: 39px">
								<P class="MsoNormal"><SPAN style="FONT-SIZE: 12pt; COLOR: black; mso-bidi-font-size: 10.0pt"><FONT size="2"><FONT face="Times New Roman">Государственные 
												награды
												<o:p></o:p></FONT></FONT></SPAN></P>
							</TD>
							<TD style="HEIGHT: 39px" align="center"><FONT size="2"><asp:label id="text_nagr" 
                                    Width="360px" runat="server" Font-Names="Times New Roman"></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 25px" vAlign="middle"><FONT face="Times New Roman" size="2">15.</FONT></TD>
							<TD style="WIDTH: 274px">
								<P class="MsoNormal"><SPAN style="FONT-SIZE: 12pt; COLOR: black; mso-bidi-font-size: 10.0pt"><FONT size="2"><FONT face="Times New Roman">Особые 
												условия службы
												<o:p></o:p></FONT></FONT></SPAN></P>
							</TD>
							<TD align="center"><asp:label id="text_komand" Width="360px" runat="server" 
                                    Font-Names="Times New Roman"></asp:label></TD>
						</TR>
					</TABLE>
					<P><br>
						<br>
						<br>
						<br>
						<br>
						<br>
						<br>
						<br>
						<br>
					</P>
				</TD>
			</TR>
			<TR>
				<TD class="maintext" style="WIDTH: 659px; HEIGHT: 37px" vAlign="top" align="center"
					colSpan="2"><STRONG><FONT face="Times New Roman">трудовая и служебная деятельность:
							<asp:table id="PTable" Width="613px" runat="server" Font-Size="X-Small" 
                        CellPadding="0" BorderColor="Black"
								BorderWidth="1px" CellSpacing="0" GridLines="Both" style="font-size: small">
								<asp:TableRow>
									<asp:TableCell Width="10%" HorizontalAlign="Center" Text="с.."></asp:TableCell>
									<asp:TableCell Width="10%" HorizontalAlign="Center" Text="..по"></asp:TableCell>
									<asp:TableCell Width="80%" HorizontalAlign="Center" Text="Место службы (работы), должность"></asp:TableCell>
								</asp:TableRow>
							</asp:table></FONT></STRONG></TD>
			</TR>
			<TR>
				<TD class="maintext" style="WIDTH: 659px; HEIGHT: 288px" vAlign="top" colSpan="2"><br>
					<P><FONT face="Times New Roman">Заместитель&nbsp;начальника УРЛС - начальник отдела 
                        кадров
							<br>
							Управления МВД России по Ивановской области</FONT></P>
					<P><FONT face="Times New Roman">полковник внутренней службы&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;В.Г.Шапошников</FONT></P>
					<P><asp:label class="DateText" id="now_date" Width="160px" runat="server" Font-Names="Times New Roman"></asp:label><FONT face="Times New Roman"></FONT></P>
				</TD>
			</TR>
		</TABLE>
		<!-- </form> -->
	</body>
</HTML>
