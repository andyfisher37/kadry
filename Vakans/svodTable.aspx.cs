using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.Caching;

namespace kadry.Vakans
{
	/// <summary>
	/// Summary description for svodTable.
	/// </summary>
	public partial class svodTable : System.Web.UI.Page
	{
		private System.Data.DataRowCollection rc;

		public void ChangeSluzb()
		{
			for( int i=0; i<rc.Count; i++)
			{
				string s = rc[i]["NAM_OF_SLU"].ToString();
				switch (s)
				{
					case "ВФСО \"ДИНАМО\"" : rc[i]["NAM_OF_SLU"] = "Динамо"; break;
					case "Криминальной милиции" : rc[i]["NAM_OF_SLU"] = "КМ"; break;
					case "Милиции обществен.безопасности" : rc[i]["NAM_OF_SLU"] = "МОБ"; break;
					case "Контрольно-ревизионная" : rc[i]["NAM_OF_SLU"] = "КРО"; break;
					case "Кадры" : rc[i]["NAM_OF_SLU"] = "Кадры"; break;
					case "Тыловое обеспечение" : rc[i]["NAM_OF_SLU"] = "Тыл"; break;
					case "Охрана" : rc[i]["NAM_OF_SLU"] = "ОВО"; break;
					case "Следствие" : rc[i]["NAM_OF_SLU"] = "СО"; break;
					case "Государственная Авто Инспекция" : rc[i]["NAM_OF_SLU"] = "ГИБДД"; break;
					case "Собственной безопасности" : rc[i]["NAM_OF_SLU"] = "ОСБ"; break;
					case "Штаб" : rc[i]["NAM_OF_SLU"] = "Штаб"; break;
					case "Дежурные части" : rc[i]["NAM_OF_SLU"] = "ДЧ"; break;
					case "Подразделения связи" : rc[i]["NAM_OF_SLU"] = "Связь"; break;
					case "Начальники ГРУОВД" : rc[i]["NAM_OF_SLU"] = "Н.ГРУОВД"; break;
					case "Замы нач. ГРУОВД по кадрам" : rc[i]["NAM_OF_SLU"] = "З.н.ГРУОВД"; break;
					case "Начальники ГОМ, РОМ, ПОМ" : rc[i]["NAM_OF_SLU"] = "Н.ГОМ,ПОМ"; break;
					case "Паспортно-визовая служба" : rc[i]["NAM_OF_SLU"] = "ПВС"; break;
					case "Экспертно-криминал.подраздел-я" : rc[i]["NAM_OF_SLU"] = "ЭКЦ"; break;
					case "Уголовный розыск" : rc[i]["NAM_OF_SLU"] = "УР"; break;
					case "Уголовный розыск по н/летним" : rc[i]["NAM_OF_SLU"] = "УР(м)"; break;
					case "По борьбе с экон.преступлениям" : rc[i]["NAM_OF_SLU"] = "БЭП"; break;
					case "По борьбе с Организ.преступн-ю" : rc[i]["NAM_OF_SLU"] = "УБОП"; break;
					case "Патрульно-постовая служба" : rc[i]["NAM_OF_SLU"] = "ППС"; break;
					case "По предупр. правонар.н/летних." : rc[i]["NAM_OF_SLU"] = "ПДН"; break;
					case "Центр врем. изоляции Н/Л прав." : rc[i]["NAM_OF_SLU"] = "ЦВСНП"; break;
					case "Участковые уполномоч. милиции" : rc[i]["NAM_OF_SLU"] = "УУМ"; break;
					case "Спецприемники для адм.арестова" : rc[i]["NAM_OF_SLU"] = "Сп.пр."; break;
					case "Лицензионно-разрешительная раб" : rc[i]["NAM_OF_SLU"] = "ЛРР"; break;
					case "Технический надзор ГИБДД" : rc[i]["NAM_OF_SLU"] = "Т/Н.ГИБДД"; break;
					case "ДПС" : rc[i]["NAM_OF_SLU"] = "ДПС"; break;
					case "Организ-я движ-я и дор.инспекц" : rc[i]["NAM_OF_SLU"] = "ОДиДИ"; break;
					case "Строевые подразд-я ДПС" : rc[i]["NAM_OF_SLU"] = "ДПС"; break;
					case "Медицинские вытрезвители" : rc[i]["NAM_OF_SLU"] = "М/В"; break;
					case "По организации дознания" : rc[i]["NAM_OF_SLU"] = "Дозн."; break;
					case "ИВС подозреваемых, обвиняемых" : rc[i]["NAM_OF_SLU"] = "ИВС"; break;
					case "Конвойные подразделения милици" : rc[i]["NAM_OF_SLU"] = "Конв."; break;
					case "Отряды милиции особого назнач." : rc[i]["NAM_OF_SLU"] = "ОМОН"; break;
					case "Кадры-охрана" : rc[i]["NAM_OF_SLU"] = "ОВО(к)"; break;
					case "Кадры-ППС" : rc[i]["NAM_OF_SLU"] = "ППС(к)"; break;
					case "Кадры-Следствие" : rc[i]["NAM_OF_SLU"] = "СО(к)"; break;
					case "Кадры-ГИБДД" : rc[i]["NAM_OF_SLU"] = "ГИБДД.(к)"; break;
					case "Кадры-Конвой" : rc[i]["NAM_OF_SLU"] = "КОНВ.(к)"; break;
					case "Кадры-ОМОН" : rc[i]["NAM_OF_SLU"] = "ОМОН(к)"; break;
					case "Кадры-Медвытрезвитель" : rc[i]["NAM_OF_SLU"] = "М/В(к)"; break;
					case "Специального назначения" : rc[i]["NAM_OF_SLU"] = "Спец."; break;
					case "Кадры-УЦ" : rc[i]["NAM_OF_SLU"] = "УЦ(к)"; break;
					case "Кадры-ГИБДД (строевые)" : rc[i]["NAM_OF_SLU"] = "ГИБДД(к)"; break;
					case "Орг.деятельности УУМ" : rc[i]["NAM_OF_SLU"] = "ОД УУМ"; break;
					case "Охрана общественного порядка" : rc[i]["NAM_OF_SLU"] = "ООП"; break;
					case "По б-бе с прест.на потр.рынке" : rc[i]["NAM_OF_SLU"] = "БППР"; break;
					case "По б-бе с незакон. лесопользов" : rc[i]["NAM_OF_SLU"] = "Лес"; break;
					case "Обеспечения и обслуживания" : rc[i]["NAM_OF_SLU"] = "ОиО"; break;
					case "Центры кинологической службы" : rc[i]["NAM_OF_SLU"] = "ЦКС"; break;
					case "Секретариаты" : rc[i]["NAM_OF_SLU"] = "ДиН"; break;
					case "Медицинская служба" : rc[i]["NAM_OF_SLU"] = "МЕД"; break;
					case "Финансовые подразделения" : rc[i]["NAM_OF_SLU"] = "ФИН"; break;
					case "Учебные центры" : rc[i]["NAM_OF_SLU"] = "УЦ"; break;
					case "Информационные центры" : rc[i]["NAM_OF_SLU"] = "ИЦ"; break;
					case "Подразделения обществен.связей" : rc[i]["NAM_OF_SLU"] = "ОС"; break;
					case "По налоговым преступлениям" : rc[i]["NAM_OF_SLU"] = "НП"; break;
					case "Правового обеспечения" : rc[i]["NAM_OF_SLU"] = "Юр."; break;
				}
			}
			
		}
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			kadry.Security.Security s = new kadry.Security.Security();

