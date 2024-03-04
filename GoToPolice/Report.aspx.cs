using System;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace kadry.GoToPolice
{
    public partial class Report : System.Web.UI.Page
    {
        public System.Data.Odbc.OdbcConnection kConn;
        public System.Data.Odbc.OdbcCommand kComm;
        public System.Data.Odbc.OdbcDataAdapter kDataAdapter;
        
        public System.Data.SqlClient.SqlConnection aConn;
        public System.Data.SqlClient.SqlCommand aComm;
        public System.Data.SqlClient.SqlDataAdapter aDataAdapter;

        // Прописываем некоторые запросные константы (для удобства)
        public string inPolice = "AND SLUZBA IN (1,2,8,9,11,12,14,16,23,24,25,27,29,30,31,32,34,35,36,37,38,39,41,42,43,44,52,54,56,58,59,61,65,67,69,70,71,78,85,90) ";//OR (sluzba = 13 and otdelenie = 1174)";
        public string inOther = "AND SLUZBA NOT IN (1,2,8,9,11,12,14,16,23,24,25,27,29,30,31,32,34,35,36,37,38,39,41,42,43,44,52,54,56,58,59,61,65,67,69,70,71,78,85,90) ";//OR (sluzba = 13 and otdelenie <> 1174)";

        public int Att_NS = 0;
        public int Att_RS = 0;

        public struct OPB
        {
            public static int ns_stat = 104;
            public static int rs_stat = 11;
            public static int ns_i4 = 1;
            public static int rs_i4 = 0;
            public static int ns_i5 = 1;
            public static int rs_i5 = 0;
            public static int ns_i6 = 1;
            public static int rs_i6 = 0;
            public static int ns_i7 = 1;
            public static int rs_i7 = 0;
            public static int ns_i8 = 1;
            public static int rs_i8 = 0;
            public static int ns_i9 = 1;
            public static int rs_i9 = 0;
        }

        public struct BSTM
        {
            public static int stat = 83;
            public static int i4 = 83;
            public static int i5 = 83;
            public static int i6 = 83;
            public static int i7 = 83;
            public static int i8 = 83;
            public static int i9 = 0;
            public static int i10 = 0;
            public static int i11 = 0;
            public static int i12 = 0;
            public static int i13 = 0;
            public static int i14 = 0;
            public static int i15 = 0;
            public static int i16 = 0;
            public static int i17 = 0;
            public static int i18 = 0;
            public static int i19 = 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Текущая дата расчета...
                Title.Text += System.DateTime.Now.ToShortDateString();
                
                // Открываем соединение с БД КАДРЫ и ИАС
                kConn = new OdbcConnection("Dsn=KADRY;Driver={277};dbq=C:\\KADRY;defaultdir=C:\\KADRY;driverid=277;fil=dBase IV;maxbuffersize=2048;pagetimeout=5");
                kComm = new OdbcCommand("",kConn);
                kDataAdapter = new OdbcDataAdapter(kComm.CommandText, kConn); 
                

                aConn = new SqlConnection("Data Source=COMP2\\SQLEXPRESS;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*");
                aComm = new SqlCommand("", aConn);
                aDataAdapter = new SqlDataAdapter(aComm.CommandText, aConn); 
                
                if (kConn.State != ConnectionState.Open) kConn.Open();
                if (aConn.State != ConnectionState.Open) aConn.Open();

                #region Вторая колонка (н/с)

                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_date is not null and resolution is not null and category = 'нс'";
                Att_NS = (int)aComm.ExecuteScalar(); 

                // Подлежащих аттестации Н/С
                kComm.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE REAL_DOLZN < '500000' AND FAMILIYA <> ''";
                int res = (int)kComm.ExecuteScalar() - Att_NS;
                n1.Text = res.ToString();

                // Подлежащих аттестации в ПОЛИЦИЮ Н/С
                kComm.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE REAL_DOLZN < '500000' AND FAMILIYA <> '' " + inPolice;
                res = (int)kComm.ExecuteScalar();
                n2.Text = res.ToString();

                // Подлежащих аттестации на ИНЫЕ ДОЛЖНОСТИ Н/С
                kComm.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE REAL_DOLZN < '500000' AND FAMILIYA <> '' " + inOther;
                res = (int)kComm.ExecuteScalar();
                n3.Text = res.ToString();

                // Отказавшиеся от присутствия (с рапортами) Н/С
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_no_men = 1 and category = 'нс'";
                res = (int)aComm.ExecuteScalar();
                n4.Text = (res).ToString();

                // Прошли переатестацию Н/С
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_date is not null and resolution is not null and category = 'нс'";
                res = (int)aComm.ExecuteScalar();
                n5.Text = (res).ToString();

                // Прошли переатестацию (рекомендовано для прохождения службы в полиции (ином подразделении органов внутренних дел РФ) на должности,
                // на которую аттестуемый сотрудник претендует) Н/С
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_date is not null and resolution = 1 and category = 'нс'";
                res = (int)aComm.ExecuteScalar();
                n6.Text = (res).ToString();

                // Назначено из прошедших по п.1 Н/С
                aComm.CommandText = "SELECT id, att_date FROM PoliceAttestation WHERE att_date is not null and resolution = 1 and category = 'нс'";
                aDataAdapter.SelectCommand = aComm;
                DataSet ds = new DataSet();
                aDataAdapter.Fill(ds);
                n7.Text = CheckNaznach(ds, false);

                // В том числе на должности в полиции из прошедших по п.1 Н/С
                n8.Text = CheckNaznach(ds, true);

                // Прошли переатестацию (рекомендовано для прохождения службы в полиции (ином подразделении органов внутренних дел РФ) на должности
                // с меньшим объемом полномочий или на нижестоящие должности) Н/С
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_date is not null and resolution = 2 and category = 'нс'";
                res = (int)aComm.ExecuteScalar();
                n9.Text = res.ToString();

                // Назначено из прошедших по п.2 Н/С
                aComm.CommandText = "SELECT id, att_date FROM PoliceAttestation WHERE att_date is not null and resolution = 2 and category = 'нс'";
                aDataAdapter.SelectCommand = aComm;
                ds.Clear();
                aDataAdapter.Fill(ds);
                n10.Text = CheckNaznach(ds, false);

                // В том числе на должности в полиции из прошедших по п.2 Н/С
                n11.Text = CheckNaznach(ds, true);

                // Прошли переатестацию (не рекомендовать для прохождения службы в полиции, предложить продолжить службу в ином подразделении
                // органов внутренних дел РФ на другой, в том числе нижестоящей должности) Н/С
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_date is not null and resolution = 3 and category = 'нс'";
                res = (int)aComm.ExecuteScalar();
                n12.Text = res.ToString();

                // Назначено из прошедших по п.3 Н/С
                aComm.CommandText = "SELECT id, att_date FROM PoliceAttestation WHERE att_date is not null and resolution = 3 and category = 'нс'";
                aDataAdapter.SelectCommand = aComm;
                ds.Clear();
                aDataAdapter.Fill(ds);
                n13.Text = CheckNaznach(ds, false);

                // В том числе на должности в полиции из прошедших по п.3 Н/С
                n14.Text = CheckNaznach(ds, true);

                // Не прошли внеочередную аттестацию и (или) отказались продолжить службу в ОВД на иных,
                // в том числе нижестоящих должностях Н/С
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_date is not null and att_negative = 1 and category = 'нс'";
                res = (int)aComm.ExecuteScalar();
                n15.Text = res.ToString();

                // Не прошли внеочередную аттестацию и (или) отказались продолжить службу в ОВД на иных,
                // в том числе нижестоящих должностях и
                // представлены к увольнению по инициативе ОВД Н/С
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_date is not null and att_negative = 1 and self_uvol = 0 and category = 'нс'";
                res = (int)aComm.ExecuteScalar();
                n16.Text = res.ToString();

                // Уволено из представленных к увольнению по инициативе ОВД Н/С
                aComm.CommandText = "SELECT id, att_date FROM PoliceAttestation WHERE att_date is not null and att_negative = 1 and self_uvol = 0 and category = 'нс'";
                aDataAdapter.SelectCommand = aComm;
                ds.Clear();
                aDataAdapter.Fill(ds);
                n17.Text = CheckUvol(ds);

                // Не прошли внеочередную аттестацию и (или) отказались продолжить службу в ОВД на иных,
                // в том числе нижестоящих должностях и
                // представлены к увольнению по собственной инициативе
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_date is not null and att_negative = 1 and self_uvol = 1 and category = 'нс'";
                res = (int)aComm.ExecuteScalar();
                n18.Text = res.ToString();

                // Уволено из представленных к увольнению по инициативе сотрудника
                aComm.CommandText = "SELECT id, att_date FROM PoliceAttestation WHERE att_date is not null and att_negative = 1 and self_uvol = 1 and category = 'нс'";
                aDataAdapter.SelectCommand = aComm;
                ds.Clear();
                aDataAdapter.Fill(ds);
                n19.Text = CheckUvol(ds);
                #endregion


                #region Третья колонка (р/с)
                // Подлежащих аттестации Р/С
                kComm.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE REAL_DOLZN BETWEEN '500000' AND '800000' AND FAMILIYA <> ''";
                res = (int)kComm.ExecuteScalar();
                r1.Text = res.ToString();

                // Подлежащих аттестации в ПОЛИЦИЮ Р/С
                kComm.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE REAL_DOLZN BETWEEN '500000' AND '800000' AND FAMILIYA <> '' AND SLUZBA IN (9,52,14,41,42,35,1,2,43,58,29,54,30,37,69,70,71,63,11,36,37,38,39,56,65,90,12,24,25,32,67,78,61,44,59,27,85,23)";
                res = (int)kComm.ExecuteScalar();
                r2.Text = res.ToString();

                // Подлежащих аттестации на ИНЫЕ ДОЛЖНОСТИ P/С
                kComm.CommandText = "SELECT COUNT(FAMILIYA) FROM AAQQ WHERE REAL_DOLZN BETWEEN '500000' AND '800000' AND FAMILIYA <> '' AND SLUZBA NOT IN (9,52,14,41,42,35,1,2,43,58,29,54,30,37,69,70,71,63,11,36,37,38,39,56,65,90,12,24,25,32,67,78,61,44,59,27,85,23)";
                res = (int)kComm.ExecuteScalar();
                r3.Text = res.ToString();

                // Отказавшиеся от присутствия (с рапортами) P/С
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_no_men = 1 and category = 'рс'";
                res = (int)aComm.ExecuteScalar();
                r4.Text = (res).ToString();

                // Прошли переатестацию P/С
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_date is not null and resolution is not null and category = 'рс'";
                res = (int)aComm.ExecuteScalar();
                r5.Text = (res).ToString();

                // Прошли переатестацию (рекомендовано для прохождения службы в полиции (ином подразделении органов внутренних дел РФ) на должности,
                // на которую аттестуемый сотрудник претендует) P/С
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_date is not null and resolution = 1 and category = 'рс'";
                res = (int)aComm.ExecuteScalar();
                r6.Text = (res).ToString();

                // Назначено из прошедших по п.1 P/С
                aComm.CommandText = "SELECT id, att_date FROM PoliceAttestation WHERE att_date is not null and resolution = 1 and category = 'рс'";
                aDataAdapter.SelectCommand = aComm;
                DataSet ds2 = new DataSet();
                aDataAdapter.Fill(ds2);
                r7.Text = CheckNaznach(ds2, false);

                // В том числе на должности в полиции из прошедших по п.1 P/С
                r8.Text = CheckNaznach(ds2, true);

                // Прошли переатестацию (рекомендовано для прохождения службы в полиции (ином подразделении органов внутренних дел РФ) на должности
                // с меньшим объемом полномочий или на нижестоящие должности) P/С
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_date is not null and resolution = 2 and category = 'рс'";
                res = (int)aComm.ExecuteScalar();
                r9.Text = res.ToString();

                // Назначено из прошедших по п.2 P/С
                aComm.CommandText = "SELECT id, att_date FROM PoliceAttestation WHERE att_date is not null and resolution = 2 and category = 'рс'";
                aDataAdapter.SelectCommand = aComm;
                ds2.Clear();
                aDataAdapter.Fill(ds);
                r10.Text = CheckNaznach(ds, false);

                // В том числе на должности в полиции из прошедших по п.2 P/С
                r11.Text = CheckNaznach(ds, true);

                // Прошли переатестацию (не рекомендовать для прохождения службы в полиции, предложить продолжить службу в ином подразделении
                // органов внутренних дел РФ на другой, в том числе нижестоящей должности) P/С
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_date is not null and resolution = 3 and category = 'рс'";
                res = (int)aComm.ExecuteScalar();
                r12.Text = res.ToString();

                // Назначено из прошедших по п.3 P/С
                aComm.CommandText = "SELECT id, att_date FROM PoliceAttestation WHERE att_date is not null and resolution = 3 and category = 'рс'";
                aDataAdapter.SelectCommand = aComm;
                ds.Clear();
                aDataAdapter.Fill(ds);
                r13.Text = CheckNaznach(ds, false);

                // В том числе на должности в полиции из прошедших по п.3 P/С
                r14.Text = CheckNaznach(ds, true);

                // Не прошли внеочередную аттестацию и (или) отказались продолжить службу в ОВД на иных,
                // в том числе нижестоящих должностях P/С
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_date is not null and att_negative = 1 and category = 'рс'";
                res = (int)aComm.ExecuteScalar();
                r15.Text = res.ToString();

                // Не прошли внеочередную аттестацию и (или) отказались продолжить службу в ОВД на иных,
                // в том числе нижестоящих должностях и
                // представлены к увольнению по инициативе ОВД P/С
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_date is not null and att_negative = 1 and self_uvol = 0 and category = 'рс'";
                res = (int)aComm.ExecuteScalar();
                r16.Text = res.ToString();

                // Уволено из представленных к увольнению по инициативе ОВД P/С
                aComm.CommandText = "SELECT id, att_date FROM PoliceAttestation WHERE att_date is not null and att_negative = 1 and self_uvol = 0 and category = 'рс'";
                aDataAdapter.SelectCommand = aComm;
                ds.Clear();
                aDataAdapter.Fill(ds);
                r17.Text = CheckUvol(ds);

                // Не прошли внеочередную аттестацию и (или) отказались продолжить службу в ОВД на иных,
                // в том числе нижестоящих должностях и
                // представлены к увольнению по собственной инициативе
                aComm.CommandText = "SELECT COUNT(id) FROM PoliceAttestation WHERE att_date is not null and att_negative = 1 and self_uvol = 1 and category = 'рс'";
                res = (int)aComm.ExecuteScalar();
                r18.Text = res.ToString();

                // Уволено из представленных к увольнению по инициативе сотрудника
                aComm.CommandText = "SELECT id, att_date FROM PoliceAttestation WHERE att_date is not null and att_negative = 1 and self_uvol = 1 and category = 'рс'";
                aDataAdapter.SelectCommand = aComm;
                ds.Clear();
                aDataAdapter.Fill(ds);
                r19.Text = CheckUvol(ds);
                #endregion


                #region Первая колонка (ВСЕГО)

                i1.Text = (Convert.ToInt16(n1.Text) + Convert.ToInt16(r1.Text)).ToString();
                i2.Text = (Convert.ToInt16(n2.Text) + Convert.ToInt16(r2.Text)).ToString();
                i3.Text = (Convert.ToInt16(n3.Text) + Convert.ToInt16(r3.Text)).ToString();
                i4.Text = (Convert.ToInt16(n4.Text) + Convert.ToInt16(r4.Text)).ToString();
                i5.Text = (Convert.ToInt16(n5.Text) + Convert.ToInt16(r5.Text)).ToString();
                i6.Text = (Convert.ToInt16(n6.Text) + Convert.ToInt16(r6.Text)).ToString();
                i7.Text = (Convert.ToInt16(n7.Text) + Convert.ToInt16(r7.Text)).ToString();
                i8.Text = (Convert.ToInt16(n8.Text) + Convert.ToInt16(r8.Text)).ToString();
                i9.Text = (Convert.ToInt16(n9.Text) + Convert.ToInt16(r9.Text)).ToString();
                i10.Text = (Convert.ToInt16(n10.Text) + Convert.ToInt16(r10.Text)).ToString();
                i11.Text = (Convert.ToInt16(n11.Text) + Convert.ToInt16(r11.Text)).ToString();
                i12.Text = (Convert.ToInt16(n12.Text) + Convert.ToInt16(r12.Text)).ToString();
                i13.Text = (Convert.ToInt16(n13.Text) + Convert.ToInt16(r13.Text)).ToString();
                i14.Text = (Convert.ToInt16(n14.Text) + Convert.ToInt16(r14.Text)).ToString();
                i15.Text = (Convert.ToInt16(n15.Text) + Convert.ToInt16(r15.Text)).ToString();
                i16.Text = (Convert.ToInt16(n16.Text) + Convert.ToInt16(r16.Text)).ToString();
                i17.Text = (Convert.ToInt16(n17.Text) + Convert.ToInt16(r17.Text)).ToString();
                i18.Text = (Convert.ToInt16(n18.Text) + Convert.ToInt16(r18.Text)).ToString();
                i19.Text = (Convert.ToInt16(n19.Text) + Convert.ToInt16(r19.Text)).ToString();

                #endregion


            }
        }

        // Проверка назначений по послужному списку (прошедших аттестацию)
        public string CheckNaznach(DataSet ds, bool police)
        {
            // kConn = new OdbcConnection("Dsn=KADRY;Driver={277};dbq=C:\\KADRY;defaultdir=C:\\KADRY;driverid=277;fil=dBase IV;maxbuffersize=2048;pagetimeout=5");
            // kComm = new OdbcCommand("", kConn);
            if (kConn.State != ConnectionState.Open) kConn.Open();
            
            // Счетчик количества назначенных...
            int count = 0;

            kComm.CommandText = "SELECT DATA_OT, KEY_POSL FROM POSL_SPI WHERE DATA_OT >= '19.05.2011' AND DOLZNOST < '800000'";
            DataSet ks = new DataSet();
            kDataAdapter.SelectCommand = kComm;
            kDataAdapter.Fill(ks);

            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[i]["att_date"]);
                string id = ds.Tables[0].Rows[i]["id"].ToString();
                // Дата назначения должна быть больше даты переаттестации
                kComm.CommandText = "SELECT COUNT(DATA_OT) FROM POSL_SPI WHERE DATA_OT >= " + dt.ToOADate() + " AND KEY_POSL = " + id;
                if (police) kComm.CommandText += inPolice;
                int res = (int)kComm.ExecuteScalar();
                if (res > 0) count++;
            }

            return count.ToString();
        }

        // Проверка уволенных по архиву из п.п.16,18
        public string CheckUvol(DataSet ds)
        {
            // kConn = new OdbcConnection("Dsn=KADRY;Driver={277};dbq=C:\\KADRY;defaultdir=C:\\KADRY;driverid=277;fil=dBase IV;maxbuffersize=2048;pagetimeout=5");
            // kComm = new OdbcCommand("", kConn);
            if (kConn.State != ConnectionState.Open) kConn.Open();

            // Счетчик количества уволенных...
            int count = 0;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[i]["att_date"]);
                string id = ds.Tables[0].Rows[i]["id"].ToString();
                // Дата назначения должна быть больше даты переаттестации
                kComm.CommandText = "SELECT COUNT(FAMILIYA) FROM ARCHIVE WHERE DATA_UVOL >= " + dt.ToOADate() + " AND KEY_1 = " + id;
                
                int res = (int)kComm.ExecuteScalar();
                if (res > 0) count++;
            }

            return count.ToString();
        }

    }
}
