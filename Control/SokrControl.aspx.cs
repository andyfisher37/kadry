using System;
using System.Data;
using System.Web.UI;

namespace kadry.Control
{
	/// <summary>
	/// Summary description for sokr_control.
	/// </summary>
	public partial class sokr_control : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected kadry.Control.sokrDataSet sokrDataSet;


		public System.Data.DataRowCollection rc;
        public kadry.sluzDataSet sDataSet;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
                //kadry.Security.Security s = new kadry.Security.Security();

                //if (!s.CheckSecurePage(User.Identity.Name,"sokr_control.aspx")) Response.Redirect("\\AccessDenied.htm",true);
                //else s.AddLogText("Списки сокращенных сотрудников...",Context.Request.UserHostAddress,40,true);

				Command.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE FAMILIYA <> '' AND (DATA_SOKR IS NOT NULL)";
				if ( Connection.State != ConnectionState.Open ) Connection.Open();
				int res = (int)Command.ExecuteScalar();

                Command.CommandText = "SELECT * FROM SLUZBA.DBF WHERE KEY_OF_SLU IN (SELECT DISTINCT SLUZBA FROM AAQQ) ORDER BY NAM_OF_SLU";
                DataAdapter.SelectCommand = Command;
                sDataSet = new sluzDataSet();
                DataAdapter.Fill(sDataSet);
                sluzList.DataSource = sDataSet;
                sluzList.DataTextField = "NAM_OF_SLU";
                sluzList.DataValueField = "KEY_OF_SLU";
                sluzList.DataBind();
                sluzList.Items.Add("Все службы (кроме ОВО)");
                sluzList.Items.FindByText("Все службы (кроме ОВО)").Value = "-2";
                sluzList.Items.Add("Все службы");
                sluzList.Items.FindByText("Все службы").Value = "-1";
                sluzList.Items.FindByText("Все службы").Selected = true;

