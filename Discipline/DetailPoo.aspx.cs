using System;
using System.Web.UI;

namespace kadry.Discipline
{
	/// <summary>
	/// Summary description for DetailPoo.
	/// </summary>
	public partial class DetailPoo : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected kadry.Discipline.pooDataSet pooDataSet;
	
	
		
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
			this.pooDataSet = new kadry.Discipline.pooDataSet();
			this.Connection = new System.Data.Odbc.OdbcConnection();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			((System.ComponentModel.ISupportInitialize)(this.pooDataSet)).BeginInit();
			// 
			// pooDataSet
			// 
			this.pooDataSet.DataSetName = "pooDataSet";
			this.pooDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
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
			this.Load += new System.EventHandler(this.DetailPoo_Load);
			((System.ComponentModel.ISupportInitialize)(this.pooDataSet)).EndInit();

		}
		#endregion

		protected void DetailPoo_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				Command.CommandText = kadry.Vars.CmdText;
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(pooDataSet,"Table");

				if (pooDataSet.Tables["Table"].Rows.Count != 0 )
				{
					kadry.Security.Security s = new kadry.Security.Security();

					// даты
					string date1 = Request.QueryString["date1"];
					string date2 = Request.QueryString["date2"];
					FindLabel.Text = Request.QueryString["title"];
					string poo = Request.QueryString["poo"];
					string podr = Request.QueryString["podr"];
					string sluz = Request.QueryString["sluz"];

					if ( podr != "0" ) // одно подразделение
					{
						Grid.Columns[3].Visible = false;
					}
					else 
					{
						Grid.Columns[3].Visible = true; 
					}

					if ( sluz != "-1" ) // одна служба
					{
						Grid.Columns[4].Visible = false;
					}
					else 
					{
						Grid.Columns[4].Visible = true;
					}
					if ( poo != "0" && poo != "-1" && poo != "-2" ) // один вид поощрения
					{
						Grid.Columns[6].Visible = false;
					}
					else 
					{
						Grid.Columns[6].Visible = true;
					}

					Grid.DataBind();
					
					count_label.Text = "Итого: " + Grid.Items.Count.ToString() + " поощрений";
					s.AddLogText("Детальная информация по поощрениям:[" + FindLabel.Text + "]",Request.UserHostAddress.ToString(),20,true);
				}
				else
				{
					FindLabel.CssClass = "Attantion";
					FindLabel.Text += "Ничего не найдено...";
					
				}
   			    
			}
		
		}
        
        protected void ExcelCopyButton_Click(object sender, ImageClickEventArgs e)
        {
            kadry.WordExcel.ExportGridToExcel(this, Grid, "Поощрения");
        }

        protected void WordCopyButton_Click(object sender, ImageClickEventArgs e)
        {
            kadry.WordExcel.ExportGridToWord(this, Grid, "Поощрения");
        }

        

	}
}
