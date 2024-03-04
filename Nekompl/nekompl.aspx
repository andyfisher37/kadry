<%@ Page language="c#" Codebehind="nekompl.aspx.cs" AutoEventWireup="True" Inherits="kadry.Nekompl.nekompl" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - некомплект...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	    <style type="text/css">
            blink
            {
                font-family: "Times New Roman", Times, serif;
            }
            .новыйСтиль1
            {
                text-transform: uppercase;
                color: #FF0000;
                text-decoration: blink;
            }
            .style12
            {
                text-decoration: underline;
                width: 504px;
                text-align: left;
            }
            .style13
            {
                width: 504px;
                text-align: left;
            }
            .style14
            {
                text-align: left;
            }
            .style15
            {
                text-decoration: underline;
            }
        </style>
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#000000" aLink="#000000" link="#000000" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 759px; HEIGHT: 590px" height="590" cellSpacing="0" cellPadding="0"
				width="759" align="left" border="0">
				<TR>
					<TD style="HEIGHT: 70px" align="center"><IMG alt="" src="/images/header_small.gif" width="750" useMap="#Map2" border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP></TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 3px" vAlign="top" align="center" height="3">некомплект 
						личного состава</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center"><br>
						<TABLE id="Table1" style="WIDTH: 711px; HEIGHT: 105px" cellSpacing="0" cellPadding="0"
							width="711" bgColor="#D1D1D1" border="0">
							<TR>
								<TD style="WIDTH: 16px; HEIGHT: 2px"></TD>
								<TD style="WIDTH: 492px; HEIGHT: 2px"></TD>
								<TD style="WIDTH: 8px; HEIGHT: 2px"></TD>
								<TD style="HEIGHT: 2px"></TD>
								<TD style="WIDTH: 14px; HEIGHT: 2px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 16px; HEIGHT: 16px"></TD>
								<TD style="WIDTH: 492px; HEIGHT: 16px" vAlign="top" align="left" class="maintext">Сведения 
									об укомплектованности органов и подразделений Управления МВД России по 
                                    Ивановской области (по территориальным органам внутренних дел) по 
									состоянию на:
									<asp:label id="DateLabel1" runat="server" ForeColor="Blue"></asp:label></TD>
								<TD style="WIDTH: 8px; HEIGHT: 16px"></TD>
								<TD style="HEIGHT: 16px"><asp:imagebutton id="Btn1" runat="server" ImageUrl="/images/btn_nek_all.gif" ToolTip="Сведения об укомплектованности по подразделениям..." onclick="Btn1_Click"></asp:imagebutton></TD>
								<TD style="WIDTH: 14px; HEIGHT: 16px">
									<P>&nbsp;</P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 16px; HEIGHT: 1px"></TD>
								<TD style="WIDTH: 500px; HEIGHT: 1px" vAlign="middle" align="center" colSpan="2">
									<hr>
								</TD>
								<TD style="WIDTH: 14px; HEIGHT: 1px"></TD>
								<TD style="WIDTH: 14px; HEIGHT: 1px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 16px; HEIGHT: 21px"></TD>
								<TD class="maintext" style="WIDTH: 492px; HEIGHT: 21px" vAlign="top" align="left">Сведения 
									об укомплектованности органов внутренних дел области (по службам) по состоянию 
									на:
									<asp:label id="DateLabel2" runat="server" ForeColor="Blue"></asp:label></TD>
								<TD style="WIDTH: 8px; HEIGHT: 21px"></TD>
								<TD style="HEIGHT: 21px">
									<asp:ImageButton id="Btn2" runat="server" ImageUrl="/images/btn_nek_slu.gif" ToolTip="Сведения об укомплектованности по службам..." onclick="Btn2_Click"></asp:ImageButton></TD>
								<TD style="WIDTH: 14px; HEIGHT: 21px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 16px; HEIGHT: 10px"></TD>
								<TD class="maintext" style="WIDTH: 500px; HEIGHT: 10px" vAlign="middle" align="center"
									colSpan="2">
									<HR>
									&nbsp;</TD>
								<TD style="WIDTH: 14px; HEIGHT: 10px"></TD>
								<TD style="WIDTH: 14px; HEIGHT: 10px"></TD>
							</TR>
							</TABLE>
						<TABLE id="Table2" style="WIDTH: 708px; HEIGHT: 54px" cellSpacing="0" cellPadding="0"
							border="0" class="smalltext">
							<TR>
								<TD colspan="3"><hr></TD>
							</TR>
							<TR>
								<TD class="style13">Штатная численность аттестованного состава в целом по УМВД:</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="stat_all_label" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style12">&nbsp;в том числе:</TD>
								<TD colspan="2" class="style14">
									&nbsp;</TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp;&nbsp; - средний, старший и высший начальствующий состав 
                                    (офицеры):&nbsp;</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="stat_ns_label" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - из них 
                                    руководящего состава&nbsp;(от начальника отделения и выше):</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="stat_rkadry_label" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp;&nbsp; - рядовой и младший начальствующий состав 
                                    (рядовые):&nbsp;</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="stat_rs_label" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style12">в том числе:</TD>
								<TD colspan="2" class="style14">
									&nbsp;</TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp;&nbsp; - подразделения полиции:&nbsp;</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="stat_police_label" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp;&nbsp; - иные органы внутренних дел (внутренняя 
                                    служба, юстиция):&nbsp;</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="stat_other_label" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;</TD>
								<TD colspan="2" class="style14">
									&nbsp;</TD>
							</TR>
							<TR>
								<TD class="style13">Штатная численность рабочих и служащих в целом по УМВД:</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="stat_vn_all_label" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style13">в том числе:</TD>
								<TD colspan="2" class="style14">
									&nbsp;</TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp;&nbsp; - федеральная государственная гражданская служба:&nbsp;</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="stat_fggs_label" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;</TD>
								<TD colspan="2" class="style14">
									&nbsp;</TD>
							</TR>
							<TR>
								<TD class="style13">Некомплект л/с в целом по УМВД, на сегодня <asp:Label id="cur_date" runat="server"></asp:Label> 
									&nbsp;составляет:
								</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="nek_all_label" runat="server"></asp:Label>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD class="style13"><U>в том числе:</U></TD>
								<TD class="style14"></TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp; - старший, средний и высший начальствующий состав 
                                    (офицеры):</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="nek_ns_label" runat="server"></asp:Label>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp; - рядовой и младший начальствующий состав (рядовые):
								</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="nek_rs_label" runat="server"></asp:Label>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp; - федеральных государственных гражданских служащих:</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="fggs_label" runat="server"></asp:Label>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;</TD>
								<TD colspan="2" class="style14">
									&nbsp;</TD>
							</TR>
							<TR>
								<TD class="style13"><span class="style15">Всего</span> сотрудников, находящихся на сокращенных должностях:</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="zs_label" runat="server"></asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp; - в том числе средний, старший и высший ачальствующий состав:</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="zs_ns_label" runat="server"></asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp; - в том числе рядовой и младший начальствующий состав:&nbsp;</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="zs_rs_label" runat="server"></asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="style13">Сотрудников, находящихся в отпуске по уходу за ребенком (декрет):</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="decr_label" runat="server"></asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="style13"><span class="style15">Рабочих и служащих</span>, находящихся на сокращенных должностях:</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="zs_vn_label" runat="server"></asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="style13">Сотрудников, совмещающих несколько аттестованных должностей 
                                    (&quot;совместители&quot;):</TD>
								<TD colspan="2" class="style14">
									<asp:Label class="label2" id="sovm_label" runat="server"></asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="style12" style="color: #FF3300"></TD>
								<TD colspan="2" class="style14">
									&nbsp;</TD>
							</TR>
							<TR>
								<TD colspan="3"><hr></TD>
							</TR>
							<TR>
								<TD class="style12">Некомплект в том числе по основным службам:</TD>
								<TD class="style14">Штат, ед.</TD>
								<TD class="style14">Нек-т,%</TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp; &nbsp;- Подразделения уголовного розыска:</TD>
								<TD class="style14">
									<asp:Label class="label2" id="st_ur" runat="server"></asp:Label></TD>
								<TD class="style14">
									<asp:Label class="label2" id="ur_nek" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp; - Следственные подразделения:</TD>
								<TD class="style14">
									<asp:Label class="label2" id="st_so" runat="server"></asp:Label></TD>
								<TD class="style14">
									<asp:Label class="label2" id="so_nek" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp; - Подразделения по экономической безопасности и 
                                    противодествия коррупции:</TD>
								<TD class="style14">
									<asp:Label class="label2" id="st_bep" runat="server"></asp:Label></TD>
								<TD class="style14">
									<asp:Label class="label2" id="bep_nek" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp; - Участковые уполномоченные полиции:</TD>
								<TD class="style14">
									<asp:Label class="label2" id="st_uum" runat="server"></asp:Label></TD>
								<TD class="style14">
									<asp:Label class="label2" id="uum_nek" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp; &nbsp;- Подразделения ГИБДД:</TD>
								<TD class="style14">
									<asp:Label class="label2" id="st_gibdd" runat="server"></asp:Label></TD>
								<TD class="style14">
									<asp:Label class="label2" id="gibdd_nek" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp; - Вневедомственная охрана:</TD>
								<TD class="style14">
									<asp:Label class="label2" id="st_ovo" runat="server"></asp:Label></TD>
								<TD class="style14">
									<asp:Label class="label2" id="ovo_nek" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;&nbsp; - Патрульно-постовая служба полиции:</TD>
								<TD class="style14">
									<asp:Label class="label2" id="st_pps" runat="server"></asp:Label></TD>
								<TD class="style14">
									<asp:Label class="label2" id="pps_nek" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="style13">&nbsp;</TD>
								<TD class="style14">
									&nbsp;</TD>
								<TD class="style14">
									&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">&nbsp;</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">&nbsp;</TD>
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