			if (!s.CheckSecurePage(User.Identity.Name,"svodTable.aspx")) Response.Redirect("\\AccessDenied.htm",true);

			s.AddLogText("Просмотр сводной таблицы вакансий",Context.Request.UserHostAddress.ToString(),28,true);

			rc = (DataRowCollection)Cache["dataset"];
			ChangeSluzb();
			DataSet ds = new DataSet();
			ds.Tables.Add("Table");

			ArrayList sluzlist = new ArrayList(); // список уникальных служб
			ArrayList podrlist = new ArrayList(); // список уникальных подр-й
            
			for( int i=0; i<rc.Count; i++) // Заполняем...
			{
				if ( !sluzlist.Contains(rc[i]["NAM_OF_SLU"].ToString())) sluzlist.Add(rc[i]["NAM_OF_SLU"].ToString());
				if ( !podrlist.Contains(rc[i]["PODRAZDEL"].ToString())) podrlist.Add(rc[i]["PODRAZDEL"].ToString());
			}
			
			// Шапка
			string[] title = new string[sluzlist.Count + 1];
			title[0] = "  Подразделение/Служба  ";
			int index = 1;
            foreach( string slz in sluzlist ) { title[index] = slz; index++; }
			
			for( int j=0; j<sluzlist.Count + 1; j++) 
			{
				ds.Tables["Table"].Columns.Add(title[j]);
			}

			index = 0;
			int curPodr = 0;
			int prevPodr = 0;
			string[] row = new string[sluzlist.Count + 1];
			string[] bottom = new string[sluzlist.Count + 1];
            bottom[0] = "Итого:";

			do
			{
				curPodr = Convert.ToInt16(rc[index]["PODRAZD"]);
				int pos = ds.Tables["Table"].Columns.IndexOf(rc[index]["NAM_OF_SLU"].ToString());
				row[pos] = "-" + rc[index]["VAK"].ToString();
				bottom[pos] = Convert.ToString(Convert.ToInt16(rc[index]["VAK"]) + Convert.ToInt16(bottom[pos]));

				if ( prevPodr != curPodr && prevPodr != 0 )
				{
					row[0] = rc[index-1]["PODRAZDEL"].ToString();
					for( int j=0; j<sluzlist.Count + 1;j++ ) if ( row[j] == null ) row[j] = " ";
					ds.Tables["Table"].Rows.Add(row);
					for( int j=0; j<sluzlist.Count + 1;j++ ) row[j] = null;
				} 
				prevPodr = curPodr;
				index++;
			
			} while ( index < rc.Count);

			ds.Tables["Table"].Rows.Add(bottom);
            									
			Grid.DataSource = ds;
			Grid.DataMember = "Table";
			Grid.DataBind();

			Grid.Items[Grid.Items.Count-2].Font.Bold = true;

			for( int i=0; i< Grid.Items.Count; i++ )
			{
				Grid.Items[i].Cells[0].HorizontalAlign = HorizontalAlign.Left;
				Grid.Items[i].Cells[0].Font.Bold = true;
			}

			Cache.Remove("dataset");

			TitleText.Text = "Сводная таблица вакансий должностей аттестованного состава УВД по Ивановской области по состоянию на " + System.DateTime.Today.ToShortDateString();

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

		}
		#endregion
	}
}
