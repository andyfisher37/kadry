using System;
using System.Data;
using System.Web.UI.WebControls;

namespace kadry
{
	/// <summary>
	/// Summary description for WebForm2.
	/// </summary>
	public partial class DetailList : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected System.Data.Odbc.OdbcConnection Conn;
		protected System.Data.Odbc.OdbcCommand Command;
		protected kadry.mainDataSet mainDataSet;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				Security.Security s = new kadry.Security.Security();
				// Проверка на право доступа...
				if ( !s.CheckSecurePage(User.Identity.Name,"detaillist.aspx") ) Response.Redirect("AccessDenied.htm",true);

				Command.CommandText = kadry.Vars.CmdText;
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(mainDataSet);

				if (mainDataSet._Table.Count !=0 ) // Если кого-то нашли...
				{
					FindLabel.CssClass = "maintext";
					FindLabel.Text = "Найдено: " + Convert.ToString(mainDataSet._Table.Count) + " человек(а)";
							
					// Если с признаком наличия фото...
					if (Request.QueryString["photo"] != "0")
					{
						// Добавляем колоночку "ФОТО"
						Grid.Columns.Add(new TemplateColumn());
						Grid.Columns[9].HeaderText = "Фото";
						Grid.Columns[9].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
						Grid.Columns[9].ItemStyle.VerticalAlign = VerticalAlign.Middle;
						Grid.Columns[9].ItemStyle.Font.Name = "Verdana";
						Grid.Columns[9].ItemStyle.Font.Bold = true;
						Grid.Columns[9].ItemStyle.Width = Unit.Percentage(3);

						Grid.DataBind();

						DataSet ds = new DataSet();
						ds.Tables.Add("table");

						for (int i = 0; i <= mainDataSet._Table.Rows.Count - 1; i++ )
						{
							// Подстановка должности при замещении...
							if ( Convert.ToString(mainDataSet._Table.Rows[i]["nam_of_dol"]) != Convert.ToString(mainDataSet._Table.Rows[i]["nam_of_dol1"]) )
							{
								Grid.Items[i].Cells[6].Text = mainDataSet._Table.Rows[i]["nam_of_dol1"] + " (за счет - " +
									mainDataSet._Table.Rows[i]["nam_of_dol"] + ")";
							}

							Command.CommandText = "SELECT PHOTO FROM PHOTOS.DBF WHERE KEY_1 = " + Convert.ToString(mainDataSet._Table.Rows[i]["KEY_1"]);
							DataAdapter.SelectCommand = Command;
							DataAdapter.Fill(ds);
							// Добавляем числовую часть личного номера...
							Grid.Items[i].Cells[8].Text += "-" + mainDataSet._Table.Rows[i]["lich_nom_2"];
							if (ds.Tables["table"].Rows.Count != 0)
							{
								Grid.Items[i].Cells[9].Text = "v";
							}
							else 
							{
								Grid.Items[i].Cells[9].Text = "";
							}
							ds.Dispose();
						}
						ds.Dispose();
					} 
					else
					{
				
						// Добавляем числовую часть личного номера...
						Grid.DataBind();			
						for (int i = 0; i <= mainDataSet._Table.Rows.Count - 1; i++ )
						{
							// Подстановка должности при замещении...
							if ( Convert.ToString(mainDataSet._Table.Rows[i]["nam_of_dol"]) != Convert.ToString(mainDataSet._Table.Rows[i]["nam_of_dol1"]) )
							{
								Grid.Items[i].Cells[6].Text = mainDataSet._Table.Rows[i]["nam_of_dol1"] + " (за счет - " +
									mainDataSet._Table.Rows[i]["nam_of_dol"] + ")";
							}

							Grid.Items[i].Cells[8].Text += "-" + mainDataSet._Table.Rows[i]["lich_nom_2"];
						}
					}

					// Скрываем ненужные столбцы в таблице...
					if (Request.QueryString["podr"] == "false")
					{
						Grid.Columns[4].Visible = false;
						FindLabel.Text += ", только (" + Grid.Items[0].Cells[4].Text + ")";
					} 
					else Grid.Columns[4].Visible = true;

					if (Request.QueryString["sluz"] == "false")
					{
						Grid.Columns[5].Visible = false;
						FindLabel.Text += ", только (" + Grid.Items[0].Cells[5].Text + ")";
					} 
					else Grid.Columns[5].Visible = true;
				
					if (Request.QueryString["zvan"] == "false")
					{
						Grid.Columns[7].Visible = false;
						FindLabel.Text += ", только (" + Grid.Items[0].Cells[7].Text + ")";
					} 
					else Grid.Columns[7].Visible = true;
					
					if (Request.QueryString["nation"] != "all")	FindLabel.Text += ", только (" + Request.QueryString["nation"] + ")";
					 
					if (Request.QueryString["s_text"] != "")
					{
						secure_label.Text = Request.QueryString["s_text"];
						secure_label.NavigateUrl = "denied_expl.aspx?User=" + User.Identity.Name;
					}
					
				}
				else
				{
					Grid.DataBind();
					FindLabel.CssClass = "Attantion";
					FindLabel.Text = "Не найдено ни одного сотрудника, попробуйте изменить параметры запроса...";
				
				}
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
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.Conn = new System.Data.Odbc.OdbcConnection();
			this.mainDataSet = new kadry.mainDataSet();
			((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).BeginInit();
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// Command
			// 
			this.Command.Connection = this.Conn;
			// 
			// Conn
			// 
			this.Conn.ConnectionString = "MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;Driv" +
				"erId=533";
			// 
			// mainDataSet
			// 
			this.mainDataSet.DataSetName = "mainDataSet";
			this.mainDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).EndInit();

		}
		#endregion
	}
}
