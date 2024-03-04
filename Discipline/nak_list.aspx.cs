using System;

namespace kadry.Discipline
{
	/// <summary>
	/// Summary description for nak_list.
	/// </summary>
	public partial class nak_list : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ListBox List;
		
		public System.Data.DataRowCollection rc;
			
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				UserName.Text = User.Identity.Name;

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

		protected void ClearList_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			TEXTAREA.Value = "";
		}

		protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			char tmp;
			int spaces = 0;

			for( int i = 0; i< TEXTAREA.Value.Length; i++ )
			{
				tmp = TEXTAREA.Value[i];
				if ( tmp == Convert.ToChar(" ") ) spaces++;
			}

			float c = spaces / 2;

			

			
		}
	
	}
}
