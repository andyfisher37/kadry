<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UvedomReport.aspx.cs" Inherits="UK.UvedomReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Отчет о выписанных и врученных уведомлениях об увольнении</title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
    <link href="/Styles.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div class="style1">
            Отчет о выписанных и врученных 
            уведомлениях об увольнении сотрудникам УМВД РФ по Ивановской области:<br />
            <hr />
            <asp:Button ID="Button1" runat="server" CssClass="label2" 
                onclick="Button1_Click" Text="Пофамильный список" />
&nbsp;<asp:Button ID="Button2" runat="server" CssClass="label2" 
                Text="Статистика по ГРУОВД" onclick="Button2_Click" />
            <br />
            <br />
        </div>
        <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Dotted" 
            BorderWidth="1px" CellPadding="0" CellSpacing="0" GridLines="Both" 
            CssClass="maintext" Visible="False" BackColor="#E9E9E9" 
            HorizontalAlign="Center">
            <asp:TableRow runat="server" CssClass="maintext" HorizontalAlign="Center">
                <asp:TableCell runat="server">Фамилия, Имя, Отчество</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Подразделение</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Личный номер</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Выписано</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Вручено</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <center>
            <asp:Label ID="Title2" runat="server" CssClass="maintext" 
                Text="Подразделения УМВД РФ по Ивановской области (без учета вневедомственной охраны)" 
                Visible="False"></asp:Label>
        </center>
            <asp:Table ID="Table2" runat="server" BorderColor="Black" BorderStyle="Dotted" 
            BorderWidth="1px" CellPadding="0" CellSpacing="0" GridLines="Both" 
            CssClass="maintext" Visible="False" BackColor="#CCFFFF" 
            HorizontalAlign="Center">
            <asp:TableRow runat="server" CssClass="maintext" HorizontalAlign="Center">
                <asp:TableCell runat="server">Наименование подразделения</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Выписано
                <br>уведомлений</br>
                </asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Вручено
                <br>уведомлений</br>
                </asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Вручено от
                <br>фактической численности, (%)</br>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <center>
        <asp:Label ID="Title3" runat="server" CssClass="maintext" 
                Text="Подразделения Вневедомственной охраны" Visible="False"></asp:Label>
        </center>
        <asp:Table ID="Table3" runat="server" BorderColor="Black" BorderStyle="Dotted" 
            BorderWidth="1px" CellPadding="0" CellSpacing="0" GridLines="Both" 
            CssClass="maintext" Visible="False" BackColor="#CCFFFF" 
            HorizontalAlign="Center">
            <asp:TableRow runat="server" CssClass="maintext" HorizontalAlign="Center">
                <asp:TableCell runat="server">Наименование подразделения</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Выписано
                <br>уведомлений</br>
                </asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Вручено
                <br>уведомлений</br>
                </asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Вручено от
                <br>фактической численности, (%)</br>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
<br />    
        <center>
        <asp:Label ID="Itog" runat="server" CssClass="label2" Visible="False"></asp:Label>
        </center>
    
    </div>
    <asp:SqlDataSource ID="kDataSource1" runat="server" 
        ConnectionString="DSN=KADRY;DBQ=C:\KADRY;DefaultDir=C:\KADRY;Driver={277};DriverId=277;FIL=dBase IV;MaxBufferSize=2048;PageTimeout=5;" 
        ProviderName="System.Data.Odbc" 
        
        
        SelectCommand="SELECT FAMILIYA, IMYA, OTCHECTVO, LICH_NOM_1, LICH_NOM_2, KEY_1, PODRAZDEL, NAIMENOVAN  FROM AAQQ, PODRAZD, NAIMEN WHERE KEY_1 &lt;&gt; 0 AND DOLZNOST &lt; '800000' AND FAMILIYA &lt;&gt; '' AND PODRAZD = KEY_OF_POD AND PODR = KEY_OF_NAI ORDER BY FAMILIYA, IMYA, OTCHECTVO">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="kDataSource2" runat="server" 
        ConnectionString="DSN=KADRY;DBQ=C:\KADRY;DefaultDir=C:\KADRY;Driver={277};DriverId=277;FIL=dBase IV;MaxBufferSize=2048;PageTimeout=5;" 
        ProviderName="System.Data.Odbc" 
        
        
        
        SelectCommand="SELECT FAMILIYA, IMYA, OTCHECTVO, LICH_NOM_1, LICH_NOM_2, KEY_1, PODRAZDEL, NAIMENOVAN  FROM AAQQ, PODRAZD, NAIMEN WHERE KEY_1 &lt;&gt; 0 AND DOLZNOST &lt; '800000' AND FAMILIYA &lt;&gt; '' AND PODRAZD = KEY_OF_POD AND PODR = KEY_OF_NAI AND SLUZBA NOT IN (9,52) ORDER BY PODRAZD, NAIMENOVAN">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="kDataSource3" runat="server" 
        ConnectionString="DSN=KADRY;DBQ=C:\KADRY;DefaultDir=C:\KADRY;Driver={277};DriverId=277;FIL=dBase IV;MaxBufferSize=2048;PageTimeout=5;" 
        ProviderName="System.Data.Odbc" 
        
        
        
        SelectCommand="SELECT FAMILIYA, IMYA, OTCHECTVO, LICH_NOM_1, LICH_NOM_2, KEY_1, PODRAZDEL, NAIMENOVAN  FROM AAQQ, PODRAZD, NAIMEN WHERE KEY_1 &lt;&gt; 0 AND DOLZNOST &lt; '800000' AND FAMILIYA &lt;&gt; '' AND PODRAZD = KEY_OF_POD AND PODR = KEY_OF_NAI AND SLUZBA IN (9,52) ORDER BY PODRAZD, NAIMENOVAN">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="uDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IASConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:IASConnectionString.ProviderName %>">
    </asp:SqlDataSource>
    </form>
</body>
</html>
