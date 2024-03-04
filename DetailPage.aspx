<%@ Page language="c#" Codebehind="DetailPage.aspx.cs" AutoEventWireup="True" Inherits="kadry.DetailPage" codePage="65001" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title>Информационная система обработки данных "Кадры" - служебная карточка сотрудника</title>
		<asp:Literal ID="_literal" runat="server"></asp:Literal>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="Styles.css" rel="stylesheet">
	    <style type="text/css">
            .style1
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 6px;
            }
            .style2
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 15px;
            }
            .style3
            {
                font-size: x-small;
            }
            .style4
            {
                font-size: xx-small;
            }
            .style5
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 7px;
            }
            .style6
            {
                font: normal normal normal x-small normal Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
            }
        </style>
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" 
        link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
		<TABLE id="Table1" 
                style="Z-INDEX: 100; LEFT: 0px; POSITION: absolute; TOP: 0px; height: 871px;" cellSpacing="1"
				cellPadding="1" width="720" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 5px" vAlign="top" align="center" colSpan="2"><IMG style="WIDTH: 742px; HEIGHT: 18px" height="18" alt="" src="images/sc-header.gif"
							width="742"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 5px" vAlign="middle" align="center" colSpan="2" rowSpan="1">
                        <asp:label class="Header" id="TitleText" runat="server" CssClass="Header" 
                            Width="440px"></asp:label></TD>
				</TR>
				<TR>
					<TD class="label" style="WIDTH: 500px; HEIGHT: 162px" vAlign="bottom" 
                        align="left">
						<TABLE id="Table3" style="WIDTH: 548px; HEIGHT: 163px" cellSpacing="1" cellPadding="1"
							width="548" align="center" border="0">
							<TR>
								<TD class="maintext" style="WIDTH: 154px" align="right">Дата рождения:</TD>
								<TD class="maintext" style="WIDTH: 290px">
									<asp:label id="L_Born" runat="server" CssClass="label2" Width="128px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 154px" align="right">Место рождения:</TD>
								<TD class="maintext" style="WIDTH: 290px">
									<asp:label id="L_BornPlace" runat="server" CssClass="label2" Width="368px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 154px" align="right">Национальность:</TD>
								<TD class="maintext" style="WIDTH: 290px">
									<asp:label id="L_Nation" runat="server" CssClass="label2" Width="192px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 154px" align="right">Личный номер:</TD>
								<TD class="maintext" style="WIDTH: 55px">
									<asp:label id="L_nom" runat="server" CssClass="label2" Width="126px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 154px" vAlign="top" align="right">Образование:</TD>
								<TD class="maintext" style="WIDTH: 55px" vAlign="top" align="left">
									<asp:label id="L_learn" runat="server" CssClass="label2" Width="369px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 154px" vAlign="top" align="right">Испытательный 
									срок&nbsp;<FONT size="1">(при поступлении на службу)</FONT>:</TD>
								<TD class="maintext" style="WIDTH: 55px" vAlign="middle" align="left">
									<asp:label id="L_isp" runat="server" Width="120px" CssClass="label2"></asp:label></TD>
							</TR>
							</TABLE>
					    <asp:Label ID="FTrLabel" runat="server" 
                            Text="Сведения о прохождении первоначальной подготовки:"></asp:Label>
