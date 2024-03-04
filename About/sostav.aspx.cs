using System;

namespace kadry.About
{
	/// <summary>
	/// Summary description for sostav.
	/// </summary>
	public partial class sostav : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected kadry.About.kadryDataSet kadryDataSet;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcConnection Conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				Security.Security s = new Security.Security();
				s.AddLogText("Просмотр личного состава УРЛС УВД",Context.Request.UserHostAddress,21,true);
			
				kadryDataSet.Clear();
				Command.CommandText = "SELECT OFIC_DOL.NAM_OF_DOL, Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, ZVANIE.VOIN_ZVAN, Aaqq.DATA_ROZD, photos.PHOTO, Aaqq.KEY_1 FROM Aaqq, OFIC_DOL, ZVANIE, photos WHERE Aaqq.REAL_DOLZN = OFIC_DOL.P3 AND Aaqq.ZVANIE = ZVANIE.KEY_ZVAN AND Aaqq.KEY_1 = photos.KEY_1 AND (Aaqq.PODRAZD = 583) AND (Aaqq.SLUZBA = 4) AND (Aaqq.FAMILIYA <> '') ORDER BY Aaqq.PODRAZD, Aaqq.PODR, Aaqq.UPRAVLENIE, Aaqq.OTDEL, Aaqq.PODOTDEL, Aaqq.OTDELENIE, Aaqq.GRUP, Aaqq.DOLZNOST";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(kadryDataSet);
				         				
				Grid.DataBind();

				for( int i=0; i<kadryDataSet.Aaqq.Rows.Count; i++)
				{
					Grid.Items[i].Cells[5].Text = "<img width=40px heigth = 10px src='../PhotoBank/" + kadryDataSet.Aaqq.Rows[i]["PHOTO"].ToString() + "'/>";
					//Grid.Items[i].Cells[1].Text = "<a href='..\\DetailPage.aspx?id=" + kadryDataSet.Aaqq.Rows[i]["KEY_1"].ToString() + "'>" + kadryDataSet.Aaqq.Rows[i]["FAMILIYA"].ToString() + "</a>";
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
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.Conn = new System.Data.Odbc.OdbcConnection();
			this.kadryDataSet = new kadry.About.kadryDataSet();
			((System.ComponentModel.ISupportInitialize)(this.kadryDataSet)).BeginInit();
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			this.DataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "Aaqq", new System.Data.Common.DataColumnMapping[] {
																																																		  new System.Data.Common.DataColumnMapping("NAM_OF_DOL", "NAM_OF_DOL"),
																																																		  new System.Data.Common.DataColumnMapping("FAMILIYA", "FAMILIYA"),
																																																		  new System.Data.Common.DataColumnMapping("IMYA", "IMYA"),
																																																		  new System.Data.Common.DataColumnMapping("OTCHECTVO", "OTCHECTVO"),
																																																		  new System.Data.Common.DataColumnMapping("VOIN_ZVAN", "VOIN_ZVAN"),
																																																		  new System.Data.Common.DataColumnMapping("DATA_ROZD", "DATA_ROZD"),
																																																		  new System.Data.Common.DataColumnMapping("PHOTO", "PHOTO")})});
			// 
			// Command
			// 
			this.Command.CommandText = @"SELECT OFIC_DOL.NAM_OF_DOL, Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, ZVANIE.VOIN_ZVAN, Aaqq.DATA_ROZD, photos.PHOTO, Aaqq.KEY_1 FROM Aaqq, OFIC_DOL, ZVANIE, photos WHERE Aaqq.REAL_DOLZN = OFIC_DOL.P3 AND Aaqq.ZVANIE = ZVANIE.KEY_ZVAN AND Aaqq.KEY_1 = photos.KEY_1 AND (Aaqq.PODRAZD = 1) AND (Aaqq.SLUZBA = 4) AND (Aaqq.FAMILIYA <> '') ORDER BY Aaqq.PODRAZD, Aaqq.PODR, Aaqq.UPRAVLENIE, Aaqq.OTDEL, Aaqq.PODOTDEL, Aaqq.OTDELENIE, Aaqq.GRUP, Aaqq.DOLZNOST";
			this.Command.Connection = this.Conn;
			// 
			// Conn
			// 
			this.Conn.ConnectionString = "MaxBufferSize=2048;FIL=dBase IV;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;Drive" +
				"rId=277";
			// 
			// kadryDataSet
			// 
			this.kadryDataSet.DataSetName = "kadryDataSet";
			this.kadryDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.kadryDataSet)).EndInit();

		}
		#endregion
	}
}