				FindLabel.Text = "По состоянию на " + System.DateTime.Now.ToShortDateString() + " г. - всего занимает сокращенные должности " + res.ToString() + " человек...";
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
			this.sokrDataSet = new kadry.Control.sokrDataSet();
			((System.ComponentModel.ISupportInitialize)(this.sokrDataSet)).BeginInit();
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// Command
			// 
			this.Command.CommandText = @"SELECT AAQQ.FAMILIYA, AAQQ.IMYA, AAQQ.OTCHECTVO, AAQQ.KEY_1, AAQQ.DATA_SOKR, PODRAZD.PODRAZDEL, NAIMEN.NAIMENOVAN AS UPRAVLENIE, NAIMEN_1.NAIMENOVAN AS OTDEL, NAIMEN_2.NAIMENOVAN AS PODOTDEL, NAIMEN_3.NAIMENOVAN AS OTDELENIE, NAIMEN_4.NAIMENOVAN AS GRUP, NAIMEN_5.NAIMENOVAN AS PODCH, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL AS REALDOLZNOST, OFIC_DOL_1.NAM_OF_DOL AS DOLZNOST, ZVANIE.VOIN_ZVAN, SLVISOD.`TEXT`, AAQQ.STAVKA_PRS, AAQQ.NOMPRSOKDO FROM AAQQ, PODRAZD, SLUZBA, OFIC_DOL, OFIC_DOL OFIC_DOL_1, ZVANIE, NAIMEN, NAIMEN NAIMEN_1, NAIMEN NAIMEN_2, NAIMEN NAIMEN_3, NAIMEN NAIMEN_4, NAIMEN NAIMEN_5, SLVISOD WHERE AAQQ.PODRAZD = PODRAZD.KEY_OF_POD AND AAQQ.SLUZBA = SLUZBA.KEY_OF_SLU AND AAQQ.REAL_DOLZN = OFIC_DOL.P3 AND AAQQ.DOLZNOST = OFIC_DOL_1.P3 AND AAQQ.ZVANIE = ZVANIE.KEY_ZVAN AND AAQQ.UPRAVLENIE = NAIMEN.KEY_OF_NAI AND AAQQ.OTDEL = NAIMEN_1.KEY_OF_NAI AND AAQQ.PODOTDEL = NAIMEN_2.KEY_OF_NAI AND AAQQ.OTDELENIE = NAIMEN_3.KEY_OF_NAI AND AAQQ.GRUP = NAIMEN_4.KEY_OF_NAI AND AAQQ.PODR = NAIMEN_5.KEY_OF_NAI AND AAQQ.IST_SOD = SLVISOD.CODE AND (AAQQ.FAMILIYA <> '') AND (AAQQ.DATA_SOKR IS NOT NULL)";
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase IV;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;DBQ=" +
				"C:\\KADRY;DriverId=277";
			// 
			// sokrDataSet
			// 
			this.sokrDataSet.DataSetName = "sokrDataSet";
			this.sokrDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.sokrDataSet)).EndInit();

		}
		#endregion

		protected void Button1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Command.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, DATA_POST, OBRAZ_LIC2, KEY_1, DATA_SOKR, PODRAZD.PODRAZDEL, NAIMEN.NAIMENOVAN AS UPRAVLENIE, NAIMEN_1.NAIMENOVAN AS OTDEL, NAIMEN_2.NAIMENOVAN AS PODOTDEL, NAIMEN_3.NAIMENOVAN AS OTDELENIE, NAIMEN_4.NAIMENOVAN AS GRUP, NAIMEN_5.NAIMENOVAN AS PODCH, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL AS REALDOLZNOST, OFIC_DOL_1.NAM_OF_DOL AS DOLZNOST, ZVANIE.VOIN_ZVAN, SLVISOD.`TEXT`, AAQQ.STAVKA_PRS, AAQQ.NOMPRSOKDO FROM AAQQ, PODRAZD, SLUZBA, OFIC_DOL, OFIC_DOL OFIC_DOL_1, ZVANIE, NAIMEN, NAIMEN NAIMEN_1, NAIMEN NAIMEN_2, NAIMEN NAIMEN_3, NAIMEN NAIMEN_4, NAIMEN NAIMEN_5, SLVISOD WHERE AAQQ.PODRAZD = PODRAZD.KEY_OF_POD AND AAQQ.SLUZBA = SLUZBA.KEY_OF_SLU AND AAQQ.REAL_DOLZN = OFIC_DOL.P3 AND AAQQ.DOLZNOST = OFIC_DOL_1.P3 AND AAQQ.ZVANIE = ZVANIE.KEY_ZVAN AND AAQQ.UPRAVLENIE = NAIMEN.KEY_OF_NAI AND AAQQ.OTDEL = NAIMEN_1.KEY_OF_NAI AND AAQQ.PODOTDEL = NAIMEN_2.KEY_OF_NAI AND AAQQ.OTDELENIE = NAIMEN_3.KEY_OF_NAI AND AAQQ.GRUP = NAIMEN_4.KEY_OF_NAI AND AAQQ.PODR = NAIMEN_5.KEY_OF_NAI AND IST_SOD = SLVISOD.CODE AND (FAMILIYA <> '') AND (DATA_SOKR IS NOT NULL)";

            switch (DolzList.SelectedValue)
            {
                case "0": Command.CommandText += " "; break;
                case "1": Command.CommandText += " AND DOLZNOST < '800000' "; break;
                case "2": Command.CommandText += " AND DOLZNOST < '500000' "; break;
                case "3": Command.CommandText += " AND DOLZNOST BETWEEN '500000' AND '800000' "; break;
                case "4": Command.CommandText += " AND DOLZNOST > '800000' "; break;
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

			switch(SortList.SelectedValue)
			{
				case "0" : Command.CommandText += " ORDER BY FAMILIYA"; break;
				case "1" : Command.CommandText += " ORDER BY PODRAZDEL"; break;
				case "2" : Command.CommandText += " ORDER BY DOLZNOST"; break;
				case "3" : Command.CommandText += " ORDER BY DATA_SOKR"; break;
				case "4" : Command.CommandText += " ORDER BY TEXT"; break;
			}

			DataAdapter.SelectCommand = Command;
			sokrDataSet.Clear();
			DataAdapter.Fill(sokrDataSet);
			rc = sokrDataSet.Tables[0].Rows;

			if ( rc.Count > 0 )
			{
				FindLabel.Text = "Найдено " + rc.Count.ToString() + " сотрудников...";
				
				Grid.DataBind();

				for( int i = 0; i < rc.Count; i++)
				{
                    string obr = "";
                    if (rc[i]["OBRAZ_LIC2"].ToString() == "10") obr = "Высшее";
                    if (rc[i]["OBRAZ_LIC2"].ToString() == "20") obr = "Среднее специальное";
                    if (rc[i]["OBRAZ_LIC2"].ToString() == "30") obr = "Среднее общее";

                    Grid.Items[i].Cells[4].Text = obr;
                    
					string pdr = "";
					if (rc[i]["GRUP"].ToString() != "          - # -" )			pdr += "группы " + rc[i]["GRUP"].ToString();
					if (rc[i]["OTDELENIE"].ToString() != "          - # -" )	pdr += " отделения " + rc[i]["OTDELENIE"].ToString();
					if (rc[i]["PODOTDEL"].ToString() != "          - # -" )		pdr += " подотдела " + rc[i]["PODOTDEL"].ToString();
					if (rc[i]["OTDEL"].ToString() != "          - # -" )		pdr += " отдела " + rc[i]["OTDEL"].ToString();
					if (rc[i]["UPRAVLENIE"].ToString() != "          - # -" )	pdr += " управление " + rc[i]["UPRAVLENIE"].ToString();
					if (rc[i]["PODCH"].ToString() != "          - # -" )		pdr += " " + rc[i]["PODCH"].ToString();
					if (rc[i]["PODRAZDEL"].ToString() != "          - # -" )		pdr += " " + rc[i]["PODRAZDEL"].ToString();
					Grid.Items[i].Cells[6].Text = pdr;

					string dol = "";
					if ( rc[i]["DOLZNOST"].ToString() != rc[i]["REALDOLZNOST"].ToString() )
						dol = rc[i]["DOLZNOST"].ToString() + " <font color='Green'>(фактическая - " + rc[i]["REALDOLZNOST"].ToString() + "</font>)";
					else dol = rc[i]["DOLZNOST"].ToString();
					Grid.Items[i].Cells[7].Text = dol;

					string skr = "Сокращена Пр.";
					if ( rc[i]["NAM_OF_SLU"].ToString() == "Охрана" || rc[i]["NAM_OF_SLU"].ToString() == "Кадры-охрана" )
						skr += "УВО при УВД";
					else skr += "УВД Ив.обл.";
					skr += " № " + rc[i]["NOMPRSOKDO"].ToString() + " от " + Convert.ToDateTime(rc[i]["DATA_SOKR"]).ToShortDateString() + " г.";
					Grid.Items[i].Cells[8].Text = skr;
				}
			}
			else
				FindLabel.Text = "Не найдено ничего...";



		}

		protected void SortList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		  Button1_Click(sender,null);
		}

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("..\\shema77.htm", true);
        }
	}
}
