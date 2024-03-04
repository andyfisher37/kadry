<%@ Page language="c#" Codebehind="index.aspx.cs" AutoEventWireup="True" Inherits="kadry.Index" codePage="65001" enableViewState="False"%>

<%@ Register TagPrefix="tcm" Namespace="OboutInc.TwoColorsMenu" Assembly="obout_TwoColorsMenu" %>

<%@ Register assembly="obout_Show_Net" namespace="OboutInc.Show" tagprefix="obshow" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>Информационная система обработки данных "Кадры" по Ивановской области</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
		<meta content="True" name="vs_showGrid"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link rel="shortcut icon" href="images/logo2.ico"/>
		<link href="Styles.css" rel="stylesheet"/>

	    <style type="text/css">
            .style1
            {
                text-decoration: underline;
            }
        </style>

	</head>
	<body oncontextmenu="nomenu();" text="#000000" bottomMargin="0" vLink="#cc0000" aLink="#6666ff"
		link="#ff9966" bgProperties="fixed" bgColor="#ffffff" leftMargin="0" background="images/background.gif"
		topMargin="0" onload="" rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
        <table cellSpacing="0" cellPadding="0" width="600">
        <tr>
         <td>
                        &nbsp;</td>
        
         <td colspan="3">
                        <img class="Header" 
                            alt="Информационная система обработки данных "Кадры"" src="/images/header.gif"
							align="middle" border="0">
         </td>
        
         <td>
         <table style="border: thin solid #000099; background-color:#999999; font-family: Arial, Helvetica, sans-serif; font-size: xx-small; color: #FFFFFF; vertical-align: top; text-align: center;" 
                 align="center">
           <tr>
             <td>
               <asp:LoginName  ID="LoginName2" runat="server" FormatString="Пользователь: {0}"/>
             </td>
           </tr>
           <tr>
             <td>
               <asp:LoginStatus ID="LoginStatus1" runat="server" BackColor="#CCCCCC" 
                   LoginImageUrl="/images/login.gif" LogoutImageUrl="/images/logout.gif" 
                   ToolTip="Выход" />
           </table>
         </td>
        
        </tr>
        <tr style="height:5">
        <td>&nbsp;</td>
        <td class="smalltext"></td>
        <td class="smalltext"></td>
        <td></td>
        <td align="center" class="smalltext"></td>
        </tr>
        <tr>
        <td>
            &nbsp;</td>
        <td>
   <tcm:TwoColorsMenu runat="server" id="menu" Vertical="true" Font="10px Verdana" ColorBackground="#D1D1D1" ColorFont="Black">
    <tcm:Item ID="item1" InnerHtml="УРЛС"/>
        <tcm:Item ParentID="item1" ID="item11" InnerHtml="Личный состав УРЛС УМВД России по Ивановской области" Url="/About/viewkadrypeople.aspx"/>
        <tcm:Item ParentID="item1" ID="item12" InnerHtml="История кадровой службы" Url="/About/hystory.htm"/>
        <tcm:Item ParentID="item1" ID="item13" InnerHtml="Нормативные документы (Положение, должностные инструкции)" Url="/About/URLS_NPA.zip"/>
    <tcm:Item ID="item2" InnerHtml="Структура ОВД"/>
        <tcm:Item ParentID="item2" ID="item21" InnerHtml="Структурная схема УМВД России по Ивановской области" Url="/Structure/structure.aspx"/>
        <tcm:Item ParentID="item2" ID="item22" InnerHtml="Структурная схема территориальных ОВД"/>
    <tcm:Item ID="item3" InnerHtml="Поисковая система" Url="/Search/search.aspx"/>
    <tcm:Item ID="item4" InnerHtml="Вакансии"/>
        <tcm:Item ParentID="item4" ID="item41" InnerHtml="Списки вакансий" Url="/Vakans/vakansy.aspx"/>
        <tcm:Item ParentID="item4" ID="item42" InnerHtml="Подбор вакансии" Url="/Vakans/search_vak.aspx"/>
        <tcm:Item ParentID="item4" ID="item43" InnerHtml="Toп 50 вакансий" Url="/Vakans/HotVak.aspx"/>
    <tcm:Item ID="item5" InnerHtml="Некомплект"/>
        <tcm:Item ParentID="item5" ID="item51" InnerHtml="Общие сведения о некомплекте" Url="/Nekompl/nekompl.aspx"/>
        <tcm:Item ParentID="item5" ID="item52" InnerHtml="Некомплект по территориальным ОВД"/>
        <tcm:Item ParentID="item5" ID="item53" InnerHtml="Некомплект по службам"/>
    <tcm:Item ID="item6" InnerHtml="Штатно-должностная книга" Url="/Structure/orgstr.aspx"/>
    <tcm:Item ID="item7" InnerHtml="Принято & уволено" Url="/InOut/inout.aspx"/>
    <tcm:Item ID="item8" InnerHtml="Дисциплина" Url="/Discipline/discipline.aspx"/>
    <tcm:Item ID="item9" InnerHtml="Статистика"/>
        <tcm:Item ParentID="item9" ID="item91" InnerHtml="Качественные показатели" Url="/Quality/Quality.aspx"/>
        <tcm:Item ParentID="item9" ID="item92" InnerHtml="Образование..." Url="/Quality/Education.aspx"/>
    <tcm:Item ID="item10" InnerHtml="Контроль"/>
        <tcm:Item ParentID="item10" ID="item101" InnerHtml="Контроль присвоения званий" Url="/Control/ZvanControl.aspx"/>
        <tcm:Item ParentID="item10" ID="item102" InnerHtml="Контроль документооборота" Url="Control/Documentum.aspx"/>
        <tcm:Item ParentID="item10" ID="item103" InnerHtml="Контроль служебных удостовереений" Url="/Control/CertControl.aspx" />
        <tcm:Item ParentID="item10" ID="item104" InnerHtml="Контроль назначений" Url="/Control/MovingControl.aspx"/>
        <tcm:Item ParentID="item10" ID="item105" InnerHtml="Контроль сокращенных сотрудников" Url="/Control/SokrControl.aspx"/>
        <tcm:Item ParentID="item10" ID="item106" InnerHtml="Контроль уведомлений об увольнении" Url="/Control/UvedomControl.aspx"/>
        <tcm:Item ParentID="item10" ID="item107" InnerHtml="Контроль квалификационных званий"/>
        <tcm:Item ParentID="item10" ID="item108" InnerHtml="Контроль первоначальной подготовки"/>
        <tcm:Item ParentID="item10" ID="item109" InnerHtml="Контроль личных дел" Url="/Control/PersFileControl.aspx"/>
    <tcm:Item ID="item011" InnerHtml="Почта (МСПД)" Url="/Mspd/mspd_main.aspx"/>
    <tcm:Item ID="item012" InnerHtml="Нормативная база" Url="/Normatives/normatives.aspx"/>
        <tcm:Item ParentID="item012" ID="item0121" InnerHtml="Список НПА"/>
        <tcm:Item ParentID="item012" ID="item0122" InnerHtml="Поиск..."/>
    <tcm:Item ID="item013" InnerHtml="Командировки" Url="/Hotpoint/hotpoint.aspx"/>
    <tcm:Item ID="item014" InnerHtml="Резерв кадров" Url="/Reserv/res_main.aspx"/>
    <tcm:Item ID="item15" InnerHtml="Бланки" Url="/Blanks/blanks.aspx"/>
    <tcm:Item ID="item020" InnerHtml="Обратная связь" Url="/Admin/admin.aspx"/>
    <tcm:Item ID="item021" InnerHtml="Помощь..." Url="/Guide/userguide.htm"/>

   </tcm:TwoColorsMenu>
                                        
							
														
					</td>
        <td align="center" rowspan="4" valign="top">
                                        <span class="style1">полезная информация и новости:</span><obshow:Show 
                                            ID="Show1" runat="server" 
                ScrollDirection="Top" ScrollingSpeed="70" SelectedPanel="0" ShowType="Show" 
                StartTimeDelay="4000" TimeBetweenPanels="7000" TransitionType="Scrolling" 
                Width="600px" Height="400px">
                                        <Panels>
                                            <obshow:Panel ID="Panel0" runat="server" PanelType="Url" 
                                                Url="/News/main_rule.htm">
                                            </obshow:Panel>
                                        <obshow:Panel ID="Panel1" PanelType="Url" Url="/News/news0001.htm">
                                        </obshow:Panel>
                                            <obshow:Panel ID="Panel2" runat="server" PanelType="Url" 
                                                Url="/News/news0002.htm">
                                            </obshow:Panel>
                                            <obshow:Panel ID="Panel3" runat="server" PanelType="Url" 
                                                Url="/News/news0003.htm">
                                            </obshow:Panel>
                                        </Panels>

