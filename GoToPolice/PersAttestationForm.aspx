<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersAttestationForm.aspx.cs" Inherits="kadry.GoToPolice.PersAttestationForm" %>

<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
        <title>Информационно-аналитическая служба УРЛС УВД - Внеочередная аттестация...</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/Styles.css" rel="stylesheet">
        <style type="text/css">
            .style1
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                width: 583px;
            }
            .style2
            {
            }
            .style3
            {
            }
            .style4
            {
                width: 583px;
            }
            .style5
            {
                color: #FF0000;
            }
        </style>
</head>
<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;" class="maintext">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="TitleText" runat="server" CssClass="Header"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr /></td>
            </tr>
            <tr>
                <td class="style1">
                    1. Дата внеочередной аттестации:<span class="style5">*</span></td>
                <td>
                    <ew:MaskedTextBox ID="Date1" runat="server" CssClass="label2" Height="16px" 
                        Mask="99.99.9999" Width="95px" ValidationGroup="99.99.9999"></ew:MaskedTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="Date1" ErrorMessage="Заполните дату аттестации"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    2. Решение аттестационной комиссии:<span class="style5">*</span><asp:CustomValidator 
                        ID="resValidator" runat="server" ControlToValidate="Resolution" 
                        ErrorMessage="Должен быть вывод по аттестации"></asp:CustomValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="2">
                    <asp:DropDownList ID="Resolution" runat="server" CssClass="label2" 
                        Height="18px" Width="852px">
                        <asp:ListItem Value="0">Не определено</asp:ListItem>
                        <asp:ListItem Value="1">Рекомендовать для прохождения службы в полиции (ином 
                        подразделении ОВД РФ) на должности, на которую аттестуемый сотрудник претендует</asp:ListItem>
                        <asp:ListItem Value="2">Рекомендовать для прохождения службы в полиции (ином 
                        подразделении ОВД РФ) на должности с меньшим объемом полномочий или на 
                        нижестоящей должности</asp:ListItem>
                        <asp:ListItem Value="3">Не рекомендовать для прохождения службы в полиции, 
                        предложить продолжить службу в ином подразделении ОВД РФ на другой должности, в 
                        том числе нижестоящей, должности</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    3. Наличие рапорта о согласии с проведением аттестации в его отсутствие:</td>
                <td>
                    <asp:CheckBox ID="raport" runat="server" CssClass="label2" Text="(Да/Нет)" />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    4. Не прошел аттестацию и (или) отказался продолжить службу в ОВД на иных, в том 
                    числе нижестоящих должностях:</td>
                <td>
                    <asp:CheckBox ID="negative" runat="server" CssClass="label2" Text="(Да/Нет)" />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    5. Дата представления к увольнению:</td>
                <td>
                    <ew:MaskedTextBox ID="Date2" runat="server" CssClass="label2" Height="16px" 
                        Mask="99.99.9999" Width="95px"></ew:MaskedTextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    6. Тип представления к увольнению:</td>
                <td>
                    <asp:RadioButton ID="UV1" runat="server" AutoPostBack="True" CssClass="label2" 
                        oncheckedchanged="UV1_CheckedChanged" Text="по инициативе ОВД" />
                    <asp:RadioButton ID="UV2" runat="server" AutoPostBack="True" CssClass="label2" 
                        oncheckedchanged="UV2_CheckedChanged" Text="по инициативе сотрудника" />
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="2">
                    <hr /></td>
            </tr>
            <tr>
                <td align="center" class="style3" colspan="2">
                    <asp:ImageButton ID="SaveButton" runat="server" 
                        ImageUrl="/images/btn_save.gif" onclick="SaveButton_Click" />
&nbsp;
                    <asp:ImageButton ID="ClearButton" runat="server" 
                        ImageUrl="/images/btn_clear.gif" onclick="ClearButton_Click" />
&nbsp;
                    <asp:ImageButton ID="CancelButton" runat="server" 
                        ImageUrl="/images/btn_cancel.gif" onclick="CancelButton_Click" />
                    <br />
                    <br />
                    <asp:Button ID="DeleteButton" runat="server" onclick="DeleteButton_Click" 
                        Text="удалить информацию об аттестации" />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <span class="style5">*</span> - поля, обязательные к заполнению.</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    <asp:SqlDataSource ID="KDataSource" runat="server" 
        ConnectionString="DSN=KADRY;DBQ=C:\KADRY;DefaultDir=C:\KADRY;Driver={277};DriverId=277;FIL=dBase IV;MaxBufferSize=2048;PageTimeout=5;" 
        ProviderName="System.Data.Odbc" 
        
        SelectCommand="SELECT FAMILIYA, IMYA, OTCHECTVO, LICH_NOM_1, LICH_NOM_2, REAL_DOLZN FROM AAQQ WHERE KEY_1 = @key">
        <SelectParameters>
            <asp:QueryStringParameter Name="key" QueryStringField="id" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="ADataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IASConnectionString %>" 
        
        
        
        SelectCommand="SELECT att_date, resolution, att_no_men, att_negative, predst_uvol, self_uvol, category FROM PoliceAttestation WHERE id = @key" 
        DeleteCommand="DELETE FROM PoliceAttestation WHERE (id = @key )">
        <SelectParameters>
            <asp:QueryStringParameter Name="key" QueryStringField="id" />
        </SelectParameters>
        <DeleteParameters>
            <asp:QueryStringParameter Name="key" QueryStringField="id" />
        </DeleteParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
