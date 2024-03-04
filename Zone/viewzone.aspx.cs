using System;
using System.Data;

namespace UK.Zone
{
	/// <summary>
	/// Summary description for viewzone.
	/// </summary>
	public partial class viewzone : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlConnection sqlConn;
		protected System.Data.SqlClient.SqlCommand Command;
		protected System.Data.Odbc.OdbcConnection odbcConn;
		protected System.Data.Odbc.OdbcCommand oCommand;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected UK.Zone.ovdDataSet ovdDataSet;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                int zonecode = Convert.ToInt16(Request.Params["id"]);

                // ���������� ����...
                switch (zonecode)
                {
                    case 0: Title.Text = "�������� ����"; break;
                    case 1: Title.Text = "����� ����"; break;
                    case 2: Title.Text = "�������� ����"; break;
                    case 3: Title.Text = "��������� ����"; break;
                }

                // ������� ������ ����...
                Command.CommandText = "SELECT Podrazd FROM Zone WHERE ID = " + zonecode.ToString();
                Command.Connection = sqlConn;
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                string podr = (string)Command.ExecuteScalar();

                oCommand.CommandText = "SELECT PODRAZDEL, KEY_OF_POD FROM PODRAZD WHERE KEY_OF_POD IN (" + podr + ")";
                DataAdapter.SelectCommand = oCommand;
                DataAdapter.Fill(ovdDataSet);
                ovdGrid.DataBind();

                int countOVD = 0;       // ���������� ���
                int stat_all = 0;       // ���� �����
                int stat_w_ovo = 0;     // �. �.�. ���� ��� ���
                int stat_ns = 0;        // �. �.�. ���� �/� ��� ���
                int stat_rs = 0;        // �. �.�. ���� �/� ��� ���
                int vak_all = 0;        // ���������� ��������
                int sokr_all = 0;       // ���������� �����������
                double nek_all = 0;     // ���������� �����
                double nek_max = 0;     // ������������ ����������
                double nek_min = 0;     // ����������� ����������

                string zone_keys = "";

                for (int i = 0; i < ovdDataSet.Tables[0].Rows.Count; i++)
                {
                    string ovd_name = ovdGrid.Items[i].Cells[0].Text;
                    string ovd_key = ovdDataSet.Tables[0].Rows[i]["KEY_OF_POD"].ToString();

                    zone_keys += ovd_key;
                    if (i < ovdDataSet.Tables[0].Rows.Count) zone_keys += ",";

                    ovdGrid.Items[i].Cells[0].Text = "<a href='view_ovd.aspx?id=" + ovd_key + "'>" + ovd_name + "</a>";

                    oCommand.CommandText = "SELECT AAQQ.FAMILIYA, AAQQ.IMYA, AAQQ.OTCHECTVO, ZVANIE.VOIN_ZVAN, PHOTOS.PHOTO, AAQQ.DATA_VAK FROM AAQQ, ZVANIE, PHOTOS WHERE AAQQ.SLUZBA = 16 AND AAQQ.DATA_SOKR IS NULL AND AAQQ.ZVANIE = ZVANIE.KEY_ZVAN AND AAQQ.KEY_1 = PHOTOS.KEY_1 AND AAQQ.PODRAZD = " + ovd_key;
                    DataSet ds = new DataSet();
                    DataAdapter.Fill(ds);
                    if (ds.Tables[0].Rows[0]["FAMILIYA"].ToString() != "")
                    {
                        ovdGrid.Items[i].Cells[1].Text = ds.Tables[0].Rows[0]["VOIN_ZVAN"].ToString() + " " + ds.Tables[0].Rows[0]["FAMILIYA"].ToString() + " " + ds.Tables[0].Rows[0]["IMYA"].ToString() + " " + ds.Tables[0].Rows[0]["OTCHECTVO"].ToString();
                        ovdGrid.Items[i].Cells[2].Text = "<a href='view_photo.aspx?id='" + ds.Tables[0].Rows[0]["PHOTO"].ToString().ToLower() + "'><img src='..\\Photobank\\" + ds.Tables[0].Rows[0]["PHOTO"].ToString().ToLower() + "' width='40px' height='60px'/></a>";
                    }
                    else ovdGrid.Items[i].Cells[1].Text = "��������� �������� � " + Convert.ToDateTime(ds.Tables[0].Rows[0]["DATA_VAK"]).ToShortTimeString() + " �.";

                    countOVD++;
                }

