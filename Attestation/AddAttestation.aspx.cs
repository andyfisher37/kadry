using System;
using System.Data;
using System.Web.Caching;

namespace kadry.Attestation
{
	/// <summary>
	/// Summary description for AddAttestation.
	/// </summary>
	public class AddAttestation : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label fio;
		protected System.Web.UI.WebControls.ImageButton Button_add;
		protected eWorld.UI.MaskedTextBox date_att;
		protected eWorld.UI.MaskedTextBox date_att_next;
		protected System.Web.UI.WebControls.DropDownList osnov_att;
		protected System.Web.UI.WebControls.DropDownList res_att;
		protected System.Web.UI.WebControls.TextBox recomend;
		protected System.Web.UI.WebControls.TextBox comment;
		protected System.Web.UI.WebControls.TextBox prot_number;
		protected System.Web.UI.WebControls.DropDownList doc_type;
		protected eWorld.UI.MaskedTextBox prot_date;
		protected System.Web.UI.WebControls.TextBox doc_number;
		protected eWorld.UI.MaskedTextBox doc_date;
		protected System.Web.UI.WebControls.ImageButton Button_cancel;
		protected kadry.Attestation.attDataSet attDataSet;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected kadry.Attestation.pdrDataSet pdrDataSet;
		protected kadry.Attestation.slv_attDataSet slv_attDataSet;
		protected System.Web.UI.WebControls.DropDownList doc_ovd;
	

		public int id;
		public System.Data.DataRowCollection rc;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Получаем ключ человека...
			id = Convert.ToInt16(Request.QueryString["id"]);
			Cache.Remove("attID");
			Cache.Add( "attID", id, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null );
		
