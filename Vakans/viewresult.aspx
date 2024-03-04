<%@ Page language="c#" Codebehind="viewresult.aspx.cs" AutoEventWireup="True" Inherits="kadry.Vakans.viewresult" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - список вакантных должностей</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#990000" aLink="#6666ff" link="#0000ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE border="0">
				<TR>
					<TD class="Header" style="HEIGHT: 23px" align="right" height="23">
                                <asp:ImageButton ID="ExcelButton" runat="server" 
                                    ImageUrl="..\images\btn_excel.gif" onclick="ExcelButton_Click" 
                                    Visible="False" />
                    </TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 23px" align="right" height="23"> 
                        <asp:ImageButton ID="WordButton" runat="server" ImageUrl="..\images\btn_word.gif" 
                                    onclick="WordButton_Click" Visible="False" style="height: 19px" />
                            </TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 23px" align="center" height="23"><asp:label class="label2" id="TitleText" runat="server" Width="607px"></asp:label></TD>
				</TR>
				</TABLE>
            <asp:table id="Table" runat="server" Width="1000px" BorderColor="#404040" Font-Size="XX-Small"
							GridLines="Both" CellPadding="1" CellSpacing="0" BackColor="Azure" Font-Names="Verdana" 
                            BorderWidth="1px">
							<asp:TableRow BackColor="#FFCC99" Font-Size="XX-Small" Font-Names="Verdana" 
                                Font-Bold="True">
								<asp:TableCell HorizontalAlign="Center" Text="Наименование должности (количество)"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Подразделение (структурное подразделение)"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Служба"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Дата вакансии"></asp:TableCell>
								<%--<asp:TableCell HorizontalAlign="Center" Text="Ист.фин."></asp:TableCell>--%>
								<asp:TableCell HorizontalAlign="Center" Text="Предельное звание по должности"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Center" Text="Оклад (тар.разр.)"></asp:TableCell>
							</asp:TableRow>
						</asp:table>
						<asp:Label class="maintext" id="CountLabel" runat="server"></asp:Label>
		</form>
	</body>
</HTML>
