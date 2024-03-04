using System;
using System.Web.UI;

namespace kadry
{
	/// <summary>
	/// Summary description for AdditionalServices.
	/// </summary>
	public partial class AdditionalServices : System.Web.UI.Page
	{
	
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

		}
		#endregion

		protected void ImageButton5_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\Control\\sokr_control.aspx");
		}

		protected void ImageButton3_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\Control\\cert_control.aspx");
		}

		protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\Control\\zvan_control.aspx");
		}

		protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\Control\\pfile_control.aspx");
		}

		protected void ImageButton4_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\Documentum\\Documentum.aspx");
		}

		protected void ImageButton6_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\InOut\\inout.aspx");
		}

		protected void ImageButton7_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\HotPoint\\HotPoint.aspx");
		}

		protected void ImageButton8_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\Normatives\\metody.aspx");
		}

		protected void ImageButton9_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\Statist\\OperSvodka.aspx");
		}

		protected void ImageButton10_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\Attestation\\Attestation.aspx");
		}

        protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Control\\moving_control.aspx");
        }

        protected void ImageButton12_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\ProfPod\\firsted_control.aspx");
        }

        protected void ImageButton13_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\ProfPod\\sbp_stat.aspx");
        }

        protected void ImageButton14_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Control\\UvedomControl.aspx");
        }
	}
}
