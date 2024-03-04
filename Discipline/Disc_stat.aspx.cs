using System;

namespace kadry.Discipline
{
	/// <summary>
	/// Summary description for Disc_stat.
	/// </summary>
	public class Disc_stat : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcCommand Command;
		protected kadry.Discipline.stat_sl_DataSet stat_sl_DataSet;
		protected System.Web.UI.WebControls.ImageButton pooBtn;
		protected System.Web.UI.WebControls.DataGrid Grid1;
		protected System.Web.UI.WebControls.DataGrid Grid2;
		protected System.Web.UI.WebControls.DataGrid Grid3;
		protected System.Web.UI.WebControls.DataGrid Grid4;
		protected kadry.Discipline.stat_pdr_DataSet stat_pdr_DataSet;
		protected eWorld.UI.MaskedTextBox Date1;
		protected eWorld.UI.MaskedTextBox Date2;
		protected System.Web.UI.WebControls.Label FindLabel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				// Устанавливаем период
				System.DateTime tmp = System.DateTime.Now.Subtract(System.TimeSpan.FromDays(365));
				Date1.Text = tmp.ToShortDateString();
				Date2.Text = System.DateTime.Now.ToShortDateString();
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
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.Connection = new System.Data.Odbc.OdbcConnection();
			this.stat_sl_DataSet = new kadry.Discipline.stat_sl_DataSet();
			this.stat_pdr_DataSet = new kadry.Discipline.stat_pdr_DataSet();
			((System.ComponentModel.ISupportInitialize)(this.stat_sl_DataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stat_pdr_DataSet)).BeginInit();
			this.pooBtn.Click += new System.Web.UI.ImageClickEventHandler(this.pooBtn_Click);
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			this.DataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[0])});
			// 
			// Command
			// 
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase IV;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;Drive" +
				"rId=277";
			// 
			// stat_sl_DataSet
			// 
			this.stat_sl_DataSet.DataSetName = "stat_sl_DataSet";
			this.stat_sl_DataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// stat_pdr_DataSet
			// 
			this.stat_pdr_DataSet.DataSetName = "stat_pdr_DataSet";
			this.stat_pdr_DataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.stat_sl_DataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stat_pdr_DataSet)).EndInit();

		}
		#endregion

		private void pooBtn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{

			// Таблица - 1
			Command.CommandText = "SELECT COUNT(sluzba.NAM_OF_SLU) As Expr1, sluzba.NAM_OF_SLU " +
				"FROM Aaqq.dbf aaqq, NAKAZAN.dbf nakazan, SLUZBA.dbf sluzba " +
				"WHERE (aaqq.KEY_1 = nakazan.KEY_1) AND (aaqq.SLUZBA = sluzba.KEY_OF_SLU) AND " +
				"(aaqq.DOLZNOST < '800000') AND (aaqq.FAMILIYA <> '') AND " +
				"(nakazan.DAT_NALOZ >= " + Convert.ToDateTime(Date1.Text).ToOADate() + " AND nakazan.DAT_NALOZ <= " + Convert.ToDateTime(Date2.Text).ToOADate() + ") " + 
				"GROUP BY sluzba.NAM_OF_SLU ORDER BY COUNT(sluzba.NAM_OF_SLU) DESC";
			
			DataAdapter.Fill(stat_sl_DataSet,"SLUZBA");
			int sum = 0;
			for(int i=0; i<stat_sl_DataSet.Tables["SLUZBA"].Rows.Count; i++)
			{
				sum += Convert.ToInt16(stat_sl_DataSet.Tables["SLUZBA"].Rows[i]["Expr1"]);
			}
			object[] row1 = {sum,"Итого:"};
			stat_sl_DataSet.Tables["SLUZBA"].Rows.Add(row1);
			Grid1.DataBind();
			for(int i=0; i<stat_sl_DataSet.Tables["SLUZBA"].Rows.Count-1; i++)
			{
				Grid1.Items[i].Cells[0].Text = Convert.ToString(i+1);
			}
			
			// Таблица - 2
			Command.CommandText = "SELECT COUNT(sluzba.NAM_OF_SLU) As Expr1, sluzba.NAM_OF_SLU " +
				"FROM Aaqq.dbf aaqq, Poo.dbf poo, SLUZBA.dbf sluzba " +
				"WHERE (aaqq.KEY_1 = poo.KEY_POO) AND (aaqq.SLUZBA = sluzba.KEY_OF_SLU) AND " +
				"(aaqq.DOLZNOST < '800000') AND (aaqq.FAMILIYA <> '') AND " +
				"(poo.DATA_POO >= " + Convert.ToDateTime(Date1.Text).ToOADate() + " AND poo.DATA_POO <= " + Convert.ToDateTime(Date2.Text).ToOADate() + ") " +
				"GROUP BY sluzba.NAM_OF_SLU ORDER BY COUNT(sluzba.NAM_OF_SLU) DESC";

			stat_sl_DataSet.Clear();
			DataAdapter.Fill(stat_sl_DataSet,"SLUZBA");
			sum = 0;
			for(int i=0; i<stat_sl_DataSet.Tables["SLUZBA"].Rows.Count; i++)
			{
				sum += Convert.ToInt16(stat_sl_DataSet.Tables["SLUZBA"].Rows[i]["Expr1"]);
			}
			object[] row2 = {sum,"Итого:"};
			stat_sl_DataSet.Tables["SLUZBA"].Rows.Add(row2);
			Grid2.DataBind();
			for(int i=0; i<stat_sl_DataSet.Tables["SLUZBA"].Rows.Count-1; i++)
			{
				Grid2.Items[i].Cells[0].Text = Convert.ToString(i+1);
			}

			// Таблица - 3
			Command.CommandText = "SELECT COUNT(podr.PODRAZDEL) As Expr1, podr.PODRAZDEL " +
				"FROM Aaqq.dbf aaqq, NAKAZAN.dbf nak, PODRAZD.dbf podr " +
				"WHERE (aaqq.KEY_1 = nak.KEY_1) AND (aaqq.PODRAZD = podr.KEY_OF_POD) AND " +
				"(aaqq.DOLZNOST < '800000') AND (aaqq.FAMILIYA <> '') AND " +
				"(nak.DAT_NALOZ >= " + Convert.ToDateTime(Date1.Text).ToOADate() + " AND nak.DAT_NALOZ <= " + Convert.ToDateTime(Date2.Text).ToOADate() + ") " +
				"GROUP BY podr.PODRAZDEL ORDER BY COUNT(podr.PODRAZDEL) DESC";

			stat_pdr_DataSet.Clear();
			DataAdapter.Fill(stat_pdr_DataSet,"PODRAZD");

			sum = 0;
			for(int i=0; i<stat_pdr_DataSet.Tables["PODRAZD"].Rows.Count; i++)
			{
				sum += Convert.ToInt16(stat_pdr_DataSet.Tables["PODRAZD"].Rows[i]["Expr1"]);
			}
			object[] row3 = {sum,"Итого:"};
			stat_pdr_DataSet.Tables["PODRAZD"].Rows.Add(row3);
			Grid3.DataBind();
			for(int i=0; i<stat_pdr_DataSet.Tables["PODRAZD"].Rows.Count-1; i++)
			{
				Grid3.Items[i].Cells[0].Text = Convert.ToString(i+1);
			}

			// Таблица - 4
			Command.CommandText = "SELECT COUNT(podr.PODRAZDEL) As Expr1, podr.PODRAZDEL " +
				"FROM Aaqq.dbf aaqq, POO.dbf poo, PODRAZD.dbf podr " +
				"WHERE (aaqq.KEY_1 = poo.KEY_POO) AND (aaqq.PODRAZD = podr.KEY_OF_POD) AND " +
				"(aaqq.DOLZNOST < '800000') AND (aaqq.FAMILIYA <> '') AND " +
				"(poo.DATA_POO >= " + Convert.ToDateTime(Date1.Text).ToOADate() + " AND poo.DATA_POO <= " + Convert.ToDateTime(Date2.Text).ToOADate() + ") " +
				"GROUP BY podr.PODRAZDEL ORDER BY COUNT(podr.PODRAZDEL) DESC";

			stat_pdr_DataSet.Clear();
			DataAdapter.Fill(stat_pdr_DataSet,"PODRAZD");
			sum = 0;
			for(int i=0; i<stat_pdr_DataSet.Tables["PODRAZD"].Rows.Count; i++)
			{
				sum += Convert.ToInt16(stat_pdr_DataSet.Tables["PODRAZD"].Rows[i]["Expr1"]);
			}
			object[] row4 = {sum,"Итого:"};
			stat_pdr_DataSet.Tables["PODRAZD"].Rows.Add(row4);
			Grid4.DataBind();
			for(int i=0; i<stat_pdr_DataSet.Tables["PODRAZD"].Rows.Count-1; i++)
			{
				Grid4.Items[i].Cells[0].Text = Convert.ToString(i+1);
			}

            //kadry.Security.Security s = new kadry.Security.Security();
            //s.AddLogText("Просмотр статистики по дисциплине за период:["+ Date1.Text+"]-["+ Date2.Text+"]",Request.UserHostAddress.ToString(),17,true);
		}
	}
}
