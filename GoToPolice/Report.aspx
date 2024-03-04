<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="kadry.GoToPolice.Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
        <title>Информационно-аналитическая служба УРЛС УВД - Отчет о внеочередной аттестации...</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/Styles.css" rel="stylesheet">
        
        <style type="text/css">
            .style1
            {
                color: red;
            }
            .style2
            {
                width: 66px;
            }
        </style>
        
</head>
<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td align="right" class="smalltext" valign="top">
                    Приложение к распоряжению МВД России от 08.04.2011 № 1/2692<br />
                </td>
            </tr>
            <tr>
                <td align="right" class="smalltext" valign="top">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="Header">
                    <asp:Label ID="TitleText" runat="server" 
                        Text="Отчет о ходе проведения внеочередной аттестации&lt;br&gt;сотрудников органов внутренних дел Ивановской области, по состоянию на "></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table bgcolor="#FFE2A8" style="width: 92%; " class="maintext" border="1" 
                        cellpadding="1" cellspacing="1" frame="border">
                        <tr>
                            <td colspan="3" align="center">
                                Наименование показателя</td>
                            <td align="center" class="style2">
                                Всего</td>
                            <td align="center">
                                в т.ч. н/с</td>
                            <td align="center">
                                в т.ч. р/с</td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left">
                                Количество сотрудников, подлежащих внеочередной аттестации и претендующих:</td>
                            <td align="center" class="style2">
                                <asp:Label ID="i1" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n1" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r1" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                из них</td>
                            <td colspan="2" align="left">
                                на должности в полиции</td>
                            <td align="center" class="style2">
                                <asp:Label ID="i2" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n2" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                на иные должности</td>
                            <td align="center" class="style2">
                                <asp:Label ID="i3" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n3" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r3" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left">
                                Количество сотрудников, отказавшихся присутствовать на заседании аттестационной 
                                комиссии, и написавших рапорт о согласии с проведением внеочередной аттестации в 
                                их отсутствие</td>
                            <td align="center" class="style2">
                                <asp:Label ID="i4" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n4" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r4" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left">
                                Прошли внеочередную аттестацию:</td>
                            <td align="center" class="style2">
                                <asp:Label ID="i5" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n5" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r5" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="9">
                                из них по решению аттестационной комиссии:</td>
                            <td colspan="2" align="left">
                                рекомендовано для прохождения службы в полиции (ином подразделении органов 
                                внутренних дел РФ) на должности, на которую аттестуемый сотрудник претендует</td>
                            <td align="center" class="style2">
                                <asp:Label ID="i6" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n6" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r6" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                из них</td>
                            <td align="left">
                                назначено</td>
                            <td class="style2" align="center">
                                <asp:Label ID="i7" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n7" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r7" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                в том числе на должности в полиции</td>
                            <td class="style2" align="center">
                                <asp:Label ID="i8" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n8" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r8" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                рекомендовано для прохождения службы в полиции (ином подразделении органов 
                                внутренних дел РФ) на должности с меньшим объемом полномочий или на нижестоящие 
                                должности</td>
                                <td class="style2" align="center">
                                    <asp:Label ID="i9" runat="server"></asp:Label>
                            </td>
                                <td align="center">
                                <asp:Label ID="n9" runat="server"></asp:Label>
                            </td>
                                <td align="center">
                                <asp:Label ID="r9" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                из них</td>
                            <td align="left">
                                назначено</td>
                            <td class="style2" align="center">
                                <asp:Label ID="i10" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n10" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r10" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="left">
                                в том числе на должности в полиции</td>
                            <td class="style2" align="center">
                                <asp:Label ID="i11" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n11" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r11" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="left" colspan="2">
                                не рекомендовать для прохождения службы в полиции, предложить продолжить службу 
                                в ином подразделении органов внутренних дел РФ на другой, в том числе 
                                нижестоящей должности</td>
                            <td class="style2" align="center">
                                <asp:Label ID="i12" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n12" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r12" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td rowspan="2">
                                из них</td>
                            <td align="left">
                                назначено</td>
                            <td class="style2" align="center">
                                <asp:Label ID="i13" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n13" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r13" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="left">
                                в том числе на должности в полиции</td>
                            <td class="style2" align="center">
                                <asp:Label ID="i14" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n14" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r14" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="left" colspan="3">
                                Не прошли внеочередную аттестацию и (или) отказались продолжить службу в ОВД на 
                                иных, в том числе нижестоящих должностях и:</td>
                            <td class="style2" align="center">
                                <asp:Label ID="i15" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n15" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r15" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td rowspan="4">
                                из них</td>
                            <td align="left" colspan="2">
                                представлены к увольнению по инициативе органа внутренних дел</td>
                            <td class="style2" align="center">
                                <asp:Label ID="i16" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n16" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r16" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                из них</td>
                            <td align="left">
                                уволено</td>
                            <td class="style2" align="center">
                                <asp:Label ID="i17" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n17" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r17" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="left" colspan="2">
                                представлены к увольнению по инициативе сотрудника</td>
                            <td class="style2" align="center">
                                <asp:Label ID="i18" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n18" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r18" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                из них</td>
                            <td align="left">
                                уволено</td>
                            <td class="style2" align="center">
                                <asp:Label ID="i19" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="n19" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="r19" runat="server"></asp:Label>
                            </td>
                        </tr>

                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="smalltext">
                    <span class="style1">*</span> Во всех строках сведения указываются нарастающим 
                    итогом с начала работы аттестационных комиссий по проведению внеочередной 
                    аттестации.</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>