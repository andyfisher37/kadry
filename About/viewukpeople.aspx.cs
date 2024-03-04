using System;

namespace kadry.About
{
	/// <summary>
	/// Summary description for viewkadrypeople.
	/// </summary>
	public partial class viewkadrypeople : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				kadry.Security.Security s = new kadry.Security.Security();
				string id = Request.QueryString["id"].ToString();
				if (!s.CheckSecureKey(Context.User.Identity.Name, Convert.ToInt16(id))) Response.Redirect("../AccessDenied.aspx",true);
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
	}
}
