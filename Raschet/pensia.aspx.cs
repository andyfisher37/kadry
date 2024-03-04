using System;
using System.Data;
//using Microsoft.Office.Interop;

namespace kadry.Raschet
{
	/// <summary>
	/// Summary description for pensia.
	/// </summary>
	public class pensia : System.Web.UI.Page
	{
		
		protected eWorld.UI.MaskedTextBox Date;
		protected System.Web.UI.WebControls.TextBox Name;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected System.Web.UI.WebControls.Label FIO;
		protected System.Web.UI.WebControls.ImageButton GoButton;

		public System.Data.DataRowCollection rc;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack) 
			{
				// Получаем ключ человека...
				string id = Request.QueryString["id"];

				// Основные сведения
				Command.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, LICH_NOM_1, LICH_NOM_2, NOMLICHDEL FROM AAQQ.DBF WHERE KEY_1 = " + id;
			
				DataSet ds = new DataSet();
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(ds);
				rc = ds.Tables[0].Rows;
				
                FIO.Text = rc[0]["FAMILIYA"].ToString() + " " + rc[0]["IMYA"].ToString() + " " + rc[0]["OTCHECTVO"].ToString() + " (" + rc[0]["LICH_NOM_1"].ToString() + "-" + rc[0]["LICH_NOM_2"].ToString() + "), личное дело № " + rc[0]["NOMLICHDEL"].ToString();
				Date.Text = System.DateTime.Now.ToShortDateString();
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
			this.Connection = new System.Data.Odbc.OdbcConnection();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;Driv" +
				"erId=533";
			// 
			// Command
			// 
			this.Command.Connection = this.Connection;
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			this.GoButton.Click += new System.Web.UI.ImageClickEventHandler(this.GoButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void GoButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
            //object oMissing = System.Reflection.Missing.Value;

            //Excel._Application oExcel;
            //Excel._Document oExcel;
            //oExcel = new Excel.Application();

            //object objDocTemplate = Server.MapPath("") + "\\Raschet\\Расчет.xlsx";
            //oDoc = oWord.Documents.Add(ref objDocTemplate, ref oMissing, ref oMissing, ref oMissing);
			
            //oDoc.ActiveWindow.View.TableGridlines = false;
            //oDoc.ActiveWindow.ActivePane.View.Zoom.Percentage = 100;
            //oDoc.ShowSpellingErrors = false;

            //oWord.Visible = true;
            //oWord.Activate();

            //object oSaveAsFile = Server.MapPath("") + "\\Raschet\\" + FIO.Text + ".doc";
            //oDoc.SaveAs(ref oSaveAsFile, ref oMissing, ref oMissing, ref oMissing,
            //ref oMissing, ref oMissing, ref oMissing, ref oMissing, 
            //ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            //object SaveChanges = true;
            //oDoc.Close(ref SaveChanges, ref oMissing, ref oMissing);
            //oDoc = null;
            //oWord.Quit(ref SaveChanges, ref oMissing, ref oMissing);
	
		}
	}
}
