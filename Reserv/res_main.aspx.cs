using System;
using System.Data;


namespace kadry.Reserv
{
    public partial class Res_main : System.Web.UI.Page
    {
        
        protected System.Data.Odbc.OdbcCommand Command;
        protected System.Data.Odbc.OdbcConnection odbcConnection;
        protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
        protected kadry.sluzDataSet sluzDataSet;
        protected kadry.podrDataSet podrDataSet;
        protected System.Data.SqlClient.SqlCommand SqlCommand;
        protected System.Data.SqlClient.SqlConnection SqlConnection;


        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
            this.Command = new System.Data.Odbc.OdbcCommand();
            this.odbcConnection = new System.Data.Odbc.OdbcConnection();
            this.SqlCommand = new System.Data.SqlClient.SqlCommand();
            this.SqlConnection = new System.Data.SqlClient.SqlConnection();
            this.podrDataSet = new kadry.podrDataSet();
            this.sluzDataSet = new kadry.sluzDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).BeginInit();
            // 
            // DataAdapter
            // 
            this.DataAdapter.SelectCommand = this.Command;
            // 
            // Command
            // 
            this.Command.Connection = this.odbcConnection;
            // 
            // odbcConnection
            // 
            this.odbcConnection.ConnectionString = "PageTimeout=0;FIL=dBase 5.0;MaxBufferSize=2048;DSN=KADRY;DefaultDir=C:\\KADRY;Driv" +
                "erId=533";
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
            // SqlCommand
            //
            this.SqlCommand.Connection = this.SqlConnection;
            //
            // SqlConnection
            //
            this.SqlConnection.ConnectionString = "Data Source=kadryR_SERVER;Initial Catalog=Reserv;Persist Security Info=True;User ID=ias_user;Password=*";

            ((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).EndInit();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                kadry.Security.Security s = new kadry.Security.Security();
                
                if (!s.CheckSecurePage(User.Identity.Name, "res_main.aspx")) Response.Redirect("\\AccessDenied.htm", true);

                Command.CommandText = "SELECT * FROM PODRAZD.DBF WHERE KEY_OF_POD IN (SELECT DISTINCT PODRAZD FROM AAQQ.DBF)";
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(podrDataSet);
                podrList.DataBind();
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

                SqlCommand.CommandText = "SELECT DISTINCT COUNT(pers_id) AS CNT FROM pers_Rezerv WHERE activated = 1";
                if (SqlConnection.State != ConnectionState.Open) SqlConnection.Open();
                int pCount = (int)SqlCommand.ExecuteScalar();
                CountPers.Text = pCount.ToString();

                SqlCommand.CommandText = "SELECT DISTINCT COUNT(dolz_id) AS CNT FROM dolz_Rezerv WHERE activated = 1";
                if (SqlConnection.State != ConnectionState.Open) SqlConnection.Open();
                int dCount = (int)SqlCommand.ExecuteScalar();
                CountDolz.Text = dCount.ToString();
                

            }
						

        }
    }
}
