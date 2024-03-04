using System;
using System.Data;

namespace kadry.Nekompl
{
	/// <summary>
	/// Summary description for nekompl.
	/// </summary>
	public partial class nekompl : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcConnection Connection;
        protected System.Data.Odbc.OdbcDataAdapter kAdapter;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				// Данные по ОПУ и УСТМ
				int ns_opu = 104;
				int rs_opu = 11;
				int ns_opu_nek = 0;
				int rs_opu_nek = 1;
				int ustm = 85;
				int ustm_nek = 1;

                //kadry.Security.Security s = new kadry.Security.Security();

                //if (!s.CheckSecurePage(User.Identity.Name,"nekompl.aspx")) Response.Redirect("\\AccessDenied.htm",true);

                //s.AddLogText("Открытие страницы:[Некомплект]",Context.Request.UserHostAddress,26,true);

				DateLabel1.Text = System.DateTime.Now.ToShortDateString();
				DateLabel2.Text = System.DateTime.Now.ToShortDateString();

				cur_date.Text = System.DateTime.Now.ToShortDateString();
                // Всего вакансий
				Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NULL AND DATA_SOKR IS NULL AND DOLZNOST < '800000' ";
				if ( Connection.State != ConnectionState.Open ) Connection.Open();
				int vak_all = (int)Command.ExecuteScalar();

                // Всего сокращенных должностей
				Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL AND DOLZNOST < '800000' ";
				int dol_sokr = (int)Command.ExecuteScalar();
                
                // Всего по штату аттестованных
				Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST < '800000' ";
				int stat_all = (int)Command.ExecuteScalar();

                // Всего по штату в/н (суммирование должностных ставок)
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST > '800000' AND STAVKA_DLZ = 1";
                double stat_vn_all = (int)Command.ExecuteScalar();

                Command.CommandText = "SELECT STAVKA_DLZ FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST > '800000' AND STAVKA_DLZ <> 1";
                DataSet stv = new DataSet();
                kAdapter = new System.Data.Odbc.OdbcDataAdapter(Command.CommandText, Connection.ConnectionString);
                kAdapter.Fill(stv);
                for (int i = 0; i < stv.Tables[0].Rows.Count; i++)
                {
                    stat_vn_all += Convert.ToDouble(stv.Tables[0].Rows[i]["STAVKA_DLZ"]);
                }

                // Всего по штату фггс
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST > '800000' and POTOLOK IN (80,81,82,83,84,85)";
                int stat_fggs = (int)Command.ExecuteScalar();
              
                // Вакансий - н/с
				Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NULL AND DATA_SOKR IS NULL AND DOLZNOST < '500000' ";
				int vak_ns = (int)Command.ExecuteScalar();
				
                // Сокращено - н/с
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL AND DOLZNOST < '500000' ";
				int ns_sokr = (int)Command.ExecuteScalar();

                // Штат - н/с
				Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST < '500000' ";
				int stat_ns = (int)Command.ExecuteScalar();

                // Штат руководящего состава
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST < '200000' ";
                int stat_rkadry = (int)Command.ExecuteScalar();

                // Штат полиции
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST < '800000' AND POTOLOK > 99";
                int stat_police = (int)Command.ExecuteScalar();

                // Штат иных органов внутренних дел
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST < '800000' AND POTOLOK < 100";
                int stat_other = (int)Command.ExecuteScalar();

                // Вакансий - р/с
				Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NULL AND DATA_SOKR IS NULL AND ((DOLZNOST > '500000') AND (DOLZNOST < '800000'))";
				int vak_rs = (int)Command.ExecuteScalar();

                // Находиться "за штатом" Н/с
                Command.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL AND DOLZNOST < '500000'";
                int zs_ns_count = (int)Command.ExecuteScalar();

                // Находиться "за штатом" р/с
                Command.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL AND DOLZNOST BETWEEN '500000' AND '800000'";
                int zs_rs_count = (int)Command.ExecuteScalar();

                // Находиться "за штатом" работников
                Command.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL AND DOLZNOST > '800000'";
                int zs_vn_count = (int)Command.ExecuteScalar();

                // Совместителей
                Command.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE DOLZNOST < '800000' AND LICH_NOM_2 = 'совмещ'";
                int sovm_count = (int)Command.ExecuteScalar();