&nbsp;&nbsp;
                        <asp:ImageButton ID="FirstTrButton" runat="server" 
                            AlternateText="первоначалка..." ImageUrl="images/green_arr.gif" 
                            onclick="FirstTrButton_Click" 
                            ToolTip="Нажмите, чтобы узнать сведения о первоначальной подготовке..." />
					</TD>
					<TD class="maintext" style="HEIGHT: 162px" vAlign="top" align="center"><asp:image id="Image" runat="server" Width="110px" Height="150px" BorderWidth="1px" AlternateText="Фото"
							ImageUrl="~/PhotoBank/"></asp:image><br>
						<asp:label id="L_nfile" runat="server" CssClass="label2" Width="185px"></asp:label><br>
						<asp:imagebutton id="CertButton" runat="server" Width="25" Height="10" ImageUrl="/images/cert.gif"
							ToolTip="Нажми на ксиву и узнаешь номер служебного удостоверения" onclick="CertButton_Click" 
                            Visible="False"></asp:imagebutton>
                        <%--<asp:ImageButton ID="Att_Button" runat="server" 
                            AlternateText="Внеочередная аттестация" 
                            ToolTip="Информация о прохождении внеочередной аттестации" 
                            ImageUrl="~/images/"
                            Visible="false" />--%>
                    </TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" align="left" colSpan="2">
						<STRONG class="style3">Служба в вооруженных силах:</STRONG>
						<asp:label id="ArmyLabel" runat="server" Width="160px" CssClass="label2" Height="12px"></asp:label>
						<asp:datagrid id=vGrid runat="server" Width="740px" BorderWidth="1px" Height="56px" AutoGenerateColumns="False" DataSource="<%# tmpDataSet %>" DataMember="Table" Font-Names="Verdana" BackColor="White" BorderColor="Black">
							<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Black"></ItemStyle>
							<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Center" ForeColor="#0000CC"
								VerticalAlign="Middle" BackColor="#D1D1D1"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="ARMY_BEGIN" SortExpression="ARMY_BEGIN" HeaderText="с..." DataFormatString="{0:d}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ARMY_STOP" SortExpression="ARMY_STOP" HeaderText="...по" DataFormatString="{0:d}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Примечание"></asp:TemplateColumn>
							</Columns>
						</asp:datagrid>
					    <br />
                        <asp:Label ID="v_stag" runat="server" CssClass="label2"></asp:Label>
                        <br />
					</TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" align="left" colSpan="2"><STRONG class="style3">Служба (работа) в 
							гражданских учреждениях:
							<asp:label id="WorkLabel" runat="server" CssClass="label2" Width="211px"></asp:label></STRONG></TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" align="left" colSpan="2">
						<asp:datagrid id=grGrid runat="server" Width="740px" Height="56px" BorderWidth="1px" BorderColor="Black" BackColor="White" Font-Names="Verdana" DataMember="Table" DataSource="<%# tmpDataSet %>" AutoGenerateColumns="False" DataKeyField="DATE_FROM">
							<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Black"></ItemStyle>
							<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Center" ForeColor="#0000CC"
								VerticalAlign="Middle" BackColor="#D1D1D1"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="DATE_FROM" SortExpression="DATE_FROM" HeaderText="c..." DataFormatString="{0:d}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATE_TO" SortExpression="DATE_TO" HeaderText="...по" DataFormatString="{0:d}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Должность, организация">
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FIRM_DOLZN") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FIRM_DOLZN") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid>
					</TD>
				</TR>
				<TR>
					<TD class="style2" vAlign="top" align="left" colSpan="2"><span class="style4">
                        *Основание: </span>
                        <asp:Label ID="WorkBookLabel" runat="server" CssClass="label"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD class="style1" vAlign="top" align="left" colSpan="2">
					</TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" align="center" colSpan="2"><STRONG>
                        <span class="style2"><b>Служба в органах 
							внутренних дел, других силовых ведомствах:</b></span> </STRONG>
					</TD>
				</TR>
				<TR>
					<TD class="style5" vAlign="top" align="center" colSpan="2">
					<hr />
					</TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" align="left" colSpan="2"><b class="style3">Список имеющихся 
                        специальных званий:</b></TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" align="left" colSpan="2"><asp:datagrid id=zGrid runat="server" CssClass="maintext" Width="736px" Height="72px" BorderWidth="1px" BorderColor="Black" BackColor="White" DataMember="Table" DataSource="<%# tmpDataSet %>" AutoGenerateColumns="False">
							<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Black"></ItemStyle>
							<HeaderStyle Font-Size="XX-Small" Font-Bold="True" HorizontalAlign="Center" ForeColor="#0000CC"
								BackColor="#D1D1D1"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="VOIN_ZVAN" SortExpression="VOIN_ZVAN" HeaderText="Звание">
									<HeaderStyle Width="30%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="P1" SortExpression="P1" HeaderText="Приказ ОВД"></asp:BoundColumn>
								<asp:BoundColumn DataField="NOM_PRIK" SortExpression="NOM_PRIK" HeaderText="№">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATA_PRIK" SortExpression="DATA_PRIK" HeaderText="Дата приказа" DataFormatString="{0:d}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATA_PRSV" SortExpression="DATA_PRSV" HeaderText="Присвоено" DataFormatString="{0:d}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" align="left" colSpan="2"><strong>
                        <span class="style3">Послужной список: в 
							ОВД с:</span>
							<asp:label id="L_OVD" runat="server" CssClass="label2" Width="56px"></asp:label>
                        <span class="style3">г. 
							, в службе с:</span>
							<asp:label id="L_vSlu" runat="server" CssClass="label2" Width="56px"></asp:label>
                        <span class="style3">г.&nbsp;, 
							в текущей должности с:</span>
							<asp:label id="L_vDolz" runat="server" CssClass="label2" Width="56px"></asp:label>
                        <span class="style3">г.</span>&nbsp;</strong>
					</TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" colSpan="2"><asp:datagrid id=pGrid runat="server" Width="736px" Height="92px" BorderWidth="1px" BorderColor="Black" BackColor="White" Font-Names="Verdana" DataMember="Table" DataSource="<%# tmpDataSet %>" AutoGenerateColumns="False">
							<ItemStyle Font-Size="XX-Small" Font-Names="Verdana"></ItemStyle>
							<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
								ForeColor="#330099" VerticalAlign="Middle" BackColor="#D1D1D1"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="DATA_OT" SortExpression="DATA_OT" HeaderText="с.." DataFormatString="{0:d}"></asp:BoundColumn>
								<asp:BoundColumn DataField="VOIN_ZVAN" SortExpression="VOIN_ZVAN" HeaderText="Звание"></asp:BoundColumn>
								<asp:BoundColumn DataField="NAM_OF_DOL" SortExpression="NAM_OF_DOL" HeaderText="Должность"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Подразделение"></asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Статус">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="P1" SortExpression="P1" HeaderText="Приказ">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NOM_PRIK" SortExpression="NOM_PRIK" HeaderText="№">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATA_PRIK" SortExpression="DATA_PRIK" HeaderText="от" DataFormatString="{0:d}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							    <asp:TemplateColumn HeaderText="Оклад">
                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                        Font-Size="XX-Small" Font-Strikeout="False" Font-Underline="False" 
                                        HorizontalAlign="Center" />
                                </asp:TemplateColumn>
							</Columns>
						</asp:datagrid>
                        <asp:Label ID="ovd_stag" runat="server" CssClass="label2"></asp:Label>
                        <br />
                        <%--<asp:Label ID="ovd_stag" runat="server" CssClass="label2"></asp:Label>
                        <asp:HyperLink ID="HyperLink1" runat="server">+++</asp:HyperLink>--%>
                    </TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" colSpan="2">
						<STRONG class="style3">Командировки:
							<asp:label id="L_komand" runat="server" CssClass="label2" Width="256px"></asp:label>
						</STRONG>
					    <asp:ImageButton ID="TableLButton" runat="server" 
                            ImageUrl="images/btn_lgot_table.gif" onclick="TableLButton_Click" 
                            ToolTip="Распечатать таблицу льготных периодов для личного дела" 
                            Visible="False" />
					</TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" colSpan="2">
						<asp:datagrid id=kGrid runat="server" Width="736px" Height="60px" 
                            BorderWidth="1px" BorderColor="Black" BackColor="White" DataMember="Table" 
                            DataSource="<%# tmpDataSet %>" AutoGenerateColumns="False">
							<ItemStyle Font-Size="XX-Small" Font-Names="Verdana"></ItemStyle>
							<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
								ForeColor="#000066" VerticalAlign="Middle" BackColor="#D1D1D1"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="DATE_FROM" SortExpression="DATE_FROM" HeaderText="с..." DataFormatString="{0:d}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATE_TO" SortExpression="DATE_TO" HeaderText="...по" DataFormatString="{0:d}">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="KOEF_VISL" SortExpression="KOEF_VISL" HeaderText="Коэфф.выслуги">
									<HeaderStyle Width="3%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="LEGEND" SortExpression="LEGEND" HeaderText="Легенда">
									<HeaderStyle Width="50%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="P1" SortExpression="P1" HeaderText="Приказ"></asp:BoundColumn>
								<asp:BoundColumn DataField="PRIK_DATE" SortExpression="PRIK_DATE" HeaderText="от" DataFormatString="{0:d}"></asp:BoundColumn>
								<asp:BoundColumn DataField="NUM_PRIK" SortExpression="NUM_PRIK" HeaderText="№"></asp:BoundColumn>
							</Columns>
						</asp:datagrid>
					</TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" colSpan="2"><STRONG class="style3">Взыскания:
							<asp:label id="L_nak" runat="server" CssClass="label2" Width="280px"></asp:label></STRONG></TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" colSpan="2">
						<P><asp:datagrid id=nakGrid runat="server" Width="736px" Height="62px" BorderWidth="1px" BorderColor="Black" BackColor="White" Font-Names="Verdana" DataMember="Table" DataSource="<%# tmpDataSet %>" AutoGenerateColumns="False">
								<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Black"></ItemStyle>
								<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
									ForeColor="#000066" BackColor="#D1D1D1"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="DAT_NALOZ" SortExpression="DAT_NALOZ" HeaderText="Наложено" DataFormatString="{0:d}">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Приказ">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="N_PRIK_NAL" SortExpression="N_PRIK_NAL" HeaderText="№">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Взыскание">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="SODERZANIE" SortExpression="SODERZANIE" HeaderText="За что...">
										<HeaderStyle Width="40%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DAT_SNIAT" SortExpression="DAT_SNIAT" HeaderText="Снято" DataFormatString="{0:d}">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Кто снял">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="N_PRIK_SN" SortExpression="N_PRIK_SN" HeaderText="№ Пр.">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></P>
					</TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" colSpan="2"><STRONG class="style3">Поощрения:
							<asp:label id="L_poo" runat="server" CssClass="label2" Width="272px"></asp:label></STRONG></TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" colSpan="2">
						<P><asp:datagrid id=pooGrid runat="server" Width="736px" Height="46px" BorderWidth="1px" BorderColor="Black" BackColor="White" Font-Names="Verdana" DataMember="Table" DataSource="<%# tmpDataSet %>" AutoGenerateColumns="False">
								<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Black"></ItemStyle>
								<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
									ForeColor="#000066" BackColor="#D1D1D1"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Вид поощрения">
										<HeaderStyle Width="35%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Причина">
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PRICHINA") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PRICHINA") %>'>
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Приказ">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="NOM_PRIK" SortExpression="NOM_PRIK" HeaderText="№">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DATA_POO" SortExpression="DATA_POO" HeaderText="Дата" DataFormatString="{0:d}">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></P>
					</TD>
				</TR>
				<TR>
					<TD class="style6" vAlign="top" colSpan="2">
						<strong>Отпуска по графику: </strong>
						<asp:Label ID="Vacations" runat="server" CssClass="label2"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" colSpan="2">
						<asp:Label ID="ProcNadb" runat="server" CssClass="label2"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" colSpan="2">
						<FONT class="maintext" style="FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: black; FONT-STYLE: normal; FONT-FAMILY: Verdana; TEXT-ALIGN: center"
							face="Times New Roman" size="3"></FONT>
					    <asp:ImageButton ID="PrnVerButton" runat="server" 
                            AlternateText="версия для печати" ImageUrl="\images\btn_prnver.gif" 
                            onclick="PrnVerButton_Click" Visible="False" />
					</TD>
				</TR>
				</TABLE>
		</form>
	</body>
</HTML>
