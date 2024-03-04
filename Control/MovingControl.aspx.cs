using System;
using System.Web.UI;
using System.Data;
using System.Data.Odbc;
using System.Web.Caching;

namespace kadry.Control
{
    public partial class moving_control : System.Web.UI.Page
    {
        public OdbcCommand Command;
        public OdbcConnection Conn;
        public OdbcDataAdapter DataAdapter;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //kadry.Security.Security s = new kadry.Security.Security();

                //if (!s.CheckSecurePage(User.Identity.Name, "moving_control.aspx")) Response.Redirect("\\AccessDenied.htm", true);

                DataTable dt = DataProvider._getDataODBC("SELECT PODRAZDEL, KEY_OF_POD FROM PODRAZD WHERE KEY_OF_POD IN (SELECT DISTINCT PODRAZD FROM AAQQ)");
                podrList.DataSource = dt;
                podrList.DataTextField = "PODRAZDEL";
                podrList.DataValueField = "KEY_OF_POD";
                podrList.DataBind();
                podrList.Items.Add("Все подразделения");
                podrList.Items.FindByText("Все подразделения").Value = "0";
                podrList.Items.FindByText("Все подразделения").Selected = true;
                dt.Dispose();

                dt = DataProvider._getDataODBC("SELECT NAM_OF_SLU, KEY_OF_SLU FROM SLUZBA");
                sluzList.DataSource = dt;
                sluzList.DataTextField = "NAM_OF_SLU";
                sluzList.DataValueField = "KEY_OF_SLU";
                sluzList.DataBind();
                sluzList.Items.Add("Все службы (кроме ОВО)");
                sluzList.Items.FindByText("Все службы (кроме ОВО)").Value = "-2";
                sluzList.Items.Add("Все службы");
                sluzList.Items.FindByText("Все службы").Value = "-1";
                sluzList.Items.FindByText("Все службы").Selected = true;

