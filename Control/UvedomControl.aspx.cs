using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kadry.Control
{
    public partial class UvedomControl : System.Web.UI.Page
    {
        public static DataRowCollection rc;
        public static DataRow r;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Date1.Text = DateTime.Now.AddMonths(-1).ToShortDateString();
                Date2.Text = DateTime.Now.AddMonths(1).ToShortDateString();
                vTable.Visible = false;

                podrList.DataBind();
                podrList.Items.Add("Все подразделения");
                podrList.Items.FindByText("Все подразделения").Value = "-1";
                podrList.Items.FindByText("Все подразделения").Selected = true;
            }

        }

        //Список сотрудников у которых истекает срок уведомления (+10 дней): 
        protected void Btn2_Click(object sender, ImageClickEventArgs e)
        {
            DataView dv = new DataView();
            nDataSource.SelectCommand = "SELECT id, date_notification_print, date_notification_give FROM Notification WHERE date_notification_give >= convert(smalldatetime,'" + DateTime.Now.AddMonths(-2).ToShortDateString() + "',104) and date_notification_give <= convert(smalldatetime,'" + DateTime.Now.AddMonths(-2).AddDays(10).ToShortDateString() + "',104) order by date_notification_give";
            dv = (DataView)nDataSource.Select(DataSourceSelectArguments.Empty);

            rc = dv.Table.Rows;
            int count = 0;

            if (rc.Count > 0)
            {
                vTable.Visible = true;

                for (int i = 0; i < rc.Count; i++)
                {
                    kDataSource2.SelectCommand = "SELECT KEY_1, FAMILIYA, IMYA, OTCHECTVO, PODRAZDEL, NAM_OF_DOL FROM AAQQ, PODRAZD, OFIC_DOL WHERE PODRAZD = KEY_OF_POD AND REAL_DOLZN = OFIC_DOL.P3 AND KEY_1 = " + rc[i]["id"].ToString();

                    if (podrList.SelectedValue != "-1") kDataSource2.SelectCommand += " AND PODRAZD = " + podrList.SelectedValue;

                    DataView dv1 = new DataView();
                    dv1 = (DataView)kDataSource2.Select(DataSourceSelectArguments.Empty);

                    if (dv1.Table.Rows.Count > 0)
                    {
                        count++;

                        r = dv1.Table.Rows[0];
                        
                        TableRow tr = new TableRow();

                        TableCell c1 = new TableCell();
                        c1.Text = count.ToString();
                        c1.HorizontalAlign = HorizontalAlign.Center;
                        tr.Cells.Add(c1);

                        TableCell c2 = new TableCell();
                        c2.Text = r["FAMILIYA"].ToString();
                        tr.Cells.Add(c2);

                        TableCell c3 = new TableCell();
                        c3.Text = r["IMYA"].ToString();
                        tr.Cells.Add(c3);

                        TableCell c4 = new TableCell();
                        c4.Text = r["OTCHECTVO"].ToString();
                        tr.Cells.Add(c4);

                        TableCell c5 = new TableCell();
                        c5.Text = r["PODRAZDEL"].ToString();
                        tr.Cells.Add(c5);

                        TableCell c6 = new TableCell();
                        c6.Text = r["NAM_OF_DOL"].ToString();
                        tr.Cells.Add(c6);

                        TableCell c7 = new TableCell();
                        c7.Text = Convert.ToDateTime(rc[i]["date_notification_give"]).ToShortDateString();
                        c7.HorizontalAlign = HorizontalAlign.Center;
                        tr.Cells.Add(c7);

                        TableCell c8 = new TableCell();
                        c8.Text = Convert.ToDateTime(rc[i]["date_notification_give"]).AddMonths(2).ToShortDateString();
                        c8.HorizontalAlign = HorizontalAlign.Center;
                        tr.Cells.Add(c8);
                        
                        vTable.Rows.Add(tr);
                    }
                    dv1.Dispose();
                }

                vTable.Visible = true;
            }
            else Response.Write("<script> alert('Сотрудников не найдено!'); window.reload(); </script>");
        }

        // Список по периоду истечения срока действия...
        protected void Btn1_Click(object sender, ImageClickEventArgs e)
        {
            DateTime d1 = Convert.ToDateTime(Date1.Text);
            DateTime d2 = Convert.ToDateTime(Date2.Text);

            DataView dv = new DataView();
            nDataSource.SelectCommand = "SELECT id, date_notification_print, date_notification_give FROM Notification WHERE date_notification_give >= convert(smalldatetime,'" + d1.AddMonths(-2).ToShortDateString() + "',104) and date_notification_give <= convert(smalldatetime,'" + d2.AddMonths(-2).ToShortDateString() + "',104) order by date_notification_give";
            dv = (DataView)nDataSource.Select(DataSourceSelectArguments.Empty);

            rc = dv.Table.Rows;
            int count = 0;

            if (rc.Count > 0)
            {
                vTable.Visible = true;

                for (int i = 0; i < rc.Count; i++)
                {
                    kDataSource2.SelectCommand = "SELECT KEY_1, FAMILIYA, IMYA, OTCHECTVO, PODRAZDEL, NAM_OF_DOL FROM AAQQ, PODRAZD, OFIC_DOL WHERE PODRAZD = KEY_OF_POD AND REAL_DOLZN = OFIC_DOL.P3 AND KEY_1 = " + rc[i]["id"].ToString();

                    if (podrList.SelectedValue != "-1") kDataSource2.SelectCommand += " AND PODRAZD = " + podrList.SelectedValue;

                    DataView dv1 = new DataView();
                    dv1 = (DataView)kDataSource2.Select(DataSourceSelectArguments.Empty);

                    if (dv1.Table.Rows.Count > 0)
                    {
                        count++;

                        r = dv1.Table.Rows[0];

                        TableRow tr = new TableRow();

                        TableCell c1 = new TableCell();
                        c1.Text = count.ToString();
                        c1.HorizontalAlign = HorizontalAlign.Center;
                        tr.Cells.Add(c1);

                        TableCell c2 = new TableCell();
                        c2.Text = r["FAMILIYA"].ToString();
                        tr.Cells.Add(c2);

                        TableCell c3 = new TableCell();
                        c3.Text = r["IMYA"].ToString();
                        tr.Cells.Add(c3);

                        TableCell c4 = new TableCell();
                        c4.Text = r["OTCHECTVO"].ToString();
                        tr.Cells.Add(c4);

                        TableCell c5 = new TableCell();
                        c5.Text = r["PODRAZDEL"].ToString();
                        tr.Cells.Add(c5);

                        TableCell c6 = new TableCell();
                        c6.Text = r["NAM_OF_DOL"].ToString();
                        tr.Cells.Add(c6);

                        TableCell c7 = new TableCell();
                        c7.Text = Convert.ToDateTime(rc[i]["date_notification_give"]).ToShortDateString();
                        c7.HorizontalAlign = HorizontalAlign.Center;
                        tr.Cells.Add(c7);

                        TableCell c8 = new TableCell();
                        c8.Text = Convert.ToDateTime(rc[i]["date_notification_give"]).AddMonths(2).ToShortDateString();
                        c8.HorizontalAlign = HorizontalAlign.Center;
                        tr.Cells.Add(c8);

                        vTable.Rows.Add(tr);
                    }
                    dv1.Dispose();
                }

                vTable.Visible = true;
            }
            else Response.Write("<script> alert('Сотрудников не найдено!'); window.reload(); </script>");

        }
    }
}
