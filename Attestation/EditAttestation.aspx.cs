using System;
using System.Data;

namespace kadry.Attestation
{
	/// <summary>
	/// Summary description for EditAttestation.
	/// </summary>
	public class EditAttestation : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected kadry.Attestation.persDataSet persDataSet;
		protected kadry.Attestation.attDataSet attDataSet;
		protected System.Web.UI.WebControls.ImageButton Button_add;
		protected eWorld.UI.MaskedTextBox date_att;
		protected kadry.Attestation.slv_attDataSet slv_attDataSet;
		protected System.Web.UI.WebControls.DropDownList res_att;
		protected System.Web.UI.WebControls.TextBox recomend;
		protected System.Web.UI.WebControls.TextBox comment;
		protected System.Web.UI.WebControls.TextBox prot_number;
		protected eWorld.UI.MaskedTextBox prot_date;
		protected System.Web.UI.WebControls.DropDownList doc_type;
		protected System.Web.UI.WebControls.TextBox doc_number;
		protected eWorld.UI.MaskedTextBox doc_date;
		protected System.Web.UI.WebControls.DropDownList doc_ovd;
		protected kadry.Attestation.pdrDataSet pdrDataSet;
		protected eWorld.UI.MaskedTextBox date_att_next;
		protected System.Web.UI.WebControls.DropDownList osnov_att;
		protected System.Web.UI.WebControls.Label fio;
		protected System.Web.UI.WebControls.ImageButton Button_cancel;
		
		public System.Data.DataRow[] dr;
        public System.Data.DataRowCollection rc;
		public System.DateTime cur_att_date;
		private int id;

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			// Получаем ключ человека...
			id = Convert.ToInt16(Request.QueryString["id"]);
			cur_att_date = Convert.ToDateTime(Request.QueryString["date"]); // текущая дата аттестации...
			
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
				//doc_ovd.SelectedIndex = doc_ovd.Items.IndexOf(doc_ovd.Items.FindByValue("-1"));
				

				// Информация о сотруднике...
				Command.CommandText = "SELECT AAQQ.FAMILIYA, AAQQ.IMYA, AAQQ.OTCHECTVO FROM AAQQ WHERE AAQQ.KEY_1 = " + id.ToString();
				DataAdapter.SelectCommand = Command;
				DataSet ds = new DataSet();
				DataAdapter.Fill(ds);
				rc = ds.Tables[0].Rows;
				fio.Text = (rc[0]["FAMILIYA"].ToString()).ToUpper() + " " + (rc[0]["IMYA"].ToString()).ToUpper() + " " + (rc[0]["OTCHECTVO"].ToString()).ToUpper();

				// Информация об аттестации сотрудника..
				attDataSet.Clear();
				Command.CommandText = "SELECT ATTESTAT.*, slvattosn.NAME, PODRAZD.PODRAZDEL FROM ATTESTAT, slvattosn, PODRAZD WHERE ATTESTAT.OSNOVANIE = slvattosn.CODE AND ATTESTAT.DOC_OVD = PODRAZD.KEY_OF_POD AND KEY_1 = " + id.ToString() + " ORDER BY DATE_ATT";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(attDataSet);
				rc.Clear();
				rc = attDataSet.Tables[0].Rows;

