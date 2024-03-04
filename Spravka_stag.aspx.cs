using System;
using System.Data.Odbc;
using System.Data;
using UK.DurationCalculatorApp;

namespace UK
{
    public partial class Spravka_stag : System.Web.UI.Page
    {
        protected System.Data.Odbc.OdbcCommand Comm;
        protected System.Data.Odbc.OdbcConnection Conn;
        protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
        public System.Data.DataRowCollection rc;
        public System.Data.DataRowCollection arc;
        public System.Data.DataRowCollection prc;
        public TPeriod army = new TPeriod();
        public TPeriod posl = new TPeriod();
        public TPeriod itog = new TPeriod();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Security.Security s = new Security.Security();

                string curIP = Convert.ToString(Context.Request.UserHostAddress);

                if (curIP != "192.168.10.2") Response.Redirect("AccessDenied.htm", true);
                // Проверка на право доступа...
                if (!s.CheckSecurePage(User.Identity.Name, "spravka_stag.aspx")) Response.Redirect("AccessDenied.htm", true);

                string id = Request.QueryString["id"];

                Conn = new OdbcConnection("MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;DBQ=" +
                "C:\\KADRY;DriverId=277");
                Comm = new OdbcCommand("", Conn);
                DataAdapter = new OdbcDataAdapter(Comm.CommandText, Conn);

                Comm.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, LICH_NOM_1, LICH_NOM_2, DATA_POST, VOIN_ZVAN, DOL.NAM_OF_DOL, PDR.PODRAZDEL,  " +
 
                "N1.NAIMENOVAN AS UPRAVLENIE, N2.NAIMENOVAN AS OTDEL, N3.NAIMENOVAN AS PODOTDEL, N4.NAIMENOVAN AS OTDELENIE, N5.NAIMENOVAN AS GRUP, N6.NAIMENOVAN AS PODR " + 
                    
                "FROM AAQQ, ZVANIE, OFIC_DOL DOL, PODRAZD PDR, NAIMEN.DBF N1, NAIMEN.DBF N2, NAIMEN.DBF N3, NAIMEN.DBF N4, NAIMEN.DBF N5, NAIMEN.DBF N6 " +
                
                "WHERE (PODR = N6.KEY_OF_NAI) AND (GRUP = N5.KEY_OF_NAI) AND (OTDELENIE = N4.KEY_OF_NAI) AND (PODOTDEL = N3.KEY_OF_NAI) AND PODRAZD = PDR.KEY_OF_POD AND " +
				"(OTDEL = N2.KEY_OF_NAI) AND (UPRAVLENIE = N1.KEY_OF_NAI) AND (PODRAZD = KEY_OF_POD) AND REAL_DOLZN = DOL.P3 AND ZVANIE = KEY_ZVAN AND KEY_1 = " + id;

                //Response.Write(Comm.CommandText);

                DataAdapter.SelectCommand = Comm;
                DataSet ds = new DataSet();
                DataAdapter.Fill(ds);
                rc = ds.Tables[0].Rows;

