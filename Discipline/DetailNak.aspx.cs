using System;
using System.Web.UI;

namespace kadry.Discipline
{
	/// <summary>
	/// Summary description for DetailNak.
	/// </summary>
	public partial class DetailNak : System.Web.UI.Page
	{
		protected kadry.Discipline.nakazDataSet nakazDataSet;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
	
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
			this.nakazDataSet = new kadry.Discipline.nakazDataSet();
			this.Connection = new System.Data.Odbc.OdbcConnection();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			((System.ComponentModel.ISupportInitialize)(this.nakazDataSet)).BeginInit();
			// 
			// nakazDataSet
			// 
			this.nakazDataSet.DataSetName = "nakazDataSet";
			this.nakazDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
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
			this.Load += new System.EventHandler(this.DetailNak_Load);
			((System.ComponentModel.ISupportInitialize)(this.nakazDataSet)).EndInit();

		}
		#endregion

		protected void DetailNak_Load(object sender, System.EventArgs e)
		{
		if (!IsPostBack)
			{
			   kadry.Security.Security s = new kadry.Security.Security();
			   
				// даты
				string date1 = Request.QueryString["date1"];
				string date2 = Request.QueryString["date2"];
				bool Check1 = Convert.ToBoolean(Request.QueryString["sn"]);
			    FindLabel.Text = Request.QueryString["title"];
				string podr = Request.QueryString["podr"];
				string sluz = Request.QueryString["sluz"];
				string nakaz = Request.QueryString["nakaz"];
			    bool OVDCheck = Convert.ToBoolean(Request.QueryString["ovddate"]);
				
				Command.CommandText = kadry.Vars.CmdText;
			    //Response.Write(Command.CommandText);
				DataAdapter.SelectCommand = Command;
				nakazDataSet.Dispose();
				DataAdapter.Fill(nakazDataSet, "Table" );

				if (nakazDataSet.Tables["Table"].Rows.Count != 0 )
				{
					// убираем ненужные колонки...
				
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

					if ( Check1 ) // только неснятые
					{
						Grid.Columns[11].Visible = false;
					}
					else 
					{
						Grid.Columns[11].Visible = true;
					}
					if ( nakaz != "0" ) // одно взыскание
					{
						Grid.Columns[6].Visible = false;
					}
					else Grid.Columns[6].Visible = true;

					if ( OVDCheck ) // по стажу в овд
					{
						Grid.Columns[12].Visible = true;
					}
					else Grid.Columns[12].Visible = false;
					
				
						//					// Убираем не попадающие в период...
						//					foreach( DataRow row in nakazDataSet.Tables["Table"].Rows)
						//					{
						//						if ( Convert.ToDateTime(row["DAT_NALOZ"]) >= Convert.ToDateTime(date1) &&
						//							 Convert.ToDateTime(row["DAT_NALOZ"]) <= Convert.ToDateTime(date2) )
						//						nakazDataSet.Tables["Table"].Rows.Remove(row);
						//					}

						// Забрасываем в таблицу...
						Grid.DataBind();

					count_label.Text = "Итого: " + Grid.Items.Count.ToString();
					s.AddLogText("Детальная информация по взысканиям:[" + FindLabel.Text + "]",Request.UserHostAddress.ToString(),19,true);
		
				}
				else
				{
					FindLabel.CssClass = "Attantion";
					FindLabel.Text = "Ничего не найдено!";
				}
			}
		}

        protected void ExcelCopyButton_Click(object sender, ImageClickEventArgs e)
        {
            kadry.WordExcel.ExportGridToExcel(this, Grid, "Взыскания");
        }

        protected void WordCopyButton_Click(object sender, ImageClickEventArgs e)
        {
            kadry.WordExcel.ExportGridToWord(this, Grid, "Взыскания");
        }
	}
}
