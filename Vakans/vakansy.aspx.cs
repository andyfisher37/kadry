using System;
using System.Web.UI;
using System.Web.Caching;



namespace kadry
{
	/// <summary>
	/// Summary description for Vakansy.
	/// </summary>
	public partial class Vakansy : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcConnection Conn;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected kadry.podrDataSet podrDataSet;
		protected kadry.sluzDataSet sluzDataSet;
		protected System.Data.Odbc.OdbcCommand Command;
		protected kadry.istDataSet istDataSet;
		protected kadry.Vakans.vakDataSet vakDataSet;
		protected kadry.Vakans.svodvakDataSet svodvakDataSet;
		private System.Data.DataRowCollection rc;
        
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
                //kadry.Security.Security s = new kadry.Security.Security();

                //if (!s.CheckSecurePage(User.Identity.Name,"vakansy.aspx")) Response.Redirect("\\AccessDenied.htm",true);

                //s.AddLogText("Открытие страницы:[Вакансии]",Context.Request.UserHostAddress.ToString(),14,true);

				Command.CommandText = "SELECT * FROM PODRAZD.DBF WHERE KEY_OF_POD IN (SELECT PODRAZD FROM AAQQ.DBF)";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(podrDataSet);
				podrList.DataBind();
				podrList.Items.Add("Только по г.Иваново");
				podrList.Items.FindByText("Только по г.Иваново").Value = "-1";
				podrList.Items.Add("Только по области");
				podrList.Items.FindByText("Только по области").Value = "-2";
				podrList.Items.Add("Центральная зона");
				podrList.Items.FindByText("Центральная зона").Value = "101";
				podrList.Items.Add("Северная зона");
				podrList.Items.FindByText("Северная зона").Value = "102";
				podrList.Items.Add("Южная зона");
				podrList.Items.FindByText("Южная зона").Value = "103";
				podrList.Items.Add("Западная зона");
				podrList.Items.FindByText("Западная зона").Value = "104";
				podrList.Items.Add("Восточная зона");
				podrList.Items.FindByText("Восточная зона").Value = "105";
				podrList.Items.Add("Все подразделения");
				podrList.Items.FindByText("Все подразделения").Value = "0";
				podrList.Items.FindByText("Все подразделения").Selected = true;

				
				Command.CommandText = "SELECT * FROM SLUZBA.DBF WHERE KEY_OF_SLU IN (SELECT SLUZBA FROM AAQQ.DBF) ORDER BY NAM_OF_SLU ";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(sluzDataSet);
				sluzList.DataBind();
				sluzList.Items.Add("Все службы (кроме ОВО)");
				sluzList.Items.FindByText("Все службы (кроме ОВО)").Value = "-2";
                sluzList.Items.Add("Все заместители начальников ГРУОВД");
                sluzList.Items.FindByText("Все заместители начальников ГРУОВД").Value = "-3";
				sluzList.Items.Add("Все службы");
				sluzList.Items.FindByText("Все службы").Value = "-1";
				sluzList.Items.FindByText("Все службы").Selected = true;
				
				
				Command.CommandText = "SELECT * FROM SLVISOD.DBF WHERE CODE IN (SELECT IST_SOD FROM AAQQ.DBF)";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(istDataSet);
				istList.DataBind();
				istList.Items.Add("Весь федеральный");
				istList.Items.FindByText("Весь федеральный").Value = "-1";
				istList.Items.Add("Весь областной");
				istList.Items.FindByText("Весь областной").Value = "-2";
				istList.Items.Add("Все источники");
				istList.Items.FindByText("Все источники").Value = "0";
				istList.Items.FindByText("Все источники").Selected = true;

                zvanList.DataBind();
                zvanList.Items.Add("Все звания");
                zvanList.Items.FindByText("Все звания").Value = "-1";
                zvanList.Items.FindByText("Все звания").Selected = true;
				
				podrList.Style.Add("Width","296px");
				sluzList.Style.Add("Width","296px");
				dolzList.Style.Add("Width","296px");
				grupList.Style.Add("Width","296px");
				istList.Style.Add("Width","296px");

