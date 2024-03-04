using System;
using System.Web.UI.WebControls;

namespace kadry.Nekompl
{
	/// <summary>
	/// Summary description for nek_sluz.
	/// </summary>
	public partial class nek_sluz : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected kadry.Nekompl.sluDataSet sluDataSet;
		protected kadry.Nekompl.work_sDataSet work_sDataSet;

		protected System.Data.DataRowCollection rc;

		public struct TSluzba
		{
			public int sluz_codes;
			public string sluz_global_name;
			public string sluz_names;
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
				TitleText.Text = "Сведения об укомплектованности служб УВД по Ивановской области, по состоянию на: <font color='red'>" + System.DateTime.Now.ToShortDateString() + "</font>";

				sluDataSet.Clear();
				Command.CommandText = "SELECT KEY_OF_SLU, NAM_OF_SLU FROM SLUZBA.DBF WHERE KEY_OF_SLU IN (SELECT DISTINCT SLUZBA FROM AAQQ) ORDER BY KEY_OF_SLU";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(sluDataSet);
				//Размерность массива служб...
				int max_index = sluDataSet.Tables[0].Rows.Count-1;
				int s_count = Convert.ToInt16(sluDataSet.Tables[0].Rows[max_index]["KEY_OF_SLU"]);

				//массив служб
				TSluzba[] sluz = new TSluzba[s_count];
				
				//Заполняем массив служб...
				for( int i = 0; i < sluDataSet.Tables[0].Rows.Count; i++)
				{
					int code = Convert.ToInt16(sluDataSet.Tables[0].Rows[i]["KEY_OF_SLU"]); 
					if ( i == code )
					{
						sluz[i].sluz_codes = code;
						sluz[i].sluz_global_name = sluDataSet.Tables[0].Rows[i]["NAM_OF_SLU"].ToString();
					} 
					else
					{
						sluz[i].sluz_codes = 0;
						sluz[i].sluz_global_name = "";
					}
				}
				
