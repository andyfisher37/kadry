<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Declaration.aspx.cs" Inherits="kadry.Declaration.Declaration" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="System.Web.Ajax" namespace="System.Web.UI" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Информационная система обработки данных "Кадры" - Декларации сотрудников...</title>
    <link href="/Styles.css" rel="stylesheet">
    <style type="text/css">
        .style2
        {
            height: 5px;
            width: 30px;
        }
        .style4
        {
            height: 15px;
            }
        .style6
        {
            width: 250px;
            height: 10px;
        }
        .style7
        {
            width: 30px;
            height: 10px;
        }
        .style8
        {
            height: 17px;
        }
    </style>
</head>
<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
    <form id="form1" runat="server">
    <div>
    <TABLE cellSpacing="0" cellPadding="0" width="760" align="left" border="0" HSPACE="0" VSPACE="0">
				<TBODY>
					<TR>
						<TD style="WIDTH: 848px; HEIGHT: 66px" vAlign="top" align="center" colSpan="19"><IMG alt="" src="/images/header_small.gif" width="750" useMap="#Map2" border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP></TD>
					</TR>
					<TR vAlign="top" align="center">
						<TD vAlign="top" align="center" colSpan="1" height="16" rowSpan="1">
                            <SPAN class="Header">Учет предоставления СВЕДЕНИЙ О ДОХОДАХ<br />
                            (КОНФИДЕНЦИАЛЬНО)</SPAN></TD>
					</TR>
					<TR vAlign="top" align="left">
						<TD style="HEIGHT: 100px" vAlign="top" noWrap align="center" colSpan="1" height="100"
							rowSpan="1">
							<BLOCKQUOTE>
								<P>
									<TABLE class="maintext" id="Table1" style="WIDTH: 305px; HEIGHT: 145px" cellSpacing="1"
										cellPadding="1" bgColor="#D1D1D1" border="0">
										<TR>
											<TD align="right" colSpan="1" rowSpan="1" class="style7">Фамилия:</TD>
											<TD align="left" class="style6">
                                                <asp:TextBox ID="first_name" runat="server" Width="170px" CssClass="label2" 
                                                    ontextchanged="first_name_TextChanged"></asp:TextBox>
                                            </TD>
										</TR>
										<TR>
											<TD align="right" class="style2">
                                                Имя:</TD>
											<TD style="WIDTH: 250px; HEIGHT: 5px" align="left">
                                                <asp:TextBox ID="second_name" runat="server" Width="170px" CssClass="label2" 
                                                    ontextchanged="second_name_TextChanged"></asp:TextBox>
                                            </TD>
										</TR>
										<TR>
											<TD align="right" class="style2">Отчество:</TD>
											<TD style="WIDTH: 250px; HEIGHT: 5px" align="left">
                                                <asp:TextBox ID="last_name" runat="server" Width="170px" CssClass="label2" 
                                                    ontextchanged="last_name_TextChanged"></asp:TextBox>
                                            </TD>
										</TR>
										<TR>
											<TD align="center" class="style8" colspan="2">
                                                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Найти" />
                                            </TD>
										</TR>
										<TR>
											<TD align="left" class="style4" colspan="2">
                                                <asp:Label ID="ResultLabel" runat="server"></asp:Label>
                                            </TD>
										</TR>
										</TABLE>
		</P>
                                <P>
									<asp:GridView ID="Grid" runat="server" AutoGenerateColumns="False" 
                                        CellPadding="4" DataSourceID="OdbcDataSource" ForeColor="#333333" 
                                        GridLines="None" onrowediting="Grid_RowEditing">
                                        <RowStyle BackColor="#EFF3FB" />
                                        <Columns>
                                            <asp:CommandField EditText="Изменить" ShowCancelButton="False" 
                                                ShowEditButton="True" >
                                                <ItemStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                            </asp:CommandField>
                                            <asp:BoundField DataField="FAMILIYA" HeaderText="Фамилия" 
                                                SortExpression="FAMILIYA" ReadOnly="True" />
                                            <asp:BoundField DataField="IMYA" HeaderText="Имя" SortExpression="IMYA" 
                                                ReadOnly="True" />
                                            <asp:BoundField DataField="OTCHECTVO" HeaderText="Отчество" 
                                                SortExpression="OTCHECTVO" ReadOnly="True" />
                                            <asp:BoundField DataField="DATA_ROZD" DataFormatString="{0:d}" 
                                                HeaderText="Дата рождения" SortExpression="DATA_ROZD" ReadOnly="True" />
                                            <asp:BoundField DataField="KEY_1" HeaderText="Ключ" SortExpression="KEY_1" 
                                                ReadOnly="True" />
                                            <asp:TemplateField HeaderText="Сведения о доходах">
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="OdbcDataSource" runat="server" 
                                        ConnectionString="DSN=KADRY;DefaultDir=C:\KADRY;DriverId=277;FIL=dBase 5.0;MaxBufferSize=2048;PageTimeout=0;" 
                                        ProviderName="System.Data.Odbc" 
                                        
                                        SelectCommand="">
                                    </asp:SqlDataSource>
		</form>
		                            <asp:SqlDataSource ID="SqlDataSource" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:IASConnectionString %>" 
                                        SelectCommand="SELECT * FROM [Declaration]"></asp:SqlDataSource>
		</P></BLOCKQUOTE>
		<P class="maintext">&nbsp;</P>
		</TD></TR>
		<TR vAlign="middle" align="left">
			<TD vAlign="top" noWrap align="center" colSpan="2" height="27"><IMG height="33" alt="Панель быстрых переходов..." src="../images/bottom.gif" 
								useMap="#Map" border="0"><MAP name="Map">
                                 <AREA title="На главную..." shape="RECT" alt="На главную..." coords="25,0,100,33" href="../index.aspx">
                                 <AREA title="Поиск сотрудников" shape="RECT" alt="Поиск сотрудников" coords="150,0,200,33"	href="../Search/search.aspx">
                                 <AREA title="Штатно-должностная книга" shape="RECT" alt="Штатно-должностная книга" coords="250,0,325,33"	href="../Structure/orgstr.aspx">
                                 <AREA title="Вакансии" shape="RECT" alt="Вакансии" coords="325,0,425,33" href="../Vakans/vakansy.aspx">
                                 <AREA title="Некомплект" shape="RECT" alt="Некомплект" coords="475,0,550,33" href="../Nekompl/nekompl.aspx">
                                 <AREA title="Качественные показатели" shape="RECT" alt="Качественные показатели" coords="575,0,650,33"	href="../Kachestv/kachestv.aspx">
                                 <AREA title="Дисциплинарная практика" shape="RECT" alt="Дисциплинарная практика" coords="700,0,775,33"	href="../Discipline/discipline.aspx">
                                 </MAP></TD>
		</TR>
		</TBODY></TABLE>
    </div>
    </form>
    </form>
    </form>
    </form>
    </form>
    </form>
    </form>
    </form>
</body>
</html>
