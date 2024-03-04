using System;
using System.Drawing;
using System.Web.UI.WebControls;

namespace kadry.Nekompl
{
	/// <summary>
	/// Summary description for vak_detail.
	/// </summary>
	public partial class vak_detail : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected kadry.Nekompl.vakDataSet vakDataSet;

		protected System.Data.DataRowCollection rc;

		public struct TVakansy
		{
			public string name;
			public string dolz;
			public string ist;
			public string sokr;
			public string date;
		}
	

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				int podr_code = Convert.ToInt16(Request.Params["code"]);
				string podr_name = Request.Params["name"];
				int is_vn = Convert.ToInt16(Request.Params["vn"]);
				int is_ovo = Convert.ToInt16(Request.Params["ovo"]);

				Header.Text = "Информация о вакантных и сокращенных должностях <br> Подразделение: <b>" + podr_name.ToUpper() + "</b>";

				Command.CommandText = "SELECT OFIC_DOL.NAM_OF_DOL, SLUZBA.NAM_OF_SLU, NAIMEN.NAIMENOVAN AS upravlenie, NAIMEN_1.NAIMENOVAN AS otdel, NAIMEN_5.NAIMENOVAN AS podr, " +
									  "NAIMEN_2.NAIMENOVAN AS podotdel, NAIMEN_3.NAIMENOVAN AS otdelenie, NAIMEN_4.NAIMENOVAN AS grup, SLVISOD.TEXT, Aaqq.DATA_VAK, " +
									  "Aaqq.DATA_SOKR, Aaqq.NOMPRSOKDO, Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO " +
									  "FROM Aaqq, OFIC_DOL, SLUZBA, NAIMEN, NAIMEN NAIMEN_1, NAIMEN NAIMEN_2, NAIMEN NAIMEN_3, NAIMEN NAIMEN_4, NAIMEN NAIMEN_5, SLVISOD " +
                                      "WHERE Aaqq.DOLZNOST = OFIC_DOL.P3 AND Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.UPRAVLENIE = NAIMEN.KEY_OF_NAI AND " +
                                      "Aaqq.OTDEL = NAIMEN_1.KEY_OF_NAI AND Aaqq.PODOTDEL = NAIMEN_2.KEY_OF_NAI AND Aaqq.OTDELENIE = NAIMEN_3.KEY_OF_NAI AND " +
                                      "Aaqq.GRUP = NAIMEN_4.KEY_OF_NAI AND Aaqq.PODR = NAIMEN_5.KEY_OF_NAI AND Aaqq.IST_SOD = SLVISOD.CODE AND " +
									  "((FAMILIYA IS NULL AND DATA_SOKR IS NULL) OR (FAMILIYA IS NOT NULL AND DATA_SOKR IS NOT NULL)) AND ";

				if ( podr_code == 0 ) Command.CommandText += "Aaqq.PODRAZD = 1 AND Aaqq.PODR = 9 ";
				else Command.CommandText += "Aaqq.PODRAZD = " + podr_code.ToString();

				if ( is_vn == 0 ) Command.CommandText += " AND DOLZNOST < '800000'";
				else Header.Text += " + вольнонаемный состав";
				if ( is_ovo == 0 ) 
				{
					Command.CommandText += " AND SLUZBA NOT IN (9,52)";
					Header.Text += " (без ОВО)";
				} else Header.Text += " (c ОВО)";

				Command.CommandText += " ORDER BY SLUZBA, DATA_SOKR, FAMILIYA";

				vakDataSet.Clear();
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(vakDataSet);
				rc = vakDataSet.Tables[0].Rows;

