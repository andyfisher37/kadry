using System;

namespace kadry.Normatives
{
	/// <summary>
	/// Summary description for metody.
	/// </summary>
	public class metody : System.Web.UI.Page
	{
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				Security.Security s = new kadry.Security.Security();
				s.AddLogText("Открытие страницы:[Методические материалы]",Context.Request.UserHostAddress.ToString(),16,true);
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