				//Проходим по каждой службе...
				for( int i = 0; i < s_count; i++ )
				{
					sluz[i].sokr_all = 0;
					sluz[i].sokr_ns = 0;
					sluz[i].sokr_rs = 0;
					sluz[i].s_ns = 0;
					sluz[i].s_rs = 0;
					sluz[i].n_all = 0;
					sluz[i].n_all_p = 0;
					sluz[i].n_ns_p = 0;
					sluz[i].n_rs_p = 0;
					sluz[i].n_ns = 0;
					sluz[i].n_rs = 0;

					if (sluz[i].sluz_codes != 0) //Если код службы не равен 0
					{
						//Command.CommandText = "SELECT DOLZNOST, OFIC_DOL.NAM_OF_DOL, SLUZBA.NAM_OF_SLU, PODRAZD.PODRAZDEL, NAIMEN.NAIMENOVAN AS upravlenie, NAIMEN_1.NAIMENOVAN AS otdel, NAIMEN_2.NAIMENOVAN AS podotdel, NAIMEN_3.NAIMENOVAN AS otdelenie, NAIMEN_4.NAIMENOVAN AS grup, NAIMEN_5.NAIMENOVAN AS podr, Aaqq.DATA_SOKR, SLVISOD.`TEXT` FROM Aaqq, OFIC_DOL, SLUZBA, PODRAZD, NAIMEN, NAIMEN NAIMEN_1, NAIMEN NAIMEN_2, NAIMEN NAIMEN_3, NAIMEN NAIMEN_4, NAIMEN NAIMEN_5, SLVISOD " +
						// " WHERE Aaqq.DOLZNOST = OFIC_DOL.P3 AND Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND " +
						// " Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.UPRAVLENIE = NAIMEN.KEY_OF_NAI " +
						// " AND Aaqq.OTDEL = NAIMEN_1.KEY_OF_NAI AND Aaqq.PODOTDEL = NAIMEN_2.KEY_OF_NAI AND " +
						// " Aaqq.OTDELENIE = NAIMEN_3.KEY_OF_NAI AND Aaqq.GRUP = NAIMEN_4.KEY_OF_NAI AND " +
						// " Aaqq.PODR = NAIMEN_5.KEY_OF_NAI AND Aaqq.IST_SOD = SLVISOD.CODE AND " +
						// " ( (Aaqq.FAMILIYA IS NULL AND Aaqq.DATA_SOKR IS NULL) OR " +
						// " (Aaqq.FAMILIYA IS NOT NULL AND Aaqq.DATA_SOKR IS NOT NULL) ) ";
						Command.CommandText = "SELECT DOLZNOST, OFIC_DOL.NAM_OF_DOL, SLUZBA.NAM_OF_SLU, NAIMEN.NAIMENOVAN AS upravlenie, NAIMEN_1.NAIMENOVAN AS otdel, NAIMEN_5.NAIMENOVAN AS podr, " +
							"NAIMEN_2.NAIMENOVAN AS podotdel, NAIMEN_3.NAIMENOVAN AS otdelenie, NAIMEN_4.NAIMENOVAN AS grup, SLVISOD.TEXT, Aaqq.DATA_VAK, " +
							"Aaqq.DATA_SOKR, Aaqq.NOMPRSOKDO, Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO " +
							"FROM Aaqq, OFIC_DOL, SLUZBA, NAIMEN, NAIMEN NAIMEN_1, NAIMEN NAIMEN_2, NAIMEN NAIMEN_3, NAIMEN NAIMEN_4, NAIMEN NAIMEN_5, SLVISOD " +
							"WHERE Aaqq.DOLZNOST = OFIC_DOL.P3 AND Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.UPRAVLENIE = NAIMEN.KEY_OF_NAI AND " +
							"Aaqq.OTDEL = NAIMEN_1.KEY_OF_NAI AND Aaqq.PODOTDEL = NAIMEN_2.KEY_OF_NAI AND Aaqq.OTDELENIE = NAIMEN_3.KEY_OF_NAI AND " +
							"Aaqq.GRUP = NAIMEN_4.KEY_OF_NAI AND Aaqq.PODR = NAIMEN_5.KEY_OF_NAI AND Aaqq.IST_SOD = SLVISOD.CODE ";
							//"((FAMILIYA IS NULL AND DATA_SOKR IS NULL) OR (FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL)) ";
						Command.CommandText += "AND SLUZBA = " + sluz[i].sluz_codes.ToString();
						Command.CommandText += " ORDER BY Aaqq.SLUZBA";

						work_sDataSet.Clear();
						DataAdapter.Fill(work_sDataSet);
						rc = work_sDataSet.Tables[0].Rows;

						sluz[i].s_all = rc.Count;
				
						// Проходим каждую должность в данной службе...
						for( int j = 0; j<rc.Count; j++)
						{				  
							int dol = Convert.ToInt16((rc[j]["DOLZNOST"].ToString()).Substring(0,1));
						
							// Штат н/с
							if ( dol <= 4 && rc[j]["DATA_SOKR"] == DBNull.Value ) sluz[i].s_ns++;
							// Штат р/с
							if ( dol >= 5 && rc[j]["DATA_SOKR"] == DBNull.Value ) sluz[i].s_rs++;
							// Должность сокращена
							if ( rc[j]["DATA_SOKR"] != DBNull.Value )
							{
								sluz[i].s_all--;
								if ( rc[j]["FAMILIYA"] != DBNull.Value ) 
								{
									sluz[i].sokr_all++;
									if ( dol <= 4 ) sluz[i].sokr_ns++;
									if ( dol >= 5 ) sluz[i].sokr_rs++;
								}
							}
							// Нек-т всего
							if ( rc[j]["FAMILIYA"].ToString() == "" && rc[j]["DATA_SOKR"] == DBNull.Value ) { sluz[i].n_all++; }
							// Нек-т н/с
							if ( rc[j]["FAMILIYA"].ToString() == "" && rc[j]["DATA_SOKR"] == DBNull.Value && dol <= 4 ) { sluz[i].n_ns++; }
							// Нек-т р/с
							if ( rc[j]["FAMILIYA"].ToString() == "" && rc[j]["DATA_SOKR"] == DBNull.Value && dol >= 5 ) { sluz[i].n_rs++; }
						}

						sluz[i].n_all = -1 * sluz[i].n_all + sluz[i].sokr_all;
						sluz[i].n_ns = (-1) * sluz[i].n_ns + sluz[i].sokr_ns;
						sluz[i].n_rs = (-1) * sluz[i].n_rs + sluz[i].sokr_rs;
						sluz[i].n_all_p = (Convert.ToDouble(sluz[i].n_all)/Convert.ToDouble(sluz[i].s_all)) * 100;
						sluz[i].n_ns_p = (Convert.ToDouble(sluz[i].n_ns)/Convert.ToDouble(sluz[i].s_ns)) * 100;
						sluz[i].n_rs_p = (Convert.ToDouble(sluz[i].n_rs)/Convert.ToDouble(sluz[i].s_rs)) * 100;
					}
				}

				// Шапка
				TableRow row1 = new TableRow();
				TableCell cell1 = new TableCell();
				cell1.Text = " Наименование службы ";
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
				Table.CellPadding = 1;
				Table.CellSpacing = 1;

