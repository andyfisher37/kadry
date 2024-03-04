<%@ Page language="c#" Codebehind="blanks.aspx.cs" AutoEventWireup="True" Inherits="kadry.Blanks.blanks" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<title>Информационная система обработки данных "Кадры" - бланки служебных документов...</title>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	<link href="/Styles.css" rel="stylesheet">
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
					<TD class="Header" style="HEIGHT: 3px" vAlign="top" align="center" height="3">БЛАНКИ 
						служебных документов</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 355px" vAlign="top" align="center">
						<P>&nbsp;
							<TABLE id="Table1" style="WIDTH: 717px; HEIGHT: 392px" cellSpacing="0" cellPadding="0"
								width="717" border="0">
								<TR>
									<TD vAlign="top" align="left"><iewc:treeview id="Tree" runat="server" Height="100%" Width="100%" TreeNodeSrc="blanks.xml"></iewc:treeview></TD>
									<TD style="HEIGHT: 369px" vAlign="top" align="left"><P>&nbsp;
											<asp:imagebutton id="ImageButton1" runat="server" ImageUrl="/images/download.gif" onclick="ImageButton1_Click"></asp:imagebutton></P>
										<P>
											<asp:Label id="Label" runat="server" Width="136px"></asp:Label>
										</P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 545px" class="smalltext" align="left" colSpan="2"><FONT color="#cc0000">* 
											Для того чтобы получить необходимый бланк документа Вам нужно выбрать в списке 
											нужный бланк и нажать кнопку [ЗАКАЧАТЬ]. В диалоге загрузки - нажмите кнопку 
											[СОХРАНИТЬ] и укажите путь на диске для сохранения. По данному пути будет 
											сохранен архив (*.ZIP) в котором и находится интересующий Вас бланк.</FONT></TD>
								</TR>
							</TABLE>
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