                oCommand.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DOLZNOST < '800000' AND DATA_SOKR IS NULL AND PODRAZD IN (" + zone_keys + ")";
                if (odbcConn.State != ConnectionState.Open) odbcConn.Open();
                stat_all = (int)oCommand.ExecuteScalar();

                oCommand.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DOLZNOST < '800000' AND SLUZBA NOT IN (9,52) AND DATA_SOKR IS NULL AND PODRAZD IN (" + zone_keys + ")";
                if (odbcConn.State != ConnectionState.Open) odbcConn.Open();
                stat_w_ovo = (int)oCommand.ExecuteScalar();

                oCommand.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DOLZNOST < '500000' AND SLUZBA NOT IN (9,52) AND DATA_SOKR IS NULL AND PODRAZD IN (" + zone_keys + ")";
                if (odbcConn.State != ConnectionState.Open) odbcConn.Open();
                stat_ns = (int)oCommand.ExecuteScalar();

                oCommand.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE DOLZNOST BETWEEN '500000' AND '800000' AND SLUZBA NOT IN (9,52) AND DATA_SOKR IS NULL AND PODRAZD IN (" + zone_keys + ")";
                if (odbcConn.State != ConnectionState.Open) odbcConn.Open();
                stat_rs = (int)oCommand.ExecuteScalar();

                oCommand.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NULL AND DOLZNOST < '800000' AND DATA_SOKR IS NULL AND PODRAZD IN (" + zone_keys + ")";
                if (odbcConn.State != ConnectionState.Open) odbcConn.Open();
                vak_all = (int)oCommand.ExecuteScalar();

                oCommand.CommandText = "SELECT COUNT(DOLZNOST) FROM AAQQ WHERE FAMILIYA IS NOT NULL AND DOLZNOST < '800000' AND DATA_SOKR IS NOT NULL AND PODRAZD IN (" + zone_keys + ")";
                if (odbcConn.State != ConnectionState.Open) odbcConn.Open();
                sokr_all = (int)oCommand.ExecuteScalar();


                nek_all = Math.Round((Convert.ToSingle(vak_all - sokr_all) / Convert.ToSingle(stat_all) * 100), 1);

                info1.Text = countOVD.ToString() + " ������� ���������� ���";
                info2.Text = stat_all.ToString() + " ��.";
                info21.Text = stat_w_ovo.ToString() + " ��.";
                info22.Text = stat_ns.ToString() + " ��.";
                info23.Text = stat_rs.ToString() + " ��.";
                info3.Text = nek_all.ToString() + " %";

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
			this.sqlConn = new System.Data.SqlClient.SqlConnection();
			this.Command = new System.Data.SqlClient.SqlCommand();
			this.odbcConn = new System.Data.Odbc.OdbcConnection();
			this.oCommand = new System.Data.Odbc.OdbcCommand();
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.ovdDataSet = new UK.Zone.ovdDataSet();
			((System.ComponentModel.ISupportInitialize)(this.ovdDataSet)).BeginInit();
			// 
			// sqlConn
			// 
            this.sqlConn.ConnectionString = "Data Source=COMP2\\SQLEXPRESS;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*";
			// 
			// Command
			// 
			this.Command.Connection = this.sqlConn;
			// 
			// odbcConn
			// 
			this.odbcConn.ConnectionString = "MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=15;DefaultDir=C:\\KADRY;DBQ" +
				"=C:\\KADRY;DriverId=277";
			// 
			// oCommand
			// 
			this.oCommand.CommandText = "SELECT PODRAZDEL, KEY_OF_POD FROM PODRAZD WHERE KEY_OF_POD IN (10,7,24,18,312,20)" +
				"";
			this.oCommand.Connection = this.odbcConn;
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.oCommand;
			// 
			// ovdDataSet
			// 
			this.ovdDataSet.DataSetName = "ovdDataSet";
			this.ovdDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.ovdDataSet)).EndInit();

		}
		#endregion
	}
}