			if (!IsPostBack)
			{
				// Словарь оснований аттестаций...
				Command.CommandText = "SELECT * FROM SLVATTOSN.DBF ORDER BY CODE";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(slv_attDataSet);
				osnov_att.DataBind();
				
				// Словарь подразделений...
				Command.CommandText = "SELECT * FROM PODRAZD WHERE (KEY_OF_POD IN (SELECT DISTINCT PODRAZD FROM AAQQ.DBF))";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(pdrDataSet);
				DataRow row = pdrDataSet.Tables[0].NewRow();
				row["PODRAZDEL"] = "-";
				row["KEY_OF_POD"] = "-1";
				pdrDataSet.Tables[0].Rows.Add(row);
				doc_ovd.DataBind();
				doc_ovd.SelectedIndex = doc_ovd.Items.IndexOf(doc_ovd.Items.FindByValue("-1"));

				// Информация о сотруднике...
				Command.CommandText = "SELECT AAQQ.FAMILIYA, AAQQ.IMYA, AAQQ.OTCHECTVO FROM AAQQ WHERE AAQQ.KEY_1 = " + id.ToString();
				DataAdapter.SelectCommand = Command;
				DataSet ds = new DataSet();
				DataAdapter.Fill(ds);
				rc = ds.Tables[0].Rows;
				fio.Text = (rc[0]["FAMILIYA"].ToString()).ToUpper() + " " + (rc[0]["IMYA"].ToString()).ToUpper() + " " + (rc[0]["OTCHECTVO"].ToString()).ToUpper();

				// Информация об аттестации сотрудника..
				attDataSet.Clear();
				Command.CommandText = "SELECT slvattosn.NAME, SLVPR2.P1, ATTESTAT.KEY_1, ATTESTAT.DATE_ATT, ATTESTAT.DATE_NEXT, ATTESTAT.OSNOVANIE, ATTESTAT.RESULTAT, ATTESTAT.RECOMEND, ATTESTAT.PRIMECHAN, ATTESTAT.PROTOC_NUM, ATTESTAT.PROTOC_DAT, ATTESTAT.DOC_OSNOV, ATTESTAT.DOC_NUMB, ATTESTAT.DOC_DATE, ATTESTAT.DOC_OVD FROM ATTESTAT, slvattosn, SLVPR2 WHERE ATTESTAT.OSNOVANIE = slvattosn.CODE AND ATTESTAT.DOC_OVD = SLVPR2.P2 AND KEY_1 = " + id.ToString() + " ORDER BY DATE_ATT";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(attDataSet);
				rc.Clear();
				rc = attDataSet.Tables[0].Rows;
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
			this.attDataSet = new kadry.Attestation.attDataSet();
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.Connection = new System.Data.Odbc.OdbcConnection();
			this.pdrDataSet = new kadry.Attestation.pdrDataSet();
			this.slv_attDataSet = new kadry.Attestation.slv_attDataSet();
			((System.ComponentModel.ISupportInitialize)(this.attDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pdrDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.slv_attDataSet)).BeginInit();
			this.Button_cancel.Click += new System.Web.UI.ImageClickEventHandler(this.Button_cancel_Click);
			this.Button_add.Click += new System.Web.UI.ImageClickEventHandler(this.Button_add_Click);
			// 
			// attDataSet
			// 
			this.attDataSet.DataSetName = "attDataSet";
			this.attDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// Command
			// 
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;DBQ" +
				"=C:\\KADRY;DriverId=277";
			// 
			// pdrDataSet
			// 
			this.pdrDataSet.DataSetName = "pdrDataSet";
			this.pdrDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// slv_attDataSet
			// 
			this.slv_attDataSet.DataSetName = "slv_attDataSet";
			this.slv_attDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.attDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pdrDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.slv_attDataSet)).EndInit();

		}
		#endregion

		private void Button_cancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if ( id == 0 ) id = (int)Cache["attID"];
			Response.Redirect("MainAttestation.aspx?id=" + id.ToString() + "&date=0");
		}

		private bool CheckData()
		{
			bool result = true;

			if ( date_att.Text == "" ) result = false;
			
			return result;
		}

		private void Button_add_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
				if ( CheckData() )
				{
					if ( id == 0 ) id = (int)Cache["attID"];

					Command.CommandText = "INSERT INTO ATTESTAT (KEY_1, DATE_ATT, DATE_NEXT, OSNOVANIE, RESULTAT, RECOMEND, PRIMECHAN, PROTOC_NUMB, PROTOC_DAT, DOC_OSNOV, DOC_NUMB, DOC_DATE, DOC_OVD) " +
						"VALUES (" + id.ToString() + 
						"," + Convert.ToDateTime(date_att.Text).ToOADate();
					if ( date_att_next.Text == "" ) Command.CommandText += ",NULL";
					else Command.CommandText += "," + Convert.ToDateTime(date_att_next.Text).ToOADate();
					Command.CommandText += "," + osnov_att.SelectedValue + 
						"," + res_att.SelectedValue +
						",'" + recomend.Text + 
						"','" + comment.Text + 
						"','" + prot_number.Text;
					if ( prot_date.Text == "" ) Command.CommandText += "',NULL";
					else Command.CommandText += "'," + Convert.ToDateTime(prot_date.Text).ToOADate();
					Command.CommandText += ",'" + doc_type.Items[doc_type.SelectedIndex].Value + 
						"','" + doc_number.Text;
					if ( doc_date.Text ==  "" ) Command.CommandText += "',NULL";
					else Command.CommandText +=	"'," + Convert.ToDateTime(doc_date.Text).ToOADate();
					Command.CommandText += "," + doc_ovd.SelectedValue + ")";
				
					if ( Connection.State != ConnectionState.Open ) Connection.Open();
					Command.ExecuteNonQuery();
					Connection.Close();

					//Response.Write("<script> window.alert('Аттестация [" + date_att.Text + "] успешно добавлена!'); </script>");
					Response.Redirect("MainAttestation.aspx?id=" + id.ToString() + "&date=" + date_att.Text);
					//else Response.Write("<script> window.confirm('Ошибка добавления аттестации: [" + date_att.Text + "]!');</script>");
				}
				else Response.Write("<script> alert('Неполные данные...'); </script>");
		}
	}
}
