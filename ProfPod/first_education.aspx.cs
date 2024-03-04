using System;
using System.Data;

namespace kadry.ProfPod
{
    public partial class first_education : System.Web.UI.Page
    {
        private System.Data.SqlClient.SqlConnection conn;
        private System.Data.SqlClient.SqlCommand comm;
        private System.Data.SqlClient.SqlDataAdapter adapter;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pnumber = Request.Params["numb"];
                FIO.Text = Request.Params["name"] + " (" + pnumber + ")";
                
                conn = new System.Data.SqlClient.SqlConnection("Data Source=kadryR_SERVER;Initial Catalog=Training_Database;Persist Security Info=True;User ID=sa;Password=*");
                comm = new System.Data.SqlClient.SqlCommand();
                adapter = new System.Data.SqlClient.SqlDataAdapter();

                comm.Connection = conn;
                comm.CommandText = "SELECT Table_SFirst_training.Training_Start_Date, Table_SFirst_training.Training_End_Date, Table_Persone.Surname, Table_Persone.Name, Table_Persone.SecondName, Table_Persone.Self_Number, GUIDE_EducationCenter.Name AS Center FROM Table_SFirst_training INNER JOIN Table_Persone ON Table_SFirst_training.Persone_ID = Table_Persone.ID INNER JOIN GUIDE_EducationCenter ON Table_SFirst_training.Teaching_Center = GUIDE_EducationCenter.ID WHERE (Table_Persone.Self_Number = '" + pnumber + "')";

                DataSet ds = new DataSet();
                adapter.SelectCommand = comm;
                adapter.Fill(ds);

                System.Data.DataRowCollection rc = ds.Tables[0].Rows;

                if (rc.Count > 0)
                {
                    Begin_Date.Text = Convert.ToDateTime(rc[0]["Training_Start_Date"]).ToShortDateString();
                    End_Date.Text = Convert.ToDateTime(rc[0]["Training_End_Date"]).ToShortDateString();
                    Traning_Place.Text = rc[0]["Center"].ToString();
                }
                else
                {
                    Begin_Date.Text = "-";
                    End_Date.Text = "-";
                    Traning_Place.Text = "-";

                    NoInfo.Visible = true;
                }



            }
        }
    }
}
