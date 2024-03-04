using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using UK.DurationCalculatorApp;


namespace UK
{
    public partial class TableLgottime : System.Web.UI.Page
    {
        public OdbcCommand Comm;
        public OdbcConnection Conn;
        public OdbcDataAdapter DataAdapter;
        public string id;
        public System.Data.DataRowCollection rc;


        // Структура описывающее узел "дерева" командировок
        struct Node
        {
            public double k;
            public DateTime date1;
            public DateTime date2;
            public string Legend;
            public string Ovd_prik;
            public string Num_prik;
            public string Date_prik;

            public string _text1;
            public string _text2;
            public string _text3;

            public bool isSimple;

            // Проверяем входят ли тек.даты узла в период узла "n"
            public bool InNode(Node n)
            {
                if (date1 >= n.date1 && date2 <= n.date2) return true;
                else return false;
            }

            // Заполнение текущего узла значениями...
            public void Fill(double k1, DateTime d1, DateTime d2, string l, string d3, string n, string o)
            {
                k = k1;
                date1 = d1;
                date2 = d2;
                Legend = l;
                Date_prik = d3;
                Num_prik = n;
                Ovd_prik = o;
                _text1 = "Находился в служебной командировке на территории: " + Legend;
                _text1 += "<br>Основание: Приказ " + Ovd_prik + " от " + Date_prik + " №" + Num_prik;
                _text2 = date1.ToShortDateString();
                _text3 = date2.ToShortDateString();
                isSimple = true;
            }

            // Добавление входящих периодов...
            public void AddSubNode(Node n)
            {
                if (isSimple) _text1 += "<br>В соответствии с Постановлением Правительства РФ от 09.02.2004 г. №65 следующие периоды нахождения в служебной командировке засчитывать в выслугу лет:";

                DateDifference dd = new DateDifference(n.date1, n.date2);
                TPeriod p = new TPeriod();
                p.Add(dd.Days, dd.Months, dd.Years);

                _text1 += "<br>&nbsp;&nbsp - с " + n.date1.ToShortDateString() + " по " + n.date2.ToShortDateString() + " (" + p.ToSpecString() + ") засчитывать <b>1:" + n.k.ToString() + "</b> Пр." + n.Ovd_prik + " от " + n.Date_prik + " г. №" + n.Num_prik;
            }

            public void AddEnd()
            {
                if (isSimple) _text1 += "<br>В соответствии с Постановлением Правительства РФ от 09.02.2004 г. №65 время нахождения в служебной командировке засчитывать в выслугу лет <b>1:" + k.ToString() + "</b>";
                else _text1 += "<br>Остальное время пребывания в командировке засчитывать <b>1:" + k.ToString() + "</b>";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region Подготовительный этап
                // Получаем ключ человека...
                id = Request["id"];

                // Источник данных для командировок...
                DataSet ds = new DataSet();

                // Коннектимся к БД, выбираем все сведения по ключу...
                Conn = new OdbcConnection("MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=00;DefaultDir=C:\\KADRY;DriverId=277");
                Comm = new OdbcCommand("", Conn);
                DataAdapter = new OdbcDataAdapter(Comm);
                Comm.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, NOMLICHDEL, DATE_FROM, DATE_TO, KOEF_VISL, LEGEND, NUM_PRIK, SLVPR2.P1, PRIK_DATE FROM LGOTTIME.DBF, SLVPR2, AAQQ WHERE KEY_1 = MAIN_KEY AND OVD_PRIK = SLVPR2.P2 AND MAIN_KEY = " + id + " ORDER BY DATE_FROM";
                DataAdapter.SelectCommand = Comm;
                DataAdapter.Fill(ds);

                // Коллекция строк для удобства обработки...
                rc = ds.Tables[0].Rows;

                //Заголовок Ф.И.О., номер личного дела...
                TitleText.Text = rc[0]["FAMILIYA"].ToString() + " " + rc[0]["IMYA"].ToString() + " " + rc[0]["OTCHECTVO"].ToString() + "<br>(личное дело №" + rc[0]["NOMLICHDEL"].ToString() + ")";

                #endregion

                ArrayList ViewTable = new ArrayList();

                Node [] nodes = new Node [rc.Count];

                for(int i = 0; i<rc.Count;i++)
                {
                    nodes[i].Fill(Convert.ToDouble(rc[i]["KOEF_VISL"]),
                                  Convert.ToDateTime(rc[i]["DATE_FROM"]),
                                  Convert.ToDateTime(rc[i]["DATE_TO"]),
                                  rc[i]["LEGEND"].ToString(),
                                  Convert.ToDateTime(rc[i]["PRIK_DATE"]).ToShortDateString(),
                                  rc[i]["NUM_PRIK"].ToString(),
                                  rc[i]["P1"].ToString());
                }

                ArrayList excl_index = new ArrayList();

                //Пробегаем все узлы ищем вхождения
                for (int i = 0; i < rc.Count; i++)
                {
                    if (!excl_index.Contains(i))
                    {
                        for (int j = i+1; j < rc.Count; j++)
                        {
                            if (nodes[j].InNode(nodes[i]) && j != i && !excl_index.Contains(j))
                            {
                                nodes[i].AddSubNode(nodes[j]);
                                excl_index.Add(j);
                                nodes[i].isSimple = false;
                            }
                        }
                        nodes[i].AddEnd();
                        ViewTable.Add(nodes[i]); // Добавляем в список готовый узел с вхождениями...
                    }
                }

                // Выводим таблицу на экран...
                foreach (Node n in ViewTable)
                {
                    TableRow r = new TableRow();

                    TableCell c1 = new TableCell();
                    c1.HorizontalAlign = HorizontalAlign.Justify;
                    c1.Text = n._text1;
                    r.Cells.Add(c1);

                    TableCell c2 = new TableCell();
                    c2.HorizontalAlign = HorizontalAlign.Center;
                    c2.Text = n._text2;
                    r.Cells.Add(c2);

                    TableCell c3 = new TableCell();
                    c3.HorizontalAlign = HorizontalAlign.Center;
                    c3.Text = n._text3;
                    r.Cells.Add(c3);

                    Table1.Rows.Add(r);
                }

            }
        }
    }
}
