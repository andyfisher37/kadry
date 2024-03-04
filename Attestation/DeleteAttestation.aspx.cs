using System;
using System.Data;

namespace kadry.Attestation
{
	/// <summary>
	/// Summary description for DeleteAttestation.
	/// </summary>
	public partial class DeleteAttestation : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected kadry.Attestation.attDataSet attDataSet;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected kadry.Attestation.slv_attDataSet slv_attDataSet;
		protected kadry.Attestation.pdrDataSet pdrDataSet;
	


		public int id;
		public string cur_att_date;
		public System.Data.DataRowCollection rc;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Получаем ключ человека...
			id = Convert.ToInt16(Request.QueryString["id"]);
			cur_att_date = Request.QueryString["date"];

			if (!IsPostBack)
			{

				// Словарь оснований аттестаций...
				Command.CommandText = "SELECT * FROM SLVATTOSN.DBF ORDER BY CODE";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(slv_attDataSet);
				
				// Словарь подразделений...
				Command.CommandText = "SELECT * FROM PODRAZD WHERE (KEY_OF_POD IN (SELECT DISTINCT PODRAZD FROM AAQQ.DBF))";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(pdrDataSet);

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
				
				if ( rc.Count != 0 )
				{
					System.Data.DataRow[] dr = attDataSet.Tables[0].Select("date_att = '" + cur_att_date + "'");
					date_att.Text = Convert.ToDateTime(dr[0]["DATE_ATT"]).ToShortDateString();
					date_att_next.Text = Convert.ToDateTime(dr[0]["DATE_NEXT"]).ToShortDateString();
					System.Data.DataRow[] tdr = slv_attDataSet.Tables[0].Select("NAME = '" + dr[0]["NAME"].ToString() + "'");
					osnov_att.Text = tdr[0]["NAME"].ToString();
					if ( Convert.ToBoolean(dr[0]["RESULTAT"]) )	res_att.Text = "Соответствует";
					else res_att.Text = "Несоответствует";
					recomend.Text = dr[0]["RECOMEND"].ToString();
					comment.Text = dr[0]["PRIMECHAN"].ToString();
					prot_number.Text = dr[0]["PROTOC_NUM"].ToString();
					prot_date.Text = Convert.ToDateTime(dr[0]["PROTOC_DAT"]).ToShortDateString();
					doc_type.Text = dr[0]["DOC_OSNOV"].ToString();
					doc_number.Text = dr[0]["DOC_NUMB"].ToString();
					doc_date.Text = Convert.ToDateTime(dr[0]["DOC_DATE"]).ToShortDateString();
					System.Data.DataRow[] tdr2 = pdrDataSet.Tables[0].Select("KEY_OF_POD = " + dr[0]["DOC_OVD"].ToString());
					doc_ovd.Text = tdr2[0]["PODRAZDEL"].ToString();
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
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.Connection = new System.Data.Odbc.OdbcConnection();
			this.attDataSet = new kadry.Attestation.attDataSet();
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.slv_attDataSet = new kadry.Attestation.slv_attDataSet();
			this.pdrDataSet = new kadry.Attestation.pdrDataSet();
			((System.ComponentModel.ISupportInitialize)(this.attDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.slv_attDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pdrDataSet)).BeginInit();
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
			// attDataSet
			// 
			this.attDataSet.DataSetName = "attDataSet";
			this.attDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
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
			((System.ComponentModel.ISupportInitialize)(this.attDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.slv_attDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pdrDataSet)).EndInit();

		}
		#endregion

		protected void Button_cancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainAttestation.aspx?id=" + id.ToString() + "&date=0");
		}

		protected void Button_delete_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Command.CommandText = "DELETE * FROM ATTESTAT WHERE KEY_1 = " + id.ToString() + " AND DATE_ATT = " + Convert.ToDateTime(cur_att_date).ToOADate();
			if ( Connection.State != ConnectionState.Open) Connection.Open();
			Command.ExecuteNonQuery();
			Response.Write("<script> alert('Запись удалена!'); </script>");
			Response.Redirect("MainAttestation.aspx?id=" + id.ToString() + "&date=0");
		}
	}
}