				for( int i = 0; i < s_count; i++)
				{
					if ( sluz[i].sluz_codes != 0 )
					{
						TableRow r = new TableRow();
						// Наименование
						TableCell c1 = new TableCell();
						c1.Text = sluz[i].sluz_global_name;
						c1.Attributes.Add("class","label");
						r.Cells.Add(c1);
						// Общий штат
						TableCell c2 = new TableCell();
						c2.Text = sluz[i].s_all.ToString();
						c2.HorizontalAlign = HorizontalAlign.Center;
						c2.Attributes.Add("class","stable");
						r.Cells.Add(c2);
						// штат н/с
						TableCell c3 = new TableCell();
						c3.Text = sluz[i].s_ns.ToString();
						c3.HorizontalAlign = HorizontalAlign.Center;
						c3.Attributes.Add("class","stable");
						r.Cells.Add(c3);
						// штат р/с
						TableCell c4 = new TableCell();
						c4.Text = sluz[i].s_rs.ToString();
						c4.HorizontalAlign = HorizontalAlign.Center;
						c4.Attributes.Add("class","stable");
						r.Cells.Add(c4);
						// Нек-т всего
						TableCell c5 = new TableCell();
						c5.Text = sluz[i].n_all.ToString();
						if ( sluz[i].n_all_p != 0 ) c5.Text += " (" + ((-1)*sluz[i].n_all_p).ToString("##.#") + "%) ";
						c5.HorizontalAlign = HorizontalAlign.Center;
						c5.Attributes.Add("class","stable");
						r.Cells.Add(c5);
						// Нек-т н/с
						TableCell c6 = new TableCell();
						c6.Text = sluz[i].n_ns.ToString();
						if ( sluz[i].n_ns_p != 0 ) c6.Text += " (" + ((-1)*sluz[i].n_ns_p).ToString("##.#") + "%) ";;
						c6.HorizontalAlign = HorizontalAlign.Center;
						c6.Attributes.Add("class","stable");
						r.Cells.Add(c6);
						// Нек-т р/с
						TableCell c7 = new TableCell();
						c7.Text = sluz[i].n_rs.ToString();
						if ( sluz[i].n_rs_p != 0 ) c7.Text += " (" + ((-1)*sluz[i].n_rs_p).ToString("##.#") + "%) ";;
						c7.HorizontalAlign = HorizontalAlign.Center;
						c7.Attributes.Add("class","stable");
						r.Cells.Add(c7);
									
						Table.Rows.Add(r);
					}
				
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
			this.Connection = new System.Data.Odbc.OdbcConnection();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.sluDataSet = new kadry.Nekompl.sluDataSet();
			this.work_sDataSet = new kadry.Nekompl.work_sDataSet();
			((System.ComponentModel.ISupportInitialize)(this.sluDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.work_sDataSet)).BeginInit();
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "PageTimeout=0;FIL=dBase IV;MaxBufferSize=2048;DSN=KADRY;DefaultDir=C:\\KADRY;Driv" +
				"erId=277";
			// 
			// Command
			// 
			this.Command.CommandText = @"SELECT OFIC_DOL.NAM_OF_DOL, SLUZBA.NAM_OF_SLU, PODRAZD.PODRAZDEL, NAIMEN.NAIMENOVAN AS upravlenie, NAIMEN_1.NAIMENOVAN AS otdel, NAIMEN_2.NAIMENOVAN AS podotdel, NAIMEN_3.NAIMENOVAN AS otdelenie, NAIMEN_4.NAIMENOVAN AS grup, NAIMEN_5.NAIMENOVAN AS podr, Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, Aaqq.DATA_SOKR, SLVISOD.`TEXT` FROM Aaqq, OFIC_DOL, SLUZBA, PODRAZD, NAIMEN, NAIMEN NAIMEN_1, NAIMEN NAIMEN_2, NAIMEN NAIMEN_3, NAIMEN NAIMEN_4, NAIMEN NAIMEN_5, SLVISOD WHERE Aaqq.DOLZNOST = OFIC_DOL.P3 AND Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.UPRAVLENIE = NAIMEN.KEY_OF_NAI AND Aaqq.OTDEL = NAIMEN_1.KEY_OF_NAI AND Aaqq.PODOTDEL = NAIMEN_2.KEY_OF_NAI AND Aaqq.OTDELENIE = NAIMEN_3.KEY_OF_NAI AND Aaqq.GRUP = NAIMEN_4.KEY_OF_NAI AND Aaqq.PODR = NAIMEN_5.KEY_OF_NAI AND Aaqq.IST_SOD = SLVISOD.CODE AND ((Aaqq.FAMILIYA IS NULL) AND (Aaqq.DATA_SOKR IS NULL) OR (Aaqq.FAMILIYA IS NOT NULL) AND (Aaqq.DATA_SOKR IS NOT NULL)) ORDER BY Aaqq.SLUZBA";
			this.Command.Connection = this.Connection;
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// sluDataSet
			// 
			this.sluDataSet.DataSetName = "sluDataSet";
			this.sluDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// work_sDataSet
			// 
			this.work_sDataSet.DataSetName = "work_sDataSet";
			this.work_sDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.sluDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.work_sDataSet)).EndInit();

		}
		#endregion
	}
}
