using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace kadry.Declaration
{
    public partial class Declaration : System.Web.UI.Page
    {
        public static string name1, name2, name3;
        public static string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.first_name_TextChanged(sender, e);
            this.second_name_TextChanged(sender, e);
            this.last_name_TextChanged(sender, e);

            OdbcDataSource.SelectCommand = "SELECT KEY_1, FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, PODRAZD, REAL_DOLZN, LICH_NOM_1, LICH_NOM_2 FROM AAQQ WHERE DOLZNOST < '800000' AND LICH_NOM_2 <> 'совмещ' ";

            // Ф.И.О.
            if (first_name.Text != "")
            {
                OdbcDataSource.SelectCommand += " AND FAMILIYA LIKE '" + first_name.Text + "%'";
                name1 = first_name.Text;
            }

            if (second_name.Text != "")
            {
                OdbcDataSource.SelectCommand += " AND IMYA LIKE '" + second_name.Text + "%'";
                name2 = second_name.Text;
            }

            if (last_name.Text != "")
            {
                OdbcDataSource.SelectCommand += " AND OTCHECTVO LIKE '" + last_name.Text + "%'";
                name3 = last_name.Text;
            }

            Grid.DataBind();

            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                SqlDataSource.SelectCommand = "SELECT * FROM Declaration WHERE ID = " + Grid.Rows[i].Cells[5].Text + " ORDER BY YEAR_DECL";
                DataView dv = (DataView)SqlDataSource.Select(DataSourceSelectArguments.Empty);
                if (dv.Table.Rows.Count > 0)
                {
                    for (int j = 0; j < dv.Table.Rows.Count; j++)
                    {
                        Grid.Rows[i].Cells[6].Text += "сданы " + Convert.ToDateTime(dv.Table.Rows[j]["DATE_GIVEN"]).ToShortDateString() + " за " + dv.Table.Rows[j]["YEAR_DECL"].ToString() + " год<br>";
                    }
                }
                else
                {
                    Grid.Rows[i].Cells[6].Text = "нет сведений";
                }
            }
 

        }


        protected void Grid_RowEditing(object sender, GridViewEditEventArgs e)
        {
           id = Grid.Rows[e.NewEditIndex].Cells[5].Text;
           string param = "?id=" + id + "&name1=" + name1 + "&name2=" + name2 + "&name3=" + name3;
           Response.Redirect("EditDecl.aspx?id=" + param);
        }

        protected void first_name_TextChanged(object sender, EventArgs e)
        {
            if (first_name.Text.Length != 0)
            {
                string tmp = Convert.ToString(first_name.Text[0]);
                first_name.Text = tmp.ToUpper() + first_name.Text.Substring(1, first_name.Text.Length - 1).ToLower();
            }
        }

        protected void second_name_TextChanged(object sender, EventArgs e)
        {
            if (second_name.Text.Length != 0)
            {
                string tmp = Convert.ToString(second_name.Text[0]);
                second_name.Text = tmp.ToUpper() + second_name.Text.Substring(1, second_name.Text.Length - 1).ToLower();
            }
        }

        protected void last_name_TextChanged(object sender, EventArgs e)
        {
            if (last_name.Text.Length != 0)
            {
                string tmp = Convert.ToString(last_name.Text[0]);
                last_name.Text = tmp.ToUpper() + last_name.Text.Substring(1, last_name.Text.Length - 1).ToLower();
            }
        }



    }
}
