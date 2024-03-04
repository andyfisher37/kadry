<%@ Page language="c#" Codebehind="viewstr.aspx.cs" AutoEventWireup="True" Inherits="kadry.Structure.viewstr" codePage="65001"%>
<%@ Register assembly="Obout.Ajax.UI" namespace="Obout.Ajax.UI.TreeView" tagprefix="obout" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - просмотр оргаштатной 
			структуры...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#990000" aLink="#6666ff" link="#0000ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" border="0">
				<TR>
					<TD align="left"><IMG alt="" src="..//images/strhead.gif" height="17" width="950"></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Label class="label2" id="TitleText" runat="server"></asp:Label><br>
						<asp:Table id="Table" runat="server" Width="950px" BackColor="#FFFFC0" BorderColor="Black"
							BorderWidth="1px" CellPadding="0" CellSpacing="0" Font-Size="XX-Small" Font-Names="Verdana"
							GridLines="Both" Visible="False">
							<asp:TableRow HorizontalAlign="Center">
								<asp:TableCell Text="Должность"></asp:TableCell>
								<asp:TableCell Text="Специальное звание"></asp:TableCell>
								<asp:TableCell Text="Фамилия"></asp:TableCell>
								<asp:TableCell Text="Имя"></asp:TableCell>
								<asp:TableCell Text="Отчество"></asp:TableCell>
								<asp:TableCell Text="Дата рождения"></asp:TableCell>
								<asp:TableCell Text="Личный номер"></asp:TableCell>
								<asp:TableCell Text="Предельное звание по должности"></asp:TableCell>
								<asp:TableCell Text="Дол.оклад"></asp:TableCell>
								<asp:TableCell Text="в ОВД"></asp:TableCell>
								<asp:TableCell Text="в Должн."></asp:TableCell>
							</asp:TableRow>
						</asp:Table>
                        <obout:Tree ID="Tree1" runat="server" ClientIDMode="AutoID" 
                            CssClass="vista_rtl" EnableTheming="False" LoadingMessage="Загрузка..." 
                            NodeDropTargets="" Visible="False" Width="200px">
                            <Nodes>
                                <obout:Node ClientID="" Text="УМВД России по Ивановской области">
                                    <obout:Node ClientID="" Text="аппарат УМВД России по Ивановской области">
                                        <obout:Node ClientID="" Text="УРЛС">
                                        </obout:Node>
                                        <obout:Node ClientID="" Text="УУР">
                                        </obout:Node>
                                    </obout:Node>
                                    <obout:Node ClientID="" Text="УМВД России по городу Иваново">
                                        <obout:Node ClientID="" Text="ОБ ППС">
                                        </obout:Node>
                                    </obout:Node>
                                    <obout:Node ClientID="" Text="Отдел МВД России &quot;Вичугский&quot;">
                                        <obout:Node ClientID="" Text="Отдел полиции №7">
                                        </obout:Node>
                                    </obout:Node>
                                    <obout:Node ClientID="" Text="Отдел МВД России &quot;Ивановский&quot;">
                                        <obout:Node ClientID="" Text="New Node">
                                        </obout:Node>
                                    </obout:Node>
                                    <obout:Node ClientID="" Text="Отдел МВД России &quot;Комсомольский&quot;">
                                        <obout:Node ClientID="" Text="New Node">
                                        </obout:Node>
                                    </obout:Node>
                                    <obout:Node ClientID="" Text="Отдел МВД России &quot;Кинешемский&quot;">
                                        <obout:Node ClientID="" Text="New Node">
                                        </obout:Node>
                                    </obout:Node>
                                    <obout:Node ClientID="" Text="Отдел МВД России &quot;Родниковский&quot;">
                                        <obout:Node ClientID="" Text="New Node">
                                        </obout:Node>
                                    </obout:Node>
                                    <obout:Node ClientID="" Text="Отдел МВД России &quot;Приволжский&quot;">
                                        <obout:Node ClientID="" Text="New Node">
                                        </obout:Node>
                                    </obout:Node>
                                    <obout:Node ClientID="" Text="Отдел МВД России &quot;Фурмановский&quot;">
                                        <obout:Node ClientID="" Text="New Node">
                                        </obout:Node>
                                    </obout:Node>
                                    <obout:Node ClientID="" Text="Отдел МВД России &quot;Тейковский&quot;">
                                        <obout:Node ClientID="" Text="New Node">
                                        </obout:Node>
                                    </obout:Node>
                                    <obout:Node ClientID="" Text="Отдел МВД России &quot;Пучежский&quot;">
                                        <obout:Node ClientID="" Text="New Node">
                                        </obout:Node>
                                    </obout:Node>
                                    <obout:Node ClientID="" Text="Отдел МВД России &quot;Южский&quot;">
                                        <obout:Node ClientID="" Text="New Node">
                                        </obout:Node>
                                    </obout:Node>
                                </obout:Node>
                            </Nodes>
                        </obout:Tree>
                        <br />
						<asp:ImageButton ID="ExcelCopyButton" runat="server" 
                            ImageUrl="..\images\btn_excel.gif" onclick="ExcelCopyButton_Click" 
                            Visible="False" />
&nbsp;<asp:ImageButton ID="WordCopyButton" runat="server" ImageUrl="..\images\btn_word.gif" 
                            onclick="WordCopyButton_Click" Visible="False" />
                                        <asp:SqlDataSource ID="uvDataSource" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:IASConnectionString %>" 
                                            ProviderName="<%$ ConnectionStrings:IASConnectionString.ProviderName %>" 
                                            SelectCommand="SELECT date_notification_print, date_notification_give FROM Notification WHERE id = @key">
                                        </asp:SqlDataSource>
						<br>
						<asp:Label class="smalltext" id="LCount" runat="server"></asp:Label><br>
					</TD>
				</TR>
				</TABLE>
		</form>
	</body>
</HTML>
