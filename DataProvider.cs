using System;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

namespace kadry
{
    class DataProvider
    {
        // Строки подключения к источникам данных
        public static string odbcConnectionString = "Dsn=Kadry;DefaultDir=C:\\Kadry;DriverID=277;Fil=dBase IV;MaxBufferSize=2048;PageTimeout=5";
        public static string oledbConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Program Files\\Алфавитня карточка\\Cards.mdb";
        public static string sqlConnectionString = "Data Source=URLS_SERVER\\sqlexpress;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*";
        

        // Методы доступа к данным (по типу провайдеров)
        
        // Запрос данных в SQL Server (табличный)
        public static DataTable _getDataSQL(string cmd)
        {
            // Создаем соединение
            SqlConnection Conn = new SqlConnection(sqlConnectionString);
            Conn.Open();
            // Создаем транзакцию
            SqlTransaction tr = Conn.BeginTransaction();
            // Создаем таблицу для данных
            DataTable dt = new DataTable();
            // Создаем SQL команду с передаваемым в cmd текстом
            SqlCommand cm = new SqlCommand(cmd, Conn) { Transaction = tr };
            cm.CommandType = CommandType.Text;
            try
            {
                // Читаем данные
                SqlDataReader dr = cm.ExecuteReader();
                dt.Load(dr);
                dr.Dispose();
            }
            catch (SqlException ex)
            {
                // В случае ошибки протоколируем
                Add2ErrorLog(ex.Message, cmd);
            }
            tr.Commit();
            Conn.Close();
            cm.Dispose();
            tr.Dispose();
            return dt; // Возвращаем результат
        }

        // Запрос данных через ODBC (возвращает таблицу с данными System.Data.DataTable)
        public static DataTable _getDataODBC(string cmd)
        {
            // Создаем таблицу для заполенения данными
            DataTable dt = new DataTable();
            // Создаем подключение
            OdbcConnection Conn = new OdbcConnection(odbcConnectionString);
            Conn.Open();
            // Создаем SQL команду
            OdbcCommand cm = new OdbcCommand(cmd, Conn);
            try
            {
                cm.CommandType = CommandType.Text;
                OdbcDataReader dr = cm.ExecuteReader();
                dt.Load(dr);
                dr.Dispose();
            }
            catch (OdbcException ex)
            {
                // Если ошибка, записываем текст в лог-файл
                Add2ErrorLog(ex.Message, cmd);
            }
            
            Conn.Close();
            cm.Dispose();
            return dt;
        }

        // Запрос данных через OLEDB (возвращает таблицу с данными System.Data.DataTable)
        public static DataTable _getDataOLEDB(string cmd)
        {
            // Создаем таблицу для заполенения данными
            DataTable dt = new DataTable();
            // Создаем подключение
            OleDbConnection Conn = new OleDbConnection(oledbConnectionString);
            Conn.Open();
            // Создаем SQL команду
            OleDbCommand cm = new OleDbCommand(cmd, Conn);
            try
            {
                cm.CommandType = CommandType.Text;
                OleDbDataReader dr = cm.ExecuteReader();
                dt.Load(dr);
                dr.Dispose();
            }
            catch (OleDbException ex)
            {
                // Если ошибка, записываем текст в лог-файл
                Add2ErrorLog(ex.Message, cmd);
            }

            Conn.Close();
            cm.Dispose();
            return dt;
        }
   
        // Протоколиование ошибок
        private static void Add2ErrorLog(string error_text, string cmd_text)
        {
            // получаем путь к папке с логами
            string path = System.Web.HttpContext.Current.Server.MapPath("/Logs/");
            // открываем поток для записи
            StreamWriter log = new StreamWriter(String.Format("{0}DataProvider_{1}.log", path, System.DateTime.Now.ToShortDateString()));
            // записываем
            log.WriteLine(String.Format("{0};[{1}];{2}",DateTime.Now, cmd_text, error_text));
            log.Flush();
            log.Close();
            log.Dispose();
        }



        // Запрос данных в SQL Server (табличный с явным указанием на строку подключения)
        public static DataTable _getDataSQL(string con_str, string cmd)
        {
            SqlConnection Conn = new SqlConnection(con_str);
            Conn.Open();
            SqlTransaction tr = Conn.BeginTransaction();
            DataTable dt = new DataTable();
            SqlCommand cm = new SqlCommand(cmd, Conn) { Transaction = tr };
            cm.CommandType = CommandType.Text;
            SqlDataReader dr = cm.ExecuteReader();
            dt.Load(dr);
            tr.Commit();
            Conn.Close();
            dr.Dispose();
            cm.Dispose();
            tr.Dispose();
            return dt;
        }
        

        // Запрос данных ODBC (простой)
        public static int _getDataODBCs(string cmd)
        {
            int res = 0;
            OdbcConnection Conn = new OdbcConnection(odbcConnectionString);
            Conn.Open();
            OdbcCommand cm = new OdbcCommand(cmd, Conn);
            try
            {
                cm.CommandType = CommandType.Text;
                res = Convert.ToInt16(cm.ExecuteScalar());
            }
            catch (OdbcException ex)
            {
                Add2ErrorLog(ex.Message, cmd);
            }

            Conn.Close();
            cm.Dispose();
            return res;
        }



        // Запрос данных SQL (простой)
        public static int _getDataSQLs(string cmd)
        {
            SqlConnection Conn = new SqlConnection(sqlConnectionString);
            Conn.Open();
            SqlCommand cm = new SqlCommand(cmd, Conn);
            cm.CommandType = CommandType.Text;
            int res = Convert.ToInt16(cm.ExecuteScalar());
            Conn.Close();
            cm.Dispose();
            return res;
        }

        // Вставка данных SQL
        public static int _insDataSQL(string cmd)
        {
            int res = 0;
            SqlConnection Conn = new SqlConnection(sqlConnectionString);
            Conn.Open();
            SqlTransaction tr = Conn.BeginTransaction();
            SqlCommand cm = new SqlCommand(cmd, Conn) { Transaction = tr };
            cm.CommandType = CommandType.Text;
            res = cm.ExecuteNonQuery();
            tr.Commit();
            Conn.Close();
            cm.Dispose();
            tr.Dispose();
            return res;
        }

        // Обновление данных SQL
        public static int _updDataSQL(string cmd)
        {
            int res = 0;
            SqlConnection Conn = new SqlConnection(sqlConnectionString);
            Conn.Open();
            SqlTransaction tr = Conn.BeginTransaction();
            SqlCommand cm = new SqlCommand(cmd, Conn) { Transaction = tr };
            cm.CommandType = CommandType.Text;
            res = cm.ExecuteNonQuery();
            tr.Commit();
            Conn.Close();
            cm.Dispose();
            tr.Dispose();
            return res;
        }

        



    }
}
