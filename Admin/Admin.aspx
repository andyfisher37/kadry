<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="kadry.Admin.Admin" %>

<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Администрирование ИАС &quot;КАДРЫ&quot;</title>
    <link href="/Styles.css" rel="stylesheet"/>
</head>
<body background="/images/background.gif">
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;" class="maintext">
            <tr>
                <td>
                    Количество зарегистрированных пользователей:</td>
                <td>
                    <asp:Label ID="UserCount" runat="server"></asp:Label>
                    <asp:SqlDataSource ID="SqlDataSource" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:IASConnectionString %>" 
                        SelectCommand="SELECT COUNT(UserName) AS user_count FROM Users">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="список" Width="81px" />
                </td>
            </tr>
            <tr>
                <td>
                    Количество ролей безопасности:</td>
                <td>
                    <asp:Label ID="RolesCount" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="список" Width="80px" />
                </td>
            </tr>
            <tr>
                <td>
                    Количество записей в логах:</td>
                <td>
                    <asp:Label ID="LogsCount" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Поместить логи с
                    <ew:MaskedTextBox ID="Date1" runat="server" CssClass="label2"></ew:MaskedTextBox>
&nbsp;по
                    <ew:MaskedTextBox ID="Date2" runat="server" CssClass="label2"></ew:MaskedTextBox>
&nbsp;в архив</td>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="архивировать" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="..\index.aspx">Главная</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
