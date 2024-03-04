<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UVGive.aspx.cs" Inherits="UK.UVGive" %>

<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Информационная система обработки данных "Кадры" - Выдать уведомление об увольнении...</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="/Styles.css" rel="stylesheet">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            font: 10pt Verdana, Arial, Helvetica, sans-serif;
            text-transform: none;
            color: #000000;
            direction: ltr;
            letter-spacing: normal;
            width: 211px;
        }
        .style3
        {
            color: #FF6600;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td align="center" class="style1" colspan="2">
                    <asp:Label ID="TitleText" runat="server" CssClass="Header"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Дата выдачи уведомления:</td>
                <td>
                    <ew:MaskedTextBox ID="DateGive" runat="server" CssClass="label2" 
                        Mask="99.99.9999" ToolTip="Дата выдачи уведомления" Width="100px"></ew:MaskedTextBox>
&nbsp;<span class="style3">* Если оставить дату пустую, дата выдачи ликвидируется</span></td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:SqlDataSource ID="kDataSource" runat="server" 
                        ConnectionString="DSN=KADRY;DBQ=C:\KADRY;DefaultDir=C:\KADRY;Driver={277};DriverId=277;FIL=dBase IV;MaxBufferSize=2048;PageTimeout=5;" 
                        ProviderName="System.Data.Odbc" 
                        SelectCommand="SELECT FAMILIYA, IMYA, OTCHECTVO, LICH_NOM_1, LICH_NOM_2 FROM AAQQ WHERE KEY_1 = @key">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="key" QueryStringField="id" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="uvDataSource" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:IASConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:IASConnectionString.ProviderName %>" 
                        
                        SelectCommand="SELECT date_notification_print, date_notification_give FROM Notification WHERE id = @key" 
                        UpdateCommand="UPDATE Notification SET date_notification_give = convert(smalldatetime, @date1, 104) WHERE (id = @key )">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="key" QueryStringField="id" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:ControlParameter ControlID="DateGive" DefaultValue="null" Name="date1" 
                                PropertyName="Text" />
                            <asp:QueryStringParameter Name="key" QueryStringField="id" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="label2" 
                        onclick="Button1_Click" Text="Сохранить" />
&nbsp;
                    <asp:Button ID="Button2" runat="server" CssClass="label2" 
                        onclick="Button2_Click" Text="Отмена" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
