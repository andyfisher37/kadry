using System;
using System.Data;
using System.Data.Odbc;

namespace UK
{
    public partial class ViewIsx : System.Web.UI.Page
    {
        public System.Data.DataRowCollection rc;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Response.ContentType = "application/msword";

                OdbcConnection Conn = new OdbcConnection("Dsn=KADRY;defaultdir=C:\\KADRY;driverid=277;fil=dBase IV;maxbuffersize=2048;pagetimeout=5");
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = Conn;
                OdbcDataAdapter DataAdapter = new OdbcDataAdapter(Command.CommandText, Conn);
                DataSet ds = new DataSet();

                string key = Request.Params["id"];

                Command.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, VOIN_ZVAN, NAM_OF_DOL, PODRAZDEL, DATA_VDOLZ, N_PR_VDOLZ, DT_PR_DOLZ, P1 FROM AAQQ, ZVANIE, OFIC_DOL, SLVPR2, PODRAZD WHERE N_PR_DOLZ1 = SLVPR2.P2 AND PODRAZD = KEY_OF_POD AND REAL_DOLZN = OFIC_DOL.P3 AND ZVANIE = KEY_ZVAN AND LICH_NOM_2 <> 'совмещ' AND KEY_1 = " + key;
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);

                rc = ds.Tables[0].Rows;

                if (rc.Count != 1)
                {
                    Response.Write("<script> alert('Ошибка при выборе сведений!'); </script>");
                    Response.Redirect("\\Search\\search.aspx");
                }

                if (Request.Params["type"] == "0")
                {
                    SecLabel.Visible = true;
                    FirstLabel.Text = "Направляю в Ваш адрес для дальнейшего хранения и ведения личное дело ";
                    PersInfo.Text = rc[0]["VOIN_ZVAN"].ToString().ToLower() + " " +
                                    rc[0]["FAMILIYA"].ToString() + " " +
                                    rc[0]["IMYA"].ToString() + " " +
                                    rc[0]["OTCHECTVO"].ToString() + ", " + Convert.ToDateTime(rc[0]["DATA_ROZD"]).ToShortDateString() + " года рождения";
                    if (Convert.ToBoolean(Request.Params["PrCheck"]))
                    {
                        PersInfo.Text += ", назначенного на должность " +
                                        rc[0]["NAM_OF_DOL"].ToString().ToLower() +
                                        rc[0]["PODRAZDEL"].ToString() +
                                        " c " + Convert.ToDateTime(rc[0]["DATA_VDOLZ"]).ToShortDateString() +
                                        " (Приказ " + rc[0]["P1"].ToString() + " от " + Convert.ToDateTime(rc[0]["DT_PR_DOLZ"]).ToShortDateString() + " №" + rc[0]["N_PR_VDOLZ"].ToString() + " л/с)";
                    }

                    int count = 1;

                    Prilog.Text = "Приложение: <br>";

                    if (Request.Params["n_main"] != "0") { Prilog.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + count.ToString() + ". Личное дело на " + Convert.ToInt16(Request.Params["n_main"]) + " л. в 1 экз.<br>"; count++; }
                    if (Request.Params["n_sp"] != "0") { Prilog.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + count.ToString() + ". Материалы <<СП>> на " + Convert.ToInt16(Request.Params["n_sp"]) + " л. в 1 экз.(СЕКРЕТНО)<br>"; count++; }
                    if (Request.Params["n_zap"] != "0") { Prilog.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + count.ToString() + ". Личное дело офицера запаса на " + Convert.ToInt16(Request.Params["n_zap"]) + " л. в 1 экз.<br>"; count++; }
                    if (Request.Params["n_tk"] != "0") { Prilog.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + count.ToString() + ". Трудовая книжка: " + Request.Params["n_tk"] + " в 1 экз.<br>"; count++; }
                    if (Request.Params["n_vb"] != "0") { Prilog.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + count.ToString() + ". Военный билет: " + Request.Params["n_vb"] + " в 1 экз.<br>"; count++; }

                }
                else
                {
                    SecLabel.Visible = false;
                    FirstLabel.Text = "Прошу Вас направить в адрес УРЛС УВД личное дело ";
                    PersInfo.Text = rc[0]["VOIN_ZVAN"].ToString().ToLower() + " " +
                                    rc[0]["FAMILIYA"].ToString() + " " +
                                    rc[0]["IMYA"].ToString() + " " +
                                    rc[0]["OTCHECTVO"].ToString() + ", " + Convert.ToDateTime(rc[0]["DATA_ROZD"]).ToShortDateString() + " года рождения";

                    if (Convert.ToBoolean(Request.Params["PrCheck"]))
                    {
                        PersInfo.Text += ", назначенного на должность " +
                                        rc[0]["NAM_OF_DOL"].ToString().ToLower() +
                                        rc[0]["PODRAZDEL"].ToString() +
                                        " c " + Convert.ToDateTime(rc[0]["DATA_VDOLZ"]).ToShortDateString() +
                                        " (Приказ " + rc[0]["P1"].ToString() + " от " + Convert.ToDateTime(rc[0]["DT_PR_DOLZ"]).ToShortDateString() + " №" + rc[0]["N_PR_VDOLZ"].ToString() + " л/с)";
                    }

                    if (Request.Params["ret"] == "1")
                    {
                        OtherText.Text += "По миновании надобности личное дело будет возвращено.";
                    }
                }

