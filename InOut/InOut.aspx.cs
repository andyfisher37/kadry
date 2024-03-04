using System;
using System.Data;
using System.Web.UI;
using System.Web.Caching;

namespace kadry.InOut
{
	/// <summary>
	/// Summary description for main.
	/// </summary>
	public class InOut : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.ImageButton ImageButton2;
		protected System.Web.UI.WebControls.ImageButton ImageButton3;
		protected System.Web.UI.WebControls.ImageButton ImageButton7;
		protected System.Data.Odbc.OdbcConnection odbcConnection;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Web.UI.WebControls.Label In_Label;
		protected System.Web.UI.WebControls.Label Out_Label;
		protected System.Web.UI.WebControls.Image InBar;
		protected System.Web.UI.WebControls.Image OutBar;
		protected System.Web.UI.WebControls.Label CurDate;
		protected System.Web.UI.WebControls.ImageButton ImageButton6;
		protected System.Web.UI.WebControls.ImageButton ImageButton5;
		protected System.Web.UI.WebControls.ImageButton ImageButton8;
		protected eWorld.UI.MaskedTextBox OutDate2;
		protected eWorld.UI.MaskedTextBox InDate1;
		protected eWorld.UI.MaskedTextBox InDate2;
		protected eWorld.UI.MaskedTextBox OutDate1;
		protected System.Web.UI.WebControls.RadioButton RBtn1;
		protected System.Web.UI.WebControls.RadioButton RBtn2;
		protected System.Web.UI.WebControls.ImageButton Imagebutton9;
		protected System.Web.UI.WebControls.DropDownList podrList;
		protected kadry.podrDataSet podrDataSet;
		protected System.Web.UI.WebControls.DropDownList sluzList;
		protected kadry.InOut.DataSet1 sluzDataSet;
		protected System.Web.UI.WebControls.ImageButton ImageButton4;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
                //kadry.Security.Security s = new kadry.Security.Security();

                //if (!s.CheckSecurePage(User.Identity.Name,"InOut.aspx")) Response.Redirect("\\AccessDenied.htm",true);
						
				string cur_date = System.DateTime.Now.ToShortDateString();
				string from_date = "01.01." + System.DateTime.Now.Year.ToString();

                int opb_in = 0;
                int opb_out = 0;
                int bstm_in = 0; 
                int bstm_out = 0;

				CurDate.Text = "По состоянию на " + cur_date;

				OutDate1.Text = from_date;
				OutDate2.Text = cur_date;
				InDate1.Text = from_date;
				InDate2.Text = cur_date;

				DataSet ds = new DataSet();

				Command.CommandText = "SELECT COUNT(FAMILIYA) AS Expr1 FROM PRIEM WHERE DOLZNOST < '800000' AND " +
									  "(ZVANIE < 77 OR ZVANIE >= 99) AND " +
									  "(KAT_POST IS NULL OR KAT_POST > 102) AND " +
									  "(DAT_REG BETWEEN " + Convert.ToDateTime(from_date).ToOADate() + " AND " + Convert.ToDateTime(cur_date).ToOADate() + ")";

				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(ds);
				int in_res = Convert.ToInt16(ds.Tables[0].Rows[0]["Expr1"]) + opb_in + bstm_in;
				In_Label.Text = in_res.ToString() + " чел.";

				Command.CommandText = "SELECT COUNT(FAMILIYA) AS Expr1 FROM ARCHIVE WHERE (DOLZNOST < '800000') " +
									  "AND FAMILIYA <> '' AND " +
									  "(( ZVANIE < 77 ) OR ( ZVANIE >= 99 )) AND " +
									  "DAT_REG >= " + Convert.ToDateTime(from_date).ToOADate() + " AND DAT_REG <= " + Convert.ToDateTime(cur_date).ToOADate();

				ds.Clear();
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(ds);
				int out_res = Convert.ToInt16(ds.Tables[0].Rows[0]["Expr1"]) + opb_out + bstm_out;
				Out_Label.Text = out_res.ToString() + " чел.";

                InBar.Height = in_res + 2;
                InBar.Width = 16;
                OutBar.Height = out_res + 2;
                OutBar.Width = 16;
                
                //if ( in_res > out_res )
                //{
                //    int dif = in_res - out_res;
                //    InBar.Height = 10 + dif/2;
                //    InBar.Width = 16;
                //}
                //if ( in_res < out_res )
                //{
                //    int dif = out_res - in_res;
                //    OutBar.Height = 10 + dif/2;
                //    OutBar.Width = 16;
                //}
               
				ds.Clear();

                Command.CommandText = "SELECT * FROM PODRAZD.DBF WHERE KEY_OF_POD IN (SELECT DISTINCT PODRAZD FROM AAQQ.DBF)";
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

				Command.CommandText = "SELECT * FROM SLUZBA.DBF WHERE KEY_OF_SLU IN (SELECT DISTINCT SLUZBA FROM AAQQ) ORDER BY NAM_OF_SLU";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(sluzDataSet);
				sluzList.DataBind();
				sluzList.Items.Add("Все службы (кроме ОВО)");
				sluzList.Items.FindByText("Все службы (кроме ОВО)").Value = "-2";
				sluzList.Items.Add("Все службы");
				sluzList.Items.FindByText("Все службы").Value = "-1";
				sluzList.Items.FindByText("Все службы").Selected = true;

