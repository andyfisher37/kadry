<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfileEdit.aspx.cs" Inherits="UK.ProfileEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table>
     <tr>
     <td>Фамилия:</td>
     <td>
         <asp:TextBox ID="fname" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
     <td>Имя:</td>
     <td>
         <asp:TextBox ID="mname" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
     <td>Отчество:</td>
     <td>
         <asp:TextBox ID="lname" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
     <td align="center" colspan="2">
          <asp:Button ID="SaveBtn" runat="server" Text="Сохранить" />
         </td>
     </tr>
     </table>
    </div>
    </form>
</body>
</html>
