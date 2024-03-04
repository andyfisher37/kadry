using System;
using obout_ASPTreeView_2_NET;

namespace kadry.Quality
{
	/// <summary>
	/// Summary description for WebForm3.
	/// </summary>
	public class Quality : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
        public System.Web.UI.WebControls.Literal Tree1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
                //kadry.Security.Security s = new kadry.Security.Security();

                //if (!s.CheckSecurePage(User.Identity.Name,"Quality.aspx")) Response.Redirect("\\AccessDenied.htm",true);

                //s.AddLogText("Открытие страницы:[Качественные характеристики]",Context.Request.UserHostAddress.ToString(),9,true);

                obout_ASPTreeView_2_NET.Tree oTree = new obout_ASPTreeView_2_NET.Tree();
                                
                oTree.AddRootNode("Статистические таблицы по кадровой работе", true, "xpMyComp.gif");

                oTree.XML_LoadFromFile(Request.MapPath("Statistics.xml"));

                oTree.FolderIcons = "../images/Tree/icons";
                oTree.FolderScript = "../images/Tree/script";
                oTree.FolderStyle = "../images/Tree/style/Classic";
                oTree.Width = "735px";

                // Write treeview to your page.
                Tree1.Text = oTree.HTML();
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
