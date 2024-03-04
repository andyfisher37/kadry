<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sbp_stat.aspx.cs" Inherits="kadry.ProfPod.sbp_stat" %>

<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Информационная система обработки данных "Кадры" - Статистика служебно-боевой подготовки...</title>
    <link href="/Styles.css" rel="stylesheet">
</head>
<BODY text="#000000" bottomMargin="0" vLink="#cc0000" aLink="#6666ff"
		link="#ff9966" bgProperties="fixed" bgColor="#ffffff" leftMargin="0" background="/images/background.gif"
		topMargin="0" rightMargin="0" ms_positioning="GridLayout">
    <form id="form1" runat="server">
    <TABLE id="Table1" style="WIDTH: 720px; HEIGHT: 128px" cellSpacing="0" cellPadding="0"
				width="720" border="0">
				<TR>
					<TD><IMG alt="" src="/images/header_small.gif"></TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 1px" vAlign="top" align="center">СТАТИСТИКА ПО 
                        БОЕВОЙ, ФИЗИЧЕСКОЙ и СПЕЦИАЛЬНОЙ ПОДГОТОВКЕ<br />
                        В УВД по ИВАНОВСКОЙ ОБЛАСТИ<br><br>
                    </TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 348px" vAlign="top" align="center">
						<table bgcolor="#D1D1D1" class="maintext" style="width: 87%; height: 162px;">
                            <tr>
                                <td align="right">
                                    Период расчета:
                                </td>
                                <td align="center" valign="middle">
                                    с
                                    <ew:MaskedTextBox ID="Date1" runat="server" Mask="99.99.9999"></ew:MaskedTextBox>
&nbsp;по
                                    <ew:MaskedTextBox ID="Date2" runat="server" Mask="99.99.9999"></ew:MaskedTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Статистика по подразделениям:                                 </td>
                                <td align="center">
                                    <asp:imagebutton id="StatBtn1" runat="server" ImageUrl="..//images/btn_stat.gif" 
                                        ToolTip="Расчитать по подразделениям..."></asp:imagebutton>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Статистика по службам:
                                </td>
                                <td align="center">
                                    <asp:imagebutton id="StatBtn2" runat="server" ImageUrl="..//images/btn_stat.gif" 
                                        ToolTip="Расчитать по службам"></asp:imagebutton>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    &nbsp;</td>
                                <td align="center">
                                    <asp:SqlDataSource ID="SqlDataSource" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:SBPConnectionString %>" 
                                        ProviderName="System.Data.SqlClient" 
                                        SelectCommand="SELECT [PrivateNumber] FROM [Grade]"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="Info" runat="server" CssClass="label2"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
    </form>
    </body>
</html>
