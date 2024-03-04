using System;

namespace kadry
{
	/// <summary>
	/// Summary description for about.
	/// </summary>
	public partial class about : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl SPAN1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				kadry.Security.Security s = new kadry.Security.Security();
				s.AddLogText("Открытие страницы - УРЛС",Request.UserHostAddress.ToString(),18,true);
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

		}
		#endregion

		protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("hystory.htm");
		}

		protected void ImageButton3_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("..\\Normatives\\Store\\UVD\\pol_kadry.htm");
		}

		private void ImageButton4_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("cabinets.htm");
		}

		protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		    Response.Redirect("sostav.aspx");
		}

		

	}
}
