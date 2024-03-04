using System;
using System.Web.UI.WebControls;

namespace kadry.Control
{
	/// <summary>
	/// Summary description for dolgi.
	/// </summary>
	public partial class dolgi : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				string podr = Request.Params["podr"];
				string dolgi = Request.Params["dolgi"];

				TitleText.Text = "Долги по приказам <<по личному составу>> (" + podr + "), по состоянию на: " + System.DateTime.Now.ToShortDateString() + " г.";
				
				string[] num = dolgi.Split(Convert.ToChar(","));

				TableRow r = new TableRow();
				TableCell c1 = new TableCell();

				for( int i = 0; i<num.Length; i++ )
				{
				  if ( num[i] != "" ) c1.Text += "№ " + num[i] + ", ";
				}
				r.Cells.Add(c1);
				Table.Rows.Add(r);
				
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
