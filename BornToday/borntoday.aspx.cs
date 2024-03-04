using System;

namespace kadry.BornToday
{
	/// <summary>
	/// Summary description for borntoday.
	/// </summary>
	public class borntoday : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected kadry.BornToday.bornDataSet bornDataSet;
        protected kadry.BornToday.bornDataSet bornDataSet2;
		protected System.Web.UI.WebControls.Label TitleText;
		protected System.Web.UI.WebControls.DataGrid Grid;
		protected System.Web.UI.WebControls.Label Count;
        protected System.Web.UI.WebControls.DataGrid Grid2;
        protected System.Web.UI.WebControls.Label Count2;
		protected System.Web.UI.WebControls.Button ThisMonth;
		protected System.Web.UI.WebControls.Button Today;
		protected eWorld.UI.MaskedTextBox Date1;
		protected eWorld.UI.MaskedTextBox Date2;
		protected System.Web.UI.WebControls.Button WithDate;
		protected System.Data.Odbc.OdbcCommand Command;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				kadry.Security.Security s = new kadry.Security.Security();

				s.AddLogText("Открытие страницы Дней Рождений",Context.Request.UserHostAddress,34,true);

				Date1.Text = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString();
				Date2.Text = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString();

				this.Today_Click( sender, e);
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
			this.Connection = new System.Data.Odbc.OdbcConnection();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.bornDataSet = new kadry.BornToday.bornDataSet();
            this.bornDataSet2 = new kadry.BornToday.bornDataSet();
			((System.ComponentModel.ISupportInitialize)(this.bornDataSet)).BeginInit();
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;Driv" +
				"erId=533";
			// 
			// Command
			// 
			this.Command.CommandText = @"SELECT Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, Aaqq.DATA_ROZD FROM Aaqq, PODRAZD, SLUZBA, ZVANIE, OFIC_DOL WHERE Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.ZVANIE = ZVANIE.KEY_ZVAN AND Aaqq.REAL_DOLZN = OFIC_DOL.P3 AND (Aaqq.DATA_ROZD = { d '1970-01-01' })";
			this.Command.Connection = this.Connection;
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// bornDataSet
			// 
			this.bornDataSet.DataSetName = "bornDataSet";
			this.bornDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
            this.bornDataSet2.DataSetName = "bornDataSet2";
            this.bornDataSet2.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.ThisMonth.Click += new System.EventHandler(this.ThisMonth_Click);
			this.Today.Click += new System.EventHandler(this.Today_Click);
			this.WithDate.Click += new System.EventHandler(this.WithDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.bornDataSet)).EndInit();

		}
		#endregion


		public string GetMonth( int m )
		{
			if ( m == 1 ) return "Январе";
			if ( m == 2 ) return "Феврале";
			if ( m == 3 ) return "Марте";
			if ( m == 4 ) return "Апреле";
			if ( m == 5 ) return "Мае";
			if ( m == 6 ) return "Июне";
			if ( m == 7 ) return "Июле";
			if ( m == 8 ) return "Августе";
			if ( m == 9 ) return "Сентябре";
			if ( m == 10 ) return "Октябре";
			if ( m == 11 ) return "Ноябре";
			if ( m == 12 ) return "Декабре";
			else return "";
		}

		private void ThisMonth_Click(object sender, System.EventArgs e)
		{
			TitleText.Text = "В " + GetMonth(DateTime.Now.Month) + " отмечают День Рождение!";
			bornDataSet.Clear();
			Grid.DataBind();
				
			Command.CommandText = "SELECT Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, " +
				"OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, Aaqq.DATA_ROZD " +
				"FROM Aaqq, PODRAZD, SLUZBA, ZVANIE, OFIC_DOL " +
				"WHERE Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND " +
				"Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.ZVANIE = ZVANIE.KEY_ZVAN AND " +
				"Aaqq.REAL_DOLZN = OFIC_DOL.P3 AND Aaqq.FAMILIYA <> '' AND Aaqq.KEY_1 <> 0 AND LICH_NOM_2 <> 'совмещ' ORDER BY Aaqq.FAMILIYA";

			DataAdapter.Fill(bornDataSet);
			int count = bornDataSet.Tables[0].Rows.Count;
				
			foreach( System.Data.DataRow row in bornDataSet.Tables[0].Rows )
			{
				int day   = Convert.ToInt16(((row["DATA_ROZD"]).ToString()).Substring(0,2));
				int month = Convert.ToInt16(((row["DATA_ROZD"]).ToString()).Substring(3,2));

				if ( month != DateTime.Now.Month ) 
				{
					row.Delete();
					count--;
				}
			}

			Grid.DataBind();

			Count.Text = " Итого: " + count.ToString() + " человек(а)";

			bornDataSet.Clear();
		
		}

		private void Today_Click(object sender, System.EventArgs e)
		{
			TitleText.Text = "Сегодня " + DateTime.Now.ToShortDateString() + " отмечают День Рождение!";

			bornDataSet.Clear();
			Grid.DataBind();
				
			Command.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, " +
				"OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, DATA_ROZD " +
				"FROM Aaqq, PODRAZD, SLUZBA, ZVANIE, OFIC_DOL " +
				"WHERE PODRAZD = PODRAZD.KEY_OF_POD AND " +
				"SLUZBA = SLUZBA.KEY_OF_SLU AND ZVANIE = ZVANIE.KEY_ZVAN AND " +
				"REAL_DOLZN = OFIC_DOL.P3 AND FAMILIYA <> '' AND KEY_1 <> 0 AND LICH_NOM_2 <> 'совмещ' ORDER BY FAMILIYA";

			DataAdapter.Fill(bornDataSet);
			int count = bornDataSet.Tables[0].Rows.Count;
				
			foreach( System.Data.DataRow row in bornDataSet.Tables[0].Rows )
			{
				int day   = Convert.ToInt16(((row["DATA_ROZD"]).ToString()).Substring(0,2));
				int month = Convert.ToInt16(((row["DATA_ROZD"]).ToString()).Substring(3,2));

				if ( day != DateTime.Now.Day || month != DateTime.Now.Month ) 
				{
					row.Delete();
					count--;
				}
			}

			Count.Text = " Итого: " + count.ToString() + " человек(а)";

			Grid.DataBind();
			bornDataSet.Clear();

            // Уволенные...
            bornDataSet2.Clear();
            Grid2.DataBind();

            Command.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, " +
                "OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, DATA_ROZD " +
                "FROM ARCHIVE, PODRAZD, SLUZBA, ZVANIE, OFIC_DOL " +
                "WHERE PODRAZD = KEY_OF_POD AND " +
                "SLUZBA = SLUZBA.KEY_OF_SLU AND ZVANIE = KEY_ZVAN AND " +
                "REAL_DOLZN = OFIC_DOL.P3 AND FAMILIYA <> '' AND KEY_1 <> 0 AND DATA_ROZD IS NOT NULL AND LICH_NOM_2 <> 'совмещ' ORDER BY FAMILIYA";

            DataAdapter.Fill(bornDataSet2);
            int count2 = bornDataSet2.Tables[0].Rows.Count;

            foreach (System.Data.DataRow row in bornDataSet2.Tables[0].Rows)
            {
                int day = Convert.ToInt16(((row["DATA_ROZD"]).ToString()).Substring(0, 2));
                int month = Convert.ToInt16(((row["DATA_ROZD"]).ToString()).Substring(3, 2));

                if (day != DateTime.Now.Day || month != DateTime.Now.Month)
                {
                    row.Delete();
                    count2--;
                }
            }

            Count2.Text = " Итого: " + count2.ToString() + " человек(а)";

            Grid2.DataBind();
            bornDataSet2.Clear();
		}

		private void WithDate_Click(object sender, System.EventArgs e)
		{
			TitleText.Text = "c " + Date1.Text + " по " + Date2.Text + " отмечают День Рождение!";
			bornDataSet.Clear();
			Grid.DataBind();
				
			Command.CommandText = "SELECT FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, " +
				"OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, Aaqq.DATA_ROZD " +
				"FROM Aaqq, PODRAZD, SLUZBA, ZVANIE, OFIC_DOL " +
				"WHERE Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND " +
				"Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.ZVANIE = ZVANIE.KEY_ZVAN AND " +
				"Aaqq.REAL_DOLZN = OFIC_DOL.P3 AND Aaqq.FAMILIYA <> '' AND Aaqq.KEY_1 <> 0 AND LICH_NOM_2 <> 'совмещ' ORDER BY Aaqq.FAMILIYA";

			DataAdapter.Fill(bornDataSet);
			int count = bornDataSet.Tables[0].Rows.Count;
			
			foreach( System.Data.DataRow row in bornDataSet.Tables[0].Rows )
			{
				int month = Convert.ToInt16(((row["DATA_ROZD"]).ToString()).Substring(3,2));
				int mX1 = Convert.ToInt16(Date1.Text.Substring(3,2));
				int mX2 = Convert.ToInt16(Date2.Text.Substring(3,2));
				int day   = Convert.ToInt16(((row["DATA_ROZD"]).ToString()).Substring(0,2));
				int dX1 = Convert.ToInt16(Date1.Text.Substring(0,2));
				int dX2 = Convert.ToInt16(Date2.Text.Substring(0,2));

				if ( (month < mX1  ||  month > mX2 ) || ( day < dX1  ||  day > dX2 )) 
				{
					row.Delete();
					count--;
				}
			
			}

			Grid.DataBind();

			Count.Text = " Итого: " + count.ToString() + " человек(а)";

			bornDataSet.Clear();

            // Уволенные...
            bornDataSet2.Clear();
            Grid2.DataBind();

            Command.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, " +
                "OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, DATA_ROZD " +
                "FROM ARCHIVE, PODRAZD, SLUZBA, ZVANIE, OFIC_DOL " +
                "WHERE ARCHIVE.PODRAZD = PODRAZD.KEY_OF_POD AND " +
                "ARCHIVE.SLUZBA = SLUZBA.KEY_OF_SLU AND ARCHIVE.ZVANIE = ZVANIE.KEY_ZVAN AND " +
                "ARCHIVE.REAL_DOLZN = OFIC_DOL.P3 AND ARCHIVE.FAMILIYA <> '' AND DATA_ROZD IS NOT NULL AND ARCHIVE.KEY_1 <> 0 AND LICH_NOM_2 <> 'совмещ' ORDER BY ARCHIVE.FAMILIYA";

            DataAdapter.Fill(bornDataSet2);
            int count2 = bornDataSet2.Tables[0].Rows.Count;

            foreach (System.Data.DataRow row in bornDataSet2.Tables[0].Rows)
            {
                int month = Convert.ToInt16(((row["DATA_ROZD"]).ToString()).Substring(3, 2));
                int mX1 = Convert.ToInt16(Date1.Text.Substring(3, 2));
                int mX2 = Convert.ToInt16(Date2.Text.Substring(3, 2));
                int day = Convert.ToInt16(((row["DATA_ROZD"]).ToString()).Substring(0, 2));
                int dX1 = Convert.ToInt16(Date1.Text.Substring(0, 2));
                int dX2 = Convert.ToInt16(Date2.Text.Substring(0, 2));

                if ((month < mX1 || month > mX2) || (day < dX1 || day > dX2))
                {
                    row.Delete();
                    count2--;
                }

            }

            Grid2.DataBind();

            Count2.Text = " Итого: " + count2.ToString() + " человек(а)";

            bornDataSet2.Clear();
			
		}
	}
}
