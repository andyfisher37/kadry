<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovingControl.aspx.cs" Inherits="kadry.Control.moving_control" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>Информационная система обработки данных "Кадры" - Контроль перемещений 
       сотрудников...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
    
    <style type="text/css">
        .style1
        {
            font: 10pt Verdana, Arial, Helvetica, sans-serif;
            text-transform: none;
            color: #000000;
            direction: ltr;
            letter-spacing: normal;
            width: 488px;
        }
        .style2
        {
            font: 10pt Verdana, Arial, Helvetica, sans-serif;
            text-transform: none;
            color: #000000;
            direction: ltr;
            letter-spacing: normal;
            width: 489px;
        }
        .style3
        {
            font: 10pt Verdana, Arial, Helvetica, sans-serif;
            text-transform: none;
            color: #000000;
            direction: ltr;
            letter-spacing: normal;
            width: 496px;
        }
    </style>
    
</head>
<body text="#000000" bottomMargin="0" vLink="#990000" aLink="#6666ff" link="#0000ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
    <form id="form1" runat="server">
    <TABLE style="WIDTH: 751px; HEIGHT: 392px" cellSpacing="0" cellPadding="0" align="left"
				border="0">
				<TR>
					<TD style="WIDTH: 739px; HEIGHT: 99px" vAlign="top" align="left"><IMG alt="Информационная система обработки данных "Кадры"" src="/images/header_small.gif" useMap="#Map2"
							border="0">
					</TD>
				</TR>
				<TR>
					<TD class="Header" style="WIDTH: 739px; HEIGHT: 24px" align="center">КОНТРОЛЬ 
                        назначений</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 739px; HEIGHT: 342px" vAlign="top" align="center">
						<P>
							<TABLE id="Table3" style="WIDTH: 776px; HEIGHT: 168px" cellSpacing="1" 
                                cellPadding="1" bgColor="#D1D1D1" border="0" class="maintext">
								<TR>
									<TD colSpan="2"></TD>
								</TR>
								<TR>
									<TD class="style3" align="right">Период за который вы 
                                        хотите получить сведения:
                                    </TD>
									<TD align="center">&nbsp; с&nbsp;
										<ew:maskedtextbox id="Date1" runat="server" Width="80px" Mask="99.99.9999"></ew:maskedtextbox>&nbsp;по
										<ew:maskedtextbox id="Date2" runat="server" Width="80px" Mask="99.99.9999"></ew:maskedtextbox></TD>
								    </TR>
								    <TR>
									<TD align="right">Направление назначений:</TD>
									<TD align="left">
										<asp:DropDownList ID="vector" runat="server" Width="277px">
                                            <asp:ListItem Value="0">не имеет значения</asp:ListItem>
                                            <asp:ListItem Value="1">в выбранное подразделение</asp:ListItem>
                                            <asp:ListItem Value="2">из выбранного подразделения</asp:ListItem>
                                        </asp:DropDownList>
                                        </TD>
								</TR>
								    <TR>
									<TD align="right">Выбор подразделения:</TD>
									<TD>
										&nbsp;</TD>
								</TR>
								<TR>
									<TD align="right">Подразделение:</TD>
									<TD>
										<asp:DropDownList ID="podrList" runat="server" 
                                            DataTextField="PODRAZDEL" DataValueField="KEY_OF_POD" Height="24px" 
                                            style="margin-left: 0px" Width="277px" AutoPostBack="True" 
                                            onselectedindexchanged="podrList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </TD>
								</TR>
								<TR>
									<TD align="right">
                                        <asp:Label ID="Label1" runat="server" Text="Подчиненное подразделение:" 
                                            Visible="False"></asp:Label>
                                    </TD>
									<TD>
										<asp:DropDownList ID="podchList" runat="server" 
                                            DataTextField="NAIMENOVAN" DataValueField="KEY_OF_NAI" Height="24px" 
                                            Visible="False" Width="277px" AutoPostBack="True" 
                                            onselectedindexchanged="podchList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </TD>
								</TR>
								<TR>
									<TD align="right"><A href="..//sluzhelp.htm"><IMG id="IMG1" alt="Информация об объединении некоторых служб при выполнении запросов..."
												src="..//images/btn_help.gif" border="0"></A>Служба:</TD>
									<TD>
										<asp:DropDownList ID="sluzList" runat="server" 
                                            DataTextField="NAM_OF_SLU" DataValueField="KEY_OF_SLU" Height="24px" 
                                            style="margin-left: 0px" Width="277px">
                                        </asp:DropDownList>
                                    </TD>
								</TR>
								<TR>
									<TD align="right">&nbsp;</TD>
									<TD>
                                        <asp:CheckBox ID="CheckHi" runat="server" 
                                            Text="Только на вышестоящие должности" TextAlign="Left" />
                                    </TD>
								</TR>
								<TR>
									<TD align="right"></TD>
									<TD>
                                        <asp:CheckBox ID="CheckHi0" runat="server" 
                                            Text="Только на руководящие должности " TextAlign="Left" />
                                    </TD>
								</TR>
								<TR>
									<TD align="right" colspan="2"><hr></TD>
								</TR>
								<TR>
									<TD align="left">1. Список сотрудников, 
                                        назначенных за указанный период:</TD>
									<TD align="center">
										<asp:imagebutton id="SpsButton1" runat="server" 
                                            ImageUrl="..//images/btn_sp.gif" onclick="SpsButton1_Click"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD align="left" colspan="2"><hr></TD>
								</TR>
								<TR>
									<TD  align="left">2. Список всех 
                                        сотрудников, сменивших службу за указанный период:</TD>
									<TD align="center">
										<asp:imagebutton id="SpsButton2" runat="server" 
                                            ImageUrl="..//images/btn_sp.gif" onclick="SpsButton2_Click"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD class="maintext" align="right" colspan="2"><hr></TD>
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
</html>
