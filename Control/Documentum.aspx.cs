using System;
using System.Data;
using System.Web.UI.WebControls;

namespace kadry.Control
{
	/// <summary>
	/// Summary description for Documentum.
	/// </summary>
	public class Documentum : System.Web.UI.Page
	{
		protected kadry.Control.docDataSet docDataSet;
		protected System.Data.SqlClient.SqlDataAdapter DataAdapter;
		protected System.Data.SqlClient.SqlConnection Connection;
		protected System.Data.SqlClient.SqlCommand Command;
		protected kadry.Control.slvdocDataSet slvdocDataSet;
		protected System.Data.DataSet statDataSet;
		protected System.Data.DataTable dataTable1;
		protected System.Data.DataColumn podr;
		protected System.Data.DataColumn count;
		protected System.Data.DataColumn maxnum;
		protected System.Data.DataColumn dolgi;
		protected System.Web.UI.WebControls.DataGrid Grid;
		protected System.Web.UI.WebControls.Label total_number;
		protected System.Web.UI.WebControls.Label Date;
		protected System.Data.DataColumn dataColumn1;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.DropDownList podrList;
		protected eWorld.UI.MaskedTextBox DateDoc;
		protected System.Web.UI.WebControls.TextBox Number;
		protected System.Web.UI.WebControls.Label Info;
        protected System.Web.UI.WebControls.DropDownList List1;
		public System.Data.DataRowCollection rc;

        public struct Prikaz
        {
            string[] podr;
            string[] podr_id;
            string[] dolgi;
            int[] numbers;
        }

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
                //kadry.Security.Security s = new kadry.Security.Security();

                //if (!s.CheckSecurePage(User.Identity.Name,"Documentum.aspx")) Response.Redirect("\\AccessDenied.htm",true);

                //s.AddLogText("�������� ��������:[���������������]",Context.Request.UserHostAddress.ToString(),25,true);

				int y = 0;
                do
                {
                    ListItem item = new ListItem((System.DateTime.Now.Year - y).ToString(), (System.DateTime.Now.Year - y).ToString());
                    List1.Items.Add(item);
                    y++;
                } while ((System.DateTime.Now.Year - y) > 2006);

                Date.Text = "01.01." + List1.SelectedValue.ToString() + " �.";

				slvdocDataSet.Clear();
				Command.CommandText = "SELECT * FROM Doc_Podr ORDER BY name";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(slvdocDataSet,"Documentum");
				podrList.DataBind();

