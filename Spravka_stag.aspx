<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Spravka_stag.aspx.cs" Inherits="UK.Spravka_stag" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Информационная система обработки данных "Кадры" - Справка о стаже службы в ОВД (в календарном исчислении)</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="Styles.css" rel="stylesheet">
    <style type="text/css">

            .maintext
{
	font: 10pt Verdana, Arial, Helvetica, sans-serif;
	text-transform: none;
	color: #000000;
	direction: ltr;
	letter-spacing: normal;
}
            .style1
            {
                font: normal normal normal 9pt normal Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
            }
            p.MsoNormal
	{margin-bottom:.0001pt;
	font-size:12.0pt;
	font-family:"Times New Roman";
	        margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }
        .style2
        {
            width: 231px;
        }
            </style>
</head>
<body>
    <form id="form1" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 64px; WIDTH: 664px; POSITION: absolute; TOP: 16px; HEIGHT: 188px"
				cellSpacing="0" cellPadding="0" width="664" border="0">
				<TR>
					<TD style="WIDTH: 278px" align="center"><IMG style="WIDTH: 136px; HEIGHT: 80px" height="80" alt="" src="images/gerb2.gif" width="136"></TD>
					<TD align="right">
						&nbsp;</TD>
				</TR>
				<TR>
					<TD class="maintext" style="WIDTH: 278px" align="center"><STRONG>МВД РОСCИИ</STRONG></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="maintext" style="WIDTH: 278px" align="center"><STRONG>УПРАВЛЕНИЕ 
                        МИНИСТЕРСТВА ВНУТРЕННИХ 
							ДЕЛ<br />
&nbsp;РОССИЙСКОЙ ФЕДЕРАЦИИ</STRONG></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="maintext" style="WIDTH: 278px" align="center"><STRONG>ПО ИВАНОВСКОЙ ОБЛАСТИ</STRONG></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="style1" style="WIDTH: 278px; HEIGHT: 17px" align="center">(УМВД России по 
						Ивановской области)</TD>
					<TD style="HEIGHT: 17px"></TD>
				</TR>
				<TR>
					<TD class="maintext" style="WIDTH: 278px; HEIGHT: 23px" align="center">УПРАВЛЕНИЕ 
						ПО РАБОТЕ<br />
                        С ЛИЧНЫМ СОСТАВОМ</TD>
					<TD style="HEIGHT: 23px"></TD>
				</TR>
				<TR>
					<TD class="maintext" style="WIDTH: 278px" align="center"><FONT size="1">пр.Ленина д.37, 
							г.Иваново, 153002</FONT></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="maintext" style="WIDTH: 278px" align="center">от &quot;___&quot;____________№_________<br />
                        на №________ от &quot;___&quot;__________</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="maintext" style="WIDTH: 278px" align="center">&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
    <table id="Table2" style="Z-INDEX: 401; LEFT: 64px; WIDTH: 664px; POSITION: absolute; TOP: 324px; HEIGHT: 257px"
				cellSpacing="0" cellPadding="0" width="664" border="0">
        <tr>
            <td align="center" colspan="3">
                <span style="font-size:14.0pt;font-family:&quot;Times New Roman&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-ansi-language:RU;mso-fareast-language:
RU;mso-bidi-language:AR-SA">СПРАВКА</span></td>
        </tr>
        <tr>
            <td align="justify" colspan="3">
                <p class="MsoNormal" style="text-align:justify">
                    <span style="font-size:14.0pt"><span style="mso-tab-count:1">&nbsp;&nbsp; </span>
                    <asp:Label ID="zvanie" runat="server"></asp:Label>
&nbsp;<asp:Label ID="FIO" runat="server" Font-Bold="True"></asp:Label>
                    &nbsp;<asp:Label ID="pnumber" runat="server"></asp:Label>
                    , 
                    <asp:Label ID="dolznost" runat="server"></asp:Label>
                    ,&nbsp;служит в органах внутренних дел Российской Федерации с 
                    <asp:Label ID="vovd" runat="server"></asp:Label>
&nbsp;года по настоящее время.<o:p></o:p></span></p>
                <span style="font-size:14.0pt;font-family:&quot;Times New Roman&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;mso-ansi-language:RU;mso-fareast-language:RU;mso-bidi-language:
AR-SA"><span style="mso-tab-count:1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>Стаж службы в органах внутренних дел 
                <asp:Label ID="FIOsmall" runat="server"></asp:Label>
&nbsp;на 
                <asp:Label ID="curdate" runat="server"></asp:Label>
&nbsp;года составляет 
                <asp:Label ID="stag" runat="server"></asp:Label>
&nbsp;в календарном исчислении.</span></td>
        </tr>
        <tr>
            <td>
                <p class="MsoNormal">
                    <span style="font-size:14.0pt">Начальник отдела кадров<o:p></o:p></span></p>
                <span style="font-size:14.0pt;font-family:&quot;Times New Roman&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;mso-ansi-language:RU;mso-fareast-language:RU;mso-bidi-language:
AR-SA">полковник внутренней службы</span></td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <span style="font-size:14.0pt;font-family:&quot;Times New Roman&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-ansi-language:RU;mso-fareast-language:
RU;mso-bidi-language:AR-SA">В.Г.Шапошников</span></td>
        </tr>
        
    </table>
    </form>
    </body>
</html>
