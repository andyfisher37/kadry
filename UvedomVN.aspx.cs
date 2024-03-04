using System;

namespace UK
{
    public partial class UvedomVN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UK.Security.Security s = new UK.Security.Security();
                //if (!s.CheckSecurePage(Context.User.Identity.Name, "uvedomVN.aspx")) Response.Redirect("AccessDenied.htm", true);

                mainLabel.Text = Request["fio"].ToUpper();
             
                prDate.Text = Request["sokrdate"];
                prNum.Text = Request["sokrpr"];

                if (Request["dolz"] == "0") prDolz.Text = "";
                else prDolz.Text = Request["dolz"];

                mainLabel0.Text = Request["fio"].ToUpper();
                prDate0.Text = Request["sokrdate"];
                prNum0.Text = Request["sokrpr"];

                if (Request["dolz"] == "0") prDolz0.Text = "";
                else prDolz0.Text = Request["dolz"];

                s.AddLogText("Уведомление: " + Request["fio"], (string)(Context.Request.UserHostAddress), 50, true);
            }

        }
    }
}
