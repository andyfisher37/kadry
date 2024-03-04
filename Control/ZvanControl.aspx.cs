using System;
using System.Data;

namespace kadry.Control
{
	/// <summary>
	/// Summary description for zvan_control.
	/// </summary>
	public partial class zvan_control : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected kadry.Control.ctrlDataSet ctrlDataSet;
		protected System.Data.Odbc.OdbcCommand nakCommand;
		protected kadry.Control.nakDataSet nakDataSet;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcDataAdapter nakDataAdapter;
		protected kadry.Control.ctrlDataSet tmpDataSet;
		protected kadry.podrDataSet podrDataSet;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                //kadry.Security.Security s = new kadry.Security.Security();

                //if (!s.CheckSecurePage(User.Identity.Name, "zvan_control.aspx")) Response.Redirect("\\AccessDenied.htm", true);
                //else s.AddLogText("Работа с контролем присвоения званий...", Context.Request.UserHostAddress, 23, true);

                Command.CommandText = "SELECT * FROM PODRAZD.DBF WHERE KEY_OF_POD IN (SELECT DISTINCT PODRAZD FROM AAQQ.DBF ) ";
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(podrDataSet);
                podrList.DataBind();
                podrList.Items.Add("Все подразделения");
                podrList.Items.FindByText("Все подразделения").Value = "0";
                podrList.Items.FindByText("Все подразделения").Selected = true;
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

                sluzDataSource.SelectCommand = "SELECT * FROM SLUZBA.DBF ";
                sluzDataSource.DataBind();
                sluzList.DataBind();
                sluzList.Items.Add("Все службы (кроме ОВО)");
                sluzList.Items.FindByText("Все службы (кроме ОВО)").Value = "-2";
                sluzList.Items.Add("Все службы");
                sluzList.Items.FindByText("Все службы").Value = "-1";
                sluzList.Items.FindByText("Все службы").Selected = true;

