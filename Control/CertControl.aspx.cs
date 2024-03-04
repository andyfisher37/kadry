using System;


namespace kadry.Control
{
	/// <summary>
	/// Summary description for cert_control.
	/// </summary>
	public class cert_control : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label FindLabel;
		protected System.Web.UI.WebControls.ImageButton Btn2;
		protected System.Web.UI.WebControls.ImageButton Btn3;
		protected System.Web.UI.WebControls.ImageButton Btn1;
		protected System.Web.UI.WebControls.DataGrid Grid;
		protected System.Data.Odbc.OdbcCommand SelectCommand;
		protected System.Data.Odbc.OdbcDataAdapter odbcDataAdapter;
		protected System.Data.Odbc.OdbcConnection odbcConnection;
		protected System.Data.SqlClient.SqlConnection sqlConnection;
		protected System.Data.SqlClient.SqlCommand Command;
		protected kadry.Control.certDataSet certDataSet;
		protected kadry.Control.archDataSet archDataSet;
		protected System.Data.SqlClient.SqlDataAdapter DataAdapter;
        protected OboutInc.Calendar2.Calendar Calendar1;
        protected OboutInc.Calendar2.Calendar Calendar2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
                //kadry.Security.Security s = new kadry.Security.Security();

                //if (!s.CheckSecurePage(User.Identity.Name,"cert_control.aspx")) Response.Redirect("\\AccessDenied.htm",true);
                //else s.AddLogText("������ � ��������� ��������� �������������",Context.Request.UserHostAddress,32,true);

