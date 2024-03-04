using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.Caching;

namespace kadry.Viewresult
{
	
	public struct InStat1
	{
		public int num;
		public string PodrName;
		public int in_all;
		public int in_ns;
		public int in_rs;
	    public int in_ovo;
	}
	
	public struct InStat2
	{
		public int num;
		public string SluzName;
		public int in_all;
		public int in_ns;
		public int in_rs;
	}

	public partial class Viewresult : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				int cat = Convert.ToInt16(Request.Params["cat"]);
				string date1 = Request.Params["date1"];
				string date2 = Request.Params["date2"];
                string pdr = Request.Params["pdr"];
				int Count = 0;
                int rsCount = 0;
                int nsCount = 0;

				DataSet ds = new DataSet();

				switch (cat)
				{
					case 0:  // Уволенные по отриц.мот.
                    #region
                        ds = (DataSet)Cache["Out_otric"];
						TitleText.Text = "Список сотрудников ОВД Ивановской области, уволенных по отрицательным мотивам с " + date1 + " по " + date2 + " (" + pdr + ")";

						for( int i=0; i<ds.Tables[0].Rows.Count; i++)
						{
							TableRow r = new TableRow();
							TableCell c1 = new TableCell();
							c1.Text = ds.Tables[0].Rows[i]["FAMILIYA"].ToString();
							r.Cells.Add(c1);
							TableCell c2 = new TableCell();
							c2.Text = ds.Tables[0].Rows[i]["IMYA"].ToString();
							r.Cells.Add(c2);
							TableCell c3 = new TableCell();
							c3.Text = ds.Tables[0].Rows[i]["OTCHECTVO"].ToString();
							r.Cells.Add(c3);
                            TableCell c31 = new TableCell();
                            c31.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_ROZD"]).ToShortDateString();
                            r.Cells.Add(c31);
							TableCell c4 = new TableCell();
							c4.Text = ds.Tables[0].Rows[i]["PODRAZDEL"].ToString();
							r.Cells.Add(c4);
							TableCell c5 = new TableCell();
							c5.Text = ds.Tables[0].Rows[i]["NAM_OF_SLU"].ToString();
							r.Cells.Add(c5);
							TableCell c6 = new TableCell();
							c6.Text = ds.Tables[0].Rows[i]["NAM_OF_DOL"].ToString();
							r.Cells.Add(c6);
							TableCell c61 = new TableCell();
							c61.HorizontalAlign = HorizontalAlign.Center;
							c61.Text = ds.Tables[0].Rows[i]["VOIN_ZVAN"].ToString();
							r.Cells.Add(c61);
							TableCell c7 = new TableCell();
							c7.HorizontalAlign = HorizontalAlign.Center;
							c7.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_UVOL"]).ToShortDateString();
							r.Cells.Add(c7);
							TableCell c8 = new TableCell();
							c8.HorizontalAlign = HorizontalAlign.Center;
							c8.Text = ds.Tables[0].Rows[i]["P1"].ToString();
                            r.Cells.Add(c8);
							TableCell c9 = new TableCell();
							c9.Text = ds.Tables[0].Rows[i]["Expr1"].ToString();
							r.Cells.Add(c9);
							TableCell c10 = new TableCell();
							c10.HorizontalAlign = HorizontalAlign.Center;
							c10.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_POST"]).ToShortDateString();
							r.Cells.Add(c10);
							TableCell c11 = new TableCell();
							c11.HorizontalAlign = HorizontalAlign.Center;
							c11.Text = ds.Tables[0].Rows[i]["Expr2"].ToString();
							r.Cells.Add(c11);
							TableCell c12 = new TableCell();
							c12.HorizontalAlign = HorizontalAlign.Center;
							c12.Text = ds.Tables[0].Rows[i]["NOM_PR_UVO"].ToString();
							r.Cells.Add(c12);
							TableCell c13 = new TableCell();
							c13.HorizontalAlign = HorizontalAlign.Center;
							c13.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_PR_UV"]).ToShortDateString();
							r.Cells.Add(c13);

							Table1.Rows.Add(r);
                            // Подсчет количества н/с и р/с
                            int z = Convert.ToInt16(ds.Tables[0].Rows[i]["ZVANIE"]);
                            if ((z >= 20 && z <= 26) || (z >= 40 && z <= 46) || (z >= 60 && z <= 66) || (z >= 100 && z <= 106)) rsCount++;
                            if ((z >= 27 && z <= 35) || (z >= 47 && z <= 55) || (z >= 67 && z <= 75) || (z >= 107 && z <= 114)) nsCount++;
						}
						Count = ds.Tables[0].Rows.Count;
                   		ds.Clear();
						Cache.Remove("Out_otric");
						Table1.Visible = true;
						Table2.Visible = false;
						Table3.Visible = false;
						Table4.Visible = false;
						Table5.Visible = false;
						Table6.Visible = false;
						Table7.Visible = false;
                        Table8.Visible = false;
					break;
                        #endregion
                    case 1:  // Уволенные до 1 года
                    #region
                    ds = (DataSet)Cache["Out_dogoda"];
                        TitleText.Text = "Список уволенных сотрудников ОВД Ивановской области с " + date1 + " по " + date2 + " ,прослуживших менее 1 года" + " (" + pdr + ")";

						for( int i=0; i< ds.Tables[0].Rows.Count; i++)
						{
							TableRow r = new TableRow();
							TableCell c1 = new TableCell();
							c1.Text = ds.Tables[0].Rows[i]["FAMILIYA"].ToString();
							r.Cells.Add(c1);
							TableCell c2 = new TableCell();
							c2.Text = ds.Tables[0].Rows[i]["IMYA"].ToString();
							r.Cells.Add(c2);
							TableCell c3 = new TableCell();
							c3.Text = ds.Tables[0].Rows[i]["OTCHECTVO"].ToString();
							r.Cells.Add(c3);
                            TableCell c31 = new TableCell();
                            c31.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_ROZD"]).ToShortDateString();
                            r.Cells.Add(c31);
							TableCell c4 = new TableCell();
							c4.Text = ds.Tables[0].Rows[i]["PODRAZDEL"].ToString();
							r.Cells.Add(c4);
							TableCell c5 = new TableCell();
							c5.Text = ds.Tables[0].Rows[i]["NAM_OF_SLU"].ToString();
							r.Cells.Add(c5);
							TableCell c6 = new TableCell();
							c6.Text = ds.Tables[0].Rows[i]["NAM_OF_DOL"].ToString();
							r.Cells.Add(c6);
							TableCell c61 = new TableCell();
							c61.HorizontalAlign = HorizontalAlign.Center;
							c61.Text = ds.Tables[0].Rows[i]["VOIN_ZVAN"].ToString();
							r.Cells.Add(c61);
							TableCell c7 = new TableCell();
							c7.HorizontalAlign = HorizontalAlign.Center;
							c7.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_UVOL"]).ToShortDateString();
							r.Cells.Add(c7);
							TableCell c8 = new TableCell();
							c8.HorizontalAlign = HorizontalAlign.Center;
							c8.Text = ds.Tables[0].Rows[i]["P1"].ToString();
							r.Cells.Add(c8);
							TableCell c9 = new TableCell();
							c9.Text = ds.Tables[0].Rows[i]["Expr1"].ToString();
							r.Cells.Add(c9);
							TableCell c10 = new TableCell();
							c10.HorizontalAlign = HorizontalAlign.Center;
							c10.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_POST"]).ToShortDateString();
							r.Cells.Add(c10);
							TableCell c11 = new TableCell();
							c11.HorizontalAlign = HorizontalAlign.Center;
							c11.Text = ds.Tables[0].Rows[i]["Expr2"].ToString();
							r.Cells.Add(c11);
							TableCell c12 = new TableCell();
							c12.HorizontalAlign = HorizontalAlign.Center;
							c12.Text = ds.Tables[0].Rows[i]["NOM_PR_UVO"].ToString();
							r.Cells.Add(c12);
							TableCell c13 = new TableCell();
							c13.HorizontalAlign = HorizontalAlign.Center;
							c13.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_PR_UV"]).ToShortDateString();
							r.Cells.Add(c13);

							Table1.Rows.Add(r);
                            // Подсчет количества н/с и р/с
                            int z = Convert.ToInt16(ds.Tables[0].Rows[i]["ZVANIE"]);
                            if ((z >= 20 && z <= 26) || (z >= 40 && z <= 46) || (z >= 60 && z <= 66) || (z >= 100 && z <= 106)) rsCount++;
                            if ((z >= 27 && z <= 35) || (z >= 47 && z <= 55) || (z >= 67 && z <= 75) || (z >= 107 && z <= 114)) nsCount++;
						}
						Count = ds.Tables[0].Rows.Count;
						ds.Clear();
						Cache.Remove("Out_dogoda");
						Table1.Visible = true;
						Table2.Visible = false;
						Table3.Visible = false;
						Table4.Visible = false;
						Table5.Visible = false;
						Table6.Visible = false;
						Table7.Visible = false;
                        Table8.Visible = false;
					break;
                    #endregion
                    case 2:  // Уволенные стажеры
                    #region
						ds = (DataSet)Cache["Out_stag"];
                        TitleText.Text = "Список стажеров, уволенных из ОВД Ивановской области с " + date1 + " по " + date2 + " (" + pdr + ")";

							for( int i=0; i< ds.Tables[0].Rows.Count; i++)
							{
								TableRow r = new TableRow();
								TableCell c1 = new TableCell();
								c1.Text = ds.Tables[0].Rows[i]["FAMILIYA"].ToString();
								r.Cells.Add(c1);
								TableCell c2 = new TableCell();
								c2.Text = ds.Tables[0].Rows[i]["IMYA"].ToString();
								r.Cells.Add(c2);
								TableCell c3 = new TableCell();
								c3.Text = ds.Tables[0].Rows[i]["OTCHECTVO"].ToString();
								r.Cells.Add(c3);
                                TableCell c31 = new TableCell();
                                c31.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_ROZD"]).ToShortDateString();
                                r.Cells.Add(c31);
								TableCell c4 = new TableCell();
								c4.Text = ds.Tables[0].Rows[i]["PODRAZDEL"].ToString();
								r.Cells.Add(c4);
								TableCell c5 = new TableCell();
								c5.Text = ds.Tables[0].Rows[i]["NAM_OF_SLU"].ToString();
								r.Cells.Add(c5);
								TableCell c6 = new TableCell();
								c6.Text = ds.Tables[0].Rows[i]["NAM_OF_DOL"].ToString();
								r.Cells.Add(c6);
								TableCell c61 = new TableCell();
								c61.HorizontalAlign = HorizontalAlign.Center;
								c61.Text = ds.Tables[0].Rows[i]["VOIN_ZVAN"].ToString();
								r.Cells.Add(c61);
								TableCell c7 = new TableCell();
								c7.HorizontalAlign = HorizontalAlign.Center;
								c7.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_UVOL"]).ToShortDateString();
								r.Cells.Add(c7);
								TableCell c8 = new TableCell();
								c8.HorizontalAlign = HorizontalAlign.Center;
								c8.Text = ds.Tables[0].Rows[i]["P1"].ToString();
								r.Cells.Add(c8);
								TableCell c9 = new TableCell();
								c9.Text = ds.Tables[0].Rows[i]["Expr1"].ToString();
								r.Cells.Add(c9);
								TableCell c10 = new TableCell();
								c10.HorizontalAlign = HorizontalAlign.Center;
								c10.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_POST"]).ToShortDateString();
								r.Cells.Add(c10);
								TableCell c11 = new TableCell();
								c11.HorizontalAlign = HorizontalAlign.Center;
								c11.Text = ds.Tables[0].Rows[i]["Expr2"].ToString();
								r.Cells.Add(c11);
								TableCell c12 = new TableCell();
								c12.HorizontalAlign = HorizontalAlign.Center;
								c12.Text = ds.Tables[0].Rows[i]["NOM_PR_UVO"].ToString();
								r.Cells.Add(c12);
								TableCell c13 = new TableCell();
								c13.HorizontalAlign = HorizontalAlign.Center;
								c13.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_PR_UV"]).ToShortDateString();
								r.Cells.Add(c13);

								Table1.Rows.Add(r);
							}
							
							Count = ds.Tables[0].Rows.Count;
							ds.Clear();
							Cache.Remove("Out_stag");
							Table1.Visible = true;
							Table2.Visible = false;
							Table3.Visible = false;
							Table4.Visible = false;
							Table5.Visible = false;
							Table6.Visible = false;
							Table7.Visible = false;
                            Table8.Visible = false;
						break;
#endregion
                    case 3:  // Откомандированные
                    #region
						ds = (DataSet)Cache["Out_kom"];
                        TitleText.Text = "Список сотрудников ОВД Ивановской области с " + date1 + " по " + date2 + " откомандированных в другие регионы или ведомства" + " (" + pdr + ")";

						for( int i=0; i< ds.Tables[0].Rows.Count; i++)
						{
							TableRow r = new TableRow();
							TableCell c1 = new TableCell();
							c1.Text = ds.Tables[0].Rows[i]["FAMILIYA"].ToString();
							r.Cells.Add(c1);
							TableCell c2 = new TableCell();
							c2.Text = ds.Tables[0].Rows[i]["IMYA"].ToString();
							r.Cells.Add(c2);
							TableCell c3 = new TableCell();
							c3.Text = ds.Tables[0].Rows[i]["OTCHECTVO"].ToString();
							r.Cells.Add(c3);
							TableCell c4 = new TableCell();
							c4.Text = ds.Tables[0].Rows[i]["PODRAZDEL"].ToString();
							r.Cells.Add(c4);
							TableCell c5 = new TableCell();
							c5.Text = ds.Tables[0].Rows[i]["NAM_OF_SLU"].ToString();
							r.Cells.Add(c5);
							TableCell c6 = new TableCell();
							c6.Text = ds.Tables[0].Rows[i]["NAM_OF_DOL"].ToString();
							r.Cells.Add(c6);
							TableCell c61 = new TableCell();
							c61.HorizontalAlign = HorizontalAlign.Center;
							c61.Text = ds.Tables[0].Rows[i]["VOIN_ZVAN"].ToString();
							r.Cells.Add(c61);
							TableCell c7 = new TableCell();
							c7.HorizontalAlign = HorizontalAlign.Center;
							c7.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_UVOL"]).ToShortDateString();
							r.Cells.Add(c7);
							TableCell c8 = new TableCell();
							c8.HorizontalAlign = HorizontalAlign.Center;
							c8.Text = ds.Tables[0].Rows[i]["PLACE"].ToString();
							r.Cells.Add(c8);
							TableCell c10 = new TableCell();
							c10.HorizontalAlign = HorizontalAlign.Center;
							c10.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_POST"]).ToShortDateString();
							r.Cells.Add(c10);
							TableCell c11 = new TableCell();
							c11.HorizontalAlign = HorizontalAlign.Center;
							c11.Text = ds.Tables[0].Rows[i]["P1"].ToString();
							r.Cells.Add(c11);
							TableCell c12 = new TableCell();
							c12.HorizontalAlign = HorizontalAlign.Center;
							c12.Text = ds.Tables[0].Rows[i]["NOM_PR_UVO"].ToString();
							r.Cells.Add(c12);
							TableCell c13 = new TableCell();
							c13.HorizontalAlign = HorizontalAlign.Center;
							c13.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_PR_UV"]).ToShortDateString();
							r.Cells.Add(c13);

							Table2.Rows.Add(r);
                            // Подсчет количества н/с и р/с
                            int z = Convert.ToInt16(ds.Tables[0].Rows[i]["ZVANIE"]);
                            if ((z >= 20 && z <= 26) || (z >= 40 && z <= 46) || (z >= 60 && z <= 66) || (z >= 100 && z <= 106)) rsCount++;
                            if ((z >= 27 && z <= 35) || (z >= 47 && z <= 55) || (z >= 67 && z <= 75) || (z >= 107 && z <= 114)) nsCount++;
						}
							
						Count = ds.Tables[0].Rows.Count;
						ds.Clear();
						Cache.Remove("Out_kom");
						Table1.Visible = false;
						Table2.Visible = true;
						Table3.Visible = false;
						Table4.Visible = false;
						Table5.Visible = false;
						Table6.Visible = false;
						Table7.Visible = false;
                        Table8.Visible = false;
						break;
                    #endregion
                    case 4:  // Все принятые
                    #region
						ds = (DataSet)Cache["In_All"];
                        TitleText.Text = "Список принятых на службу в ОВД Ивановской области с " + date1 + " по " + date2 + " (" + pdr + ")";

						for( int i=0; i< ds.Tables[0].Rows.Count; i++)
						{
							TableRow r = new TableRow();
							TableCell c1 = new TableCell();
							c1.Text = ds.Tables[0].Rows[i]["FAMILIYA"].ToString();
							r.Cells.Add(c1);
							TableCell c2 = new TableCell();
							c2.Text = ds.Tables[0].Rows[i]["IMYA"].ToString();
							r.Cells.Add(c2);
							TableCell c3 = new TableCell();
							c3.Text = ds.Tables[0].Rows[i]["OTCHECTVO"].ToString();
							r.Cells.Add(c3);
							TableCell c7 = new TableCell();
							c7.HorizontalAlign = HorizontalAlign.Center;
							c7.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_ROZD"]).ToShortDateString();
							r.Cells.Add(c7);
							TableCell c4 = new TableCell();
							c4.Text = ds.Tables[0].Rows[i]["PODRAZDEL"].ToString();
							r.Cells.Add(c4);
							TableCell c5 = new TableCell();
							c5.Text = ds.Tables[0].Rows[i]["NAM_OF_SLU"].ToString();
							r.Cells.Add(c5);
							TableCell c6 = new TableCell();
							c6.Text = ds.Tables[0].Rows[i]["NAM_OF_DOL"].ToString();
							r.Cells.Add(c6);
							TableCell c61 = new TableCell();
							c61.HorizontalAlign = HorizontalAlign.Center;
							c61.Text = ds.Tables[0].Rows[i]["VOIN_ZVAN"].ToString();
							r.Cells.Add(c61);
							TableCell c10 = new TableCell();
							c10.HorizontalAlign = HorizontalAlign.Center;
							c10.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_POST"]).ToShortDateString();
							r.Cells.Add(c10);
							TableCell c11 = new TableCell();
							c11.HorizontalAlign = HorizontalAlign.Center;
							c11.Text = ds.Tables[0].Rows[i]["P1"].ToString();
							r.Cells.Add(c11);
							TableCell c12 = new TableCell();
							c12.HorizontalAlign = HorizontalAlign.Center;
							c12.Text = ds.Tables[0].Rows[i]["N_PR_VDOLZ"].ToString();
							r.Cells.Add(c12);
							TableCell c13 = new TableCell();
							c13.HorizontalAlign = HorizontalAlign.Center;
							c13.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DAT_PRI"]).ToShortDateString();
							r.Cells.Add(c13);

							Table3.Rows.Add(r);
                            // Подсчет количества н/с и р/с
                            int z = Convert.ToInt16(ds.Tables[0].Rows[i]["ZVANIE"]);
                            if ((z >= 20 && z <= 26) || (z >= 40 && z <= 46) || (z >= 60 && z <= 66) || (z >= 100 && z <= 106)) rsCount++;
                            if ((z >= 27 && z <= 35) || (z >= 47 && z <= 55) || (z >= 67 && z <= 75) || (z >= 107 && z <= 114)) nsCount++;
						}
							
						Count = ds.Tables[0].Rows.Count;
						ds.Clear();
						Cache.Remove("In_All");
						Table1.Visible = false;
						Table2.Visible = false;
						Table3.Visible = true;
						Table4.Visible = false;
						Table5.Visible = false;
						Table6.Visible = false;
						Table7.Visible = false;
                        Table8.Visible = false;
						break;
                    #endregion
                    case 51: // принятые по подразделениям
                    #region
						ds = (DataSet)Cache["In_pdr"];
                        TitleText.Text = "Количество принятых на службу в ОВД Ивановской области с " + date1 + " по " + date2 + " по подразделениям" + " (" + pdr + ")";
						ArrayList list = new ArrayList();

						string podr = "";
						int num = 1;
						int all = 0;
						int ns = 0;
						int rs = 0;
						int ovo = 0;
						InStat1 item = new InStat1();

						// Добавляем в конец пустую строку для прохода последнего элемента
						System.Data.DataRow rd = ds.Tables[0].NewRow();
						ds.Tables[0].Rows.Add(rd);
						
						for( int i = 0; i < ds.Tables[0].Rows.Count-1; i++ )
						{
							int dol = Convert.ToInt16(ds.Tables[0].Rows[i]["DOLZNOST"].ToString().Substring(0,1));
							int sl = Convert.ToInt16(ds.Tables[0].Rows[i]["SLUZBA"]);
							podr = ds.Tables[0].Rows[i]["PODRAZDEL"].ToString();
							if ( sl == 9 || sl == 52 ) ovo++;
							if ( dol < 5 ) ns++;	
							else if ( dol >= 5 && dol < 8  ) rs++;
							all++;
							if ( podr != ds.Tables[0].Rows[i+1]["PODRAZDEL"].ToString() )
							{
								item.PodrName = podr;
								item.num = num; num++;
								item.in_all = all;
								item.in_ns = ns;
								item.in_rs = rs;
								item.in_ovo = ovo;
								list.Add(item);
								item = new InStat1();
								podr = "";
								all = 0;
								ns = 0;
								rs = 0;
								ovo = 0;
							}
						}
						
						foreach( InStat1 row in list )
						{
							TableRow r = new TableRow();
							TableCell c1 = new TableCell();
							c1.HorizontalAlign = HorizontalAlign.Center;
							c1.Text = row.num.ToString();
							r.Cells.Add(c1);
							TableCell c2 = new TableCell();
							c2.Text = row.PodrName;
							r.Cells.Add(c2);
							TableCell c3 = new TableCell();
							c3.HorizontalAlign = HorizontalAlign.Center;
							c3.Text = row.in_all.ToString();
							r.Cells.Add(c3);
							TableCell c4 = new TableCell();
							c4.HorizontalAlign = HorizontalAlign.Center;
							c4.Text = row.in_ns.ToString();
							r.Cells.Add(c4);
							TableCell c5 = new TableCell();
							c5.HorizontalAlign = HorizontalAlign.Center;
							c5.Text = row.in_rs.ToString();
							r.Cells.Add(c5);
							TableCell c6 = new TableCell();
							c6.HorizontalAlign = HorizontalAlign.Center;
							if ( row.in_ovo != 0 ) c6.Text = row.in_ovo.ToString();
							else c6.Text = "-";
							r.Cells.Add(c6);
							
							Table6.Rows.Add(r);

                            
						}
							
						Count = ds.Tables[0].Rows.Count-1;
						ds.Clear();
						Cache.Remove("In_podr");
						Table1.Visible = false;
						Table2.Visible = false;
						Table3.Visible = false;
						Table4.Visible = false;
						Table5.Visible = false;
						Table6.Visible = true;
						Table7.Visible = false;
                        Table8.Visible = false;
						break;
                    #endregion
                    case 52: // принятые по службам
					#region
						ds = (DataSet)Cache["In_slz"];
                        TitleText.Text = "Количество принятых на службу в ОВД Ивановской области с " + date1 + " по " + date2 + " по службам" + " (" + pdr + ")";
						ArrayList list2 = new ArrayList();

						int sluz = 0;
						int num2 = 1;
						int all2 = 0;
						int ns2 = 0;
						int rs2 = 0;
						InStat2 item2 = new InStat2();

						// Добавляем в конец пустую строку для прохода последнего элемента
						System.Data.DataRow rd2 = ds.Tables[0].NewRow();
						rd2["SLUZBA"] = 0;
						ds.Tables[0].Rows.Add(rd2);
						
						for( int i = 0; i < ds.Tables[0].Rows.Count-1; i++ )
						{
							int dol = Convert.ToInt16(ds.Tables[0].Rows[i]["DOLZNOST"].ToString().Substring(0,1));
							sluz = Convert.ToInt16(ds.Tables[0].Rows[i]["SLUZBA"]);
							if ( dol < 5 ) ns2++;	
							else if ( dol >= 5 && dol < 8  ) rs2++;
							all2++;
							if ( sluz != Convert.ToInt16(ds.Tables[0].Rows[i+1]["SLUZBA"]) )
							{
								item2.SluzName = ds.Tables[0].Rows[i]["NAM_OF_SLU"].ToString();
								item2.num = num2; num2++;
								item2.in_all = all2;
								item2.in_ns = ns2;
								item2.in_rs = rs2;
								list2.Add(item2);
								item2 = new InStat2();
								sluz = 0;
								all2 = 0;
								ns2 = 0;
								rs2 = 0;
							}
						}
						
						foreach( InStat2 row in list2 )
						{
							TableRow r = new TableRow();
							TableCell c1 = new TableCell();
							c1.HorizontalAlign = HorizontalAlign.Center;
							c1.Text = row.num.ToString();
							r.Cells.Add(c1);
							TableCell c2 = new TableCell();
							c2.Text = row.SluzName;
							r.Cells.Add(c2);
							TableCell c3 = new TableCell();
							c3.HorizontalAlign = HorizontalAlign.Center;
							c3.Text = row.in_all.ToString();
							r.Cells.Add(c3);
							TableCell c4 = new TableCell();
							c4.HorizontalAlign = HorizontalAlign.Center;
							c4.Text = row.in_ns.ToString();
							r.Cells.Add(c4);
							TableCell c5 = new TableCell();
							c5.HorizontalAlign = HorizontalAlign.Center;
							c5.Text = row.in_rs.ToString();
							r.Cells.Add(c5);
														
							Table7.Rows.Add(r);
                          
						}
							
						Count = ds.Tables[0].Rows.Count-1;
						ds.Clear();
						Cache.Remove("In_slz");
						Table1.Visible = false;
						Table2.Visible = false;
						Table3.Visible = false;
						Table4.Visible = false;
						Table5.Visible = false;
						Table6.Visible = false;
						Table7.Visible = true;
                        Table8.Visible = false;
						break;

                    #endregion
                    case 6:  // Прибывшие из учебных заведений
                    #region
						ds = (DataSet)Cache["In_vypusk"];
                        TitleText.Text = "Список прибывших на службу в ОВД Ивановской области с " + date1 + " по " + date2 + " по окончании учебных заведений МВД России" + " (" + pdr + ")";

						for( int i=0; i< ds.Tables[0].Rows.Count; i++)
						{
							TableRow r = new TableRow();
							TableCell c1 = new TableCell();
							c1.Text = ds.Tables[0].Rows[i]["FAMILIYA"].ToString();
							r.Cells.Add(c1);
							TableCell c2 = new TableCell();
							c2.Text = ds.Tables[0].Rows[i]["IMYA"].ToString();
							r.Cells.Add(c2);
							TableCell c3 = new TableCell();
							c3.Text = ds.Tables[0].Rows[i]["OTCHECTVO"].ToString();
							r.Cells.Add(c3);
							TableCell c7 = new TableCell();
							c7.HorizontalAlign = HorizontalAlign.Center;
							c7.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_ROZD"]).ToShortDateString();
							r.Cells.Add(c7);
							TableCell c4 = new TableCell();
							c4.Text = ds.Tables[0].Rows[i]["PODRAZDEL"].ToString();
							r.Cells.Add(c4);
							TableCell c5 = new TableCell();
							c5.Text = ds.Tables[0].Rows[i]["NAM_OF_SLU"].ToString();
							r.Cells.Add(c5);
							TableCell c6 = new TableCell();
							c6.Text = ds.Tables[0].Rows[i]["NAM_OF_DOL"].ToString();
							r.Cells.Add(c6);
							TableCell c61 = new TableCell();
							c61.HorizontalAlign = HorizontalAlign.Center;
							c61.Text = ds.Tables[0].Rows[i]["VOIN_ZVAN"].ToString();
							r.Cells.Add(c61);
							TableCell c10 = new TableCell();
							c10.HorizontalAlign = HorizontalAlign.Center;
							c10.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_POST"]).ToShortDateString();
							r.Cells.Add(c10);
							TableCell c111 = new TableCell();
							c111.HorizontalAlign = HorizontalAlign.Center;
							c111.Text = ds.Tables[0].Rows[i]["UCH"].ToString();
							r.Cells.Add(c111);
							TableCell c11 = new TableCell();
							c11.HorizontalAlign = HorizontalAlign.Center;
							c11.Text = ds.Tables[0].Rows[i]["P1"].ToString();
							r.Cells.Add(c11);
							TableCell c12 = new TableCell();
							c12.HorizontalAlign = HorizontalAlign.Center;
							c12.Text = ds.Tables[0].Rows[i]["N_PR_VDOLZ"].ToString();
							r.Cells.Add(c12);
							TableCell c13 = new TableCell();
							c13.HorizontalAlign = HorizontalAlign.Center;
							c13.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DAT_PRI"]).ToShortDateString();
							r.Cells.Add(c13);

							Table4.Rows.Add(r);

                            // Подсчет количества н/с и р/с
                            int z = Convert.ToInt16(ds.Tables[0].Rows[i]["ZVANIE"]);
                            if ((z >= 20 && z <= 26) || (z >= 40 && z <= 46) || (z >= 60 && z <= 66) || (z >= 100 && z <= 106)) rsCount++;
                            if ((z >= 27 && z <= 35) || (z >= 47 && z <= 55) || (z >= 67 && z <= 75) || (z >= 107 && z <= 114)) nsCount++;
						}
							
						Count = ds.Tables[0].Rows.Count;
						ds.Clear();
						Cache.Remove("In_vypusk");
						Table1.Visible = false;
						Table2.Visible = false;
						Table3.Visible = false;
						Table4.Visible = true;
						Table5.Visible = false;
						Table6.Visible = false;
						Table7.Visible = false;
                        Table8.Visible = false;
						break;
                    #endregion
                    case 7:  // Прибывшие из других регионов...
                    #region
						ds = (DataSet)Cache["In_prib"];
                        TitleText.Text = "Список прибывших на службу в ОВД Ивановской области с " + date1 + " по " + date2 + " из других регионов и ведомств" + " (" + pdr + ")";

						for( int i=0; i< ds.Tables[0].Rows.Count; i++)
						{
							TableRow r = new TableRow();
							TableCell c1 = new TableCell();
							c1.Text = ds.Tables[0].Rows[i]["FAMILIYA"].ToString();
							r.Cells.Add(c1);
							TableCell c2 = new TableCell();
							c2.Text = ds.Tables[0].Rows[i]["IMYA"].ToString();
							r.Cells.Add(c2);
							TableCell c3 = new TableCell();
							c3.Text = ds.Tables[0].Rows[i]["OTCHECTVO"].ToString();
							r.Cells.Add(c3);
							TableCell c7 = new TableCell();
							c7.HorizontalAlign = HorizontalAlign.Center;
							c7.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_ROZD"]).ToShortDateString();
							r.Cells.Add(c7);
							TableCell c4 = new TableCell();
							c4.Text = ds.Tables[0].Rows[i]["PODRAZDEL"].ToString();
							r.Cells.Add(c4);
							TableCell c5 = new TableCell();
							c5.Text = ds.Tables[0].Rows[i]["NAM_OF_SLU"].ToString();
							r.Cells.Add(c5);
							TableCell c6 = new TableCell();
							c6.Text = ds.Tables[0].Rows[i]["NAM_OF_DOL"].ToString();
							r.Cells.Add(c6);
							TableCell c61 = new TableCell();
							c61.HorizontalAlign = HorizontalAlign.Center;
							c61.Text = ds.Tables[0].Rows[i]["VOIN_ZVAN"].ToString();
							r.Cells.Add(c61);
							TableCell c10 = new TableCell();
							c10.HorizontalAlign = HorizontalAlign.Center;
							c10.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_POST"]).ToShortDateString();
							r.Cells.Add(c10);
							TableCell c111 = new TableCell();
							c111.HorizontalAlign = HorizontalAlign.Center;
							c111.Text = ds.Tables[0].Rows[i]["OTKYDA"].ToString();
							r.Cells.Add(c111);
							TableCell c11 = new TableCell();
							c11.HorizontalAlign = HorizontalAlign.Center;
							c11.Text = ds.Tables[0].Rows[i]["P1"].ToString();
							r.Cells.Add(c11);
							TableCell c12 = new TableCell();
							c12.HorizontalAlign = HorizontalAlign.Center;
							c12.Text = ds.Tables[0].Rows[i]["N_PR_VDOLZ"].ToString();
							r.Cells.Add(c12);
							TableCell c13 = new TableCell();
							c13.HorizontalAlign = HorizontalAlign.Center;
							c13.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DAT_PRI"]).ToShortDateString();
							r.Cells.Add(c13);

							Table5.Rows.Add(r);
                            
                            // Подсчет количества н/с и р/с
                            int z = Convert.ToInt16(ds.Tables[0].Rows[i]["ZVANIE"]);
                            if ((z >= 20 && z <= 26) || (z >= 40 && z <= 46) || (z >= 60 && z <= 66) || (z >= 100 && z <= 106)) rsCount++;
                            if ((z >= 27 && z <= 35) || (z >= 47 && z <= 55) || (z >= 67 && z <= 75) || (z >= 107 && z <= 114)) nsCount++;
						}
							
						Count = ds.Tables[0].Rows.Count;
						ds.Clear();
						Cache.Remove("In_prib");
						Table1.Visible = false;
						Table2.Visible = false;
						Table3.Visible = false;
						Table4.Visible = false;
						Table5.Visible = true;
						Table6.Visible = false;
						Table7.Visible = false;
                        Table8.Visible = false;
						break;
                    #endregion
                    case 8:  // Все уволенные
                    #region
						ds = (DataSet)Cache["Out_All"];
                        TitleText.Text = "Список всех уволенных сотрудников ОВД Ивановской области с " + date1 + " по " + date2 + " (" + pdr + ")";

						for( int i=0; i< ds.Tables[0].Rows.Count; i++)
						{
							TableRow r = new TableRow();
							TableCell c1 = new TableCell();
							c1.Text = ds.Tables[0].Rows[i]["FAMILIYA"].ToString();
							r.Cells.Add(c1);
							TableCell c2 = new TableCell();
							c2.Text = ds.Tables[0].Rows[i]["IMYA"].ToString();
							r.Cells.Add(c2);
							TableCell c3 = new TableCell();
							c3.Text = ds.Tables[0].Rows[i]["OTCHECTVO"].ToString();
							r.Cells.Add(c3);
                            TableCell c31 = new TableCell();
                            c31.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_ROZD"]).ToShortDateString();
                            r.Cells.Add(c31);
							TableCell c4 = new TableCell();
							c4.Text = ds.Tables[0].Rows[i]["PODRAZDEL"].ToString();
							r.Cells.Add(c4);
							TableCell c5 = new TableCell();
							c5.Text = ds.Tables[0].Rows[i]["NAM_OF_SLU"].ToString();
							r.Cells.Add(c5);
							TableCell c6 = new TableCell();
							c6.Text = ds.Tables[0].Rows[i]["NAM_OF_DOL"].ToString();
							r.Cells.Add(c6);
							TableCell c61 = new TableCell();
							c61.HorizontalAlign = HorizontalAlign.Center;
							c61.Text = ds.Tables[0].Rows[i]["VOIN_ZVAN"].ToString();
							r.Cells.Add(c61);
							TableCell c7 = new TableCell();
							c7.HorizontalAlign = HorizontalAlign.Center;
							c7.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_UVOL"]).ToShortDateString();
							r.Cells.Add(c7);
							TableCell c8 = new TableCell();
							c8.HorizontalAlign = HorizontalAlign.Center;
							c8.Text = ds.Tables[0].Rows[i]["P1"].ToString();
							r.Cells.Add(c8);
							TableCell c9 = new TableCell();
							c9.Text = ds.Tables[0].Rows[i]["Expr1"].ToString();
							r.Cells.Add(c9);
							TableCell c10 = new TableCell();
							c10.HorizontalAlign = HorizontalAlign.Center;
							c10.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_POST"]).ToShortDateString();
							r.Cells.Add(c10);
							TableCell c11 = new TableCell();
							c11.HorizontalAlign = HorizontalAlign.Center;
							c11.Text = ds.Tables[0].Rows[i]["Expr2"].ToString();
							r.Cells.Add(c11);
							TableCell c12 = new TableCell();
							c12.HorizontalAlign = HorizontalAlign.Center;
							c12.Text = ds.Tables[0].Rows[i]["NOM_PR_UVO"].ToString();
							r.Cells.Add(c12);
							TableCell c13 = new TableCell();
							c13.HorizontalAlign = HorizontalAlign.Center;
							c13.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_PR_UV"]).ToShortDateString();
							r.Cells.Add(c13);
                            TableCell c14 = new TableCell();
                            c14.HorizontalAlign = HorizontalAlign.Center;
                            c14.Text = ds.Tables[0].Rows[i]["NOMLICHDEL"].ToString();
                            r.Cells.Add(c14);
							Table1.Rows.Add(r);
                            
                            // Подсчет количества н/с и р/с
                            int z = Convert.ToInt16(ds.Tables[0].Rows[i]["ZVANIE"]);
                            if ((z >= 20 && z <= 26) || (z >= 40 && z <= 46) || (z >= 60 && z <= 66) || (z >= 100 && z <= 106)) rsCount++;
                            if ((z >= 27 && z <= 35) || (z >= 47 && z <= 55) || (z >= 67 && z <= 75) || (z >= 107 && z <= 114)) nsCount++;

						}
						Count = ds.Tables[0].Rows.Count;
						ds.Clear();
						Cache.Remove("Out_All");
						Table1.Visible = true;
						Table2.Visible = false;
						Table3.Visible = false;
						Table4.Visible = false;
						Table5.Visible = false;
						Table6.Visible = false;
						Table7.Visible = false;
                        Table8.Visible = false;
						break;
                    #endregion
                    case 9:  // Уволенные по п."е"
                    #region
                        ds = (DataSet)Cache["Out_Sokr"];
                        TitleText.Text = "Список уволенных сотрудников ОВД Ивановской области, по сокращению штатов, с " + date1 + " по " + date2 + " (" + pdr + ")";

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            TableRow r = new TableRow();
                            TableCell c1 = new TableCell();
                            c1.Text = ds.Tables[0].Rows[i]["FAMILIYA"].ToString();
                            r.Cells.Add(c1);
                            TableCell c2 = new TableCell();
                            c2.Text = ds.Tables[0].Rows[i]["IMYA"].ToString();
                            r.Cells.Add(c2);
                            TableCell c3 = new TableCell();
                            c3.Text = ds.Tables[0].Rows[i]["OTCHECTVO"].ToString();
                            r.Cells.Add(c3);
                            TableCell c4 = new TableCell();
                            c4.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_ROZD"]).ToShortDateString();
                            r.Cells.Add(c4);
                            TableCell c5 = new TableCell();
                            c5.Text = ds.Tables[0].Rows[i]["PODRAZDEL"].ToString();
                            r.Cells.Add(c5);
                            TableCell c6 = new TableCell();
                            c6.Text = ds.Tables[0].Rows[i]["NAM_OF_SLU"].ToString();
                            r.Cells.Add(c6);
                            TableCell c7 = new TableCell();
                            c7.Text = ds.Tables[0].Rows[i]["NAM_OF_DOL"].ToString();
                            r.Cells.Add(c7);
                            TableCell c8 = new TableCell();
                            c8.HorizontalAlign = HorizontalAlign.Center;
                            c8.Text = ds.Tables[0].Rows[i]["VOIN_ZVAN"].ToString();
                            r.Cells.Add(c8);
                            TableCell c9 = new TableCell();
                            c9.HorizontalAlign = HorizontalAlign.Center;
                            c9.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_UVOL"]).ToShortDateString();
                            r.Cells.Add(c9);
                            TableCell c10 = new TableCell();
                            c10.HorizontalAlign = HorizontalAlign.Center;
                            c10.Text = ds.Tables[0].Rows[i]["P1"].ToString();
                            r.Cells.Add(c10);
                            TableCell c11 = new TableCell();
                            c11.Text = "по сокращению штатов";
                            r.Cells.Add(c11);
                            TableCell c12 = new TableCell();
                            c12.HorizontalAlign = HorizontalAlign.Center;
                            c12.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_POST"]).ToShortDateString();
                            r.Cells.Add(c12);
                            TableCell c13 = new TableCell();
                            c13.HorizontalAlign = HorizontalAlign.Center;
                            c13.Text = ds.Tables[0].Rows[i]["Expr2"].ToString();
                            r.Cells.Add(c13);
                            TableCell c14 = new TableCell();
                            c14.HorizontalAlign = HorizontalAlign.Center;
                            c14.Text = ds.Tables[0].Rows[i]["NOM_PR_UVO"].ToString();
                            r.Cells.Add(c14);
                            TableCell c15 = new TableCell();
                            c15.HorizontalAlign = HorizontalAlign.Center;
                            c15.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_PR_UV"]).ToShortDateString();
                            r.Cells.Add(c15);

                            Table8.Rows.Add(r);

                            // Подсчет количества н/с и р/с

                            int z = Convert.ToInt16(ds.Tables[0].Rows[i]["ZVANIE"]);
                            if ((z >= 20 && z <= 26) || (z >= 40 && z <= 46) || (z >= 60 && z <= 66) || (z >= 100 && z <= 106)) rsCount++;
                            if ((z >= 27 && z <= 35) || (z >= 47 && z <= 55) || (z >= 67 && z <= 75) || (z >= 107 && z <= 114)) nsCount++;
 
                        }
                        Count = ds.Tables[0].Rows.Count;
                        ds.Clear();
                        Cache.Remove("Out_Sokr");
                        Table1.Visible = false;
                        Table2.Visible = false;
                        Table3.Visible = false;
                        Table4.Visible = false;
                        Table5.Visible = false;
                        Table6.Visible = false;
                        Table7.Visible = false;
                        Table8.Visible = true;
                        break;
                    #endregion
                    case 10: // Уволенные по собственному желанию (без пенсии)
                    #region
                        ds = (DataSet)Cache["Out_perswish"];
                        TitleText.Text = "Список уволенных сотрудников органов внутренних дел Ивановской области, по 'собственному желанию', с " + date1 + " по " + date2 + " (" + pdr + ")";

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            TableRow r = new TableRow();
                            TableCell c1 = new TableCell();
                            c1.Text = ds.Tables[0].Rows[i]["FAMILIYA"].ToString();
                            r.Cells.Add(c1);
                            TableCell c2 = new TableCell();
                            c2.Text = ds.Tables[0].Rows[i]["IMYA"].ToString();
                            r.Cells.Add(c2);
                            TableCell c3 = new TableCell();
                            c3.Text = ds.Tables[0].Rows[i]["OTCHECTVO"].ToString();
                            r.Cells.Add(c3);
                            TableCell c4 = new TableCell();
                            c4.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_ROZD"]).ToShortDateString();
                            r.Cells.Add(c4);
                            TableCell c5 = new TableCell();
                            c5.Text = ds.Tables[0].Rows[i]["PODRAZDEL"].ToString();
                            r.Cells.Add(c5);
                            TableCell c6 = new TableCell();
                            c6.Text = ds.Tables[0].Rows[i]["NAM_OF_SLU"].ToString();
                            r.Cells.Add(c6);
                            TableCell c7 = new TableCell();
                            c7.Text = ds.Tables[0].Rows[i]["NAM_OF_DOL"].ToString();
                            r.Cells.Add(c7);
                            TableCell c8 = new TableCell();
                            c8.HorizontalAlign = HorizontalAlign.Center;
                            c8.Text = ds.Tables[0].Rows[i]["VOIN_ZVAN"].ToString();
                            r.Cells.Add(c8);
                            TableCell c9 = new TableCell();
                            c9.HorizontalAlign = HorizontalAlign.Center;
                            c9.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_UVOL"]).ToShortDateString();
                            r.Cells.Add(c9);
                            TableCell c10 = new TableCell();
                            c10.HorizontalAlign = HorizontalAlign.Center;
                            c10.Text = ds.Tables[0].Rows[i]["P1"].ToString();
                            r.Cells.Add(c10);
                            TableCell c11 = new TableCell();
                            c11.Text = ds.Tables[0].Rows[i]["PRICH"].ToString();
                            r.Cells.Add(c11);
                            TableCell c12 = new TableCell();
                            c12.HorizontalAlign = HorizontalAlign.Center;
                            c12.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_POST"]).ToShortDateString();
                            r.Cells.Add(c12);
                            TableCell c13 = new TableCell();
                            c13.HorizontalAlign = HorizontalAlign.Center;
                            c13.Text = ds.Tables[0].Rows[i]["Expr2"].ToString();
                            r.Cells.Add(c13);
                            TableCell c14 = new TableCell();
                            c14.HorizontalAlign = HorizontalAlign.Center;
                            c14.Text = ds.Tables[0].Rows[i]["NOM_PR_UVO"].ToString();
                            r.Cells.Add(c14);
                            TableCell c15 = new TableCell();
                            c15.HorizontalAlign = HorizontalAlign.Center;
                            c15.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_PR_UV"]).ToShortDateString();
                            r.Cells.Add(c15);

