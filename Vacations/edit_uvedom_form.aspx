<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_uvedom_form.aspx.cs" Inherits="kadry.Vacations.edit_uvedom_form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Подготовка уведомления о предстоящем отпуске</title>
    <LINK href="/Styles.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">

    
    <table style="width:100%;">
        <tr>
            <td colspan="2" align="center" class="Header" valign="top">
    <div>Подготовка уведомления о предстоящем отпуске</div>

    
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="Header" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Руководитель визирующий уведомление:</td>
            <td>
                <asp:DropDownList ID="rkadry_list" runat="server" CssClass="label2" Width="846px">
                    <asp:ListItem Selected="True" Value="0">Заместитель начальника УРЛС - начальник отдела кадров, полковник вн.службы Шапошников В.Г.</asp:ListItem>
                    <asp:ListItem Value="1">Заместитель начальника отдела кадров, п.п-к вн.сл. Донской С.Г.</asp:ListItem>
                    <asp:ListItem Value="10">Помощник начальника отдела МВД России &quot;Приволжский&quot; по работе с личным составом, майор вн.сл. Степанов Н.В.</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Приказ, утвердивший график отпусков:</td>
            <td>
                <asp:TextBox ID="grafik" runat="server" CssClass="label2" Width="841px">УМВД от «12» декабря 2012 г. № 1111</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="MakeButton" runat="server" onclick="MakeButton_Click" 
                    Text="Подготовить" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