                UpdateTable();
							
			}
		}

        private void UpdateTable()
        {

            Date.Text = "01.01." + List1.SelectedValue.ToString() + " �.";

            slvdocDataSet.Clear();
            Command.CommandText = "SELECT * FROM Doc_Podr ORDER BY name";
            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(slvdocDataSet, "Documentum");
            podrList.DataBind();

            docDataSet.Clear();
            Command.CommandText = "SELECT Doc_Podr.id, Doc_Podr.name, Documentum.number_doc, Documentum.date_doc, Documentum.date_reg, Documentum.fabula, Documentum.number_list, Documentum.get_storing, Documentum.who_get FROM Documentum INNER JOIN Doc_Podr ON Documentum.podrazd_doc = Doc_Podr.id WHERE YEAR(date_doc) = " + List1.SelectedValue.ToString() + " ORDER BY Documentum.podrazd_doc, Documentum.number_doc";
            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(docDataSet, "Documentum");

            Command.CommandText = "SELECT Doc_Podr.id, Doc_Podr.name, number_doc, date_doc, date_reg, fabula, number_list, get_storing, who_get FROM Doc_Archive INNER JOIN Doc_Podr ON podrazd_doc = Doc_Podr.id  WHERE YEAR(date_doc) = " + List1.SelectedValue.ToString() + " ORDER BY podrazd_doc, number_doc";
            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(docDataSet, "Documentum");

            total_number.Text = docDataSet.Tables["Documentum"].Rows.Count.ToString();
            Info.Text = "";

            rc = docDataSet.Tables["Documentum"].Rows;

            Grid.DataBind();

            int podrCount = slvdocDataSet.Tables["Documentum"].Rows.Count;
            int[] count = new int[podrCount];
            string[] podr = new string[podrCount];
            string[] podr_id = new string[podrCount];
            string[] dolgi = new string[podrCount];
            int itog_count = 0;
            int itog_nocount = 0;

            statDataSet.Clear();

            System.Data.DataRow row;

            for (int i = 0; i < podrCount; i++)
            {
                podr[i] = slvdocDataSet.Tables["Documentum"].Rows[i]["name"].ToString();
                podr_id[i] = slvdocDataSet.Tables["Documentum"].Rows[i]["id"].ToString();
                count[i] = 0;
                int maxnum = 0;
                int[] numbers = new int[rc.Count];

                for (int j = 0; j < rc.Count; j++)
                {
                    if (rc[j]["name"].ToString() == podr[i])
                    {
                        count[i]++;
                        numbers[j] = Convert.ToInt16(rc[j]["number_doc"]);
                        if (maxnum < Convert.ToInt16(rc[j]["number_doc"])) maxnum = Convert.ToInt16(rc[j]["number_doc"]);
                    }
                }
                // ���� ���-�� �������� 2 � �����
                if (count[i] > 1)
                {
                    for (int j = 1; j < maxnum; j++)
                    {
                        int flag = 0;
                        for (int n = 0; n < rc.Count; n++)
                        {
                            if (j == numbers[n]) flag++;
                        }
                        if (flag == 0)
                        {
                            dolgi[i] += j.ToString() + ",";
                            itog_nocount++;
                        }
                    }
                }

                row = statDataSet.Tables["Table"].NewRow();
                row["podr"] = "&nbsp" + podr[i];
                row["count"] = count[i];
                itog_count += count[i];
                row["maxnum"] = maxnum;

                if (dolgi[i] != null)
                {
                    int dc = dolgi[i].Split(Convert.ToChar(",")).Length;
                    string tmp = dc.ToString();
                    row["link"] = "<a href=\"dolgi.aspx?podr=" + podr[i] + "&dolgi=" + dolgi[i] + "\"><img src=\"..//images/plus.gif\" border=0 ></a>";
                    row["dolgi"] = tmp;
                }
                else row["dolgi"] = "-";
                statDataSet.Tables["Table"].Rows.Add(row);
            }

            //�������� ������...
            row = statDataSet.Tables["Table"].NewRow();
            row["podr"] = "&nbsp�����:";
            row["count"] = itog_count;
            row["maxnum"] = 0;
            row["dolgi"] = "&nbsp;&nbsp;" + (itog_nocount - 1).ToString(); // + " - " + Math.Abs((itog_nocount/itog_count*100)).ToString() + "%";
            row["link"] = "";
            statDataSet.Tables["Table"].Rows.Add(row);

            Grid.DataBind();

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
			this.docDataSet = new kadry.Control.docDataSet();
			this.slvdocDataSet = new kadry.Control.slvdocDataSet();
			this.statDataSet = new System.Data.DataSet();
			this.dataTable1 = new System.Data.DataTable();
			this.podr = new System.Data.DataColumn();
			this.count = new System.Data.DataColumn();
			this.maxnum = new System.Data.DataColumn();
			this.dolgi = new System.Data.DataColumn();
			this.dataColumn1 = new System.Data.DataColumn();
			((System.ComponentModel.ISupportInitialize)(this.docDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.slvdocDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
			this.ImageButton1.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton1_Click);
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			this.DataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "Documentum", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("name", "name"),
																																																				new System.Data.Common.DataColumnMapping("number_doc", "number_doc"),
																																																				new System.Data.Common.DataColumnMapping("date_doc", "date_doc"),
																																																				new System.Data.Common.DataColumnMapping("date_reg", "date_reg"),
																																																				new System.Data.Common.DataColumnMapping("fabula", "fabula"),
																																																				new System.Data.Common.DataColumnMapping("number_list", "number_list"),
																																																				new System.Data.Common.DataColumnMapping("get_storing", "get_storing"),
																																																				new System.Data.Common.DataColumnMapping("who_get", "who_get")})});
			// 
			// Command
			// 
			this.Command.CommandText = "SELECT * FROM Doc_Podr ORDER BY name";
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
            this.Connection.ConnectionString = "Data Source=kadryR_SERVER;Initial Catalog=Kard2004;Persist Security Info=True;User ID=ias_user;Password=*";
            // 
			// docDataSet
			// 
			this.docDataSet.DataSetName = "docDataSet";
			this.docDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// slvdocDataSet
			// 
			this.slvdocDataSet.DataSetName = "slvdocDataSet";
			this.slvdocDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// statDataSet
			// 
			this.statDataSet.DataSetName = "NewDataSet";
			this.statDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.statDataSet.Tables.AddRange(new System.Data.DataTable[] {
																			 this.dataTable1});
			// 
			// dataTable1
			// 
			this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
																			  this.podr,
																			  this.count,
																			  this.maxnum,
																			  this.dolgi,
																			  this.dataColumn1});
			this.dataTable1.TableName = "Table";
			// 
			// podr
			// 
			this.podr.ColumnName = "podr";
			// 
			// count
			// 
			this.count.ColumnName = "count";
			this.count.DataType = typeof(short);
			// 
			// maxnum
			// 
			this.maxnum.ColumnName = "maxnum";
			this.maxnum.DataType = typeof(short);
			// 
			// dolgi
			// 
			this.dolgi.ColumnName = "dolgi";
			this.dolgi.DefaultValue = "-";
			// 
			// dataColumn1
			// 
			this.dataColumn1.ColumnName = "link";
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.docDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.slvdocDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();

		}
		#endregion

		private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Info.Text = "";
			string podr = podrList.Items[podrList.SelectedIndex].Value;
			string date = "";
            DateTime dateS = new DateTime();
			string num =  Number.Text;

            if (DateDoc.Text != "")
            {
                date = Convert.ToDateTime(DateDoc.Text).ToShortDateString();
                dateS = Convert.ToDateTime(DateDoc.Text);
            }
			
			DataSet ds = new DataSet();
			ds.Clear();
			
			Command.CommandText = "SELECT Doc_Podr.name, number_doc, date_doc, date_reg, fabula, number_list, get_storing, who_get FROM Doc_Archive INNER JOIN Doc_Podr ON podrazd_doc = Doc_Podr.id  WHERE podrazd_doc = '" + podr + "'";
			if ( num != "" ) Command.CommandText += " AND number_doc = '" + num + "'";
			if ( date != "" ) Command.CommandText += " AND date_doc = " + dateS.ToOADate();
			Command.CommandText += " ORDER BY number_doc ";
			DataAdapter.Fill(ds);

			Command.CommandText = "SELECT Doc_Podr.name, number_doc, date_doc, date_reg, fabula, number_list, get_storing, who_get FROM Documentum INNER JOIN Doc_Podr ON podrazd_doc = Doc_Podr.id  WHERE podrazd_doc = '" + podr + "'";
			if ( num != "" ) Command.CommandText += " AND number_doc = '" + num + "'";
			if ( date != "" ) Command.CommandText += " AND date_doc = " + dateS.ToOADate();
			Command.CommandText += " ORDER BY number_doc ";
			DataAdapter.Fill(ds);
			
			if ( ds.Tables[0].Rows.Count != 0 )
			{
				for( int i=0; i<ds.Tables[0].Rows.Count; i++ )
				{
					Info.Text += "������ " + ds.Tables[0].Rows[i]["name"].ToString() + " �� " +
						Convert.ToDateTime(ds.Tables[0].Rows[i]["date_doc"]).ToShortDateString() + " � " +
						ds.Tables[0].Rows[i]["number_doc"].ToString() + " -> ���������������: " +
						Convert.ToDateTime(ds.Tables[0].Rows[i]["date_reg"]).ToShortDateString() + "<br>";
				}
			}
			else Info.Text = "������ �� ���������������!";


		
		}

        protected void List1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }
	}
}
