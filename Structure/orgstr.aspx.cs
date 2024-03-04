using System;
using System.Web.Caching;

namespace kadry.Structure
{
	/// <summary>
	/// Модуль построения оргштатной структуры на лету...
	/// </summary>
	public partial class orgstr : System.Web.UI.Page
	{
		protected kadry.podrDataSet podrDataSet;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected System.Data.Odbc.OdbcCommand Command;
		protected kadry.sluzDataSet sluzDataSet;
		protected kadry.Structure.strDataSet strDataSet;
		protected kadry.Structure.zvDataSet zvDataSet;
		protected System.Data.Odbc.OdbcConnection odbcConnection;
        protected System.Web.UI.WebControls.DropDownList istList;

        public int viewtype;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
                //kadry.Security.Security s = new kadry.Security.Security();

                //if (!s.CheckSecurePage(User.Identity.Name,"orgstr.aspx")) Response.Redirect("\\AccessDenied.htm",true);

														
				Command.CommandText = "SELECT * FROM PODRAZD.DBF WHERE KEY_OF_POD IN (SELECT DISTINCT PODRAZD FROM AAQQ.DBF ) ";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(podrDataSet);
				podrList.DataBind();
				podrList.Items.Add("Все подразделения");
				podrList.Items.FindByText("Все подразделения").Value = "0";
				podrList.Items.FindByText("Все подразделения").Selected = true;
                //podrList.Items.Add("Центральная зона");
                //podrList.Items.FindByText("Центральная зона").Value = "101";
                //podrList.Items.Add("Северная зона");
                //podrList.Items.FindByText("Северная зона").Value = "102";
                //podrList.Items.Add("Южная зона");
                //podrList.Items.FindByText("Южная зона").Value = "103";
                //podrList.Items.Add("Западная зона");
                //podrList.Items.FindByText("Западная зона").Value = "104";
                //podrList.Items.Add("Восточная зона");
                //podrList.Items.FindByText("Восточная зона").Value = "105";
				
				Command.CommandText = "SELECT * FROM SLUZBA.DBF WHERE KEY_OF_SLU IN (SELECT DISTINCT SLUZBA FROM AAQQ.DBF) ORDER BY NAM_OF_SLU";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(sluzDataSet);

				sluzList.DataBind();
				sluzList.Items.Add("Все службы (кроме ОВО)");
				sluzList.Items.FindByText("Все службы (кроме ОВО)").Value = "-2";
				sluzList.Items.Add("Все службы");
				sluzList.Items.FindByText("Все службы").Value = "-1";
				sluzList.Items.FindByText("Все службы").Selected = true;

				Command.CommandText = "SELECT VOIN_ZVAN, KEY_ZVAN FROM ZVANIE.DBF WHERE KEY_ZVAN BETWEEN 1 AND 15 ORDER BY KEY_ZVAN";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(zvDataSet);

				zvanList.DataBind();
				zvanList.Items.Add("Все звания");
				zvanList.Items.FindByText("Все звания").Value = "100";
				zvanList.Items.FindByText("Все звания").Selected = true;

                //istDataSource.SelectCommand = "SELECT TEXT, CODE FROM SLVISOD.DBF WHERE CODE IN (SELECT IST_SOD FROM AAQQ.DBF)";
                //istDataSource.DataBind();
                //istList.DataBind();
                //istList.Items.Add("Весь федеральный");
                //istList.Items.FindByText("Весь федеральный").Value = "-1";
                //istList.Items.Add("Весь областной");
                //istList.Items.FindByText("Весь областной").Value = "-2";
                //istList.Items.Add("Все источники");
                //istList.Items.FindByText("Все источники").Value = "0";
                //istList.Items.FindByText("Все источники").Selected = true;