                //VacDate.Date = DateTime.Now.AddYears(-1);
			
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
			this.Conn = new System.Data.Odbc.OdbcConnection();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.podrDataSet = new kadry.podrDataSet();
			this.sluzDataSet = new kadry.sluzDataSet();
			this.istDataSet = new kadry.istDataSet();
			this.vakDataSet = new kadry.Vakans.vakDataSet();
			this.svodvakDataSet = new kadry.Vakans.svodvakDataSet();
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.istDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vakDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.svodvakDataSet)).BeginInit();
			// 
			// Conn
			// 
            this.Conn.ConnectionString = "PageTimeout=0;FIL=dBase IV;MaxBufferSize=2048;DSN=KADRY;DefaultDir=C:\\KADRY;Drive" +
                "rId=277";
			// 
			// Command
			// 
			this.Command.CommandText = @"SELECT COUNT( Aaqq.DOLZNOST ) AS VAK, Podrazd.PODRAZDEL, Sluzba.NAM_OF_SLU FROM AAQQ.DBF Aaqq, PODRAZD.DBF Podrazd, SLUZBA.DBF Sluzba WHERE (Aaqq.FAMILIYA IS NULL) AND (Aaqq.PODRAZD = Podrazd.KEY_OF_POD) AND (Aaqq.SLUZBA = Sluzba.KEY_OF_SLU) AND (Aaqq.DATA_SOKR IS NULL) AND (Aaqq.DOLZNOST < '800000') GROUP BY Podrazd.PODRAZDEL, Sluzba.NAM_OF_SLU";
			this.Command.Connection = this.Conn;
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// podrDataSet
			// 
			this.podrDataSet.DataSetName = "podrDataSet";
			this.podrDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sluzDataSet
			// 
			this.sluzDataSet.DataSetName = "sluzDataSet";
			this.sluzDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// istDataSet
			// 
			this.istDataSet.DataSetName = "istDataSet";
			this.istDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// vakDataSet
			// 
			this.vakDataSet.DataSetName = "vakDataSet";
			this.vakDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// svodvakDataSet
			// 
			this.svodvakDataSet.DataSetName = "svodvakDataSet";
			this.svodvakDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.Unload += new System.EventHandler(this.Vakansy_Unload);
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.istDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vakDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.svodvakDataSet)).EndInit();

		}
		#endregion

		
		protected void Vakansy_Unload(object sender, System.EventArgs e)
		{
			Conn.Dispose();
		}

		protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{

            Command.CommandText = "SELECT PODRAZD, PODR, UPRAVLENIE, OTDEL, PODOTDEL, OTDELENIE, GRUP, dolz1.NAM_OF_DOL, dolz2.NAM_OF_DOL, " +
                "DOLZNOST, VOIN_ZVAN, PODRAZDEL, N1.NAIMENOVAN AS N1, N2.NAIMENOVAN AS N2, N3.NAIMENOVAN AS N3, " +
                "N4.NAIMENOVAN AS N4, N5.NAIMENOVAN AS N5, N6.NAIMENOVAN AS N6, DOLZ.NAM_OF_DOL, NAM_OF_SLU, " +
                "OKLAD_OT, OKLAD_DO, DATA_VAK, IST.TEXT, STAVKA_DLZ, STAVKA_PRS " +
                "FROM AAQQ.DBF, PODRAZD.DBF, OFIC_DOL.DBF DOLZ, SLUZBA.DBF, NAIMEN.DBF N1, NAIMEN.DBF N2, OFIC_DOL.dbf dolz1, ofic_dol.dbf dolz2, " +
                "NAIMEN.DBF N3, NAIMEN.DBF N4, NAIMEN.DBF N5, NAIMEN.DBF N6, ZVANIE.DBF, SLVISOD.DBF IST " +
                "WHERE (FAMILIYA IS NULL) AND " +
                "(DATA_SOKR IS NULL) AND " +
                "(PODRAZD = KEY_OF_POD) AND " +
                "(DOLZNOST = DOLZ.P3) AND " +
                "(SLUZBA = KEY_OF_SLU) AND " +
                "(UPRAVLENIE = N1.KEY_OF_NAI) AND " +
                "(OTDEL = N2.KEY_OF_NAI) AND " +
                "(PODOTDEL = N3.KEY_OF_NAI) AND " +
                "(OTDELENIE = N4.KEY_OF_NAI) AND " +
                "(GRUP = N5.KEY_OF_NAI) AND " +
                "(PODR = N6.KEY_OF_NAI) AND " +
                "(POTOLOK = KEY_ZVAN) AND " +
                "(IST_SOD = IST.CODE) AND (dolz1.P3 = DOLZNOST) AND (dolz2.P3 = REAL_DOLZN) ";
			
			// Добавляем подразделение...
			switch (podrList.SelectedItem.Value)
			{
				case "101" : Command.CommandText += " AND PODRAZD IN (54,2,3,4,5,28,29,30)"; break;
				case "102" : Command.CommandText += " AND PODRAZD IN (10,7,24,18,312,20)"; break;
				case "103" : Command.CommandText += " AND PODRAZD IN (17,16,6,25,21,26)"; break;
				case "104" : Command.CommandText += " AND PODRAZD IN (8,13,23,14,11)"; break;
				case "105" : Command.CommandText += " AND PODRAZD IN (19,27,15,152,9)"; break;
				case "-1" :	Command.CommandText += " AND PODRAZD IN (1,2,3,4,5,28,29,30,31,54)"; break;
				case "-2" :	Command.CommandText += " AND PODRAZD NOT IN (1,2,3,4,5,28,29,30,31,54)"; break;
				case "0" : break;
				default : Command.CommandText += " AND PODRAZD = " + podrList.SelectedItem.Value; break;
			}

			// Добавляем службу...
			// Объединение некоторых глобальных служб...
			if ( grupList.SelectedValue == "0" )
			{
				switch(sluzList.SelectedItem.Value)
				{
					case "-2" : { Command.CommandText += " AND SLUZBA NOT IN (9,52)"; break; }
						// Все службы
					case "-1" : break;
                    case "-3": { Command.CommandText += " AND (dolz2.nam_of_dol like 'Заместитель начальника УВД%' or dolz2.nam_of_dol like 'Заместитель начальника ОВД%')"; break; }
						// КМ
					case "1" : { Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) "; break; }
						// МОБ
					case "2" : {Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70,71) "; break; }
						// Кадры
					case "4" : {Command.CommandText += " AND SLUZBA IN (4,52,53,54,55,56,58,59,60,63,64,65) "; break; }
						// Тыл
					case "5" : {Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) "; break; }
						// ОВО
					case "9" : {Command.CommandText += " AND SLUZBA IN (9,52) "; break; }
						// Следствие
					case "10" : {Command.CommandText += " AND SLUZBA IN (10,55) "; break; }
						// ГИБДД
					case "11" :	{Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) "; break; }
						// УР
					case "24" :	{Command.CommandText += " AND SLUZBA IN (24,25) "; break; }
						// ППС
					case "29" :	{Command.CommandText += " AND SLUZBA IN (29,54) "; break; }
						// Приемники
					case "33" :	{Command.CommandText += " AND SLUZBA IN (33,63) "; break; }
						// Мед.вытрезв
					case "40" :	{Command.CommandText += " AND SLUZBA IN (40,60) "; break; }
						// Конвой
					case "43" :	{Command.CommandText += " AND SLUZBA IN (43,58) "; break; }
						// ОМОН
					case "44" :	{Command.CommandText += " AND SLUZBA IN (44,59) "; break; }
						// УЦ
					case "78" :	{Command.CommandText += " AND SLUZBA IN (78,64) "; break; }
						// УНП
					case "85" :	{Command.CommandText += " AND SLUZBA IN (85,66) "; break; }
						//
					default : {Command.CommandText += " AND SLUZBA = " + sluzList.SelectedItem.Value; break; }
				}
			}
						 
			// Выбор должности
			if ( dolzList.SelectedValue != "0" )
			{
				if ( dolzList.SelectedValue == "1" )
				{
					Command.CommandText += " AND DOLZNOST < '200000'";
				}
				if ( dolzList.SelectedValue == "2" )
				{
					Command.CommandText += " AND DOLZNOST < '500000'";
				}
				if ( dolzList.SelectedValue == "3" )
				{
					Command.CommandText += " AND DOLZNOST BETWEEN '500000' AND '800000'";
				}
				if ( dolzList.SelectedValue == "4" )
				{
					Command.CommandText += " AND DOLZNOST > '800000'";
				}
				if ( dolzList.SelectedValue == "5" )
				{
					Command.CommandText += " AND DOLZNOST < '800000'";
				}
			} 

			// Выбор источника
			if ( istList.SelectedValue == "-1" )
			{
				Command.CommandText += " AND IST_SOD IN (1,5,15,21,97)";
			} 
			else if ( istList.SelectedValue == "-2" )
			{
				Command.CommandText += " AND IST_SOD IN (2,95,109)";
			} 
			else if ( istList.SelectedValue != "0" )
			{
				Command.CommandText += " AND IST_SOD = " + istList.SelectedItem.Value;
			}
			
			// Выбор группы предназначения...
			if ( grupList.SelectedValue != "0" )
			{
				switch (grupList.SelectedValue)
				{
					case "2" : Command.CommandText += " AND (SLUZBA NOT IN (28,44,59,61,29,54,39,65,74) OR (DOLZNOST NOT IN ('500195','500197','500207') AND SLUZBA IN (9,52)))"; break;
                    case "3": Command.CommandText += " AND SLUZBA IN (22,15,73,76,77,3,79,9,52,78,64,80,86,75,5,11,30,31,32,33,34,35,36,40,41,42,43,23,10,59,14,4,53,54,55,56,58,59,60,63,64,65,13) OR (SLUZBA IN (9) AND DOLZNOST < '500000'))"; break;
					case "4" : Command.CommandText += " AND SLUZBA IN (22,15,73,76,77,3,79,9,52,78,64,80,86,75,5)"; break;
				}
			}

            // Ограничение по званиям
            if (zvanList.SelectedValue != "-1")
            {
                Command.CommandText += " AND " + GetPotolok(zvanList.SelectedItem.Value, cList.SelectedItem.Value);
            }

            // Выбор Полиции или иных
            if (inPoliceList.SelectedValue == "1")
            {
                Command.CommandText += " AND POTOLOK >= 100 ";
            }
            else if (inPoliceList.SelectedValue == "2")
            {
                Command.CommandText += " AND POTOLOK < 100 ";
            }
            
            // По дате вакансии
            if (dZnak.SelectedIndex != 0)
            {
                //if (dZnak.SelectedIndex == 1) Command.CommandText += String.Format(" AND DATA_VAK >= {0} ", VacDate.Date.Date.ToOADate());
                //if (dZnak.SelectedIndex == 2) Command.CommandText += String.Format(" AND DATA_VAK <= {0} ", VacDate.Date.Date.ToOADate());
            }

            Command.CommandText += " ORDER BY PODRAZD, PODR, UPRAVLENIE, OTDEL, PODOTDEL, OTDELENIE, GRUP, DOLZNOST";

            //Response.Write(Command.CommandText);

            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(vakDataSet);

            rc = vakDataSet.Tables[0].Rows;

            //if (Check3.Checked)
            //{
            //    Cache.Remove("vakansy");
            //    Cache.Add("vakansy", vakDataSet, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);
            //    Response.Redirect("viewresult.aspx", false);
            //}

            if (rc.Count != 0) // Если кого-то нашли...
            {
                //Grid.DataBind();
                L_info.Text = "Найдено: " + rc.Count.ToString();

                TitleGrid.Text = "Список вакантных должностей ";
                if (podrList.SelectedItem.Value != "0")
                {
                    TitleGrid.Text += " по подразделению: " + podrList.SelectedItem.Text + ", ";
                }
                else TitleGrid.Text += " по всем подразделениям, ";

                if (sluzList.SelectedItem.Value != "-1")
                {
                    TitleGrid.Text += " по службе: " + sluzList.SelectedItem.Text + ", ";
                }
                else TitleGrid.Text += " по всем службам, ";

                if (grupList.SelectedValue != "0")
                {
                    TitleGrid.Text += " (" + grupList.SelectedItem.Text + ") ";
                }

                TitleGrid.Text += " по состоянию на: " + System.DateTime.Now.ToShortDateString();
                ExcelCopyButton.Visible = true;
                WordCopyButton.Visible = true;

                Cache.Remove("vakansy");
                Cache.Add("vakansy", vakDataSet, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);
                Response.Redirect("viewresult.aspx?title=" + TitleGrid.Text);


                //    for (int i = 0; i <= rc.Count - 1; i++)
                //    {
                //        string pdr = "";
                //        if (Convert.ToString(rc[i]["N5"]) != "          - # -") pdr += "группы " + Convert.ToString(rc[i]["N5"]);
                //        if (Convert.ToString(rc[i]["N4"]) != "          - # -") pdr += " отделения " + Convert.ToString(rc[i]["N4"]);
                //        if (Convert.ToString(rc[i]["N3"]) != "          - # -") pdr += " подотдела " + Convert.ToString(rc[i]["N3"]);
                //        if (Convert.ToString(rc[i]["N2"]) != "          - # -") pdr += " отдела " + Convert.ToString(rc[i]["N2"]);
                //        if (Convert.ToString(rc[i]["N1"]) != "          - # -") pdr += " управления " + Convert.ToString(rc[i]["N1"]);
                //        if (Convert.ToString(rc[i]["N6"]) != "          - # -") pdr += " " + Convert.ToString(rc[i]["N6"]);
                //        if (Convert.ToString(rc[i]["PODRAZDEL"]) != "          - # -") pdr += " " + Convert.ToString(rc[i]["PODRAZDEL"]);

                //        Grid.Items[i].Cells[1].Text = kadry.GlobalTransform.TransformPdrNames(pdr);

                //    }

                //    for (int i = 0; i <= rc.Count - 1; i++)
                //    {
                //        Grid.Items[i].Cells[2].Text = kadry.GlobalTransform.TransformSlzNames(rc[i]["NAM_OF_SLU"].ToString());
                //    }

                //    if (!Check1.Checked)
                //    {
                //        Grid.Columns[4].Visible = false;
                //        Grid.Columns[5].Visible = false;
                //    }
                //    else
                //    {
                //        Grid.Columns[4].Visible = true;
                //        Grid.Columns[5].Visible = true;
                //    }
                //    if (!Check2.Checked)
                //    {
                //        Grid.Columns[6].Visible = false;
                //    }
                //    else
                //    {
                //        Grid.Columns[6].Visible = true;
                //    }

                //}
                //else
                //{
                //    L_info.Text = "Вакансий не найдено...";
            }

            
		}

        public string GetPotolok(string code, string type)
        {
            string res = "";

            if (type == "0") // только...
            {
                switch (code)
                {
                    case "1": res = "POTOLOK IN (20,40,60,100)"; break; // рядовой...
                    case "2": res = "POTOLOK IN (21,41,61,101)"; break;
                    case "3": res = "POTOLOK IN (22,42,62,102)"; break;
                    case "4": res = "POTOLOK IN (23,43,63,103)"; break;
                    case "5": res = "POTOLOK IN (24,44,64,104)"; break;
                    case "6": res = "POTOLOK IN (25,45,65,105)"; break;
                    case "7": res = "POTOLOK IN (26,46,66,106)"; break;
                    case "8": res = "POTOLOK IN (27,47,67,107)"; break;
                    case "9": res = "POTOLOK IN (28,48,68,108)"; break;
                    case "10": res = "POTOLOK IN (29,49,69,109)"; break;
                    case "11": res = "POTOLOK IN (30,50,70,110)"; break;
                    case "12": res = "POTOLOK IN (31,51,71,111)"; break;
                    case "13": res = "POTOLOK IN (32,52,72,112)"; break;
                    case "14": res = "POTOLOK IN (33,53,73,113)"; break;
                    case "15": res = "POTOLOK IN (34,54,74,114)"; break;// ген.-майор
                }
            }
            else if (type == "1") // от...
            {
                switch (code)
                {
                    case "1": res = "(POTOLOK >= 20 AND POTOLOK <= 75) OR (POTOLOK >= 100)"; break; // от рядового и выше
                    case "2": res = "((POTOLOK >= 21 AND POTOLOK <= 35) OR (POTOLOK >= 41 AND POTOLOK <= 55) OR (POTOLOK >= 61 AND POTOLOK <= 75) OR (POTOLOK >= 101))"; break;
                    case "3": res = "((POTOLOK >= 22 AND POTOLOK <= 35) OR (POTOLOK >= 42 AND POTOLOK <= 55) OR (POTOLOK >= 62 AND POTOLOK <= 75) OR (POTOLOK >= 102))"; break;
                    case "4": res = "((POTOLOK >= 23 AND POTOLOK <= 35) OR (POTOLOK >= 43 AND POTOLOK <= 55) OR (POTOLOK >= 63 AND POTOLOK <= 75) OR (POTOLOK >= 103))"; break;
                    case "5": res = "((POTOLOK >= 24 AND POTOLOK <= 35) OR (POTOLOK >= 44 AND POTOLOK <= 55) OR (POTOLOK >= 64 AND POTOLOK <= 75) OR (POTOLOK >= 104))"; break;
                    case "6": res = "((POTOLOK >= 25 AND POTOLOK <= 35) OR (POTOLOK >= 45 AND POTOLOK <= 55) OR (POTOLOK >= 65 AND POTOLOK <= 75) OR (POTOLOK >= 105))"; break;
                    case "7": res = "((POTOLOK >= 26 AND POTOLOK <= 35) OR (POTOLOK >= 46 AND POTOLOK <= 55) OR (POTOLOK >= 66 AND POTOLOK <= 75) OR (POTOLOK >= 106))"; break;
                    case "8": res = "((POTOLOK >= 27 AND POTOLOK <= 35) OR (POTOLOK >= 47 AND POTOLOK <= 55) OR (POTOLOK >= 67 AND POTOLOK <= 75) OR (POTOLOK >= 107))"; break;
                    case "9": res = "((POTOLOK >= 28 AND POTOLOK <= 35) OR (POTOLOK >= 48 AND POTOLOK <= 55) OR (POTOLOK >= 68 AND POTOLOK <= 75) OR (POTOLOK >= 108))"; break;
                    case "10": res = "((POTOLOK >= 29 AND POTOLOK <= 35) OR (POTOLOK >= 49 AND POTOLOK <= 55) OR (POTOLOK >= 69 AND POTOLOK <= 75) OR (POTOLOK >= 109))"; break;
                    case "11": res = "((POTOLOK >= 30 AND POTOLOK <= 35) OR (POTOLOK >= 50 AND POTOLOK <= 55) OR (POTOLOK >= 70 AND POTOLOK <= 75) OR (POTOLOK >= 110))"; break;
                    case "12": res = "((POTOLOK >= 31 AND POTOLOK <= 35) OR (POTOLOK >= 51 AND POTOLOK <= 55) OR (POTOLOK >= 71 AND POTOLOK <= 75) OR (POTOLOK >= 111))"; break;
                    case "13": res = "((POTOLOK >= 32 AND POTOLOK <= 35) OR (POTOLOK >= 52 AND POTOLOK <= 55) OR (POTOLOK >= 72 AND POTOLOK <= 75) OR (POTOLOK >= 112))"; break;
                    case "14": res = "((POTOLOK >= 33 AND POTOLOK <= 35) OR (POTOLOK >= 53 AND POTOLOK <= 55) OR (POTOLOK >= 73 AND POTOLOK <= 75) OR (POTOLOK >= 113))"; break;
                    case "15": res = "((POTOLOK >= 34 AND POTOLOK <= 35) OR (POTOLOK >= 54 AND POTOLOK <= 55) OR (POTOLOK >= 74 AND POTOLOK <= 75) OR (POTOLOK >= 114))"; break;
                }

            }
            else if (type == "2") // до...
            {
                switch (code)
                {
                    case "1": res = "POTOLOK IN (20,40,60)"; break; // до рядового (только рядовой)
                    case "2": res = "((POTOLOK <= 20 AND POTOLOK <= 21) OR (POTOLOK >= 40 AND POTOLOK <= 41) OR (POTOLOK >= 60 AND POTOLOK <= 61) OR (POTOLOK >= 100 AND POTOLOK <= 101))"; break;
                    case "3": res = "((POTOLOK <= 20 AND POTOLOK <= 22) OR (POTOLOK >= 40 AND POTOLOK <= 42) OR (POTOLOK >= 60 AND POTOLOK <= 62) OR (POTOLOK >= 100 AND POTOLOK <= 102))"; break;
                    case "4": res = "((POTOLOK <= 20 AND POTOLOK <= 23) OR (POTOLOK >= 40 AND POTOLOK <= 43) OR (POTOLOK >= 60 AND POTOLOK <= 63) OR (POTOLOK >= 100 AND POTOLOK <= 103))"; break;
                    case "5": res = "((POTOLOK <= 20 AND POTOLOK <= 24) OR (POTOLOK >= 40 AND POTOLOK <= 44) OR (POTOLOK >= 60 AND POTOLOK <= 64) OR (POTOLOK >= 100 AND POTOLOK <= 104))"; break;
                    case "6": res = "((POTOLOK <= 20 AND POTOLOK <= 25) OR (POTOLOK >= 40 AND POTOLOK <= 45) OR (POTOLOK >= 60 AND POTOLOK <= 65) OR (POTOLOK >= 100 AND POTOLOK <= 105))"; break;
                    case "7": res = "((POTOLOK <= 20 AND POTOLOK <= 26) OR (POTOLOK >= 40 AND POTOLOK <= 46) OR (POTOLOK >= 60 AND POTOLOK <= 66) OR (POTOLOK >= 100 AND POTOLOK <= 106))"; break;
                    case "8": res = "((POTOLOK <= 20 AND POTOLOK <= 27) OR (POTOLOK >= 40 AND POTOLOK <= 47) OR (POTOLOK >= 60 AND POTOLOK <= 67) OR (POTOLOK >= 100 AND POTOLOK <= 107))"; break;
                    case "9": res = "((POTOLOK <= 20 AND POTOLOK <= 28) OR (POTOLOK >= 40 AND POTOLOK <= 48) OR (POTOLOK >= 60 AND POTOLOK <= 68) OR (POTOLOK >= 100 AND POTOLOK <= 108))"; break;
                    case "10": res = "((POTOLOK <= 20 AND POTOLOK <= 29) OR (POTOLOK >= 40 AND POTOLOK <= 49) OR (POTOLOK >= 60 AND POTOLOK <= 69) OR (POTOLOK >= 100 AND POTOLOK <= 109))"; break;
                    case "11": res = "((POTOLOK <= 20 AND POTOLOK <= 30) OR (POTOLOK >= 40 AND POTOLOK <= 50) OR (POTOLOK >= 60 AND POTOLOK <= 70) OR (POTOLOK >= 100 AND POTOLOK <= 110))"; break;
                    case "12": res = "((POTOLOK <= 20 AND POTOLOK <= 31) OR (POTOLOK >= 40 AND POTOLOK <= 51) OR (POTOLOK >= 60 AND POTOLOK <= 71) OR (POTOLOK >= 100 AND POTOLOK <= 111))"; break;
                    case "13": res = "((POTOLOK <= 20 AND POTOLOK <= 32) OR (POTOLOK >= 40 AND POTOLOK <= 52) OR (POTOLOK >= 60 AND POTOLOK <= 72) OR (POTOLOK >= 100 AND POTOLOK <= 112))"; break;
                    case "14": res = "((POTOLOK <= 20 AND POTOLOK <= 33) OR (POTOLOK >= 40 AND POTOLOK <= 53) OR (POTOLOK >= 60 AND POTOLOK <= 73) OR (POTOLOK >= 100 AND POTOLOK <= 113))"; break;
                    case "15": res = "((POTOLOK <= 20 AND POTOLOK <= 34) OR (POTOLOK >= 40 AND POTOLOK <= 54) OR (POTOLOK >= 60 AND POTOLOK <= 74) OR (POTOLOK >= 100 AND POTOLOK <= 114))"; break;
                }

            }
            return res;
        }
        

		protected void ImageButton3_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("anketa.aspx", true);
		}

		protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Command.CommandText = "SELECT COUNT( Aaqq.DOLZNOST ) AS VAK, Podrazd.PODRAZDEL, Sluzba.NAM_OF_SLU, PODRAZD, SLUZBA FROM AAQQ.DBF Aaqq, PODRAZD.DBF Podrazd, SLUZBA.DBF Sluzba WHERE (Aaqq.FAMILIYA IS NULL) AND (Aaqq.PODRAZD = Podrazd.KEY_OF_POD) AND (Aaqq.SLUZBA = Sluzba.KEY_OF_SLU) AND (Aaqq.DATA_SOKR IS NULL) AND (Aaqq.DOLZNOST < '800000') GROUP BY Podrazd.PODRAZDEL, Sluzba.NAM_OF_SLU, PODRAZD, SLUZBA ORDER BY PODRAZD, SLUZBA";

			DataAdapter.SelectCommand = Command;
			DataAdapter.Fill(svodvakDataSet,"Table");
			if ( svodvakDataSet.Tables["Table"].Rows.Count != 0 )
			{
				Cache.Add( "dataset", svodvakDataSet.Tables["Table"].Rows, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null );
				Response.Redirect("svodTable.aspx", false);
                ExcelCopyButton.Visible = true;
                WordCopyButton.Visible = true;
			}
			else L_info.Text = "Нет вакансий!";
		}

        protected void ExcelCopyButton_Click(object sender, ImageClickEventArgs e)
        {
            //kadry.WordExcel.ExportGridToExcel(this, Grid, "Список");
        }

        protected void WordCopyButton_Click(object sender, ImageClickEventArgs e)
        {
            //kadry.WordExcel.ExportGridToWord(this, Grid, "Список");
        }

				
	}
}
