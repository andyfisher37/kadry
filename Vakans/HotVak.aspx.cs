using System;

namespace kadry.Vakans
{
	/// <summary>
	/// Summary description for HotVak.
	/// </summary>
	public partial class HotVak : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcCommand Command;
		protected kadry.Vakans.hotvakDataSet hotvakDataSet;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Command.CommandText = "SELECT PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, SLVISOD.`TEXT`, Aaqq.DATA_VAK FROM Aaqq, PODRAZD, SLUZBA, OFIC_DOL, SLVISOD WHERE Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.DOLZNOST = OFIC_DOL.P3 AND Aaqq.IST_SOD = SLVISOD.CODE AND (Aaqq.FAMILIYA IS NULL) AND (Aaqq.DATA_SOKR IS NULL) AND (Aaqq.DATA_VAK IS NOT NULL) AND (Aaqq.DOLZNOST < '800000') AND IST_SOD NOT IN (1,5,15,21,97) ORDER BY Aaqq.DATA_VAK, PODRAZD";
			DataAdapter.Fill(hotvakDataSet);
			int count = hotvakDataSet.Tables[0].Rows.Count;
			//for( int i = 50; i < count; i++ )
			//{
			//	hotvakDataSet.Tables[0].Rows[i].Delete();
			//}
			Grid.DataBind();
			for( int i = 0; i < 50; i++ )
			{
				Grid.Items[i].Cells[0].Text = (i+1).ToString();
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
			this.hotvakDataSet = new kadry.Vakans.hotvakDataSet();
			((System.ComponentModel.ISupportInitialize)(this.hotvakDataSet)).BeginInit();
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "PageTimeout=0;FIL=dBase 5.0;MaxBufferSize=2048;DSN=KADRY;DefaultDir=C:\\KADRY;DBQ=" +
				"C:\\KADRY;DriverId=277";
			// 
			// Command
			// 
			this.Command.CommandText = @"SELECT PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, SLVISOD.`TEXT`, Aaqq.DATA_VAK FROM Aaqq, PODRAZD, SLUZBA, OFIC_DOL, SLVISOD WHERE Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.DOLZNOST = OFIC_DOL.P3 AND Aaqq.IST_SOD = SLVISOD.CODE AND (Aaqq.FAMILIYA IS NULL) AND (Aaqq.DATA_SOKR IS NULL) AND (Aaqq.DATA_VAK IS NOT NULL) AND (Aaqq.DOLZNOST < '800000') ORDER BY Aaqq.DATA_VAK";
			this.Command.Connection = this.Connection;
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// hotvakDataSet
			// 
			this.hotvakDataSet.DataSetName = "hotvakDataSet";
			this.hotvakDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.hotvakDataSet)).EndInit();

		}
		#endregion
	}
}