                //TimeList.Items.Clear();
                //DateTime now = Convert.ToDateTime("01.01.2001");
                //int m = now.Month;
                //int y = now.Year;
                //do
                //{
                //    m = now.Month;
                //    y = now.Year;
                //    string item = kadry.GlobalTransform.TransMonth(m) + " " + y + " года";
                //    TimeList.Items.Add(item);
                //    TimeList.Items.FindByText(item).Value = m + ";" + y;
                //    now = now.AddMonths(1);
                //    //Response.Write(now.ToShortDateString() + "\n");
                //} while (now.Month <= DateTime.Now.Month || now.Year != DateTime.Now.Year);
                //TimeList.Items.FindByText(kadry.GlobalTransform.TransMonth(DateTime.Now.Month) + " " + DateTime.Now.Year + " года").Selected = true;

                DataAdapter.Dispose();
                //s.Dispose();

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
			this.podrDataSet = new kadry.podrDataSet();
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.odbcConnection = new System.Data.Odbc.OdbcConnection();
			this.sluzDataSet = new kadry.sluzDataSet();
			this.strDataSet = new kadry.Structure.strDataSet();
			this.zvDataSet = new kadry.Structure.zvDataSet();
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.strDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.zvDataSet)).BeginInit();
			// 
			// podrDataSet
			// 
			this.podrDataSet.DataSetName = "podrDataSet";
			this.podrDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// Command
			// 
			this.Command.Connection = this.odbcConnection;
			// 
			// odbcConnection
			// 
			this.odbcConnection.ConnectionString = "PageTimeout=0;FIL=dBase 5.0;MaxBufferSize=2048;DSN=KADRY;DefaultDir=C:\\KADRY;Driv" +
				"erId=533";
			// 
			// sluzDataSet
			// 
			this.sluzDataSet.DataSetName = "sluzDataSet";
			this.sluzDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// strDataSet
			// 
			this.strDataSet.DataSetName = "strDataSet";
			this.strDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// zvDataSet
			// 
			this.zvDataSet.DataSetName = "zvDataSet";
			this.zvDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.strDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.zvDataSet)).EndInit();

		}
		#endregion

		protected void Button_next_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
            //kadry.Security.Security s = new kadry.Security.Security();

			string LogText = "";

			string title = "";

            string now = DateTime.Now.Month + ";" + DateTime.Now.Year;

            //if (TimeList.SelectedValue == now)
            //{
            Command.CommandText = "SELECT PODRAZD, PODR, UPRAVLENIE, OTDEL, PODOTDEL, OTDELENIE, GRUP, PODRAZD.PODRAZDEL, DATA_SOKR, STAVKA_DLZ, ZVANIE.VOIN_ZVAN, ZV.VOIN_ZVAN AS ZVAN1, DATA_PRSV, OFIC_DOL.NAM_OF_DOL, NAIMEN.NAIMENOVAN AS n_upravlenie, NAIMEN_1.NAIMENOVAN AS n_otdel, NAIMEN_2.NAIMENOVAN AS n_podotdel, NAIMEN_3.NAIMENOVAN AS n_otdelenie, NAIMEN_4.NAIMENOVAN AS n_grup, NAIMEN_5.NAIMENOVAN AS n_podr, FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, LICH_NOM_1, LICH_NOM_2, DATA_VAK, KEY_1, OFIC_DOL_1.NAM_OF_DOL AS REALDOL, OKLAD_OT, OKLAD_DO, OKLAD, DOLZNOST, DATA_POST, DATA_VDOLZ FROM AAQQ, PODRAZD, ZVANIE, ZVANIE ZV, OFIC_DOL, NAIMEN, NAIMEN NAIMEN_1, NAIMEN NAIMEN_2, NAIMEN NAIMEN_3, NAIMEN NAIMEN_4, NAIMEN NAIMEN_5, OFIC_DOL OFIC_DOL_1 WHERE PODRAZD = PODRAZD.KEY_OF_POD AND POTOLOK = ZVANIE.KEY_ZVAN AND ZVANIE = ZV.KEY_ZVAN AND DOLZNOST = OFIC_DOL.P3 AND UPRAVLENIE = NAIMEN.KEY_OF_NAI AND OTDEL = NAIMEN_1.KEY_OF_NAI AND PODOTDEL = NAIMEN_2.KEY_OF_NAI AND OTDELENIE = NAIMEN_3.KEY_OF_NAI AND GRUP = NAIMEN_4.KEY_OF_NAI AND PODR = NAIMEN_5.KEY_OF_NAI AND REAL_DOLZN = OFIC_DOL_1.P3 ";
            //}
            //else
            //{
            //    string[] p = TimeList.SelectedValue.Split(Convert.ToChar(";"));
            //    if (Convert.ToInt16(p[0]) < 10) p[0] = "0" + p[0];
            //    this.odbcConnection.ConnectionString = "PageTimeout=0;FIL=dBase 5.0;MaxBufferSize=2048;DefaultDir=C:\\KADRY\\base_arch\\" + p[1] + "\\aaqq" + p[0] + p[1].Substring(2,2) + ";DriverId=277";
            //    Response.Write(this.odbcConnection.ConnectionString);
            //    Command.CommandText = "SELECT PODRAZD, PODR, UPRAVLENIE, OTDEL, PODOTDEL, OTDELENIE, GRUP, PODRAZD.PODRAZDEL, DATA_SOKR, STAVKA_DLZ, ZVANIE.VOIN_ZVAN, OFIC_DOL.NAM_OF_DOL, NAIMEN.NAIMENOVAN AS n_upravlenie, NAIMEN_1.NAIMENOVAN AS n_otdel, NAIMEN_2.NAIMENOVAN AS n_podotdel, NAIMEN_3.NAIMENOVAN AS n_otdelenie, NAIMEN_4.NAIMENOVAN AS n_grup, NAIMEN_5.NAIMENOVAN AS n_podr, FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, SLVISOD.`TEXT` AS ISTOCHNIK, LICH_NOM_1, LICH_NOM_2, DATA_VAK, KEY_1, OFIC_DOL_1.NAM_OF_DOL AS REALDOL, OKLAD_OT, OKLAD_DO, OKLAD, DOLZNOST FROM AAQQ, PODRAZD, ZVANIE, OFIC_DOL, NAIMEN, NAIMEN NAIMEN_1, NAIMEN NAIMEN_2, NAIMEN NAIMEN_3, NAIMEN NAIMEN_4, NAIMEN NAIMEN_5, SLVISOD, OFIC_DOL OFIC_DOL_1 WHERE PODRAZD = PODRAZD.KEY_OF_POD AND POTOLOK = ZVANIE.KEY_ZVAN AND DOLZNOST = OFIC_DOL.P3 AND UPRAVLENIE = NAIMEN.KEY_OF_NAI AND OTDEL = NAIMEN_1.KEY_OF_NAI AND PODOTDEL = NAIMEN_2.KEY_OF_NAI AND OTDELENIE = NAIMEN_3.KEY_OF_NAI AND GRUP = NAIMEN_4.KEY_OF_NAI AND PODR = NAIMEN_5.KEY_OF_NAI AND IST_SOD = SLVISOD.CODE AND REAL_DOLZN = OFIC_DOL_1.P3 ";
            //}

            if (podrList.SelectedValue != "0")
            {
                if (podrList.SelectedValue == "101") Command.CommandText += " AND PODRAZD IN (54,2,3,4,5,28,29,30)";
                else
                    if (podrList.SelectedValue == "102") Command.CommandText += " AND PODRAZD IN (10,7,24,18,312,20)";
                    else
                        if (podrList.SelectedValue == "103") Command.CommandText += " AND PODRAZD IN (17,16,6,25,21,26)";
                        else
                            if (podrList.SelectedValue == "104") Command.CommandText += " AND PODRAZD IN (8,13,23,14,11)";
                            else
                                if (podrList.SelectedValue == "105") Command.CommandText += " AND PODRAZD IN (19,27,15,152,9)";
                                else Command.CommandText += " AND PODRAZD = " + podrList.SelectedValue;

                title = podrList.SelectedItem.Text;
                LogText += "[" + podrList.SelectedItem.Text + "]";

            }
            else
            {
                LogText += "[Все подразделения]";
                title = "Все подразделения ";
            }

            // Выбор подчиненного...
            if (podchList.Visible && podchList.SelectedItem.Value != "-1" && podchList.SelectedItem.Value != "-2")
            {
                Command.CommandText += " AND PODR = " + podchList.SelectedItem.Value;
                title += "(" + podchList.SelectedItem.Text + ")";
                LogText += "(" + podchList.SelectedItem.Text + ")";
            }
            else if (podchList.Visible && podchList.SelectedItem.Value == "-2")
            {
                Command.CommandText += " AND PODR = 9 ";
                title += "(без подчиненных)";
                LogText += "(без подчиненных)";
            }
            else if (podchList.Visible && podchList.SelectedItem.Value == "-1")
            {
                Command.CommandText +=  "";
                title += "(весь аппарат)";
                LogText += "(весь аппарат)";
            }

			// Выбор службы
			if ( sluzList.SelectedItem.Value != "-1" )
			{
				if (sluzList.SelectedItem.Value != "-2" )
				{

					// Объединение некоторых глобальных служб...
					// КМ
					if (sluzList.SelectedItem.Value == "1" && ChSl.Checked )	Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
					else
					// МОБ
                        if (sluzList.SelectedItem.Value == "2" && ChSl.Checked) Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
					else
					// Кадры
                            if (sluzList.SelectedItem.Value == "4" && ChSl.Checked) Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
					else
					// Тыл
                                if (sluzList.SelectedItem.Value == "5" && ChSl.Checked) Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) ";
					else
					// ОВО
                                    if (sluzList.SelectedItem.Value == "9" && ChSl.Checked) Command.CommandText += " AND SLUZBA IN (9,52) ";
					else
					// Следствие
                                        if (sluzList.SelectedItem.Value == "10" && ChSl.Checked) Command.CommandText += " AND SLUZBA IN (10,55) ";
					else
					// ГИБДД
                                            if (sluzList.SelectedItem.Value == "11" && ChSl.Checked) Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
					else
					// УР
                                                if (sluzList.SelectedItem.Value == "24" && ChSl.Checked) Command.CommandText += " AND SLUZBA IN (24,25) ";
					else
					// ППС
                                                    if (sluzList.SelectedItem.Value == "29" && ChSl.Checked) Command.CommandText += " AND SLUZBA IN (29,54) ";
					else
					// Приемники
                                                        if (sluzList.SelectedItem.Value == "33" && ChSl.Checked) Command.CommandText += " AND SLUZBA IN (33,63) ";
					else
					// Мед.вытрезв
                                                            if (sluzList.SelectedItem.Value == "40" && ChSl.Checked) Command.CommandText += " AND SLUZBA IN (40,60) ";
					else
					// Конвой
                                                                if (sluzList.SelectedItem.Value == "43" && ChSl.Checked) Command.CommandText += " AND SLUZBA IN (43,58) ";
					else
					// ОМОН
                                                                    if (sluzList.SelectedItem.Value == "44" && ChSl.Checked) Command.CommandText += " AND SLUZBA IN (44,59) ";
					else
					// УЦ
                                                                        if (sluzList.SelectedItem.Value == "78" && ChSl.Checked) Command.CommandText += " AND SLUZBA IN (78,64) ";
					else
					// УНП
                                                                            if (sluzList.SelectedItem.Value == "85" && ChSl.Checked) Command.CommandText += " AND SLUZBA IN (85,66) ";

					else Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
				} 
				else 	Command.CommandText += " AND SLUZBA NOT IN (9,52) ";
			} 

			title += ", " + sluzList.SelectedItem.Text.ToLower();
            LogText += "[" + sluzList.SelectedItem.Text.ToLower() + "]";

            // Показывать только сокращенные
            if (CheckSokr.Checked) Command.CommandText += " AND DATA_SOKR IS NOT NULL";

            // Показывать только НЕсокращенные
            if (CheckNoSokr.Checked) Command.CommandText += " AND DATA_SOKR IS NULL";

			// Выбор категории должности
			if ( dolzList.SelectedValue != "0" )
			{
					
				if ( dolzList.SelectedValue == "1" )
				{
					Command.CommandText += " AND DOLZNOST < '800000'";
				}
				if ( dolzList.SelectedValue == "2" )
				{
					Command.CommandText += " AND DOLZNOST < '200000'";
				}
				if ( dolzList.SelectedValue == "3" )
				{
					Command.CommandText += " AND DOLZNOST < '500000'";
				}
				if ( dolzList.SelectedValue == "4" )
				{
					Command.CommandText += " AND DOLZNOST BETWEEN '500000' AND '800000'";
				}
				if ( dolzList.SelectedValue == "5" )
				{
                    Command.CommandText += " AND DOLZNOST > '800000' AND POTOLOK NOT IN (80,81,82,83,84,85)";
				}
                if (dolzList.SelectedValue == "6")
                {
                    Command.CommandText += " AND DOLZNOST > '800000' AND POTOLOK IN (80,81,82,83,84,85)";
                }
			}

            
			title += " ," + dolzList.SelectedItem.Text.ToLower();
            LogText += "[" + dolzList.SelectedItem.Text.ToLower() + "]";

			if ( zvanList.SelectedValue != "100" )
			{
				Command.CommandText += " AND " + GetPotolok(zvanList.SelectedItem.Value, cList.SelectedItem.Value);
			}

			title += " , c предельным званием ";
			if ( cList.SelectedItem.Value == "1" ) title += zvanList.SelectedItem.Text.ToLower() + " и выше";
			if ( cList.SelectedItem.Value == "2" ) title += " до " + zvanList.SelectedItem.Text.ToLower();
			if ( cList.SelectedItem.Value == "0" ) title += zvanList.SelectedItem.Text.ToLower();

			// Ограничения по службам...
            //string secure_sluzb = s.GetSecureSluzb(User.Identity.Name);
            //if (secure_sluzb != "")	
            //{
            //    Command.CommandText += " AND SLUZBA NOT IN (" + secure_sluzb + ") ";
            //}

			Command.CommandText += " ORDER BY PODRAZD, PODR, UPRAVLENIE, OTDEL, PODOTDEL, OTDELENIE, GRUP, DOLZNOST";

            //Response.Write( Command.CommandText );

			strDataSet.Clear();
			DataAdapter.Fill(strDataSet);

			if ( strDataSet.Tables[0].Rows.Count > 0 )
			{
				Result.Text = "Найдено " + strDataSet.Tables[0].Rows.Count.ToString() + " должностей!";

			} else Result.Text = "По данным условиям не найдено ни одной должности...";

            //s.AddLogText("Штатка: " + LogText, Convert.ToString(Context.Request.UserHostAddress),43,true);

			Cache.Remove("struct");
            //s.Dispose();
            podrDataSet.Dispose();
            DataAdapter.Dispose();
            sluzDataSet.Dispose();
            zvDataSet.Dispose();
            
            odbcConnection.Dispose();

            if (ViewType1.Checked) viewtype = 1;
            if (ViewType2.Checked) viewtype = 2;

			Cache.Add("struct", strDataSet, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null );
			Response.Redirect(String.Format("viewstr.aspx?title={0}&viewtype={1}",title,viewtype));
		}

		public string GetPotolok( string code, string type )
		{
			string res = "";

			if ( type == "0" ) // только...
			{
				switch(code)
				{
					case "1" : res = "POTOLOK IN (20,40,60,100)"; break;// рядовой...
					case "2" : res = "POTOLOK IN (21,41,61,101)"; break;
					case "3" : res = "POTOLOK IN (22,42,62,102)"; break;
					case "4" : res = "POTOLOK IN (23,43,63,103)"; break;
					case "5" : res = "POTOLOK IN (24,44,64,104)"; break;
					case "6" : res = "POTOLOK IN (25,45,65,105)"; break;
					case "7" : res = "POTOLOK IN (26,46,66,106)"; break;
					case "8" : res = "POTOLOK IN (27,47,67,107)"; break;
					case "9" : res = "POTOLOK IN (28,48,68,108)"; break;
					case "10" : res = "POTOLOK IN (29,49,69,109)"; break;
					case "11" : res = "POTOLOK IN (30,50,70,110)"; break;
					case "12" : res = "POTOLOK IN (31,51,71,111)"; break;
					case "13" : res = "POTOLOK IN (32,52,72,112)"; break;
					case "14" : res = "POTOLOK IN (33,53,73,113)"; break;
					case "15" : res = "POTOLOK IN (34,54,74,114)";  break;// ген.-майор
				}
			}
			else if ( type == "1" ) // от...
			{
				switch(code)
				{
					case "1" : res = "POTOLOK >= 20 AND POTOLOK <= 75"; break;
					case "2" : res = "((POTOLOK >= 21 AND POTOLOK <= 35) OR (POTOLOK >= 41 AND POTOLOK <= 55) OR (POTOLOK >= 61 AND POTOLOK <= 75))"; break;
					case "3" : res = "((POTOLOK >= 22 AND POTOLOK <= 35) OR (POTOLOK >= 42 AND POTOLOK <= 55) OR (POTOLOK >= 62 AND POTOLOK <= 75))"; break;
					case "4" : res = "((POTOLOK >= 23 AND POTOLOK <= 35) OR (POTOLOK >= 43 AND POTOLOK <= 55) OR (POTOLOK >= 63 AND POTOLOK <= 75))"; break;
					case "5" : res = "((POTOLOK >= 24 AND POTOLOK <= 35) OR (POTOLOK >= 44 AND POTOLOK <= 55) OR (POTOLOK >= 64 AND POTOLOK <= 75))"; break;
					case "6" : res = "((POTOLOK >= 25 AND POTOLOK <= 35) OR (POTOLOK >= 45 AND POTOLOK <= 55) OR (POTOLOK >= 65 AND POTOLOK <= 75))"; break;
					case "7" : res = "((POTOLOK >= 26 AND POTOLOK <= 35) OR (POTOLOK >= 46 AND POTOLOK <= 55) OR (POTOLOK >= 66 AND POTOLOK <= 75))"; break;
					case "8" : res = "((POTOLOK >= 27 AND POTOLOK <= 35) OR (POTOLOK >= 47 AND POTOLOK <= 55) OR (POTOLOK >= 67 AND POTOLOK <= 75))"; break;
					case "9" : res = "((POTOLOK >= 28 AND POTOLOK <= 35) OR (POTOLOK >= 48 AND POTOLOK <= 55) OR (POTOLOK >= 68 AND POTOLOK <= 75))"; break;
					case "10" : res = "((POTOLOK >= 29 AND POTOLOK <= 35) OR (POTOLOK >= 49 AND POTOLOK <= 55) OR (POTOLOK >= 69 AND POTOLOK <= 75))"; break;
					case "11" : res = "((POTOLOK >= 30 AND POTOLOK <= 35) OR (POTOLOK >= 50 AND POTOLOK <= 55) OR (POTOLOK >= 70 AND POTOLOK <= 75))"; break;
					case "12" : res = "((POTOLOK >= 31 AND POTOLOK <= 35) OR (POTOLOK >= 51 AND POTOLOK <= 55) OR (POTOLOK >= 71 AND POTOLOK <= 75))"; break;
					case "13" : res = "((POTOLOK >= 32 AND POTOLOK <= 35) OR (POTOLOK >= 52 AND POTOLOK <= 55) OR (POTOLOK >= 72 AND POTOLOK <= 75))"; break;
					case "14" : res = "((POTOLOK >= 33 AND POTOLOK <= 35) OR (POTOLOK >= 53 AND POTOLOK <= 55) OR (POTOLOK >= 73 AND POTOLOK <= 75))"; break;
					case "15" : res = "((POTOLOK >= 34 AND POTOLOK <= 35) OR (POTOLOK >= 54 AND POTOLOK <= 55) OR (POTOLOK >= 74 AND POTOLOK <= 75))"; break;
				}

			}
			else if ( type == "2" ) // до...
			{
				switch(code)
				{
					case "1" : res = "POTOLOK IN (20,40,60)"; break;
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

        protected void podrList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Если выбран аппарат УВД или ГУВД -> показываем подчиненные подразделения...
            if (podrList.SelectedItem.Value == "1")
            {
                podchLabel.Visible = true;
                podchList.Visible = true;
                podchDataSource.SelectCommand = "SELECT NAIMENOVAN, KEY_OF_NAI FROM NAIMEN WHERE KEY_OF_NAI IN (SELECT DISTINCT PODR FROM AAQQ WHERE PODR <> 9 AND PODRAZD = 1) ORDER BY NAIMENOVAN";
                podchDataSource.DataBind();
                podchList.DataBind();
                podchList.Items.Add("Весь аппарат УВД");
                podchList.Items.FindByText("Весь аппарат УВД").Value = "-1";
                podchList.Items.FindByText("Весь аппарат УВД").Selected = true;
            }
            else if (podrList.SelectedItem.Value == "54")
            {
                podchLabel.Visible = true;
                podchList.Visible = true;
                podchDataSource.SelectCommand = "SELECT NAIMENOVAN, KEY_OF_NAI FROM NAIMEN WHERE KEY_OF_NAI IN (SELECT DISTINCT PODR FROM AAQQ WHERE PODR <> 9 AND PODRAZD = 54) ORDER BY NAIMENOVAN";
                podchDataSource.DataBind();
                podchList.DataBind();
                podchList.Items.Add("Весь аппарат ГУВД");
                podchList.Items.FindByText("Весь аппарат ГУВД").Value = "-1";
                podchList.Items.FindByText("Весь аппарат ГУВД").Selected = true;
            }
            else if (podrList.SelectedItem.Value == "583")
            {
                podchLabel.Visible = true;
                podchList.Visible = true;
                podchDataSource.SelectCommand = "SELECT NAIMENOVAN, KEY_OF_NAI FROM NAIMEN WHERE KEY_OF_NAI IN (SELECT DISTINCT PODR FROM AAQQ WHERE PODR <> 9 AND PODRAZD = 583) ORDER BY NAIMENOVAN";
                podchDataSource.DataBind();
                podchList.DataBind();
                podchList.Items.Add("Только аппарат УМВД (без подчиненных)");
                podchList.Items.FindByText("Только аппарат УМВД (без подчиненных)").Value = "-2";
                podchList.Items.Add("Весь аппарат УМВД по И.О.");
                podchList.Items.FindByText("Весь аппарат УМВД по И.О.").Value = "-1";
                podchList.Items.FindByText("Весь аппарат УМВД по И.О.").Selected = true;
            }
            else if (podrList.SelectedItem.Value == "584")
            {
                podchLabel.Visible = true;
                podchList.Visible = true;
                podchDataSource.SelectCommand = "SELECT NAIMENOVAN, KEY_OF_NAI FROM NAIMEN WHERE KEY_OF_NAI IN (SELECT DISTINCT PODR FROM AAQQ WHERE PODR <> 9 AND PODRAZD = 584) ORDER BY NAIMENOVAN";
                podchDataSource.DataBind();
                podchList.DataBind();
                podchList.Items.Add("Только аппарат УМВД (без подчиненных)");
                podchList.Items.FindByText("Только аппарат УМВД (без подчиненных)").Value = "-2";
                podchList.Items.Add("Весь аппарат УМВД по г.Иваново");
                podchList.Items.FindByText("Весь аппарат УМВД по г.Иваново").Value = "-1";
                podchList.Items.FindByText("Весь аппарат УМВД по г.Иваново").Selected = true;
            }
            else
            {
                podchLabel.Visible = false;
                podchList.Visible = false;
            }
        }

        protected void ViewType1_CheckedChanged(object sender, EventArgs e)
        {
            if (ViewType1.Checked)
            {
                viewtype = 1;
                ViewType2.Checked = false;
            }
        }

        protected void ViewType2_CheckedChanged(object sender, EventArgs e)
        {
            if (ViewType2.Checked)
            {
                viewtype = 2;
                ViewType1.Checked = false;
            }
        }
	}
}
