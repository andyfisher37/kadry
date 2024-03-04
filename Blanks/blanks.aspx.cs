using System;
using System.IO;

namespace kadry.Blanks
{
	/// <summary>
	/// Summary description for blanks.
	/// </summary>
	public partial class blanks : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				kadry.Security.Security s = new kadry.Security.Security();

				if (!s.CheckSecurePage(User.Identity.Name,"blanks.aspx")) Response.Redirect("\\AccessDenied.htm",true);
				else  s.AddLogText("Открытие страницы - бланки служ.документов",Context.Request.UserHostAddress,24,true);
				
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
            //if ( Tree.SelectedNodeIndex.Length > 2 )
            //{
            //    int index1 = Convert.ToInt16(Tree.SelectedNodeIndex.Substring(0,1));
            //    int index2 = Convert.ToInt16(Tree.SelectedNodeIndex.Substring(2,1));
            //    string fName = Tree.Nodes[index1].Nodes[index2].NodeData;
			
            //    long lngFileSize; 
            //    byte[] bytBuffer; 
            //    int iReading; 
            //    string sFileName = Server.MapPath("~\\Blanks\\" + fName); 
            //    Stream outStream = Response.OutputStream; 
            //    Response.ContentType = "application/octet-stream"; 
            //    Response.AppendHeader("Connection","keep-alive"); 
            //    Response.AppendHeader("Content-Disposition"," attachment; filename = "+fName ); 
            //    FileStream fStream = new FileStream(sFileName,FileMode.OpenOrCreate,FileAccess.Read); 
            //    lngFileSize = fStream.Length; 
            //    bytBuffer = new byte[(int)lngFileSize]; 
            //    while((iReading=fStream.Read(bytBuffer,0,(int)lngFileSize)) > 0) 
            //    { 
            //        outStream.Write(bytBuffer,0,iReading); 
            //    } 
            //    fStream.Close(); 
            //    outStream.Close(); 
                
            //}
			
		}
	}
}
