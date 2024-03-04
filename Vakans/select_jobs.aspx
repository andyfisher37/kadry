<%@ Page language="c#" Codebehind="select_jobs.aspx.cs" AutoEventWireup="True" Inherits="kadry.Vakans.anketa" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - параметры для подбора 
			вакансии...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/Styles.css" rel="stylesheet">
	    <style type="text/css">
            .style1
            {
                font: 10pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #000000;
                direction: ltr;
                letter-spacing: normal;
                height: 17px;
                width: 282px;
            }
            .style2
            {
                height: 4px;
                width: 282px;
            }
            .style3
            {
                height: 11px;
                width: 282px;
            }
            .style4
            {
                height: 31px;
                width: 282px;
            }
            .style5
            {
                height: 12px;
                width: 282px;
            }
            .style6
            {
                height: 6px;
                width: 282px;
            }
            .style7
            {
                height: 8px;
                width: 282px;
            }
            .style8
            {
                height: 9px;
                width: 282px;
            }
            .style9
            {
                width: 282px;
            }
            .style10
            {
                height: 15px;
                width: 282px;
            }
        </style>
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#ff66ff" aLink="#66ffff" link="#3333ff" bgColor="#ffffff"
		leftMargin="0" background="/images/background.gif" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout"
		MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 676px; HEIGHT: 604px" height="604" cellSpacing="0" cellPadding="0"
				width="676" align="left" border="0" HSPACE="0" VSPACE="0">
				<TR>
					<TD style="HEIGHT: 90px" align="center" height="90" vAlign="top"><IMG alt="" src="/images/head_small.gif" width="750" useMap="#Map2" border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP></TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 28px" align="center" height="28" vAlign="top">ПОДБОР ВАКАНСИИ</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" style="HEIGHT: 330px">
						<P>
							<TABLE class="maintext" id="Table1" style="WIDTH: 584px; HEIGHT: 265px" cellSpacing="1"
								cellPadding="1" width="584" bgColor="#D1D1D1" border="0">
								<TR>
									<TD class="style1" align="right">Имеющееся специальное звание:</TD>
									<TD style="HEIGHT: 17px">
										<asp:DropDownList id="TypeObrazList0" runat="server" Width="240px" 
                                            Font-Bold="True" ForeColor="Maroon"
											Font-Names="Tahoma" Font-Size="9pt">
											<asp:ListItem Value="0" Selected="True">Не имеет значения</asp:ListItem>
											<asp:ListItem Value="10">Высшее</asp:ListItem>
											<asp:ListItem Value="20">Среднее специальное</asp:ListItem>
											<asp:ListItem Value="30">Среднее</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="style1" align="right"><FONT color="#000000">Уровень имеющегося образования:</FONT></TD>
									<TD style="HEIGHT: 17px">
										<asp:DropDownList id="TypeObrazList" runat="server" Width="240px" Font-Bold="True" ForeColor="Maroon"
											Font-Names="Tahoma" Font-Size="9pt">
											<asp:ListItem Value="0" Selected="True">Не имеет значения</asp:ListItem>
											<asp:ListItem Value="10">Высшее</asp:ListItem>
											<asp:ListItem Value="20">Среднее специальное</asp:ListItem>
											<asp:ListItem Value="30">Среднее</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD align="right" class="style2">Профиль образования (специальность):</TD>
									<TD style="HEIGHT: 4px">
										<asp:DropDownList id="ProfObrazList" runat="server" Width="240px" Font-Bold="True" ForeColor="Maroon"
											Font-Names="Tahoma" Font-Size="9pt">
											<asp:ListItem Value="0" Selected="True">Не имеет значения</asp:ListItem>
											<asp:ListItem Value="Юридическое">Юридическое</asp:ListItem>
											<asp:ListItem Value="Экономическое">Экономическое</asp:ListItem>
											<asp:ListItem Value="Техническое">Техническое</asp:ListItem>
											<asp:ListItem Value="Медицинское">Медицинское</asp:ListItem>
											<asp:ListItem Value="Педагогическое">Педагогическое</asp:ListItem>
											<asp:ListItem Value="Военное">Военное</asp:ListItem>
											<asp:ListItem Value="Пожарное">Пожарное</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD align="right" class="style3"><FONT color="#000000">Возраст:</FONT></TD>
									<TD style="HEIGHT: 11px">
										<asp:TextBox id="AgeBox" runat="server" Width="88px" Font-Bold="True" ForeColor="Maroon" Font-Names="Tahoma"
											Font-Size="9pt"></asp:TextBox>&nbsp;полных лет</TD>
								</TR>
								<TR>
									<TD align="right" class="style4"><FONT color="#000000">Пол:</FONT></TD>
									<TD style="HEIGHT: 31px">
										<asp:DropDownList id="SexList" runat="server" Width="88px" Font-Bold="True" ForeColor="Maroon" Font-Names="Tahoma"
											Font-Size="9pt">
											<asp:ListItem Value="0" Selected="True">Мужской</asp:ListItem>
											<asp:ListItem Value="1">Женский</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD align="right" class="style5">Рост:</TD>
									<TD style="HEIGHT: 12px">
										<asp:TextBox id="SizeBox" runat="server" Width="88px" Font-Bold="True" ForeColor="Maroon" Font-Names="Tahoma"
											Font-Size="9pt"></asp:TextBox>&nbsp;см.</TD>
								</TR>
								<TR>
									<TD align="right" class="style5">Стаж в ОВД:</TD>
									<TD style="HEIGHT: 12px">
										<asp:TextBox id="SizeBox0" runat="server" Width="88px" Font-Bold="True" 
                                            ForeColor="Maroon" Font-Names="Tahoma"
											Font-Size="9pt"></asp:TextBox>&nbsp;полных лет</TD>
								</TR>
								<TR>
									<TD align="right" class="style5">Желаемый оклад (по должности) от:</TD>
									<TD style="HEIGHT: 12px">
										<asp:TextBox id="OkladBox" runat="server" Width="42px" Font-Bold="True" 
                                            ForeColor="Maroon" Font-Names="Tahoma"
											Font-Size="9pt">10</asp:TextBox>&nbsp;до
										<asp:TextBox id="OkladBox0" runat="server" Width="42px" Font-Bold="True" 
                                            ForeColor="Maroon" Font-Names="Tahoma"
											Font-Size="9pt">12</asp:TextBox>&nbsp;тар.разр.</TD>
								</TR>
								<TR>
									<TD align="right" class="style6">Наличие службы в ВС:</TD>
									<TD style="HEIGHT: 6px">
										<asp:DropDownList id="SluzbaList" runat="server" Width="88px" Font-Bold="True" ForeColor="Maroon"
											Font-Names="Tahoma" Font-Size="9pt">
											<asp:ListItem Value="Да">Да</asp:ListItem>
											<asp:ListItem Value="Нет" Selected="True">Нет</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD align="right" class="style7">Участие в боевых действиях:</TD>
									<TD style="HEIGHT: 8px">
										<asp:DropDownList id="BDList" runat="server" Width="88px" Font-Bold="True" ForeColor="Maroon" Font-Names="Tahoma"
											Font-Size="9pt">
											<asp:ListItem Value="Да">Да</asp:ListItem>
											<asp:ListItem Value="Нет" Selected="True">Нет</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD align="right" class="style8"><FONT color="#000000">Ограничения 
											по здоровью:</FONT></TD>
									<TD style="HEIGHT: 9px">
										<asp:DropDownList id="HealthList" runat="server" Width="240px" Font-Bold="True" ForeColor="Maroon"
											Font-Names="Tahoma" Font-Size="9pt">
											<asp:ListItem Value="0" Selected="True">Нет ограничений</asp:ListItem>
											<asp:ListItem Value="1">2,3,4 группы предназначения</asp:ListItem>
											<asp:ListItem Value="2">3 и 4 группа предназначения</asp:ListItem>
											<asp:ListItem Value="3">только 4 группа предназначения</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD align="right" class="style9">Опыт руководящей работы:</TD>
									<TD>
										<asp:DropDownList id="BossList" runat="server" Width="88px" Font-Bold="True" ForeColor="Maroon" Font-Names="Tahoma"
											Font-Size="9pt">
											<asp:ListItem Value="Да">Да</asp:ListItem>
											<asp:ListItem Value="Нет" Selected="True">Нет</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD align="right" class="style7">Наличие водительских прав:</TD>
									<TD style="HEIGHT: 8px">
										<asp:DropDownList id="VodilaList" runat="server" Width="88px" Font-Bold="True" ForeColor="Maroon"
											Font-Names="Tahoma" Font-Size="9pt">
											<asp:ListItem Value="Да">Да</asp:ListItem>
											<asp:ListItem Value="Нет" Selected="True">Нет</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD align="right" class="style10">Специальные навыки:</TD>
									<TD style="HEIGHT: 15px">
										<asp:CheckBox ID="CheckBox1" runat="server" CssClass="label2" 
                                            Text="уверенный пользователь ПК" />
                                    </TD>
								</TR>
								<TR>
									<TD align="right" class="style10">&nbsp;</TD>
									<TD style="HEIGHT: 15px">
										<asp:CheckBox ID="CheckBox2" runat="server" CssClass="label2" 
                                            Text="опыт оперативной работы" />
                                    </TD>
								</TR>
								<TR>
									<TD align="right" class="style10">&nbsp;</TD>
									<TD style="HEIGHT: 15px">
										<asp:CheckBox ID="CheckBox3" runat="server" CssClass="label2" 
                                            Text="аналитические способности" />
                                    </TD>
								</TR>
								<TR>
									<TD align="right" class="style10">Место службы:</TD>
									<TD style="HEIGHT: 15px">
										<asp:DropDownList id="PlaceList" runat="server" Width="240px" Font-Bold="True" ForeColor="Maroon"
											Font-Names="Tahoma" Font-Size="9pt">
											<asp:ListItem Value="0" Selected="True">Не имеет значения</asp:ListItem>
											<asp:ListItem Value="IN (1,2,3,4,5,10,28,29,30,31,32,54,312)">только по г.Иваново</asp:ListItem>
											<asp:ListItem Value="NOT IN (1,2,3,4,5,10,28,29,30,31,32,54,312)">кроме г.Иваново</asp:ListItem>
											<asp:ListItem Value="1">только аппарат УМВД</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD align="right" class="style10">Возможность переезда в другую местность:</TD>
									<TD style="HEIGHT: 15px">
										<asp:RadioButton ID="RadioButton1" runat="server" CssClass="label2" Text="Да" />
                                        <asp:RadioButton ID="RadioButton2" runat="server" Checked="True" 
                                            CssClass="label2" Text="Нет" />
                                    </TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<HR width="100%" SIZE="1">
									</TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<asp:ImageButton id="NextButton" runat="server" ImageUrl="/images/btn_next.gif" onclick="NextButton_Click"></asp:ImageButton></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"></TD>
								</TR>
								<TR>
									<TD align="left" colSpan="2">
										<asp:Label id="Result" runat="server"></asp:Label></TD>
								</TR>
							</TABLE>
						</P>
					</TD>
				</TR>
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
			</TABLE>
		</form>
	</body>
</HTML>
