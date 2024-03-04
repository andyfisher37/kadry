using System;
using obout_ASPTreeView_2_NET;

namespace kadry.Normatives
{
	public class normatives : System.Web.UI.Page
	{
        public System.Web.UI.WebControls.Literal Tree1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				kadry.Security.Security s = new kadry.Security.Security();

				if (!s.CheckSecurePage(User.Identity.Name,"normatives.aspx")) Response.Redirect("\\AccessDenied.htm",true);	

				s.AddLogText("Открытие страницы:[Нормативная база]",Context.Request.UserHostAddress.ToString(),10,true);

                obout_ASPTreeView_2_NET.Tree oTree = new obout_ASPTreeView_2_NET.Tree();

                // Root node is optional. You can delete this line.
                oTree.AddRootNode("Перечень нормативных документов по кадровой работе", true, "xpMyComp.gif");


                // Absolute path. Load file from XML file.
                //oTree.XML_LoadFromFile("C:/Inetpub/wwwroot/TreeView/Examples/CSharp/xmldemo.xml");

                // Relative path. Load file from XML file.
                oTree.XML_LoadFromFile(Request.MapPath("tree.xml"));

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
