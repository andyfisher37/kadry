<%@ Page language="c#" Codebehind="DetailPage_s.aspx.cs" AutoEventWireup="True" Inherits="UK.DetailPage_s" codePage="65001" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - служубная карточка сотрудника</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 100; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="1"
				cellPadding="1" width="720" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 5px" vAlign="top" align="right" colSpan="2"><FONT size="1">Служебная 
							карточка (Форма №2)</FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 5px" vAlign="middle" align="center" colSpan="2" rowSpan="1"><asp:label class="Header" id="TitleText" runat="server" CssClass="Header" Width="440px"></asp:label></TD>
				</TR>
				<TR>
					<TD class="maintext" style="WIDTH: 725px; HEIGHT: 202px" vAlign="top" align="left">
						<TABLE id="Table3" style="WIDTH: 688px; HEIGHT: 96px" cellSpacing="1" cellPadding="1" width="688"
							align="center" border="0">
							<TR>
								<TD class="maintext" style="WIDTH: 128px" align="right">Дата рождения:</TD>
								<TD class="maintext" style="WIDTH: 290px" colSpan="4">&nbsp;
									<asp:label id="L_Born" runat="server" CssClass="label2" Width="534px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 128px" align="right">Место рождения:</TD>
								<TD class="maintext" style="WIDTH: 290px" colSpan="4">&nbsp;
									<asp:label id="L_BornPlace" runat="server" CssClass="label2" Width="534px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 128px" align="right">Национальность:</TD>
								<TD class="maintext" style="WIDTH: 290px" colSpan="4">&nbsp;
									<asp:label id="L_Nation" runat="server" CssClass="label2" Width="534px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 128px" align="right">Личный номер:</TD>
								<TD class="maintext" style="WIDTH: 55px" colSpan="4">&nbsp;
									<asp:label id="L_nom" runat="server" CssClass="label2" Width="534px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="maintext" style="WIDTH: 128px" vAlign="top" align="right">Образование:</TD>
								<TD class="maintext" style="WIDTH: 55px" vAlign="top" align="left" colSpan="4">&nbsp;&nbsp;
									<asp:label id="L_learn" runat="server" CssClass="label2" Width="527px"></asp:label></TD>
							</TR>
						</TABLE>
						<STRONG>Служба в вооруженных силах:</STRONG>
						<TABLE class="maintext" id="Table2" style="WIDTH: 686px; HEIGHT: 94px" cellSpacing="1"
							cellPadding="1" width="686" border="0">
							<TR>
								<TD style="WIDTH: 340px; HEIGHT: 20px"><asp:label id="L_Vinfo1" runat="server" CssClass="label2" Width="334px" Height="4px"></asp:label></TD>
								<TD style="HEIGHT: 20px"><asp:label id="L_Vinfo5" runat="server" CssClass="label2" Width="334px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 340px"><asp:label id="L_Vinfo2" runat="server" CssClass="label2" Width="334px"></asp:label></TD>
								<TD><asp:label id="L_Vinfo6" runat="server" CssClass="label2" Width="334px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 340px"><asp:label id="L_Vinfo3" runat="server" CssClass="label2" Width="334px"></asp:label></TD>
								<TD><asp:label id="L_Vinfo7" runat="server" CssClass="label2" Width="334px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 340px"><asp:label id="L_Vinfo4" runat="server" CssClass="label2" Width="334px"></asp:label></TD>
								<TD><asp:label id="L_Vinfo8" runat="server" CssClass="label2" Width="334px"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="maintext" style="HEIGHT: 202px" vAlign="top" align="center"><br>
						<asp:Button id="PhotoBtn" runat="server" Text="Фото" onclick="PhotoBtn_Click"></asp:Button>
						<asp:label id="L_nfile" runat="server" CssClass="label2" Width="60px"></asp:label><br>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" colSpan="2">
						<HR align="center" SIZE="1">
					</TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" align="left" colSpan="2"><STRONG>Служба (работа) в 
							гражданских учреждениях:
							<asp:label id="WorkLabel" runat="server" CssClass="label2" Width="211px"></asp:label></STRONG></TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" align="left" colSpan="2">
						<P><asp:datagrid id=grGrid runat="server" Width="740px" Height="56px" BorderWidth="1px" BorderColor="Black" BackColor="White" Font-Names="Verdana" DataMember="Table" DataSource="<%# tmpDataSet %>" AutoGenerateColumns="False" DataKeyField="DATE_FROM">
								<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Black"></ItemStyle>
								<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Center" ForeColor="#0000CC"
									VerticalAlign="Middle" BackColor="#FFFFCC"></HeaderStyle>
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
							</asp:datagrid></P>
					</TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" align="left" colSpan="2"><STRONG>Служба в органах 
							внутренних дел: </STRONG>
					</TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" align="left" colSpan="2"><asp:datagrid id=zGrid runat="server" CssClass="maintext" Width="736px" Height="72px" BorderWidth="1px" BorderColor="Black" BackColor="White" DataMember="Table" DataSource="<%# tmpDataSet %>" AutoGenerateColumns="False">
							<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Black"></ItemStyle>
							<HeaderStyle Font-Size="XX-Small" Font-Bold="True" HorizontalAlign="Center" ForeColor="#0000CC"
								BackColor="#FFFFCC"></HeaderStyle>
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
					<TD class="maintext" vAlign="top" align="left" colSpan="2"><strong>Послужной список: в 
							ОВД с:
							<asp:label id="L_OVD" runat="server" CssClass="label2" Width="56px"></asp:label>г. 
							, в службе с:
							<asp:label id="L_vSlu" runat="server" CssClass="label2" Width="56px"></asp:label>г.&nbsp;, 
							в текущей должности с:
							<asp:label id="L_vDolz" runat="server" CssClass="label2" Width="56px"></asp:label>г.&nbsp;</strong>
					</TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" colSpan="2"><asp:datagrid id=pGrid runat="server" Width="736px" Height="92px" BorderWidth="1px" BorderColor="Black" BackColor="White" Font-Names="Verdana" DataMember="Table" DataSource="<%# tmpDataSet %>" AutoGenerateColumns="False">
							<ItemStyle Font-Size="XX-Small" Font-Names="Verdana"></ItemStyle>
							<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
								ForeColor="#330099" VerticalAlign="Middle" BackColor="#FFFFCC"></HeaderStyle>
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
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" colSpan="2">
						<P><STRONG>Командировки:
								<asp:label id="L_komand" runat="server" CssClass="label2" Width="256px"></asp:label></P>
						</STRONG></TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" colSpan="2">
						<P><asp:datagrid id=kGrid runat="server" Width="736px" Height="60px" BorderWidth="1px" BorderColor="Black" BackColor="White" DataMember="Table" DataSource="<%# tmpDataSet %>" AutoGenerateColumns="False">
								<ItemStyle Font-Size="XX-Small" Font-Names="Verdana"></ItemStyle>
								<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
									ForeColor="#000066" VerticalAlign="Middle" BackColor="#FFFFCC"></HeaderStyle>
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
							</asp:datagrid></P>
					</TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" colSpan="2"><STRONG>Взыскания:
							<asp:label id="L_nak" runat="server" CssClass="label2" Width="280px"></asp:label></STRONG></TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" colSpan="2">
						<P><asp:datagrid id=nakGrid runat="server" Width="736px" Height="62px" BorderWidth="1px" BorderColor="Black" BackColor="White" Font-Names="Verdana" DataMember="Table" DataSource="<%# tmpDataSet %>" AutoGenerateColumns="False">
								<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Black"></ItemStyle>
								<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
									ForeColor="#000066" BackColor="#FFFFCC"></HeaderStyle>
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
					<TD class="maintext" vAlign="top" colSpan="2"><STRONG>Поощрения:
							<asp:label id="L_poo" runat="server" CssClass="label2" Width="272px"></asp:label></STRONG></TD>
				</TR>
				<TR>
					<TD class="maintext" vAlign="top" colSpan="2">
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR vAlign="middle" align="left">
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
