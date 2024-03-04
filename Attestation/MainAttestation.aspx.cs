using System;
using System.Data;

namespace kadry.Attestation
{
	/// <summary>
	/// Summary description for MainAttestation.
	/// </summary>
	public partial class MainAttestation : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected kadry.Attestation.slv_attDataSet slv_attDataSet;
		protected kadry.Attestation.pdrDataSet pdrDataSet;
		protected kadry.Attestation.persDataSet persDataSet;
		protected kadry.Attestation.attDataSet attDataSet;


		private int id;
		public System.Data.DataRow[] dr;
		public System.Data.DataRowCollection rc;
		public string cur_att_date;


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
				DataRow row = pdrDataSet.Tables[0].NewRow();
				row["PODRAZDEL"] = "-";
				row["KEY_OF_POD"] = "-1";
				pdrDataSet.Tables[0].Rows.Add(row);

				
				// Информация о сотруднике...
				Command.CommandText = "SELECT AAQQ.FAMILIYA, AAQQ.IMYA, AAQQ.OTCHECTVO, AAQQ.DATA_ROZD, ZVANIE.VOIN_ZVAN, " +
					"PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, AAQQ.DATA_PRSV, AAQQ.DATA_POST, " +
					"AAQQ.DATA_VDOLZ, AAQQ.VREMI_V_SL, AAQQ.NOMLICHDEL, AAQQ.LICH_NOM_1, AAQQ.LICH_NOM_2, " +
					"AAQQ.N_PR_ZVAN1, AAQQ.DT_PR_DOLZ, AAQQ.DATA_PR_ZV, AAQQ.N_PR_VDOLZ FROM AAQQ, ZVANIE, " +
					"PODRAZD, SLUZBA, OFIC_DOL WHERE AAQQ.ZVANIE = ZVANIE.KEY_ZVAN AND AAQQ.PODRAZD = PODRAZD.KEY_OF_POD AND AAQQ.SLUZBA = SLUZBA.KEY_OF_SLU AND AAQQ.REAL_DOLZN = OFIC_DOL.P3 " +
					" AND AAQQ.KEY_1 = " + id.ToString();
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(persDataSet);
				rc = persDataSet.Tables[0].Rows;
				if ( rc.Count != 0 )
				{
					first_name.Text = rc[0]["FAMILIYA"].ToString();
					name.Text = rc[0]["IMYA"].ToString();
					last_name.Text = rc[0]["OTCHECTVO"].ToString();
					p_number.Text = rc[0]["LICH_NOM_1"].ToString() + "-" + rc[0]["LICH_NOM_2"].ToString();
					zvanie.Text = rc[0]["VOIN_ZVAN"].ToString();
					podrazd.Text = rc[0]["PODRAZDEL"].ToString();
					sluzba.Text = rc[0]["NAM_OF_SLU"].ToString();
					dolznost.Text = rc[0]["NAM_OF_DOL"].ToString();
					if ( rc[0]["NOMLICHDEL"].ToString() != "" )	file_number.Text = rc[0]["NOMLICHDEL"].ToString();
					else 	file_number.Text = "-";
					zvan_data.Text = "с " + Convert.ToDateTime(rc[0]["DATA_PRSV"]).ToShortDateString() + " Пр.№ " + rc[0]["N_PR_ZVAN1"].ToString() + " от " + Convert.ToDateTime(rc[0]["DATA_PR_ZV"]).ToShortDateString();
					dolz_data.Text = "с " + Convert.ToDateTime(rc[0]["DATA_VDOLZ"]).ToShortDateString() + " Пр.№ " + rc[0]["N_PR_VDOLZ"].ToString() + " от " + Convert.ToDateTime(rc[0]["DT_PR_DOLZ"]).ToShortDateString();
					data_post.Text = Convert.ToDateTime(rc[0]["DATA_POST"]).ToShortDateString();
					sluz_data.Text = Convert.ToDateTime(rc[0]["VREMI_V_SL"]).ToShortDateString();

				}
				// Информация об аттестациях сотрудника..
				attDataSet.Clear();
				Command.CommandText = "SELECT slvattosn.NAME, SLVPR2.P1, ATTESTAT.KEY_1, ATTESTAT.DATE_ATT, ATTESTAT.DATE_NEXT, ATTESTAT.OSNOVANIE, ATTESTAT.RESULTAT, ATTESTAT.RECOMEND, ATTESTAT.PRIMECHAN, ATTESTAT.PROTOC_NUM, ATTESTAT.PROTOC_DAT, ATTESTAT.DOC_OSNOV, ATTESTAT.DOC_NUMB, ATTESTAT.DOC_DATE, ATTESTAT.DOC_OVD FROM ATTESTAT, slvattosn, SLVPR2 WHERE ATTESTAT.OSNOVANIE = slvattosn.CODE AND ATTESTAT.DOC_OVD = SLVPR2.P2 AND KEY_1 = " + id.ToString() + " ORDER BY DATE_ATT";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(attDataSet);
				rc.Clear();
				rc = attDataSet.Tables[0].Rows;
				Grid.DataBind();