                // Находиться "в декрете"
                Command.CommandText = "SELECT COUNT(FAMILIYA) FROM RESERV WHERE DOLZNOST < '800000' AND PRIMECHAN = 'декретный отпуск' ";//AND KEY_1 NOT IN (SELECT DISTINCT KEY_1 FROM AAQQ WHERE DOLZNOST < '800000')";
                int decr_count = (int)Command.ExecuteScalar();

                // Уволено сотрудников по сокращению штатов
              //  Command.CommandText = "SELECT COUNT(FAMILIYA) FROM ARCHIVE WHERE PRICH_UV = '1017' AND DOLZNOST < '800000' AND ZVANIE < 77 AND " +
              //                        "DAT_UVOL > '01.01." + DateTime.Now.Year.ToString() + "'";
              //  int uvs_count = (int)Command.ExecuteScalar();
                                
                // Сокращено - р/с
				Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL AND ((DOLZNOST > '500000') AND (DOLZNOST < '800000'))";
				int rs_sokr = (int)Command.ExecuteScalar();

                // Штат - р/с
				Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND ((DOLZNOST > '500000') AND (DOLZNOST < '800000'))";
				int stat_rs = (int)Command.ExecuteScalar();

                // Вакансий - фггс
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NULL AND DATA_SOKR IS NULL AND POTOLOK IN (80,81,82,83,84,85)";
				int vak_fggs = (int)Command.ExecuteScalar();

                // Сокращено - фггс
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL AND POTOLOK IN (80,81,82,83,84,85)";
				int fggs_sokr = (int)Command.ExecuteScalar();

                                
                // Вакансий - УР н/с
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NULL AND DATA_SOKR IS NULL AND DOLZNOST < '500000' AND SLUZBA IN (24,25)";
                int vak_ur = (int)Command.ExecuteScalar();

                // Сокращено - УР н/с
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL AND DOLZNOST < '500000' AND SLUZBA IN (24,25)";
                int ur_sokr = (int)Command.ExecuteScalar();

                // Штат - УР н/с
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST < '500000' AND SLUZBA IN (24,25)";
                int stat_ur = (int)Command.ExecuteScalar();

                // Вакансий - Следствие
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NULL AND DATA_SOKR IS NULL AND DOLZNOST < '800000' AND SLUZBA IN (10,55)";
                int vak_so = (int)Command.ExecuteScalar();

                // Сокращено - Следствие
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL AND DOLZNOST < '800000' AND SLUZBA IN (10,55)";
                int so_sokr = (int)Command.ExecuteScalar();

                // Штат - Следствие
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST < '800000' AND SLUZBA IN (10,55)";
                int stat_so = (int)Command.ExecuteScalar();

                // Вакансий - ЭБ и ПК
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NULL AND DATA_SOKR IS NULL AND DOLZNOST < '800000' AND SLUZBA IN (27,85)";
                int vak_bep = (int)Command.ExecuteScalar();

                // Сокращено - ЭБ и ПК
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL AND DOLZNOST < '800000' AND SLUZBA IN (27,85)";
                int bep_sokr = (int)Command.ExecuteScalar();

                // Штат - ЭБ и ПК
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST < '800000' AND SLUZBA IN (27,85)";
                int stat_bep = (int)Command.ExecuteScalar();

                //// Вакансий - НП
                //Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NULL AND DATA_SOKR IS NULL AND DOLZNOST < '800000' AND SLUZBA = 85";
                //int vak_np = (int)Command.ExecuteScalar();

                //// Сокращено - НП
                //Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL AND DOLZNOST < '800000' AND SLUZBA = 85";
                //int np_sokr = (int)Command.ExecuteScalar();

                //// Штат - НП
                //Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST < '800000' AND SLUZBA = 85";
                //int stat_np = (int)Command.ExecuteScalar();

                // Вакансий - УУП
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NULL AND DATA_SOKR IS NULL AND DOLZNOST < '500000' AND SLUZBA = 32";
                int vak_uum = (int)Command.ExecuteScalar();

                // Сокращено - УУП
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL AND DOLZNOST < '500000' AND SLUZBA = 32";
                int uum_sokr = (int)Command.ExecuteScalar();

                // Штат - УУП
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST < '500000' AND SLUZBA = 32";
                int stat_uum = (int)Command.ExecuteScalar();

                // Вакансий - ГИБДД
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NULL AND DATA_SOKR IS NULL AND DOLZNOST < '800000' AND SLUZBA IN (11,36,37,38,39,56,65)";
                int vak_gibdd = (int)Command.ExecuteScalar();

