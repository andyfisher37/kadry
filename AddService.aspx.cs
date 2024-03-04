using System;
using System.Web.UI;

namespace kadry
{
	/// <summary>
	/// Summary description for AddService.
	/// </summary>
	public partial class AddService : System.Web.UI.Page
	{

		protected static string key;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				Security.Security s = new Security.Security();

                key = Request.Params["id"];
                                
				if ( !s.CheckSecurePage( User.Identity.Name, "addservice.aspx") ) Response.Redirect("AccessDenied.htm",true);
				
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

		protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		   Response.Redirect("Objective.aspx?id=" + key);
		}

		protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("Spravka.aspx?id=" + key);
		}

		protected void ImageButton3_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("Spravka2.aspx?id=" + key);
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ObjectiveWD.aspx?id=" + key);
		}

		protected void ImageButton4_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\Raschet\\pensia.aspx?id=" + key);
		}

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\IsxDelo.aspx?id=" + key);
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\WorkBook\\main.aspx?id=" + key);
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\GoToPolice\\PersAttestationForm.aspx?id=" + key + "&base=" + kadry.Vars.sbase);
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UVparam.aspx?id=" + key);
        }

        protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UVGive.aspx?id=" + key);
        }

        protected void ImageButton12_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\HotPoint\\Spravka.aspx?id=" + key + "&sbase=" + kadry.Vars.sbase);
        }

        protected void ImageButton13_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Contracts\\Contract.aspx?id=" + key);
        }

        protected void ImageButton14_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Spravka_stag.aspx?id=" + key);
        }

        protected void ImageButton15_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\NZPolice\\nzp_dataform.aspx?id=" + key);
        }

        protected void ImageButton16_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Vacations\\edit_uvedom_form.aspx?id=" + key);
        }
	}
}
