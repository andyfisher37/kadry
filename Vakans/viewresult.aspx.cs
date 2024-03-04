using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kadry.Vakans
{
	/// <summary>
	/// Summary description for viewresult.
	/// </summary>
	public partial class viewresult : System.Web.UI.Page
	{
		public System.Data.DataRowCollection rc;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				TitleText.Text = Request["title"];

				DataSet ds = new DataSet();
				ds = (DataSet)Cache["vakansy"];
				rc = ds.Tables[0].Rows;

                double stavka_dlz = 0;
                double stavka_prs = 0;

                
                for (int i = 0; i < rc.Count; i++)
                {
                    TableRow r = new TableRow();

                    // Должность
                    
                    TableCell c1 = new TableCell();
                    c1.Text = kadry.GlobalTransform.TransformDolzNames(rc[i]["NAM_OF_DOL"].ToString());
                    r.Cells.Add(c1);

                    // Подразделение
                    string cur_pdr = "";
                    if (Convert.ToString(rc[i]["N5"]) != "          - # -") cur_pdr += "группы " + Convert.ToString(rc[i]["N5"]);
                    if (Convert.ToString(rc[i]["N4"]) != "          - # -") cur_pdr += " отделения " + Convert.ToString(rc[i]["N4"]);
                    if (Convert.ToString(rc[i]["N3"]) != "          - # -") cur_pdr += " подотдела " + Convert.ToString(rc[i]["N3"]);
                    if (Convert.ToString(rc[i]["N2"]) != "          - # -") cur_pdr += " отдела " + Convert.ToString(rc[i]["N2"]);
                    if (Convert.ToString(rc[i]["N1"]) != "          - # -") cur_pdr += " управления " + Convert.ToString(rc[i]["N1"]);
                    if (Convert.ToString(rc[i]["N6"]) != "          - # -") cur_pdr += " " + Convert.ToString(rc[i]["N6"]);
                    if (Convert.ToString(rc[i]["PODRAZDEL"]) != "          - # -") cur_pdr += " " + Convert.ToString(rc[i]["PODRAZDEL"]);
                    TableCell c2 = new TableCell();
                    c2.Text = kadry.GlobalTransform.TransformPdrNames(cur_pdr);
                    r.Cells.Add(c2);

                    // Служба
                    TableCell c3 = new TableCell();
                    c3.HorizontalAlign = HorizontalAlign.Center;
                    c3.Text = kadry.GlobalTransform.TransformSlzNames(rc[i]["NAM_OF_SLU"].ToString());
                    r.Cells.Add(c3);

                    // Дата вакансии
                    TableCell c4 = new TableCell();
                    if (rc[i]["DATA_VAK"] != DBNull.Value) c4.Text = Convert.ToDateTime(rc[i]["DATA_VAK"]).ToShortDateString();
                    else c4.Text = "";
                    c4.HorizontalAlign = HorizontalAlign.Center;
                    r.Cells.Add(c4);

                    // Источник финансирования
                    //TableCell c5 = new TableCell();
                    //c5.HorizontalAlign = HorizontalAlign.Center;
                    //c5.Text = rc[i]["TEXT"].ToString();
                    //r.Cells.Add(c5);

                    // Потолок по званию
                    TableCell c6 = new TableCell();
                    c6.HorizontalAlign = HorizontalAlign.Center;
                    c6.Text = kadry.GlobalTransform.TransformZvanNames(rc[i]["VOIN_ZVAN"].ToString());
                    r.Cells.Add(c6);

                    // Оклад по должности
                    TableCell c7 = new TableCell();
                    c7.HorizontalAlign = HorizontalAlign.Center;
                    c7.Text = rc[i]["OKLAD_OT"].ToString() + " - " + rc[i]["OKLAD_DO"].ToString();
                    r.Cells.Add(c7);
                    
                    Table.Rows.Add(r);
                }

                // Суммирование одинаковых должностей...
                int index = 1;
                string cur_dolz = "";
                string prev_dolz = "";
                int cnt = 0;
                bool flag = false;
                do
                {
                    cur_dolz = Table.Rows[index].Cells[0].Text + Table.Rows[index].Cells[1].Text;
                    prev_dolz = Table.Rows[index - 1].Cells[0].Text + Table.Rows[index - 1].Cells[1].Text;
                    if (cur_dolz == prev_dolz)
                    {
                        flag = true;
                        cnt++;
                        Table.Rows[index - 1].Visible = false;
                    }
                    else
                    {
                        if (flag == true)
                        {
                            Table.Rows[index - 1].Cells[0].Text += " (" + (cnt+1).ToString() + " ед.)";
                            cnt = 0;
                            flag = false;
                        }
                    }
                    index++;
                } while(index < rc.Count);

                CountLabel.Text = "Итого: " + rc.Count.ToString() + " вакантных должностей";

                //ExcelButton.Visible = true;
                //WordButton.Visible = true;
                
			}
		}
        
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

        protected void ExcelButton_Click(object sender, ImageClickEventArgs e)
        {
            kadry.WordExcel.ExportGridToExcel(this, Table, "Список");
        }

        protected void WordButton_Click(object sender, ImageClickEventArgs e)
        {
            kadry.WordExcel.ExportGridToWord(this, Table, "Список");
        }
	}
}