                FindLabel.Text = "";
            
            
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
			this.ctrlDataSet = new kadry.Control.ctrlDataSet();
			this.nakCommand = new System.Data.Odbc.OdbcCommand();
			this.nakDataSet = new kadry.Control.nakDataSet();
			this.nakDataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.tmpDataSet = new kadry.Control.ctrlDataSet();
			this.podrDataSet = new kadry.podrDataSet();
			((System.ComponentModel.ISupportInitialize)(this.ctrlDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nakDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tmpDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).BeginInit();
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// Command
			// 
			this.Command.CommandText = "SELECT * FROM PODRAZD.DBF WHERE KEY_OF_POD IN (SELECT DISTINCT PODRAZD FROM AAQQ." +
				"DBF)";
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase IV;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;Drive" +
				"rId=277";
			// 
			// ctrlDataSet
			// 
			this.ctrlDataSet.DataSetName = "ctrlDataSet";
			this.ctrlDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// nakCommand
			// 
			this.nakCommand.Connection = this.Connection;
			// 
			// nakDataSet
			// 
			this.nakDataSet.DataSetName = "nakDataSet";
			this.nakDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// nakDataAdapter
			// 
			this.nakDataAdapter.SelectCommand = this.nakCommand;
			// 
			// tmpDataSet
			// 
			this.tmpDataSet.DataSetName = "ctrlDataSet";
			this.tmpDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// podrDataSet
			// 
			this.podrDataSet.DataSetName = "podrDataSet";
			this.podrDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.ctrlDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nakDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tmpDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).EndInit();

		}
		#endregion

		// Стажеры без званий...
		protected void Button1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
            Command.CommandText = "SELECT Aaqq.KEY_1, Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, PODRAZD.PODRAZDEL, " +
                "OFIC_DOL.NAM_OF_DOL, SLUZBA.NAM_OF_SLU, Aaqq.DATA_POST, PRIEM.ISP_SROK, PRIEM.DAT_PRI " +
                "FROM Aaqq, PODRAZD, OFIC_DOL, SLUZBA, PRIEM " +
                "WHERE (Aaqq.PODRAZD = PODRAZD.KEY_OF_POD) " +
                "AND (Aaqq.KEY_1 = PRIEM.KEY_1) " +
                "AND (Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU) " +
                "AND (Aaqq.FAMILIYA <> '') " +
                "AND (Aaqq.REAL_DOLZN = OFIC_DOL.P3) " +
                "AND (Aaqq.ZVANIE = 99) AND (REAL_DOLZN < '800000') ";
				//"AND (Aaqq.DATA_POST = PRIEM.DAT_PRI) ";
	
	        // Выбор подразделения...
			if ( podrList.SelectedValue != "0" )
			{
				if ( podrList.SelectedValue == "101" ) Command.CommandText += " AND Aaqq.PODRAZD IN (54,2,3,4,5,28,29,30)";
				else
					if ( podrList.SelectedValue == "102" ) Command.CommandText += " AND Aaqq.PODRAZD IN (10,7,24,18,312,20)";
				else
					if ( podrList.SelectedValue == "103" ) Command.CommandText += " AND Aaqq.PODRAZD IN (17,16,6,25,21,26)";
				else
					if ( podrList.SelectedValue == "104" ) Command.CommandText += " AND Aaqq.PODRAZD IN (8,13,23,14,11)";
				else
					if ( podrList.SelectedValue == "105" ) Command.CommandText += " AND Aaqq.PODRAZD IN (19,27,15,152,9)";
				else Command.CommandText += " AND Aaqq.PODRAZD = " + podrList.SelectedValue;
			}

            // Выбор подчиненного...
            if (podchList.Visible && podchList.SelectedItem.Value != "-1")
            {
                Command.CommandText += " AND PODR = " + podchList.SelectedItem.Value;
            }

            // Выбор службы
            if (sluzList.SelectedItem.Value != "-1")
            {
                if (sluzList.SelectedItem.Value != "-2")
                {
                    // Объединение некоторых глобальных служб...
                    // КМ
                    if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND Aaqq.SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                    else
                        // МОБ
                        if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND Aaqq.SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                        else
                            // Кадры
                            if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND Aaqq.SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                            else
                                // Тыл
                                if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND Aaqq.SLUZBA IN (5,15,73,76,77) ";
                                else
                                    // ОВО
                                    if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND Aaqq.SLUZBA IN (9,52) ";
                                    else
                                        // Следствие
                                        if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND Aaqq.SLUZBA IN (10,55) ";
                                        else
                                            // ГИБДД
                                            if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND Aaqq.SLUZBA IN (11,36,37,38,39,56,65) ";
                                            else
                                                // УР
                                                if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND Aaqq.SLUZBA IN (24,25) ";
                                                else
                                                    // ППС
                                                    if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND Aaqq.SLUZBA IN (29,54) ";
                                                    else
                                                        // Приемники
                                                        if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND Aaqq.SLUZBA IN (33,63) ";
                                                        else
                                                            // Мед.вытрезв
                                                            if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND Aaqq.SLUZBA IN (40,60) ";
                                                            else
                                                                // Конвой
                                                                if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND Aaqq.SLUZBA IN (43,58) ";
                                                                else
                                                                    // ОМОН
                                                                    if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND Aaqq.SLUZBA IN (44,59) ";
                                                                    else
                                                                        // УЦ
                                                                        if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND Aaqq.SLUZBA IN (78,64) ";
                                                                        else
                                                                            // УНП
                                                                            if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND Aaqq.SLUZBA IN (85,66) ";
                                                                            else Command.CommandText += " AND Aaqq.SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                }
                else Command.CommandText += " AND Aaqq.SLUZBA NOT IN (9,52) ";
            }


			Command.CommandText += " ORDER BY Aaqq.PODRAZD, Aaqq.FAMILIYA";
			
			ctrlDataSet.Dispose();
			DataAdapter.Fill(ctrlDataSet);

			// Предпологаемая дата присвоения - дата пост. + исп.срок.
			System.DateTime dateX;
            
			for (int i = 0; i < ctrlDataSet.Tables["Table"].Rows.Count; i++)
			{
                int srok = 0;
                DateTime dt;
                
                try
                {
                    srok = Convert.ToInt16(ctrlDataSet.Tables["Table"].Rows[i]["ISP_SROK"]);
                    dt = Convert.ToDateTime(ctrlDataSet.Tables["Table"].Rows[i]["DATA_POST"]);
                }
                catch
                {
                    srok = 6;
                    dt = Convert.ToDateTime(ctrlDataSet.Tables["Table"].Rows[i]["DAT_PRI"]);
                }
    			if ( srok == 0 )
				{
					dateX = dt.AddMonths(6);
				}
				else dateX = dt.AddMonths(srok);
								
				if ( dateX > System.DateTime.Now ) ctrlDataSet.Tables["Table"].Rows[i].Delete();
                //else 
                //{
                //    ctrlDataSet.Tables["Table"].Rows[i]["dateX"] = dateX;
                //    nakCommand.CommandText = "SELECT KEY_1 FROM NAKAZAN WHERE DAT_SNIAT IS NULL AND KEY_1 = " + ctrlDataSet.Tables["Table"].Rows[i]["KEY_1"].ToString();
                //    nakDataSet.Dispose();
                //    nakDataAdapter.Fill(nakDataSet);
                //    if ( nakDataSet.Tables["Table"].Rows.Count != 0 ) ctrlDataSet.Tables["Table"].Rows[i]["IsNak"] = "есть";
                //    else ctrlDataSet.Tables["Table"].Rows[i]["IsNak"] = "-";
                //}

			}

			Grid.DataBind();
			Grid.Columns[3].Visible = false;
			Grid.Columns[4].Visible = false;
			Grid.Columns[10].Visible = false;
			Grid.Columns[9].Visible = true;
			Grid.Columns[12].Visible = false;
			

			FindLabel.Text = "Найдено: " + Grid.Items.Count.ToString() + " человек(а)";
		}

        // Список сотрудников назначенных на офицерские должности, но не имеющих специальных званий
		protected void Button2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Command.CommandText = "SELECT KEY_1, FAMILIYA, IMYA, OTCHECTVO, PODRAZD.PODRAZDEL, " +
				"OFIC_DOL.NAM_OF_DOL, SLUZBA.NAM_OF_SLU, Aaqq.DATA_POST, Aaqq.DATA_VDOLZ, Aaqq.PODRAZD " +
				"FROM Aaqq, PODRAZD, OFIC_DOL, SLUZBA " +
				"WHERE Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU " +
				"AND (FAMILIYA <> '') AND (REAL_DOLZN = OFIC_DOL.P3) " +
				"AND (ZVANIE IN (0,20,21,22,23,24,25,26,40,41,42,43,44,45,46,60,61,62,63,64,65,66,100,101,102,103,104,105,106) AND (REAL_DOLZN < '500000')) ";
			
			if ( podrList.SelectedValue != "0" )
			{
				if ( podrList.SelectedValue == "101" ) Command.CommandText += " AND Aaqq.PODRAZD IN (54,2,3,4,5,28,29,30)";
				else
					if ( podrList.SelectedValue == "102" ) Command.CommandText += " AND Aaqq.PODRAZD IN (10,7,24,18,312,20)";
				else
					if ( podrList.SelectedValue == "103" ) Command.CommandText += " AND Aaqq.PODRAZD IN (17,16,6,25,21,26)";
				else
					if ( podrList.SelectedValue == "104" ) Command.CommandText += " AND Aaqq.PODRAZD IN (8,13,23,14,11)";
				else
					if ( podrList.SelectedValue == "105" ) Command.CommandText += " AND Aaqq.PODRAZD IN (19,27,15,152,9)";
				else Command.CommandText += " AND Aaqq.PODRAZD = " + podrList.SelectedValue;
			}

            // Выбор подчиненного...
            if (podchList.Visible && podchList.SelectedItem.Value != "-1")
            {
                Command.CommandText += " AND PODR = " + podchList.SelectedItem.Value;
            }

            // Выбор службы
            if (sluzList.SelectedItem.Value != "-1")
            {
                if (sluzList.SelectedItem.Value != "-2")
                {
                    // Объединение некоторых глобальных служб...
                    // КМ
                    if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND Aaqq.SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                    else
                        // МОБ
                        if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND Aaqq.SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                        else
                            // Кадры
                            if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND Aaqq.SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                            else
                                // Тыл
                                if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND Aaqq.SLUZBA IN (5,15,73,76,77) ";
                                else
                                    // ОВО
                                    if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND Aaqq.SLUZBA IN (9,52) ";
                                    else
                                        // Следствие
                                        if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND Aaqq.SLUZBA IN (10,55) ";
                                        else
                                            // ГИБДД
                                            if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND Aaqq.SLUZBA IN (11,36,37,38,39,56,65) ";
                                            else
                                                // УР
                                                if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND Aaqq.SLUZBA IN (24,25) ";
                                                else
                                                    // ППС
                                                    if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND Aaqq.SLUZBA IN (29,54) ";
                                                    else
                                                        // Приемники
                                                        if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND Aaqq.SLUZBA IN (33,63) ";
                                                        else
                                                            // Мед.вытрезв
                                                            if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND Aaqq.SLUZBA IN (40,60) ";
                                                            else
                                                                // Конвой
                                                                if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND Aaqq.SLUZBA IN (43,58) ";
                                                                else
                                                                    // ОМОН
                                                                    if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND Aaqq.SLUZBA IN (44,59) ";
                                                                    else
                                                                        // УЦ
                                                                        if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND Aaqq.SLUZBA IN (78,64) ";
                                                                        else
                                                                            // УНП
                                                                            if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND Aaqq.SLUZBA IN (85,66) ";
                                                                            else Command.CommandText += " AND Aaqq.SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                }
                else Command.CommandText += " AND Aaqq.SLUZBA NOT IN (9,52) ";
            }

			Command.CommandText += " ORDER BY DATA_VDOLZ";
									
			ctrlDataSet.Dispose();
			DataAdapter.Fill(ctrlDataSet);

			System.DateTime dateX; // Дата присвоения...
            
			for (int i = 0; i < ctrlDataSet.Tables["Table"].Rows.Count; i++)
			{
				dateX = Convert.ToDateTime(ctrlDataSet.Tables["Table"].Rows[i]["DATA_VDOLZ"]);
									
				ctrlDataSet.Tables["Table"].Rows[i]["dateX"] = dateX;

				// Проверка на наличие взыскания...
				nakCommand.CommandText = "SELECT KEY_1 FROM NAKAZAN WHERE DAT_SNIAT IS NULL AND VID_NAKAZ <> '106' AND KEY_1 = " + ctrlDataSet.Tables["Table"].Rows[i]["KEY_1"].ToString();
				if ( Connection.State != ConnectionState.Open ) Connection.Open();
				int res = nakCommand.ExecuteNonQuery();
				
				if ( res > 0 ) ctrlDataSet.Tables["Table"].Rows[i]["IsNak"] = "есть";
				else ctrlDataSet.Tables["Table"].Rows[i]["IsNak"] = "-";
					
			}

			Grid.DataBind();
			Grid.Columns[3].Visible = false;
			Grid.Columns[4].Visible = false;
			Grid.Columns[9].Visible = false;
			Grid.Columns[12].Visible = true;
			
			FindLabel.Text = "Найдено: " + Grid.Items.Count.ToString() + " человек(а)";
		
		}

        // Список аттестованных сотрудников, которым не присвоено очередное спец.звание по истечении необходимого срока выслуги
		protected void Button3_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Command.CommandText = "SELECT KEY_1, FAMILIYA, IMYA, OTCHECTVO, PODRAZDEL, ZVANIE, POTOLOK, DATA_POST, DATA_VDOLZ, DATA_PRSV, OBRAZ_DOL1, OBRAZ_LIC2, " +
				"OFIC_DOL.NAM_OF_DOL, SLUZBA.NAM_OF_SLU, ZVANIE.VOIN_ZVAN " +
				"FROM Aaqq, PODRAZD, OFIC_DOL, SLUZBA, ZVANIE " +
				"WHERE KEY_1 <> 0 AND Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.ZVANIE = ZVANIE.KEY_ZVAN " +
				"AND (FAMILIYA <> '') AND REAL_DOLZN = OFIC_DOL.P3 " +
				"AND REAL_DOLZN < '800000' AND DATA_PRSV IS NOT NULL ";

			if ( podrList.SelectedValue != "0" )
			{
				if ( podrList.SelectedValue == "101" ) Command.CommandText += " AND Aaqq.PODRAZD IN (54,2,3,4,5,28,29,30)";
				else
					if ( podrList.SelectedValue == "102" ) Command.CommandText += " AND Aaqq.PODRAZD IN (10,7,24,18,312,20)";
				else
					if ( podrList.SelectedValue == "103" ) Command.CommandText += " AND Aaqq.PODRAZD IN (17,16,6,25,21,26)";
				else
					if ( podrList.SelectedValue == "104" ) Command.CommandText += " AND Aaqq.PODRAZD IN (8,13,23,14,11)";
				else
					if ( podrList.SelectedValue == "105" ) Command.CommandText += " AND Aaqq.PODRAZD IN (19,27,15,152,9)";
				else Command.CommandText += " AND Aaqq.PODRAZD = " + podrList.SelectedValue;
			}

            // Выбор подчиненного...
            if (podchList.Visible && podchList.SelectedItem.Value != "-1")
            {
                Command.CommandText += " AND PODR = " + podchList.SelectedItem.Value;
            }

			if ( ZvanList1.SelectedIndex == 1 )
			{
                Command.CommandText += " AND Aaqq.ZVANIE IN (27,28,29,30,31,32,33,34,35,47,48,49,50,51,52,53,54,55,67,68,69,70,71,72,73,74,75,107,108,109,110,11,112,113,114) AND Aaqq.DOLZNOST < '500000'";
			} 
			else if ( ZvanList1.SelectedIndex == 2 )
			{
                Command.CommandText += " AND Aaqq.ZVANIE NOT IN (27,28,29,30,31,32,33,34,35,47,48,49,50,51,52,53,54,55,67,68,69,70,71,72,73,74,75,107,108,109,110,11,112,113,114) AND Aaqq.DOLZNOST > '500000' AND Aaqq.DOLZNOST < '800000'";
			}
			else Command.CommandText += " AND Aaqq.DOLZNOST < '800000'";

            // Выбор службы
            if (sluzList.SelectedItem.Value != "-1")
            {
                if (sluzList.SelectedItem.Value != "-2")
                {
                    // Объединение некоторых глобальных служб...
                    // КМ
                    if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND Aaqq.SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                    else
                        // МОБ
                        if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND Aaqq.SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                        else
                            // Кадры
                            if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND Aaqq.SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                            else
                                // Тыл
                                if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND Aaqq.SLUZBA IN (5,15,73,76,77) ";
                                else
                                    // ОВО
                                    if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND Aaqq.SLUZBA IN (9,52) ";
                                    else
                                        // Следствие
                                        if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND Aaqq.SLUZBA IN (10,55) ";
                                        else
                                            // ГИБДД
                                            if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND Aaqq.SLUZBA IN (11,36,37,38,39,56,65) ";
                                            else
                                                // УР
                                                if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND Aaqq.SLUZBA IN (24,25) ";
                                                else
                                                    // ППС
                                                    if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND Aaqq.SLUZBA IN (29,54) ";
                                                    else
                                                        // Приемники
                                                        if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND Aaqq.SLUZBA IN (33,63) ";
                                                        else
                                                            // Мед.вытрезв
                                                            if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND Aaqq.SLUZBA IN (40,60) ";
                                                            else
                                                                // Конвой
                                                                if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND Aaqq.SLUZBA IN (43,58) ";
                                                                else
                                                                    // ОМОН
                                                                    if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND Aaqq.SLUZBA IN (44,59) ";
                                                                    else
                                                                        // УЦ
                                                                        if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND Aaqq.SLUZBA IN (78,64) ";
                                                                        else
                                                                            // УНП
                                                                            if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND Aaqq.SLUZBA IN (85,66) ";
                                                                            else Command.CommandText += " AND Aaqq.SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                }
                else Command.CommandText += " AND Aaqq.SLUZBA NOT IN (9,52) ";
            }

			Command.CommandText += " ORDER BY Aaqq.PODRAZD";
			
			tmpDataSet.Dispose();
			ctrlDataSet.Dispose();
			DataAdapter.Fill(tmpDataSet);

			if ( tmpDataSet.Tables["Table"].Rows.Count != 0)
			{
				System.DateTime dateX;
				int zv = 0;
				int potolok = 0;
				string obr_d = "";
				string obr_l = "";
            
				for (int i=0; i < tmpDataSet.Tables["Table"].Rows.Count; i++)
				{
					zv = Convert.ToInt16(tmpDataSet.Tables["Table"].Rows[i]["ZVANIE"]);
					potolok = Convert.ToInt16(tmpDataSet.Tables["Table"].Rows[i]["POTOLOK"]);
					dateX = System.DateTime.Now;
					obr_d = tmpDataSet.Tables["Table"].Rows[i]["OBRAZ_DOL1"].ToString();
					obr_l = tmpDataSet.Tables["Table"].Rows[i]["OBRAZ_LIC2"].ToString();
							
					if ( CheckPotolok.Checked )
					{
						if ( zv < potolok ) // учитывать потолок...
						{
							//if (( obr_d == "Высшее" && obr_l == "10" ) || ( obr_d == "Среднее" && obr_l == "30" ) || ( obr_d == "Среднее" && obr_l == "20" ))
							//{
										
							// 1 - год выслуги по званию
                            if (zv == 20 || zv == 21 || zv == 27 || zv == 40 || zv == 41 || zv == 47 || zv == 60 || zv == 61 || zv == 67 || zv == 100 || zv == 101 || zv == 107)
							{
								dateX = Convert.ToDateTime(tmpDataSet.Tables["Table"].Rows[i]["DATA_PRSV"]).AddYears(1);
							}
							// 2 - года выслуги по званию
                            if (zv == 22 || zv == 28 || zv == 42 || zv == 48 || zv == 62 || zv == 68 || zv == 102 || zv == 108)
							{
								dateX = Convert.ToDateTime(tmpDataSet.Tables["Table"].Rows[i]["DATA_PRSV"]).AddYears(2);
							}
							// 3 - года выслуги по званию
                            if (zv == 23 || zv == 29 || zv == 30 || zv == 43 || zv == 49 || zv == 50 || zv == 63 || zv == 69 || zv == 70 || zv == 67 || zv == 103 || zv == 109 || zv == 110)
							{
								dateX = Convert.ToDateTime(tmpDataSet.Tables["Table"].Rows[i]["DATA_PRSV"]).AddYears(3);
							}
							// 4 - года выслуги по званию
                            if (zv == 31 || zv == 51 || zv == 71 || zv == 111)
							{
								dateX = Convert.ToDateTime(tmpDataSet.Tables["Table"].Rows[i]["DATA_PRSV"]).AddYears(4);
							}
							// 5 - лет выслуги по званию
                            if (zv == 25 || zv == 32 || zv == 45 || zv == 52 || zv == 65 || zv == 72 || zv == 105 || zv == 112)
							{
								dateX = Convert.ToDateTime(tmpDataSet.Tables["Table"].Rows[i]["DATA_PRSV"]).AddYears(5);
							}
								
							if ( dateX < System.DateTime.Now ) 
							{
								tmpDataSet.Tables["Table"].Rows[i]["dateX"] = dateX;
								ctrlDataSet.Tables[0].ImportRow(tmpDataSet.Tables["Table"].Rows[i]);
							}
					
						}
					}
					else // Без учета потолка...
					{
						// 1 - год выслуги по званию
						if ( zv == 20 || zv == 21 || zv == 27 || zv == 40 || zv == 41 || zv ==47 || zv == 60 || zv == 61 || zv == 67 )
						{
							dateX = Convert.ToDateTime(tmpDataSet.Tables["Table"].Rows[i]["DATA_PRSV"]).AddYears(1);
						}
						// 2 - года выслуги по званию
						if ( zv == 22 || zv == 28 || zv == 42 || zv == 48 || zv == 62 || zv ==68 )
						{
							dateX = Convert.ToDateTime(tmpDataSet.Tables["Table"].Rows[i]["DATA_PRSV"]).AddYears(2);
						}
						// 3 - года выслуги по званию
						if ( zv == 23 || zv == 29|| zv == 30 || zv == 43 || zv == 49 || zv ==50 || zv == 63 || zv == 69 || zv == 70 )
						{
							dateX = Convert.ToDateTime(tmpDataSet.Tables["Table"].Rows[i]["DATA_PRSV"]).AddYears(3);
						}
						// 4 - года выслуги по званию
						if ( zv == 31 || zv == 51 || zv == 71 )
						{
							dateX = Convert.ToDateTime(tmpDataSet.Tables["Table"].Rows[i]["DATA_PRSV"]).AddYears(4);
						}
						// 5 - лет выслуги по званию
						if ( zv == 25 || zv == 32 || zv == 45 || zv == 52 || zv == 65 || zv == 72 )
						{
							dateX = Convert.ToDateTime(tmpDataSet.Tables["Table"].Rows[i]["DATA_PRSV"]).AddYears(5);
						}
								
						if ( dateX < System.DateTime.Now ) 
						{
							tmpDataSet.Tables["Table"].Rows[i]["dateX"] = dateX;
							ctrlDataSet.Tables[0].ImportRow(tmpDataSet.Tables["Table"].Rows[i]);
						}
					}
				}
				if ( CheckNak.Checked )
				{
					Grid.Columns[12].Visible = true;
				}
				else Grid.Columns[12].Visible = false;

				int n = 0;

				do
				{
                    nakCommand.CommandText = "SELECT KEY_1 FROM NAKAZAN WHERE DAT_SNIAT IS NULL AND VID_NAKAZ <> '106' AND KEY_1 = " + ctrlDataSet.Tables["Table"].Rows[n]["KEY_1"].ToString();
					nakDataSet.Clear();
					nakDataAdapter.Fill(nakDataSet);
					if ( nakDataSet.Tables["Table"].Rows.Count != 0 ) 
					{
						ctrlDataSet.Tables[0].Rows[n]["IsNak"] = "есть";
						if ( !CheckNak.Checked )
						{
							ctrlDataSet.Tables[0].Rows[n].Delete();
						}
					}
					else ctrlDataSet.Tables[0].Rows[n]["IsNak"] = "-";
					n++;
				} while (n < ctrlDataSet.Tables[0].Rows.Count);
				
			}

			tmpDataSet.Dispose();

			Grid.DataBind();
			Grid.Columns[3].Visible = true;
			Grid.Columns[4].Visible = true;
			Grid.Columns[11].Visible = true;
			Grid.Columns[9].Visible = false;
			
			FindLabel.Text = "Найдено: " + Grid.Items.Count.ToString() + " человек(а)";
		
		}

        // Контрольный список сотрудников, которым в текущем месяце, должно быть присвоено спец.звание
		protected void Button4_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            #region расчет
            Command.CommandText = "SELECT Aaqq.KEY_1, Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, PODRAZD.PODRAZDEL, Aaqq.ZVANIE, Aaqq.POTOLOK, " +
				"OFIC_DOL.NAM_OF_DOL, SLUZBA.NAM_OF_SLU, Aaqq.DATA_POST, Aaqq.DATA_VDOLZ, Aaqq.DATA_PRSV, ZVANIE.VOIN_ZVAN, Aaqq.OBRAZ_DOL1, Aaqq.OBRAZ_LIC2 " +
				"FROM Aaqq, PODRAZD, OFIC_DOL, SLUZBA, ZVANIE " +
				"WHERE KEY_1 <> 0 AND Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.ZVANIE = ZVANIE.KEY_ZVAN " +
				"AND (Aaqq.FAMILIYA <> '') AND Aaqq.REAL_DOLZN = OFIC_DOL.P3 " +
				"AND Aaqq.ZVANIE NOT IN (0,34,35,77,99,98,97,75,94,96,24,44,64,26,33,46,53,66,73,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,80,81) AND Aaqq.DATA_PRSV IS NOT NULL ";

			if ( podrList.SelectedValue != "0" )
			{
				if ( podrList.SelectedValue == "101" ) Command.CommandText += " AND Aaqq.PODRAZD IN (54,2,3,4,5,28,29,30)";
				else
					if ( podrList.SelectedValue == "102" ) Command.CommandText += " AND Aaqq.PODRAZD IN (10,7,24,18,312,20)";
				else
					if ( podrList.SelectedValue == "103" ) Command.CommandText += " AND Aaqq.PODRAZD IN (17,16,6,25,21,26)";
				else
					if ( podrList.SelectedValue == "104" ) Command.CommandText += " AND Aaqq.PODRAZD IN (8,13,23,14,11)";
				else
					if ( podrList.SelectedValue == "105" ) Command.CommandText += " AND Aaqq.PODRAZD IN (19,27,15,152,9)";
				else Command.CommandText += " AND Aaqq.PODRAZD = " + podrList.SelectedValue;
			}

            // Выбор подчиненного...
            if (podchList.Visible && podchList.SelectedItem.Value != "-1")
            {
                Command.CommandText += " AND PODR = " + podchList.SelectedItem.Value;
            }

			if ( ZvanList2.SelectedIndex == 1 )
			{
				Command.CommandText += " AND Aaqq.DOLZNOST < '500000'";
			} 
			else if ( ZvanList2.SelectedIndex == 2 )
			{
				Command.CommandText += " AND Aaqq.DOLZNOST > '500000' AND Aaqq.DOLZNOST < '800000'";
			}
			else Command.CommandText += " AND Aaqq.DOLZNOST < '800000'";

            // Выбор службы
            if (sluzList.SelectedItem.Value != "-1")
            {
                if (sluzList.SelectedItem.Value != "-2")
                {
                    // Объединение некоторых глобальных служб...
                    // КМ
                    if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND Aaqq.SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                    else
                        // МОБ
                        if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND Aaqq.SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                        else
                            // Кадры
                            if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND Aaqq.SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                            else
                                // Тыл
                                if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND Aaqq.SLUZBA IN (5,15,73,76,77) ";
                                else
                                    // ОВО
                                    if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND Aaqq.SLUZBA IN (9,52) ";
                                    else
                                        // Следствие
                                        if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND Aaqq.SLUZBA IN (10,55) ";
                                        else
                                            // ГИБДД
                                            if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND Aaqq.SLUZBA IN (11,36,37,38,39,56,65) ";
                                            else
                                                // УР
                                                if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND Aaqq.SLUZBA IN (24,25) ";
                                                else
                                                    // ППС
                                                    if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND Aaqq.SLUZBA IN (29,54) ";
                                                    else
                                                        // Приемники
                                                        if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND Aaqq.SLUZBA IN (33,63) ";
                                                        else
                                                            // Мед.вытрезв
                                                            if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND Aaqq.SLUZBA IN (40,60) ";
                                                            else
                                                                // Конвой
                                                                if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND Aaqq.SLUZBA IN (43,58) ";
                                                                else
                                                                    // ОМОН
                                                                    if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND Aaqq.SLUZBA IN (44,59) ";
                                                                    else
                                                                        // УЦ
                                                                        if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND Aaqq.SLUZBA IN (78,64) ";
                                                                        else
                                                                            // УНП
                                                                            if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND Aaqq.SLUZBA IN (85,66) ";
                                                                            else Command.CommandText += " AND Aaqq.SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                }
                else Command.CommandText += " AND Aaqq.SLUZBA NOT IN (9,52) ";
            }

			Command.CommandText += " ORDER BY Aaqq.PODRAZD";
			
			tmpDataSet.Dispose();
			ctrlDataSet.Dispose();
			DataAdapter.Fill(tmpDataSet);

			if ( tmpDataSet.Tables["Table"].Rows.Count != 0)
			{
				System.DateTime dateX, curDate;
				int zv = 0;
				int potolok = 0;
				string obr_d = "";
				string obr_l = "";
            
				for (int i=0; i < tmpDataSet.Tables["Table"].Rows.Count; i++)
				{
                    zv = Convert.ToInt16(tmpDataSet.Tables["Table"].Rows[i]["ZVANIE"]);
                    curDate = Convert.ToDateTime(tmpDataSet.Tables["Table"].Rows[i]["DATA_PRSV"]);
                    potolok = Convert.ToInt16(tmpDataSet.Tables["Table"].Rows[i]["POTOLOK"]);

                    // проверка на перекрас...
                    DataSet ds = new DataSet();
                    DataRowCollection rc;
                    Command.CommandText = "SELECT ZVANIE, DATA_PRSV FROM PERSZVAN WHERE KEY_1 = " + tmpDataSet.Tables["Table"].Rows[i]["ZVANIE"].ToString() +
                                          " AND DATA_PRSV < " + Convert.ToDateTime(tmpDataSet.Tables["Table"].Rows[i]["DATA_PRSV"]).ToOADate() + " ORDER BY DATA_PRSV DESC";
                    DataAdapter.SelectCommand = Command;
                    DataAdapter.Fill(ds);
                    rc = ds.Tables[0].Rows;
                    if (rc.Count > 0)
                    {
                        int zv0 = Convert.ToInt16(rc[0]["ZVANIE"]);
                        if ( (zv0 >= 20 && zv0 <= 35 && zv >= 100) ||
                             (zv0 >= 20 && zv0 <= 35 && zv >= 40 && zv <= 55) ||
                             (zv0 >= 40 && zv0 <= 55 && zv >= 100) )
                        { 
                            zv = zv0;
                            curDate = Convert.ToDateTime(rc[0]["DATA_PRSV"]);
                        }
                    }
					                    

					// Приведение в соответствие потолка по званию и текущего звания к одному типу...
					// милиция
                    if (zv >= 20 && zv <= 35)
					{
						if ( potolok >= 40 && potolok <= 55 ) potolok -= 20;
						if ( potolok >= 60 && potolok <= 75 ) potolok -= 40;
                        if ( potolok >= 100 && potolok <= 114 ) potolok -= 80;
					}
                    // вн.служба
					if (zv >= 40 && zv <= 55)
					{
						if ( potolok >= 20 && potolok <=35 ) potolok += 20;
                        if ( potolok >= 60 && potolok <= 75) potolok -= 20;
                        if ( potolok >= 100 && potolok <= 114 ) potolok -= 60;
					}
                    // юстиция
					if (zv >= 60 && zv <= 75)
					{
						if ( potolok >= 20 && potolok <=35 ) potolok += 40;
						if ( potolok >= 40 && potolok <= 55 ) potolok += 20;
                        if ( potolok >= 100 && potolok <= 114 ) potolok -= 40;
					}
                    // полиция
                    if (zv >= 100 && zv <= 114)
                    {
                        if (potolok >= 20 && potolok <= 35) potolok += 80;
                        if (potolok >= 40 && potolok <= 55) potolok += 60;
                        if (potolok >= 60 && potolok <= 75) potolok += 40;
                    }
					
					dateX = System.DateTime.Now;
					obr_d = tmpDataSet.Tables["Table"].Rows[i]["OBRAZ_DOL1"].ToString();
					obr_l = tmpDataSet.Tables["Table"].Rows[i]["OBRAZ_LIC2"].ToString();
								
					if ( zv < potolok ) 
					{
						//if (( obr_d == "Высшее" && obr_l == "10" ) || ( obr_d == "Среднее" && obr_l == "30" ) || ( obr_d == "Среднее" && obr_l == "20" ))
						//{
										
							// 1 - год выслуги по званию
							if ( zv == 20 || zv == 21 || zv == 27 || zv == 40 || zv == 41 || zv ==47 || zv == 60 || zv == 61 || zv == 67 || zv == 100 || zv == 101 || zv == 107 )
							{
								dateX = Convert.ToDateTime(curDate).AddYears(1);
							}
							// 2 - года выслуги по званию
							if ( zv == 22 || zv == 28 || zv == 42 || zv == 48 || zv == 62 || zv ==68 || zv == 102 || zv == 108 )
							{
								dateX = Convert.ToDateTime(curDate).AddYears(2);
							}
							// 3 - года выслуги по званию
							if ( zv == 23 || zv == 29|| zv == 30 || zv == 43 || zv == 49 || zv ==50 || zv == 63 || zv == 69 || zv == 70 || zv == 103 || zv == 109 || zv == 110 )
							{
								dateX = Convert.ToDateTime(curDate).AddYears(3);
							}
							// 4 - года выслуги по званию
							if ( zv == 31 || zv == 51 || zv == 71 || zv == 111)
							{
								dateX = Convert.ToDateTime(curDate).AddYears(4);
							}
							// 5 - лет выслуги по званию
							if ( zv == 25 || zv == 32 || zv == 45 || zv == 52 || zv == 65 || zv == 72 || zv == 105 || zv == 112)
							{
								dateX = Convert.ToDateTime(curDate).AddYears(5);
							}
								
							if ( dateX.Month == System.DateTime.Now.Month && dateX.Year == System.DateTime.Now.Year ) 
							{
								tmpDataSet.Tables["Table"].Rows[i]["dateX"] = dateX;
								ctrlDataSet.Tables[0].ImportRow(tmpDataSet.Tables["Table"].Rows[i]);
							}
						//}
					}

				}
				tmpDataSet.Dispose();

            #endregion

                Grid.DataBind();
				Grid.Columns[3].Visible = true;
				Grid.Columns[4].Visible = true;
				Grid.Columns[9].Visible = false;
				Grid.Columns[12].Visible = false;

				FindLabel.Text = "Найдено: " + Grid.Items.Count.ToString() + " человек(а)";
			}
		
		}	

		protected void Page_Unload(object sender, System.EventArgs e)
		{
			ctrlDataSet.Dispose();
			nakDataSet.Dispose();
			Connection.Dispose();
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
            else
            {
                podchLabel.Visible = false;
                podchList.Visible = false;
            }
        }

	
				
	}
}
