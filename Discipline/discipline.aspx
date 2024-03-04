<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Page language="c#" Codebehind="discipline.aspx.cs" AutoEventWireup="false" Inherits="kadry.Discipline.discipline" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - дисциплина...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgProperties="fixed"
		bgColor="#ffffff" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="760" align="left" border="0" HSPACE="0" VSPACE="0">
				<TBODY>
					<TR>
						<TD style="WIDTH: 848px; HEIGHT: 66px" vAlign="top" align="center" colSpan="19"><IMG alt="" src="/images/header_small.gif" width="750" useMap="#Map2" border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP></TD>
					</TR>
					<TR vAlign="top" align="center">
						<TD vAlign="top" align="center" colSpan="1" height="16" rowSpan="1"><SPAN class="Header">Дисциплина</SPAN></TD>
					</TR>
					<TR vAlign="top" align="left">
						<TD style="HEIGHT: 100px" vAlign="top" noWrap align="center" colSpan="1" height="100"
							rowSpan="1">
							<BLOCKQUOTE>
								<P>
									<TABLE class="maintext" id="Table1" style="WIDTH: 737px; HEIGHT: 384px" cellSpacing="1"
										cellPadding="1" bgColor="#D1D1D1" border="0">
										<TR>
											<TD style="WIDTH: 173px; HEIGHT: 8px" align="right" colSpan="1" rowSpan="1">Подразделение:</TD>
											<TD style="WIDTH: 250px; HEIGHT: 8px" align="left" colSpan="2">
                                                <asp:dropdownlist id=podrList tabIndex=1 runat="server" Font-Bold="True" 
                                                    DataMember="Table" DataValueField="KEY_OF_POD" DataTextField="PODRAZDEL" 
                                                    DataSource="<%# podrDataSet %>" CssClass="maintext" ForeColor="#C00000" 
                                                    Font-Names="Verdana" Width="432px" Font-Size="8pt" AutoPostBack="True" 
                                                    onselectedindexchanged="podrList_SelectedIndexChanged">
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 173px; HEIGHT: 5px" align="right">
                                                <asp:Label ID="podchLabel" runat="server" Text="подчиненное:" Visible="False"></asp:Label>
                                            </TD>
											<TD style="WIDTH: 250px; HEIGHT: 5px" align="left" colSpan="2">
                                        <asp:dropdownlist id="podchList" tabIndex="7" runat="server" Font-Size="7pt" 
                                            Width="432px" ForeColor="#C00000" Font-Names="Verdana" Visible="False" 
                                            DataSourceID="podchDataSource" DataTextField="NAIMENOVAN" 
                                            DataValueField="KEY_OF_NAI"></asp:dropdownlist>
                                                <asp:SqlDataSource ID="podchDataSource" runat="server" 
                                                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                                                    SelectCommand="SELECT [NAIMENOVAN], [KEY_OF_NAI] FROM [NAIMEN]">
                                                </asp:SqlDataSource>
                                            </TD>
										</TR>
										<TR>
											<TD style="WIDTH: 173px; HEIGHT: 5px" align="right"><A href="..//sluzhelp.htm"><IMG id="IMG1" alt="Информация об объединении некоторых служб при выполнении запросов..."
														src="..//images/btn_help.gif" border="0"></A>Служба:</TD>
											<TD style="WIDTH: 250px; HEIGHT: 5px" align="left" colSpan="2"><asp:dropdownlist id=sluzList tabIndex=2 runat="server" Font-Bold="True" DataMember="Table" DataValueField="KEY_OF_SLU" DataTextField="NAM_OF_SLU" DataSource="<%# sluzDataSet %>" CssClass="maintext" ForeColor="#C00000" Font-Names="Verdana" Width="432px" Font-Size="8pt">
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 173px; HEIGHT: 14px" align="right">Категория должностей:</TD>
											<TD style="WIDTH: 250px; HEIGHT: 14px" align="left" colSpan="2">
												<asp:dropdownlist id="dolzList" tabIndex="9" runat="server" Width="432px" Font-Names="Verdana" ForeColor="#C00000"
													Font-Bold="True" Font-Size="8pt">
													<asp:ListItem Value="0" Selected="True">Не имеет значения</asp:ListItem>
													<asp:ListItem Value="-1">Все аттестованные</asp:ListItem>
													<asp:ListItem Value="1">Руководство (от нач.отделения и выше)</asp:ListItem>
													<asp:ListItem Value="2">Старший и средний нач.состав</asp:ListItem>
													<asp:ListItem Value="3">Рядовой состав</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 173px; HEIGHT: 15px" align="right">Вид поощрения:</TD>
											<TD style="WIDTH: 250px; HEIGHT: 15px" align="left" colSpan="2"><asp:dropdownlist id=pooList tabIndex=3 runat="server" Font-Bold="True" DataMember="Table" DataValueField="P2" DataTextField="P1" DataSource="<%# slvDataSet %>" CssClass="maintext" ForeColor="#C00000" Font-Names="Verdana" Width="432px" Font-Size="8pt">
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 173px; HEIGHT: 6px" align="right">Вид взыскания:</TD>
											<TD style="WIDTH: 250px; HEIGHT: 6px" align="left" colSpan="2"><asp:dropdownlist id=nakList tabIndex=4 runat="server" Font-Bold="True" DataMember="Table" DataValueField="P2" DataTextField="P1" DataSource="<%# slvDataSet %>" CssClass="maintext" ForeColor="#C00000" Font-Names="Verdana" Width="432px" Font-Size="8pt">
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 173px; HEIGHT: 8px" align="right">Период с:
											</TD>
											<TD style="WIDTH: 341px; HEIGHT: 8px" vAlign="middle" align="left" colSpan="2">
												<ew:MaskedTextBox id="Date1" runat="server" Width="90px" Font-Names="Verdana" ForeColor="#0000C0"
													Font-Bold="True" ToolTip="Дата начала периода" Text="01.01.2004" Mask="99.99.9999" RequiredErrorText="Необходима дата..."
													RequiredErrorMessage="Необходима дата..." ErrorText="Неправильная дата" ErrorMessage="Неправильная дата"
													tabIndex="5"></ew:MaskedTextBox>&nbsp;года&nbsp;по&nbsp;
												<ew:MaskedTextBox id="Date2" runat="server" Width="90px" Font-Names="Verdana" ForeColor="#0000C0"
													Font-Bold="True" ToolTip="Дата конца периода" Text="01.01.2004" Mask="99.99.9999" RequiredErrorText="Необходима дата..."
													RequiredErrorMessage="Необходима дата..." ErrorText="Неправильная дата" ErrorMessage="Неправильная дата"
													tabIndex="6"></ew:MaskedTextBox>&nbsp;года</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 173px; HEIGHT: 8px" align="right">
												<asp:CheckBox id="OVDCheck" runat="server" Text="В ОВД с:"></asp:CheckBox></TD>
											<TD style="WIDTH: 341px; HEIGHT: 8px" vAlign="middle" align="left" colSpan="2">
												<ew:MaskedTextBox id="OVDDate" tabIndex="5" runat="server" Width="90px" 
                                                    Font-Names="Verdana" ForeColor="#0000C0"
													Font-Bold="True" ErrorMessage="Неправильная дата" ErrorText="Неправильная дата" RequiredErrorMessage="Необходима дата..."
													RequiredErrorText="Необходима дата..." Mask="99.99.9999" Text="01.01.2004" ToolTip="Дата начала службы в ОВД"></ew:MaskedTextBox></TD>
										</TR>
										<TR>
											<TD class="smalltext" style="HEIGHT: 25px" vAlign="middle" align="center" colSpan="3">
												<HR align="center" width="100%" color="#000000" SIZE="2">
												<STRONG><FONT color="#ff3333">дополнительные параметры:</FONT></STRONG>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 173px" vAlign="middle" align="right">
												Искать где:</TD>
											<TD style="WIDTH: 206px" vAlign="middle" align="left" colSpan="2">
												<p><asp:radiobutton id="RadioBtn1" runat="server" ToolTip="Отображать только работающих по настоящее время"
														Text="среди действующих сотрудников" GroupName="TypeSearch" Checked="True" Width="285px" tabIndex="7"
														CssClass="label2"></asp:radiobutton>
                                                    <asp:radiobutton id="RadioBtn2" 
                                                        runat="server" ToolTip="Отображать только уволенных" Text="среди уволенных"
														GroupName="TypeSearch" tabIndex="8" CssClass="label2"></asp:radiobutton></p>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 173px" vAlign="middle" align="right" rowspan="2">Отображать что:</TD>
											<TD style="WIDTH: 331px" vAlign="middle" align="left"><asp:checkbox id="Check1" tabIndex="9" runat="server" Width="224px" ToolTip="Не показывать снятые взыскания..."
													Text="только неснятые взыскания" CssClass="label2"></asp:checkbox></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 331px" vAlign="middle" align="left"><asp:checkbox id="Check2" 
                                                    tabIndex="9" runat="server" Width="224px" ToolTip="Сотрудников награжденных несколько раз показывать 1 раз"
													Text="только уникальные записи" CssClass="label2" Visible="False"></asp:checkbox></TD>
											<TD>&nbsp;</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 173px; HEIGHT: 6px" vAlign="middle" align="right"></TD>
											<TD style="WIDTH: 331px; HEIGHT: 6px" vAlign="middle" align="left"></TD>
											<TD style="HEIGHT: 6px"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 173px; HEIGHT: 25px" vAlign="middle" align="right">
												<asp:ImageButton id="pooBtn" runat="server" ToolTip="Вывести список поощрений" ImageUrl="/images/btn_poo.gif"
													tabIndex="10" onclick="pooBtn_Click1"></asp:ImageButton></TD>
											<TD style="WIDTH: 331px; HEIGHT: 25px" vAlign="middle" align="center">
												<asp:ImageButton id="ImageButton1" runat="server" ToolTip="Список поощренных сотрудников, имеющих неснятые дисциплинарные взыскания"
													ImageUrl="/images/btn_badpoo.gif"></asp:ImageButton></TD>
											<TD style="WIDTH: 323px; HEIGHT: 25px" vAlign="middle" align="left"></TD>
											<TD style="HEIGHT: 25px"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 173px; HEIGHT: 26px" vAlign="middle" align="right">
												<asp:ImageButton id="nakBtn" runat="server" ToolTip="Вывести список наказанных" ImageUrl="/images/btn_nak.gif"
													tabIndex="11" onclick="nakBtn_Click1"></asp:ImageButton></TD>
											<TD style="WIDTH: 331px; HEIGHT: 26px" vAlign="middle" align="center">
												<asp:ImageButton id="nak_sp_btn" runat="server" ToolTip="Проверить на наличие взысканий сотрудников по списку..."
													ImageUrl="/images/btn_nak_sp.gif" tabIndex="13"></asp:ImageButton></TD>
											<TD style="HEIGHT: 26px"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 173px" vAlign="middle" align="right">
												<asp:ImageButton id="statBtn" runat="server" ImageUrl="/images/btn_stat.gif" 
                                                    tabIndex="12" AlternateText="статистика по дисциплине" onclick="statBtn_Click1"></asp:ImageButton></TD>
											<TD style="WIDTH: 331px" vAlign="middle" align="center"></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 126px" vAlign="middle" align="left" colSpan="3"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 126px" vAlign="middle" align="left" colSpan="3"><asp:label id="FindLabel" runat="server" CssClass="label" Width="552px"></asp:label></TD>
										</TR>
									</TABLE>
		</form>
		</P></BLOCKQUOTE>
		<P class="maintext"><IMG alt="" src="/images/Sign.gif"><FONT size="1"><STRONG>Внимание:</STRONG>
				для получения точного результата необходимо корректно&nbsp;задать параметры 
				запроса</FONT>...</P>
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
        </form>
        </form>
        </FORM>
	</body>
</HTML>
