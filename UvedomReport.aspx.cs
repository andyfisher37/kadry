using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UK
{
    public partial class UvedomReport : System.Web.UI.Page
    {
        public static int cnt_prn;
        public static int cnt_giv;
        public static int cnt_fct;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cnt_prn = 0;
                cnt_giv = 0;
                cnt_fct = 0;
            }

        }

        // Пофамильный список...
        protected void Button1_Click(object sender, EventArgs e)
        {
            Table3.Visible = false;
            Table2.Visible = false;
            Title2.Visible = false;
            Title3.Visible = false;
            Itog.Visible = false;
            Table1.Visible = true;

            DataView dv = new DataView();
            dv = (DataView)kDataSource1.Select(DataSourceSelectArguments.Empty);

            for (int i = 0; i < dv.Table.Rows.Count; i++)
            {
                uDataSource.SelectCommand = "SELECT date_notification_print, date_notification_give FROM Notification WHERE id = @key";
                uDataSource.SelectParameters.Add("key", dv.Table.Rows[i]["KEY_1"].ToString());
                DataView v = new DataView();
                v = (DataView)uDataSource.Select(DataSourceSelectArguments.Empty);

                if (v.Table.Rows.Count > 0)
                {
                    TableRow r = new TableRow();

                    TableCell c1 = new TableCell();
                    c1.Text = dv.Table.Rows[i]["FAMILIYA"].ToString() + " " + dv.Table.Rows[i]["IMYA"].ToString() + " " + dv.Table.Rows[i]["OTCHECTVO"].ToString();
                    r.Cells.Add(c1);

                    TableCell c2 = new TableCell();
                    c2.Text = dv.Table.Rows[i]["PODRAZDEL"].ToString();
                    if (dv.Table.Rows[i]["NAIMENOVAN"].ToString() != "          - # -")
                        c2.Text += " (" + dv.Table.Rows[i]["NAIMENOVAN"].ToString() + ")";
                    r.Cells.Add(c2);

                    TableCell c3 = new TableCell();
                    c3.Text = dv.Table.Rows[i]["LICH_NOM_1"].ToString() + "-" + dv.Table.Rows[i]["LICH_NOM_2"].ToString();
                    c3.HorizontalAlign = HorizontalAlign.Center;
                    r.Cells.Add(c3);

                    TableCell c4 = new TableCell();
                    c4.Text = Convert.ToDateTime(v.Table.Rows[0][0]).ToShortDateString();
                    c4.HorizontalAlign = HorizontalAlign.Center;
                    r.Cells.Add(c4);

                    TableCell c5 = new TableCell();
                    if (v.Table.Rows[0][1] != DBNull.Value) c5.Text = Convert.ToDateTime(v.Table.Rows[0][1]).ToShortDateString();
                    else c5.Text = "";
                    c5.HorizontalAlign = HorizontalAlign.Center;
                    r.Cells.Add(c5);

                    Table1.Rows.Add(r);
                }

                uDataSource.SelectParameters.Clear();
                v.Dispose();
            }

            dv.Dispose();

        }

        // По ГРУОВД..
        protected void Button2_Click(object sender, EventArgs e)
        {
            Table3.Visible = true;
            Table2.Visible = true;
            Title2.Visible = true;
            Title3.Visible = true;
            Itog.Visible = true;
            Table1.Visible = false;

            // ГРУОВД без ОВО
            DataView dv = new DataView();
            dv = (DataView)kDataSource2.Select(DataSourceSelectArguments.Empty);
            PrintTable(dv, Table2);
                      

            // ОВО ГРУОВД
            DataView dv2 = new DataView();
            dv2 = (DataView)kDataSource3.Select(DataSourceSelectArguments.Empty);
            PrintTable(dv2, Table3);

            Itog.Text = "Итого во всему Управлению МВД России по Ивановской области:<br> ВЫПИСАНО - " + cnt_prn.ToString() + "; ВЫДАНО - " + cnt_giv.ToString() +
                        "; " + Math.Round((Convert.ToSingle(cnt_giv) / Convert.ToSingle(cnt_fct) * 100), 1).ToString() + "% от факт.численности";
 
        }

        public void PrintTable(DataView dv, Table table)
        {
            string curNamePodr = dv.Table.Rows[0]["PODRAZDEL"].ToString();
            string prevNamePodr = dv.Table.Rows[0]["PODRAZDEL"].ToString();
            string curPodch = dv.Table.Rows[0]["NAIMENOVAN"].ToString();
            string prevPodch = dv.Table.Rows[0]["NAIMENOVAN"].ToString();
            int count_print = 0;
            int count_give = 0;
            int count_fact = 0;
            int count_print_itog = 0;
            int count_give_itog = 0;
            int count_fact_itog = dv.Table.Rows.Count;

            for (int i = 0; i < dv.Table.Rows.Count; i++)
            {
                count_fact++;

                uDataSource.SelectCommand = "SELECT date_notification_print, date_notification_give FROM Notification WHERE id = @key";
                uDataSource.SelectParameters.Add("key", dv.Table.Rows[i]["KEY_1"].ToString());
                DataView v = new DataView();
                v = (DataView)uDataSource.Select(DataSourceSelectArguments.Empty);

                if (v.Table.Rows.Count > 0)
                {
                    if (v.Table.Rows[0][0] != DBNull.Value) count_print++;
                    if (v.Table.Rows[0][1] != DBNull.Value) count_give++;
                }

                curNamePodr = dv.Table.Rows[i]["PODRAZDEL"].ToString();

                if (curNamePodr != prevNamePodr)
                {
                    TableRow r = new TableRow();

                    TableCell c1 = new TableCell();
                    c1.Text = prevNamePodr;
                    r.Cells.Add(c1);

                    TableCell c2 = new TableCell();
                    c2.Text = count_print.ToString();
                    c2.HorizontalAlign = HorizontalAlign.Center;
                    r.Cells.Add(c2);

                    TableCell c3 = new TableCell();
                    c3.Text = count_give.ToString();
                    c3.HorizontalAlign = HorizontalAlign.Center;
                    r.Cells.Add(c3);

                    TableCell c4 = new TableCell();
                    c4.Text = Math.Round((Convert.ToSingle(count_give) / Convert.ToSingle(count_fact) * 100), 1).ToString();
                    c4.HorizontalAlign = HorizontalAlign.Center;
                    r.Cells.Add(c4);

                    table.Rows.Add(r);

                    count_fact = 0;

                    count_print_itog += count_print;
                    count_print = 0;

                    count_give_itog += count_give;
                    count_give = 0;


                    prevNamePodr = curNamePodr;
                }

                uDataSource.SelectParameters.Clear();
                v.Dispose();
            }

            #region Итоговая строчка
                TableRow r1 = new TableRow();

            TableCell c11 = new TableCell();
            c11.Text = "Итого:";
            c11.HorizontalAlign = HorizontalAlign.Center;
            r1.Cells.Add(c11);

            TableCell c22 = new TableCell();
            c22.Text = count_print_itog.ToString();
            c22.HorizontalAlign = HorizontalAlign.Center;
            r1.Cells.Add(c22);

            TableCell c33 = new TableCell();
            c33.Text = count_give_itog.ToString();
            c33.HorizontalAlign = HorizontalAlign.Center;
            r1.Cells.Add(c33);

            TableCell c44 = new TableCell();
            c44.Text = Math.Round((Convert.ToSingle(count_give_itog) / Convert.ToSingle(count_fact_itog) * 100), 1).ToString();
            c44.HorizontalAlign = HorizontalAlign.Center;
            r1.Cells.Add(c44);
            
            table.Rows.Add(r1);

            cnt_prn += count_print_itog;
            cnt_giv += count_give_itog;
            cnt_fct += count_fact_itog;
                #endregion


            dv.Dispose();
        }

    }
}
