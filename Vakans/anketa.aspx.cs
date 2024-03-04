using System;
using System.Web.Caching;

namespace kadry.Vakans
{
	/// <summary>
	/// Summary description for anketa.
	/// </summary>
	public partial class anketa : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected kadry.Vakans.vakDataSet vakDataSet;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				kadry.Security.Security s = new kadry.Security.Security();

				if (!s.CheckSecurePage(User.Identity.Name,"anketa.aspx")) Response.Redirect("\\AccessDenied.htm",true);

				s.AddLogText("Подбор вакансии...",Context.Request.UserHostAddress.ToString(),29,true);

				TypeObrazList.Style.Add("Width","240px");
				ProfObrazList.Style.Add("Width","240px");
				AgeBox.Style.Add("Width","88px");
				SizeBox.Style.Add("Width","88px");
				OkladBox.Style.Add("Width","88px");
				SluzbaList.Style.Add("Width","88px");
				BDList.Style.Add("Width","88px");
				BossList.Style.Add("Width","88px");
				VodilaList.Style.Add("Width","88px");
				HealthList.Style.Add("Width","240px");
				PlaceList.Style.Add("Width","240px");

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
			this.vakDataSet = new kadry.Vakans.vakDataSet();
			((System.ComponentModel.ISupportInitialize)(this.vakDataSet)).BeginInit();
			// 
			// Command
			// 
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase IV;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;Drive" +
				"rId=277";
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

		protected void NextButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string paramStr = "";
			
			Command.CommandText = "SELECT VOIN_ZVAN, PODRAZDEL, N1.NAIMENOVAN, N2.NAIMENOVAN, N3.NAIMENOVAN, N4.NAIMENOVAN, N5.NAIMENOVAN, " +
				"N6.NAIMENOVAN, DOLZ.NAM_OF_DOL, NAM_OF_SLU, OKLAD_OT, OKLAD_DO, DATA_VAK " +
				"FROM AAQQ.DBF, PODRAZD.DBF, OFIC_DOL.DBF DOLZ, SLUZBA.DBF, NAIMEN.DBF N1, NAIMEN.DBF N2, " +
				"NAIMEN.DBF N3, NAIMEN.DBF N4, NAIMEN.DBF N5, NAIMEN.DBF N6, ZVANIE.DBF " +
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
				"(POTOLOK = KEY_ZVAN) ";

			// Тип образования
			if ( TypeObrazList.SelectedValue != "0" )
			{
				switch (TypeObrazList.SelectedValue)
				{
					case "10" :	
					{
						Command.CommandText += " AND OBRAZ_DOL1 = 'Высшее'";
						paramStr += "tobr=Высшее";
						break;
					}
					case "20" : 
					{
						Command.CommandText += " AND OBRAZ_DOL1 = 'Среднее' AND OBRAZ_DOL2 <> ''";
						paramStr += "tobr=Среднее-специальное";
						break;
					}
					case "30" : 
					{
						Command.CommandText += " AND OBRAZ_DOL1 = 'Среднее'";
						paramStr += "tobr=Среднее";
						break;
					}
				}
			} 
			else paramStr += "tobr=Не имеет значения";

			// Профиль образования
			if ( ProfObrazList.SelectedValue != "0" )
			{
				Command.CommandText += " AND OBRAZ_DOL2 = '" + ProfObrazList.SelectedValue + "'";
				paramStr += "&pobr="+ProfObrazList.SelectedValue;
			} 
			else paramStr += "&pobr=Не имеет значения";

            // Возраст
			if ( AgeBox.Text != "" )
			{
				if ( Convert.ToInt16(AgeBox.Text) >= 35 )
				{
					Command.CommandText += " AND VOIN_ZVAN NOT LIKE '%милиции%' AND VOIN_ZVAN NOT LIKE '%юстиции%'";
				}
				paramStr += "&age=" + AgeBox.Text;
			} 
			else paramStr += "&age=не задан";

			// Пол
			if ( SexList.SelectedValue == "0" ) 
			{
				Command.CommandText += " ";
				paramStr += "&sex=мужчина";
			} 
			else paramStr += "&sex=женщина"; 

			// Рост
			if ( SizeBox.Text != "" )
			{
				if ( Convert.ToInt16(SizeBox.Text) <= 175 ) 
				{
					Command.CommandText += " AND SLUZBA NOT IN (11,36,37,38,39,56,65) ";
				}
				paramStr += "&size=" + SizeBox.Text + " см";
			} 
			else paramStr += "&size=не имеет значения";

            // Оклад
			if ( OkladBox.Text != "" )
			{
				Command.CommandText += " AND OKLAD_OT > '" + OkladBox.Text + "'";  
				paramStr += "&pay=" + OkladBox.Text + " рублей и выше";
			} 
			else paramStr += "&pay=не имеет значения";

			// Опыт руководящей работы
			if ( BossList.SelectedValue == "Нет" )
			{
				Command.CommandText += " AND DOLZNOST > '100000'";
				paramStr += "&boss=Нет опыта руководящей работы";
			}
			else paramStr += "&boss=Есть опыт руководящей работы";

			if ( VodilaList.SelectedValue == "Нет" )
			{
				Command.CommandText += " AND SLUZBA NOT IN (11,36,37,38,39,56,65) AND NAM_OF_DOL NOT LIKE '%одитель%'";
				paramStr += "&vod=Нет";
			} else paramStr += "&vod=Есть";
			
			if ( BDList.SelectedValue == "Нет" )
			{
				paramStr += "&bd=Нет";
			} else paramStr += "&bd=Да";

			//Response.Write(Command.CommandText);

			DataAdapter.SelectCommand = Command;
			DataAdapter.Fill(vakDataSet,"Table");

			if (vakDataSet.Tables["Table"].Rows.Count != 0)
			{
				Cache.Add( "dataset", vakDataSet, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null );
				Response.Redirect("v_result.aspx?"+paramStr, true);
			}
			else Result.Text = "К сожалению по Вашему запросу вакансий не найдено, попробуйте еще раз...";




		}


	}
}