                            Table8.Rows.Add(r);

                            // Подсчет количества н/с и р/с

                            int z = Convert.ToInt16(ds.Tables[0].Rows[i]["ZVANIE"]);
                            if ((z >= 20 && z <= 26) || (z >= 40 && z <= 46) || (z >= 60 && z <= 66) || (z >= 100 && z <= 106)) rsCount++;
                            if ((z >= 27 && z <= 35) || (z >= 47 && z <= 55) || (z >= 67 && z <= 75) || (z >= 107 && z <= 114)) nsCount++;

                        }
                        Count = ds.Tables[0].Rows.Count;
                        ds.Clear();
                        Cache.Remove("Out_perswish");
                        Table1.Visible = false;
                        Table2.Visible = false;
                        Table3.Visible = false;
                        Table4.Visible = false;
                        Table5.Visible = false;
                        Table6.Visible = false;
                        Table7.Visible = false;
                        Table8.Visible = true;
                        break;
                        #endregion
                    case 11: // Уволееные работники
                    #region
                     ds = (DataSet)Cache["Out_All_vn"];
                        TitleText.Text = "Список всех уволенных работников ОВД Ивановской области с " + date1 + " по " + date2 + " (" + pdr + ")";

						for( int i=0; i< ds.Tables[0].Rows.Count; i++)
						{
							TableRow r = new TableRow();
							TableCell c1 = new TableCell();
							c1.Text = ds.Tables[0].Rows[i]["FAMILIYA"].ToString();
							r.Cells.Add(c1);
							TableCell c2 = new TableCell();
							c2.Text = ds.Tables[0].Rows[i]["IMYA"].ToString();
							r.Cells.Add(c2);
							TableCell c3 = new TableCell();
							c3.Text = ds.Tables[0].Rows[i]["OTCHECTVO"].ToString();
							r.Cells.Add(c3);
                            TableCell c31 = new TableCell();
                            c31.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_ROZD"]).ToShortDateString();
                            r.Cells.Add(c31);
							TableCell c4 = new TableCell();
							c4.Text = ds.Tables[0].Rows[i]["PODRAZDEL"].ToString();
							r.Cells.Add(c4);
							TableCell c5 = new TableCell();
							c5.Text = ds.Tables[0].Rows[i]["NAM_OF_SLU"].ToString();
							r.Cells.Add(c5);
							TableCell c6 = new TableCell();
							c6.Text = ds.Tables[0].Rows[i]["NAM_OF_DOL"].ToString();
							r.Cells.Add(c6);
							TableCell c61 = new TableCell();
							c61.HorizontalAlign = HorizontalAlign.Center;
							c61.Text = ds.Tables[0].Rows[i]["VOIN_ZVAN"].ToString();
							r.Cells.Add(c61);
							TableCell c7 = new TableCell();
							c7.HorizontalAlign = HorizontalAlign.Center;
							c7.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_UVOL"]).ToShortDateString();
							r.Cells.Add(c7);
							TableCell c8 = new TableCell();
							c8.HorizontalAlign = HorizontalAlign.Center;
							c8.Text = ds.Tables[0].Rows[i]["P1"].ToString();
							r.Cells.Add(c8);
							TableCell c9 = new TableCell();
							c9.Text = ds.Tables[0].Rows[i]["Expr1"].ToString();
							r.Cells.Add(c9);
							TableCell c10 = new TableCell();
							c10.HorizontalAlign = HorizontalAlign.Center;
							c10.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_POST"]).ToShortDateString();
							r.Cells.Add(c10);
							TableCell c11 = new TableCell();
							c11.HorizontalAlign = HorizontalAlign.Center;
							c11.Text = ds.Tables[0].Rows[i]["Expr2"].ToString();
							r.Cells.Add(c11);
							TableCell c12 = new TableCell();
							c12.HorizontalAlign = HorizontalAlign.Center;
							c12.Text = ds.Tables[0].Rows[i]["NOM_PR_UVO"].ToString();
							r.Cells.Add(c12);
							TableCell c13 = new TableCell();
							c13.HorizontalAlign = HorizontalAlign.Center;
							c13.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_PR_UV"]).ToShortDateString();
							r.Cells.Add(c13);
                            TableCell c14 = new TableCell();
                            c14.HorizontalAlign = HorizontalAlign.Center;
                            c14.Text = ds.Tables[0].Rows[i]["NOMLICHDEL"].ToString();
                            r.Cells.Add(c14);
							Table1.Rows.Add(r);
						}
						Count = ds.Tables[0].Rows.Count;
						ds.Clear();
						Cache.Remove("Out_All_vn");
						Table1.Visible = true;
						Table2.Visible = false;
						Table3.Visible = false;
						Table4.Visible = false;
						Table5.Visible = false;
						Table6.Visible = false;
						Table7.Visible = false;
                        Table8.Visible = false;
						break;
                    #endregion
                }

				CountLabel.Text = "Итого: " + Count.ToString() + " человек(а)";
				
				
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

	}
}
