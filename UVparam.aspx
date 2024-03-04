<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UVparam.aspx.cs" Inherits="UK.UVparam" %>
<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Информационная система обработки данных "Кадры" - Уведомление об увольнении...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="/Styles.css" rel="stylesheet">
        <style type="text/css">
            .style1
            {
                width: 141px;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="maintext" style="width:103%;">
            <tr>
                <td class="style1">
                    Дата выписки:
                    <ew:MaskedTextBox ID="NowDate" runat="server" Mask="99.99.9999" 
                        CssClass="label2" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Подготовить уведомление об увольнении для:</td>
                <td>
                    <asp:Label ID="ZVANIE" runat="server" CssClass="Header"></asp:Label>
                    ,
                    <asp:Label ID="NAME" runat="server" CssClass="Header"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Основание статьи 82 ФЗ &quot;О службе&quot;:</td>
                <td>
                    <asp:DropDownList ID="punktList" runat="server" CssClass="label2">
                        <asp:ListItem Value="пункта 11 части 2 (в связи с сокращением должности в органах внутренних дел, замещаемой сотрудником)">пункта 11 части 2 (в связи с сокращением должности в органах внутренних дел, замещаемой сотрудником)</asp:ListItem>
                        <asp:ListItem Value="пункта 9 части 2 (в связи с восстановлением в должности в органах внутренних дел сотрудника, ранее замещавшего эту должность)">пункта 9 части 2 (в связи с восстановлением в должности в органах внутренних дел сотрудника, ранее замещавшего эту должность)</asp:ListItem>
                        <asp:ListItem Value="пункта 2 части 1 (по достижении сотрудником предельного возраста пребывания на службе в органах внутренних дел)">пункта 2 части 1 (по достижении сотрудником предельного возраста пребывания на службе в органах внутренних дел)</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Приказ об оргштатных изменениях:</td>
                <td>
                    Чей
                    <asp:TextBox ID="cheyPrik" runat="server" CssClass="label2">УМВД</asp:TextBox>
&nbsp;Дата:
                    <ew:MaskedTextBox ID="DateEdit" runat="server" Mask="99.99.9999" 
                        CssClass="label2"></ew:MaskedTextBox>
                &nbsp;№
                    <asp:TextBox ID="PrikEdit" runat="server" CssClass="label2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Сокращаемая должность:
                <td>
                    <asp:TextBox ID="DolzEdit" runat="server" Width="600px" CssClass="label2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:CheckBox ID="CheckDol" runat="server" 
                        Text="Включить в текст уведомления должность" />
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="подготовить уведомление" 
                        onclick="Button1_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    <asp:SqlDataSource ID="kDataSource" runat="server" 
        ConnectionString="DSN=KADRY;DBQ=C:\KADRY;DefaultDir=C:\KADRY;Driver={277};DriverId=277;FIL=dBase IV;MaxBufferSize=2048;PageTimeout=5;" 
        ProviderName="System.Data.Odbc"></asp:SqlDataSource>
    <asp:SqlDataSource ID="nDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IASConnectionString %>" 
        InsertCommand="INSERT INTO Notification VALUES (@key, @date1, null)" 
        ProviderName="<%$ ConnectionStrings:IASConnectionString.ProviderName %>" SelectCommand="SELECT     COUNT(*) AS Expr1
FROM         Notification
WHERE     (id = @key)" 
        UpdateCommand="UPDATE Notification SET date_notification_print = @date1 WHERE id = @key">
        <SelectParameters>
            <asp:QueryStringParameter Name="key" QueryStringField="id" />
        </SelectParameters>
        <UpdateParameters>
            <asp:ControlParameter ControlID="NowDate" Name="date1" PropertyName="Text" 
                Type="DateTime" />
            <asp:QueryStringParameter Name="key" QueryStringField="id" />
        </UpdateParameters>
        <InsertParameters>
            <asp:QueryStringParameter Name="key" QueryStringField="id" />
            <asp:ControlParameter ControlID="NowDate" Name="date1" PropertyName="Text" 
                Type="DateTime" />
        </InsertParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
