using System;
using System.Data;
using System.Web.UI.WebControls;

namespace kadry.Nekompl
{
	/// <summary>
	/// Summary description for nek_svod.
	/// </summary>
	public partial class nek_svod : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcCommand Command;
		protected kadry.Nekompl.podrDataSet podrDataSet;
		protected kadry.Nekompl.workDataSet workDataSet;
		protected kadry.Nekompl.podchDataSet podchDataSet;



		public System.Data.DataRowCollection rc;
		public System.Data.DataRowCollection podr;
		public System.Data.DataRowCollection podch;
		public System.Data.DataRowCollection rc1;

		public struct TPodrazd
		{
			public string NamePodr;
			public int CodePodr;
			public int s_all;
			public int s_ns;
			public int s_rs;
			public int sokr_all;
			public int n_all;
			public double n_all_p;
			public int n_ns;
			public int sokr_ns;
			public double n_ns_p;
			public int n_rs;
			public int sokr_rs;
			public double n_rs_p;
		}


		public struct TPodch
		{
			public string NamePodr;
			public int CodePodr;
			public int s_all;
			public int s_ns;
			public int s_rs;
			public int sokr_all;
			public int n_all;
			public double n_all_p;
			public int n_ns;
			public int sokr_ns;
			public double n_ns_p;
			public int n_rs;
			public int sokr_rs;
			public double n_rs_p;
		}
	

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				Calculate();	
			}
		}

		private void Calculate()
		{
			TitleText.Text = "Сведения об укомплектованости ГРУОВД Ивановской области, по состоянию на <font color='red'>" + System.DateTime.Now.ToShortDateString() + "</font>";

			podrDataSet.Clear();
			Command.CommandText = "SELECT KEY_OF_POD, PODRAZDEL FROM PODRAZD.DBF WHERE KEY_OF_POD IN (SELECT DISTINCT PODRAZD FROM AAQQ.DBF) ORDER BY KEY_OF_POD";
			DataAdapter.SelectCommand = Command;
			DataAdapter.Fill(podrDataSet);
			podr = podrDataSet.Tables[0].Rows;
			DataRow row = podrDataSet.Tables[0].NewRow();
			row[0] = "0";
			row[1] = "Аппарат УВД (без подч.)";
			podr.InsertAt(row,0);
			
			podchDataSet.Clear();
			Command.CommandText = "SELECT KEY_OF_NAI, NAIMENOVAN FROM NAIMEN.DBF WHERE KEY_OF_NAI IN (SELECT PODR FROM AAQQ.DBF WHERE PODRAZD = 1 AND PODR <> 9 ";
			if ( !CheckVN.Checked ) Command.CommandText += " AND DOLZNOST < '800000'";  // Без в/н
			if ( CheckOVO.Checked ) Command.CommandText += " AND SLUZBA NOT IN (9,52)"; // Без ОВО
            Command.CommandText += " ) ORDER BY KEY_OF_NAI";
			DataAdapter.SelectCommand = Command;
			DataAdapter.Fill(podchDataSet);
			podch = podchDataSet.Tables[0].Rows;

			TPodrazd[] podrazd = new TPodrazd[podr.Count + 1]; // +1 -аппарат УВД без подчин.
			TPodch[] podchin = new TPodch[podch.Count];

			BuildPodr(podrazd);
			BuildPodch(podchin);

		}


		private void BuildPodr( TPodrazd[] podrazd )
		{
			for( int i = 0; i < podr.Count; i++)
			{
				workDataSet.Clear();
				if ( Convert.ToInt16(podr[i]["KEY_OF_POD"]) == 0 )
				{
					Command.CommandText = "SELECT FAMILIYA, DOLZNOST, DATA_SOKR FROM Aaqq.dbf WHERE PODRAZD = 1 AND PODR = 9 ";
				} 
				else Command.CommandText = "SELECT FAMILIYA, DOLZNOST, DATA_SOKR FROM Aaqq.dbf WHERE PODRAZD = " + podr[i]["KEY_OF_POD"].ToString();

				if ( !CheckVN.Checked ) Command.CommandText += " AND DOLZNOST < '800000'";  // Без в/н
				if ( CheckOVO.Checked ) Command.CommandText += " AND SLUZBA NOT IN (9,52)"; // Без ОВО
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(workDataSet);
				rc = workDataSet.Tables[0].Rows;

				podrazd[i].CodePodr = Convert.ToInt16(podr[i]["KEY_OF_POD"]);	// Код подразделения
				if ( Convert.ToInt16(podr[i]["KEY_OF_POD"]) == 1 ) podrazd[i].NamePodr = "Аппарат УВД (с подч.)";
				else podrazd[i].NamePodr = podr[i]["PODRAZDEL"].ToString();			// Наименование
				podrazd[i].s_all = rc.Count;									// Общий штат
				podrazd[i].sokr_all = 0;
				podrazd[i].sokr_ns = 0;
				podrazd[i].sokr_rs = 0;
				podrazd[i].s_ns = 0;
				podrazd[i].s_rs = 0;
				podrazd[i].n_all = 0;
				podrazd[i].n_all_p = 0;
				podrazd[i].n_ns_p = 0;
				podrazd[i].n_rs_p = 0;
				podrazd[i].n_ns = 0;
				podrazd[i].n_rs = 0;

				for( int j = 0; j<rc.Count; j++ )
				{
					int dol = Convert.ToInt16((rc[j]["DOLZNOST"].ToString()).Substring(0,1));
						
					// Штат н/с
					if ( dol <= 4 && rc[j]["DATA_SOKR"] == DBNull.Value ) podrazd[i].s_ns++;
					// Штат р/с
					if ( dol >= 5 && rc[j]["DATA_SOKR"] == DBNull.Value ) podrazd[i].s_rs++;
					// Должность сокращена
					if ( rc[j]["DATA_SOKR"] != DBNull.Value )
					{
						podrazd[i].s_all--;
						if ( rc[j]["FAMILIYA"] != DBNull.Value ) 
						{
							podrazd[i].sokr_all++;
							if ( dol <= 4 ) podrazd[i].sokr_ns++;
							if ( dol >= 5 ) podrazd[i].sokr_rs++;
						}
					}
					// Нек-т всего
					if ( rc[j]["FAMILIYA"].ToString() == "" && rc[j]["DATA_SOKR"] == DBNull.Value ) { podrazd[i].n_all++; }
					// Нек-т н/с
					if ( rc[j]["FAMILIYA"].ToString() == "" && rc[j]["DATA_SOKR"] == DBNull.Value && dol <= 4 ) { podrazd[i].n_ns++; }
					// Нек-т р/с
					if ( rc[j]["FAMILIYA"].ToString() == "" && rc[j]["DATA_SOKR"] == DBNull.Value && dol >= 5 ) { podrazd[i].n_rs++; }

				}

				podrazd[i].n_all = -1 * podrazd[i].n_all + podrazd[i].sokr_all;
				podrazd[i].n_ns = (-1) * podrazd[i].n_ns + podrazd[i].sokr_ns;
				podrazd[i].n_rs = (-1) * podrazd[i].n_rs + podrazd[i].sokr_rs;
				podrazd[i].n_all_p = (Convert.ToDouble(podrazd[i].n_all)/Convert.ToDouble(podrazd[i].s_all)) * 100;
				podrazd[i].n_ns_p = (Convert.ToDouble(podrazd[i].n_ns)/Convert.ToDouble(podrazd[i].s_ns)) * 100;
				podrazd[i].n_rs_p = (Convert.ToDouble(podrazd[i].n_rs)/Convert.ToDouble(podrazd[i].s_rs)) * 100;
			}

			// Шапка
			TableRow row1 = new TableRow();
			TableCell cell1 = new TableCell();
			cell1.Text = " Подразделение ";
			cell1.HorizontalAlign = HorizontalAlign.Center;
			cell1.Attributes.Add("class","label2");
			row1.Cells.Add(cell1);

			TableCell cell2 = new TableCell();
			cell2.Text = " Штат всего ";
			cell2.HorizontalAlign = HorizontalAlign.Center;
			cell2.Attributes.Add("class","label2");
			row1.Cells.Add(cell2);

			TableCell cell3 = new TableCell();
			cell3.Text = " Штат н/с ";
			cell3.HorizontalAlign = HorizontalAlign.Center;
			cell3.Attributes.Add("class","label2");
			row1.Cells.Add(cell3);

			TableCell cell4 = new TableCell();
			cell4.Text = " Штат р/с ";
			cell4.HorizontalAlign = HorizontalAlign.Center;
			cell4.Attributes.Add("class","label2");
			row1.Cells.Add(cell4);

			TableCell cell5 = new TableCell();
			cell5.Text = " Нек-т всего ";
			cell5.HorizontalAlign = HorizontalAlign.Center;
			cell5.Attributes.Add("class","label2");
			row1.Cells.Add(cell5);

			TableCell cell6 = new TableCell();
			cell6.Text = " Нек-т н/с ";
			cell6.HorizontalAlign = HorizontalAlign.Center;
			cell6.Attributes.Add("class","label2");
			row1.Cells.Add(cell6);

			TableCell cell7 = new TableCell();
			cell7.Text = " Нек-т р/с ";
			cell7.HorizontalAlign = HorizontalAlign.Center;
			cell7.Attributes.Add("class","label2");
			row1.Cells.Add(cell7);
			
			Table.Rows.Add(row1);
			Table.CellPadding = 0;
			Table.CellSpacing = 0;

			for( int i = 0; i < podr.Count; i++)
			{
				TableRow r = new TableRow();
				// Наименование
				TableCell c1 = new TableCell();
				c1.Text = "&nbsp<a href='vak_detail.aspx?code=" + podrazd[i].CodePodr + "&name=" + podrazd[i].NamePodr;
				if ( !CheckVN.Checked ) c1.Text += "&vn=0";
				else c1.Text += "&vn=1";
				if ( CheckOVO.Checked ) c1.Text += "&ovo=0";
				else c1.Text += "&ovo=1";
				c1.Text += "'>" + podrazd[i].NamePodr + "</a>";
				c1.Attributes.Add("class","label");
				r.Cells.Add(c1);
				// Общий штат
				TableCell c2 = new TableCell();
				c2.Text = podrazd[i].s_all.ToString();
				c2.HorizontalAlign = HorizontalAlign.Center;
				c2.Attributes.Add("class","stable");
				r.Cells.Add(c2);
				// штат н/с
				TableCell c3 = new TableCell();
				c3.Text = podrazd[i].s_ns.ToString();
				c3.HorizontalAlign = HorizontalAlign.Center;
				c3.Attributes.Add("class","stable");
				r.Cells.Add(c3);
				// штат р/с
				TableCell c4 = new TableCell();
				c4.Text = podrazd[i].s_rs.ToString();
				c4.HorizontalAlign = HorizontalAlign.Center;
				c4.Attributes.Add("class","stable");
				r.Cells.Add(c4);
				// Нек-т всего
				TableCell c5 = new TableCell();
				c5.Text = podrazd[i].n_all.ToString();
				if ( podrazd[i].n_all_p != 0 ) c5.Text += " (" + ((-1)*podrazd[i].n_all_p).ToString("##.#") + "%) ";
				c5.HorizontalAlign = HorizontalAlign.Center;
				c5.Attributes.Add("class","stable");
				r.Cells.Add(c5);
				// Нек-т н/с
				TableCell c6 = new TableCell();
				c6.Text = podrazd[i].n_ns.ToString();
				if ( podrazd[i].n_ns_p != 0 ) c6.Text += " (" + ((-1)*podrazd[i].n_ns_p).ToString("##.#") + "%) ";;
				c6.HorizontalAlign = HorizontalAlign.Center;
				c6.Attributes.Add("class","stable");
				r.Cells.Add(c6);
				// Нек-т р/с
				TableCell c7 = new TableCell();
				c7.Text = podrazd[i].n_rs.ToString();
				if ( podrazd[i].n_rs_p != 0 ) c7.Text += " (" + ((-1)*podrazd[i].n_rs_p).ToString("##.#") + "%) ";;
				c7.HorizontalAlign = HorizontalAlign.Center;
				c7.Attributes.Add("class","stable");
				r.Cells.Add(c7);
									
				Table.Rows.Add(r);
			}
		}
	

		private void BuildPodch( TPodch[] podchin )
		{
		
			for( int i = 0; i < podch.Count; i++)
			{
				workDataSet.Clear();
				Command.CommandText = "SELECT FAMILIYA, DOLZNOST, DATA_SOKR FROM Aaqq.dbf WHERE PODRAZD = 1 AND PODR = " + podch[i]["KEY_OF_NAI"].ToString();
				if ( !CheckVN.Checked ) Command.CommandText += " AND DOLZNOST < '800000'";  // Без в/н
				if ( CheckOVO.Checked ) Command.CommandText += " AND SLUZBA NOT IN (9,52)"; // Без ОВО
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(workDataSet);
				rc1 = workDataSet.Tables[0].Rows;

				podchin[i].CodePodr = Convert.ToInt16(podch[i]["KEY_OF_NAI"]);	// Код подразделения
				podchin[i].NamePodr = podch[i]["NAIMENOVAN"].ToString();		// Наименование
				podchin[i].s_all = rc1.Count;									// Общий штат
				podchin[i].sokr_all = 0;
				podchin[i].sokr_ns = 0;
				podchin[i].sokr_rs = 0;
				podchin[i].s_ns = 0;
				podchin[i].s_rs = 0;
				podchin[i].n_all = 0;
				podchin[i].n_all_p = 0;
				podchin[i].n_ns_p = 0;
				podchin[i].n_rs_p = 0;
				podchin[i].n_ns = 0;
				podchin[i].n_rs = 0;

				for( int j = 0; j<rc1.Count; j++ )
				{
					int dol = Convert.ToInt16((rc1[j]["DOLZNOST"].ToString()).Substring(0,1));
						
					// Штат н/с
					if ( dol <= 4 && rc1[j]["DATA_SOKR"] == DBNull.Value ) podchin[i].s_ns++;
					// Штат р/с
					if ( dol >= 5 && rc1[j]["DATA_SOKR"] == DBNull.Value ) podchin[i].s_rs++;
					// Должность сокращена
					if ( rc1[j]["DATA_SOKR"] != DBNull.Value )
					{
						podchin[i].s_all--;
						if ( rc1[j]["FAMILIYA"] != DBNull.Value ) 
						{
							podchin[i].sokr_all++;
							if ( dol <= 4 ) podchin[i].sokr_ns++;
							if ( dol >= 5 ) podchin[i].sokr_rs++;
						}
					}
					// Нек-т всего
					if ( rc1[j]["FAMILIYA"].ToString() == "" && rc1[j]["DATA_SOKR"] == DBNull.Value ) { podchin[i].n_all++; }
					// Нек-т н/с
					if ( rc1[j]["FAMILIYA"].ToString() == "" && rc1[j]["DATA_SOKR"] == DBNull.Value && dol <= 4 ) { podchin[i].n_ns++; }
					// Нек-т р/с
					if ( rc1[j]["FAMILIYA"].ToString() == "" && rc1[j]["DATA_SOKR"] == DBNull.Value && dol >= 5 ) { podchin[i].n_rs++; }

				}

				podchin[i].n_all = -1 * podchin[i].n_all + podchin[i].sokr_all;
				podchin[i].n_ns = (-1) * podchin[i].n_ns + podchin[i].sokr_ns;
				podchin[i].n_rs = (-1) * podchin[i].n_rs + podchin[i].sokr_rs;
				if ( podchin[i].s_all == 0 ) podchin[i].n_all_p = 0;
				else podchin[i].n_all_p = (Convert.ToDouble(podchin[i].n_all)/Convert.ToDouble(podchin[i].s_all)) * 100;
				if ( podchin[i].s_ns == 0 ) podchin[i].n_ns_p = 0;
				else podchin[i].n_ns_p = (Convert.ToDouble(podchin[i].n_ns)/Convert.ToDouble(podchin[i].s_ns)) * 100;
				if ( podchin[i].s_rs == 0 ) podchin[i].n_rs_p = 0;
				else podchin[i].n_rs_p = (Convert.ToDouble(podchin[i].n_rs)/Convert.ToDouble(podchin[i].s_rs)) * 100;
			}

			// Шапка
			TableRow row1 = new TableRow();

			TableCell cell1 = new TableCell();
			cell1.Text = " Подразделение ";
			cell1.HorizontalAlign = HorizontalAlign.Center;
			cell1.Attributes.Add("class","label2");
			row1.Cells.Add(cell1);

			TableCell cell2 = new TableCell();
			cell2.Text = " Штат всего ";
			cell2.HorizontalAlign = HorizontalAlign.Center;
			cell2.Attributes.Add("class","label2");
			row1.Cells.Add(cell2);

			TableCell cell3 = new TableCell();
			cell3.Text = " Штат н/с ";
			cell3.HorizontalAlign = HorizontalAlign.Center;
			cell3.Attributes.Add("class","label2");
			row1.Cells.Add(cell3);

			TableCell cell4 = new TableCell();
			cell4.Text = " Штат р/с ";
			cell4.HorizontalAlign = HorizontalAlign.Center;
			cell4.Attributes.Add("class","label2");
			row1.Cells.Add(cell4);

			TableCell cell5 = new TableCell();
			cell5.Text = " Нек-т всего ";
			cell5.HorizontalAlign = HorizontalAlign.Center;
			cell5.Attributes.Add("class","label2");
			row1.Cells.Add(cell5);

			TableCell cell6 = new TableCell();
			cell6.Text = " Нек-т н/с ";
			cell6.HorizontalAlign = HorizontalAlign.Center;
			cell6.Attributes.Add("class","label2");
			row1.Cells.Add(cell6);

			TableCell cell7 = new TableCell();
			cell7.Text = " Нек-т р/с ";
			cell7.HorizontalAlign = HorizontalAlign.Center;
			cell7.Attributes.Add("class","label2");
			row1.Cells.Add(cell7);

			Table1.Rows.Add(row1);
			Table1.CellPadding = 0;
			Table1.CellSpacing = 0;

			for( int i = 0; i < podch.Count; i++)
			{
				TableRow r = new TableRow();
				// Наименование
				TableCell c1 = new TableCell();
				c1.Text = "&nbsp" + podchin[i].NamePodr;
				c1.Attributes.Add("class","label");
				r.Cells.Add(c1);
				// Общий штат
				TableCell c2 = new TableCell();
				c2.Text = podchin[i].s_all.ToString();
				c2.HorizontalAlign = HorizontalAlign.Center;
				c2.Attributes.Add("class","sTable1");
				r.Cells.Add(c2);
				// штат н/с
				TableCell c3 = new TableCell();
				c3.Text = podchin[i].s_ns.ToString();
				c3.HorizontalAlign = HorizontalAlign.Center;
				c3.Attributes.Add("class","sTable1");
				r.Cells.Add(c3);
				// штат р/с
				TableCell c4 = new TableCell();
				c4.Text = podchin[i].s_rs.ToString();
				c4.HorizontalAlign = HorizontalAlign.Center;
				c4.Attributes.Add("class","sTable1");
				r.Cells.Add(c4);
				// Нек-т всего
				TableCell c5 = new TableCell();
				c5.Text = podchin[i].n_all.ToString();
				if ( podchin[i].n_all_p != 0 ) c5.Text += " (" + ((-1)*podchin[i].n_all_p).ToString("##.#") + "%) ";
				c5.HorizontalAlign = HorizontalAlign.Center;
				c5.Attributes.Add("class","sTable1");
				r.Cells.Add(c5);
				// Нек-т н/с
				TableCell c6 = new TableCell();
				c6.Text = podchin[i].n_ns.ToString();
				if ( podchin[i].n_ns_p != 0 ) c6.Text += " (" + ((-1)*podchin[i].n_ns_p).ToString("##.#") + "%) ";;
				c6.HorizontalAlign = HorizontalAlign.Center;
				c6.Attributes.Add("class","sTable1");
				r.Cells.Add(c6);
				// Нек-т р/с
				TableCell c7 = new TableCell();
				c7.Text = podchin[i].n_rs.ToString();
				if ( podchin[i].n_rs_p != 0 ) c7.Text += " (" + ((-1)*podchin[i].n_rs_p).ToString("##.#") + "%) ";;
				c7.HorizontalAlign = HorizontalAlign.Center;
				c7.Attributes.Add("class","sTable1");
				r.Cells.Add(c7);
					
				Table1.Rows.Add(r);

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
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.podrDataSet = new kadry.Nekompl.podrDataSet();
			this.workDataSet = new kadry.Nekompl.workDataSet();
			this.podchDataSet = new kadry.Nekompl.podchDataSet();
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.workDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.podchDataSet)).BeginInit();
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "PageTimeout=0;FIL=dBase IV;MaxBufferSize=2048;DSN=KADRY;DefaultDir=C:\\KADRY;Driv" +
				"erId=277";
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// Command
			// 
			this.Command.Connection = this.Connection;
			// 
			// podrDataSet
			// 
			this.podrDataSet.DataSetName = "podrDataSet";
			this.podrDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// workDataSet
			// 
			this.workDataSet.DataSetName = "workDataSet";
			this.workDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// podchDataSet
			// 
			this.podchDataSet.DataSetName = "podchDataSet";
			this.podchDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.workDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.podchDataSet)).EndInit();

		}
		#endregion

		protected void BtnRefresh_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Calculate();
		}
	}
}
