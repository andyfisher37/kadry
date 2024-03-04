<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nzp_dataform.aspx.cs" Inherits="kadry.NZPolice.nzp_dataform" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Форма сведений о нагрудном знаке сотрудника полиции</title>
    <LINK href="/Styles.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="TitleText" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2" align="center" colspan="2"><hr />
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    Тип нагрудного знака:</td>
                <td>
                    <asp:DropDownList ID="nzTypeList" runat="server" DataTextField="type" DataValueField="code" 
                        Width="350px" CssClass="label2">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="1">Нагрудный знак сотрудника полиции (общий)</asp:ListItem>
                        <asp:ListItem Value="2">Нагрудный знак сотрудника патрульно-постовой службы</asp:ListItem>
                        <asp:ListItem Value="3">Нагрудный знак сотрудника вневедомственной охраны</asp:ListItem>
                        <asp:ListItem Value="4">Нагрудный знак сотрудника дорожно-патрульной службы</asp:ListItem>
                        <asp:ListItem Value="5">Нагрудный знак участкового уполномоченного полиции</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Статус нагрудного знака:</td>
                <td>
                    <asp:Label ID="Status" runat="server" CssClass="label2"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Номер нагрудного знака:</td>
                <td>
                    <asp:TextBox ID="nzNumber" runat="server" CssClass="label2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="nzNumber" Display="Dynamic" 
                        ErrorMessage="* укажите номер нагрудного знака"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Дата закрепления (приказа):</td>
                <td>
                    <dx:ASPxDateEdit ID="nzpGiveDate" runat="server" Theme="Default">
                    </dx:ASPxDateEdit>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="nzpGiveDate" Display="Dynamic" 
                        ErrorMessage="* введите корректную дату" 
                        ValidationExpression="\d{2}.\d{2}.\d{4}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Чей приказ о закреплении:</td>
                <td>
                    <asp:TextBox ID="nzPodrName" runat="server" CssClass="label2" Width="450px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="nzPodrName" Display="Dynamic" ErrorMessage="* чей приказ ?"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Номер приказа о закреплении:</td>
                <td>
                    <asp:TextBox ID="prNumber" runat="server" Width="68px" CssClass="label2" 
                        Font-Bold="True" Font-Names="Verdana" ForeColor="Maroon"></asp:TextBox>
&nbsp;л/с<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="prNumber" Display="Dynamic" 
                        ErrorMessage="* номерок приказа ?"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Дата утраты (порчи):</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" align="center" colspan="2"><hr />
                    </td>
            </tr>
            <tr>
                <td class="style2" align="center" colspan="2">
                    <asp:Label ID="Info" runat="server" CssClass="admin_text"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2" align="center" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="style1" colspan="2">
                    <asp:Button ID="SaveButton" runat="server" 
                        Text="Закрепить знак (внести изменения)" onclick="SaveButton_Click" />
&nbsp;
                    <asp:Button ID="SaveButton0" runat="server" Text="Освободить знак" />
&nbsp;
                    <asp:Button ID="LostButton" runat="server" Text="Отметить утрату" />
                &nbsp;
                    <asp:Button ID="LostButton0" runat="server" Text="Отметить порчу" />
                &nbsp;
                    <asp:Button ID="CancelButton" runat="server" Text="Вернуться" 
                        onclick="CancelButton_Click" />
&nbsp;&nbsp;
                    &nbsp;&nbsp;
                    </td>
            </tr>
        </table>
    
    </div>
    <asp:SqlDataSource ID="NZPoliceDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IASConnectionString %>" 
        InsertCommandType="StoredProcedure" 
        ProviderName="<%$ ConnectionStrings:IASConnectionString.ProviderName %>" 
        UpdateCommandType="StoredProcedure"></asp:SqlDataSource>
    </form>
</body>
</html>