                Date1.Text = "01.01." + System.DateTime.Now.Year.ToString();
                Date2.Text = System.DateTime.Now.ToShortDateString();
            }

        }

        protected void SpsButton1_Click(object sender, ImageClickEventArgs e)
        {
            string cmd = String.Format("SELECT DISTINCT KEY_POSL FROM POSL_SPI WHERE KEY_POSL <> 0 AND " +
                                       "KEY_POSL IN (SELECT DISTINCT KEY_1 FROM AAQQ) AND DATA_OT BETWEEN {0} AND {1}",
                                        Convert.ToDateTime(Date1.Text).ToOADate(),
                                        Convert.ToDateTime(Date2.Text).ToOADate());

            // Выбор подразделения...
            if ( podrList.SelectedItem.Value != "0" ) cmd += " AND PODRAZD = " + podrList.SelectedItem.Value;

            // Выбор подчиненного...
            if (podchList.SelectedItem.Value != "-1") cmd += " AND PODR = " + podchList.SelectedItem.Value;

            // Только на руководящие...
            if (!CheckHi.Checked) cmd += " AND DOLZNOST < '800000'";
            else cmd += " AND DOLZNOST < '200000'";

            // Выбор службы
            if (sluzList.SelectedItem.Value != "-1")
            {
                if (sluzList.SelectedItem.Value != "-2")
                {
                    // Объединение некоторых глобальных служб...
                    // КМ
                    if (sluzList.SelectedItem.Value == "1") cmd += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                    else
                        // МОБ
                        if (sluzList.SelectedItem.Value == "2") cmd += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                        else
                            // Кадры
                            if (sluzList.SelectedItem.Value == "4") cmd += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                            else
                                // Тыл
                                if (sluzList.SelectedItem.Value == "5") cmd += " AND SLUZBA IN (5,15,73,76,77) ";
                                else
                                    // ОВО
                                    if (sluzList.SelectedItem.Value == "9") cmd += " AND SLUZBA IN (9,52) ";
                                    else
                                        // Следствие
                                        if (sluzList.SelectedItem.Value == "10") cmd += " AND SLUZBA IN (10,55) ";
                                        else
                                            // ГИБДД
                                            if (sluzList.SelectedItem.Value == "11") cmd += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
                                            else
                                                // УР
                                                if (sluzList.SelectedItem.Value == "24") cmd += " AND SLUZBA IN (24,25) ";
                                                else
                                                    // ППС
                                                    if (sluzList.SelectedItem.Value == "29") cmd += " AND SLUZBA IN (29,54) ";
                                                    else
                                                        // Приемники
                                                        if (sluzList.SelectedItem.Value == "33") cmd += " AND SLUZBA IN (33,63) ";
                                                        else
                                                            // Мед.вытрезв
                                                            if (sluzList.SelectedItem.Value == "40") cmd += " AND SLUZBA IN (40,60) ";
                                                            else
                                                                // Конвой
                                                                if (sluzList.SelectedItem.Value == "43") cmd += " AND SLUZBA IN (43,58) ";
                                                                else
                                                                    // ОМОН
                                                                    if (sluzList.SelectedItem.Value == "44") cmd += " AND SLUZBA IN (44,59) ";
                                                                    else
                                                                        // УЦ
                                                                        if (sluzList.SelectedItem.Value == "78") cmd += " AND SLUZBA IN (78,64) ";
                                                                        else
                                                                            // УНП
                                                                            if (sluzList.SelectedItem.Value == "85") cmd += " AND SLUZBA IN (85,66) ";

                                                                            else cmd += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                }
                else cmd += " AND SLUZBA NOT IN (9,52) ORDER BY KEY_POSL";
                
                //Response.Write(Command.CommandText + "<br>");

                // Заполняем массив ключей...
                DataTable dt = DataProvider._getDataODBC(cmd);

                DataRowCollection rc = dt.Rows;
                dt.Dispose();

                //Response.Write(rc.Count.ToString() + "<br>");

               // // Получаем основные данные
               // DataSet pers = new DataSet();

               // for (int i = 0; i < rc.Count; i++)
               // {
               //     dt = DataProvider._getDataODBC(String.Format("SELECT KEY_1, FAMILIYA, IMYA, OTCHECTVO, VOIN_ZVAN, DATA_VDOLZ, PODRAZDEL, NAM_OF_SLU, NAM_OF_DOL FROM AAQQ, ZVANIE, PODRAZD, SLUZBA, OFIC_DOL WHERE ZVANIE = KEY_ZVAN AND PODRAZD = KEY_OF_POD AND SLUZBA = KEY_OF_SLU AND REAL_DOLZN = OFIC_DOL.P3 AND KEY_1 = {0}",rc[i]["KEY_POSL"].ToString()));
               //     Response.Write(" - " + pers.Tables[0].Rows[i]["FAMILIYA"] + "(" + pers.Tables[0].Rows[i]["KEY_1"] + ")<br>");
               // }

               // // Получаем данные о предыдущей должности...
               // DataSet[] list = new DataSet[rc.Count];

               // //Response.Write(" --------------------------- ");
               // for (int i = 0; i < rc.Count; i++)
               // {
               //     list[i] = new DataSet();
               //     Command.CommandText = "SELECT POSL.*, D.NAM_OF_DOL, N6.NAIMENOVAN, " +
               //                           "Pdr.PODRAZDEL, N1.NAIMENOVAN, N2.NAIMENOVAN, " +
               //                           "N3.NAIMENOVAN, N4.NAIMENOVAN, N5.NAIMENOVAN " +
               //                           "FROM POSL_SPI.DBF POSL, PODRAZD.DBF Pdr, NAIMEN.DBF N1, " +
               //                           "NAIMEN.DBF N2, NAIMEN.DBF N3, NAIMEN.DBF N4, NAIMEN.DBF N5, " +
               //                           "NAIMEN.DBF N6, OFIC_DOL.DBF D " +
               //                           "WHERE (PODR = N6.KEY_OF_NAI) AND (GRUP = N5.KEY_OF_NAI) " +
               //                           "AND (OTDELENIE = N4.KEY_OF_NAI) AND (PODOTDEL = N3.KEY_OF_NAI) " +
               //                           "AND (OTDEL = N2.KEY_OF_NAI) AND (UPRAVLENIE = N1.KEY_OF_NAI) " +
               //                           "AND (PODRAZD = KEY_OF_POD) AND (DOLZNOST = D.P3) " +
               //         //"AND (DATA_OT <> " + Convert.ToDateTime(ds1.Tables[0].Rows[i]["DATA_VDOLZ"]).ToOADate() + ") " +
               //                           "AND (KEY_POSL = " + rc[i]["KEY_POSL"].ToString() + ") ORDER BY DATA_OT DESC";
               //     DataAdapter.SelectCommand = Command;
               //     DataAdapter.Fill(list[i]);
               //     Response.Write(list[i].Tables[0].Rows[0]["KEY_POSL"].ToString() + " (" + list[i].Tables[0].Rows.Count.ToString() + ")<br>");
               //}

               // Cache.Remove("pers");
               // Cache.Add("pers", pers, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);
               // Cache.Remove("list");
               // Cache.Add("list", list, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);

               // Response.Redirect("moving_view.aspx?cat=0&date1=" + Date1.Text + "&date2=" + Date2.Text + "&pdr=" + podrList.SelectedItem.Text + "&slz=" + sluzList.SelectedItem.Text + "&cnt=" + rc.Count.ToString());
            }
        }

        protected void SpsButton2_Click(object sender, ImageClickEventArgs e)
        {
            Command = new OdbcCommand();
            Conn = new OdbcConnection("Dsn=KADRY;defaultdir=C:\\KADRY;driverid=277;fil=dBase IV;maxbuffersize=2048;pagetimeout=5");
            DataAdapter = new OdbcDataAdapter(Command);
            DataSet ds = new DataSet();

            Command.Connection = Conn;
            Command.CommandText = "SELECT DISTINCT KEY_POSL FROM POSL_SPI WHERE KEY_POSL <> 0 AND " +
                                  "KEY_POSL IN (SELECT DISTINCT KEY_1 FROM AAQQ WHERE ZVANIE BETWEEN 20 AND 76) AND " +
                                  "STATUS IN ('3000','9000','9004','9002','1701','1700','1500','1400','1300','1200','1100') AND " +
                                  "DATA_OT BETWEEN " +
                                  Convert.ToDateTime(Date1.Text).ToOADate() +
                                  " AND " +
                                  Convert.ToDateTime(Date2.Text).ToOADate();

            // Выбор подразделения...
            if (podrList.SelectedItem.Value != "0") Command.CommandText += " AND PODRAZD = " + podrList.SelectedItem.Value;
            
            // Выбор подчиненного...
            if (podchList.SelectedItem.Value != "-1") Command.CommandText += " AND PODR = " + podchList.SelectedItem.Value;

            Response.Write(Command.CommandText + "<br>");

            // Заполняем массив ключей...
            ds.Clear();
            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(ds);

            DataRowCollection rc = ds.Tables[0].Rows;

            //Response.Write(rc.Count.ToString() + "<br>");

            // Получаем основные данные
            DataSet pers = new DataSet();

            for (int i = 0; i < rc.Count; i++)
            {
                Command.CommandText = "SELECT KEY_1, FAMILIYA, IMYA, OTCHECTVO, VOIN_ZVAN, DATA_VDOLZ, PODRAZDEL, NAM_OF_SLU, NAM_OF_DOL FROM AAQQ, ZVANIE, PODRAZD, SLUZBA, OFIC_DOL WHERE ZVANIE = KEY_ZVAN AND PODRAZD = KEY_OF_POD AND SLUZBA = KEY_OF_SLU AND REAL_DOLZN = OFIC_DOL.P3 AND KEY_1 IN (" + rc[i]["KEY_POSL"].ToString() + ") ";
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(pers);
                //Response.Write(" - " + pers.Tables[0].Rows[i]["FAMILIYA"] + "(" + pers.Tables[0].Rows[i]["KEY_1"] + ")<br>");
            }

            // Анализируем данные послужного списка...
            DataSet[] list = new DataSet[rc.Count];

            //Response.Write(" --------------------------- ");
            for (int i = 0; i < rc.Count; i++)
            {
                list[i] = new DataSet();
                Command.CommandText = "SELECT POSL.*, D.NAM_OF_DOL, N6.NAIMENOVAN, " +
                                      "Pdr.PODRAZDEL, N1.NAIMENOVAN, N2.NAIMENOVAN, " +
                                      "N3.NAIMENOVAN, N4.NAIMENOVAN, N5.NAIMENOVAN " +
                                      "FROM POSL_SPI.DBF POSL, PODRAZD.DBF Pdr, NAIMEN.DBF N1, " +
                                      "NAIMEN.DBF N2, NAIMEN.DBF N3, NAIMEN.DBF N4, NAIMEN.DBF N5, " +
                                      "NAIMEN.DBF N6, OFIC_DOL.DBF D " +
                                      "WHERE (PODR = N6.KEY_OF_NAI) AND (GRUP = N5.KEY_OF_NAI) " +
                                      "AND (OTDELENIE = N4.KEY_OF_NAI) AND (PODOTDEL = N3.KEY_OF_NAI) " +
                                      "AND (OTDEL = N2.KEY_OF_NAI) AND (UPRAVLENIE = N1.KEY_OF_NAI) " +
                                      "AND (PODRAZD = KEY_OF_POD) AND (DOLZNOST = D.P3) " +
                                      "AND (KEY_POSL = " + rc[i]["KEY_POSL"].ToString() + ") ORDER BY DATA_OT DESC";
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(list[i]);

                //Response.Write(list[i].Tables[0].Rows[0]["KEY_POSL"].ToString() + " (" + list[i].Tables[0].Rows.Count.ToString() + ")<br>");
            }

            Cache.Remove("pers");
            Cache.Add("pers", pers, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);
            Cache.Remove("list");
            Cache.Add("list", list, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);

            Response.Redirect("moving_view.aspx?cat=1&date1=" + Date1.Text + "&date2=" + Date2.Text + "&pdr=" + podrList.SelectedItem.Text + "&slz=" + sluzList.SelectedItem.Text + "&cnt=" + rc.Count.ToString());
        }

        protected void podrList_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        protected void podchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        
    }
}
