<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contract.aspx.cs" Inherits="kadry.Contracts.Contract" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            font-size: 9pt;
            color: #000066;
        }
        .style3
        {
            color: #000066;
        }
        .style4
        {
            font-size: 9pt;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
        Генератор<br />
        <strong>КОНТРАКТА<br />
        о прохождении службы в органах внутренних дел</strong><br />
    
    <hr />
        Отредактируйте имеющиеся данные или заполните пустующие поля, если есть 
        необходимость:<br />
        <table style="width:100%;">
            <tr>
                <td align="left">
                    Фамилия:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="first_name" runat="server" Font-Bold="True" 
                        Font-Names="vardana" Font-Size="11pt" ForeColor="Maroon" 
                        style="margin-left: 0px" Width="220px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="small_name" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Имя:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="name" runat="server" Font-Bold="True" Font-Names="vardana" 
                        Font-Size="11pt" ForeColor="Maroon" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Отчество:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="second_name" runat="server" Font-Bold="True" 
                        Font-Names="vardana" Font-Size="11pt" ForeColor="Maroon" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Дата рождения:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="born" runat="server" Font-Bold="True" Font-Names="vardana" 
                        Font-Size="11pt" ForeColor="Maroon" Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Наименование должности <span class="style2"></span><em><span class="style2">(именительный падеж - кто? что?)</span></em>:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="dolz1" runat="server" Font-Bold="True" Font-Names="vardana" 
                        Font-Size="11pt" ForeColor="Maroon" Width="1000px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Специальное звание&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <span class="style3"><span class="style4"></span><em><span 
                        class="style4">(именительный падеж)</span></em></span>:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="rank" runat="server" Font-Bold="True" Font-Names="vardana" 
                        Font-Size="11pt" ForeColor="Maroon" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Наименование должности <span class="style3">
                    <span class="style4"></span><em><span class="style4">(винительный падеж - кого? чего?)</span></em></span>:</td>
                <td style="text-align: left">
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                        Text="взять сверху" />
                    <asp:TextBox ID="dolz2" runat="server" Font-Bold="True" Font-Names="vardana" 
                        Font-Size="11pt" ForeColor="Maroon" Width="980px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Срок контракта&nbsp;&nbsp;&nbsp;&nbsp;
                    <span class="style3"><span class="style4"></span><em><span class="style4">(по умолчанию бессрочный)</span></em></span>:</td>
                <td style="text-align: left">
                    <asp:DropDownList ID="srok_list" runat="server" Font-Bold="True" 
                        Font-Names="vardana" Font-Size="11pt" Width="220px">
                        <asp:ListItem Selected="True">бессрочный</asp:ListItem>
                        <asp:ListItem>сроком на 1 год</asp:ListItem>
                        <asp:ListItem>сроком на пять лет</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left">
                    </td>
                <td style="text-align: left">
                    паспортные данные:</td>
            </tr>
            <tr>
                <td align="left">
                    Серия паспорта:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="pass_ser" runat="server" Font-Names="Verdana" Font-Size="11pt" 
                        ForeColor="Maroon"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Номер:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="pass_num" runat="server" Font-Names="Verdana" Font-Size="11pt" 
                        ForeColor="Maroon"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Кем и когда выдан:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="pass_ovd" runat="server" Font-Names="Verdana" Font-Size="11pt" 
                        ForeColor="Maroon" Width="756px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Место жительства:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="live_place" runat="server" Font-Names="Verdana" 
                        Font-Size="11pt" ForeColor="Maroon" Width="1000px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        Text="СФОРМИРОВАТЬ КОНТРАКТ" />
                </td>
            </tr>
        </table>
    <br />
    </div>
    </form>
</body>
</html>
