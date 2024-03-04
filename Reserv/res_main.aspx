<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="res_main.aspx.cs" Inherits="kadry.Reserv.Res_main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
    <title>Информационная система обработки данных "Кадры" - Резерв кадров на выдвижение...</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
	<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
	<meta name="CODE_LANGUAGE" Content="C#">
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
	<link href="/Styles.css" rel="stylesheet">
    <style type="text/css">
        .style1
        {
            font: normal normal 700 10pt normal Verdana, Arial, Helvetica, sans-serif;
            text-transform: none;
            color: #000000;
            direction: ltr;
            letter-spacing: normal;
            }
        .style2
        {
        }
        .style3
        {
        }
p.ConsPlusTitle
	{margin-bottom:.0001pt;
	text-autospace:none;
	font-size:10.0pt;
	font-family:Arial;
	font-weight:bold;
            margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }
        .style4
        {
            font: 10pt Verdana, Arial, Helvetica, sans-serif;
            text-transform: none;
            color: #000000;
            direction: ltr;
            letter-spacing: normal;
            width: 300px;
        }
        .style5
        {
            font: normal normal bold 10pt normal Verdana, Arial, Helvetica, sans-serif;
            text-transform: none;
            color: #000000;
            direction: ltr;
            letter-spacing: normal;
        }
        .style6
        {
            font: normal normal 700 10pt normal Verdana, Arial, Helvetica, sans-serif;
            text-transform: none;
            color: #000000;
            direction: ltr;
            letter-spacing: normal;
        }
    </style>
</head>
<body text="#000000" vLink="#000000" aLink="#000000" link="#000000" bgColor="#ffffff"
			leftMargin="0" background="/images/background.gif" topMargin="0" MS_POSITIONING="GridLayout"
			bottomMargin="0" bgProperties="fixed" rightMargin="0">
    <form id="form1" runat="server">
    <table style="width: 79%;">
        <tr>
         <TD style="WIDTH: 712px; HEIGHT: 99px" vAlign="top" align="center" colSpan="2">
         <IMG alt="Информационная система обработки данных "Кадры"" src="/images/header_small.gif" useMap="#Map2" border="0">
	     </TD>
		</tr>
        
        <tr>
            <td colspan="2" align="center" valign="top" class="Header">
                РАБОТА С РЕЗЕРВОМ КАДРОВ (номенклатура начальника УВД)<br>!!! работает в тестовом режиме !!!</td>
        </tr>
        <tr>
            <td colspan="2">
                <table align="center" bgcolor="#99CCFF" style="width:94%;">
                    <tr>
                        <td class="style6" align="left">
                            Всего сотрудников в резерве:                             <asp:Label ID="CountPers" runat="server" CssClass="label2"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" align="left">
                            Всего должностей в резерве:
                            <asp:Label ID="CountDolz" runat="server" CssClass="label2"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                        <a href="reserv_prikaz.doc">Приказ МВД России от 13.07.2007 № 629 &quot;Об утверждении положения о порядке формирования резерва для назначения на должности руководящего состава 
                            ОВД РФ и работе с ним&quot;</a></td>
                    </tr>
                    <tr>
                        <td class="label">
                        <a href="reserv_metoda.doc">Методические рекомендации &quot;О подготовке и формировании резерва для назначения 
                            на должности руководящего состава&quot;</a></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <table align="center" bgcolor="#FFCC99" style="width:94%; height: 145px;" 
                    class="maintext">
                    <tr>
                        <td class="style1" colspan="2">
                            Формирование списков сотрудников, зачисленных в резерв:</td>
                    </tr>
                    <tr>
                        <td class="style4">
                            Подразделение:</td>
                        <td class="style3">
                            <asp:DropDownList ID="podrList" runat="server" DataSource="<%# podrDataSet %>" 
                                Width="300px" DataMember="Table" DataTextField="PODRAZDEL" 
                                DataValueField="KEY_OF_POD">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Служба:</td>
                        <td class="style3">
                            <asp:DropDownList ID="sluzList" runat="server" Width="300px" DataTextField="NAM_OF_SLU" DataValueField="KEY_OF_SLU" DataSource="<%# sluzDataSet %>">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            </td>
                        <td class="style3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2" align="center" colspan="2">
                            <asp:ImageButton ID="ListButton1" runat="server" 
                                ImageUrl="..//images/btn_sp.gif" />
                        </td>
                    </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            
        </tr>
    </table>
    </form>
    
</body>
</html>