                if (rc.Count > 0)
                {
                    zvanie.Text = rc[0]["VOIN_ZVAN"].ToString();
                    FIO.Text = rc[0]["FAMILIYA"].ToString() + " " + rc[0]["IMYA"].ToString() + " " + rc[0]["OTCHECTVO"].ToString();
                    FIOsmall.Text = GlobalTransform.TransFamily(rc[0]["FAMILIYA"].ToString(), 1) + " " + rc[0]["IMYA"].ToString().Substring(0, 1).ToUpper() + "." + rc[0]["OTCHECTVO"].ToString().Substring(0, 1).ToUpper() + ".";
                    pnumber.Text = "(" + rc[0]["LICH_NOM_1"].ToString() + "-" + rc[0]["LICH_NOM_2"].ToString() + ")";
                    curdate.Text = DateTime.Now.ToShortDateString();
                    vovd.Text = Convert.ToDateTime(rc[0]["DATA_POST"]).ToShortDateString();
                    dolznost.Text = rc[0]["NAM_OF_DOL"].ToString().ToLower();
                    string pdr = "";
                    if (rc[0]["GRUP"].ToString() != "          - # -") pdr += "группы " + rc[0]["NAIM5"].ToString();
                    if (rc[0]["OTDELENIE"].ToString() != "          - # -") pdr += " отделения " + rc[0]["NAIM4"].ToString();
                    if (rc[0]["PODOTDEL"].ToString() != "          - # -") pdr += " подотдела " + rc[0]["NAIM3"].ToString();
                    if (rc[0]["OTDEL"].ToString() != "          - # -") pdr += " отдела " + rc[0]["NAIM2"].ToString();
                    if (rc[0]["UPRAVLENIE"].ToString() != "          - # -") pdr += " управление " + rc[0]["NAIM1"].ToString();
                    if (rc[0]["PODR"].ToString() != "          - # -") pdr += " " + rc[0]["NAIM"].ToString();
                    pdr += " " + rc[0]["PODRAZDEL"].ToString();

                    // Подсчет стажа

                    // Служба в ВС
                    DataSet ds1 = new DataSet();
                    Comm.CommandText = "SELECT ARMY_BEGIN, ARMY_STOP, SOSTAV, VUS, WAR, GODEN, VOENKOMAT, VBILET, BILET_DATE, BILET_RVK, VOIN_ZVAN FROM VUCHET.DBF, ZVANIE.DBF WHERE ZVANIE = KEY_ZVAN AND KEY_1 = " + id;
                    DataAdapter.SelectCommand = Comm;
                    DataAdapter.Fill(ds1);
                    arc = ds1.Tables[0].Rows;
                    if (arc.Count != 0)
                    {
                        for (int i = 0; i < arc.Count; i++)
                        {
                            // Подсчет выслуги в ВС...
                            DateDifference dd;

                            if (arc[i]["ARMY_BEGIN"] != DBNull.Value)
                            {
                                dd = new DateDifference(Convert.ToDateTime(arc[i]["ARMY_BEGIN"]), Convert.ToDateTime(arc[i]["ARMY_STOP"]));
                                army.Add(dd.Days, dd.Months, dd.Years);
                            }
                        }
                    }

                    // Стаж из послужного
                    DataSet ds2 = new DataSet();
                    Comm.CommandText = "SELECT DATA_OT, STATUS, NOM_PRIK FROM POSL_SPI.DBF " +
                        "WHERE (KEY_POSL = " + id + ") ORDER BY DATA_OT, NOM_PRIK";
                    DataAdapter.SelectCommand = Comm;
                    DataAdapter.Fill(ds2);
                    prc = ds2.Tables[0].Rows;

                    // Подсчет выслуги лет...
                    DateTime date1;
                    DateTime date2 = new DateTime();
                    DateDifference dd2;

                    if (prc.Count > 0)
                    {
                        // Если в послужном 1 запись о приеме...
                        if (prc.Count == 1)
                        {
                            // Если 1 запись в послужном (принят)
                            if (prc[0]["STATUS"].ToString() == "2000")
                            {
                                date1 = Convert.ToDateTime(prc[0]["DATA_OT"]);
                                date2 = DateTime.Now;
                                // Вычисляем длительность периода
                                dd2 = new DateDifference(date1, date2);
                                // Добавляем в выслугу...
                                posl.Add(dd2.Days, dd2.Months, dd2.Years);
                            }
                        }
                        else // Если записей в послужном более 1
                        {
                            // Перебираем записи...
                            // Начальная дата расчета
                            date1 = Convert.ToDateTime(prc[0]["DATA_OT"]);
                            int m = 1;
                            string st = "";
                            do
                            {
                                st = prc[m]["STATUS"].ToString();
                                if (st == "4000" || st == "7000") // Если уволен или умер...
                                {
                                    date2 = Convert.ToDateTime(prc[m]["DATA_OT"]);
                                    // Вычисляем длительность периода
                                    dd2 = new DateDifference(date1, date2);
                                    // Добавляем в выслугу...
                                    posl.Add(dd2.Days, dd2.Months, dd2.Years);
                                    m++;
                                    if (m != prc.Count) date1 = Convert.ToDateTime(prc[m]["DATA_OT"]);
                                }
                                else
                                {
                                    m++;
                                }
                            } while (m < prc.Count);

                            date2 = DateTime.Now;
                            // Вычисляем длительность периода
                            dd2 = new DateDifference(date1, date2);
                            // Добавляем в выслугу...
                            posl.Add(dd2.Days, dd2.Months, dd2.Years);
                        }

                        itog.Add(army.d, army.m, army.y);
                        itog.Add(posl.d, posl.m, posl.y);

                        stag.Text = itog.ToSpecLongString();
                    }


                }

                s.AddLogText("Справка о стаже службы: ", Context.Request.UserHostAddress.ToString(), 42, true);
                rc.Clear();
                arc.Clear();
                ds.Dispose();

                
            }

        }
    }
}