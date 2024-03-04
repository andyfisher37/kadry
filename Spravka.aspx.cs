using System;
using System.Data;

namespace UK
{
	/// <summary>
	/// Summary description for Spravka.
	/// </summary>
	public partial class Spravka : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcConnection Connection;
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

                // Проверка на право доступа...
                if (!s.CheckSecurePage(User.Identity.Name, "spravka.aspx")) Response.Redirect("AccessDenied.htm", true);

				int id = Convert.ToInt16(Request.QueryString["id"]);
                
                // Проверка на действ. и уволенн.
                Command.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, DATA_POST, REAL_DOLZN FROM AAQQ WHERE FAMILIYA <> '' AND KEY_1 = " + id.ToString();
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(resDataSet);
                rc = resDataSet.Tables[0].Rows;
                if (rc.Count > 0)
                {
                    if (Convert.ToDecimal(rc[0]["REAL_DOLZN"]) < 800000) status.Text = " проходит службу ";
                    else status.Text = " работает ";
                    DataPost.Text = Convert.ToDateTime(rc[0]["DATA_POST"]).ToShortDateString() + " г. ";
                    DataEnd.Text = "настоящее время";
                }
                else
                {
                    resDataSet.Clear();
                    rc.Clear();
                    Command.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, DATA_POST, DATA_UVOL, REAL_DOLZN, DATA_PR_UV, NOM_PR_UVO, SLVPRU.P1 AS PRUV, SLVPR2.P3, SLVSTU.P1 AS STUV FROM ARCHIVE, SLVPR2, SLVPRU, SLVSTU WHERE SLVSTU.P2 = ST_UV AND SLVPRU.P2 = PRICH_UV AND SLVPR2.P2 = KTO_UVOLIL AND FAMILIYA <> '' AND KEY_1 = " + id.ToString();
                    DataAdapter.SelectCommand = Command;
                    DataAdapter.Fill(resDataSet);
                    rc = resDataSet.Tables[0].Rows;
                    if (rc.Count > 0)
                    {
                        if (Convert.ToDecimal(rc[0]["REAL_DOLZN"]) < 800000)
                        {
                            status.Text = " служил(а) ";
                            UvolInfo.Text = "Уволен из органов внутренних дел ";
                        }
                        else
                        {
                            status.Text = " работал(а) ";
                            UvolInfo.Text = "Уволен ";
                        }
                        DataPost.Text = Convert.ToDateTime(rc[0]["DATA_POST"]).ToShortDateString() + " г. ";
                        DataEnd.Text = Convert.ToDateTime(rc[0]["DATA_UVOL"]).ToShortDateString() + " г. ";
                        UvolInfo.Text += Convert.ToDateTime(rc[0]["DATA_UVOL"]).ToShortDateString() +
                                                                            " (Приказ " + rc[0]["P3"].ToString() + " от " +
                                                                            Convert.ToDateTime(rc[0]["DATA_PR_UV"]).ToShortDateString() + " г. №" +
                                                                            rc[0]["NOM_PR_UVO"].ToString() + " л/с) " +
                                                                            rc[0]["PRUV"].ToString() + " (ст." + rc[0]["STUV"].ToString() + ").";
                    }
                    else
                    {
                        resDataSet.Clear();
                        rc.Clear();
                        Command.CommandText = "SELECT RES.FAMILIYA, RES.IMYA, RES.OTCHECTVO, RES.DATA_ROZD, RES.REAL_DOLZN, RES.DATA_ZACH, RES.DATA_POST, RES.DATA_PR_UV, RES.NOM_PR_UVO, RES.PRIMECHAN, SLVPR2.P3 FROM RESERV RES, SLVPR2 WHERE SLVPR2.P2 = KTO_ZACHIS AND FAMILIYA <> '' AND KEY_1 = " + id.ToString();
                        DataAdapter.SelectCommand = Command;
                        DataAdapter.Fill(resDataSet);
                        rc = resDataSet.Tables[0].Rows;
                        if (rc.Count > 0)
                        {
                            if (Convert.ToDecimal(rc[0]["REAL_DOLZN"]) < 800000)
                            {
                                status.Text = " служит ";
                                UvolInfo.Text = "С " + Convert.ToDateTime(rc[0]["DATA_ZACH"]).ToShortDateString() + " " + GlobalTransform.TransResComment(rc[0]["PRIMECHAN"].ToString());
                            }
                            else
                            {
                                status.Text = " работает ";
                                UvolInfo.Text = "c " + Convert.ToDateTime(rc[0]["DATA_ZACH"]).ToShortDateString() + " " + rc[0]["PRIMECHAN"].ToString();
                            }
                            DataPost.Text = Convert.ToDateTime(rc[0]["DATA_POST"]).ToShortDateString() + " г. ";
                            DataEnd.Text = "настоящее время ";
                            UvolInfo.Text += " Основание: (Приказ " + rc[0]["P3"].ToString() + " от " + Convert.ToDateTime(rc[0]["DATA_PR_UV"]).ToShortDateString() + " г. №" +
                                                                                rc[0]["NOM_PR_UVO"].ToString() + " л/с) ";
                        }
                        else
                        {
                            resDataSet.Clear();
                            rc.Clear();
                            Command.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, REAL_DOLZN, DATA_UVOL, DATA_POST, DATA_PR_UV, NOM_PR_UVO, PRIMECHAN, PLACE, SLVPR2.P3 FROM VYEZD, SLVPR2 WHERE SLVPR2.P2 = KTO_UVOLIL AND FAMILIYA <> '' AND KEY_1 = " + id.ToString();
                            DataAdapter.SelectCommand = Command;
                            DataAdapter.Fill(resDataSet);
                            rc = resDataSet.Tables[0].Rows;
                            if (rc.Count > 0)
                            {
                                if (Convert.ToDecimal(rc[0]["REAL_DOLZN"]) < 800000)
                                {
                                    status.Text = " служил ";
                                    UvolInfo.Text = "С " + Convert.ToDateTime(rc[0]["DATA_UVOL"]).ToShortDateString() + " откомандирован в  " + rc[0]["PLACE"].ToString();
                                }
                                else
                                {
                                    status.Text = " работал ";
                                    UvolInfo.Text = "c " + Convert.ToDateTime(rc[0]["DATA_UVOL"]).ToShortDateString() + " откомандирован в  " + rc[0]["PLACE"].ToString();
                                }
                                DataPost.Text = Convert.ToDateTime(rc[0]["DATA_POST"]).ToShortDateString() + " года";
                                DataEnd.Text = "по " + Convert.ToDateTime(rc[0]["DATA_UVOL"]).ToShortDateString() + " года";
                                UvolInfo.Text += "<br>Основание: (Приказ " + rc[0]["P3"].ToString() + " от " + Convert.ToDateTime(rc[0]["DATA_PR_UV"]).ToShortDateString() + " года №" +
                                                                                    rc[0]["NOM_PR_UVO"].ToString() + " л/с) ";
                            }
                        }
                    }
                }
               
                Name.Text = rc[0]["FAMILIYA"].ToString().ToUpper() + " " + rc[0]["IMYA"].ToString().ToUpper() + " " + rc[0]["OTCHECTVO"].ToString().ToUpper() + ", " + Convert.ToDateTime(rc[0]["DATA_ROZD"]).ToShortDateString() + " года рождения";

                //Response.AddHeader("Content-Disposition", "attachment;inline; filename=" + Name.Text + ".doc");
                //Response.ContentType = "application/msword";

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

                    DataPost.Text += " (Приказ " + rc1[0]["P3"].ToString() + " от " + Convert.ToDateTime(rc1[0]["DATA_PRIK"]).ToShortDateString() + " г. №" + rc1[0]["NOM_PRIK"].ToString() + " л/с)";
                }
                
                s.AddLogText("Справка о прохождении службы: " + Name.Text, Context.Request.UserHostAddress.ToString(), 42, true);
			
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
            this.resDataSet = new UK.resDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.resDataSet)).BeginInit();
			// Command
			// 
			this.Command.CommandText = "";
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;DBQ=" +
				"C:\\KADRY;DriverId=277";
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
