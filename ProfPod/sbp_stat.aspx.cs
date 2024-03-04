using System;
using System.Data.Odbc;

namespace kadry.ProfPod
{
    public partial class sbp_stat : System.Web.UI.Page
    {
        protected System.Data.Odbc.OdbcConnection odbcConnection;
        protected System.Data.Odbc.OdbcCommand odbcCommand;
        protected System.Data.Odbc.OdbcDataAdapter odbcDataAdapter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Date2.Text = System.DateTime.Now.ToShortDateString();
                Date1.Text = "01.01." + System.DateTime.Now.Year.ToString();

                odbcConnection = new OdbcConnection("");
                odbcCommand = new OdbcCommand();
                odbcCommand.CommandText = "SELECT COUNT(KEY_1) FROM AAQQ WHERE FAMILIYA <> '' AND DOLZNOST < '800000' AND LICH_NOM_2 <> 'совмещ'";

                

            }

        }
    }
}
