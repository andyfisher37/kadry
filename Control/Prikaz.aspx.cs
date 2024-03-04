using System;

namespace kadry.Documentum
{
    public partial class Prikaz : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.DropDownList podrList;
        protected kadry.podrDataSet podrDataSet;
        protected System.Data.Odbc.OdbcConnection odbcConnection;
        protected System.Data.Odbc.OdbcCommand Command;
        protected System.Data.Odbc.OdbcDataAdapter DataAdapter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Command = new System.Data.Odbc.OdbcCommand("SELECT * FROM PODRAZD.DBF");
                odbcConnection = new System.Data.Odbc.OdbcConnection("PageTimeout=0;FIL=dBase 5.0;MaxBufferSize=2048;DSN=KADRY;DefaultDir=C:\\KADRY;DriverId=277");
                DataAdapter = new System.Data.Odbc.OdbcDataAdapter(Command.CommandText, odbcConnection.ConnectionString);
                podrDataSet = new kadry.podrDataSet();
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(podrDataSet);
                podrList.DataSourceID = "podrDataSet";
                podrList.DataValueField = "KEY_OF_POD";
                podrList.DataTextField = "PODRAZDEL";
                podrList.DataBind();
                podrList.Items.Add("Неизвестно");
                podrList.Items.FindByText("Неизвестно").Value = "0";

            }
        }
    }
}
