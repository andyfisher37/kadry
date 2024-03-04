using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace kadry.Control
{
    public partial class BulletPlan : System.Web.UI.Page
    {
        public System.Data.DataRowCollection rc;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            OdbcConnection conn = new OdbcConnection("Dsn=KADRY;Driver={277};dbq=C:\\KADRY;defaultdir=C:\\KADRY;driverid=277;fil=dBase IV;maxbuffersize=2048;pagetimeout=5");
            OdbcCommand comm = new OdbcCommand();
            comm.Connection = conn;
            comm.CommandText = "SELECT PODRAZDEL, KEY_OF_POD FROM PODRAZD.DBF WHERE KEY_OF_POD IN (SELECT DISTINCT PODRAZD FROM AAQQ.DBF WHERE SLUZBA NOT IN (44,59,61)) ORDER BY KEY_OF_POD";
            OdbcDataAdapter adapter = new OdbcDataAdapter(comm.CommandText,conn);

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            rc = ds.Tables[0].Rows;

            #region Таблица №1

            Title1.Text = "Расчет штатной и фактической численности личного состава, для планирования стрельб, по состоянию на " + System.DateTime.Now.ToShortDateString();
            int[] stat = new int[rc.Count];
            int itog1 = 0;
            int[] fact = new int[rc.Count];
            int itog2 = 0;
            int[] stat_1 = new int[rc.Count];
            int itog3 = 0;
            int[] fact_1 = new int[rc.Count];
            int itog4 = 0;
            int[] stat_2 = new int[rc.Count];
            int itog5 = 0;
            int[] fact_2 = new int[rc.Count];
            int itog6 = 0;

            for (int i = 0; i < rc.Count; i++)
            {
                TableRow r = new TableRow();

                TableCell c1 = new TableCell();
                c1.Text = rc[i]["PODRAZDEL"].ToString();
                r.Cells.Add(c1);
                    
                // Штат всего
                comm.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DOLZNOST < '800000' AND DATA_SOKR IS NULL AND SLUZBA NOT IN (44,59,61) AND PODRAZD = " + rc[i]["KEY_OF_POD"].ToString();
                if (conn.State != ConnectionState.Open) conn.Open();
                stat[i] = (int)comm.ExecuteScalar();
                itog1 += stat[i];

                TableCell c2 = new TableCell();
                c2.Text = stat[i].ToString();
                c2.HorizontalAlign = HorizontalAlign.Center;
                r.Cells.Add(c2);

                // Факт всего
                comm.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE DOLZNOST < '800000' AND SLUZBA NOT IN (44,59,61) AND PODRAZD = " + rc[i]["KEY_OF_POD"].ToString();
                if (conn.State != ConnectionState.Open) conn.Open();
                fact[i] = (int)comm.ExecuteScalar();
                itog2 += fact[i];

                TableCell c3 = new TableCell();
                c3.Text = fact[i].ToString();
                c3.HorizontalAlign = HorizontalAlign.Center;
                r.Cells.Add(c3);

                // Штат "с оружием"
                comm.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DOLZNOST < '800000' AND DATA_SOKR IS NULL AND SLUZBA IN (SELECT KEY_OF_SLU FROM SLUZBA WHERE BSPFACTOR = TRUE) AND PODRAZD = " + rc[i]["KEY_OF_POD"].ToString();
                if (conn.State != ConnectionState.Open) conn.Open();
                stat_1[i] = (int)comm.ExecuteScalar();
                itog3 += stat_1[i];

                TableCell c4 = new TableCell();
                c4.Text = stat_1[i].ToString();
                c4.HorizontalAlign = HorizontalAlign.Center;
                r.Cells.Add(c4);

                // Факт "с оружием"
                comm.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE DOLZNOST < '800000' AND SLUZBA IN (SELECT KEY_OF_SLU FROM SLUZBA WHERE BSPFACTOR = TRUE) AND PODRAZD = " + rc[i]["KEY_OF_POD"].ToString();
                if (conn.State != ConnectionState.Open) conn.Open();
                fact_1[i] = (int)comm.ExecuteScalar();
                itog4 += fact_1[i];

                TableCell c5 = new TableCell();
                c5.Text = fact_1[i].ToString();
                c5.HorizontalAlign = HorizontalAlign.Center;
                r.Cells.Add(c5);

                // Штат "без оружия"
                comm.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DOLZNOST < '800000' AND DATA_SOKR IS NULL AND SLUZBA IN (SELECT KEY_OF_SLU FROM SLUZBA WHERE BSPFACTOR = FALSE) AND PODRAZD = " + rc[i]["KEY_OF_POD"].ToString();
                if (conn.State != ConnectionState.Open) conn.Open();
                stat_2[i] = (int)comm.ExecuteScalar();
                itog5 += stat_2[i];

                TableCell c6 = new TableCell();
                c6.Text = stat_2[i].ToString();
                c6.HorizontalAlign = HorizontalAlign.Center;
                r.Cells.Add(c6);

                // Факт "без оружия"
                comm.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE DOLZNOST < '800000' AND SLUZBA IN (SELECT KEY_OF_SLU FROM SLUZBA WHERE BSPFACTOR = FALSE) AND PODRAZD = " + rc[i]["KEY_OF_POD"].ToString();
                if (conn.State != ConnectionState.Open) conn.Open();
                fact_2[i] = (int)comm.ExecuteScalar();
                itog6 += fact_2[i];

                TableCell c7 = new TableCell();
                c7.Text = fact_2[i].ToString();
                c7.HorizontalAlign = HorizontalAlign.Center;
                r.Cells.Add(c7);

                
                Table.Rows.Add(r);
            }

            // Итоговая строка...                       
            TableRow r1 = new TableRow();
            TableCell cc1 = new TableCell();
            cc1.Text = "ИТОГО: ";
            cc1.Font.Bold = true;
            r1.Cells.Add(cc1);

            TableCell cc2 = new TableCell();
            cc2.Text = itog1.ToString();
            cc2.HorizontalAlign = HorizontalAlign.Center;
            cc2.Font.Bold = true;
            r1.Cells.Add(cc2);

            TableCell cc3 = new TableCell();
            cc3.Text = itog2.ToString();
            cc3.HorizontalAlign = HorizontalAlign.Center;
            cc3.Font.Bold = true;
            r1.Cells.Add(cc3);

            TableCell cc4 = new TableCell();
            cc4.Text = itog3.ToString();
            cc4.HorizontalAlign = HorizontalAlign.Center;
            cc4.Font.Bold = true;
            r1.Cells.Add(cc4);

            TableCell cc5 = new TableCell();
            cc5.Text = itog4.ToString();
            cc5.HorizontalAlign = HorizontalAlign.Center;
            cc5.Font.Bold = true;
            r1.Cells.Add(cc5);

            TableCell cc6 = new TableCell();
            cc6.Text = itog5.ToString();
            cc6.HorizontalAlign = HorizontalAlign.Center;
            cc6.Font.Bold = true;
            r1.Cells.Add(cc6);

            TableCell cc7 = new TableCell();
            cc7.Text = itog6.ToString();
            cc7.HorizontalAlign = HorizontalAlign.Center;
            cc7.Font.Bold = true;
            r1.Cells.Add(cc7);
            Table.Rows.Add(r1);

            #endregion

            #region Таблица №2

            // Таблица №2
            Title2.Text = "Расчет штатной и фактической численности личного состава спецподразделений, для планирования стрельб";

            //TableRow r = new TableRow();

            //TableCell c1 = new TableCell();
            //c1.Text = "ОМОН УВД";
            //r.Cells.Add(c1);

            //// Штат всего
            //TableCell c2 = new TableCell();
            //comm.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DOLZNOST < '800000' AND DATA_SOKR IS NULL AND SLUZBA IN (44,59)";
            //if (conn.State != ConnectionState.Open) conn.Open();
            //c2.Text = ((int)comm.ExecuteScalar()).ToString();
            //c2.HorizontalAlign = HorizontalAlign.Center;
            //r.Cells.Add(c2);

            //// Факт всего
            //TableCell c3 = new TableCell();
            //comm.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE DOLZNOST < '800000' AND  AND SLUZBA IN (44,59)";
            //if (conn.State != ConnectionState.Open) conn.Open();
            //c3.Text = ((int)comm.ExecuteScalar()).ToString();
            //c3.HorizontalAlign = HorizontalAlign.Center;
            //r.Cells.Add(c3);

            //// Штат "с оружием"
            //TableCell c4 = new TableCell();
            //comm.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DOLZNOST < '800000' AND DATA_SOKR IS NULL AND SLUZBA IN (SELECT KEY_OF_SLU FROM SLUZBA WHERE BSPFACTOR = TRUE) AND PODRAZD = " + rc[i]["KEY_OF_POD"].ToString();
            //if (conn.State != ConnectionState.Open) conn.Open();
            //c4.Text = ((int)comm.ExecuteScalar()).ToString();
            //c4.HorizontalAlign = HorizontalAlign.Center;
            //r.Cells.Add(c4);

            //// Факт "с оружием"
            //TableCell c5 = new TableCell();
            //comm.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE DOLZNOST < '800000' AND SLUZBA IN (SELECT KEY_OF_SLU FROM SLUZBA WHERE BSPFACTOR = TRUE) AND PODRAZD = " + rc[i]["KEY_OF_POD"].ToString();
            //if (conn.State != ConnectionState.Open) conn.Open();
            //c5.Text = ((int)comm.ExecuteScalar()).ToString();
            //c5.HorizontalAlign = HorizontalAlign.Center;
            //r.Cells.Add(c5);

            //// Штат "без оружия"
            //comm.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DOLZNOST < '800000' AND DATA_SOKR IS NULL AND SLUZBA IN (SELECT KEY_OF_SLU FROM SLUZBA WHERE BSPFACTOR = FALSE) AND PODRAZD = " + rc[i]["KEY_OF_POD"].ToString();
            //if (conn.State != ConnectionState.Open) conn.Open();
            //TableCell c6 = new TableCell();
            //c6.Text = ((int)comm.ExecuteScalar()).ToString();
            //c6.HorizontalAlign = HorizontalAlign.Center;
            //r.Cells.Add(c6);

            //// Факт "без оружия"
            //comm.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE DOLZNOST < '800000' AND SLUZBA IN (SELECT KEY_OF_SLU FROM SLUZBA WHERE BSPFACTOR = FALSE) AND PODRAZD = " + rc[i]["KEY_OF_POD"].ToString();
            //if (conn.State != ConnectionState.Open) conn.Open();
            //fact_2[i] = (int)comm.ExecuteScalar();
            //itog6 += fact_2[i];

            //TableCell c7 = new TableCell();
            //c7.Text = ((int)comm.ExecuteScalar()).ToString();
            //c7.HorizontalAlign = HorizontalAlign.Center;
            //r.Cells.Add(c7);


            //Table2.Rows.Add(r);

            #endregion


        }
    }
}