<Changer Type="Arrow" ArrowType="Side1" Position="Bottom" VerticalAlign="Middle" HorizontalAlign="Center"></Changer>
                                        </obshow:Show>
            </td>
        <td></td>
        <td align="center" valign="top" rowspan="9">

							<asp:imagebutton id="ImageButton8" runat="server" 
                AlternateText="Сегодня родились..." Height="49px"
								Width="49px" ImageUrl="/images/born_today.gif" 
                ToolTip="Узнай у кого сегодня День Рождения!" onclick="ImageButton8_Click"></asp:imagebutton>
                                        <br />

                            <asp:imagebutton id="ImageButton1" runat="server" AlternateText="График отпусков..." 
								ImageUrl="/images/grafik2013_icon.gif" ToolTip="График отпусков на 2013 год" 
                                onclick="ImageButton1_Click" ></asp:imagebutton>
                            <br />
                            <asp:imagebutton id="ImageButtonPerDoc" runat="server" AlternateText="Перечень..." 
								ImageUrl="/images/per_doc.gif" 
                                ToolTip="Перечень документов, образующихся в деятельности органов внутренних дел Российской Федерации, с указанием сроков хранения (Приложение к приказу МВД России от 30.06.2012 № 655)" 
                                onclick="ImageButtonPerDoc_Click" Height="49px" 
                Width="49px">
                            </asp:imagebutton>
                        <FONT class="smalltext" face="Verdana" size="1">
                                                                    <A href="/Normatives/Store/UVD/pr_uvd_1804_12.pdf">
									<IMG style="WIDTH: 36px; HEIGHT: 36px" alt='Приказ УМВД России по Ивановской области №1804 л/с от 06.11.2012 г. "О награждении медалями За отличие в службе"'
										src="/images/otlich2012.gif" border="0"></A></FONT><br />
														
						    <asp:ImageButton ID="ImageButton28" runat="server" 
                                ImageUrl="/images/policemen.gif" onclick="ImageButton28_Click" 
                                
                                
                                ToolTip="Памятка сотрудникам органов внутренних дел, увольняемым в связи с оргштатными мероприятиями..." 
                                Height="89px" Width="29px" />

        </td>
        </tr>
        <tr style="height:5px">
        <td class="style18">&nbsp;</td>
        <td class="style18"></td>
        <td></td>
        </tr>
        <tr>
        <td class="style18">
											&nbsp;</td>
        <td class="style18">
											<asp:ImageButton id="ImageButton10" runat="server" 
                                                ToolTip="Официальный сайт МВД России" ImageUrl="/images/btn_mvd.gif" 
                                                onclick="ImageButton10_Click" AlternateText="МВД РФ"></asp:ImageButton></td>
        <td></td>
        </tr>
        <tr style="height:5px">
        <td class="style18">&nbsp;</td>
        <td class="style18"></td>
        <td></td>
        </tr>
        <tr style="height:5px">
        <td class="style18">&nbsp;</td>
        <td class="style18">
											<asp:ImageButton id="CZNButton" runat="server" 
                                                ToolTip="Сайт центра занятости населения" 
                                                ImageUrl="/images/btn_czn.gif" onclick="CZNButton_Click" 
                                                AlternateText="ТК"></asp:ImageButton></td>
        <td align="center" valign="top">
                                        <asp:ImageButton ID="dko_banner" runat="server" 
                                            ImageUrl="/images/dko_banner.gif" onclick="dko_banner_Click" 
                                            Height="16px" AlternateText="ДКО МВД РФ" />
                                        </td>
        <td></td>
        </tr>
        <tr>
        <td class="style18">
										&nbsp;</td>
        <td class="style18">
										&nbsp;</td>
        <td align="center">
                                        &nbsp;</td>
        <td>&nbsp;</td>
        </tr>
        <tr>
        <td class="style18">
										&nbsp;</td>
        <td class="style18">
										<asp:ImageButton id="ImageButton18" runat="server" 
                                                ImageUrl="/images/licvidation.gif" 
                                                ToolTip="Если возникают вопросы типа: А где нажать чтобы печатало? Вам сюда..." 
                                                onclick="ImageButton18_Click" AlternateText="Мануалы..."></asp:ImageButton></td>
        <td align="center">
                                        &nbsp;</td>
        <td></td>
        </tr>
        <tr>
        <td class="style18">
										&nbsp;</td>
        <td class="style18">
										&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        </tr>
        <tr>
        <td class="style18">
										&nbsp;</td>
        <td class="style18">
										<asp:ImageButton ID="ImageButton33" runat="server" ImageUrl="/images/ntica.gif" 
                                            onclick="ImageButton33_Click" 
                                            ToolTip="ПОМОГИ УРЛС УВЕЛИЧИТЬ СТАТИСТИКУ ПОСЕЩЕНИЙ АИПС НТИ-ЦА" 
                                            Width="203px" />
									</td>
        <td>
                            &nbsp;</td>
        <td>&nbsp;</td>
        </tr>
        <tr>
        <td class="style18">
										&nbsp;</td>
        <td class="style18">
										&nbsp;</td>
        <td>
                            &nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        </tr>
        <tr>
        <td class="style18">
										&nbsp;</td>
        <td class="style18">
											<asp:ImageButton id="ReglamentButton" runat="server" ImageUrl="/images/btn_ZOP.gif" 
                                                onclick="ReglamentButton_Click" 
                                                ToolTip="ФЗ №3-ФЗ от 07.02.2011 с 01.03.2011 г."></asp:ImageButton>
									</td>
        <td>
                            &nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        </tr>
        <tr>
        <td class="style18">
										&nbsp;</td>
        <td class="style18">
										&nbsp;</td>
        <td>
                            &nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        </tr>
        <tr>
        <td class="style18">
										&nbsp;</td>
        <td class="style18">
                                        <asp:ImageButton ID="ImageButton30" runat="server" 
                                            ImageUrl="/images/concept.gif" onclick="ImageButton30_Click" Height="61px" 
                                            Width="203px" />
									</td>
        <td>
                            &nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        </tr>
        </table>

			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" border="0">
				<TR>
					<TD style="HEIGHT: 131px" align="left" colspan="2">
                        &nbsp;</TD>
					
					<TD>
                        &nbsp;<TD>
                        <br />
                    </TD>
				</TR>
				<TR>
					<TD align="center" class="style11" valign="top" rowspan="2">
							<br>
                                        
							
														
					</TD>
					<TD class="style12">
						<TABLE id="Table4" style="WIDTH: 752px; HEIGHT: 214px" cellSpacing="0" cellPadding="0"
							width="752" border="0">
							<TBODY class="label3">
								<TR>
									<TD style="HEIGHT: 12px" align="center" colspan="3" valign="middle" 
                                        class="maintext">
                                        &nbsp;</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 12px" align="center" colspan="3" valign="middle" 
                                        class="Attantion">
                                        
                                       
                                        
                                        
                                        <br />
                                        <br />
                                    </TD>
								</TR>
								<TR>
									<TD style="WIDTH: 255px; HEIGHT: 12px" align="center">
										&nbsp;</TD>
									<TD align="center" class="style5"><STRONG><U>
                                        <FONT face="Verdana" color="#993333" size="2">
                                        <asp:ImageButton id="ImageButton14" runat="server" ImageUrl="/images/btn_addservice.gif" ToolTip="Дополнительные сервисы..."
											AlternateText="Дополнительные сервисы..." Width="130px" Height="50px" onclick="ImageButton14_Click"></asp:ImageButton></TD>
									<TD align="center" class="style2">
										

									</TD>
								</TR>
								<TR>
									<TD align="center" class="style3"></TD>
									<TD align="center" class="style6"></TD>
									<TD align="center" class="style16"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 255px; HEIGHT: 75px" align="center">
											&nbsp;</TD>
									<TD align="center" class="style7">
											&nbsp;</TD>
									<TD align="center" class="style17">
										<P>
										    &nbsp;</P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 255px" align="center">
											&nbsp;</TD>
									<TD align="center" class="style6">
										&nbsp;</TD>
									<TD align="center" class="style16">
										&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 255px" align="center">
											&nbsp;</TD>
									<TD align="center" class="style6">
										&nbsp;</TD>
									<TD align="center" class="style16">
                                        &nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 255px" align="center">
											<asp:ImageButton id="ReservButton" runat="server" 
                                                ToolTip="Резерв кадров УВД" 
                                                ImageUrl="/images/reserv_btn.gif" AlternateText="Резерв" 
                                                onclick="ReservButton_Click" Visible="False"></asp:ImageButton></TD>
									<TD align="center" class="style6">
										<P>
											&nbsp;</P>
									</TD>
									<TD align="center" class="style16">
										<P>
										<asp:ImageButton id="ZoneControlButton" runat="server" 
                                                ImageUrl="/images/btn_zone.gif" 
                                                ToolTip="Система контроля для зональных сотрудников УРЛС УВД" 
                                                onclick="ImageButton23_Click" AlternateText="Зональный контроль..." 
                                                Visible="False"></asp:ImageButton></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 255px" align="center">
											&nbsp;</TD>
									<TD align="center" class="style6">
										&nbsp;</TD>
									<TD align="center" class="style16">
										&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 255px" align="center">
											&nbsp;</TD>
									<TD align="center" class="style6">
                                        &nbsp;</TD>
									<TD align="center" class="style16">
										&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 255px" align="center">
											&nbsp;</TD>
									<TD align="center" class="style6">
										&nbsp;</TD>
									<TD align="center" class="style16">
										&nbsp;</TD>
								</TR>
							</TBODY>
						</TABLE>
					</TD>
					<TD align="center" class="style13" rowspan="2" valign="top">
                        <br />
							<asp:ImageButton ID="ImageButton29" runat="server" 
                                ImageUrl="/images/btn_schema.gif" onclick="ImageButton29_Click" 
                                ToolTip="Организационная схема УМВД РФ по Ивановской области" />
							
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <asp:ImageButton ID="ImageButton32" runat="server" AlternateText="Chrome" 
                            ImageUrl="\images\chrome.gif" onclick="ImageButton32_Click" />
                        <br />
                        <br />
                        <asp:ImageButton ID="ImageButton20" runat="server" Height="40px" 
                            ImageUrl="\images\firefox.gif" Width="52px" AlternateText="FireFox" 
                            onclick="ImageButton20_Click" />
                        <br />
														
                        <br />
                        <br />
                        <FONT class="smalltext" face="Verdana" size="1">
                        <CENTER><br>
								Приказы УВД &quot;За отличие в службе...&quot;&nbsp;&nbsp;
                                                                    <br />
                                        &nbsp;<br>
                                <A href="/Normatives/Store/UVD/pr_uvd_2348_11.htm">
									<IMG style="WIDTH: 36px; HEIGHT: 36px" height="64" alt='Приказ УМВД России по Ивановской области №2348 л/с от 03.11.2011 г. "О награждении медалями За отличие в службе"'
										src="/images/otlich2011.gif" width="64" border="0"></A><br />
										&nbsp;<br>
								<A href="/Normatives/Store/UVD/pr_uvd_1909_10.htm">
									<IMG style="WIDTH: 36px; HEIGHT: 36px" height="64" alt='Приказ УВД по Ивановской области №1909 л/с от 02.11.2010 г. "О награждении медалями За отличие в службе"'
										src="/images/otlich2010.gif" width="64" border="0"></A><br />
										&nbsp;<br>
								<A href="/Normatives/Store/UVD/pr_uvd_1848_09.htm">
									<IMG style="WIDTH: 44px; HEIGHT: 44px" height="64" alt='Приказ УВД по Ивановской области №1848 л/с от 02.11.2009 г. "О награждении медалями За отличие в службе"'
										src="/images/otlich2009.gif" width="64" border="0"></A><br />
