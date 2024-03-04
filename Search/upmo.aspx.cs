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

namespace UK.Search
{
	/// <summary>
	/// Summary description for upmo.
	/// </summary>
	public partial class upmo : System.Web.UI.Page
	{
		protected System.Data.OracleClient.OracleConnection Connection;
		protected System.Data.OracleClient.OracleDataAdapter DataAdapter;
		protected UK.Search.upmoDataSet upmoDataSet;
		protected System.Data.OracleClient.OracleCommand Command;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.Connection = new System.Data.OracleClient.OracleConnection();
			this.Command = new System.Data.OracleClient.OracleCommand();
			this.DataAdapter = new System.Data.OracleClient.OracleDataAdapter();
			this.upmoDataSet = new UK.Search.upmoDataSet();
			((System.ComponentModel.ISupportInitialize)(this.upmoDataSet)).BeginInit();
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "user id=case1;data source=PRIMEPWR;password=case1";
			// 
			// Command
			// 
			this.Command.CommandText = "SELECT FAM, IMJ, OTCH, Y_ROJD, M_ROJD, D_ROJD, KRAJ FROM T001 WHERE (FAM = \'–€¡¿ " +
				"Œ¬\') AND (IMJ = \'¿Õƒ–≈…\') AND (OTCH = \'ﬁ–‹≈¬»◊\') ORDER BY Y_ROJD";
			this.Command.Connection = this.Connection;
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// upmoDataSet
			// 
			this.upmoDataSet.DataSetName = "upmoDataSet";
			this.upmoDataSet.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.upmoDataSet)).EndInit();

		}
		#endregion

		protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Command.CommandText = "SELECT FAM, IMJ, OTCH, Y_ROJD, M_ROJD, D_ROJD, KRAJ FROM T001 " +
								  "WHERE FAM = '" + TextBox1.Text.ToUpper() + "' AND " +
								  "IMJ = '" + TextBox2.Text.ToUpper() + "' AND " +
								  "OTCH = '" + TextBox3.Text.ToUpper() + "' ORDER BY Y_ROJD ";

			DataAdapter.SelectCommand = Command;
			DataAdapter.Fill(upmoDataSet);
			if ( upmoDataSet.Tables[0].Rows.Count > 0 )
			{
				Grid.DataBind();
				label.Text = "Õ‡È‰ÂÌÓ: " + upmoDataSet.Tables[0].Rows.Count.ToString();
			}
			else label.Text = "ÕË˜Â„Ó ÌÂ Ì‡È‰ÂÌÓ!";


		}
	}
}
