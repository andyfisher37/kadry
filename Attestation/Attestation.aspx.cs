using System;
using System.Drawing;

namespace kadry.Attestation
{
	/// <summary>
	/// Summary description for Attestation.
	/// </summary>
	public partial class Attestation : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected kadry.Attestation.viewDataSet viewDataSet;
		protected kadry.Attestation.attDataSet attDataSet;

		public System.Data.DataRowCollection rc;
		public System.Data.DataRowCollection att;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				kadry.Security.Security s = new kadry.Security.Security();

				if (!s.CheckSecurePage(User.Identity.Name,"attestation.aspx")) Response.Redirect("\\AccessDenied.htm",true);
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
			this.viewDataSet = new kadry.Attestation.viewDataSet();
			this.attDataSet = new kadry.Attestation.attDataSet();
			((System.ComponentModel.ISupportInitialize)(this.viewDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.attDataSet)).BeginInit();
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;DBQ=" +
				"C:\\KADRY;DriverId=277";
			// 
			// Command
			// 
			this.Command.CommandText = @"SELECT slvattosn.NAME, SLVPR2.P1, ATTESTAT.KEY_1, ATTESTAT.DATE_ATT, ATTESTAT.DATE_NEXT, ATTESTAT.OSNOVANIE, ATTESTAT.RESULTAT, ATTESTAT.RECOMEND, ATTESTAT.PRIMECHAN, ATTESTAT.PROTOC_NUM, ATTESTAT.PROTOC_DAT, ATTESTAT.DOC_OSNOV, ATTESTAT.DOC_NUMB, ATTESTAT.DOC_DATE, ATTESTAT.DOC_OVD FROM ATTESTAT, slvattosn, SLVPR2 WHERE ATTESTAT.OSNOVANIE = slvattosn.CODE AND ATTESTAT.DOC_OVD = SLVPR2.P2 ORDER BY ATTESTAT.DATE_ATT";
			this.Command.Connection = this.Connection;
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// viewDataSet
			// 
			this.viewDataSet.DataSetName = "viewDataSet";
			this.viewDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// attDataSet
			// 
			this.attDataSet.DataSetName = "attDataSet";
			this.attDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.viewDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.attDataSet)).EndInit();

		}
		#endregion

		protected void GoBtn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if ( first_name.Text == "" && name.Text == "" && last_name.Text == "" && file_num.Text == "" )
			{
				Grid.DataBind();
				FindLabel.Text = "Необходимы входные параметры...";
			}
			else
			{
				string LogText = "";

				this.first_name_TextChanged(sender, e);
				this.name_TextChanged(sender, e);
				this.last_name_TextChanged(sender, e);

				Command.CommandText = "SELECT KEY_1, FAMILIYA, IMYA, OTCHECTVO, PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN FROM AAQQ, PODRAZD, SLUZBA, OFIC_DOL, ZVANIE WHERE AAQQ.PODRAZD = PODRAZD.KEY_OF_POD AND AAQQ.SLUZBA = SLUZBA.KEY_OF_SLU AND AAQQ.REAL_DOLZN = OFIC_DOL.P3 AND AAQQ.ZVANIE = ZVANIE.KEY_ZVAN ";

				// Ф.И.О.
				if (first_name.Text != "")
				{
					Command.CommandText += " AND FAMILIYA LIKE '" + first_name.Text + "%'";
					LogText += first_name.Text + "|";			
				} 
			
				if (name.Text != "") 
				{
					Command.CommandText += " AND IMYA LIKE '" + name.Text + "%'";
					LogText += name.Text + "|";				
				} 
			
				if (last_name.Text != "")
				{
					Command.CommandText += " AND OTCHECTVO LIKE '" + last_name.Text + "%'";
					LogText += last_name.Text + "|";				
				}

				// № личного дела
				if ( file_num.Text != "" )
				{
					Command.CommandText += " AND NOMLICHDEL = " + Convert.ToInt16(file_num.Text);
					LogText += file_num.Text + "|";				
				}

				Command.CommandText += " ORDER BY FAMILIYA";

				viewDataSet.Clear();
				DataAdapter.Fill(viewDataSet);

				rc = viewDataSet.Tables[0].Rows;

				Grid.DataBind();

				if ( rc.Count != 0 ) // Если кого-то нашли...
				{
					FindLabel.Text = "Найдено " + rc.Count.ToString() + " сотрудников...";

					for( int i=0; i<rc.Count; i++ )
					{
						attDataSet.Clear();
						Command.CommandText = "SELECT slvattosn.NAME, SLVPR2.P1, ATTESTAT.KEY_1, ATTESTAT.DATE_ATT, ATTESTAT.DATE_NEXT, ATTESTAT.OSNOVANIE, ATTESTAT.RESULTAT, ATTESTAT.RECOMEND, ATTESTAT.PRIMECHAN, ATTESTAT.PROTOC_NUM, ATTESTAT.PROTOC_DAT, ATTESTAT.DOC_OSNOV, ATTESTAT.DOC_NUMB, ATTESTAT.DOC_DATE, ATTESTAT.DOC_OVD FROM ATTESTAT, slvattosn, SLVPR2 WHERE ATTESTAT.OSNOVANIE = slvattosn.CODE AND ATTESTAT.DOC_OVD = SLVPR2.P2 AND KEY_1 = " + rc[i]["KEY_1"].ToString();
						DataAdapter.SelectCommand = Command;
						DataAdapter.Fill(attDataSet);
						att = attDataSet.Tables[0].Rows;

						if ( att.Count != 0 )
						{			
							for (int j=0; j<att.Count; j++)
							{
								Grid.Items[i].Cells[7].ForeColor = Color.Indigo;
								Grid.Items[i].Cells[7].Text += "<font color=black >" + (j+1).ToString() + ".)</font> " + 
									Convert.ToDateTime(att[j]["DATE_ATT"]).ToShortDateString() + 
									" - " + att[j]["NAME"].ToString() + " Протокол №" +
									att[j]["PROTOC_NUM"].ToString() + " от " + 
									att[j]["PROTOC_DAT"].ToString() + " г.";
								if ( j < att.Count - 1) Grid.Items[i].Cells[7].Text += "<hr>";
							}
						} 
						else Grid.Items[i].Cells[7].Text = "нет данных";

						att.Clear();
					}
				}
				else FindLabel.Text = "Ничего не найдено, попробуйте с другими параметрами...";
			}

		}

		protected void first_name_TextChanged(object sender, System.EventArgs e)
		{
			if (first_name.Text.Length != 0) 
			{
				string tmp = Convert.ToString(first_name.Text[0]);
				first_name.Text = tmp.ToUpper() + first_name.Text.Substring(1,first_name.Text.Length-1).ToLower();
			}
		}

		protected void name_TextChanged(object sender, System.EventArgs e)
		{
			if (name.Text.Length != 0 )
			{
				string tmp = Convert.ToString(name.Text[0]);
				name.Text = tmp.ToUpper() + name.Text.Substring(1,name.Text.Length-1).ToLower();
			}
		}

		protected void last_name_TextChanged(object sender, System.EventArgs e)
		{
			if (last_name.Text.Length != 0)
			{
				string tmp = Convert.ToString(last_name.Text[0]);
				last_name.Text = tmp.ToUpper() + last_name.Text.Substring(1,last_name.Text.Length-1).ToLower();
			}
		}
	}
}
