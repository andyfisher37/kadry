using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UK
{
    public partial class IsxDelo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if (TypeBtn.SelectedItem.Value == "0")
                {
                    PrilogLabel.Visible = true;
                    Check1.Visible = true;
                    Check2.Visible = true;
                    Check3.Visible = true;
                    Check4.Visible = true;
                    Check5.Visible = true;
                    Text1.Visible = true;
                    Text2.Visible = true;
                    Text3.Visible = true;
                    Text4.Visible = true;
                    Text5.Visible = true;
                    RetCheck.Visible = false;
                }
                else
                {
                    PrilogLabel.Visible = false;
                    Check1.Visible = false;
                    Check2.Visible = false;
                    Check3.Visible = false;
                    Check4.Visible = false;
                    Check5.Visible = false;
                    Text1.Visible = false;
                    Text2.Visible = false;
                    Text3.Visible = false;
                    Text4.Visible = false;
                    Text5.Visible = false;
                    RetCheck.Visible = true;
                }
               
        }

        protected void GoButton_Click(object sender, EventArgs e)
        {
            string param = Request.Params["id"] +
            "&Podr=" + PodrName.Text +
            "&RukZvan=" + ZvanList.SelectedItem.Value +
            "&PodrRuk=" + PodrRuk.Text +
            "&PrCheck=" + PrCheck.Checked +
            "&Isp=" + IspText.Text +
            "&IspPhone=" + IspPhoneText.Text +
            "&Ruk=" + RukList.SelectedItem.Value;

            if (TypeBtn.SelectedItem.Value == "0")
            {
                if (Check1.Checked) param += "&n_main=" + Text1.Text;
                else param += "&n_main=0";
                if (Check2.Checked) param += "&n_sp=" + Text2.Text;
                else param += "&n_sp=0";
                if (Check3.Checked) param += "&n_zap=" + Text3.Text;
                else param += "&n_zap=0";
                if (Check4.Checked) param += "&n_tk=" + Text4.Text;
                else param += "&n_tk=0";
                if (Check5.Checked) param += "&n_vb=" + Text5.Text;
                else param += "&n_vb=0";

                param += "&type=0";
            }
            else
            {
                if ( RetCheck.Checked ) param += "&ret=1";
                else param += "&ret=0";

                param += "&type=1";

            }

            Response.Redirect("ViewIsx.aspx?id=" + param);
        }
    }
}
