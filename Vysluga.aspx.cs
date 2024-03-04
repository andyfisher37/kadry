using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using UK.Security;
using UK.DurationCalculatorApp;


namespace UK
{
    
	/// <summary>
	/// Summary description for Vysluga.
	/// </summary>
	public class Vysluga : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label DateLabel;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected UK.vyslugaDataSet vyslugaDataSet;
		protected System.Web.UI.WebControls.Label TitleLabel;
		protected System.Web.UI.WebControls.Label year_total;
		protected System.Web.UI.WebControls.Label month_total;
		protected System.Web.UI.WebControls.Label day_total;
		protected System.Web.UI.WebControls.Label year_army;
		protected System.Web.UI.WebControls.Label month_army;
		protected System.Web.UI.WebControls.Label day_army;
		protected System.Web.UI.WebControls.Label year_ovd;
		protected System.Web.UI.WebControls.Label month_ovd;
		protected System.Web.UI.WebControls.Label day_ovd;
		protected eWorld.UI.MaskedTextBox DateBox;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Data.DataRowCollection rc;
        public static string id;
	
		public struct TPeriod
		{
			public int d;
			public int m;
			public int y;

			public void Add(int d1, int m1, int y1)
			{
				d = d + d1;
				m = m + m1;
				y = y + y1;
			}

		}

   		// функция возвращает период в днях, мес., и годах между 2-мя датами...
		public TPeriod CalcStag( DateTime begin, DateTime stop)
		{
			System.TimeSpan span = stop - begin;
			TPeriod period = new TPeriod();
			period.y = Convert.ToInt16(span.Days / 365);
			period.m = Convert.ToInt16( (span.Days - (period.y * 365)) / 12 );
			period.d = Convert.ToInt16( ((span.Days - (period.y * 365)) - (period.m * 30)) / 30 );
			return period;
		}
        
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				UK.Security.Security s = new UK.Security.Security();


                id = Request.Params["id"];
                TitleLabel.Text = Request.Params["name"];
                DateTime today = System.DateTime.Today;
                DateLabel.Text = today.ToShortDateString() + " г.";
                DateBox.Text = today.ToShortDateString();

                s.AddLogText("Подсчет выслуги лет:" + Request.Params["name"], (string)(Context.Request.UserHostAddress), 30, true);

                TPeriod army = new TPeriod();
                bool isArmy = false;

                TPeriod last = new TPeriod();
                TPeriod total = new TPeriod();


				// Выслуга в армии...
                Command.CommandText = "SELECT ARMY_BEGIN, ARMY_STOP FROM VUCHET.DBF WHERE KEY_1 = " + id + " AND ARMY_BEGIN IS NOT NULL ORDER BY ARMY_BEGIN";
                DataAdapter.Fill(vyslugaDataSet, "Table");
                rc = vyslugaDataSet.Tables["Table"].Rows;

                if (rc.Count != 0)
                {
                    for (int i = 0; i < rc.Count; i++)
                    {
                        DateTime begin = Convert.ToDateTime(rc[i]["ARMY_BEGIN"]);
                        DateTime stop = Convert.ToDateTime(rc[i]["ARMY_STOP"]);

                        DateDifference dd = new DateDifference(begin, stop);
                        army.Add(dd.Days,dd.Months,dd.Years);
                    }

                    day_army.Text = army.d.ToString();
                    month_army.Text = army.m.ToString();
                    year_army.Text = army.y.ToString();
                    isArmy = true;
                }

                rc.Clear();

				// Выслуга в органах...
				Command.CommandText = "SELECT DATA_OT, STATUS, ZVANIE FROM POSL_SPI.DBF WHERE KEY_POSL = " + id + " AND ZVANIE NOT IN (77,94,95,96,97,98) ORDER BY DATA_OT";
				DataAdapter.Fill(vyslugaDataSet,"Table");
				rc = vyslugaDataSet.Tables["Table"].Rows;

				TPeriod ovd = new TPeriod();
				bool isOvd = false;

				DateTime cur_date = new DateTime();
				DateTime prev_date = new DateTime();
                //int i = 0;

                //do
                //{                    
                // cur_date = Convert.ToDateTime(rc[i]["DATA_OT"]);
                // prev_date = Convert.ToDateTime(rc[i]["DATA_OT"]);
                // string status = "";
                // status = rc[i]["STATUS"].ToString();
                // if (status == "4000" || status == "5000" || status == "7000")
                //        {
                //            DateTime stop = Convert.ToDateTime(rc[i]["DATA_OT"]);
                //        }
                //        ovd.Add(CalcStag(begin, stop));
                //    }

                //    last.Add(CalcStag(Convert.ToDateTime(rc[rc.Count-1]["DATA_OT"]),today));

                //    ovd.Add(last);
					
                //    day_ovd.Text = ovd.d.ToString();
                //    month_ovd.Text = ovd.m.ToString();
                //    year_ovd.Text = ovd.y.ToString();
                //    isOvd = true;
                //} while ( i < rc.Count);

				rc.Clear();

				
				
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
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.vyslugaDataSet = new UK.vyslugaDataSet();
			((System.ComponentModel.ISupportInitialize)(this.vyslugaDataSet)).BeginInit();
			// 
			// Command
			// 
			this.Command.CommandText = "SELECT ARMY_BEGIN, ARMY_STOP FROM VUCHET WHERE KEY_1 = 11184";
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase IV;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;Drive" +
				"rId=277";
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// vyslugaDataSet
			// 
			this.vyslugaDataSet.DataSetName = "vyslugaDataSet";
			this.vyslugaDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.vyslugaDataSet)).EndInit();

		}
		#endregion
	}
}
