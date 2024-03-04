<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Page language="c#" Codebehind="InOut.aspx.cs" AutoEventWireup="false" Inherits="kadry.InOut.InOut" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Принятые и уволенные...</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	    <style type="text/css">
            .style1
            {
                font: bold 7pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #663333;
                height: 251px;
                width: 557px;
            }
            .style2
            {
                font: bold 7pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #663333;
                height: 6px;
                width: 557px;
            }
            .style3
            {
                font: bold 7pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #663333;
                width: 55px;
            }
            #Table3
            {
                width: 97px;
            }
            .style4
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 24px;
                width: 532px;
            }
            .style5
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                width: 532px;
            }
            .style6
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 27px;
                width: 532px;
            }
            .style7
            {
                font-size: xx-small;
            }
        </style>
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#990000" aLink="#6666ff" link="#0000ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 726px; HEIGHT: 487px" cellSpacing="0" cellPadding="0" align="left"
				border="0">
				<TR>
					<TD style="WIDTH: 712px; HEIGHT: 99px" vAlign="top" align="left" colSpan="3"><IMG alt="Информационная система обработки данных "Кадры"" src="/images/header_small.gif" useMap="#Map2"
							border="0">
					</TD>
				</TR>
				<TR>
					<TD class="Header" style="WIDTH: 712px; HEIGHT: 1px" align="center" colSpan="3">ПРИНЯТЫЕ 
						и УВОЛЕННЫЕ</TD>
				</TR>
				<TR>
					<TD class="style1" vAlign="bottom" align="left" colSpan="2">
						<P>&nbsp;</P>
						<P>
							<TABLE id="Table3" borderColor="#660033" cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="label" align="center" colSpan="2"><asp:label id="CurDate" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="style3" align="center">принято</TD>
									<TD class="label" align="center">уволено</TD>
								</TR>
								<TR>
									<TD class="style3" vAlign="bottom" align="center">
										<P>&nbsp;</P>
										<P><asp:image id="InBar" runat="server" Width="16px" ImageUrl="..//images/tube_blue.gif" Height="78px"></asp:image></P>
										<P><asp:label class="label" id="In_Label" runat="server" Font-Size="XX-Small"></asp:label></P>
									</TD>
									<TD class="label" vAlign="bottom" align="center">
										<P>&nbsp;</P>
										<P><asp:image id="OutBar" runat="server" Width="16px" ImageUrl="..//images/tube_red.gif" Height="78px"></asp:image></P>
										<P><asp:label class="label" id="Out_Label" runat="server" Font-Size="XX-Small"></asp:label></P>
									</TD>
								</TR>
							</TABLE>
						</P>
						<P>&nbsp;</P>
					</TD>
					<TD style="WIDTH: 610px; HEIGHT: 251px" vAlign="bottom" align="left">
						<P>
							<TABLE id="Table1" style="WIDTH: 641px; HEIGHT: 235px" cellSpacing="0" cellPadding="0"
								bgColor="#D1D1D1" border="0">
								<TR>
									<TD class="maintext" align="left" colSpan="2"><U><FONT color="#990033">Уволенные</FONT></U>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
										период: с&nbsp;
										<ew:maskedtextbox id="OutDate1" runat="server" Width="88px" Mask="99.99.9999"></ew:maskedtextbox>&nbsp;по
										<ew:maskedtextbox id="OutDate2" runat="server" Width="88px" Mask="99.99.9999"></ew:maskedtextbox></TD>
								</TR>
								<TR>
									<TD class="style4" align="right">Список сотрудников, 
										уволенных по отрицательным мотивам:</TD>
									<TD class="maintext" style="HEIGHT: 24px" align="center">
                                        <asp:imagebutton id="ImageButton1" runat="server" 
                                            ImageUrl="..//images/btn_sp.gif" ToolTip="Уволенные по отрицательным мотивам" 
                                            onclick="ImageButton1_Click1"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="style5" align="right">Список&nbsp; уволенных сотрудников, прослуживших 
										менее 1 года:</TD>
									<TD style="WIDTH: 130px; HEIGHT: 28px" align="center">
                                        <asp:imagebutton id="ImageButton2" runat="server" 
                                            ImageUrl="..//images/btn_sp.gif" ToolTip="Уволенные до года в ОВД" 
                                            onclick="ImageButton2_Click1"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="style6" align="right">Список 
										уволенных стажеров:</TD>
									<TD style="WIDTH: 130px; HEIGHT: 27px" align="center">
                                        <asp:imagebutton id="ImageButton3" runat="server" 
                                            ImageUrl="..//images/btn_sp.gif" ToolTip="Уволенные стажеры" 
                                            onclick="ImageButton3_Click1"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="style6" align="right">Список&nbsp;откомандированных 
										сотрудников (<EM><FONT size="1">др.регионы,ведомства</FONT></EM>):</TD>
									<TD style="WIDTH: 130px; HEIGHT: 27px" align="center">
                                        <asp:imagebutton id="ImageButton7" runat="server" 
                                            ImageUrl="..//images/btn_sp.gif" ToolTip="Откомандированные" 
                                            onclick="ImageButton7_Click1"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="style6" align="right">Список всех 
										уволенных (<FONT size="1"><EM>без стажеров</EM></FONT>):</TD>
									<TD style="WIDTH: 130px; HEIGHT: 27px" align="center">
                                        <asp:imagebutton id="Imagebutton9" runat="server" 
                                            ImageUrl="..//images/btn_sp.gif" ToolTip="Все уволенные без стажеров" 
                                            onclick="Imagebutton9_Click1"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="style6" align="right">Список&nbsp;уволенных сотрудников по  
                                        (<span class="style7">оргштатным мероприятиям</span>):</TD>
									<TD style="WIDTH: 130px; HEIGHT: 27px" align="center">
                                        <asp:imagebutton id="Imagebutton10" runat="server" 
                                            ImageUrl="..//images/btn_sp.gif" ToolTip="Уволенные по сокращению" 
                                            onclick="Imagebutton10_Click1"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="style6" align="right">Список уволенных сотрудников по &quot;собственному 
                                        желанию&quot; (<span class="style7">без пенсии</span>):</TD>
									<TD style="WIDTH: 130px; HEIGHT: 27px" align="center">
                                        <asp:imagebutton id="Imagebutton11" runat="server" 
                                            ImageUrl="..//images/btn_sp.gif" ToolTip="Уволенные по собственному (без пенсии)" 
                                            onclick="Imagebutton11_Click"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="style6" align="right">Список уволенных работников: </TD>
									<TD style="WIDTH: 130px; HEIGHT: 27px" align="center">
                                        <asp:imagebutton id="Imagebutton12" runat="server" 
                                            ImageUrl="..//images/btn_sp.gif" ToolTip="Уволенные работники:" 
                                            onclick="Imagebutton12_Click"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="style6" align="right">Список уволенных федеральных государственных 
                                        гражданских служащих:</TD>
									<TD style="WIDTH: 130px; HEIGHT: 27px" align="center">
                                        <asp:imagebutton id="Imagebutton13" runat="server" 
                                            ImageUrl="..//images/btn_sp.gif" ToolTip="Уволенные работники:" 
                                            onclick="Imagebutton13_Click"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 769px; HEIGHT: 1px" align="center" 
                                        colSpan="2">
										<P>
											&nbsp;<HR>
										<P>&nbsp;</P>
									</TD>
								</TR>
							</TABLE>
						</P>
						<P>
							<TABLE id="Table2" style="WIDTH: 642px; HEIGHT: 166px" cellSpacing="0" 
                                cellPadding="0" bgColor="#D1D1D1" border="0">
								<TR>
									<TD class="maintext" style="WIDTH: 769px; HEIGHT: 3px" align="left" colSpan="3"><U><FONT color="#990033">Принятые</FONT></U>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;период: с&nbsp;
										<ew:maskedtextbox id="InDate1" runat="server" Width="88px" Mask="99.99.9999"></ew:maskedtextbox>&nbsp;по
										<ew:maskedtextbox id="InDate2" runat="server" Width="88px" Mask="99.99.9999"></ew:maskedtextbox></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 501px; HEIGHT: 28px" align="right">Список&nbsp;всех 
										принятых на службу:</TD>
									<TD class="maintext" style="WIDTH: 130px; HEIGHT: 28px" align="center" colSpan="2">
                                        <asp:imagebutton id="ImageButton6" runat="server" 
                                            ImageUrl="..//images/btn_sp.gif" ToolTip="Все принятые" 
                                            onclick="ImageButton6_Click1"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 501px; HEIGHT: 28px" align="right">Количество&nbsp;принятых&nbsp;сотрудников:
										<asp:radiobutton id="RBtn1" runat="server" Font-Size="XX-Small" GroupName="1" Checked="True" Text="По подразделениям"></asp:radiobutton><asp:radiobutton id="RBtn2" runat="server" Font-Size="XX-Small" GroupName="1" Text="По службам"></asp:radiobutton></TD>
									<TD style="WIDTH: 130px; HEIGHT: 28px" align="center" colSpan="2">
                                        <asp:imagebutton id="ImageButton5" runat="server" 
                                            ImageUrl="..//images/btn_sp.gif" ToolTip="Принятые по службам и подразделениям" 
                                            onclick="ImageButton5_Click1"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 501px; HEIGHT: 27px" align="right">Список 
										прибывших по окончании учебных заведений МВД России:</TD>
									<TD style="WIDTH: 130px; HEIGHT: 27px" align="center" colSpan="2">
                                        <asp:imagebutton id="ImageButton8" runat="server" 
                                            ImageUrl="..//images/btn_sp.gif" 
                                            ToolTip="Прибывшие выпускники ВУЗов и ССУЗов МВД России" 
                                            onclick="ImageButton8_Click1"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 501px; HEIGHT: 27px" align="right">Список 
										прибывших сотрудников (<FONT size="1"><EM>др.регионы, ведомства</EM></FONT>):</TD>
									<TD style="WIDTH: 130px; HEIGHT: 27px" align="center" colSpan="2">
                                        <asp:imagebutton id="ImageButton4" runat="server" 
                                            ImageUrl="..//images/btn_sp.gif" ToolTip="Все прибывшие" 
                                            onclick="ImageButton4_Click1"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 769px; HEIGHT: 1px" align="center" colSpan="3">
										<HR>
									</TD>
								</TR>
							</TABLE>
						</P>
						<P>
							<TABLE id="Table4" style="WIDTH: 576px; HEIGHT: 53px" cellSpacing="0" cellPadding="0" width="576"
								bgColor="#D1D1D1" border="0">
								<TR>
									<TD class="maintext" style="WIDTH: 769px; HEIGHT: 26px" align="right" colSpan="3"><FONT color="#000000">Подразделение:&nbsp;
										</FONT>
										<asp:dropdownlist id=podrList tabIndex=7 runat="server" Width="424px" Font-Size="7pt" ForeColor="#C00000" Font-Names="Verdana" DataMember="Table" DataTextField="PODRAZDEL" DataValueField="KEY_OF_POD" DataSource="<%# podrDataSet %>">
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="maintext" style="WIDTH: 769px; HEIGHT: 27px" align="right" colSpan="3"><FONT color="#000000">Служба: 
											&nbsp;</FONT>
										<asp:dropdownlist id=sluzList tabIndex=7 runat="server" Width="424px" Font-Size="7pt" ForeColor="#C00000" Font-Names="Verdana" DataMember="Table" DataTextField="NAM_OF_SLU" DataValueField="KEY_OF_SLU" DataSource="<%# sluzDataSet %>">
										</asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</P>
					</TD>
				</TR>
				<TR>
					<TD class="style2" vAlign="bottom" align="left" colSpan="2"></TD>
					<TD style="WIDTH: 610px; HEIGHT: 6px" vAlign="bottom" align="left">&nbsp;</TD>
				</TR>
				<TR vAlign="middle" align="left">
					<TD vAlign="top" noWrap align="center" colSpan="3" height="27"><IMG height="33" alt="Панель быстрых переходов..." src="../images/bottom.gif" 
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
