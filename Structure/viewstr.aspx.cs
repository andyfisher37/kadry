using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
using Obout.Ajax.UI.TreeView;

namespace kadry.Structure
{
	/// <summary>
	/// Summary description for viewstr.
	/// </summary>
	public partial class viewstr : System.Web.UI.Page
	{
        public Obout.Ajax.UI.TreeView.Tree Tree1;

        public static string id;

		public System.Data.DataRowCollection rc;
	
		public struct TStruct
		{
			public int podrazd;
			public int upravlenie;
			public int otdel;
			public int podotdel;
			public int otdelenie;
			public int grup;
			public int podr;

			public void Clear()
			{
				podrazd = 0;
				upravlenie = 0;
				otdel = 0;
				podotdel = 0;
				otdelenie = 0;
				grup = 0;
				podr = 0;
			}
		}

		public TStruct ch;

		public void FillStr( TStruct[] str, int i)
		{
			str[i].podrazd = Convert.ToInt16(rc[i]["PODRAZD"]);
			str[i].upravlenie = Convert.ToInt16(rc[i]["UPRAVLENIE"]);
			str[i].otdel = Convert.ToInt16(rc[i]["OTDEL"]);
			str[i].podotdel = Convert.ToInt16(rc[i]["PODOTDEL"]);
			str[i].otdelenie = Convert.ToInt16(rc[i]["OTDELENIE"]);
			str[i].grup = Convert.ToInt16(rc[i]["GRUP"]);
			str[i].podr = Convert.ToInt16(rc[i]["PODR"]);
		}

		public bool IsStrChange( TStruct str1, TStruct str2 )
		{
			bool isChange = false;

			if ( str1.podrazd != str2.podrazd )	{ isChange = true; ch.podrazd = 1; }
			if ( str1.upravlenie != str2.upravlenie ) { isChange = true; ch.upravlenie = 1;	}
			if ( str1.otdel != str2.otdel )	{ isChange = true; ch.otdel = 1; }
			if ( str1.podotdel != str2.podotdel ) {	isChange = true; ch.podotdel = 1; }
			if ( str1.otdelenie != str2.otdelenie )	{ isChange = true; ch.otdelenie = 1; }
			if ( str1.grup != str2.grup ) { isChange = true; ch.grup = 1; }
			if ( str1.podr != str2.podr ) { isChange = true; ch.podr = 1; }

			return isChange;
		}

  		public string GetStrName(int i)
		{
			string pdr = "";
			
			if (rc[i]["GRUP"].ToString() != "9" && ch.grup == 1 )			pdr += "группа " + rc[i]["n_grup"].ToString();
			if (rc[i]["OTDELENIE"].ToString() != "9" && ch.otdelenie == 1)	pdr += " отделение " + rc[i]["n_otdelenie"].ToString();
			if (rc[i]["PODOTDEL"].ToString() != "9" && ch.podotdel == 1)		pdr += " подотдел " + rc[i]["n_podotdel"].ToString();
			if (rc[i]["OTDEL"].ToString() != "9" && ch.otdel == 1)			pdr += " отдел " + rc[i]["n_otdel"].ToString();
			if (rc[i]["UPRAVLENIE"].ToString() != "9" && ch.upravlenie == 1)	pdr += " управление " + rc[i]["n_upravlenie"].ToString();
			if (rc[i]["PODR"].ToString() != "9" && ch.podr == 1)				pdr += " " + rc[i]["n_podr"].ToString();
			//if (rc[i]["PODRAZD"].ToString() != "9" && ch.podrazd == 1)		pdr += " " + rc[i]["PODRAZDEL"].ToString();

			return pdr;
		}
		
		
		public void ViewStrRow(int i)
		{
            if (ch.podrazd == 1) //rc[i]["PODRAZD"].ToString() != "9" && ch.podrazd == 1
			{
				TableRow r = new TableRow();

				TableCell c1 = new TableCell();
				c1.Text = "<b>" + rc[i]["PODRAZDEL"].ToString().ToUpper() + "</b>";
				c1.ColumnSpan = 11;
				c1.HorizontalAlign = HorizontalAlign.Center;
				c1.BackColor = Color.LightSlateGray;
				c1.ForeColor = Color.White;
				c1.Font.Bold = true;
				r.Cells.Add(c1);
				
				Table.Rows.Add(r);
			}

			TableRow r2 = new TableRow();

			TableCell c2 = new TableCell();
			c2.Text = GetStrName(i);
            c2.ColumnSpan = 11;
			c2.HorizontalAlign = HorizontalAlign.Center;
            if (c2.Text.IndexOf("Вневедомственной") != -1) c2.BackColor = Color.AliceBlue;
            else c2.BackColor = Color.PowderBlue;
			r2.Cells.Add(c2);

			Table.Rows.Add(r2);
		}


		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                double ist_f = 0; // Федеральный источник
                double ist_o = 0; // Остальные (не федеральные)
                int pcount = 0; // Кол-во человек
                double ns = 0;     // Кол-во нач.состав
                double rs = 0;     // Кол-во ряд.состав
                double vs = 0;     // Кол-во вольн.состав
                double sokr = 0;   // Сокращено должностей

