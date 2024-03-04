using System;
using System.Data;

namespace kadry.Discipline
{
	/// <summary>
	/// Summary description for BadPoo.
	/// </summary>
	public partial class BadPoo : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected System.Web.UI.WebControls.Table Table1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				Info.Text = "По состоянию на " + System.DateTime.Now.ToShortDateString() + " г.";

				System.Data.DataSet ds = new DataSet();
				System.Data.DataRowCollection rc;
				//System.Data.DataRowCollection tc;

				Command.CommandText = "SELECT KEY_1, FAMILIYA, IMYA, OTCHECTVO, PODRAZDEL FROM AAQQ, NAKAZAN, PODRAZD WHERE AAQQ.KEY_1 = NAKAZAN.KEY_1 AND NAKAZAN.DAT_SNIAT IS NULL AND PODRAZD.KEY_OF_POD = AAQQ.PODRAZD";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(ds);

				rc = ds.Tables[0].Rows;

				for( int i = 0; i < rc.Count; i++ )
				{
					ds.Clear();
					Command.CommandText = "SELECT POO.DATA_POO, POO.NOM_PRIK, SLVPR2.P1, SLVPOO.P1 AS Expr1, POO.PRICHINA FROM POO, SLVPR2, SLVPOO WHERE POO.CHEI_PRIK = SLVPR2.P2 AND POO.TYPE_POO = SLVPOO.P2 AND KEY_POO = " + 
										  rc[i]["KEY_1"].ToString() + " AND " +
										  "POO.DATA_POO >= ";
					DataAdapter.SelectCommand = Command;
					DataAdapter.Fill(ds);
					




				}


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
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;DBQ=" +
				"C:\\KADRY;DriverId=277";
			// 
			// Command
			// 
			this.Command.Connection = this.Connection;
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;

		}
		#endregion
	}
}