                //s.AddLogText("Открытие страницы:[Принятые и Уволенные]",Context.Request.UserHostAddress,35,true);

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
			this.odbcConnection = new System.Data.Odbc.OdbcConnection();
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.podrDataSet = new kadry.podrDataSet();
			this.sluzDataSet = new kadry.InOut.DataSet1();
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).BeginInit();
			// 
			// odbcConnection
			// 
			this.odbcConnection.ConnectionString = "PageTimeout=0;FIL=dBase 5.0;MaxBufferSize=2048;DSN=KADRY;DefaultDir=C:\\KADRY;Driv" +
				"erId=533";
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// Command
			// 
			this.Command.CommandText = "SELECT * FROM SLUZBA.DBF WHERE KEY_OF_SLU IN (SELECT DISTINCT SLUZBA FROM AAQQ) O" +
				"RDER BY NAM_OF_SLU";
			this.Command.Connection = this.odbcConnection;
			// 
			// podrDataSet
			// 
			this.podrDataSet.DataSetName = "podrDataSet";
			this.podrDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sluzDataSet
			// 
			this.sluzDataSet.DataSetName = "DataSet1";
			this.sluzDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).EndInit();

		}
		#endregion
        		
          
        // Уволенные по отрицательным мотивам
        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            if (OutDate1.Text != "" && OutDate2.Text != "")
            {
                DataSet ds = new DataSet();

                Command.CommandText = String.Format("SELECT ARCHIVE.FAMILIYA, ARCHIVE.IMYA, ARCHIVE.OTCHECTVO, DATA_ROZD, PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, SLVSTU.P1, SLVPRU.P1 AS Expr1, ARCHIVE.DATA_UVOL, ARCHIVE.ZVANIE, ARCHIVE.SL_RANE_OT, ARCHIVE.SL_RANE_DO, ARCHIVE.DATA_POST, ARCHIVE.LICH_NOM_1, ARCHIVE.LICH_NOM_2, ARCHIVE.DATA_PR_UV, ARCHIVE.NOM_PR_UVO, SLVPR2.P1 AS Expr2, ZVANIE.VOIN_ZVAN FROM ARCHIVE, PODRAZD, SLUZBA, OFIC_DOL, SLVSTU, SLVPRU, SLVPR2, ZVANIE WHERE ARCHIVE.ZVANIE = ZVANIE.KEY_ZVAN AND ARCHIVE.PODRAZD = PODRAZD.KEY_OF_POD AND ARCHIVE.SLUZBA = SLUZBA.KEY_OF_SLU AND ARCHIVE.REAL_DOLZN = OFIC_DOL.P3 AND ARCHIVE.ST_UV = SLVSTU.P2 AND ARCHIVE.PRICH_UV = SLVPRU.P2 AND ARCHIVE.KTO_UVOLIL = SLVPR2.P2 AND DOLZNOST < '800000' AND ARCHIVE.PRICH_UV IN ('1003','1004','1008','1013','1024','1026','1034','1035','1040','1041') AND ((ZVANIE < 77) OR (ZVANIE >= 99)) AND ARCHIVE.DAT_REG BETWEEN {0} AND {1}", Convert.ToDateTime(OutDate1.Text).ToOADate(), Convert.ToDateTime(OutDate2.Text).ToOADate());

                // Добавляем подразделение...
                switch (podrList.SelectedItem.Value)
                {
                    case "101": Command.CommandText += " AND PODRAZD IN (54,2,3,4,5,28,29,30)"; break;
                    case "102": Command.CommandText += " AND PODRAZD IN (10,7,24,18,312,20)"; break;
                    case "103": Command.CommandText += " AND PODRAZD IN (17,16,6,25,21,26)"; break;
                    case "104": Command.CommandText += " AND PODRAZD IN (8,13,23,14,11)"; break;
                    case "105": Command.CommandText += " AND PODRAZD IN (19,27,15,152,9)"; break;
                    case "-1": Command.CommandText += " AND PODRAZD IN (1,2,3,4,5,28,29,30,31,54)"; break;
                    case "-2": Command.CommandText += " AND PODRAZD NOT IN (1,2,3,4,5,28,29,30,31,54)"; break;
                    case "0": break;
                    default: Command.CommandText += " AND PODRAZD = " + podrList.SelectedItem.Value; break;
                }

                // Выбор службы
                if (sluzList.SelectedItem.Value != "-1")
                {
                    if (sluzList.SelectedItem.Value != "-2")
                    {
                        // Объединение некоторых глобальных служб...
                        // КМ
                        if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                        else
                            // МОБ
                            if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                            else
                                // Кадры
                                if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                                else
                                    // Тыл
                                    if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) ";
                                    else
                                        // ОВО
                                        if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND SLUZBA IN (9,52) ";
                                        else
                                            // Следствие
                                            if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND SLUZBA IN (10,55) ";
                                            else
                                                // ГИБДД
                                                if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
                                                else
                                                    // УР
                                                    if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND SLUZBA IN (24,25) ";
                                                    else
                                                        // ППС
                                                        if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND SLUZBA IN (29,54) ";
                                                        else
                                                            // Приемники
                                                            if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND SLUZBA IN (33,63) ";
                                                            else
                                                                // Мед.вытрезв
                                                                if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND SLUZBA IN (40,60) ";
                                                                else
                                                                    // Конвой
                                                                    if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND SLUZBA IN (43,58) ";
                                                                    else
                                                                        // ОМОН
                                                                        if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND SLUZBA IN (44,59) ";
                                                                        else
                                                                            // УЦ
                                                                            if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND SLUZBA IN (78,64) ";
                                                                            else
                                                                                // УНП
                                                                                if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND SLUZBA IN (85,66) ";

                                                                                else Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                    }
                    else Command.CommandText += " AND SLUZBA NOT IN (9,52) ";
                }

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);

                Cache.Remove("Out_otric");
                Cache.Add("Out_otric", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);

                Response.Redirect("viewresult.aspx?cat=0&date1=" + OutDate1.Text + "&date2=" + OutDate2.Text + "&pdr=" + podrList.SelectedItem.Text);

            }

        }

        // Уволенные, прослужившие менее 1 года
        protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
        {
            DataSet ds = new DataSet();

            Command.CommandText = "SELECT ARCHIVE.FAMILIYA, ARCHIVE.IMYA, ARCHIVE.OTCHECTVO, DATA_ROZD, PODRAZD.PODRAZDEL, " +
                "SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, SLVSTU.P1, SLVPRU.P1 AS Expr1, ARCHIVE.DATA_UVOL, ARCHIVE.ZVANIE, " +
                "ARCHIVE.SL_RANE_OT, ARCHIVE.SL_RANE_DO, ARCHIVE.DATA_POST, ARCHIVE.LICH_NOM_1, ARCHIVE.LICH_NOM_2, " +
                "ARCHIVE.DATA_PR_UV, ARCHIVE.NOM_PR_UVO, SLVPR2.P1 AS Expr2, ZVANIE.VOIN_ZVAN FROM ARCHIVE, PODRAZD, SLUZBA, OFIC_DOL, " +
                "SLVSTU, SLVPRU, SLVPR2, ZVANIE WHERE ARCHIVE.ZVANIE = ZVANIE.KEY_ZVAN AND ARCHIVE.PODRAZD = PODRAZD.KEY_OF_POD AND " +
                "ARCHIVE.SLUZBA = SLUZBA.KEY_OF_SLU AND ARCHIVE.REAL_DOLZN = OFIC_DOL.P3 AND " +
                "ARCHIVE.ST_UV = SLVSTU.P2 AND ARCHIVE.PRICH_UV = SLVPRU.P2 AND " +
                "ARCHIVE.KTO_UVOLIL = SLVPR2.P2 AND DOLZNOST < '800000' " +
                "AND (((Archive.SL_RANE_OT IS NULL) AND ((Archive.DATA_UVOL - Archive.DATA_POST) < 365)) OR " +
                "((Archive.SL_RANE_OT IS NOT NULL) AND (((Archive.DATA_UVOL - Archive.DATA_POST) + (Archive.SL_RANE_DO - Archive.SL_RANE_OT) ) < 365))) " +
                "AND  (Archive.ST_UV <> '1010') AND  Archive.ZVANIE NOT IN (77, 78, 94, 95, 96, 97, 98, 99) AND " +
                "ARCHIVE.DAT_REG BETWEEN " + Convert.ToDateTime(OutDate1.Text).ToOADate() +
                " AND " + Convert.ToDateTime(OutDate2.Text).ToOADate();

            // Добавляем подразделение...
            switch (podrList.SelectedItem.Value)
            {
                case "101": Command.CommandText += " AND PODRAZD IN (54,2,3,4,5,28,29,30)"; break;
                case "102": Command.CommandText += " AND PODRAZD IN (10,7,24,18,312,20)"; break;
                case "103": Command.CommandText += " AND PODRAZD IN (17,16,6,25,21,26)"; break;
                case "104": Command.CommandText += " AND PODRAZD IN (8,13,23,14,11)"; break;
                case "105": Command.CommandText += " AND PODRAZD IN (19,27,15,152,9)"; break;
                case "-1": Command.CommandText += " AND PODRAZD IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "-2": Command.CommandText += " AND PODRAZD NOT IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "0": break;
                default: Command.CommandText += " AND PODRAZD = " + podrList.SelectedItem.Value; break;
            }

            // Выбор службы
            if (sluzList.SelectedItem.Value != "-1")
            {
                if (sluzList.SelectedItem.Value != "-2")
                {

                    // Объединение некоторых глобальных служб...
                    // КМ
                    if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                    else
                        // МОБ
                        if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                        else
                            // Кадры
                            if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                            else
                                // Тыл
                                if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) ";
                                else
                                    // ОВО
                                    if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND SLUZBA IN (9,52) ";
                                    else
                                        // Следствие
                                        if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND SLUZBA IN (10,55) ";
                                        else
                                            // ГИБДД
                                            if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
                                            else
                                                // УР
                                                if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND SLUZBA IN (24,25) ";
                                                else
                                                    // ППС
                                                    if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND SLUZBA IN (29,54) ";
                                                    else
                                                        // Приемники
                                                        if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND SLUZBA IN (33,63) ";
                                                        else
                                                            // Мед.вытрезв
                                                            if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND SLUZBA IN (40,60) ";
                                                            else
                                                                // Конвой
                                                                if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND SLUZBA IN (43,58) ";
                                                                else
                                                                    // ОМОН
                                                                    if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND SLUZBA IN (44,59) ";
                                                                    else
                                                                        // УЦ
                                                                        if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND SLUZBA IN (78,64) ";
                                                                        else
                                                                            // УНП
                                                                            if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND SLUZBA IN (85,66) ";

                                                                            else Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                }
                else Command.CommandText += " AND SLUZBA NOT IN (9,52) ";
            }

            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(ds);

            Cache.Remove("Out_dogoda");
            Cache.Add("Out_dogoda", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);

            Response.Redirect("viewresult.aspx?cat=1&date1=" + OutDate1.Text + "&date2=" + OutDate2.Text + "&pdr=" + podrList.SelectedItem.Text);

        }

        // Уволенные стажеры
        protected void ImageButton3_Click1(object sender, ImageClickEventArgs e)
        {
            DataSet ds = new DataSet();

            Command.CommandText = "SELECT ARCHIVE.FAMILIYA, ARCHIVE.IMYA, ARCHIVE.OTCHECTVO, DATA_ROZD, PODRAZD.PODRAZDEL, " +
                "SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, SLVSTU.P1, SLVPRU.P1 AS Expr1, ARCHIVE.DATA_UVOL, " +
                "ARCHIVE.SL_RANE_OT, ARCHIVE.SL_RANE_DO, ARCHIVE.DATA_POST, ARCHIVE.LICH_NOM_1, ARCHIVE.LICH_NOM_2, " +
                "ARCHIVE.DATA_PR_UV, ARCHIVE.NOM_PR_UVO, SLVPR2.P1 AS Expr2, ZVANIE.VOIN_ZVAN FROM ARCHIVE, PODRAZD, SLUZBA, OFIC_DOL, " +
                "SLVSTU, SLVPRU, SLVPR2, ZVANIE WHERE ARCHIVE.ZVANIE = ZVANIE.KEY_ZVAN AND ARCHIVE.PODRAZD = PODRAZD.KEY_OF_POD AND " +
                "ARCHIVE.SLUZBA = SLUZBA.KEY_OF_SLU AND ARCHIVE.REAL_DOLZN = OFIC_DOL.P3 AND " +
                "ARCHIVE.ST_UV = SLVSTU.P2 AND ARCHIVE.PRICH_UV = SLVPRU.P2 AND " +
                "ARCHIVE.KTO_UVOLIL = SLVPR2.P2 AND DOLZNOST < '800000' AND " +
                "ARCHIVE.ZVANIE = 99 AND " +
                "ARCHIVE.DAT_REG BETWEEN " + Convert.ToDateTime(OutDate1.Text).ToOADate() +
                " AND " + Convert.ToDateTime(OutDate2.Text).ToOADate();

            // Добавляем подразделение...
            switch (podrList.SelectedItem.Value)
            {
                case "101": Command.CommandText += " AND PODRAZD IN (54,2,3,4,5,28,29,30)"; break;
                case "102": Command.CommandText += " AND PODRAZD IN (10,7,24,18,312,20)"; break;
                case "103": Command.CommandText += " AND PODRAZD IN (17,16,6,25,21,26)"; break;
                case "104": Command.CommandText += " AND PODRAZD IN (8,13,23,14,11)"; break;
                case "105": Command.CommandText += " AND PODRAZD IN (19,27,15,152,9)"; break;
                case "-1": Command.CommandText += " AND PODRAZD IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "-2": Command.CommandText += " AND PODRAZD NOT IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "0": break;
                default: Command.CommandText += " AND PODRAZD = " + podrList.SelectedItem.Value; break;
            }

            // Выбор службы
            if (sluzList.SelectedItem.Value != "-1")
            {
                if (sluzList.SelectedItem.Value != "-2")
                {

                    // Объединение некоторых глобальных служб...
                    // КМ
                    if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                    else
                        // МОБ
                        if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                        else
                            // Кадры
                            if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                            else
                                // Тыл
                                if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) ";
                                else
                                    // ОВО
                                    if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND SLUZBA IN (9,52) ";
                                    else
                                        // Следствие
                                        if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND SLUZBA IN (10,55) ";
                                        else
                                            // ГИБДД
                                            if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
                                            else
                                                // УР
                                                if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND SLUZBA IN (24,25) ";
                                                else
                                                    // ППС
                                                    if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND SLUZBA IN (29,54) ";
                                                    else
                                                        // Приемники
                                                        if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND SLUZBA IN (33,63) ";
                                                        else
                                                            // Мед.вытрезв
                                                            if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND SLUZBA IN (40,60) ";
                                                            else
                                                                // Конвой
                                                                if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND SLUZBA IN (43,58) ";
                                                                else
                                                                    // ОМОН
                                                                    if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND SLUZBA IN (44,59) ";
                                                                    else
                                                                        // УЦ
                                                                        if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND SLUZBA IN (78,64) ";
                                                                        else
                                                                            // УНП
                                                                            if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND SLUZBA IN (85,66) ";
                                                                            else Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                }
                else Command.CommandText += " AND SLUZBA NOT IN (9,52) ";
            }

            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(ds);

            Cache.Remove("Out_stag");
            Cache.Add("Out_stag", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);

            Response.Redirect("viewresult.aspx?cat=2&date1=" + OutDate1.Text + "&date2=" + OutDate2.Text + "&pdr=" + podrList.SelectedItem.Text);
      }

        // Откомандированные сотрудники
        protected void ImageButton7_Click1(object sender, ImageClickEventArgs e)
        {
            DataSet ds = new DataSet();

            Command.CommandText = "SELECT VYEZD.FAMILIYA, VYEZD.IMYA, VYEZD.OTCHECTVO, PODRAZD.PODRAZDEL, " +
                "SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, VYEZD.DATA_POST, VYEZD.DATA_UVOL, VYEZD.ZVANIE, " +
                "VYEZD.PLACE, SLVPR2.P1, VYEZD.NOM_PR_UVO, VYEZD.DATA_PR_UV FROM VYEZD, PODRAZD, SLUZBA, " +
                "OFIC_DOL, ZVANIE, SLVPR2 WHERE VYEZD.PODRAZD = PODRAZD.KEY_OF_POD AND " +
                "VYEZD.SLUZBA = SLUZBA.KEY_OF_SLU AND VYEZD.REAL_DOLZN = OFIC_DOL.P3 AND " +
                "VYEZD.ZVANIE = ZVANIE.KEY_ZVAN AND VYEZD.KTO_UVOLIL = SLVPR2.P2 AND " +
                "DOLZNOST < '800000' AND ZVANIE NOT IN (77, 78, 94, 95, 96, 97, 98, 99) AND KOD_VYBYL NOT IN (104) AND " +
                "VYEZD.DATA_UVOL BETWEEN " + Convert.ToDateTime(OutDate1.Text).ToOADate() +
                " AND " + Convert.ToDateTime(OutDate2.Text).ToOADate();

            // Добавляем подразделение...
            switch (podrList.SelectedItem.Value)
            {
                case "101": Command.CommandText += " AND PODRAZD IN (54,2,3,4,5,28,29,30)"; break;
                case "102": Command.CommandText += " AND PODRAZD IN (10,7,24,18,312,20)"; break;
                case "103": Command.CommandText += " AND PODRAZD IN (17,16,6,25,21,26)"; break;
                case "104": Command.CommandText += " AND PODRAZD IN (8,13,23,14,11)"; break;
                case "105": Command.CommandText += " AND PODRAZD IN (19,27,15,152,9)"; break;
                case "-1": Command.CommandText += " AND PODRAZD IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "-2": Command.CommandText += " AND PODRAZD NOT IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "0": break;
                default: Command.CommandText += " AND PODRAZD = " + podrList.SelectedItem.Value; break;
            }

            // Выбор службы
            if (sluzList.SelectedItem.Value != "-1")
            {
                if (sluzList.SelectedItem.Value != "-2")
                {

                    // Объединение некоторых глобальных служб...
                    // КМ
                    if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                    else
                        // МОБ
                        if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                        else
                            // Кадры
                            if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                            else
                                // Тыл
                                if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) ";
                                else
                                    // ОВО
                                    if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND SLUZBA IN (9,52) ";
                                    else
                                        // Следствие
                                        if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND SLUZBA IN (10,55) ";
                                        else
                                            // ГИБДД
                                            if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
                                            else
                                                // УР
                                                if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND SLUZBA IN (24,25) ";
                                                else
                                                    // ППС
                                                    if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND SLUZBA IN (29,54) ";
                                                    else
                                                        // Приемники
                                                        if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND SLUZBA IN (33,63) ";
                                                        else
                                                            // Мед.вытрезв
                                                            if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND SLUZBA IN (40,60) ";
                                                            else
                                                                // Конвой
                                                                if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND SLUZBA IN (43,58) ";
                                                                else
                                                                    // ОМОН
                                                                    if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND SLUZBA IN (44,59) ";
                                                                    else
                                                                        // УЦ
                                                                        if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND SLUZBA IN (78,64) ";
                                                                        else
                                                                            // УНП
                                                                            if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND SLUZBA IN (85,66) ";
                                                                            else Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                }
                else Command.CommandText += " AND SLUZBA NOT IN (9,52) ";
            }

            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(ds);

            Cache.Remove("Out_kom");
            Cache.Add("Out_kom", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);

            Response.Redirect("viewresult.aspx?cat=3&date1=" + OutDate1.Text + "&date2=" + OutDate2.Text + "&pdr=" + podrList.SelectedItem.Text);
	   }

        // Сисок всех уволенных, без стажеров
        protected void Imagebutton9_Click1(object sender, ImageClickEventArgs e)
        {
            if (OutDate1.Text != "" && OutDate2.Text != "")
            {
                DataSet ds = new DataSet();

                Command.CommandText = "SELECT ARCHIVE.FAMILIYA, ARCHIVE.IMYA, ARCHIVE.OTCHECTVO, DATA_ROZD, PODRAZD.PODRAZDEL, " +
                    "SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, SLVSTU.P1, SLVPRU.P1 AS Expr1, ARCHIVE.DATA_UVOL, ARCHIVE.ZVANIE, " +
                    "ARCHIVE.SL_RANE_OT, ARCHIVE.SL_RANE_DO, ARCHIVE.DATA_POST, ARCHIVE.LICH_NOM_1, ARCHIVE.LICH_NOM_2, ARCHIVE.NOMLICHDEL, " +
                    "ARCHIVE.DATA_PR_UV, ARCHIVE.NOM_PR_UVO, SLVPR2.P1 AS Expr2, ZVANIE.VOIN_ZVAN FROM ARCHIVE, PODRAZD, SLUZBA, OFIC_DOL, " +
                    "SLVSTU, SLVPRU, SLVPR2, ZVANIE WHERE ARCHIVE.ZVANIE = ZVANIE.KEY_ZVAN AND ARCHIVE.PODRAZD = PODRAZD.KEY_OF_POD AND " +
                    "ARCHIVE.SLUZBA = SLUZBA.KEY_OF_SLU AND ARCHIVE.REAL_DOLZN = OFIC_DOL.P3 AND " +
                    "ARCHIVE.ST_UV = SLVSTU.P2 AND ARCHIVE.PRICH_UV = SLVPRU.P2 AND " +
                    "ARCHIVE.KTO_UVOLIL = SLVPR2.P2 AND DOLZNOST < '800000' AND " +
                    "(ZVANIE < 77 OR ZVANIE > 99) AND " +
                    "ARCHIVE.DAT_REG BETWEEN " + Convert.ToDateTime(OutDate1.Text).ToOADate() +
                    " AND " + Convert.ToDateTime(OutDate2.Text).ToOADate();

                // Добавляем подразделение...
                switch (podrList.SelectedItem.Value)
                {
                    case "101": Command.CommandText += " AND PODRAZD IN (54,2,3,4,5,28,29,30)"; break;
                    case "102": Command.CommandText += " AND PODRAZD IN (10,7,24,18,312,20)"; break;
                    case "103": Command.CommandText += " AND PODRAZD IN (17,16,6,25,21,26)"; break;
                    case "104": Command.CommandText += " AND PODRAZD IN (8,13,23,14,11)"; break;
                    case "105": Command.CommandText += " AND PODRAZD IN (19,27,15,152,9)"; break;
                    case "-1": Command.CommandText += " AND PODRAZD IN (1,2,3,4,5,28,29,30,31,54)"; break;
                    case "-2": Command.CommandText += " AND PODRAZD NOT IN (1,2,3,4,5,28,29,30,31,54)"; break;
                    case "0": break;
                    default: Command.CommandText += " AND PODRAZD = " + podrList.SelectedItem.Value; break;
                }

                // Выбор службы
                if (sluzList.SelectedItem.Value != "-1")
                {
                    if (sluzList.SelectedItem.Value != "-2")
                    {

                        // Объединение некоторых глобальных служб...
                        // КМ
                        if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                        else
                            // МОБ
                            if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                            else
                                // Кадры
                                if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                                else
                                    // Тыл
                                    if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) ";
                                    else
                                        // ОВО
                                        if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND SLUZBA IN (9,52) ";
                                        else
                                            // Следствие
                                            if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND SLUZBA IN (10,55) ";
                                            else
                                                // ГИБДД
                                                if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
                                                else
                                                    // УР
                                                    if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND SLUZBA IN (24,25) ";
                                                    else
                                                        // ППС
                                                        if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND SLUZBA IN (29,54) ";
                                                        else
                                                            // Приемники
                                                            if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND SLUZBA IN (33,63) ";
                                                            else
                                                                // Мед.вытрезв
                                                                if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND SLUZBA IN (40,60) ";
                                                                else
                                                                    // Конвой
                                                                    if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND SLUZBA IN (43,58) ";
                                                                    else
                                                                        // ОМОН
                                                                        if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND SLUZBA IN (44,59) ";
                                                                        else
                                                                            // УЦ
                                                                            if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND SLUZBA IN (78,64) ";
                                                                            else
                                                                                // УНП
                                                                                if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND SLUZBA IN (85,66) ";
                                                                                else Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                    }
                    else Command.CommandText += " AND SLUZBA NOT IN (9,52) ";
                }

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);

                Cache.Remove("Out_All");
                Cache.Add("Out_All", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);

                Response.Redirect("viewresult.aspx?cat=8&date1=" + OutDate1.Text + "&date2=" + OutDate2.Text + "&pdr=" + podrList.SelectedItem.Text);

            }

        }

        // Уволенные сотрудники по п."е" (сокращение штатов)
        protected void Imagebutton10_Click1(object sender, ImageClickEventArgs e)
        {
            if (OutDate1.Text != "" && OutDate2.Text != "")
            {
                DataSet ds = new DataSet();

                Command.CommandText = "SELECT ARCHIVE.FAMILIYA, ARCHIVE.IMYA, ARCHIVE.OTCHECTVO, DATA_ROZD, PODRAZD.PODRAZDEL, " +
                    "SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, SLVSTU.P1, ARCHIVE.DATA_UVOL, ARCHIVE.ZVANIE, " +
                    "ARCHIVE.SL_RANE_OT, ARCHIVE.SL_RANE_DO, ARCHIVE.DATA_POST, ARCHIVE.LICH_NOM_1, ARCHIVE.LICH_NOM_2, " +
                    "ARCHIVE.DATA_PR_UV, ARCHIVE.NOM_PR_UVO, SLVPR2.P1 AS Expr2, ZVANIE.VOIN_ZVAN FROM ARCHIVE, PODRAZD, SLUZBA, OFIC_DOL, " +
                    "SLVSTU, SLVPR2, ZVANIE WHERE ARCHIVE.ZVANIE = ZVANIE.KEY_ZVAN AND ARCHIVE.PODRAZD = PODRAZD.KEY_OF_POD AND " +
                    "ARCHIVE.SLUZBA = SLUZBA.KEY_OF_SLU AND ARCHIVE.REAL_DOLZN = OFIC_DOL.P3 AND " +
                    "ARCHIVE.ST_UV = SLVSTU.P2 AND ARCHIVE.PRICH_UV = '1017' AND " +
                    "ARCHIVE.KTO_UVOLIL = SLVPR2.P2 AND DOLZNOST < '800000' AND " +
                    "(ZVANIE < 77 OR ZVANIE > 99) AND " +
                    "ARCHIVE.DAT_REG BETWEEN " + Convert.ToDateTime(OutDate1.Text).ToOADate() +
                    " AND " + Convert.ToDateTime(OutDate2.Text).ToOADate();

                // Добавляем подразделение...
                switch (podrList.SelectedItem.Value)
                {
                    case "101": Command.CommandText += " AND PODRAZD IN (54,2,3,4,5,28,29,30)"; break;
                    case "102": Command.CommandText += " AND PODRAZD IN (10,7,24,18,312,20)"; break;
                    case "103": Command.CommandText += " AND PODRAZD IN (17,16,6,25,21,26)"; break;
                    case "104": Command.CommandText += " AND PODRAZD IN (8,13,23,14,11)"; break;
                    case "105": Command.CommandText += " AND PODRAZD IN (19,27,15,152,9)"; break;
                    case "-1": Command.CommandText += " AND PODRAZD IN (1,2,3,4,5,28,29,30,31,54)"; break;
                    case "-2": Command.CommandText += " AND PODRAZD NOT IN (1,2,3,4,5,28,29,30,31,54)"; break;
                    case "0": break;
                    default: Command.CommandText += " AND PODRAZD = " + podrList.SelectedItem.Value; break;
                }

                // Выбор службы
                if (sluzList.SelectedItem.Value != "-1")
                {
                    if (sluzList.SelectedItem.Value != "-2")
                    {

                        // Объединение некоторых глобальных служб...
                        // КМ
                        if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                        else
                            // МОБ
                            if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                            else
                                // Кадры
                                if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                                else
                                    // Тыл
                                    if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) ";
                                    else
                                        // ОВО
                                        if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND SLUZBA IN (9,52) ";
                                        else
                                            // Следствие
                                            if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND SLUZBA IN (10,55) ";
                                            else
                                                // ГИБДД
                                                if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
                                                else
                                                    // УР
                                                    if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND SLUZBA IN (24,25) ";
                                                    else
                                                        // ППС
                                                        if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND SLUZBA IN (29,54) ";
                                                        else
                                                            // Приемники
                                                            if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND SLUZBA IN (33,63) ";
                                                            else
                                                                // Мед.вытрезв
                                                                if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND SLUZBA IN (40,60) ";
                                                                else
                                                                    // Конвой
                                                                    if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND SLUZBA IN (43,58) ";
                                                                    else
                                                                        // ОМОН
                                                                        if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND SLUZBA IN (44,59) ";
                                                                        else
                                                                            // УЦ
                                                                            if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND SLUZBA IN (78,64) ";
                                                                            else
                                                                                // УНП
                                                                                if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND SLUZBA IN (85,66) ";
                                                                                else Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                    }
                    else Command.CommandText += " AND SLUZBA NOT IN (9,52) ";
                }

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);

                Cache.Remove("Out_Sokr");
                Cache.Add("Out_Sokr", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);

                Response.Redirect("viewresult.aspx?cat=9&date1=" + OutDate1.Text + "&date2=" + OutDate2.Text + "&pdr=" + podrList.SelectedItem.Text);

            }
        }

        // Список всех принятых сотрудников
        protected void ImageButton6_Click1(object sender, ImageClickEventArgs e)
        {
            DataSet ds = new DataSet();

            Command.CommandText = "SELECT PRIEM.FAMILIYA, PRIEM.IMYA, PRIEM.OTCHECTVO, PRIEM.DATA_ROZD, " +
                "PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, PRIEM.DATA_POST, PRIEM.ZVANIE, " +
                "SLVPR2.P1, N_PR_VDOLZ, DAT_PRI FROM PRIEM, PODRAZD, SLUZBA, OFIC_DOL, ZVANIE, SLVPR2 WHERE " +
                "PRIEM.N_PR_DOLZ1 = SLVPR2.P2 AND " +
                "(PRIEM.PODRAZD = PODRAZD.KEY_OF_POD) AND (PRIEM.SLUZBA = SLUZBA.KEY_OF_SLU) AND " +
                "(PRIEM.DOLZNOST = OFIC_DOL.P3) AND (PRIEM.ZVANIE = ZVANIE.KEY_ZVAN) AND " +
                "(PRIEM.DOLZNOST < '800000') AND (ZVANIE < 77 OR ZVANIE >= 99) AND " +
                "((KAT_POST IS NULL ) OR (KAT_POST > 102)) AND " +
                "PRIEM.DAT_REG BETWEEN " + Convert.ToDateTime(InDate1.Text).ToOADate() +
                " AND " + Convert.ToDateTime(InDate2.Text).ToOADate();

            // Добавляем подразделение...
            switch (podrList.SelectedItem.Value)
            {
                case "101": Command.CommandText += " AND PODRAZD IN (54,2,3,4,5,28,29,30)"; break;
                case "102": Command.CommandText += " AND PODRAZD IN (10,7,24,18,312,20)"; break;
                case "103": Command.CommandText += " AND PODRAZD IN (17,16,6,25,21,26)"; break;
                case "104": Command.CommandText += " AND PODRAZD IN (8,13,23,14,11)"; break;
                case "105": Command.CommandText += " AND PODRAZD IN (19,27,15,152,9)"; break;
                case "-1": Command.CommandText += " AND PODRAZD IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "-2": Command.CommandText += " AND PODRAZD NOT IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "0": break;
                default: Command.CommandText += " AND PODRAZD = " + podrList.SelectedItem.Value; break;
            }

            // Выбор службы
            if (sluzList.SelectedItem.Value != "-1")
            {
                if (sluzList.SelectedItem.Value != "-2")
                {

                    // Объединение некоторых глобальных служб...
                    // КМ
                    if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                    else
                        // МОБ
                        if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                        else
                            // Кадры
                            if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                            else
                                // Тыл
                                if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) ";
                                else
                                    // ОВО
                                    if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND SLUZBA IN (9,52) ";
                                    else
                                        // Следствие
                                        if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND SLUZBA IN (10,55) ";
                                        else
                                            // ГИБДД
                                            if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
                                            else
                                                // УР
                                                if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND SLUZBA IN (24,25) ";
                                                else
                                                    // ППС
                                                    if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND SLUZBA IN (29,54) ";
                                                    else
                                                        // Приемники
                                                        if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND SLUZBA IN (33,63) ";
                                                        else
                                                            // Мед.вытрезв
                                                            if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND SLUZBA IN (40,60) ";
                                                            else
                                                                // Конвой
                                                                if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND SLUZBA IN (43,58) ";
                                                                else
                                                                    // ОМОН
                                                                    if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND SLUZBA IN (44,59) ";
                                                                    else
                                                                        // УЦ
                                                                        if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND SLUZBA IN (78,64) ";
                                                                        else
                                                                            // УНП
                                                                            if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND SLUZBA IN (85,66) ";

                                                                            else Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                }
                else Command.CommandText += " AND SLUZBA NOT IN (9,52) ";
            }

            Command.CommandText += " ORDER BY PRIEM.FAMILIYA";

            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(ds);

            Cache.Remove("In_All");
            Cache.Add("In_All", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);

            Response.Redirect("viewresult.aspx?cat=4&date1=" + InDate1.Text + "&date2=" + InDate2.Text + "&pdr=" + podrList.SelectedItem.Text);

        }

      
        // Количество принятых по службам и подразделениям
        protected void ImageButton5_Click1(object sender, ImageClickEventArgs e)
        {
            DataSet ds = new DataSet();

            Command.CommandText = "SELECT PRIEM.FAMILIYA, PRIEM.IMYA, PRIEM.OTCHECTVO, PRIEM.DATA_ROZD, PRIEM.PODRAZD, PRIEM.SLUZBA, PRIEM.DOLZNOST, " +
                "PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, PRIEM.DATA_POST, " +
                "SLVPR2.P1, N_PR_VDOLZ, DAT_PRI FROM PRIEM, PODRAZD, SLUZBA, OFIC_DOL, ZVANIE, SLVPR2 WHERE " +
                "PRIEM.N_PR_DOLZ1 = SLVPR2.P2 AND PRIEM.SLUZBA IS NOT NULL AND " +
                "PRIEM.PODRAZD = PODRAZD.KEY_OF_POD AND PRIEM.SLUZBA = SLUZBA.KEY_OF_SLU AND " +
                "PRIEM.DOLZNOST = OFIC_DOL.P3 AND PRIEM.ZVANIE = ZVANIE.KEY_ZVAN AND " +
                "PRIEM.DOLZNOST < '800000' AND (ZVANIE < 77 OR ZVANIE >= 99) AND " +
                "((KAT_POST IS NULL ) OR (KAT_POST > 102)) AND " +
                "PRIEM.DAT_REG BETWEEN " + Convert.ToDateTime(InDate1.Text).ToOADate() +
                " AND " + Convert.ToDateTime(InDate2.Text).ToOADate();

            // Добавляем подразделение...
            switch (podrList.SelectedItem.Value)
            {
                case "101": Command.CommandText += " AND PODRAZD IN (54,2,3,4,5,28,29,30)"; break;
                case "102": Command.CommandText += " AND PODRAZD IN (10,7,24,18,312,20)"; break;
                case "103": Command.CommandText += " AND PODRAZD IN (17,16,6,25,21,26)"; break;
                case "104": Command.CommandText += " AND PODRAZD IN (8,13,23,14,11)"; break;
                case "105": Command.CommandText += " AND PODRAZD IN (19,27,15,152,9)"; break;
                case "-1": Command.CommandText += " AND PODRAZD IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "-2": Command.CommandText += " AND PODRAZD NOT IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "0": break;
                default: Command.CommandText += " AND PODRAZD = " + podrList.SelectedItem.Value; break;
            }

            // Выбор службы
            if (sluzList.SelectedItem.Value != "-1")
            {
                if (sluzList.SelectedItem.Value != "-2")
                {

                    // Объединение некоторых глобальных служб...
                    // КМ
                    if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                    else
                        // МОБ
                        if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                        else
                            // Кадры
                            if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                            else
                                // Тыл
                                if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) ";
                                else
                                    // ОВО
                                    if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND SLUZBA IN (9,52) ";
                                    else
                                        // Следствие
                                        if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND SLUZBA IN (10,55) ";
                                        else
                                            // ГИБДД
                                            if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
                                            else
                                                // УР
                                                if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND SLUZBA IN (24,25) ";
                                                else
                                                    // ППС
                                                    if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND SLUZBA IN (29,54) ";
                                                    else
                                                        // Приемники
                                                        if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND SLUZBA IN (33,63) ";
                                                        else
                                                            // Мед.вытрезв
                                                            if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND SLUZBA IN (40,60) ";
                                                            else
                                                                // Конвой
                                                                if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND SLUZBA IN (43,58) ";
                                                                else
                                                                    // ОМОН
                                                                    if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND SLUZBA IN (44,59) ";
                                                                    else
                                                                        // УЦ
                                                                        if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND SLUZBA IN (78,64) ";
                                                                        else
                                                                            // УНП
                                                                            if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND SLUZBA IN (85,66) ";

                                                                            else Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                }
                else Command.CommandText += " AND SLUZBA NOT IN (9,52) ";
            }

            if (RBtn1.Checked)
            {
                Command.CommandText += " ORDER BY PRIEM.PODRAZD";
            }
            if (RBtn2.Checked)
            {
                Command.CommandText += " ORDER BY PRIEM.SLUZBA";
            }

            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(ds);

            if (RBtn1.Checked)
            {
                Cache.Remove("In_pdr");
                Cache.Add("In_pdr", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);
                Response.Redirect("viewresult.aspx?cat=51&date1=" + InDate1.Text + "&date2=" + InDate2.Text + "&pdr=" + podrList.SelectedItem.Text);
            }
            if (RBtn2.Checked)
            {
                Cache.Remove("In_slz");
                Cache.Add("In_slz", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);
                Response.Redirect("viewresult.aspx?cat=52&date1=" + InDate1.Text + "&date2=" + InDate2.Text + "&pdr=" + podrList.SelectedItem.Text);
            }

        }

        // Прибывшие по окончании УЗ МВД России
        protected void ImageButton8_Click1(object sender, ImageClickEventArgs e)
        {
            DataSet ds = new DataSet();

            Command.CommandText = "SELECT PRIEM.FAMILIYA, PRIEM.IMYA, PRIEM.OTCHECTVO, PRIEM.DATA_ROZD, " +
                "PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, PRIEM.DATA_POST, PRIEM.ZVANIE, " +
                "SLVPR2.P1, N_PR_VDOLZ, DAT_PRI, OTKYDA AS UCH FROM PRIEM, PODRAZD, SLUZBA, OFIC_DOL, ZVANIE, SLVPR2, SLVUCZ WHERE " +
                "PRIEM.N_PR_DOLZ1 = SLVPR2.P2 AND " +
                "PRIEM.UCHZAV = SLVUCZ.P2 AND " +
                "PRIEM.PODRAZD = PODRAZD.KEY_OF_POD AND PRIEM.SLUZBA = SLUZBA.KEY_OF_SLU AND " +
                "PRIEM.DOLZNOST = OFIC_DOL.P3 AND PRIEM.ZVANIE = ZVANIE.KEY_ZVAN AND " +
                "PRIEM.DOLZNOST < '800000' AND (ZVANIE < 77 OR ZVANIE >= 99) AND " +
                "KAT_POST IN (103) AND " +
                "PRIEM.DAT_REG >= " + Convert.ToDateTime(InDate1.Text).ToOADate() +
                " AND PRIEM.DAT_REG <= " + Convert.ToDateTime(InDate2.Text).ToOADate();

            //			Command.CommandText = "SELECT PRIEM.FAMILIYA, PRIEM.IMYA, PRIEM.OTCHECTVO, PRIEM.DATA_ROZD, " + 
            //				"PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, PRIEM.DATA_POST, " +
            //				"SLVPR2.P1, N_PR_VDOLZ, DAT_PRI, OTKYDA FROM PRIEM, PODRAZD, SLUZBA, OFIC_DOL, ZVANIE, SLVPR2 WHERE " +
            //				"PRIEM.N_PR_DOLZ1 = SLVPR2.P2 AND " +
            //				"PRIEM.PODRAZD = PODRAZD.KEY_OF_POD AND PRIEM.SLUZBA = SLUZBA.KEY_OF_SLU AND " +
            //				"PRIEM.DOLZNOST = OFIC_DOL.P3 AND PRIEM.ZVANIE = ZVANIE.KEY_ZVAN AND " +
            //				"PRIEM.DOLZNOST < '800000' AND (ZVANIE < 77 OR ZVANIE = 99) AND " +
            //				"PRIEM.KAT_POST IN (101,102) AND " +
            //				"PRIEM.DAT_REG >= " + Convert.ToDateTime(InDate1.Text).ToOADate() +
            //				" AND PRIEM.DAT_REG <= " + Convert.ToDateTime(InDate2.Text).ToOADate();

            // Добавляем подразделение...
            switch (podrList.SelectedItem.Value)
            {
                case "101": Command.CommandText += " AND PODRAZD IN (54,2,3,4,5,28,29,30)"; break;
                case "102": Command.CommandText += " AND PODRAZD IN (10,7,24,18,312,20)"; break;
                case "103": Command.CommandText += " AND PODRAZD IN (17,16,6,25,21,26)"; break;
                case "104": Command.CommandText += " AND PODRAZD IN (8,13,23,14,11)"; break;
                case "105": Command.CommandText += " AND PODRAZD IN (19,27,15,152,9)"; break;
                case "-1": Command.CommandText += " AND PODRAZD IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "-2": Command.CommandText += " AND PODRAZD NOT IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "0": break;
                default: Command.CommandText += " AND PODRAZD = " + podrList.SelectedItem.Value; break;
            }

            // Выбор службы
            if (sluzList.SelectedItem.Value != "-1")
            {
                if (sluzList.SelectedItem.Value != "-2")
                {

                    // Объединение некоторых глобальных служб...
                    // КМ
                    if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                    else
                        // МОБ
                        if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                        else
                            // Кадры
                            if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                            else
                                // Тыл
                                if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) ";
                                else
                                    // ОВО
                                    if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND SLUZBA IN (9,52) ";
                                    else
                                        // Следствие
                                        if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND SLUZBA IN (10,55) ";
                                        else
                                            // ГИБДД
                                            if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
                                            else
                                                // УР
                                                if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND SLUZBA IN (24,25) ";
                                                else
                                                    // ППС
                                                    if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND SLUZBA IN (29,54) ";
                                                    else
                                                        // Приемники
                                                        if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND SLUZBA IN (33,63) ";
                                                        else
                                                            // Мед.вытрезв
                                                            if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND SLUZBA IN (40,60) ";
                                                            else
                                                                // Конвой
                                                                if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND SLUZBA IN (43,58) ";
                                                                else
                                                                    // ОМОН
                                                                    if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND SLUZBA IN (44,59) ";
                                                                    else
                                                                        // УЦ
                                                                        if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND SLUZBA IN (78,64) ";
                                                                        else
                                                                            // УНП
                                                                            if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND SLUZBA IN (85,66) ";
                                                                            else Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                }
                else Command.CommandText += " AND SLUZBA NOT IN (9,52) ";
            }

            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(ds);
            //Response.Write(Command.CommandText);

            Cache.Remove("In_vypusk");
            Cache.Add("In_vypusk", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);

            Response.Redirect("viewresult.aspx?cat=6&date1=" + InDate1.Text + "&date2=" + InDate2.Text + "&pdr=" + podrList.SelectedItem.Text);


        }

        // Список прибывших из других регионов и ведомств
        protected void ImageButton4_Click1(object sender, ImageClickEventArgs e)
        {
            DataSet ds = new DataSet();

            Command.CommandText = "SELECT PRIEM.FAMILIYA, PRIEM.IMYA, PRIEM.OTCHECTVO, PRIEM.DATA_ROZD, PRIEM.ZVANIE, " +
                "PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, PRIEM.DATA_POST, " +
                "SLVPR2.P1, N_PR_VDOLZ, DAT_PRI, OTKYDA FROM PRIEM, PODRAZD, SLUZBA, OFIC_DOL, ZVANIE, SLVPR2 WHERE " +
                "PRIEM.N_PR_DOLZ1 = SLVPR2.P2 AND " +
                "PRIEM.PODRAZD = PODRAZD.KEY_OF_POD AND PRIEM.SLUZBA = SLUZBA.KEY_OF_SLU AND " +
                "PRIEM.DOLZNOST = OFIC_DOL.P3 AND PRIEM.ZVANIE = ZVANIE.KEY_ZVAN AND " +
                "PRIEM.DOLZNOST < '800000' AND (ZVANIE < 77 OR ZVANIE >= 99) AND " +
                "PRIEM.KAT_POST IN (101,102) AND " +
                "PRIEM.DAT_REG >= " + Convert.ToDateTime(InDate1.Text).ToOADate() +
                " AND PRIEM.DAT_REG <= " + Convert.ToDateTime(InDate2.Text).ToOADate();

            // Добавляем подразделение...
            switch (podrList.SelectedItem.Value)
            {
                case "101": Command.CommandText += " AND PODRAZD IN (54,2,3,4,5,28,29,30)"; break;
                case "102": Command.CommandText += " AND PODRAZD IN (10,7,24,18,312,20)"; break;
                case "103": Command.CommandText += " AND PODRAZD IN (17,16,6,25,21,26)"; break;
                case "104": Command.CommandText += " AND PODRAZD IN (8,13,23,14,11)"; break;
                case "105": Command.CommandText += " AND PODRAZD IN (19,27,15,152,9)"; break;
                case "-1": Command.CommandText += " AND PODRAZD IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "-2": Command.CommandText += " AND PODRAZD NOT IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "0": break;
                default: Command.CommandText += " AND PODRAZD = " + podrList.SelectedItem.Value; break;
            }

            // Выбор службы
            if (sluzList.SelectedItem.Value != "-1")
            {
                if (sluzList.SelectedItem.Value != "-2")
                {

                    // Объединение некоторых глобальных служб...
                    // КМ
                    if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                    else
                        // МОБ
                        if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                        else
                            // Кадры
                            if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                            else
                                // Тыл
                                if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) ";
                                else
                                    // ОВО
                                    if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND SLUZBA IN (9,52) ";
                                    else
                                        // Следствие
                                        if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND SLUZBA IN (10,55) ";
                                        else
                                            // ГИБДД
                                            if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
                                            else
                                                // УР
                                                if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND SLUZBA IN (24,25) ";
                                                else
                                                    // ППС
                                                    if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND SLUZBA IN (29,54) ";
                                                    else
                                                        // Приемники
                                                        if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND SLUZBA IN (33,63) ";
                                                        else
                                                            // Мед.вытрезв
                                                            if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND SLUZBA IN (40,60) ";
                                                            else
                                                                // Конвой
                                                                if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND SLUZBA IN (43,58) ";
                                                                else
                                                                    // ОМОН
                                                                    if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND SLUZBA IN (44,59) ";
                                                                    else
                                                                        // УЦ
                                                                        if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND SLUZBA IN (78,64) ";
                                                                        else
                                                                            // УНП
                                                                            if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND SLUZBA IN (85,66) ";
                                                                            else Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                }
                else Command.CommandText += " AND SLUZBA NOT IN (9,52) ";
            }

            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(ds);
            //Response.Write(Command.CommandText);

            Cache.Remove("In_prib");
            Cache.Add("In_prib", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);

            Response.Redirect("viewresult.aspx?cat=7&date1=" + InDate1.Text + "&date2=" + InDate2.Text + "&pdr=" + podrList.SelectedItem.Text);

        }

        // Уволенные по собственному желанию (без пенсии)
        protected void Imagebutton11_Click(object sender, ImageClickEventArgs e)
        {
            DataSet ds = new DataSet();

            Command.CommandText = "SELECT ARCHIVE.FAMILIYA, ARCHIVE.IMYA, ARCHIVE.OTCHECTVO, DATA_ROZD, PODRAZD.PODRAZDEL, " +
                "SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, SLVSTU.P1, SLVPRU.P1 AS PRICH, ARCHIVE.DATA_UVOL, ARCHIVE.ZVANIE, " +
                "ARCHIVE.SL_RANE_OT, ARCHIVE.SL_RANE_DO, ARCHIVE.DATA_POST, ARCHIVE.LICH_NOM_1, ARCHIVE.LICH_NOM_2, " +
                "ARCHIVE.DATA_PR_UV, ARCHIVE.NOM_PR_UVO, SLVPR2.P1 AS Expr2, ZVANIE.VOIN_ZVAN FROM ARCHIVE, PODRAZD, SLUZBA, OFIC_DOL, " +
                "SLVSTU, SLVPRU, SLVPR2, ZVANIE WHERE ARCHIVE.ZVANIE = ZVANIE.KEY_ZVAN AND ARCHIVE.PODRAZD = PODRAZD.KEY_OF_POD AND " +
                "ARCHIVE.SLUZBA = SLUZBA.KEY_OF_SLU AND ARCHIVE.REAL_DOLZN = OFIC_DOL.P3 AND " +
                "ARCHIVE.ST_UV = SLVSTU.P2 AND ARCHIVE.PRICH_UV = SLVPRU.P2 AND " +
                "ARCHIVE.KTO_UVOLIL = SLVPR2.P2 AND DOLZNOST < '800000' " +
                "AND Archive.PRICH_UV IN ('1002','1009','1025','1038') AND (Archive.DATA_UVOL - Archive.DATA_POST) < 7300 AND " +
                "Archive.ZVANIE NOT IN (77, 78, 94, 95, 96, 97, 98, 99) AND " +
                "ARCHIVE.DATA_UVOL BETWEEN " + Convert.ToDateTime(OutDate1.Text).ToOADate() +
                " AND " + Convert.ToDateTime(OutDate2.Text).ToOADate();

            // Добавляем подразделение...
            switch (podrList.SelectedItem.Value)
            {
                case "101": Command.CommandText += " AND PODRAZD IN (54,2,3,4,5,28,29,30)"; break;
                case "102": Command.CommandText += " AND PODRAZD IN (10,7,24,18,312,20)"; break;
                case "103": Command.CommandText += " AND PODRAZD IN (17,16,6,25,21,26)"; break;
                case "104": Command.CommandText += " AND PODRAZD IN (8,13,23,14,11)"; break;
                case "105": Command.CommandText += " AND PODRAZD IN (19,27,15,152,9)"; break;
                case "-1": Command.CommandText += " AND PODRAZD IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "-2": Command.CommandText += " AND PODRAZD NOT IN (1,2,3,4,5,28,29,30,31,54)"; break;
                case "0": break;
                default: Command.CommandText += " AND PODRAZD = " + podrList.SelectedItem.Value; break;
            }

            // Выбор службы
            if (sluzList.SelectedItem.Value != "-1")
            {
                if (sluzList.SelectedItem.Value != "-2")
                {

                    // Объединение некоторых глобальных служб...
                    // КМ
                    if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                    else
                        // МОБ
                        if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                        else
                            // Кадры
                            if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                            else
                                // Тыл
                                if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) ";
                                else
                                    // ОВО
                                    if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND SLUZBA IN (9,52) ";
                                    else
                                        // Следствие
                                        if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND SLUZBA IN (10,55) ";
                                        else
                                            // ГИБДД
                                            if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
                                            else
                                                // УР
                                                if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND SLUZBA IN (24,25) ";
                                                else
                                                    // ППС
                                                    if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND SLUZBA IN (29,54) ";
                                                    else
                                                        // Приемники
                                                        if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND SLUZBA IN (33,63) ";
                                                        else
                                                            // Мед.вытрезв
                                                            if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND SLUZBA IN (40,60) ";
                                                            else
                                                                // Конвой
                                                                if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND SLUZBA IN (43,58) ";
                                                                else
                                                                    // ОМОН
                                                                    if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND SLUZBA IN (44,59) ";
                                                                    else
                                                                        // УЦ
                                                                        if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND SLUZBA IN (78,64) ";
                                                                        else
                                                                            // УНП
                                                                            if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND SLUZBA IN (85,66) ";

                                                                            else Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
                }
                else Command.CommandText += " AND SLUZBA NOT IN (9,52) ";
            }

            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(ds);

            Cache.Remove("Out_perswish");
            Cache.Add("Out_perswish", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);

            Response.Redirect("viewresult.aspx?cat=10&date1=" + OutDate1.Text + "&date2=" + OutDate2.Text + "&pdr=" + podrList.SelectedItem.Text);

        }

        // Уволенные работники (без фггс)
        protected void Imagebutton12_Click(object sender, ImageClickEventArgs e)
        {
            if (OutDate1.Text != "" && OutDate2.Text != "")
            {
                DataSet ds = new DataSet();

                Command.CommandText = String.Format("SELECT ARCHIVE.FAMILIYA, ARCHIVE.IMYA, ARCHIVE.OTCHECTVO, DATA_ROZD, PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, SLVSTU.P1, SLVPRU.P1 AS Expr1, ARCHIVE.DATA_UVOL, ARCHIVE.ZVANIE, ARCHIVE.SL_RANE_OT, ARCHIVE.SL_RANE_DO, ARCHIVE.DATA_POST, ARCHIVE.LICH_NOM_1, ARCHIVE.LICH_NOM_2, ARCHIVE.NOMLICHDEL, ARCHIVE.DATA_PR_UV, ARCHIVE.NOM_PR_UVO, SLVPR2.P1 AS Expr2, ZVANIE.VOIN_ZVAN FROM ARCHIVE, PODRAZD, SLUZBA, OFIC_DOL, SLVSTU, SLVPRU, SLVPR2, ZVANIE WHERE ARCHIVE.ZVANIE = ZVANIE.KEY_ZVAN AND ARCHIVE.PODRAZD = PODRAZD.KEY_OF_POD AND ARCHIVE.SLUZBA = SLUZBA.KEY_OF_SLU AND ARCHIVE.REAL_DOLZN = OFIC_DOL.P3 AND ARCHIVE.ST_UV = SLVSTU.P2 AND ARCHIVE.PRICH_UV = SLVPRU.P2 AND ARCHIVE.KTO_UVOLIL = SLVPR2.P2 AND DOLZNOST > '800000' AND LOWER(NAM_OF_DOL) LIKE '%фггс%' AND ARCHIVE.DAT_REG BETWEEN {0} AND {1}", Convert.ToDateTime(OutDate1.Text).ToOADate(), Convert.ToDateTime(OutDate2.Text).ToOADate());

                // Добавляем подразделение...
                switch (podrList.SelectedItem.Value)
                {
                    case "101": Command.CommandText += " AND PODRAZD IN (54,2,3,4,5,28,29,30)"; break;
                    case "102": Command.CommandText += " AND PODRAZD IN (10,7,24,18,312,20)"; break;
                    case "103": Command.CommandText += " AND PODRAZD IN (17,16,6,25,21,26)"; break;
                    case "104": Command.CommandText += " AND PODRAZD IN (8,13,23,14,11)"; break;
                    case "105": Command.CommandText += " AND PODRAZD IN (19,27,15,152,9)"; break;
                    case "-1": Command.CommandText += " AND PODRAZD IN (1,2,3,4,5,28,29,30,31,54)"; break;
                    case "-2": Command.CommandText += " AND PODRAZD NOT IN (1,2,3,4,5,28,29,30,31,54)"; break;
                    case "0": break;
                    default: Command.CommandText += " AND PODRAZD = " + podrList.SelectedItem.Value; break;
                }

                // Выбор службы
                if (sluzList.SelectedItem.Value != "-1")
                {
                    if (sluzList.SelectedItem.Value != "-2")
                    {

                        // Объединение некоторых глобальных служб...
                        // КМ
                        if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                        else
                            // МОБ
                            if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                            else
                                // Кадры
                                if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                                else
                                    // Тыл
                                    if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) ";
                                    else
                                        // ОВО
                                        if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND SLUZBA IN (9,52) ";
                                        else
                                            // Следствие
                                            if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND SLUZBA IN (10,55) ";
                                            else
                                                // ГИБДД
                                                if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
                                                else
                                                    // УР
                                                    if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND SLUZBA IN (24,25) ";
                                                    else
                                                        // ППС
                                                        if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND SLUZBA IN (29,54) ";
                                                        else
                                                            // Приемники
                                                            if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND SLUZBA IN (33,63) ";
                                                            else
                                                                // Мед.вытрезв
                                                                if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND SLUZBA IN (40,60) ";
                                                                else
                                                                    // Конвой
                                                                    if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND SLUZBA IN (43,58) ";
                                                                    else
                                                                        // ОМОН
                                                                        if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND SLUZBA IN (44,59) ";
                                                                        else
                                                                            // УЦ
                                                                            if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND SLUZBA IN (78,64) ";
                                                                            else
                                                                                // УНП
                                                                                if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND SLUZBA IN (85,66) ";
                                                                                else Command.CommandText += String.Format(" AND SLUZBA IN ({0} )", sluzList.SelectedItem.Value);
                    }
                    else Command.CommandText += " AND SLUZBA NOT IN (9,52) ";
                }

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);

                Cache.Remove("Out_All_vn");
                Cache.Add("Out_All_vn", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);

                Response.Redirect(String.Format("viewresult.aspx?cat=11&date1={0}&date2={1}&pdr={2}", OutDate1.Text, OutDate2.Text, podrList.SelectedItem.Text));
            }
        }

        protected void Imagebutton13_Click(object sender, ImageClickEventArgs e)
        {

        }
		
	}
}
