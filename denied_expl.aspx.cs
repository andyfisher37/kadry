using System;
using System.Data;

namespace kadry
{
	/// <summary>
	/// Summary description for denied_expl.
	/// </summary>
	public partial class denied_expl : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcCommand Command;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				UserName.Text = Request.QueryString["User"];

				DataSet dataset = new DataSet();
				DataRowCollection rc;
                
				if (Request.QueryString.Count == 1)
				{
					Security.Security s = new kadry.Security.Security();
					string secure_sluzb = s.GetSecureSluzb(Request.QueryString["User"]);
					string secure_podrazd = s.GetSecurePodrazd(Request.QueryString["User"]);
					string secure_podr = s.GetSecurePodr(Request.QueryString["User"]);

					if (secure_sluzb != "")
					{
						Command.CommandText = "SELECT NAM_OF_SLU FROM SLUZBA.DBF WHERE KEY_OF_SLU IN (" + secure_sluzb + ") ";
						DataAdapter.Fill(dataset);
						rc = dataset.Tables[0].Rows;
					
						for( int i=0; i<rc.Count; i++)
						{
							sl_label.Text += rc[i]["NAM_OF_SLU"].ToString();
							sl_label.Text += ",";
						}
												
						Command.CommandText = "SELECT NAM_OF_SLU FROM SLUZBA.DBF WHERE KEY_OF_SLU NOT IN (" + secure_sluzb + ") ";
						DataAdapter.Fill(dataset);
						rc = dataset.Tables[0].Rows;
					
						for( int i=0; i<rc.Count; i++)
						{
							sl_label2.Text += rc[i]["NAM_OF_SLU"].ToString();
							sl_label2.Text += ",";
						}
					}
					else sl_label.Text += "нет"; sl_label2.Text += "нет";

					if ( secure_podrazd != "" )
					{

						Command.CommandText = "SELECT PODRAZDEL FROM PODRAZD.DBF WHERE KEY_OF_POD IN (" + secure_podrazd + ")";
						DataAdapter.Fill(dataset);
						rc = dataset.Tables[0].Rows;
					
						for( int i=0; i<rc.Count; i++)
						{
							podr_label.Text += rc[i]["PODRAZDEL"].ToString();
							podr_label.Text += ",";
						}
					} 
					else podr_label.Text += "нет";

					if ( secure_podr != "" )
					{

						Command.CommandText = "SELECT PODR FROM NAIMEN.DBF WHERE KEY_OF_NAI IN (" + secure_podr + ")";
						DataAdapter.Fill(dataset);
						rc = dataset.Tables[0].Rows;
					
						for( int i=0; i<rc.Count; i++)
						{
							pdr_label.Text += rc[i]["NAIMENOVAN"].ToString();
							pdr_label.Text += ",";
						}
					} 
					else pdr_label.Text += "нет";
				}
				else
				{
					if (Request.QueryString["sl"].ToString() != "")
					{
						Command.CommandText = "SELECT NAM_OF_SLU FROM SLUZBA.DBF WHERE KEY_OF_SLU IN (" +
							Request.QueryString["sl"] + ") ";
						DataAdapter.Fill(dataset);
						rc = dataset.Tables[0].Rows;
						for( int i=0; i<rc.Count; i++)
						{
							sl_label.Text += rc[i]["NAM_OF_SLU"].ToString();
							sl_label.Text += ",";
						}
					} 
					else sl_label.Text += "нет";
					
					if (Request.QueryString["podr"].ToString() != "")
					{
						Command.CommandText = "SELECT PODRAZDEL FROM PODRAZD.DBF WHERE KEY_OF_POD IN (" +
							Request.QueryString["podr"] + ")";
						DataAdapter.Fill(dataset);
						rc = dataset.Tables[0].Rows;
						for( int i=0; i<rc.Count; i++)
						{
							podr_label.Text += rc[i]["PODRAZDEL"].ToString();
							podr_label.Text += ",";
						}
					} 
					else podr_label.Text += "нет";

					if (Request.QueryString["pdr"].ToString() != "")
					{
						Command.CommandText = "SELECT * FROM NAIMEN.DBF WHERE KEY_OF_NAI IN (" +
							Request.QueryString["pdr"] + ")";
						DataAdapter.Fill(dataset);
						rc = dataset.Tables[0].Rows;
						for( int i=0; i<rc.Count; i++)
						{
							pdr_label.Text += rc[i]["NAIMENOVAN"].ToString();
							pdr_label.Text += ",";
						}
					} 
					else pdr_label.Text += "нет";
					
				}

				dataset.Tables[0].Dispose();
				Connection.Dispose();
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
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// Command
			// 
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase IV;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;Drive" +
				"rId=277";

		}
		#endregion
	}
}
