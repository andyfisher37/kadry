<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prikaz.aspx.cs" Inherits="kadry.Control.Prikaz" %>
<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Информационная система обработки данных "Кадры" - Выборки по приказам...</title>
    <meta name="vs_snapToGrid" content="False">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	<link href="/Styles.css" rel="stylesheet">
    <style type="text/css">
        .style1
        {
            height: 27px;
            width: 131px;
        }
        .style2
        {
            width: 131px;
        }
    </style>
</head>
<body text="#000000" bottomMargin="0" vLink="#990000" aLink="#6666ff" link="#0000ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
    <form id="form1" runat="server">
    <div>
    <TABLE style="WIDTH: 751px; HEIGHT: 376px" height="376" cellSpacing="0" cellPadding="0"
				width="751" align="left" border="0">
				<TR>
					<TD style="WIDTH: 740px; HEIGHT: 58px" vAlign="top" align="center" height="58"><IMG alt="Информационная система обработки данных "Кадры"" src="/images/header_small.gif" useMap="#Map2"
							border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP>&nbsp;
					</TD>
				</TR>
				<TR>
					<TD class="Header" style="WIDTH: 740px; HEIGHT: 21px" align="center" height="21">
                        Выборки по приказам по личному составу</TD>
				</TR>
				<TR>
					<td style="WIDTH: 740px; HEIGHT: 221px" vAlign="top" align="center">
						<TABLE class="maintext" id="Table1" cellSpacing="0" cellPadding="0" border="0" align="center">
							<TR>
								<TD vAlign="top" align="center">
									<HR style="WIDTH: 737px; HEIGHT: 1px" color="#000099" SIZE="1">
									<TABLE class="maintext" id="Table2" cellSpacing="0" cellPadding="0" bgColor="antiquewhite"
										border="0" style="WIDTH: 623px; HEIGHT: 146px">
										<TR>
											<TD class="label2" align="center" colSpan="2">Задайте параметры поиска приказа:</TD>
										</TR>
										<TR>
											<TD class="supersmall" style="HEIGHT: 7px" align="right" colSpan="2"></TD>
										</TR>
										<TR>
											<TD align="right" class="style1">Тип приказа:</TD>
											<TD style="HEIGHT: 27px" align="left">
												<asp:DropDownList id=typeList runat="server" Width="489px" class=label2 
                                                    CssClass="label2">
                                                    <asp:ListItem Selected="True" Value="1">О присвоении званий</asp:ListItem>
                                                    <asp:ListItem Value="2">О назначении</asp:ListItem>
                                                    <asp:ListItem Value="3">О поощрении</asp:ListItem>
                                                    <asp:ListItem Value="4">О привлечении к дисциплинарной ответственности</asp:ListItem>
                                                    <asp:ListItem Value="5">Об увольнении</asp:ListItem>
                                                    <asp:ListItem Value="6">Об откомандировании</asp:ListItem>
												</asp:DropDownList></TD>
										</TR>
										<TR>
											<TD align="right" class="style1">Чей приказ:</TD>
											<TD style="HEIGHT: 27px" align="left">
												<asp:DropDownList ID="podrList" runat="server" CssClass="label2" 
                                                    DataSourceID="podrDataSet" DataTextField="PODRAZDEL" 
                                                    DataValueField="KEY_OF_POD" Width="487px">
                                                </asp:DropDownList>
                                            </TD>
										</TR>
										<TR>
											<TD align="right" class="style2">Дата приказа:</TD>
											<TD align="left">
												<ew:maskedtextbox id="DateDoc" runat="server" Width="90px" Mask="99.99.9999" 
                                                    CssClass="label2"></ew:maskedtextbox></TD>
										</TR>
										<TR>
											<TD align="right" class="style2">Номер приказа:</TD>
											<TD align="left">
												<asp:TextBox id="Number" runat="server" Width="90px" CssClass="label2"></asp:TextBox>&nbsp;л/с</TD>
										</TR>
										<TR>
											<TD class="supersmall" colSpan="2"></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="2">
												<asp:ImageButton id="FindButton" runat="server" ImageUrl="../images/iskat.gif"></asp:ImageButton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">&nbsp;</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center">
                                    <asp:Label ID="InfoLabel" runat="server" CssClass="label"></asp:Label>
                                </TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
					</td>
				</TR>
				<TR vAlign="middle" align="left">
					<TD style="WIDTH: 740px" vAlign="middle" noWrap align="center" colSpan="2" height="27">&nbsp;
						</TD>
				</TR>
			</TABLE>
    </div>
    </form>
</body>
</html>
