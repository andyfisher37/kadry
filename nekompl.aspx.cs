using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace UK
{
	/// <summary>
	/// Summary description for nekompl.
	/// </summary>
	public class nekompl : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected UK.podrDataSet podrDataSet;
		protected UK.sluzDataSet sluzDataSet;
		protected UK.dolzDataSet dolzDataSet;
		protected UK.istDataSet istDataSet;
		protected System.Web.UI.WebControls.DropDownList podrList;
		protected System.Web.UI.WebControls.Button AddPodrBtn;
		protected System.Web.UI.WebControls.DropDownList sluzList;
		protected System.Web.UI.WebControls.Button AddSluzBtn;
		protected System.Web.UI.WebControls.DropDownList dolzList;
		protected System.Web.UI.WebControls.Button AddDolzBtn;
		protected System.Web.UI.WebControls.DropDownList istList;
		protected System.Web.UI.WebControls.Button AddIstBtn;
		protected System.Web.UI.WebControls.Label InfoLabel;
		protected System.Web.UI.WebControls.Label ListLabel;
		protected System.Web.UI.WebControls.Button GoBtn;
		public System.Data.DataRowCollection rc;	// Основные данные
		public System.Data.DataRowCollection rcp;	// Словарь подразделений
		public ArrayList sluz;						// список служб...
		public int[] rowpos;						// шаблон вывода по подразделениям...
		
		
		
		public struct NekPoint
		{
			public int podrazd;
			public int podr;
			public int sluzba;
			public int dolz;
			public int stat, vak, sokr;
			public string podrazdel;
			public string naimenovan;
				
		}

		public struct Map
		{
			public string[] Title1;
			public string[] Title2;
			public string[] PodrName;
			public int[][] item;
		}

		
		public void FillShablon()
		{
			rowpos = new int[32];

			rowpos[0]=	1;
			rowpos[1]=	54;
			rowpos[2]=	2;
			rowpos[3]=	3;
			rowpos[4]=	4;
			rowpos[5]=	5;
			rowpos[6]=	6;
			rowpos[7]=	7;
			rowpos[8]=	8;
			rowpos[9]=	9;
			rowpos[10]= 10;
			rowpos[11]= 11;
			rowpos[12]= 152;
			rowpos[13]= 13;
			rowpos[14]= 312;
			rowpos[15]= 14;
			rowpos[16]= 15;
			rowpos[17]= 16;
			rowpos[18]= 17;
			rowpos[19]= 18;
			rowpos[20]= 19;
			rowpos[21]= 20;
			rowpos[22]= 21;
			rowpos[23]= 23;
			rowpos[24]= 24;
			rowpos[25]= 25;
			rowpos[26]= 26;
			rowpos[27]= 27;
			rowpos[28]= 28;
			rowpos[29]= 29;
			rowpos[30]= 30;
			rowpos[31]= 31;
		}

		private int AddToMap( NekPoint item ) 
		{
			
//			switch (code)
//			{
//				case 0 : return "ДИНАМО";
//				case 1 : return "КМ";
//				case 2 : return	"Милиции обществен.безопасности";
//				case 3 : return "Контрольно-ревизионная";
//				case 4 : return "Кадры";
//				case 5 : return "Тыловое обеспечение";
//				case 6 : return "Исполнения наказаний";
//				case 7 : return "Государствен.противопож.служба";
//				case 8 : return "Служба организации управления";
//				case 9 : return "Охрана";
//				default : return "Прочие";

//10	Следствие
//11	Государственная Авто Инспекция
//12	Собственной безопасности
//13	Штаб
//14	Дежурные части
//15	Подразделения связи
//16	Начальники ГРУОВД
//17	Замы нач.ГРУОВД без кадров
//18	Замы нач. ГРУОВД по кадрам
//19	Начальники ГОМ, РОМ, ПОМ
//20	Замы нач. ГРПОМ без кадров
//21	Замы нач. ОМ по кадрам
//22	Паспортно-визовая служба
//23	Экспертно-криминал.подраздел-я
//24	Уголовный розыск
//25	Уголовный розыск по н/летним
//26	По борьбе с незак.обор.наркот.
//27	По борьбе с экон.преступлениям
//28	По борьбе с Организ.преступн-ю
//29	Патрульно-постовая служба
//30	По предупр. правонар.н/летних.
//31	Центр врем. изоляции Н/Л прав.
//32	Участковые уполномоч. милиции
//33	Пр-распр.д/лиц задерж.за бродя
//34	Спецприемники для адм.арестова
//35	Лицензионно-разрешительная раб
//36	Технический надзор ГИБДД
//37	ДПС
//38	Организ-я движ-я и дор.инспекц
//39	Строевые подразд-я ДПС
//40	Медицинские вытрезвители
//41	По организации дознания
//42	ИВС подозреваемых, обвиняемых
//43	Конвойные подразделения милици
//44	Отряды милиции особого назнач.
//45	Начальник отрядов и частей ГПС
//46	Зам.нач.отр./ч.ГПС по кадрам
//47	Начальники караулов частей ГПС
//48	Инженеры ГПН и профилактики
//49	Инспекторы ГПН и профилактики
//50	Учебные заведения МВД
//51	Фельдегерская служба
//52	Кадры-охрана
//53	Кадры-ГПС
//54	Кадры-ППС
//55	Кадры-Следствие
//56	Кадры-ГИБДД
//58	Кадры-Конвой
//59	Кадры-ОМОН
//60	Кадры-Медвытрезвитель
//63	Кадры-Приемник для бродяг
//64	Кадры-УЦ
//65	Кадры-ГИБДД (строевые)
//66	Налоговая полиция
//67	Орг.деятельности УУМ
//68	Охрана общественного порядка
//69	По незак. обороту алкоголя
//70	По б-бе с прест.на потр.рынке
//71	По б-бе с незакон. лесопользов
//72	По б-бе с прест.в сф.высок.тех
//73	Обеспечения и обслуживания
//74	Центры кинологической службы
//75	Секретариаты
//76	Медицинская служба
//77	Финансовые подразделения
//78	Учебные центры
//79	Информационные центры
//80	Подразделения обществен.связей
//81	Подразделения по СОГВ
//82	Федеральная служба безопасност
//83	Миграции
//84	Политико-воспитательная служба
//85	По налоговым преступлениям
//86	Правового обеспечения
		return 0;
			
		}
				
		private int PodrCount(System.Data.DataRowCollection rc) // Подсчитывает кол-во подр-ий...
		{
			int count = 1;

			for( int i=0; i<rc.Count-1; i++)
			{
				if (!rc[i+1]["PODRAZD"].Equals(rc[i]["PODRAZD"])) count++;
			}
			return count;

		}
		
		private bool IsOficer(System.Data.DataRow rc) // Функция принадлежности к н/с
		{
			if ( Convert.ToInt32(rc["DOLZNOST"]) <= 500000 ) return true;
			else return false;
		}

		private bool IsVolny(System.Data.DataRow rc) // Функция принадлежности к вольнонаемн.
		{
			if ( Convert.ToInt32(rc["DOLZNOST"]) >= 800000 ) return true;
			else return false;
		}

		private bool IsSokr(System.Data.DataRow rc) // Функция проверки на сокращенность должности
		{
			if ( Fn.D2STR(rc["DATA_SOKR"]) != "..." ) return true;
			else return false;
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			ArrayList podrQuery = (ArrayList)Session["nek"];
		    ArrayList sluzQuery = (ArrayList)Session["nek"];
		    ArrayList dolzQuery = (ArrayList)Session["nek"];
			ArrayList istQuery =  (ArrayList)Session["nek"];
						
			if (!IsPostBack)
			{
				Command.CommandText = "SELECT * FROM PODRAZD.DBF WHERE KEY_OF_POD IN (SELECT PODRAZD FROM AAQQ.DBF) ORDER BY PODRAZDEL";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(podrDataSet);
				podrList.DataBind();
				podrList.Items.Add("Все подразделения");
				podrList.Items.FindByText("Все подразделения").Value = "0";
				podrList.Items.FindByText("Все подразделения").Selected = true;

				Command.CommandText = "SELECT * FROM SLUZBA.DBF WHERE KEY_OF_SLU IN (SELECT SLUZBA FROM AAQQ.DBF) ORDER BY NAM_OF_SLU ";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(sluzDataSet);
				sluzList.DataBind();
				sluzList.Items.Add("Все службы");
				sluzList.Items.FindByText("Все службы").Value = "-1";
				sluzList.Items.FindByText("Все службы").Selected = true;

				Command.CommandText = "SELECT * FROM Ofic_DOL.DBF WHERE P3 IN (SELECT REAL_DOLZN FROM AAQQ.DBF) ORDER BY NAM_OF_DOL";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(dolzDataSet);
				dolzList.DataBind();
				dolzList.Items.Add("Все аттестованые должности");
				dolzList.Items.FindByText("Все аттестованые должности").Value = "0";
				dolzList.Items.Add("Всё руководство (от нач.отделения)");
				dolzList.Items.FindByText("Всё руководство (от нач.отделения)").Value = "1";
				dolzList.Items.Add("Старший и средний нач.состав");
				dolzList.Items.FindByText("Старший и средний нач.состав").Value = "2";
				dolzList.Items.Add("Младший нач.состав");
				dolzList.Items.FindByText("Младший нач.состав").Value = "3";
				dolzList.Items.Add("Вольнонаемные должности");
				dolzList.Items.FindByText("Вольнонаемные должности").Value = "4";
				dolzList.Items.FindByText("Все аттестованые должности").Selected = true;
				
				Command.CommandText = "SELECT * FROM SLVISOD.DBF WHERE CODE IN (SELECT IST_SOD FROM AAQQ.DBF) ORDER BY TEXT";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(istDataSet);
				istList.DataBind();
				istList.Items.Add("Все источники");
				istList.Items.FindByText("Все источники").Value = "0";
				istList.Items.FindByText("Все источники").Selected = true;
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
			this.podrDataSet = new UK.podrDataSet();
			this.sluzDataSet = new UK.sluzDataSet();
			this.dolzDataSet = new UK.dolzDataSet();
			this.istDataSet = new UK.istDataSet();
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dolzDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.istDataSet)).BeginInit();
			this.AddPodrBtn.Click += new System.EventHandler(this.AddPodrBtn_Click);
			this.AddSluzBtn.Click += new System.EventHandler(this.AddSluzBtn_Click);
			this.AddDolzBtn.Click += new System.EventHandler(this.AddDolzBtn_Click);
			this.AddIstBtn.Click += new System.EventHandler(this.AddIstBtn_Click);
			this.GoBtn.Click += new System.EventHandler(this.GoBtn_Click);
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277;Dbq=c:\\borland\\kadry";
			// 
			// Command
			// 
			this.Command.Connection = this.Connection;
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
			// dolzDataSet
			// 
			this.dolzDataSet.DataSetName = "dolzDataSet";
			this.dolzDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// istDataSet
			// 
			this.istDataSet.DataSetName = "istDataSet";
			this.istDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dolzDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.istDataSet)).EndInit();

		}
		#endregion
        
		private void GoBtn_Click(object sender, System.EventArgs e)
		{
			ArrayList podrQuery = (ArrayList)Session["nek"];
			ArrayList sluzQuery = (ArrayList)Session["nek"];
			ArrayList dolzQuery = (ArrayList)Session["nek"];
			ArrayList istQuery = (ArrayList)Session["nek"];
			DataSet ds = new DataSet();

			// Если не задано критериев расчета...
			if ( podrQuery.Count == 0 && sluzQuery.Count == 0 && dolzQuery.Count == 0 && istQuery.Count == 0)
			{
				Command.CommandText = "SELECT PODRAZD, PODR, UPRAVLENIE, OTDEL, PODOTDEL, OTDELENIE, GRUP, DOLZNOST, SLUZBA, FAMILIYA, DATA_SOKR FROM AAQQ.DBF WHERE PODRAZD = 2 ORDER BY PODRAZD, PODR, UPRAVLENIE, OTDEL, PODOTDEL, OTDELENIE, GRUP, DOLZNOST";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(ds, "Base");
				Command.CommandText = "SELECT * FROM PODRAZD.DBF ORDER BY KEY_OF_POD";
				DataAdapter.Fill(ds, "Podr");
				DataColumn[] podrKey = new DataColumn[1];
				podrKey[0] = ds.Tables["Podr"].Columns["KEY_OF_POD"];
				ds.Tables["Podr"].PrimaryKey = podrKey;

				rc = ds.Tables["Base"].Rows;
				rcp = ds.Tables["Podr"].Rows;
						
				//NekPoint[] nek = new NekPoint[7000];
				//nek.Initialize();
				  ArrayList nek = new ArrayList();
		                
				int i = 0;   // общий счетчик по кол-ву должностей...
				int stat = 0;
				int vak = 0;
				int sokr = 0;
				int cur_dolz = 0;
				
				// сканируем по всем должностям...(создаем список уникальных должностей)
				do
				{
				  stat = vak = sokr = 0;
				  
				  NekPoint tmpItem = new NekPoint();

					cur_dolz = Convert.ToInt32(rc[i]["DOLZNOST"]);

					do
					{				
						if ( IsSokr(rc[i]) ) 
						{
							if ( Convert.ToString(rc[i]["FAMILIYA"]) != "" ) sokr++;
						}
						else
						{
							stat++;
							if ( Convert.ToString(rc[i]["FAMILIYA"]) == "" ) vak++;
						}
				  	 i++;
					 if ( i >= rc.Count-1 ) break;
					} while ( cur_dolz == Convert.ToInt32(rc[i]["DOLZNOST"]));

					tmpItem.dolz = Convert.ToInt32(rc[i-1]["DOLZNOST"]);
					tmpItem.sluzba = Convert.ToInt16(rc[i-1]["SLUZBA"]);
					tmpItem.podrazd = Convert.ToInt16(rc[i-1]["PODRAZD"]);
					tmpItem.podr = Convert.ToInt16(rc[i-1]["PODR"]);
					tmpItem.podrazdel = Convert.ToString(rcp.Find(rc[i-1]["PODRAZD"])["PODRAZDEL"]);
					tmpItem.stat = stat;
					tmpItem.vak = vak;
					tmpItem.sokr = sokr;
					
					nek.Add(tmpItem);
								
				} while (i <= rc.Count - 1);

				int count = i;

				// непосредственный анализ...

				// проходим весь отсканированый массив
				i = 0;
				int pdr = 1;

				int cur_podrazd = 0;
				int cur_sluz = 0;
				int sluz_pos = 4;
				
				System.Collections.IEnumerator nekPos = nek.GetEnumerator();

				foreach( NekPoint item in nek )
				{
				 
				 

				}

//				do
//				{
////					cur_podrazd = nek[i].podrazd; // текущее подразделение...
////					sluz_pos = 4;
////
////					do // пока не сменилось подразделение...
////					{
////						cur_sluz = nek[i].sluzba;
////
////					  do // пока не сменилась служба
////					  {
////                          
////
////					  } while ( cur_sluz == nek[i+1].sluzba );
////                        map[pdr][sluz_pos] = GetSluzba(nek[i].sluzba);
////						sluz_pos++;
////
////					if (i >= count-1) break;
////
////					} while (cur_podrazd == nek[i+1].podrazd);
////
////					map[pdr][0] = nek[i].podrazdel; // наименование подразделения
////					pdr++;
////				
//				} while ( i < count-1 );
				

				// Очищаем массивы данных...
				rc.Clear();
				ds.Dispose();
				

			}
			// Если выбраны только подразделения...
			if ( podrQuery.Count !=0  && sluzQuery.Count == 0 && dolzQuery.Count == 0 && istQuery.Count == 0)
			{
				Command.CommandText = "SELECT * FROM AAQQ.DBF WHERE PODRAZD IN (";
				for(int i=0; i<podrQuery.Count-1; i++)
				{
					Command.CommandText += podrQuery[i] + ",";
				}
				Command.CommandText += ") ORDER BY PODRAZD, PODR, UPRAVLENIE, OTDEL, PODOTDEL, OTDELENIE, GRUP, DOLZNOST";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(ds, "Base");
				rc = ds.Tables["Base"].Rows;

				

			}


			
		
		}

		private void nekompl_Unload(object sender, System.EventArgs e)
		{
			Connection.Close();
		}

		private void AddPodrBtn_Click(object sender, System.EventArgs e)
		{
			ArrayList podrQuery = (ArrayList)Session["nek"];

		    if (podrQuery.Contains(podrList.SelectedValue) == false)
			{
				podrQuery.Add(podrList.SelectedValue);
				ListLabel.Text += " " + podrList.SelectedItem.Text;
				InfoLabel.Text = "";
			}
			else InfoLabel.Text = "уже добавлено...";
			Page.Validate();
		}

		private void AddSluzBtn_Click(object sender, System.EventArgs e)
		{
			ArrayList sluzQuery = (ArrayList)Session["nek"];
			if (sluzQuery.Contains(sluzList.SelectedValue) == false)
			{
				sluzQuery.Add(sluzList.SelectedValue);
				ListLabel.Text += " " + sluzList.SelectedItem.Text;
				InfoLabel.Text = "";
			}
			else InfoLabel.Text = "уже добавлено...";
		
		}

		private void AddDolzBtn_Click(object sender, System.EventArgs e)
		{
			ArrayList dolzQuery = (ArrayList)Session["nek"];
			if (dolzQuery.Contains(dolzList.SelectedValue) == false)
			{
				dolzQuery.Add(dolzList.SelectedValue);
				ListLabel.Text += " " + dolzList.SelectedItem.Text;
				InfoLabel.Text = "";
			}
			else InfoLabel.Text = "уже добавлено...";
		}

		private void AddIstBtn_Click(object sender, System.EventArgs e)
		{
			ArrayList istQuery = (ArrayList)Session["nek"];
			if (istQuery.Contains(istList.SelectedValue) == false)
			{
				istQuery.Add(istList.SelectedValue);
				ListLabel.Text += " " + istList.SelectedItem.Text;
				InfoLabel.Text = "";
			}
			else InfoLabel.Text = "уже добавлено...";
		}

		

		
	}
}
