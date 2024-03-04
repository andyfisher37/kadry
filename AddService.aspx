<%@ Page Language="c#" Codebehind="AddService.aspx.cs" AutoEventWireup="True" Inherits="kadry.AddService" codePage="65001"%>
<%@ Register assembly="obout_Interface" namespace="Obout.Interface" tagprefix="cc1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Дополнительные сервисы...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	    <style type="text/css">
            .style1
            {
                width: 243px;
            }
        </style>
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="LEFT: 0px; POSITION: absolute; TOP: 0px" tabIndex="23" height="521" cellSpacing="0"
				cellPadding="0" width="753" align="left" border="0">
				<TBODY>
					<TR vAlign="top">
						<TD style="HEIGHT: 85px" vAlign="top" align="center"><IMG alt="Информационная система обработки данных "Кадры"" src="/images/header_small.gif" border="0"></TD>
					</TR>
					<TR vAlign="top">
						<TD style="HEIGHT: 15px" vAlign="top" align="center" height="15">
							<P class="Header" align="center">ДОПОЛНИТЕЛЬНЫЕ ВОЗМОЖНОСТИ</P>
						</TD>
					</TR>
					<TR vAlign="top">
						<TD tabIndex="0" vAlign="top" align="center">
							<P tabIndex="16"><A href="howtosearch.htm"></A></P>
							<P tabIndex="16">
								<TABLE id="Table1" style="WIDTH: 593px; HEIGHT: 443px" cellSpacing="0" 
                                    cellPadding="0" border="0">
									<TR>
										<TD class="style1">
                                            <asp:ImageButton ID="ImageButton15" runat="server" 
                                                ImageUrl="/images/btn_nzp.gif" onclick="ImageButton15_Click" />
                                        </TD>
										<TD class="smalltext">- Операции с нагрудными знаками полиции</TD>
									</TR>
									<TR>
										<TD class="style1">
                                            <asp:ImageButton ID="ImageButton9" runat="server" 
                                                ImageUrl="/images/btn_policecheck.gif" onclick="ImageButton9_Click" 
                                                Visible="False" />
                                        </TD>
										<TD class="smalltext"></TD>
									</TR>
									<TR>
										<TD class="style1">
                                            <asp:ImageButton ID="ImageButton13" runat="server" 
                                                ImageUrl="/images/btn_contract.gif" onclick="ImageButton13_Click" 
                                                ToolTip="Контракт" />
                                        </TD>
										<TD class="smalltext">- Оформить контракт о прохождении службы</TD>
									</TR>
									<TR>
										<TD class="style1">
                                            <asp:ImageButton ID="ImageButton10" runat="server" 
                                                ImageUrl="/images/btn_uvedom_print.gif" onclick="ImageButton10_Click" />
                                        </TD>
										<TD class="smalltext">- Выписать уведомление об увольнении</TD>
									</TR>
									<TR>
										<TD class="style1">
                                            <asp:ImageButton ID="ImageButton11" runat="server" 
                                                ImageUrl="/images/btn_uvedom_give.gif" onclick="ImageButton11_Click" />
                                        </TD>
										<TD class="smalltext">- Поставить отметку о вручении уведомления об увольнении</TD>
									</TR>
									<TR>
										<TD class="style1">
                                            &nbsp;</TD>
										<TD class="smalltext">&nbsp;</TD>
									</TR>
									<TR>
										<TD class="style1">
											<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="/images/btn_spr1.gif" ToolTip="Справка-объективка" onclick="ImageButton1_Click"></asp:ImageButton></TD>
										<TD class="smalltext" align="center">
											-&nbsp;Приложение №3 к правилам&nbsp;оформления&nbsp;и ведения личных дел<br />
                                            (проеверяйте правильность сведений по личным делам)</TD>
									</TR>
									<TR>
										<TD class="style1">
											<asp:ImageButton id="ImageButton14" runat="server" 
                                                ImageUrl="/images/btn_spr_stag.gif" ToolTip="Справка о стаже службы в ОВД" 
                                                onclick="ImageButton14_Click"></asp:ImageButton></TD>
										<TD class="smalltext">- Справка о стаже службы в органах внутренних дел<br />
                                            (в календарном исчислении)<br />
                                            (проеверяйте правильность сведений по личным делам)</TD>
									</TR>
									<TR>
										<TD class="style1">
											<asp:ImageButton id="ImageButton2" runat="server" ImageUrl="/images/btn_spr2.gif" ToolTip='"Дана Ф.И.О. в том, что он действительно проходит службу с... по н/время..."' onclick="ImageButton2_Click"></asp:ImageButton></TD>
										<TD class="smalltext">- Для сотрудников и работников (для предост.по месту 
											требования)</TD>
									</TR>
									<TR>
										<TD class="style1">
											<asp:ImageButton id="ImageButton3" runat="server" 
                                                ImageUrl="/images/btn_spr3.gif" 
                                                ToolTip="Для предоставления в подразделения ЛРР" onclick="ImageButton3_Click"></asp:ImageButton></TD>
										<TD class="smalltext">-&nbsp;Для предоставление в подразделения ЛРР</TD>
									</TR>
									<TR>
										<TD class="style1">
											<asp:ImageButton ID="ImageButton12" runat="server" 
                                                ImageUrl="/images/btn_skr_time.gif" onclick="ImageButton12_Click" />
                                        </TD>
										<TD class="smalltext">- Справка о зачете в выслугу лет периодов нахождения в СКР<br />
                                            (перед подписанием ОБЯЗАТЕЛЬНО сверять с личным делом) !!!</TD>
									</TR>
									<TR>
										<TD class="style1">
											<asp:ImageButton id="ImageButton7" runat="server" 
                                                ImageUrl="/images/btn_isxpfile.gif" ToolTip="Только для сотрудников УРЛС УВД" 
                                                onclick="ImageButton7_Click"></asp:ImageButton></TD>
										<TD class="smalltext">- Формирование исходящего на отправку/получение личного дела</TD>
									</TR>
									<TR>
										<TD class="style1">
											<asp:ImageButton id="ImageButton4" runat="server" ToolTip="Подготовка расчета выслуги лет на пенсию..."
												ImageUrl="/images/btn_spr4.gif" onclick="ImageButton4_Click"></asp:ImageButton></TD>
										<TD class="smalltext">- Расчет выслуги лет на пенсию (Приложение № 2 к Инструкции)</TD>
									</TR>
									<TR>
										<TD class="style1">
											<asp:ImageButton id="ImageButton5" runat="server" ToolTip="Подготовка представления на звание" ImageUrl="/images/btn_spr5.gif"></asp:ImageButton></TD>
										<TD class="smalltext">- Представление на звание</TD>
									</TR>
									<TR>
										<TD class="style1">
											<asp:ImageButton id="ImageButton6" runat="server" ToolTip="Подготовка аттестации..." ImageUrl="/images/btn_spr6.gif"></asp:ImageButton></TD>
										<TD class="smalltext">- Аттестация</TD>
									</TR>
									<TR>
										<TD align="center" class="style1">
											<asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="/images/wb_btn.gif" 
                                                onclick="ImageButton8_Click" style="margin-left: 0px" />
                                        </TD>
										<TD class="smalltext">- Информация по трудовой книжке</- Информация по трудовой книжке</TD>
									</TR>
									<TR>
										<TD align="center" class="style1">
											<asp:ImageButton id="ImageButton16" runat="server" 
                                                ToolTip="Уведомление об отпуске" ImageUrl="/images/btn_uvedom_vac.gif" 
                                                onclick="ImageButton16_Click"></asp:ImageButton>
                                        </TD>
										<TD class="smalltext">- Подготовка уведомления о предстоящем отпуске...</TD>
									</TR>
								</TABLE>
							</P>
						</TD>
					</TR>
					<TR vAlign="middle" align="left">
						<TD vAlign="top" noWrap align="center" height="27">&nbsp;</TD>
					</TR>
					<TR vAlign="middle" align="left">
						<TD vAlign="top" noWrap align="center" height="27">
                            Руководитель визирующий документ:<br /> 
                            <cc1:OboutDropDownList ID="rkadryviz" runat="server" 
                                Width="600px" MenuWidth="600px" 
                                onselectedindexchanged="rkadryviz_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">Заместитель начальника УРЛС - начальник отдела (кадров), полковник вн.службы В.Г.Шапошников</asp:ListItem>
                                <asp:ListItem Value="1">Заместитель начальника УРЛС - начальник отдела (мпо) полковник вн. службы Н.М.Новичков </asp:ListItem>
                                <asp:ListItem Value="2">Заместитель начальника отдела (кадров) подполковник вн. службы  С.Г.Донской</asp:ListItem>
                                <asp:ListItem Value="3">Врио начальника УРЛС полковник вн. службы Н.М.Новичков</asp:ListItem>
                            </cc1:OboutDropDownList>
                        </TD>
					</TR>
					<TR vAlign="middle" align="left">
						<TD vAlign="top" noWrap align="center" height="27">&nbsp;</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