				if ( rc.Count != 0 )
				{
					//cur_att_date = rc[0]["DATE_ATT"].ToString();
					for( int i = 0; i<rc.Count; i++ )
					{
						Grid.Items[i].Cells[0].Text = "<a href='MainAttestation.aspx?id=" + id.ToString() + "&date=" + Convert.ToDateTime(rc[i]["DATE_ATT"]).ToShortDateString() + "'>" + Convert.ToDateTime(rc[i]["DATE_ATT"]).ToShortDateString() + "</a>"; 
						if ( Convert.ToBoolean(rc[i]["RESULTAT"]) ) Grid.Items[i].Cells[3].Text = "Соответствует";
						else Grid.Items[i].Cells[3].Text = "Не соответствует";
					}
				}
				
				if ( cur_att_date != "0" )
				{
					dr = attDataSet.Tables[0].Select("date_att = '" + cur_att_date + "'");
					date_att.Text = Convert.ToDateTime(dr[0]["DATE_ATT"]).ToShortDateString();
					if ( dr[0]["DATE_NEXT"] != DBNull.Value )
					date_att_next.Text = Convert.ToDateTime(dr[0]["DATE_NEXT"]).ToShortDateString();
					else date_att_next.Text = "";
					System.Data.DataRow[] tdr = slv_attDataSet.Tables[0].Select("NAME = '" + dr[0]["NAME"].ToString() + "'");
					osnov_att.Text = tdr[0]["NAME"].ToString();
					if ( Convert.ToBoolean(dr[0]["RESULTAT"]) )	res_att.Text = "Соответствует";
					else res_att.Text = "Несоответствует";
					recomend.Text = dr[0]["RECOMEND"].ToString();
					comment.Text = dr[0]["PRIMECHAN"].ToString();
					prot_number.Text = dr[0]["PROTOC_NUM"].ToString();
					if ( dr[0]["PROTOC_DAT"] != DBNull.Value )
					prot_date.Text = Convert.ToDateTime(dr[0]["PROTOC_DAT"]).ToShortDateString();
					else prot_date.Text = "";
					doc_type.Text = dr[0]["DOC_OSNOV"].ToString();
					doc_number.Text = dr[0]["DOC_NUMB"].ToString();
					if ( dr[0]["DOC_DATE"] != DBNull.Value )
					doc_date.Text = Convert.ToDateTime(dr[0]["DOC_DATE"]).ToShortDateString();
					else doc_date.Text = "";
					System.Data.DataRow[] tdr2 = pdrDataSet.Tables[0].Select("KEY_OF_POD = " + dr[0]["DOC_OVD"].ToString());
					doc_ovd.Text = tdr2[0]["PODRAZDEL"].ToString();
				} 
				else
				{
					date_att.Text = "-";
					date_att_next.Text = "-";
					osnov_att.Text = "-";
					res_att.Text = "-";
					recomend.Text = "-";
					comment.Text = "-";
					prot_number.Text = "-";
					prot_date.Text = "-";
					doc_type.Text = "-";
					doc_number.Text = "-";
					doc_date.Text = "-";
					doc_ovd.Text = "-";
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
			this.Connection = new System.Data.Odbc.OdbcConnection();
			this.slv_attDataSet = new kadry.Attestation.slv_attDataSet();
			this.pdrDataSet = new kadry.Attestation.pdrDataSet();
			this.persDataSet = new kadry.Attestation.persDataSet();
			this.attDataSet = new kadry.Attestation.attDataSet();
			((System.ComponentModel.ISupportInitialize)(this.slv_attDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pdrDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.persDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.attDataSet)).BeginInit();
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// Command
			// 
			this.Command.CommandText = "SELECT * FROM PODRAZD WHERE (KEY_OF_POD IN (SELECT DISTINCT PODRAZD FROM AAQQ.DBF" +
				"))";
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;DBQ" +
				"=C:\\KADRY;DriverId=277";
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
			((System.ComponentModel.ISupportInitialize)(this.slv_attDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pdrDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.persDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.attDataSet)).EndInit();

		}
		#endregion

		protected void Button_delete_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if ( cur_att_date != "0" )
			{
				Response.Redirect("DeleteAttestation.aspx?id=" + id.ToString() + "&date=" + cur_att_date);
			} 
			else Response.Write("<script> alert('Выберите аттестацию для удаления!'); </script>");
		}

		protected void Button_add_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("AddAttestation.aspx?id=" + id.ToString());
		}

		protected void Button_change_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if ( cur_att_date != "0" )
			{
				Response.Redirect("EditAttestation.aspx?id=" + id.ToString() + "&date=" + cur_att_date);
			} 
			else Response.Write("<script> alert('Выберите аттестацию для изменения!'); </script>");

		}
	}
}
