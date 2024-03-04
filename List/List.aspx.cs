using System;
using System.Data;
using System.Web.Caching;

namespace kadry.List
{
	/// <summary>
	/// Summary description for List.
	/// </summary>
	public partial class List : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected kadry.List.catDataSet catDataSet;
		protected kadry.List.viewDataSet viewDataSet;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				Command.CommandText = "SELECT TEXT_QRY, NAME_FORM FROM group1K";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(catDataSet);
				catList.DataBind();
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
			this.catDataSet = new kadry.List.catDataSet();
			this.viewDataSet = new kadry.List.viewDataSet();
			((System.ComponentModel.ISupportInitialize)(this.catDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.viewDataSet)).BeginInit();
			// 
			// Command
			// 
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
			// catDataSet
			// 
			this.catDataSet.DataSetName = "catDataSet";
			this.catDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// viewDataSet
			// 
			this.viewDataSet.DataSetName = "viewDataSet";
			this.viewDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.catDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.viewDataSet)).EndInit();

		}
		#endregion

		protected void BtnList_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			viewDataSet.Clear();
			
			Command.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ " + catList.SelectedItem.Value + " AND DATA_SOKR IS NULL ";
			if ( Connection.State != ConnectionState.Open) Connection.Open();
			int st = (int)Command.ExecuteScalar();

			Command.CommandText = "SELECT PODRAZD, PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, ZVANIE.VOIN_ZVAN, Aaqq.DATA_ROZD, SLVLE2.P1, Aaqq.OBRAZ_LIC1, Aaqq.DATA_POST, Aaqq.DATA_VDOLZ FROM Aaqq, PODRAZD, SLUZBA, OFIC_DOL, ZVANIE, SLVLE2 WHERE Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.REAL_DOLZN = OFIC_DOL.P3 AND Aaqq.ZVANIE = ZVANIE.KEY_ZVAN AND Aaqq.OBRAZ_LIC2 = SLVLE2.P2 AND FAMILIYA <> ''";
			Command.CommandText += " AND " + catList.SelectedItem.Value.Remove(0,5);
			Command.CommandText += " ORDER BY PODRAZD";
			DataAdapter.SelectCommand = Command;
			DataAdapter.Fill(viewDataSet);
			
			string title = "Список личного состава по категории:|" + catList.SelectedItem.Text + "|по состоянию на " + System.DateTime.Now.ToShortDateString();
			int count = viewDataSet.Tables[0].Rows.Count;

			Cache.Remove("listdata");
			Cache.Add("listdata", viewDataSet, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null );
            
			Response.Redirect("viewlist.aspx?title="+title+"&st=" + st.ToString() + "&count="+count.ToString());
            
		}
	}
}
