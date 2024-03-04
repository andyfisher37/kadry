using System;

namespace kadry.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Date2.Text = DateTime.Now.AddYears(-1).ToShortDateString();
                Date2.Text = "01.01.2000";




            }
        }
    }
}