&nbsp;<br>
								<A href="/Normatives/Store/UVD/pr_uvd_1440_08.htm">
									<IMG style="WIDTH: 36px; HEIGHT: 36px" height="64" alt='Приказ УВД по Ивановской области №1440 л/с от 06.11.2008 г. "О награждении медалями За отличие в службе"'
										src="/images/otlich2008.gif" width="64" border="0"></A><br />
&nbsp;<br>
								<A href="/Normatives/Store/UVD/pr_uvd_1730_07.htm">
									<IMG style="WIDTH: 36px; HEIGHT: 36px" height="64" alt='Приказ УВД по Ивановской области №1730 л/с от 31.10.2007 г. "О награждении медалями За отличие в службе"'
										src="/images/otlich2007.gif" width="64" border="0"></A><br />
&nbsp;<br>
								<A href="/Normatives/Store/UVD/pr_uvd_1280_06.htm">
                                <IMG style="WIDTH: 44px; HEIGHT: 44px" height="64" alt='Приказ УВД по Ивановской области №1280 л/с от 07.11.2006 г. "О награждении медалями За отличие в службе"'
										src="/images/otlich2006.gif" width="64" border="0"></A><br />
&nbsp;<br>
								<A href="/Normatives/Store/UVD/pr_uvd_1305_05.htm">
                                <IMG style="WIDTH: 44px; HEIGHT: 44px" height="64" alt='Приказ УВД по Ивановской области №1305 от 03.11.2005 г. "О награждении медалями За отличие в службе"'
										src="/images/otlich2005.gif" width="64" border="0"></A><br />