                PodrName.Text = Request.Params["Podr"];
                PodrRuk.Text = Request.Params["RukZvan"] + "<br>" + Request.Params["PodrRuk"];

                string Ruk = Request.Params["Ruk"];

                if (Ruk == "ГУБИН")
                {
                    RukDol.Text = "Заместитель начальника УРЛС<br>УМВД России по Ивановской области<br>полковник милиции";
                    RukName.Text = "О.Ю.Губин";
                }
                else if (Ruk == "МОЛОДКИН")
                {
                    RukDol.Text = "Заместитель начальника УВД -<br>начальник управления по работе с личным составом<br>полковник милиции";
                    RukName.Text = "М.В.Молодкин";
                }
                else if (Ruk == "НОВИЧКОВ")
                {
                    RukDol.Text = "Заместитель начальника УРЛС<br>УМВД России по Ивановской области<br>полковник милиции";
                    RukName.Text = "Н.М.Новичков";
                }

                Isp.Text = "Исп.<br>" + Request.Params["Isp"] + "<br>" + Request.Params["IspPhone"];

                rc.Clear();
                ds.Dispose();
            }

        }

        // Обаботка фамилии, имени, отчества
        public string getFIO(string n1, string n2, string n3)
        {
            string tmp = "";

            if ( n1.Substring(n1.Length-2,2) == "ов" ) tmp += n1 + "а";
            else if ( n1.Substring(n1.Length - 3, 3) == "ова") tmp += n1.Substring(0,n1.Length-2) + "ой";
            else if (n1.Substring(n1.Length - 2, 2) == "ин") tmp += n1 + "а";
            else if (n1.Substring(n1.Length - 3, 3) == "ина") tmp += n1.Substring(0, n1.Length - 2) + "ой";
            else if (n1.Substring(n1.Length - 2, 2) == "ая") tmp += n1.Substring(0, n1.Length - 2) + "ой";
            else if (n1.Substring(n1.Length - 2, 2) == "ой") tmp += n1.Substring(0, n1.Length - 2) + "ого";
            else tmp += n1 + "а";

            if (n2.Substring(n2.Length - 2, 2) == "ей") tmp += n2.Substring(0, n2.Length - 2) + "ея";
            else if (n2.Substring(n2.Length - 2, 2) == "ий") tmp += n2.Substring(0, n2.Length - 2) + "ия";
            else if (n2.Substring(n2.Length - 2, 2) == "ил") tmp += n2.Substring(0, n2.Length - 2) + "ила";

            return tmp;

        }
        
    }
}
