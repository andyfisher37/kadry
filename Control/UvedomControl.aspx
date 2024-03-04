<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UvedomControl.aspx.cs" Inherits="kadry.Control.UvedomControl" %>

<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Информационная система обработки данных "Кадры" - контроль сроков уведомлений о 
            сокращении...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
    
	    <style type="text/css">
            .style1
            {
                font-weight: bold;
                text-decoration: underline;
            }
        </style>
    
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#cc66ff" aLink="#0066ff" link="#0000ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
		<TABLE style="WIDTH: 759px; HEIGHT: 3px" cellSpacing="0" cellPadding="0"
				width="759" align="left" border="0">
				<TR>
					<TD align="center"><IMG alt="" src="/images/header_small.gif" width="750" useMap="#Map2" border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP></TD>
				</TR>
				<TR>
					<TD align="center" class="Header">КОНТРОЛЬ СРОКОВ УВЕДОМЛЕНИЙ ОБ УВОЛЬНЕНИИ<br />
                    </TD>
				</TR>
				<TR>
					<TD align="center" class="style1">
                        <table bgcolor="#D1D1D1" style="width:100%;" align="left" class="maintext">
                            <tr>
                                <td align="left" colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Фильтр по подразделениям:</td>
                                <td align="left">
                                    <asp:DropDownList ID="podrList" runat="server" DataSourceID="kDataSource" 
                                        DataTextField="PODRAZDEL" DataValueField="KEY_OF_POD" Width="300px" 
                                        CssClass="label2">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Фильтр по службе:</td>
                                <td align="left">
                                    <asp:DropDownList ID="podrList0" runat="server" Width="300px" 
                                        CssClass="label2">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="style2">
                                    Период, в который должен истечь срок уведомления:</td>
                                <td align="left">
                                    с
                                    <ew:MaskedTextBox ID="Date1" runat="server" Mask="99.99.9999" Width="80px" 
                                        CssClass="label2"></ew:MaskedTextBox>
                                    &nbsp;по
                                    <ew:MaskedTextBox ID="Date2" runat="server" Mask="99.99.9999" Width="80px" 
                                        CssClass="label2"></ew:MaskedTextBox>
                                </td>
                                <td>
                                    <asp:ImageButton ID="Btn1" runat="server" 
                                        ImageUrl="../images/btn_sp.gif" onclick="Btn1_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style2">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    Список сотрудников у которых истекает срок уведомления на сегодня (+10 дней):<td>
                                    <asp:ImageButton ID="Btn2" runat="server" 
                                        ImageUrl="../images/btn_sp.gif" onclick="Btn2_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    </td>
                            </tr>
                        </table>
                    </TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 70px" align="justify" class="smalltext">
                        <br />
                        <asp:Table ID="vTable" runat="server" BorderColor="#000066" 
                            BorderStyle="Dotted" BorderWidth="1px" CellPadding="1" CellSpacing="1" 
                            GridLines="Both" HorizontalAlign="Center" BackColor="White">
                            <asp:TableRow runat="server">
                                <asp:TableCell runat="server" Font-Bold="True" HorizontalAlign="Center">№ п/п</asp:TableCell>
                                <asp:TableCell runat="server" Font-Bold="True" HorizontalAlign="Center">Фамилия</asp:TableCell>
                                <asp:TableCell runat="server" Font-Bold="True" HorizontalAlign="Center">Имя</asp:TableCell>
                                <asp:TableCell runat="server" Font-Bold="True" HorizontalAlign="Center">Отчество</asp:TableCell>
                                <asp:TableCell runat="server" Font-Bold="True" HorizontalAlign="Center">Подразделение</asp:TableCell>
                                <asp:TableCell runat="server" Font-Bold="True" HorizontalAlign="Center">Должность</asp:TableCell>
                                <asp:TableCell runat="server" Font-Bold="True" HorizontalAlign="Center">Дата 
                                выдачи уведомления</asp:TableCell>
                                <asp:TableCell runat="server" Font-Bold="True" HorizontalAlign="Center">Дата 
                                истечения срока</asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <br />
                    </TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 70px" align="justify" class="smalltext"><b>* Часть 5 статьи 36 
                        Федерального закона РФ от 30.11.2011 №342-ФЗ &quot;О службе в органах внутренних 
                        дел...&quot;:</b>&nbsp; при упразднении (ликвидации) территориального органа 
                        федерального органа исполнительной власти в сфере внутренних дел или 
                        подразделения либо сокращении должностей в органах внутренних дел руководитель 
                        федерального органа исполнительной власти в сфере внутренних дел или 
                        уполномоченный руководитель уведомляет в письменной форме сотрудника органов 
                        внутренних дел о предстоящем увольнении со службы в органах внутренних дел
                        <span class="style1">не позднее чем за два месяца до его увольнения</span>.</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 70px" align="center">
                        <asp:SqlDataSource ID="nDataSource" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:IASConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:IASConnectionString.ProviderName %>">
                        </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="kDataSource2" runat="server" 
                                        ConnectionString="DSN=KADRY;DBQ=C:\KADRY;DefaultDir=C:\KADRY;Driver={277};DriverId=277;FIL=dBase IV;MaxBufferSize=2048;PageTimeout=5;" 
                                        ProviderName="System.Data.Odbc">
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="kDataSource" runat="server" 
                                        ConnectionString="DSN=KADRY;DBQ=C:\KADRY;DefaultDir=C:\KADRY;Driver={277};DriverId=277;FIL=dBase IV;MaxBufferSize=2048;PageTimeout=5;" 
                                        ProviderName="System.Data.Odbc" 
                                        SelectCommand="SELECT [PODRAZDEL], [KEY_OF_POD] FROM [PODRAZD] WHERE KEY_OF_POD IN (SELECT DISTINCT(PODRAZD) FROM AAQQ)">
                                    </asp:SqlDataSource>
                                </TD>
				</TR>
		</TABLE>	
		</form>
	</body>
</html>
