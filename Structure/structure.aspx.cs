using System;

namespace UK.Structure
{
	/// <summary>
	/// Summary description for structure.
	/// </summary>
	public partial class structure : System.Web.UI.Page
	{
		public System.Data.DataRowCollection rc;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				UK.Security.Security s = new UK.Security.Security();

				if (!s.CheckSecurePage(User.Identity.Name,"structure.aspx")) Response.Redirect("\\AccessDenied.htm",true);
				
				s.AddLogText("Открытие страницы:[Структура ОВД]",Context.Request.UserHostAddress.ToString(),13,true);
						
//				OdbcConnection Connection = new System.Data.Odbc.OdbcConnection("MaxBufferSize=2048;FIL=dBase IV;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;DriverId=277");
//				OdbcCommand Command = new System.Data.Odbc.OdbcCommand("SELECT PODRAZDEL FROM PODRAZD WHERE KEY_OF_POD IN (SELECT PODRAZD FROM AAQQ ORDER BY PODRAZD)", Connection );
//				OdbcDataAdapter DataAdapter = new System.Data.Odbc.OdbcDataAdapter( Command.CommandText, Connection);
//				DataSet strDataSet = new DataSet();
//				DataAdapter.Fill(strDataSet);
//				rc = strDataSet.Tables[0].Rows;
			
				
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
