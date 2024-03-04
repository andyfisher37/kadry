<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditFirstEducation.aspx.cs" Inherits="kadry.ProfPod.EditFirstEducation" %>
<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
       <table style="width:100%;">
            <tr align="center" class="Header">
                <td align="center">
                    <asp:Label ID="TitleText" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
						<asp:table id="Table" runat="server" Width="1063px" BackColor="Azure" 
                        BorderWidth="1px" BorderColor="#404040"
							Font-Size="XX-Small" GridLines="Both" CellPadding="1" CellSpacing="0" Font-Names="Verdana">
							<asp:TableRow BackColor="PowderBlue" Font-Size="XX-Small" Font-Names="Verdana">
								<asp:TableCell HorizontalAlign="Center" Text="Фамилия"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Имя"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Отчество"></asp:TableCell>
							    <asp:TableCell HorizontalAlign="Center" Text="Подразделение"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Служба"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Должность"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Звание"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата приема"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Приказ"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="№"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата приказа"></asp:TableCell>
							    <asp:TableCell runat="server" HorizontalAlign="Center">Откуда принят (прибыл)</asp:TableCell>
                                <asp:TableCell runat="server" Width="100px" HorizontalAlign="Center">Дата направления в ЦПП</asp:TableCell>
                                <asp:TableCell runat="server" HorizontalAlign="Center">Категория группы</asp:TableCell>
                                <asp:TableCell runat="server" HorizontalAlign="Center">Статус</asp:TableCell>
							    <asp:TableCell runat="server" HorizontalAlign="Center">Изм.</asp:TableCell>
							</asp:TableRow>
						</asp:table>
						</td>
            </tr>
        </table>
    </form>
</body>
</html>