&nbsp;<br>
								<A href="/Normatives/Store/UVD/pr_uvd_1455_04.htm">
                                <IMG style="WIDTH: 44px; HEIGHT: 44px" height="64" alt='Приказ УВД по Ивановской области №1455 от 09.11.2004 г. "О награждении медалями За отличие в службе"'
										src="/images/otlich2004.gif" width="64" border="0"></A><br />
&nbsp;<br>
								<A href="/Normatives/Store/UVD/pr_uvd_1498_03.htm">
                                <IMG style="WIDTH: 44px; HEIGHT: 44px" height="64" alt='Приказ УВД по Ивановской области №1498 от 05.11.2003 г. "О награждении медалями За отличие в службе"'
										src="/images/otlich2003.gif" width="64" border="0"></A>
						</FONT></CENTER>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        Награды МВД России:<br />
                        <asp:ImageButton ID="AllNagradButton" runat="server" 
                            AlternateText="Все награды МВД России" ImageUrl="\images\all_nagrad.gif" 
                            onclick="AllNagradButton_Click" 
                            ToolTip="Информация о всех нагардах МВД России..." />
                        <br />
                        Литература:<br />
                        <asp:ImageButton ID="ImageButton21" runat="server" 
                            AlternateText="&quot;Ведомственные медали силовых структур&quot;" 
                            ImageUrl="\images\kniga_medali.gif" onclick="ImageButton21_Click" 
                            
                            
                            ToolTip="&quot;Ведомственные медали силовых структур&quot; И.Кузьмичев, А.Трифон" />
                        <br />
                        <br />
                        <asp:ImageButton ID="ImageButton25" runat="server" AlternateText="История ОВД" 
                            ImageUrl="/images/hystory_book.gif" onclick="ImageButton25_Click" 
                            ToolTip="Учебник. История ОВД" Height="102px" Width="70px" />
                        <br />
                        <br />
                        <asp:ImageButton ID="ImageButton22" runat="server" 
                            AlternateText="&quot;Органы внутренних дел и госбезопасности (история реорганизаций и назначений)&quot;" 
                            ImageUrl="\images\lubyanka.gif" onclick="ImageButton22_Click" 
                            ToolTip="&quot;Органы внутренних дел и госбезопасности (история реорганизаций и назначений)&quot;" />
                            <br />
                            <br />
                        <asp:ImageButton ID="ImageButton34" runat="server" 
                            AlternateText="Эффективное делопроизводство на ПК" 
                            ImageUrl="\images\delo.gif" onclick="ImageButton34_Click" 
                            ToolTip="Эффективное делопроизводство на ПК" Height="86px" Width="73px" />
                            <br />
                            <br />
                            <br />
                    </TD>
				</TR>
				<TR>
					<TD align="center" class="style14">
						<P align="center"><FONT face="Verdana" color="#003300" size="1"><STRONG><U>Последние 
                            обновления (в хронологическом порядке):</U></STRONG></FONT></P>
						<BLOCKQUOTE style="width: 691px">
						    <P class="smallBottom" align="left">19.05.2011 - Добавлен учет выписки и вручения уведомлений об увольнении...</P>
							<P class="smallBottom" align="left">27.10.2009 - Добавлено отображение информации о 
                                первоначальной подготовке в служебной карточке...</P>
                            <P class="smallBottom" align="left">10.10.2008 - Доступна OFF-Line версия 
                                официального сайта МВД России - <a href="\mvd.ru\mvd.ru\default.htm">здесь</a>
							</P>
							<P class="smallBottom" align="left">07.12.2007 -&nbsp;Запущен проект &quot;Штатно-должностная 
                                книга&quot; - <a href="\Structure\orgstr.aspx">подробнее...</a>
							</P>
							<P class="smallBottom" align="left">17.05.2007 -&nbsp;Добавлена возможность поиска 
                                приказа по личному составу в разделе <a href="\Documentum\documentum.aspx">
                                &quot;Документооборот&quot;...</a>
							</P>
							<P class="smallBottom" align="left">12.03.2007 -&nbsp;Обновлен раздел <font color="red">
									<U>&quot;качественные показатели&quot;</U></font> - размещена полная статистика за 
                                каждый месяц с 2001 года по настоящее время...
							</P>
							<P class="smallBottom" align="left">16.11.2006 -&nbsp;Уважаемые &quot;зональники&quot; 
                                контролируйте поступление личных дел&nbsp;сотрудников номенклатуры УВД в ОПСиИО УРЛС 
                                УВД - [<A href="\Control\pfile_control.aspx">здесь</A>]</P>
							<P class="smallBottom" align="left">28.06.2006 -&nbsp;Создана страница для отслеживания 
                                изменений в службе УУМ и последующих изменений в Правоохранительном портале МВД 
                                России</P>
							<P class="smallBottom" align="left">31.05.2006 -&nbsp;Добавлена возможность получения 
                                информации о принятых и уволенных в УВД по Ивановской области</P>
							<P class="smallBottom" align="left">25.05.2006 -&nbsp;Добавлена новая &quot;версия&quot; служ. 
                                карт.&nbsp;- при просмотре служ.карт. сотрудника в конце каждой страницы есть кнопка <STRONG><FONT color="#ff0033">
                                &quot;версия для печати&quot;</FONT></STRONG></P>
							<P class="smallBottom" align="left">03.04.2006 -&nbsp;Для <U>сотрудников УРЛС УВД</U> 
								появилась возможность отправки служебных документов по МСПД МВД России
							</P>
							<P class="smallBottom" align="left">20.02.2006 -&nbsp;Добавлен сервис по контролю за 
                                служебными удостоверениями<A href="/Control/cer_control.aspx">[здесь]</A>&nbsp;
							</P>
							<P class="smallBottom" align="left">17.02.2006 -&nbsp;Добавлен раздел по документообороту 
                                в УРЛС УВД <A href="/Documentum/documentum.aspx">[здесь]</A>&nbsp;
							</P>
							<P class="smallBottom" align="left">15.02.2006 -&nbsp;Статистика и выборки по образованию <A href="/Kachestv/obrazov.aspx">
                                [здесь]</A>&nbsp;
							</P>
							<P class="smallBottom" align="left">20.12.2005 -&nbsp;Добавлен сервис &quot;Командировки в СКР 
                                и другие горячие точки&quot;&nbsp;
							</P>
							<P class="smallBottom" align="left">27.09.2005 -&nbsp;Краткую статистику сетевой 
                                активности пользователей можно посмотреть <A href="net_stat.aspx">здесь</A>&nbsp;
							</P>
							<P class="smallBottom" align="left">19.09.2005 - Смотри фотогаллерею Управления 
                                кадров...&nbsp;
							</P>
							<P class="smallBottom" align="left">09.09.2005 - Функционирует раздел &quot;Бланки 
                                служебных документов&quot;
							</P>
							<P class="smallBottom" align="left">07.09.2005 -&nbsp;Добавлен сайт ОМОНа УВД Ивановской 
                                области (www.omon-ivanovo.narod.ru)
							</P>
							<P class="smallBottom" align="left">05.09.2005 -&nbsp;В разделе вакансии добавлена 
                                сводная таблица вакансий с разбивкой по службам
							</P>
							<P class="smallBottom" align="left">25.05.2005 -&nbsp;Для зональных сотрудников кадровых 
                                аппаратов доступна <A href="/Control/zvan_control.aspx">страничка</A> контроля 
                                присвоения званий
							</P>
							<P class="smallBottom" align="left">16.04.2005 -&nbsp;Добавлен раздел для сотрудников 
                                кадрового аппарата (&quot;<FONT color="#ff9966"><A href="Statist\OperSvodka.aspx">Статистика 
                                по оперативной обстановке</A></FONT>&quot;)
							</P>
							<P class="smallBottom" align="left">14.04.2005 -&nbsp;Добавлена краткая статистика по 
                                поощрениям и взысканиям см.раздел &quot;<A href="/Discipline/discipline.aspx">Дисциплина</A>&quot;
							</P>
							<P class="smallBottom" align="left">05.04.2005 -&nbsp;Добавлена возможность поиска по 
                                датам рождения
							</P>
							<P class="smallBottom" align="left">03.03.2005 -&nbsp;Появился раздел <A href="/Normatives/metody.aspx">
									&quot;Методические материалы&quot; </A>
							</P>
							<P class="smallBottom" align="left">17.12.2004 -&nbsp;Добавлен раздел&nbsp; <A href="About/about.aspx">
									&quot;УРЛС УВД&quot;</A>
							</P>
							<P class="smallBottom" align="left">30.11.2004 -&nbsp;Добавлен раздел&nbsp; <A href="Kachestv/kachestv.aspx">
									Качественные показатели&quot;</A>
							</P>
							<P class="smallBottom" align="left">20.11.2004 -&nbsp;Переработана &quot;Нормативная база&quot; , 
                                добавлена возможность поиска
							</P>
							<P class="smallBottom" align="left">01.11.2004 -&nbsp; Добавлена возможность 
                                автоматического формирования &quot;Справки-Объективки&quot; - смотри <A href="Search/search.aspx">
									[ПОИСК]</A>
							</P>
							<P class="smallBottom" align="left">29.10.2004 - Добавлена информация по наградам 
                                МВД России ( <A href="/Normatives/nagrady_1.html">часть 1</A>, <A href="/Normatives/nagrady_2.html">
									часть 2</A> )
							</P>
						</BLOCKQUOTE>
					</TD>
					
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 77px; HEIGHT: 18px">&nbsp;</TD>
					
					<TD class="style15">
                        <br />
                        <br />
                        </TD>
				</TR>
				<TR>
					<TD style="WIDTH: 77px; HEIGHT: 18px"></TD>
					<TD align="right">&nbsp;<TD style="WIDTH: 77px"></TD>
					<TD vAlign="middle" noWrap height="27"><%--&nbsp; <IMG height="33" alt="Панель быстрого перехода..." src="images/bottom.gif" width="750"
							useMap="#Map" border="0"><MAP name="Map"><AREA title="Сделано в УРЛС УВД по Ивановской области" shape="RECT" alt="Сделано в УРЛС УВД по Ивановской области"
								coords="346,7,743,25" href="/About/about.aspx"><area title="На главную..." shape="RECT" alt="На главную..." coords="18,5,39,27" href="index.aspx"><area title="Об УРЛС УВД" shape="RECT" alt="Об УРЛС УВД" coords="47,5,68,27"
								href="/About/about.aspx"><area title="Структура органов внутренних дел" shape="RECT" alt="Структура органов внутренних дел"
								coords="75,5,97,27" href="/Structure/structure.aspx"><area title="Поиск сотрудников" shape="RECT" alt="Поиск сотрудников" coords="104,5,125,27"
								href="/Search/search.aspx"><area title="Вакансии" shape="RECT" alt="Вакансии" coords="132,5,154,27" href="/Vakans/vakansy.aspx"><area title="Некомплект" shape="RECT" alt="Некомплект" coords="161,5,183,26" href="/Nekompl/nekompl.aspx"><area title="Качественные показатели" shape="RECT" alt="Качественные показатели" coords="190,5,212,26"
								href="/Kachestv/kachestv.aspx"><area title="Нормативные документы" shape="RECT" alt="Нормативные документы" coords="218,5,240,27"
								href="/Normatives/normatives.aspx"><area title="Бланки служебных документов" shape="RECT" alt="Бланки служебных документов"
								coords="247,5,269,26" href="/Blanks/blanks.aspx"><area title="Дисциплинарная практика" shape="RECT" alt="Дисциплинарная практика" coords="275,5,297,26"
								href="/Discipline/discipline.aspx"><area title="Письмо администратору..." shape="RECT" alt="Письмо администратору..." coords="305,5,327,27"
								href="/Toadmin/toadmin.aspx"></MAP>--%></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
