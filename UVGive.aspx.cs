using System;
using System.Data;
using System.Web.UI;

namespace UK
{
    public partial class UVGive : System.Web.UI.Page
    {
        protected string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Request["id"];

                DataView dv = new DataView();
                kDataSource.SelectCommand = "SELECT FAMILIYA, IMYA, OTCHECTVO, LICH_NOM_1, LICH_NOM_2 FROM AAQQ WHERE KEY_1 = " + id;
                dv = (DataView) kDataSource.Select(DataSourceSelectArguments.Empty);

                TitleText.Text = dv.Table.Rows[0]["FAMILIYA"].ToString() + " " + dv.Table.Rows[0]["IMYA"].ToString() + " " + dv.Table.Rows[0]["OTCHECTVO"].ToString() + " (" + dv.Table.Rows[0]["LICH_NOM_1"].ToString() + "-" + dv.Table.Rows[0]["LICH_NOM_2"].ToString() + ")";
                                
                dv = (DataView)uvDataSource.Select(DataSourceSelectArguments.Empty);

                if (dv.Table.Rows.Count > 0)
                {
                    if (dv.Table.Rows[0]["date_notification_give"] != DBNull.Value)
                        DateGive.Text = Convert.ToDateTime(dv.Table.Rows[0]["date_notification_give"]).ToShortDateString();
                }
                else
                {
                 Response.Write("<script> alert('Уведомление не выписывалось!'); window.close(); </script>");
                }


                dv.Dispose();

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UK.Security.Security s = new UK.Security.Security();
            //string tmp = "";

            if (Page.IsValid)
            {
                if (DateGive.Text == "")
                {
                    id = Request["id"];
                    uvDataSource.UpdateParameters.Clear();
                    uvDataSource.UpdateCommand = "UPDATE Notification SET date_notification_give = null WHERE id = @key";
                    uvDataSource.UpdateParameters.Add("key", id);
                    uvDataSource.Update();
                }
                else
                {
                    uvDataSource.Update();
                }
                s.AddLogText("Дата вручения уведомления: " + TitleText.Text + " - " + DateGive.Text, Convert.ToString(Context.Request.UserHostAddress), 51, true);
                uvDataSource.UpdateParameters.Clear();
                
            }
            Response.Write("<script> alert('Дата выдачи уведомления успешно сохранена!'); window.close(); </script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<script> window.close(); </script>");
        }
    }
}
