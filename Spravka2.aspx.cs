using System;
using System.Data;

namespace UK
{
	/// <summary>
	/// Summary description for Spravka2.
	/// </summary>
	public partial class Spravka2 : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected UK.resDataSet resDataSet;
        
		public System.Data.DataRowCollection rc;
        public System.Data.DataRowCollection rc1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				Security.Security s = new Security.Security();

                string curIP = Convert.ToString(Context.Request.UserHostAddress);

                // ѕроверка на право доступа...
                if (!s.CheckSecurePage(User.Identity.Name, "spravka2.aspx")) Response.Redirect("AccessDenied.htm", true);
                												
				int id = Convert.ToInt16(Request.QueryString["id"]);

				// ѕроверка на действ. и уволенн.
                Command.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, DATA_POST FROM AAQQ WHERE DOLZNOST < '800000' AND FAMILIYA <> '' AND KEY_1 = " + id.ToString();
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(resDataSet);
				rc = resDataSet.Tables[0].Rows;
                if (rc.Count > 0)
                {
                    status.Text = "проходит";
                    Weapon.Text = "имеет право на ношение и хранение табельного огнестрельного оружи€ и специальных средств.";
                    DataPost.Text = Convert.ToDateTime(rc[0]["DATA_POST"]).ToShortDateString() + " г. ";
                    DataEnd.Text = "насто€щее врем€";
                }
                else
                {
                    resDataSet.Clear();
                    rc.Clear();
                    Command.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, DATA_POST, DATA_UVOL, DATA_PR_UV, NOM_PR_UVO, SLVPRU.P1 AS PRUV, SLVPR2.P3, SLVSTU.P1 AS STUV FROM ARCHIVE, SLVPR2, SLVPRU, SLVSTU WHERE SLVSTU.P2 = ST_UV AND SLVPRU.P2 = PRICH_UV AND SLVPR2.P2 = KTO_UVOLIL AND DOLZNOST < '800000' AND FAMILIYA <> '' AND KEY_1 = " + id.ToString();
                    DataAdapter.SelectCommand = Command;
                    DataAdapter.Fill(resDataSet);
                    rc = resDataSet.Tables[0].Rows;
                    if (rc.Count > 0)
                    {
                        status.Text = "проходил";
                        Weapon.Text = "во врем€ службы имел право на ношение и хранение табельного огнестрельного оружи€ и специальных средств.";
                        DataPost.Text = Convert.ToDateTime(rc[0]["DATA_POST"]).ToShortDateString() + " г. ";
                        DataEnd.Text = Convert.ToDateTime(rc[0]["DATA_UVOL"]).ToShortDateString() + " г. ";
                        UvolText.Text = "”волен из органов внутренних дел с " + Convert.ToDateTime(rc[0]["DATA_UVOL"]).ToShortDateString() +
                                                                            " г. (ѕриказ " + rc[0]["P3"].ToString() + " от " +
                                                                            Convert.ToDateTime(rc[0]["DATA_PR_UV"]).ToShortDateString() + " г. є" + 
                                                                            rc[0]["NOM_PR_UVO"].ToString() + " л/с) " + 
                                                                            rc[0]["PRUV"].ToString() + " (ст." + rc[0]["STUV"].ToString() + ").";
                    }
                }

                FIO.Text = rc[0]["FAMILIYA"].ToString().ToUpper() + " " + rc[0]["IMYA"].ToString().ToUpper() + " " + rc[0]["OTCHECTVO"].ToString().ToUpper() + ", " + Convert.ToDateTime(rc[0]["DATA_ROZD"]).ToShortDateString() + " года рождени€";
                Name2.Text = rc[0]["FAMILIYA"].ToString().ToUpper() + " " + rc[0]["IMYA"].ToString().Substring(0, 1).ToUpper() + "." + rc[0]["OTCHECTVO"].ToString().Substring(0, 1).ToUpper() + ".";

                DataSet ds = new DataSet();
                Command.CommandText = "SELECT DATA_OT, NOM_PRIK, P3, DATA_PRIK FROM POSL_SPI, SLVPR2 WHERE P2 = CHEI_PRIK AND DATA_OT = " + Convert.ToDateTime(rc[0]["DATA_POST"]).ToOADate() + " AND KEY_POSL = " + id.ToString();
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                rc1 = ds.Tables[0].Rows;

                string dprik = "";

                if (rc1.Count > 0)
                {
                    if (rc1[0]["DATA_PRIK"] != DBNull.Value) dprik = Convert.ToDateTime(rc1[0]["DATA_PRIK"]).ToShortDateString();
                    else dprik = Convert.ToDateTime(rc1[0]["DATA_OT"]).ToShortDateString();

                    DataPost.Text += " (ѕриказ " + rc1[0]["P3"].ToString() + " от " + dprik + " г. є" + rc1[0]["NOM_PRIK"].ToString() + " л/с)";
                }

                //if (status.Text == "проходит") DataEnd.Text = "насто€щее врем€";
                //else DataEnd.Text = Convert.ToDateTime(rc[0]["DATA_UVOL"]).ToShortDateString() + " г."; 

                //s.AddLogText("—правка дл€ лицензии на оружие: " + FIO.Text, Context.Request.UserHostAddress.ToString(), 45, true);
			
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
			this.resDataSet = new UK.resDataSet();
			((System.ComponentModel.ISupportInitialize)(this.resDataSet)).BeginInit();
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;DBQ=" +
				"C:\\KADRY;DriverId=277";
			// 
			// Command
			// 
			this.Command.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, DATA_POST FROM AAQQ";
			this.Command.Connection = this.Connection;
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// resDataSet
			// 
			this.resDataSet.DataSetName = "resDataSet";
			this.resDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.resDataSet)).EndInit();

		}
		#endregion
	}
}
