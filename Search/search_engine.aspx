<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search_engine.aspx.cs" Inherits="UK.Search.search_engine" %>

<%@ Register assembly="obout_Interface" namespace="Obout.Interface" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Информационно-аналитическая служба УРЛС УВД - поиск сотрудников...</title>
    <LINK href="/Styles.css" rel="stylesheet">
</head>
<body background="../images/background.gif">
    <form id="form1" runat="server">
    <div>
        <table style="width: auto; position: absolute; z-index: auto; height: auto; top: 0px; left: 0px;">
            <tr>
                <td align="center">
                <IMG alt="Информационно-аналитическая служба УРЛС УВД" src="/images/head_small.gif" border="0">
                </td>
            </tr>
            <tr>
                <td align="center" class="Header">Поиск</td>
            </tr>
            <tr>
                <td align="center">
                    <table id="table1" class="maintext" style="width:100%;">
                        <tr>
                            <td align="right">
                                Фамилия:</td>
                            <td align="left">
                                <cc1:OboutTextBox ID="first_name" runat="server"></cc1:OboutTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Имя:</td>
                            <td align="left">
                                <cc1:OboutTextBox ID="second_name" runat="server"></cc1:OboutTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Отчество:</td>
                            <td align="left">
                                <cc1:OboutTextBox ID="last_name" runat="server"></cc1:OboutTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Личный номер:</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Нагрудный знак сотрудника полиции:</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Номер личного дела:</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Номер служебного удостоверения:</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Дата рождения:</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Дата назначения:</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Дата увольнения (откомандирования):</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Подразделение:</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Структурное подразделение:</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Служба (должностная группа):</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Категория должностей:</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Должность:</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Специальное звание:</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Национальность:</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Уровень образования:</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Специальность:</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Где ищем:</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:imagebutton id="GoBtn" 
                                            runat="server" ToolTip="искать" 
                        ImageUrl="../images/iskat.gif" alt=" Поиск "
											AlternateText="Искать..." onclick="GoBtn_Click"></asp:imagebutton>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <IMG height="33" alt="Панель быстрых переходов..." src="../images/bottom.gif" 
								useMap="#Map" border="0"><MAP name="Map">
                                 <AREA title="На главную..." shape="RECT" alt="На главную..." coords="25,0,100,33" href="../index.aspx">
                                 <AREA title="Поиск сотрудников" shape="RECT" alt="Поиск сотрудников" coords="150,0,200,33"	href="../Search/search_engine.aspx">
                                 <AREA title="Штатно-должностная книга" shape="RECT" alt="Штатно-должностная книга" coords="250,0,325,33"	href="../Structure/orgstr.aspx">
                                 <AREA title="Вакансии" shape="RECT" alt="Вакансии" coords="325,0,425,33" href="../Vakans/vakansy.aspx">
                                 <AREA title="Некомплект" shape="RECT" alt="Некомплект" coords="475,0,550,33" href="../Nekompl/nekompl.aspx">
                                 <AREA title="Качественные показатели" shape="RECT" alt="Качественные показатели" coords="575,0,650,33"	href="../Kachestv/kachestv.aspx">
                                 <AREA title="Дисциплинарная практика" shape="RECT" alt="Дисциплинарная практика" coords="700,0,775,33"	href="../Discipline/discipline.aspx">
                                 </MAP>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
