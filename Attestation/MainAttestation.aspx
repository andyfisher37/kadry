<%@ Page language="c#" Codebehind="MainAttestation.aspx.cs" AutoEventWireup="True" Inherits="kadry.Attestation.MainAttestation" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Аттестации...</title>
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
								АТТЕСТАЦИИ</P>
						</TD>
					</TR>
					<TR vAlign="top">
						<TD style="HEIGHT: 513px" tabIndex="0" vAlign="top" align="center">
							<P tabIndex="16"><A href="howtosearch.htm"></A></P>
							<TABLE class="maintext" id="Table1" style="WIDTH: 742px; HEIGHT: 414px" tabIndex="0" cellSpacing="1"
								cols="1" cellPadding="1" align="center" bgColor="#D1D1D1" border="0">
								<TR>
									<TD class="maintext" style="WIDTH: 276px" vAlign="top" align="left" width="276" height="14">
										<TABLE id="Table2" style="WIDTH: 304px; HEIGHT: 248px" cellSpacing="1" cellPadding="1"
											width="304" border="0">
											<TR>
												<TD class="maintext" style="WIDTH: 161px">Фамилия:</TD>
												<TD><asp:label class="label2" id="first_name" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="maintext" style="WIDTH: 161px">Имя:</TD>
												<TD><asp:label class="label2" id="name" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="maintext" style="WIDTH: 161px">Отчество:</TD>
												<TD><asp:label class="label2" id="last_name" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="maintext" style="WIDTH: 161px">Личный номер:</TD>
												<TD><asp:label class="label2" id="p_number" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="maintext" style="WIDTH: 161px">Звание:</TD>
												<TD><asp:label class="label2" id="zvanie" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="maintext" style="WIDTH: 161px">Подразделение:</TD>
												<TD><asp:label class="label2" id="podrazd" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="maintext" style="WIDTH: 161px">Служба:</TD>
												<TD><asp:label class="label2" id="sluzba" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="maintext" style="WIDTH: 161px">Должность:</TD>
												<TD><asp:label class="label2" id="dolznost" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="maintext" style="WIDTH: 161px">№ личного дела:</TD>
												<TD><asp:label class="label2" id="file_number" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="maintext" style="WIDTH: 161px">Звание присвоено:</TD>
												<TD><asp:label class="label2" id="zvan_data" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="maintext" style="WIDTH: 161px">Назначен на должность:</TD>
												<TD><asp:label class="label2" id="dolz_data" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="maintext" style="WIDTH: 161px">В ОВД с:</TD>
												<TD><asp:label class="label2" id="data_post" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="maintext" style="WIDTH: 161px">В службе с:</TD>
												<TD><asp:label class="label2" id="sluz_data" runat="server"></asp:label></TD>
											</TR>
										</TABLE>
										<TABLE id="Table4" style="WIDTH: 304px; HEIGHT: 76px" cellSpacing="1" cellPadding="1" width="304"
											border="0">
											<TR>
												<TD>
													<hr>
												</TD>
											</TR>
											<TR>
												<TD></TD>
											</TR>
										</TABLE>
									</TD>
									<TD vAlign="top" align="left" width="213" height="14"><FONT color="#660033" size="1"><STRONG><U>Параметры 
													текущей аттестации:</U></STRONG></FONT>
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
									<TD class="maintext" style="WIDTH: 276px" vAlign="top" align="center" width="276" colSpan="2"
										height="14"><asp:imagebutton id="Button_add" runat="server" ImageUrl="..//images//btn_add.gif" onclick="Button_add_Click"></asp:imagebutton>&nbsp;&nbsp;
										<asp:imagebutton id="Button_change" runat="server" ImageUrl="..//images//btn_change.gif" onclick="Button_change_Click"></asp:imagebutton>&nbsp; 
										&nbsp;
										<asp:imagebutton id="Button_delete" runat="server" ImageUrl="..//images//btn_delete.gif" onclick="Button_delete_Click"></asp:imagebutton></TD>
								</TR>
							</TABLE>
							<P tabIndex="16">
								<asp:datagrid id=Grid runat="server" Width="741px" Font-Size="XX-Small" Font-Names="Verdana" DataMember="Table" DataSource="<%# attDataSet %>" BackColor="AliceBlue" AutoGenerateColumns="False" BorderColor="Black" BorderWidth="1px" ToolTip="Выбор аттестации по дате...">
									<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
										VerticalAlign="Middle" BackColor="Gainsboro"></HeaderStyle>
									<Columns>
										<asp:TemplateColumn HeaderText="Дата аттестации">
											<ItemStyle Font-Bold="True" HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DATE_ATT", "{0:d}") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.DATE_ATT", "EditAttestation.aspx?") %>' Target="_self" ID="Hyperlink1">
												</asp:HyperLink>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn DataField="DATE_NEXT" SortExpression="DATE_NEXT" HeaderText="Дата след.аттестации"
											DataFormatString="{0:d}"></asp:BoundColumn>
										<asp:BoundColumn DataField="NAME" SortExpression="NAME" HeaderText="Основание">
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Вывод">
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:TemplateColumn>
										<asp:BoundColumn DataField="RECOMEND" SortExpression="RECOMEND" HeaderText="Рекомендации">
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PRIMECHAN" SortExpression="PRIMECHAN" HeaderText="Примечание">
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PROTOC_NUM" SortExpression="PROTOC_NUM" HeaderText="№ протокола">
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PROTOC_DAT" SortExpression="PROTOC_DAT" HeaderText="Дата протокола" DataFormatString="{0:d}">
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DOC_OSNOV" SortExpression="DOC_OSNOV" HeaderText="Тип докум. основания">
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DOC_NUMB" SortExpression="DOC_NUMB" HeaderText="№ док.осн.">
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PODRAZDEL" SortExpression="PODRAZDEL" HeaderText="Кем издан"></asp:BoundColumn>
									</Columns>
								</asp:datagrid></P>
							<P tabIndex="16">&nbsp;</P>
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
