<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TableLgottime.aspx.cs" Inherits="UK.TableLgottime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>Информационная система обработки данных "Кадры" - Таблица командировок для личного дела</title>
		<asp:Literal ID="_literal" runat="server"></asp:Literal>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio 9" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="Styles.css" rel="stylesheet">
		</head>
<body>
    <form id="form1" runat="server">
   
    
        <table style="width:64%;">
            <tr>
                <td align="center">
                    <asp:Label ID="TitleText" runat="server" CssClass="Header"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Solid" 
                        BorderWidth="1px" CellPadding="0" CellSpacing="0" CssClass="maintext" 
                        GridLines="Both" Width="900px">
                        <asp:TableRow runat="server" CssClass="maintext">
                            <asp:TableCell runat="server" HorizontalAlign="Center">Описание периода нахождения в служебной командировке</asp:TableCell>
                            <asp:TableCell runat="server" HorizontalAlign="Center" Width="10%">с..</asp:TableCell>
                            <asp:TableCell runat="server" HorizontalAlign="Center" Width="10%">..по</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
  
    </form>
</body>
</html>
