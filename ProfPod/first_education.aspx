<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="first_education.aspx.cs" Inherits="kadry.ProfPod.first_education" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>Информационная система обработки данных "Кадры" - Сведения о первоначальной подготовке...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
    <style type="text/css">
        .style1
        {
            font: 10pt Verdana, Arial, Helvetica, sans-serif;
            text-transform: none;
            color: #000000;
            direction: ltr;
            letter-spacing: normal;
        }
        .style2
        {
            font: 10pt Verdana, Arial, Helvetica, sans-serif;
            text-transform: none;
            color: #000000;
            direction: ltr;
            letter-spacing: normal;
            width: 346px;
        }
        .style3
        {
            width: 115px;
        }
        .style4
        {
            text-justify: inter-word;
            font-size: 9px;
            page-break-before: auto;
            word-spacing: normal;
            page-break-after: auto;
            color: #0000CC;
            text-indent: 0%;
            font-family: Verdana, Helvetica, sans-serif;
            white-space: normal;
        }
    </style>
</head>
<body text="#000000" bottomMargin="0" vLink="#990000" aLink="#6666ff" link="#0000ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td align="center" class="Header" colspan="3">
                    <asp:Label ID="FIO" runat="server" CssClass="Header"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Даты прохождения первоначальной подготовки:</td>
                <td class="style3">
                    с
                    <asp:Label ID="Begin_Date" runat="server" CssClass="label2"></asp:Label>
&nbsp;г.</td>
                <td>
                    по
                    <asp:Label ID="End_Date" runat="server" CssClass="label2"></asp:Label>
&nbsp;г.</td>
            </tr>
            <tr>
                <td class="style2">
                    Место прохождения первоначальной подготовки:</td>
                <td class="style3">
                    <asp:Label ID="Traning_Place" runat="server" CssClass="label2"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="style1" colspan="3">
                    <asp:Label ID="NoInfo" runat="server" CssClass="maintext" Font-Bold="True" 
                        Text="Сведений о первоначальной подготовке на данного сотрудника НЕТ" 
                        Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" class="style1" colspan="3">
                    <hr class="smalltext"></td>
            </tr>
            <tr>
                <td align="center" class="style4" colspan="3">
                    *Информация о первоначальной подготовке выбрана по АИС &quot;Боеготовность&quot; ОСБП УРЛС 
                    УВД</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