                TitleText.Text = Request.Params["title"];
                int viewtype = Convert.ToInt16(Request.Params["viewtype"]);

                if (viewtype == 1) // Табличный вывод
                {
                    this.Table.Visible = true;
                    Tree1.Visible = false;
                    DataSet ds = new DataSet();
                    ds = (DataSet)Cache["struct"];
                    rc = ds.Tables[0].Rows;

                    TStruct[] str = new TStruct[rc.Count];
                    TStruct cur_str = new TStruct();
                    cur_str.Clear();

                    ch = new TStruct();
                    ch.Clear();


                    for (int i = 0; i < rc.Count; i++)
                    {
                        id = rc[i]["KEY_1"].ToString();

                        double stavka = Convert.ToDouble(rc[i]["STAVKA_DLZ"]);
                        FillStr(str, i); // Сохраняем текущеее состояние стр-ры...

                        // Проверяем не изменилось ли...

                        if (IsStrChange(cur_str, str[i]) == true) ViewStrRow(i);

                        TableRow r = new TableRow(); // Добавляем полную должность...

                        // Должность
                        TableCell c1 = new TableCell();
                        string dol = rc[i]["NAM_OF_DOL"].ToString();
                        string rdol = rc[i]["REALDOL"].ToString();
                        if (dol != rdol) c1.Text = rdol + " <i>(за счет должности " + dol + ")</i>";
                        else c1.Text = dol;

                        //Response.Write(Convert.ToInt32(rc[i]["DOLZNOST"]).ToString()+",");

                        if (rc[i]["DATA_SOKR"] != DBNull.Value)
                        {
                            c1.BackColor = Color.GreenYellow;
                            c1.Text += "\t (сокращена " + Convert.ToDateTime(rc[i]["DATA_SOKR"]).ToShortDateString() + " г.)";
                            sokr += stavka;
                        }
                        else
                        {
                            if (Convert.ToInt32(rc[i]["DOLZNOST"]) < 500000) ns += stavka;
                            if (Convert.ToInt32(rc[i]["DOLZNOST"]) > 500000 && Convert.ToInt32(rc[i]["DOLZNOST"]) < 800000) rs += stavka;
                            if (Convert.ToInt32(rc[i]["DOLZNOST"]) > 800000) vs += stavka;
                        }

                        if (stavka != 1) c1.Text += "&nbsp<b><font color='DarkBlue'>[" + stavka.ToString() + " ставки]</font></b>";

                        r.Cells.Add(c1);



                        // Спец.звание
                        TableCell c2 = new TableCell();
                        c2.HorizontalAlign = HorizontalAlign.Center;
                        c2.Text = rc[i]["ZVAN1"].ToString().ToLower();
                        if (rc[i]["DATA_PRSV"] != DBNull.Value) c2.Text += "<br>(с " + Convert.ToDateTime(rc[i]["DATA_PRSV"]).ToShortDateString() + " г.)</br>";
                        if (rc[i]["FAMILIYA"].ToString() == "")
                        {
                            c2.BackColor = Color.Gainsboro;
                            c2.ForeColor = Color.Red;
                            c2.ColumnSpan = 6;
                            c2.Text = "ВАКАНСИЯ";
                            if (rc[i]["DATA_VAK"] != DBNull.Value) c2.Text += "\tc " + Convert.ToDateTime(rc[i]["DATA_VAK"]).ToShortDateString();
                        }
                        r.Cells.Add(c2);

                        // Фамилия
                        TableCell c3 = new TableCell();
                        c3.HorizontalAlign = HorizontalAlign.Center;
                        if (rc[i]["FAMILIYA"].ToString() == "")
                        {
                            //c3.BackColor = Color.Gainsboro;
                            //c3.ForeColor = Color.Red;
                            //c3.ColumnSpan = 5;
                            //c3.Text = "ВАКАНСИЯ";
                            //if ( rc[i]["DATA_VAK"] != DBNull.Value ) c3.Text += "\tc " + Convert.ToDateTime(rc[i]["DATA_VAK"]).ToShortDateString();
                            //r.Cells.Add(c3);

                            // потолок Звание
                            TableCell c8 = new TableCell();
                            c8.HorizontalAlign = HorizontalAlign.Center;
                            c8.Text = rc[i]["VOIN_ZVAN"].ToString();
                            r.Cells.Add(c8);

                            // Вилка оклада
                            TableCell c9 = new TableCell();
                            c9.HorizontalAlign = HorizontalAlign.Center;
                            c9.Font.Size = FontUnit.Point(7);
                            //						double o1;
                            //						double o2;
                            //						if ( Convert.ToInt32(rc[i]["DOLZNOST"]) < 800000 )
                            //						{
                            //							o1 = Convert.ToDouble(rc[i]["OKLAD_OT"]);
                            //							o1 += (o1 * 11)/100; o1 += (o1 * 10)/100; o1 += (o1 * 15)/100; o1 += (o1 * 15)/100;	o1 += (o1 * 9)/100;
                            //							o2 = Convert.ToDouble(rc[i]["OKLAD_DO"]);
                            //							o2 += (o2 * 11)/100; o2 += (o2 * 10)/100; o2 += (o2 * 15)/100; o2 += (o2 * 15)/100; o2 += (o2 * 9)/100;
                            //							c9.Text = rc[i]["OKLAD_OT"].ToString() + "-" + rc[i]["OKLAD_DO"].ToString() + "<br>" + "(" + Math.Round(o1).ToString() + "-" + Math.Round(o2).ToString() + ")";
                            //						} 
                            //						else
                            //						{
                            c9.Text = rc[i]["OKLAD_OT"].ToString() + "&nbsp-&nbsp" + rc[i]["OKLAD_DO"].ToString();
                            //						}
                            r.Cells.Add(c9);

                            TableCell c10 = new TableCell();
                            c10.HorizontalAlign = HorizontalAlign.Center;
                            c10.Text = "-";
                            r.Cells.Add(c10);
                            TableCell c11 = new TableCell();
                            c11.HorizontalAlign = HorizontalAlign.Center;
                            c11.Text = "-";
                            r.Cells.Add(c11);

                        }
                        else // Если есть человек...
                        {
                            if (Request.Browser.Browser == "IE")
                            {
                                c3.Text = "<a href='..\\DetailPage.aspx?id=" + id + "'>" + rc[i]["FAMILIYA"].ToString().ToUpper() + "</a>";
                                r.Cells.Add(c3);
                            }
                            else
                            {
                                c3.Text = "<a href='..//DetailPage.aspx?id=" + id + "'>" + rc[i]["FAMILIYA"].ToString().ToUpper() + "</a>";
                                r.Cells.Add(c3);
                            }

                            // Имя
                            TableCell c4 = new TableCell();
                            c4.HorizontalAlign = HorizontalAlign.Center;
                            c4.Text = rc[i]["IMYA"].ToString();
                            r.Cells.Add(c4);

                            // Отчество
                            TableCell c5 = new TableCell();
                            c5.HorizontalAlign = HorizontalAlign.Center;
                            c5.Text = rc[i]["OTCHECTVO"].ToString();
                            r.Cells.Add(c5);

                            // Дата рождения
                            TableCell c6 = new TableCell();
                            c6.HorizontalAlign = HorizontalAlign.Center;
                            if (rc[i]["DATA_ROZD"] == DBNull.Value) c6.Text = "";
                            else c6.Text = Convert.ToDateTime(rc[i]["DATA_ROZD"]).ToShortDateString();
                            r.Cells.Add(c6);

                            // Личный номер
                            TableCell c7 = new TableCell();
                            c7.HorizontalAlign = HorizontalAlign.Center;
                            if (rc[i]["LICH_NOM_2"].ToString() == "") c7.Text = "";
                            else if (rc[i]["LICH_NOM_2"].ToString() == "совмещ") c7.Text = "совместитель";
                            else c7.Text = rc[i]["LICH_NOM_1"].ToString() + "-" + rc[i]["LICH_NOM_2"].ToString();
                            r.Cells.Add(c7);

                            // Потолок Звание
                            TableCell c8 = new TableCell();
                            c8.HorizontalAlign = HorizontalAlign.Center;
                            c8.Text = rc[i]["VOIN_ZVAN"].ToString();
                            r.Cells.Add(c8);

                            // Вилка оклада
                            TableCell c9 = new TableCell();
                            c9.HorizontalAlign = HorizontalAlign.Center;
                            c9.Font.Size = FontUnit.Point(7);
                            //						double o1;
                            //						double o2;
                            //						if ( Convert.ToInt32(rc[i]["DOLZNOST"]) < 800000 )
                            //						{
                            //							o1 = Convert.ToDouble(rc[i]["OKLAD_OT"]);
                            //							o1 += (o1 * 11)/100; o1 += (o1 * 10)/100; o1 += (o1 * 15)/100; o1 += (o1 * 15)/100;	o1 += (o1 * 9)/100;
                            //							o2 = Convert.ToDouble(rc[i]["OKLAD_DO"]);
                            //							o2 += (o2 * 11)/100; o2 += (o2 * 10)/100; o2 += (o2 * 15)/100; o2 += (o2 * 15)/100; o2 += (o2 * 9)/100;
                            //							c9.Text = rc[i]["OKLAD_OT"].ToString() + "-" + rc[i]["OKLAD_DO"].ToString() + "<br>" + "(" + Math.Round(o1).ToString() + "-" + Math.Round(o2).ToString() + ")";
                            //						}
                            //						else
                            //						{
                            c9.Text = rc[i]["OKLAD_OT"].ToString() + "&nbsp-&nbsp" + rc[i]["OKLAD_DO"].ToString();
                            //						}
                            r.Cells.Add(c9);

                            // в ОВД...
                            TableCell c10 = new TableCell();
                            c10.HorizontalAlign = HorizontalAlign.Center;
                            c10.Text = Convert.ToDateTime(rc[i]["DATA_POST"]).ToShortDateString();
                            r.Cells.Add(c10);

                            // в Должн.
                            TableCell c11 = new TableCell();
                            c11.HorizontalAlign = HorizontalAlign.Center;
                            c11.Text = Convert.ToDateTime(rc[i]["DATA_VDOLZ"]).ToShortDateString();
                            r.Cells.Add(c11);

                            //uvDataSource.SelectCommand = "SELECT date_notification_print, date_notification_give FROM Notification WHERE id = @key";
                            //uvDataSource.SelectParameters.Add("key", id);
                            //DataView dv = new DataView();
                            //dv = (DataView)uvDataSource.Select(DataSourceSelectArguments.Empty);
                            //if (dv.Table.Rows.Count > 0)
                            //{
                            //    TableCell c10 = new TableCell();
                            //    c10.HorizontalAlign = HorizontalAlign.Center;
                            //    if (dv.Table.Rows[0][0] != DBNull.Value) c10.Text = Convert.ToDateTime(dv.Table.Rows[0][0]).ToShortDateString();
                            //    else c10.Text = "-";
                            //    r.Cells.Add(c10);

                            //    TableCell c11 = new TableCell();
                            //    c11.HorizontalAlign = HorizontalAlign.Center;
                            //    if (dv.Table.Rows[0][1] != DBNull.Value) c11.Text = Convert.ToDateTime(dv.Table.Rows[0][1]).ToShortDateString();
                            //    else c11.Text = "<a href='..\\UVGive.aspx?id=" + id + "'>выдать</a>";
                            //    r.Cells.Add(c11);

                            //}
                            //else
                            //{
                            //    TableCell c10 = new TableCell();
                            //    c10.HorizontalAlign = HorizontalAlign.Center;
                            //    c10.Text = "<a href='..\\UVparam.aspx?id=" + id + "'>выписать</a>"; ;
                            //    r.Cells.Add(c10);
                            //    TableCell c11 = new TableCell();
                            //    c11.HorizontalAlign = HorizontalAlign.Center;
                            //    c11.Text = "-";
                            //    r.Cells.Add(c11);
                            //}
                            //dv.Dispose();
                            //uvDataSource.SelectParameters.Clear();

                            pcount++;
                        }

                        Table.Rows.Add(r);

                        cur_str = str[i];
                        ch.Clear();

                    }

                    LCount.Text = "<b>Итого: по штату - " + (ns + rs + vs - sokr).ToString() + " ед. (н/с - " + ns.ToString() + ", р/с - " + rs.ToString() + ", в/н - " + vs.ToString() + "), по источникам: федеральный - " + ist_f.ToString() + ", областной и муниципальные - " + ist_o.ToString() + ", по факту - " + pcount.ToString() + "</b>";
                    Cache.Remove("struct");
                    rc.Clear();
                    ds.Dispose();
                }
                else
                {
                    Tree1 = new Tree();
                    Tree1.Visible = true;
                    
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

		}
		#endregion

        protected void ExcelCopyButton_Click(object sender, ImageClickEventArgs e)
        {
            kadry.WordExcel.ExportGridToExcel(this, Table, "Штаты");
        }

        protected void WordCopyButton_Click(object sender, ImageClickEventArgs e)
        {
            kadry.WordExcel.ExportGridToWord(this, Table, "Штаты");
        }
	}
}