				Calendar1.SelectedDate = Convert.ToDateTime("01.01." + System.DateTime.Now.Year.ToString());
                Calendar2.SelectedDate = System.DateTime.Now;
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
			this.DataAdapter = new System.Data.SqlClient.SqlDataAdapter();
			this.Command = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection = new System.Data.SqlClient.SqlConnection();
			this.SelectCommand = new System.Data.Odbc.OdbcCommand();
			this.odbcConnection = new System.Data.Odbc.OdbcConnection();
			this.odbcDataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.certDataSet = new kadry.Control.certDataSet();
			this.archDataSet = new kadry.Control.archDataSet();
			((System.ComponentModel.ISupportInitialize)(this.certDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.archDataSet)).BeginInit();
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// Command
			// 
			this.Command.Connection = this.sqlConnection;
			// 
			// sqlConnection
			// 
			this.sqlConnection.ConnectionString = "packet size=4096;user id=ias_user;data source=kadryR_SERVER;persist security info=Tr" +
				"ue;initial catalog=K2_certificate;password=*";
			// 
			// SelectCommand
			// 
			this.SelectCommand.Connection = this.odbcConnection;
			// 
			// odbcConnection
			// 
			this.odbcConnection.ConnectionString = "PageTimeout=0;FIL=dBase 5.0;MaxBufferSize=2048;DSN=KADRY;DefaultDir=C:\\KADRY;Driv" +
				"erId=533";
			// 
			// odbcDataAdapter
			// 
			this.odbcDataAdapter.SelectCommand = this.SelectCommand;
			// 
			// certDataSet
			// 
			this.certDataSet.DataSetName = "certDataSet";
			this.certDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// archDataSet
			// 
			this.archDataSet.DataSetName = "archDataSet";
			this.archDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.Btn1.Click += new System.Web.UI.ImageClickEventHandler(this.Btn1_Click);
			this.Btn2.Click += new System.Web.UI.ImageClickEventHandler(this.Btn2_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.certDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.archDataSet)).EndInit();

		}
		#endregion


		public bool IsLowZvan( int code )
		{
			if ( (code >= 20 && code <= 26) || (code >= 40 && code <= 46) || (code >= 60 && code <= 66) || (code == 99) || (code == 0) ) return true;
			else return false;
		}

		private void Btn1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			
			archDataSet.Clear();

			// ���������...

			SelectCommand.CommandText = "SELECT ZVANIE, FAMILIYA, IMYA, OTCHECTVO, KEY_1, LICH_NOM_1, DATA_UVOL, LICH_NOM_2, PRICH_UV AS STATUS, PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN FROM ARCHIVE, PODRAZD, SLUZBA, OFIC_DOL, ZVANIE WHERE PODRAZD = PODRAZD.KEY_OF_POD AND SLUZBA = SLUZBA.KEY_OF_SLU AND REAL_DOLZN = OFIC_DOL.P3 AND ZVANIE = ZVANIE.KEY_ZVAN AND (ZVANIE NOT IN (77, 78, 94, 95, 96, 97, 98)) AND (REAL_DOLZN < '800000') AND (DATA_UVOL >= " + Calendar1.SelectedDate.ToOADate() + " ) AND (KEY_1 <> 0) ORDER BY PODRAZD, PODR, FAMILIYA";
			odbcDataAdapter.SelectCommand = SelectCommand;
			odbcDataAdapter.Fill(archDataSet);

			// �����������������...
            SelectCommand.CommandText = "SELECT ZVANIE, FAMILIYA, IMYA, OTCHECTVO, KEY_1, LICH_NOM_1, DATA_UVOL, LICH_NOM_2, PLACE AS STATUS, PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN FROM VYEZD, PODRAZD, SLUZBA, OFIC_DOL, ZVANIE WHERE PODRAZD = PODRAZD.KEY_OF_POD AND SLUZBA = SLUZBA.KEY_OF_SLU AND REAL_DOLZN = OFIC_DOL.P3 AND ZVANIE = ZVANIE.KEY_ZVAN AND (ZVANIE NOT IN (77, 78, 94, 95, 96, 97, 98)) AND (REAL_DOLZN < '800000') AND (DATA_UVOL >= " + Calendar1.SelectedDate.ToOADate() + ") AND (KEY_1 <> 0) ORDER BY PODRAZD, PODR, FAMILIYA";
			odbcDataAdapter.SelectCommand = SelectCommand;
			odbcDataAdapter.Fill(archDataSet);

			int acount = archDataSet.Tables[0].Rows.Count;

			for( int i = 0; i < acount; i++ )
			{
				Command.CommandText = "SELECT person.first_name, person.last_name, person.middle_name, crt_blank.blank_serie, crt_blank.blank_number, crt_certificate.date_created, crt_state.description FROM person INNER JOIN crt_certificate ON person.id_person = crt_certificate.id_person INNER JOIN crt_blank ON crt_certificate.id_blank = crt_blank.id_blank INNER JOIN crt_state ON crt_certificate.id_state = crt_state.id_state WHERE (crt_certificate.id_state NOT IN (4, 5, 6, 9))";
				certDataSet.Clear();

				if ( IsLowZvan(Convert.ToInt16(archDataSet.Tables[0].Rows[i]["ZVANIE"])) )
					Command.CommandText += " AND (person.first_name = '" + archDataSet.Tables[0].Rows[i]["FAMILIYA"].ToString() +
					"') AND (person.last_name = '" + archDataSet.Tables[0].Rows[i]["IMYA"].ToString() +
					"') AND (person.middle_name = '" + archDataSet.Tables[0].Rows[i]["OTCHECTVO"].ToString() + 
					"') AND (person.personal_number = '" + archDataSet.Tables[0].Rows[i]["LICH_NOM_1"].ToString() + "-" + archDataSet.Tables[0].Rows[i]["LICH_NOM_2"].ToString() + "')";
				else Command.CommandText += " AND (person.personal_number = '" + archDataSet.Tables[0].Rows[i]["LICH_NOM_1"].ToString() + "-" + archDataSet.Tables[0].Rows[i]["LICH_NOM_2"].ToString() + "')";
			
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(certDataSet);
				int ccount = certDataSet.Tables[0].Rows.Count;
				if ( ccount > 0 )
				{
					for( int j=0; j< ccount; j++)
					{
						if ( Convert.ToDateTime(certDataSet.Tables[0].Rows[j]["date_created"]) > Convert.ToDateTime(archDataSet.Tables[0].Rows[i]["data_uvol"]) ) archDataSet.Tables[0].Rows[i]["certificate"] = "-";
						else archDataSet.Tables[0].Rows[i]["certificate"] += "��� � " + 
							 certDataSet.Tables[0].Rows[j]["blank_number"].ToString() + 
							 " �� " + Convert.ToDateTime(certDataSet.Tables[0].Rows[j]["date_created"]).ToShortDateString() + 
							 " (" + certDataSet.Tables[0].Rows[j]["description"].ToString()+ ") <br>";
					}

				} else archDataSet.Tables[0].Rows[i]["certificate"] = "-";
      			
			}

			Grid.DataBind();
			int count = acount;
			for( int i = 0; i < acount; i++ )
			{
				string status = archDataSet.Tables[0].Rows[i]["STATUS"].ToString();

				if ( status[0] != Convert.ToChar("1") )  Grid.Items[i].Cells[5].Text = "��������������";
				else if ( status == "1021" || status == "1010" )
				{
					Grid.Items[i].Cells[5].Text = "���� (�����)";
				} else Grid.Items[i].Cells[5].Text = "������";  

				if ( archDataSet.Tables[0].Rows[i]["certificate"].ToString() == "-" )
				{
					Grid.Items[i].Visible = false;
					count--;
				} else Grid.Items[i].Cells[8].Text += "-" + archDataSet.Tables[0].Rows[i]["LICH_NOM_2"].ToString();
			}

			FindLabel.Text = "�� " + acount.ToString() + " �����������, �� ��������� ������ ������� �������������: " + count.ToString();
		}

		private void Btn2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
//			System.DateTime today = System.DateTime.Now;
//
//			Command.CommandText = "select person.first_name, person.last_name, person.middle_name, person.personal_number, crt_blank.blank_number, crt_certificate.date_created, crt_state.description from dbo.person " +
//								  "inner join dbo.crt_certificate on person.id_person = crt_certificate.id_person " +
//								  "inner join dbo.crt_state on crt_certificate.id_state = crt_state.id_state " +
//								  "inner join dbo.crt_blank on crt_certificate.id_blank = crt_blank.id_blank " +
//								  "where crt_certificate.id_state not in (4,5,6,9) and crt_certificate.acts_before <= { d '" + today.Year.ToString() + "-" + today.Month.ToString() + "-" + today.Day.ToString() + "' }";
//
//			certDataSet.Clear();
//			DataAdapter.SelectCommand = Command;
//			DataAdapter.Fill(certDataSet);
//
//			Grid.DataBind();
//
//			int count = certDataSet.Tables[0].Rows.Count;
//
//			if ( count > 0 )
//			{
//				Grid.
//
//
//			} else FindLabel.Text = "�� ��������� �� " + today.ToShortDateString() + " ������������ ������������� ���!";

		
		}
	}
}