                // Сокращено - ГИБДД
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL AND DOLZNOST < '800000' AND SLUZBA IN (11,36,37,38,39,56,65)";
                int gibdd_sokr = (int)Command.ExecuteScalar();

                // Штат - ГИБДД
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST < '800000' AND SLUZBA IN (11,36,37,38,39,56,65)";
                int stat_gibdd = (int)Command.ExecuteScalar();

                // Вакансий - ОВО
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NULL AND DATA_SOKR IS NULL AND DOLZNOST < '800000' AND SLUZBA IN (9,52)";
                int vak_ovo = (int)Command.ExecuteScalar();

                // Сокращено - ОВО
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL AND DOLZNOST < '800000' AND SLUZBA IN (9,52)";
                int ovo_sokr = (int)Command.ExecuteScalar();

                // Штат - ОВО
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST < '800000' AND SLUZBA IN (9,52)";
                int stat_ovo = (int)Command.ExecuteScalar();

                // Вакансий - ППС
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NULL AND DATA_SOKR IS NULL AND DOLZNOST < '800000' AND SLUZBA IN (29,54)";
                int vak_pps = (int)Command.ExecuteScalar();

                // Сокращено - ППС
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL AND DOLZNOST < '800000' AND SLUZBA IN (29,54)";
                int pps_sokr = (int)Command.ExecuteScalar();

                // Штат - ППС
                Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DATA_SOKR IS NULL AND DOLZNOST < '800000' AND SLUZBA IN (29,54)";
                int stat_pps = (int)Command.ExecuteScalar();

				stat_all += ns_opu + rs_opu + ustm;
				stat_ns += ns_opu + ustm;
				stat_rs += rs_opu;
				

                double nek_all = Math.Round((Convert.ToSingle(vak_all - dol_sokr + ns_opu_nek + rs_opu_nek + ustm_nek) / Convert.ToSingle(stat_all) * 100), 1);
                double nek_ns = Math.Round((Convert.ToSingle(vak_ns - ns_sokr + ns_opu_nek + ustm_nek) / Convert.ToSingle(stat_ns) * 100), 1);
                double nek_rs = Math.Round((Convert.ToSingle(vak_rs - rs_sokr + rs_opu_nek + ustm_nek) / Convert.ToSingle(stat_rs) * 100), 1);
                double nek_fggs = Math.Round((Convert.ToSingle(vak_fggs - fggs_sokr) / Convert.ToSingle(stat_fggs) * 100), 1);
                double nek_ur = Math.Round((Convert.ToSingle(vak_ur - ur_sokr) / Convert.ToSingle(stat_ur) * 100), 1);
                double nek_so = Math.Round((Convert.ToSingle(vak_so - so_sokr) / Convert.ToSingle(stat_so) * 100), 1);
                double nek_bep = Math.Round((Convert.ToSingle(vak_bep - bep_sokr) / Convert.ToSingle(stat_bep) * 100), 1);
                ////double nek_np = Math.Round((Convert.ToSingle(vak_np - np_sokr) / Convert.ToSingle(stat_np) * 100), 1);
                double nek_uum = Math.Round((Convert.ToSingle(vak_uum - uum_sokr) / Convert.ToSingle(stat_uum) * 100), 1);
                double nek_gibdd = Math.Round((Convert.ToSingle(vak_gibdd - gibdd_sokr) / Convert.ToSingle(stat_gibdd) * 100), 1);
                double nek_ovo = Math.Round((Convert.ToSingle(vak_ovo - ovo_sokr) / Convert.ToSingle(stat_ovo) * 100), 1);
                double nek_pps = Math.Round((Convert.ToSingle(vak_pps - pps_sokr) / Convert.ToSingle(stat_pps) * 100), 1);
                int nek_ed = vak_all - dol_sokr + ns_opu_nek + rs_opu_nek + ustm_nek;

