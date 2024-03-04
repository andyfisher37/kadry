<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Page language="c#" Codebehind="EditAttestation.aspx.cs" AutoEventWireup="false" Inherits="kadry.Attestation.EditAttestation" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Редактирование аттестации...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="LEFT: 0px; POSITION: absolute; TOP: 0px" tabIndex="23" cellSpacing="0" cellPadding="0"
				width="753" align="left" border="0">
				<TBODY>
					<TR vAlign="top">
						<TD style="HEIGHT: 85px" vAlign="top" align="center" colSpan="19"><IMG alt="Информационная система обработки данных "Кадры"" src="/images/header_small.gif" border="0"></TD>
					</TR>
					<TR vAlign="top">
						<TD style="HEIGHT: 15px" vAlign="top" align="center" height="15">
							<P class="Header" align="center">ИЗМЕНЕНИЕ&nbsp;АТТЕСТАЦИИ...</P>
						</TD>
					</TR>
					<TR vAlign="top">
						<TD style="HEIGHT: 467px" tabIndex="0" vAlign="top" align="center">
							<P tabIndex="16"><A href="howtosearch.htm"></A></P>
							<TABLE class="maintext" id="Table1" style="WIDTH: 742px; HEIGHT: 390px" tabIndex="0" cellSpacing="1"
								cols="1" cellPadding="1" align="center" bgColor="#D1D1D1" border="0">
								<TR>
									<TD class="maintext" style="WIDTH: 276px; HEIGHT: 371px" vAlign="top" align="center"
										width="276" colSpan="2" height="371">
										<TABLE id="Table4" style="WIDTH: 304px; HEIGHT: 76px" cellSpacing="1" cellPadding="1" width="304"
											border="0">
										</TABLE>
										<asp:label id="fio" runat="server" Font-Size="Small" Font-Names="Verdana" Font-Bold="True"
											Font-Italic="True"></asp:label>
										<P></P>
										<TABLE class="maintext" id="Table3" style="WIDTH: 504px; HEIGHT: 316px" cellSpacing="1"
											cellPadding="1" width="504" border="1">
											<TR>
												<TD class="maintext" style="WIDTH: 179px" align="right">Дата аттестации:</TD>
												<TD><ew:maskedtextbox id="date_att" runat="server" Width="80px" Font-Names="Verdana" ForeColor="#0000C0"
														Font-Bold="True" ErrorMessage="Неправильная дата" ErrorText="Неправильная дата" RequiredErrorMessage="Необходима дата..."
														RequiredErrorText="Необходима дата..." Mask="99.99.9999" ToolTip="Дата аттестации"></ew:maskedtextbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right">Дата следующей аттестации:</TD>
												<TD><ew:maskedtextbox id="date_att_next" tabIndex="1" runat="server" Width="80px" Font-Names="Verdana"
														ForeColor="#0000C0" Font-Bold="True" ErrorMessage="Неправильная дата" ErrorText="Неправильная дата"
														RequiredErrorMessage="Необходима дата..." RequiredErrorText="Необходима дата..." Mask="99.99.9999"
														ToolTip="Дата следующей аттестации"></ew:maskedtextbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right">Основание для аттестации:</TD>
												<TD><asp:dropdownlist class=label2 id=osnov_att tabIndex=2 runat="server" Width="304px" DataValueField="CODE" DataTextField="NAME" DataSource="<%# slv_attDataSet %>">
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px; HEIGHT: 17px" align="right">Вывод по аттестации:</TD>
												<TD style="HEIGHT: 17px"><asp:dropdownlist class="label2" id="res_att" tabIndex="3" runat="server" Width="304px">
														<asp:ListItem Value="True">Соответствует</asp:ListItem>
														<asp:ListItem Value="False">Несоответствует</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right">Рекомендации:</TD>
												<TD><asp:textbox class="label2" id="recomend" tabIndex="4" runat="server" Width="304px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right">Примечание:</TD>
												<TD><asp:textbox class="label2" id="comment" tabIndex="5" runat="server" Width="304px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px; HEIGHT: 20px" align="right" bgColor="#ffffcc"><FONT color="#000000">Протокол 
														№</FONT></TD>
												<TD style="HEIGHT: 20px" bgColor="#ffffcc"><FONT color="#000000"><asp:textbox class="label2" id="prot_number" tabIndex="6" runat="server" Width="80px"></asp:textbox></FONT></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right" bgColor="#ffffcc"><FONT color="#000000">Дата 
														протокола:</FONT></TD>
												<TD bgColor="#ffffcc"><FONT color="#000000"><ew:maskedtextbox id="prot_date" tabIndex="7" runat="server" Width="80px" Font-Names="Verdana" ForeColor="#0000C0"
															Font-Bold="True" ErrorMessage="Неправильная дата" ErrorText="Неправильная дата" RequiredErrorMessage="Необходима дата..." RequiredErrorText="Необходима дата..."
															Mask="99.99.9999" ToolTip="Дата протокола"></ew:maskedtextbox></FONT></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right" bgColor="#ccffcc"><FONT color="#000000">Документ 
														основание:</FONT></TD>
												<TD bgColor="#ccffcc"><FONT color="#000000"><asp:dropdownlist class="label2" id="doc_type" tabIndex="8" runat="server" Width="304px">
															<asp:ListItem Value="ОТСУТСТВУЕТ">ОТСУТСТВУЕТ</asp:ListItem>
															<asp:ListItem Value="ПРИКАЗ">ПРИКАЗ</asp:ListItem>
															<asp:ListItem Value="РАСПОРЯЖЕНИЕ">РАСПОРЯЖЕНИЕ</asp:ListItem>
														</asp:dropdownlist></FONT></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right" bgColor="#ccffcc"><FONT color="#000000">№</FONT></TD>
												<TD bgColor="#ccffcc"><FONT color="#000000"><asp:textbox class="label2" id="doc_number" tabIndex="9" runat="server" Width="80px"></asp:textbox></FONT></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right" bgColor="#ccffcc"><FONT color="#000000">Дата:</FONT></TD>
												<TD bgColor="#ccffcc"><FONT color="#000000"><ew:maskedtextbox id="doc_date" tabIndex="10" runat="server" Width="80px" Font-Names="Verdana" ForeColor="#0000C0"
															Font-Bold="True" ErrorMessage="Неправильная дата" ErrorText="Неправильная дата" RequiredErrorMessage="Необходима дата..." RequiredErrorText="Необходима дата..."
															Mask="99.99.9999" ToolTip="Дата документа основания"></ew:maskedtextbox></FONT></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right" bgColor="#ccffcc"><FONT color="#000000">Кем 
														издан:</FONT></TD>
												<TD bgColor="#ccffcc"><asp:dropdownlist class=label2 id=doc_ovd tabIndex=11 runat="server" Width="304px" DataValueField="KEY_OF_POD" DataTextField="PODRAZDEL" DataSource="<%# pdrDataSet %>">
													</asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="UserInfo" style="WIDTH: 276px; HEIGHT: 22px" vAlign="top" align="center"
										width="276" colSpan="2" height="22">Проверяйте правильность введенных данных!</TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 276px" vAlign="top" align="center" width="276" colSpan="2"
										height="14">&nbsp;&nbsp;
										<asp:imagebutton id="Button_cancel" runat="server" ImageUrl="..//images//btn_cancel2.gif"></asp:imagebutton>&nbsp; 
										&nbsp;
										<asp:imagebutton id="Button_add" runat="server" ImageUrl="..//images//btn_change.gif"></asp:imagebutton></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR vAlign="middle" align="left">
						<TD vAlign="top" noWrap align="center" colSpan="2" height="27"><IMG height="33" alt="Панель быстрых переходов..." src="../images/bottom.gif" 
								useMap="#Map" border="0"><MAP name="Map">
                                 <AREA title="На главную..." shape="RECT" alt="На главную..." coords="25,0,100,33" href="../index.aspx">
                                 <AREA title="Поиск сотрудников" shape="RECT" alt="Поиск сотрудников" coords="150,0,200,33"	href="../Search/search.aspx">
                                 <AREA title="Штатно-должностная книга" shape="RECT" alt="Штатно-должностная книга" coords="250,0,325,33"	href="../Structure/orgstr.aspx">
                                 <AREA title="Вакансии" shape="RECT" alt="Вакансии" coords="325,0,425,33" href="../Vakans/vakansy.aspx">
                                 <AREA title="Некомплект" shape="RECT" alt="Некомплект" coords="475,0,550,33" href="../Nekompl/nekompl.aspx">
                                 <AREA title="Качественные показатели" shape="RECT" alt="Качественные показатели" coords="575,0,650,33"	href="../Kachestv/kachestv.aspx">
                                 <AREA title="Дисциплинарная практика" shape="RECT" alt="Дисциплинарная практика" coords="700,0,775,33"	href="../Discipline/discipline.aspx">
                                 </MAP></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
