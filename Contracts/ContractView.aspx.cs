using System;

namespace kadry.Contracts
{
    public partial class ContractView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string first_name = Request["first_name"];
                string name = Request["name"];
                string second_name = Request["second_name"];
                string born = Request["born"];
                string dolz1 = Request["dol1"];
                string dolz2 = Request["dol2"];
                string fiosmall = Request["fiosmall"];
                string rank = Request["rank"];
                string pass_ser = Request["pass_ser"];
                string pass_num = Request["pass_num"];
                string pass_ovd = Request["pass_ovd"];
                string live_place = Request["live_place"];

                FIO.Text = first_name + " " + name + " " + second_name;
                
                
                Response.AddHeader("Content-Disposition", "attachment;inline; filename=" + FIO.Text + ".doc");
                Response.ContentType = "application/msword";

                BORN.Text = born;

                Dol1.Text = dolz1;
                Dol2.Text = dolz2;

                RANK.Text = rank;

                FIOsmall.Text = fiosmall;

                FIO2.Text = FIO.Text;

                PASS_SER.Text = pass_ser;
                PASS_NUM.Text = pass_num;
                PASS_OVD.Text = pass_ovd;
                LIVE.Text = live_place;
                

            }

        }
    }
}