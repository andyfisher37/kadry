using System;
using System.Drawing;
using System.Web.UI.WebControls;

namespace UK
{
	/// <summary>
	/// Summary description for net_stat.
	/// </summary>
	public partial class net_stat : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlDataAdapter DataAdapter;
		protected System.Data.SqlClient.SqlCommand Command;
		protected UK.logsDataSet logsDataSet;
		protected System.Data.SqlClient.SqlConnection Connection;
		protected System.Data.DataRowCollection rc;
	
		public struct TStat
		{
			public string ip;
			public int count;
			public string name;
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				// �������� ������ �������������...
				Command.CommandText = "SELECT DISTINCT IP, COMMENT FROM Users WHERE IP NOT IN ('192.168.10.2','192.168.0.2') ORDER BY IP";
				DataAdapter.Fill(logsDataSet,"Users");
				rc = logsDataSet.Tables["Users"].Rows;

				int total_hit = 0;
				int month_hit = 0;
				int today_hit = 0;
				int count_user = rc.Count;
				TStat[] users = new TStat[count_user];

				// ��������� ������ �������������...
				for( int i = 0; i< count_user; i++ )
				{
					users[i].ip = rc[i]["IP"].ToString();
					users[i].name = rc[i]["Comment"].ToString();
					users[i].count = 0;
				}

				// �������� ������ ����� ��� ������� ������������...
				for( int i = 0; i < count_user; i++ )
				{
					Command.CommandText = "SELECT Time, UserInit, AccessStatus FROM Logs WHERE EventType <> 2 AND UserInit = '" + users[i].ip + "' ORDER BY Time ";
					logsDataSet.Clear();
					rc.Clear();
					DataAdapter.Fill(logsDataSet,"Logs");
					rc = logsDataSet.Tables["Logs"].Rows;

					users[i].count = rc.Count;
					total_hit += users[i].count;
					DateTime date = new DateTime();

					for( int j = 0; j < users[i].count; j++ )
					{
						date = Convert.ToDateTime(rc[j]["Time"]);
						if ( date.Year == System.DateTime.Now.Year && date.Month == System.DateTime.Now.Month ) month_hit++;
						if ( date.ToShortDateString() == System.DateTime.Now.ToShortDateString() ) today_hit++;
					}
				}

				// ��������� �� ��������...
				TStat temp = new TStat();
				bool flag = false;
				do
				{
					flag = false;
					for( int i = 0; i < count_user-1; i++ )
					{
						if ( users[i+1].count > users[i].count ) 
						{
							temp.count = users[i].count;
							temp.ip = users[i].ip;
							temp.name = users[i].name;
							users[i].count = users[i+1].count;
							users[i].ip = users[i+1].ip;
							users[i].name = users[i+1].name;
							users[i+1].count = temp.count;
							users[i+1].ip = temp.ip;
							users[i+1].name = temp.name;
							flag = true;
						}
					}
				}while(flag!=false);
			
				// ����� � ��������...
				TableRow row1 = new TableRow();
				TableCell cell1 = new TableCell();
				cell1.Text = " ������������ ";
				cell1.HorizontalAlign = HorizontalAlign.Center;
				cell1.Font.Bold = true;
				row1.Cells.Add(cell1);
				TableCell cell2 = new TableCell();
                cell2.Text = " ���������� �������� ";
				cell2.HorizontalAlign = HorizontalAlign.Center;
				cell2.Font.Bold = true;
				row1.Cells.Add(cell2);
				Table.Rows.Add(row1);

				for( int i = 0; i < count_user; i++ )
				{
					TableRow r = new TableRow();
					TableCell c1 = new TableCell();
					c1.Text = users[i].name;
					c1.Font.Name = "Verdana";
					c1.ForeColor = Color.Brown;
					r.Cells.Add(c1);
					TableCell c2 = new TableCell();
					c2.Text = graph(users[i].count, users[0].count) + " [" + users[i].count.ToString() + "] ";
					c2.Font.Name = "Verdana";
					c2.ForeColor = Color.DarkGreen;
					r.Cells.Add(c2);
					Table.Rows.Add(r);
				}

				total_query.Text = total_hit.ToString();
				month_query.Text = month_hit.ToString();
				today_query.Text = today_hit.ToString();

					
			}
		}

		public string graph( int pos, int max )
		{
			int proc = Math.Abs((pos * 100 / max) / 2);
			string bar = "";
			for( int i = 0; i < proc; i++ )
			{
				bar += "<img src='images\\star.gif'>";
			}
			return bar;
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
			this.DataAdapter = new System.Data.SqlClient.SqlDataAdapter();
			this.Command = new System.Data.SqlClient.SqlCommand();
			this.Connection = new System.Data.SqlClient.SqlConnection();
			this.logsDataSet = new UK.logsDataSet();
			((System.ComponentModel.ISupportInitialize)(this.logsDataSet)).BeginInit();
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			this.DataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "Users", new System.Data.Common.DataColumnMapping[0])});
			// 
			// Command
			// 
			this.Command.CommandText = "SELECT UserName, DISTINCT IP, UserID FROM Users WHERE IP NOT IN (\'192.168.10.2\',\'192.168.0.2\') ORDER B" +
				"Y UserID";
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
            this.Connection.ConnectionString = "Data Source=URLS_SERVER\\SQLEXPRESS;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*";
			// 
			// logsDataSet
			// 
			this.logsDataSet.DataSetName = "logsDataSet";
			this.logsDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.logsDataSet)).EndInit();

		}
		#endregion
	}
}
