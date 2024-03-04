using System;
using System.Data;
using System.Web.Caching;
using System.Web.UI.WebControls;
using eWorld.UI;


namespace kadry.ProfPod
{
    public partial class EditFirstEducation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string date1 = Request.Params["date1"];
                string date2 = Request.Params["date2"];
                int Count = 0;

                DataSet ds = new DataSet();
                ds = (DataSet)Cache["First_education"];
				TitleText.Text = "Список принятых (прибывших) сотрудников ОВД Ивановской области в период с " + date1 + " г. по " + date2 + " г." ;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TableRow r = new TableRow();
                    // Фамилия
                    TableCell c1 = new TableCell();
                    c1.Text = ds.Tables[0].Rows[i]["FAMILIYA"].ToString();
                    r.Cells.Add(c1);
                    // Имя
                    TableCell c2 = new TableCell();
                    c2.Text = ds.Tables[0].Rows[i]["IMYA"].ToString();
                    r.Cells.Add(c2);
                    // Отчество
                    TableCell c3 = new TableCell();
                    c3.Text = ds.Tables[0].Rows[i]["OTCHECTVO"].ToString();
                    r.Cells.Add(c3);
                    // Подразделение
                    TableCell c4 = new TableCell();
                    c4.Text = ds.Tables[0].Rows[i]["PODRAZDEL"].ToString();
                    r.Cells.Add(c4);
                    // Служба
                    TableCell c5 = new TableCell();
                    c5.Text = ds.Tables[0].Rows[i]["NAM_OF_SLU"].ToString();
                    r.Cells.Add(c5);
                    // Должность
                    TableCell c6 = new TableCell();
                    c6.Text = ds.Tables[0].Rows[i]["NAM_OF_DOL"].ToString();
                    r.Cells.Add(c6);
                    // Звание
                    TableCell c7 = new TableCell();
                    c7.HorizontalAlign = HorizontalAlign.Center;
                    c7.Text = ds.Tables[0].Rows[i]["VOIN_ZVAN"].ToString();
                    r.Cells.Add(c7);
                    // Дата приема
                    TableCell c8 = new TableCell();
                    c8.HorizontalAlign = HorizontalAlign.Center;
                    c8.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DAT_PRI"]).ToShortDateString();
                    r.Cells.Add(c8);
                    // Приказ ОВД
                    TableCell c9 = new TableCell();
                    c9.HorizontalAlign = HorizontalAlign.Center;
                    c9.Text = ds.Tables[0].Rows[i]["P1"].ToString();
                    r.Cells.Add(c9);
                    // № приказа
                    TableCell c10 = new TableCell();
                    c10.Text = ds.Tables[0].Rows[i]["N_PR_VDOLZ"].ToString();
                    r.Cells.Add(c10);
                    // Дата приказа
                    TableCell c11 = new TableCell();
                    c11.HorizontalAlign = HorizontalAlign.Center;
                    c11.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_POST"]).ToShortDateString();
                    r.Cells.Add(c11);
                    // Откуда принят
                    TableCell c12 = new TableCell();
                    c12.HorizontalAlign = HorizontalAlign.Center;
                    if (ds.Tables[0].Rows[i]["OTKYDA"].ToString() != "") c12.Text = ds.Tables[0].Rows[i]["OTKYDA"].ToString();
                    else c12.Text = "-";
                    r.Cells.Add(c12);

                    // Дата напрвления в ЦПП
                    TableCell c13 = new TableCell();
                    c13.HorizontalAlign = HorizontalAlign.Center;
                    c13.Text = "";
                    eWorld.UI.MaskedTextBox dateGO = new MaskedTextBox();
                    dateGO.Mask = "99.99.9999";
                    dateGO.CssClass = "label2";
                    dateGO.Width = Unit.Pixel(76);
                    dateGO.ToolTip = "Дата (ДД.ММ.ГГГГ)";
                    c13.Controls.Add(dateGO);
                    
                    r.Cells.Add(c13);

                    // Категория группы
                    TableCell c14 = new TableCell();
                    c14.HorizontalAlign = HorizontalAlign.Center;
                    c14.Text = "";
                    System.Web.UI.WebControls.DropDownList cat = new DropDownList();
                    cat.Text = "не определено";
                    cat.Items.Add("КМ");
                    cat.Items.Add("МОБ и прочие...");
                    cat.CssClass = "label2";
                    cat.ToolTip = "КМ или МОБ и прочие...";
                    c14.Controls.Add(cat);

                    r.Cells.Add(c14);
                    
                    // Статус
                    TableCell c15 = new TableCell();
                    c15.HorizontalAlign = HorizontalAlign.Center;
                    c15.Text = "";
                    System.Web.UI.WebControls.RadioButtonList status = new RadioButtonList();
                    status.Items.Add("прошел");
                    status.Items.Add("не прошел");
                    status.Items[1].Selected = true;
                    status.CssClass = "label2";
                    status.RepeatDirection = RepeatDirection.Horizontal;
                    status.ToolTip = "Выберите статус прохождения первоначалки...";
                    c15.Controls.Add(status);

                    r.Cells.Add(c15);
                    
                    // Сохранение значений...
                    TableCell c16 = new TableCell();
                    c16.HorizontalAlign = HorizontalAlign.Center;
                    c16.Text = "";
                    System.Web.UI.WebControls.ImageButton btn = new ImageButton();
                    btn.ImageUrl = "/images/fdd.gif";
                    btn.ToolTip = "Сохранить изменения...";
                    btn.OnClientClick = "SaveClick()";
                    c16.Controls.Add(btn);

                    r.Cells.Add(c16);


                    Table.Rows.Add(r);
                }
                Count = ds.Tables[0].Rows.Count;
                
                ds.Clear();
                Cache.Remove("First_education");
            }

        }
    }
}
