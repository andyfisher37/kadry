using System;
//using Microsoft.Office.Interop.Word;



namespace UK
{
	/// <summary>
	/// Summary description for ObjectiveWD.
	/// </summary>
	public partial class ObjectiveWD : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack) 
			{
				Security.Security s = new Security.Security();
				

                ////string LogText = "";
                //string curIP = Convert.ToString(Context.Request.UserHostAddress);
                ////string sbase = "";

                //// Получаем ключ человека...
                //int id = Convert.ToInt16(Request.QueryString["id"]);

                //// Проверка на право доступа...
                //if ( !s.CheckSecurePage(User.Identity.Name,"objective.aspx") ) Response.Redirect("AccessDenied.htm",true);
                //if ( !s.CheckSecureKey(User.Identity.Name,id) ) Response.Redirect("AccessDenied.htm",true);

                //Word.ApplicationClass oWordApp = new Word.ApplicationClass();

                //object readOnly = false;
                //object isVisible = true;
                //object missing = System.Reflection.Missing.Value;
                //object oTemplate = "Objective.dot";
								 
                //Word.Document oWordDoc = oWordApp.Documents.Add(ref oTemplate, 
                //    ref missing,ref missing, ref missing);

                //oWordDoc.Activate();

                //oWordApp.Selection.TypeText("This is the text");
                //oWordApp.Selection.TypeParagraph();
                //oWordDoc.Save();

                //oWordApp.Application.Quit(ref missing, ref missing, ref missing);
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
