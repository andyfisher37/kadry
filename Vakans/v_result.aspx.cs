using System;

namespace kadry.Vakans
{
	/// <summary>
	/// Summary description for v_result.
	/// </summary>
	public partial class v_result : System.Web.UI.Page
	{
		protected kadry.Vakans.vakDataSet vakDataSet;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Label1.Text = Request.Params["tobr"].ToString();
			Label2.Text = Request.Params["pobr"].ToString();
			Label3.Text = Request.Params["age"].ToString();
			Label4.Text = Request.Params["sex"].ToString();
			Label5.Text = Request.Params["size"].ToString();
			Label6.Text = Request.Params["pay"].ToString();

			Label8.Text = Request.Params["bd"].ToString();

			Label10.Text = Request.Params["boss"].ToString();
			Label11.Text = Request.Params["vod"].ToString();

			vakDataSet = (kadry.Vakans.vakDataSet)Cache["dataset"];
			Grid.DataBind();
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
			this.vakDataSet = new kadry.Vakans.vakDataSet();
			((System.ComponentModel.ISupportInitialize)(this.vakDataSet)).BeginInit();
			// 
			// vakDataSet
			// 
			this.vakDataSet.DataSetName = "vakDataSet";
			this.vakDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.vakDataSet)).EndInit();

		}
		#endregion
	}
}
