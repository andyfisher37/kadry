<%@ Page language="c#" Codebehind="DeleteAttestation.aspx.cs" AutoEventWireup="True" Inherits="kadry.Attestation.DeleteAttestation" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Удаление аттестации...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
							<P class="Header" align="center">
								УДАЛЕНИЕ ЗАПИСИ ОБ АТТЕСТАЦИИ...</P>
						</TD>
					</TR>
					<TR vAlign="top">
						<TD style="HEIGHT: 467px" tabIndex="0" vAlign="top" align="center">
							<P tabIndex="16"><A href="howtosearch.htm"></A></P>
							<TABLE class="maintext" id="Table1" style="WIDTH: 742px; HEIGHT: 426px" tabIndex="0" cellSpacing="1"
								cols="1" cellPadding="1" align="center" bgColor="#D1D1D1" border="0">
								<TR>
									<TD class="maintext" style="WIDTH: 276px; HEIGHT: 367px" vAlign="top" align="center"
										width="276" height="367" colSpan="2">
										<TABLE id="Table4" style="WIDTH: 304px; HEIGHT: 76px" cellSpacing="1" cellPadding="1" width="304"
											border="0">
										</TABLE>
										<asp:label id="fio" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Verdana"
											Font-Size="Small"></asp:label>
										<P></P>
										<TABLE class="maintext" id="Table3" style="WIDTH: 424px; HEIGHT: 316px" cellSpacing="1"
											cellPadding="1" width="424" border="1">
											<TR>
												<TD class="maintext" style="WIDTH: 179px" align="right">Дата аттестации:</TD>
												<TD>
													<asp:label class="label2" id="date_att" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right">Дата следующей аттестации:</TD>
												<TD>
													<asp:label class="label2" id="date_att_next" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right">Основание для аттестации:</TD>
												<TD>
													<asp:label class="label2" id="osnov_att" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right">Вывод по аттестации:</TD>
												<TD>
													<asp:label class="label2" id="res_att" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right">Рекомендации:</TD>
												<TD>
													<asp:label class="label2" id="recomend" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right">Примечание:</TD>
												<TD>
													<asp:label class="label2" id="comment" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px; HEIGHT: 20px" align="right" bgColor="#ffffcc"><FONT color="#000000">Протокол 
														№</FONT></TD>
												<TD style="HEIGHT: 20px" bgColor="#ffffcc"><FONT color="#000000">
														<asp:label class="label2" id="prot_number" runat="server"></asp:label></FONT></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right" bgColor="#ffffcc"><FONT color="#000000">Дата 
														протокола:</FONT></TD>
												<TD bgColor="#ffffcc"><FONT color="#000000">
														<asp:label class="label2" id="prot_date" runat="server"></asp:label></FONT></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right" bgColor="#ccffcc"><FONT color="#000000">Документ 
														основание:</FONT></TD>
												<TD bgColor="#ccffcc"><FONT color="#000000">
														<asp:label class="label2" id="doc_type" runat="server"></asp:label></FONT></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right" bgColor="#ccffcc"><FONT color="#000000">№</FONT></TD>
												<TD bgColor="#ccffcc"><FONT color="#000000">
														<asp:label class="label2" id="doc_number" runat="server"></asp:label></FONT></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right" bgColor="#ccffcc"><FONT color="#000000">Дата:</FONT></TD>
												<TD bgColor="#ccffcc"><FONT color="#000000">
														<asp:label class="label2" id="doc_date" runat="server"></asp:label></FONT></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 179px" align="right" bgColor="#ccffcc"><FONT color="#000000">Кем 
														издан:</FONT></TD>
												<TD bgColor="#ccffcc">
													<asp:label class="label2" id="doc_ovd" runat="server"></asp:label></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="Attantion" style="WIDTH: 276px; HEIGHT: 22px" vAlign="top" align="center"
										width="276" colSpan="2" height="22">Действительно удалить аттестацию ?</TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 276px" vAlign="top" align="center" width="276" colSpan="2"
										height="14">&nbsp;&nbsp;
										<asp:imagebutton id="Button_cancel" runat="server" ImageUrl="..//images//btn_cancel2.gif" onclick="Button_cancel_Click"></asp:imagebutton>&nbsp; 
										&nbsp;
										<asp:imagebutton id="Button_delete" runat="server" ImageUrl="..//images//btn_delete.gif" onclick="Button_delete_Click"></asp:imagebutton></TD>
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
