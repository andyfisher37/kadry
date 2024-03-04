<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="UK.WorkBook.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>Информационная система обработки данных "Кадры" - Учет трудовых книжек...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
    <style type="text/css">
        .style1
        {
            font-size: medium;
            font-family: "Times New Roman", Times, serif;
        }
        .style3
        {
            width: 74px;
        }
        .style4
        {
            width: 206px;
        }
        .style5
        {
            width: 133px;
        }
        .style6
        {
            width: 188px;
        }
        .style7
        {
            width: 76px;
        }
    </style>
</head>
<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
    <form id="form1" runat="server">
    <div>
    <table style="width:95%; height: 1px;">
        <tr>
            <td class="style7">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/home.gif" 
                    onclick="ImageButton1_Click" AlternateText="Главная" />
                <asp:ImageButton ID="ImageButton2" runat="server" 
                    ImageUrl="/images/search.gif" AlternateText="Поиск..." />
            </td>
            <td align="center" class="style1" valign="bottom">
                <h4 class="Header">
                    (В РАЗРАБОТКЕ...)</h4>
                <h4 class="Header">
                    РЕГИСТРАЦИЯ И УЧЕТ ТРУДОВЫХ КНИЖЕК</h4>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <hr></td>
        </tr>
        <tr>
            <td bgcolor="#FFFFCC" colspan="3">
                <table class="maintext" style="width: 99%;">
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td align="center" colspan="2">
                            <b>Информация по трудовой книжке:</b></td>
                    </tr>
                    <tr>
                        <td class="style3">
                            Фамилия:</td>
                        <td class="style4">
                            <asp:Label ID="Familiya" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style6">
                            Серия:</td>
                        <td class="style5">
                            <asp:Label ID="Ser" runat="server" Font-Bold="True" ForeColor="#660066"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            Имя:</td>
                        <td class="style4">
                            <asp:Label ID="Imya" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style6">
                            Номер:</td>
                        <td class="style5">
                            <asp:Label ID="Num" runat="server" Font-Bold="True" ForeColor="#660066"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            Отчество:</td>
                        <td class="style4">
                            <asp:Label ID="Otchectvo" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style6">
                            Дата заполнения:</td>
                        <td class="style5">
                            <asp:Label ID="DateEnt" runat="server" Font-Bold="True" ForeColor="#660066"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            № л/д:</td>
                        <td class="style4">
                            <asp:Label ID="NumPersFile" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style6">
                            Тип трудовой кн.:</td>
                        <td class="style5">
                            <asp:Label ID="Type" runat="server" Font-Bold="True" ForeColor="#660066"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td class="style6">
                            Регистр.номер:</td>
                        <td class="style5">
                            <asp:Label ID="RegNum" runat="server" Font-Bold="True" ForeColor="#660066"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td class="style6">
                            Дата регистрации:</td>
                        <td class="style5">
                            <asp:Label ID="DateReg" runat="server" Font-Bold="True" ForeColor="#660066"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td class="style6">
                            Дата последнего измен.:</td>
                        <td class="style5">
                            <asp:Label ID="DateCh" runat="server" Font-Bold="True" ForeColor="#660066"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td class="style6">
                            Тип последнего измен.:</td>
                        <td class="style5">
                            <asp:Label ID="TypeCh" runat="server" Font-Bold="True" ForeColor="#660066"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
    </table>
    </div>
    </form>
    
</body>
</html>
