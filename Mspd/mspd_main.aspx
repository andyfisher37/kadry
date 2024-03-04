<%@ Page language="c#" Codebehind="mspd_main.aspx.cs" AutoEventWireup="True" Inherits="kadry.Mspd.mspd_main" codePage="65001"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Информационная система обработки данных "Кадры" - Рассылка документов по МСПД МВД 
			России...</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/Styles.css" rel="stylesheet">
		<script>
	      function OpenWindowGIF( iWidth, iHeight )
		  {
			var	iRealWidth = iWidth	? iWidth : 600
			var	iRealHeight	= iHeight ?	iHeight	: screen.height	- 300

			var	iLeft =	Math.round(	(screen.width-iRealWidth)/2	)
			var	iTop =	Math.round(	(screen.height-iRealHeight)/2 )	- 35

			var	sWindowOptions = 'status=no,menubar=no,toolbar=no'
			sWindowOptions += ',resizable=no,scrollbars=no,location=no'
			sWindowOptions += ',width='	 + iRealWidth
			sWindowOptions += ',height=' + iRealHeight
			sWindowOptions += ',left='	 + iLeft
			sWindowOptions += ',top='	 + iTop

			var	oWindow	= window.open('','',sWindowOptions)
			oWindow.focus()
			oWindow.document.open()
			oWindow.document.writeln('<html>')
			oWindow.document.writeln('<head>')
			oWindow.document.writeln('</head>')
			oWindow.document.writeln('<body	marginwidth="0"	marginheight="0" topmargin="0" leftmargin="0">')
			oWindow.document.writeln('<img src="mspd_mem.gif">')
			oWindow.document.writeln('</html>')
			oWindow.document.close()
			return oWindow
          }
		</script>
	    <style type="text/css">
            .style1
            {
                font: bold 8pt Verdana, Arial, Helvetica, sans-serif;
                text-transform: none;
                color: #993333;
                height: 50px;
            }
            #File1
            {
                width: 733px;
            }
            .style2
            {
                font-size: x-small;
                color: #FF0000;
                text-decoration: underline;
            }
        </style>
	</HEAD>
	<body text="#000000" bottomMargin="0" vLink="#990000" aLink="#6666ff" link="#0000ff" bgColor="#ffffff"
		onload="OpenWindowGIF(500,230);" leftMargin="0" background="/images/background.gif" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 744px; HEIGHT: 592px" height="592" cellSpacing="0" cellPadding="0"
				width="744" align="left" border="0">
				<TR>
					<TD style="HEIGHT: 102px" vAlign="top" align="center" height="102"><IMG alt="Информационная система обработки данных "Кадры"" src="/images/header_small.gif" useMap="#Map2"
							border="0"><MAP name="Map2"><AREA title="УРЛС УВД..." shape="RECT" alt="УРЛС УВД..." coords="244,51,499,82" href="../About/about.aspx"></MAP>
					</TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 29px" align="center" height="29">
                        Рассылка 
                        документов по МСПД МВД России</TD>
				</TR>
				<TR>
					<TD class="Header" style="HEIGHT: 293px" vAlign="top" align="center" height="293">
						<P><asp:label class="label2" id="Info" runat="server" Width="719px"></asp:label></P>
						<P>
							<TABLE id="Table2" style="WIDTH: 738px; HEIGHT: 309px" cellSpacing="0" cellPadding="0"
								width="738" bgColor="#D1D1D1" border="0">
								<TR>
									<TD align="center"><FONT color="#Параметры 
                                        направляемого документа:</FONT></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3">
										<hr>
									</TD>
								</TR>
								<TR>
									<TD class="label2" align="left">
                                        Отправитель (укажите свою фамилию, имя, отчество (и) или должность):</TD>
								</TR>
								<TR>
									<TD><asp:textbox id="Author" runat="server" Width="730px"></asp:textbox><FONT color="#ff6600" size="2"></FONT></TD>
								</TR>
								<TR>
									<TD class="label2" align="left">
                                        Направляемый документ (нажатием кнопки &quot;обзор&quot; выберите направляемый файл):</TD>
								</TR>
								<TR>
									<TD><INPUT id="File1" type="file" size="100" name="File1"
											runat="server"></TD>
								</TR>
								<TR>
									<TD class="label2" align="left">Тема 
                                        документа (возможно указание № исх. документа или краткое содержание, или другие пояснения):</TD>
								</TR>
								<TR>
									<TD><asp:textbox id="Subject" runat="server" Width="730px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center" class="style1" valign="middle"><span class="style2">Если Вы не нашли 
                                        нужный Вам адрес в списке адресов ниже, укажите адрес вручную здесь:</span><br />
                                        <asp:TextBox ID="manualURL" runat="server" Font-Bold="True" Font-Size="12pt" 
                                            Width="275px" ToolTip="Ручной ввод адресата"></asp:TextBox>
                                    </TD>
								</TR>
								<TR>
									<TD align="center" class="label2">
										<HR>
									</TD>
								</TR>
								<TR>
									<TD align="center" class="label2"><FONT color="#000099" size="1">Адресаты (проставьте 
                                        галочки напротив тех адресатов куда вы направляете свой документ...)&nbsp;:</FONT></TD>
								</TR>
								<TR>
									<TD align="center"><FONT color="#006600" size="2"><STRONG>Адреса подразделений 
                                        и служб ОВД Ивановской области: </STRONG></FONT>
									</TD>
								</TR>
								<TR>
									<TD>
										<asp:checkboxlist class=smalltext id=adrList1 runat="server" Width="736px" DataSource="<%# emailDataSet1 %>" DataMember="MSPDBook" DataTextField="MSPDNAME" DataValueField="EMAIL" CssClass="supersmall" RepeatColumns="3">
										</asp:checkboxlist></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 10px">
										<HR>
									</TD>
								</TR>
								<TR>
									<TD align="center"><FONT color="#006600" size="2"><STRONG>Адреса МВД России и 
                                        прочие:</STRONG></FONT></TD>
								</TR>
								<TR>
									<TD>
										<asp:checkboxlist class=smalltext id=adrList2 runat="server" Width="736px" DataSource="<%# emailDataSet2 %>" DataMember="MSPDBook" DataTextField="MSPDNAME" DataValueField="EMAIL" CssClass="supersmall" RepeatColumns="3">
										</asp:checkboxlist></TD>
								</TR>
								<TR>
									<TD align="center">
										<hr>
									</TD>
								</TR>
								<TR>
									<TD align="center">
                                        <asp:imagebutton id="BtnList" runat="server" 
                                            ImageUrl="/images/btn_sendemail.gif" onclick="BtnList_Click"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD></TD>
								</TR>
							</TABLE>
							<br>
						</P>
						<P>&nbsp;</P>
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
