<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Page language="c#" Codebehind="moving.aspx.cs" AutoEventWireup="false" Inherits="kadry.Moving.moving" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Движение личного состава</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#990000" aLink="#6666ff" link="#0000ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 751px; HEIGHT: 392px" cellSpacing="0" cellPadding="0" align="left"
				border="0">
				<TR>
					<TD style="WIDTH: 739px; HEIGHT: 99px" vAlign="top" align="left"><IMG alt="Информационная система обработки данных "Кадры"" src="/images/header_small.gif" useMap="#Map2"
							border="0">
					</TD>
				</TR>
				<TR>
					<TD class="Header" style="WIDTH: 739px; HEIGHT: 24px" align="center">ДВИЖЕНИЕ 
						ЛИЧНОГО СОСТАВА</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 739px; HEIGHT: 342px" vAlign="top" align="center">
						<P>
							<TABLE id="Table3" style="WIDTH: 745px; HEIGHT: 168px" cellSpacing="1" 
                                cellPadding="1" bgColor="#D1D1D1" border="0">
								<TR>
									<TD class="maintext" colSpan="2"><U><FONT color="#990033">Движение из службы в службу:<A href="..//moving_help.htm"><IMG id="Img2" alt="Информация об объединении некоторых служб при выполнении запросов..."
														src="..//images/btn_help.gif" border="0"></A></FONT></U>&nbsp; 
										период: с&nbsp;
										<ew:maskedtextbox id="Date1" runat="server" Width="88px" Mask="99.99.9999"></ew:maskedtextbox>&nbsp;по
										<ew:maskedtextbox id="Date2" runat="server" Width="88px" Mask="99.99.9999"></ew:maskedtextbox></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 409px" align="right"><A href="..//sluzhelp.htm"><IMG id="IMG1" alt="Информация об объединении некоторых служб при выполнении запросов..."
												src="..//images/btn_help.gif" border="0"></A>Служба:</TD>
									<TD>
										<asp:DropDownList id=sluzList runat="server" Width="295px" DataSource="<%# sluzDataSet %>" DataTextField="NAM_OF_SLU" DataValueField="KEY_OF_SLU">
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 409px" align="right">Список сотрудников 
										убывших&nbsp;из службы:</TD>
									<TD align="left">
										<asp:imagebutton id="SpsButton1" runat="server" ImageUrl="..//images/btn_sp.gif" ToolTip="Уволенные по отрицательным мотивам"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 409px" align="right">Список 
										сотрудников&nbsp;прибывших в службу:</TD>
									<TD align="left">
										<asp:imagebutton id="SpsButton2" runat="server" ImageUrl="..//images/btn_sp.gif" ToolTip="Уволенные по отрицательным мотивам"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 409px" align="right">Сводная статитстика 
										прибывших/убывших по выбранной службе:</TD>
									<TD align="left">
										<asp:imagebutton id="StatButton" runat="server" ImageUrl="..//images/btn_stat.gif" ToolTip="Уволенные по отрицательным мотивам"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 409px" align="right">
                                        <asp:CheckBox ID="CheckHi" runat="server" 
                                            Text="Только на вышестоящие должности..." />
                                    </TD>
									<TD align="left">
										&nbsp;</TD>
								</TR>
								<TR>
									<TD class="maintext" align="right" colspan="2"><hr></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 409px" align="right">&nbsp;</TD>
									<TD align="left">
										&nbsp;</TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 409px" align="right">&nbsp;</TD>
									<TD align="left">
										&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 409px" colSpan="2">
										<asp:Label class="label2" id="Info" runat="server" Width="704px"></asp:Label></TD>
								</TR>
							</TABLE>
						</P>
						<P>&nbsp;</P>
						<P>
						</P>
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
			</TABLE>
		</form>
	</body>
</HTML>
