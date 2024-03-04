using System;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;




namespace kadry.Contracts
{
    public partial class Contract : System.Web.UI.Page
    {
        public static string id; // Ключ сотрудника
        
        public OdbcConnection oConn;
        public OdbcCommand oComm;
        public OdbcDataAdapter oDataAdapter;

        public SqlConnection sConn;
        public SqlCommand sComm;
                   
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Request["id"];


                oConn = new OdbcConnection("Dsn=KADRY;dbq=C:\\KADRY;defaultdir=C:\\KADRY;driverid=277;fil=dBase IV;maxbuffersize=2048;pagetimeout=5");
                oComm = new OdbcCommand("SELECT FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, VOIN_ZVAN, PODRAZD, UPRAVLENIE, OTDEL, " +
                        "PODOTDEL, OTDELENIE, GRUP, PODR, " +
                        "D.NAM_OF_DOL, N6.NAIMENOVAN, Pdr.PODRAZDEL, N1.NAIMENOVAN, N2.NAIMENOVAN, " +
                        "N3.NAIMENOVAN, N4.NAIMENOVAN, N5.NAIMENOVAN " +
						"FROM AAQQ, ZVANIE, PODRAZD.DBF Pdr, NAIMEN.DBF N1, NAIMEN.DBF N2, NAIMEN.DBF N3, NAIMEN.DBF N4, NAIMEN.DBF N5, NAIMEN.DBF N6, OFIC_DOL.DBF D " +
						"WHERE (PODR = N6.KEY_OF_NAI) AND (GRUP = N5.KEY_OF_NAI) " +
						"AND (OTDELENIE = N4.KEY_OF_NAI) AND (PODOTDEL = N3.KEY_OF_NAI) " +
						"AND (OTDEL = N2.KEY_OF_NAI) AND (UPRAVLENIE = N1.KEY_OF_NAI) " +
						"AND (PODRAZD = KEY_OF_POD) AND (REAL_DOLZN = D.P3) AND (ZVANIE = KEY_ZVAN) " +
                        "AND (DOLZNOST < '800000') AND (LICH_NOM_2 <> 'совмещ') AND KEY_1 = " + id, oConn);
                oDataAdapter = new OdbcDataAdapter(oComm.CommandText, oConn);
                
                DataSet ds = new DataSet();

                oDataAdapter.Fill(ds);
                
                DataRowCollection rc = ds.Tables[0].Rows;

                first_name.Text = rc[0]["FAMILIYA"].ToString();
                name.Text = rc[0]["IMYA"].ToString();
                second_name.Text = rc[0]["OTCHECTVO"].ToString();

                small_name.Text = first_name.Text + " " + name.Text[0].ToString().ToUpper() + "." + second_name.Text[0].ToString().ToUpper() + ".";

                born.Text = Convert.ToDateTime(rc[0]["DATA_ROZD"]).ToShortDateString();

                string pdr = "";
				if (rc[0]["GRUP"].ToString() != "9" )		pdr += "группы " + rc[0]["NAIMENOVAN5"].ToString();
				if (rc[0]["OTDELENIE"].ToString() != "9" )	pdr += " отделения " + rc[0]["NAIMENOVAN4"].ToString();
				if (rc[0]["PODOTDEL"].ToString() != "9" )	pdr += " подотдела " + rc[0]["NAIMENOVAN3"].ToString();
				if (rc[0]["OTDEL"].ToString() != "9" )		pdr += " отдела " + rc[0]["NAIMENOVAN2"].ToString();
				if (rc[0]["UPRAVLENIE"].ToString() != "9" )	pdr += " управление " + rc[0]["NAIMENOVAN1"].ToString();
				if (rc[0]["PODR"].ToString() != "9" )		pdr += " " + rc[0]["NAIMENOVAN"].ToString();
                pdr += " " + rc[0]["PODRAZDEL"].ToString();
                dolz1.Text = TransNames(rc[0]["NAM_OF_DOL"].ToString() + pdr);
                rank.Text = rc[0]["VOIN_ZVAN"].ToString().ToLower();
                dolz2.Text = dolz1.Text;
                
            }

        }
                
        protected void Button1_Click(object sender, EventArgs e)
        {
            sConn = new SqlConnection("Data Source=URLS_SERVER\\SQLEXPRESS;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*");

            sComm = new SqlCommand("DELETE FROM [IAS].[dbo].[Contracts] WHERE id = " + id, sConn);

            if (sConn.State != ConnectionState.Open) sConn.Open();

            int res = sComm.ExecuteNonQuery();

            sComm.CommandText = "INSERT INTO [IAS].[dbo].[Contracts] ([id],[data],[srok],[pass_ser],[pass_num],[pass_ovd],[live_place]) " +
                    "VALUES (" + id +",'" + DateTime.Now.ToShortDateString() + "','" + srok_list.SelectedValue + "','" + 
                    pass_ser.Text + "','" + pass_num.Text + "','" + pass_ovd.Text + "','" + live_place.Text + "')";
            if (sConn.State != ConnectionState.Open) sConn.Open();

            res = sComm.ExecuteNonQuery();

            //Response.Write(sComm.CommandText);
            pass_ser.Text = pass_ser.Text.Trim(Convert.ToChar(" "));
            pass_num.Text = pass_num.Text.Trim(Convert.ToChar(" "));


            Response.Redirect("ContractView.aspx?first_name=" + first_name.Text +
                                "&name=" + name.Text +
                                "&second_name=" + second_name.Text +
                                "&born=" + born.Text +
                                "&dol1=" + dolz1.Text +
                                "&dol2=" + dolz2.Text +
                                "&fiosmall=" + small_name.Text +
                                "&rank=" + rank.Text +
                                "&pass_ser=" + pass_ser.Text +
                                "&pass_num=" + pass_num.Text +
                                "&pass_ovd=" + pass_ovd.Text +
                                "&live_place=" + live_place.Text, true);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            dolz2.Text = dolz1.Text;
        }

        // Преобразование некоторых наименований подразделений...
        public static string TransNames(string name)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder(name);

            str.Replace("УМВД по Ивановской обл.", "УМВД России по Ивановской области");
            str.Replace("УМВД по городу Иваново", "УМВД России по городу Иваново");
            str.Replace("отдела Штаб", "Штаба");
            str.Replace("отделения Штаб", "Штаба");
            str.Replace("отделения Дежурная часть", "дежурной части");
            str.Replace("группы Дежурная часть", "дежурной части");
            str.Replace("подотдела Дежурная часть", "дежурной части");
            str.Replace("отдела Уголовного розыска", "отдела уголовного розыска");
            str.Replace("группы Филиал", "филиала");
            
            return str.ToString();
        }
    }
}