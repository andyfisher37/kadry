<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="firsted_control.aspx.cs" Inherits="kadry.ProfPod.firsted_control" %>
<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   		<title>Информационная система обработки данных "Кадры" - Контроль прохождения первоначальной подготовки...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">

</head>
<BODY text="#000000" bottomMargin="0" vLink="#cc0000" aLink="#6666ff"
		link="#ff9966" bgProperties="fixed" bgColor="#ffffff" leftMargin="0" background="/images/background.gif"
		topMargin="0" rightMargin="0" ms_positioning="GridLayout">
    <form id="form1" runat="server">
    <TABLE id="Table1" style="WIDTH: 720px; HEIGHT: 128px" cellSpacing="0" cellPadding="0"
				width="720" border="0">
				<TR>
					<TD><IMG alt="" src="/images/header_small.gif"></TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 1px" vAlign="top" align="center">КОНТРОЛЬ 
                        ПРОХОЖДЕНИЯ ПЕРВОНАЧАЛЬНОЙ ПОДГОТОВКИ<br><br>
                    </TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 348px" vAlign="top" align="center">
						<table bgcolor="#D1D1D1" class="maintext" style="width: 87%; height: 62px;">
                            <tr>
                                <td align="center">
                                    Вывести список принятых (прибывших) на службу в период с:<ew:maskedtextbox 
                                        id="Date1" runat="server" Width="88px" Mask="99.99.9999" CssClass="label2" 
                                        ToolTip="Дата начала периода"></ew:maskedtextbox>&nbsp;по
										<ew:maskedtextbox id="Date2" runat="server" Width="88px" Mask="99.99.9999" 
                                        CssClass="label2" ToolTip="Дата конца периода"></ew:maskedtextbox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:RadioButtonList ID="RList" runat="server" RepeatDirection="Horizontal" 
                                        Width="420px">
                                        <asp:ListItem Selected="True" Value="0">Все принятые</asp:ListItem>
                                        <asp:ListItem Value="1">Только не прошедшие первоначалку</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    Сортировать результаты по:<asp:DropDownList ID="SortList" runat="server" 
                                        CssClass="label2" ToolTip="Параметры сортировки">
                                        <asp:ListItem Value="0">Ф.И.О.</asp:ListItem>
                                        <asp:ListItem Value="1">Подразделению</asp:ListItem>
                                        <asp:ListItem Value="2">Службе</asp:ListItem>
                                        <asp:ListItem Value="3">Дате приема в ОВД</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:imagebutton id="GoButton" runat="server" ImageUrl="..//images/btn_sp.gif" 
                                        ToolTip="Создать список" onclick="GoButton_Click"></asp:imagebutton>
                                </td>
                            </tr>
                        </table>
                    </TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
    </form>
</body>
</html>