				dr = attDataSet.Tables[0].Select("date_att = '" + cur_att_date.ToShortDateString() + "'");
				date_att.Text = Convert.ToDateTime(dr[0]["DATE_ATT"]).ToShortDateString();
				if ( dr[0]["DATE_NEXT"] != DBNull.Value )
					date_att_next.Text = Convert.ToDateTime(dr[0]["DATE_NEXT"]).ToShortDateString();
				else date_att_next.Text = "";
				osnov_att.Items.FindByText(dr[0]["NAME"].ToString());
				res_att.Items.FindByValue(dr[0]["RESULTAT"].ToString());
				recomend.Text = dr[0]["RECOMEND"].ToString();
				comment.Text = dr[0]["PRIMECHAN"].ToString();
				prot_number.Text = dr[0]["PROTOC_NUM"].ToString();
				if ( dr[0]["PROTOC_DAT"] != DBNull.Value )
					prot_date.Text = Convert.ToDateTime(dr[0]["PROTOC_DAT"]).ToShortDateString();
				else prot_date.Text = "";
				doc_type.Items.FindByText(dr[0]["DOC_OSNOV"].ToString());
				doc_number.Text = dr[0]["DOC_NUMB"].ToString();
				if ( dr[0]["DOC_DATE"] != DBNull.Value )
					doc_date.Text = Convert.ToDateTime(dr[0]["DOC_DATE"]).ToShortDateString();
				else doc_date.Text = "";
				doc_ovd.Items.FindByValue(dr[0]["DOC_OVD"].ToString());
	
			}
			
		}

		public bool CheckData()
		{
			bool res = true;

			if (date_att.Text == "") res = false;

			return res;
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
			this.persDataSet = new kadry.Attestation.persDataSet();
			this.attDataSet = new kadry.Attestation.attDataSet();
			this.slv_attDataSet = new kadry.Attestation.slv_attDataSet();
			this.pdrDataSet = new kadry.Attestation.pdrDataSet();
			((System.ComponentModel.ISupportInitialize)(this.persDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.attDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.slv_attDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pdrDataSet)).BeginInit();
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;DBQ" +
				"=C:\\KADRY;DriverId=277";
			// 
			// Command
			// 
			this.Command.CommandText = "SELECT ATTESTAT.*, slvattosn.NAME, SLVPR2.P1 FROM ATTESTAT, slvattosn, SLVPR2 WHE" +
				"RE ATTESTAT.OSNOVANIE = slvattosn.CODE AND ATTESTAT.DOC_OVD = SLVPR2.P2 ORDER BY" +
				" ATTESTAT.DATE_ATT";
			this.Command.Connection = this.Connection;
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// persDataSet
			// 
			this.persDataSet.DataSetName = "persDataSet";
			this.persDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// attDataSet
			// 
			this.attDataSet.DataSetName = "attDataSet";
			this.attDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// slv_attDataSet
			// 
			this.slv_attDataSet.DataSetName = "slv_attDataSet";
			this.slv_attDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// pdrDataSet
			// 
			this.pdrDataSet.DataSetName = "pdrDataSet";
			this.pdrDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.Button_cancel.Click += new System.Web.UI.ImageClickEventHandler(this.Button_cancel_Click);
			this.Button_add.Click += new System.Web.UI.ImageClickEventHandler(this.Button_add_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.persDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.attDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.slv_attDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pdrDataSet)).EndInit();

		}
		#endregion

		private void Button_add_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if ( CheckData() )
			{
				Command.CommandText = "UPDATE ATTESTAT SET " +
				" DATE_ATT = " + Convert.ToDateTime(date_att.Text).ToOADate() + ",";
				if ( date_att_next.Text == "" ) Command.CommandText += " DATE_NEXT = NULL,";
				else Command.CommandText +=	" DATE_NEXT = " + Convert.ToDateTime(date_att_next.Text).ToOADate() + ",";
				Command.CommandText += " OSNOVANIE = " + osnov_att.SelectedValue + "," +
				" RESULTAT = " + res_att.SelectedValue + "," +
				" RECOMEND = '" + recomend.Text + "'," +
				" PRIMECHAN = '" + comment.Text + "'," + 
				" PROTOC_NUM = '" + prot_number.Text + "',";
				if ( prot_date.Text == "" ) Command.CommandText += " PROTOC_DAT = NULL, ";
				else Command.CommandText +=	" PROTOC_DAT = " + Convert.ToDateTime(prot_date.Text).ToOADate() + ",";
				Command.CommandText += " DOC_OSNOV = '" + doc_type.Items[doc_type.SelectedIndex].Value + "'," +
				" DOC_NUMB = '" + doc_number.Text + "',";
				if ( doc_date.Text == "" ) Command.CommandText += " DOC_DATE = NULL,";
				else Command.CommandText +=	" DOC_DATE = " + Convert.ToDateTime(doc_date.Text).ToOADate() + ",";
				Command.CommandText += " DOC_OVD = " + doc_ovd.SelectedValue + 
				" WHERE (KEY_1 = " + id.ToString() + ") AND (DATE_ATT = " + cur_att_date.ToOADate() + ")";

				if ( Connection.State != ConnectionState.Open ) Connection.Open();
				Command.ExecuteNonQuery();
				Connection.Close();

                //Response.Write("<script>window.alert('Аттестация [" + date_att.Text + "] успешно добавлена!');</script>");
				Response.Redirect("MainAttestation.aspx?id=" + id.ToString() + "&date=" + date_att.Text);
				//else Response.Write("<script> window.confirm('Ошибка добавления аттестации: [" + date_att.Text + "]!');</script>");
			}
			else Response.Write("<script> window.confirm('Неполные данные...');</script>");
			
		}

		private void Button_cancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		  Response.Redirect("MainAttestation.aspx?id=" + id.ToString() + "&date=" + date_att.Text);
		}

	}
}
