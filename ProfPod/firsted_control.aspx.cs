using System;
using System.Web.UI;
using System.Data;
using System.Web.Caching;

namespace kadry.ProfPod
{
    public partial class firsted_control : System.Web.UI.Page
    {
        private System.Data.Odbc.OdbcCommand Command;
        private System.Data.Odbc.OdbcConnection Connection;
        private System.Data.Odbc.OdbcDataAdapter DataAdapter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Date1.Text = "01.01." + System.DateTime.Now.Year.ToString();
                Date2.Text = System.DateTime.Now.ToShortDateString();

            }

        }

        protected void GoButton_Click(object sender, ImageClickEventArgs e)
        {
            DataSet ds = new DataSet();
            Command = new System.Data.Odbc.OdbcCommand();
            Connection = new System.Data.Odbc.OdbcConnection("PageTimeout=0;FIL=dBase 5.0;MaxBufferSize=2048;DSN=KADRY;DefaultDir=C:\\KADRY;DriverId=277");
            Command.Connection = Connection;
            
            Command.CommandText = "SELECT PRIEM.KEY_1, PRIEM.FAMILIYA, PRIEM.IMYA, PRIEM.OTCHECTVO, PRIEM.DATA_ROZD, " +
                "PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, PRIEM.DATA_POST, " +
                "N_PR_VDOLZ, DAT_PRI, OTKYDA, SLVPR2.P1 FROM PRIEM, PODRAZD, SLUZBA, OFIC_DOL, ZVANIE, SLVPR2 WHERE " +
                "PRIEM.N_PR_DOLZ1 = SLVPR2.P2 AND " +
                "(PRIEM.PODRAZD = PODRAZD.KEY_OF_POD) AND (PRIEM.SLUZBA = SLUZBA.KEY_OF_SLU) AND " +
                "(PRIEM.DOLZNOST = OFIC_DOL.P3) AND (PRIEM.ZVANIE = ZVANIE.KEY_ZVAN) AND " +
                "(PRIEM.DOLZNOST < '800000') AND (ZVANIE < 77 OR ZVANIE = 99) AND " +
                "((KAT_POST IS NULL ) OR (KAT_POST <> 103)) AND " +
                "PRIEM.DAT_REG BETWEEN " + Convert.ToDateTime(Date1.Text).ToOADate() +
                " AND " + Convert.ToDateTime(Date2.Text).ToOADate();

            switch (SortList.SelectedItem.Value)
            {
                case "0": Command.CommandText += " ORDER BY FAMILIYA, IMYA, OTCHECTVO"; break;
                case "1": Command.CommandText += " ORDER BY PODRAZD"; break;
                case "2": Command.CommandText += " ORDER BY SLUZBA"; break;
                case "3": Command.CommandText += " ORDER BY DATA_POST"; break;

                default: Command.CommandText += ""; break;
            }
            

            DataAdapter = new System.Data.Odbc.OdbcDataAdapter(Command.CommandText, Connection.ConnectionString);
            DataAdapter.Fill(ds);

            Cache.Remove("First_education");
            Cache.Add("First_education", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);

            Response.Redirect("EditFirstEducation.aspx?date1=" + Date1.Text + "&date2=" + Date2.Text);
        }
    }
}
