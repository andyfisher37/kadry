using System;
using System.Drawing;
using System.Web.UI.WebControls;

namespace UK
{
	/// <summary>
	/// Summary description for viewphoto.
	/// </summary>
	public partial class viewphoto : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Image.ImageUrl = Request.Params["photo"];
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