				if ( rc.Count > 0 )
				{
					TVakansy[] vak = new TVakansy[rc.Count];
					for( int i=0; i < rc.Count; i++)
					{
						vak[i].name = rc[i]["NAM_OF_DOL"].ToString();
						vak[i].dolz = BuildDolz( rc[i] );
						vak[i].ist = rc[i]["TEXT"].ToString();
						if ( rc[i]["DATA_VAK"] != DBNull.Value )
						 vak[i].date = Convert.ToDateTime(rc[i]["DATA_VAK"]).ToShortDateString();
						else vak[i].date = "-";
						if ( rc[i]["DATA_SOKR"] != DBNull.Value ) 
						{
							vak[i].sokr = Convert.ToDateTime(rc[i]["DATA_SOKR"]).ToShortDateString();
							if ( rc[i]["FAMILIYA"].ToString() != "" ) vak[i].sokr += "[ " + rc[i]["FAMILIYA"].ToString() + " " + rc[i]["IMYA"].ToString().Substring(0,1) + "." + rc[i]["OTCHECTVO"].ToString().Substring(0,1) + ". ]";
						} 
						else vak[i].sokr = "-";
					}
					BuildTable( rc.Count, vak );
				}
			}
		}

		private string BuildDolz( System.Data.DataRow r )
		{
			string pdr = "";
			if (r["grup"].ToString() != "          - # -" )		pdr += "группы " + r["grup"].ToString();
			if (r["otdelenie"].ToString() != "          - # -" )	pdr += " отделения " + r["otdelenie"].ToString();
			if (r["podotdel"].ToString() != "          - # -" )	pdr += " подотдела " + r["podotdel"].ToString();
			if (r["otdel"].ToString() != "          - # -" )		pdr += " отдела " + r["otdel"].ToString();
			if (r["upravlenie"].ToString() != "          - # -" )	pdr += " управление " + r["upravlenie"].ToString();
			if (r["podr"].ToString() != "          - # -" )		pdr += " " + r["podr"].ToString();
			return pdr;
		}

		private void BuildTable( int count, TVakansy[] vak )
		{
			// Шапка
			TableRow row1 = new TableRow();

			TableCell cell0 = new TableCell();
			cell0.Text = " № п/п ";
			cell0.HorizontalAlign = HorizontalAlign.Center;
			cell0.Attributes.Add("class","label2");
			row1.Cells.Add(cell0);

			TableCell cell1 = new TableCell();
			cell1.Text = " Должность ";
			cell1.HorizontalAlign = HorizontalAlign.Center;
			cell1.Attributes.Add("class","label2");
			row1.Cells.Add(cell1);

			TableCell cell2 = new TableCell();
			cell2.Text = " Оргштатное положение ";
			cell2.HorizontalAlign = HorizontalAlign.Center;
			cell2.Attributes.Add("class","label2");
			row1.Cells.Add(cell2);

			TableCell cell3 = new TableCell();
			cell3.Text = " Источник<br>финансир. ";
			cell3.HorizontalAlign = HorizontalAlign.Center;
			cell3.Attributes.Add("class","label2");
			row1.Cells.Add(cell3);

			TableCell cell4 = new TableCell();
			cell4.Text = " Информ.<br>о сокращении ";
			cell4.HorizontalAlign = HorizontalAlign.Center;
			cell4.Attributes.Add("class","label2");
			row1.Cells.Add(cell4);

			TableCell cell5 = new TableCell();
			cell5.Text = " Дата вак.";
			cell5.HorizontalAlign = HorizontalAlign.Center;
			cell5.Attributes.Add("class","label2");
			row1.Cells.Add(cell5);

			Table.Rows.Add(row1);

			for( int i = 0; i < count; i++)
			{
				TableRow r = new TableRow();
				// №
				TableCell c0 = new TableCell();
				c0.Text = Convert.ToString(i + 1);
				c0.Attributes.Add("class","label");
				c0.HorizontalAlign = HorizontalAlign.Center;
				r.Cells.Add(c0);
				// Должность
				TableCell c1 = new TableCell();
				c1.Text = vak[i].name;
				c1.Attributes.Add("class","label");
				r.Cells.Add(c1);
				// Подразделение
				TableCell c2 = new TableCell();
				c2.Text = vak[i].dolz;
				c2.Attributes.Add("class","label");
				r.Cells.Add(c2);
				// Ист.финансирования
				TableCell c3 = new TableCell();
				c3.Text = vak[i].ist;
				c3.Attributes.Add("class","label");
				c3.HorizontalAlign = HorizontalAlign.Center;
				r.Cells.Add(c3);
				// Инф.о сокращеннии
				TableCell c4 = new TableCell();
				c4.Text = vak[i].sokr;
				c4.Attributes.Add("class","label");
				c4.HorizontalAlign = HorizontalAlign.Center;
				c4.ForeColor = Color.Red;
				r.Cells.Add(c4);
				// Дата вакансии...
				TableCell c5 = new TableCell();
				c5.Text = vak[i].date;
				c5.Attributes.Add("class","label");
				c5.HorizontalAlign = HorizontalAlign.Center;
				r.Cells.Add(c5);

				Table.Rows.Add(r);
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
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.vakDataSet = new kadry.Nekompl.vakDataSet();
			((System.ComponentModel.ISupportInitialize)(this.vakDataSet)).BeginInit();
			// 
			// Command
			// 
			this.Command.CommandText = @"SELECT OFIC_DOL.NAM_OF_DOL, SLUZBA.NAM_OF_SLU, NAIMEN.NAIMENOVAN AS upravlenie, NAIMEN_1.NAIMENOVAN AS otdel, NAIMEN_2.NAIMENOVAN AS podotdel, NAIMEN_3.NAIMENOVAN AS otdelenie, NAIMEN_4.NAIMENOVAN AS grup, SLVISOD.`TEXT`, Aaqq.DATA_VAK, Aaqq.DATA_SOKR, Aaqq.NOMPRSOKDO, Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, NAIMEN_5.NAIMENOVAN AS podr FROM Aaqq, OFIC_DOL, SLUZBA, NAIMEN, NAIMEN NAIMEN_1, NAIMEN NAIMEN_2, NAIMEN NAIMEN_3, NAIMEN NAIMEN_4, SLVISOD, NAIMEN NAIMEN_5 WHERE Aaqq.DOLZNOST = OFIC_DOL.P3 AND Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.UPRAVLENIE = NAIMEN.KEY_OF_NAI AND Aaqq.OTDEL = NAIMEN_1.KEY_OF_NAI AND Aaqq.PODOTDEL = NAIMEN_2.KEY_OF_NAI AND Aaqq.OTDELENIE = NAIMEN_3.KEY_OF_NAI AND Aaqq.GRUP = NAIMEN_4.KEY_OF_NAI AND Aaqq.IST_SOD = SLVISOD.CODE AND Aaqq.PODR = NAIMEN_5.KEY_OF_NAI AND ((Aaqq.FAMILIYA IS NULL) AND (Aaqq.DOLZNOST < '800000') OR (Aaqq.FAMILIYA IS NOT NULL) AND (Aaqq.DOLZNOST < '800000') AND (Aaqq.DATA_SOKR IS NOT NULL))";
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;DBQ=" +
				"C:\\KADRY;DriverId=277";
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// vakDataSet
			// 
			this.vakDataSet.DataSetName = "vakDataSet";
			this.vakDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.vakDataSet)).EndInit();

		}
		#endregion
	}
}