                //double nek_all = Math.Round((Convert.ToSingle(vak_all + ns_opu_nek + rs_opu_nek + ustm_nek) / Convert.ToSingle(stat_all) * 100), 1);
                //double nek_ns = Math.Round((Convert.ToSingle(vak_ns + ns_opu_nek + ustm_nek) / Convert.ToSingle(stat_ns) * 100), 1);
                //double nek_rs = Math.Round((Convert.ToSingle(vak_rs + rs_opu_nek + ustm_nek) / Convert.ToSingle(stat_rs) * 100), 1);
                //double nek_fb = Math.Round((Convert.ToSingle(vak_fb + ns_opu_nek + rs_opu_nek + ustm_nek) / Convert.ToSingle(stat_fb) * 100), 1);
                //double nek_ur = Math.Round((Convert.ToSingle(vak_ur) / Convert.ToSingle(stat_ur) * 100), 1);
                //double nek_so = Math.Round((Convert.ToSingle(vak_so) / Convert.ToSingle(stat_so) * 100), 1);
                //double nek_bep = Math.Round((Convert.ToSingle(vak_bep) / Convert.ToSingle(stat_bep) * 100), 1);
                ////double nek_np = Math.Round((Convert.ToSingle(vak_np - np_sokr) / Convert.ToSingle(stat_np) * 100), 1);
                //double nek_uum = Math.Round((Convert.ToSingle(vak_uum) / Convert.ToSingle(stat_uum) * 100), 1);
                //double nek_gibdd = Math.Round((Convert.ToSingle(vak_gibdd) / Convert.ToSingle(stat_gibdd) * 100), 1);
                //double nek_ovo = Math.Round((Convert.ToSingle(vak_ovo) / Convert.ToSingle(stat_ovo) * 100), 1);
                //double nek_pps = Math.Round((Convert.ToSingle(vak_pps) / Convert.ToSingle(stat_pps) * 100), 1);
                //int nek_ed = vak_all + ns_opu_nek + rs_opu_nek + ustm_nek;

				stat_all_label.Text = stat_all.ToString() + " ед.";
                stat_ns_label.Text = stat_ns.ToString() + " ед.";
                stat_rkadry_label.Text = stat_rkadry.ToString() + " ед.";
                stat_rs_label.Text = stat_rs.ToString() + " ед.";
                stat_police_label.Text = (stat_police + ns_opu + ustm + rs_opu).ToString() + " ед.";
                stat_other_label.Text = (stat_other).ToString() + " ед.";
				nek_all_label.Text = nek_ed.ToString() + " ед. (" + nek_all.ToString() + " %)";
                nek_ns_label.Text = (vak_ns + ns_opu_nek + ustm_nek).ToString() + " ед., (" + nek_ns.ToString() + " %)";
				nek_rs_label.Text = (vak_rs + rs_opu_nek + ustm_nek).ToString() + " ед., (" + nek_rs.ToString() + " %)";
                stat_vn_all_label.Text = stat_vn_all.ToString() + " ед.";
                stat_fggs_label.Text = stat_fggs.ToString() + " ед.";
				fggs_label.Text = vak_fggs.ToString() + " ед., (" + nek_fggs.ToString() + " %)";
                zs_label.Text = (zs_ns_count + zs_rs_count).ToString() + " чел.";
                zs_ns_label.Text = zs_ns_count.ToString() + " чел.";
                zs_rs_label.Text = zs_rs_count.ToString() + " чел.";
                zs_vn_label.Text = zs_vn_count.ToString() + " чел.";
                decr_label.Text = decr_count.ToString() + " чел.";
                sovm_label.Text = sovm_count.ToString() + " чел.";
                st_ur.Text = stat_ur.ToString();
                ur_nek.Text = nek_ur.ToString();
                st_so.Text = stat_so.ToString();
                so_nek.Text = nek_so.ToString();
                st_bep.Text = stat_bep.ToString();
                bep_nek.Text = nek_bep.ToString();
                //st_np.Text = stat_np.ToString();
                //np_nek.Text = nek_np.ToString();
                st_uum.Text = stat_uum.ToString();
                uum_nek.Text = nek_uum.ToString();
                st_gibdd.Text = stat_gibdd.ToString();
                gibdd_nek.Text = nek_gibdd.ToString();
                st_ovo.Text = stat_ovo.ToString();
                ovo_nek.Text = nek_ovo.ToString();
                st_pps.Text = stat_pps.ToString();
                pps_nek.Text = nek_pps.ToString();
			}
			
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.Connection = new System.Data.Odbc.OdbcConnection();
			// 
			// Command
			// 
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;DBQ=" +
				"C:\\KADRY;DriverId=277";

		}
		#endregion

		protected void Btn1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		   Response.Redirect("/Quality/NekOVD/04_2013.xls",true);
		}

		protected void Btn2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/Quality/Daily_Stat/04_2013.xls",true);
		}

	}
}
