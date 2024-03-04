using System;
using System.Web.UI.WebControls;
using System.Web.Caching;
using System.Data;

namespace kadry.Control
{
    public partial class moving_view : System.Web.UI.Page
    {
        public System.Data.DataRowCollection rc;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int cat = Convert.ToInt16(Request.Params["cat"]);
                string date1 = Request.Params["date1"];
                string date2 = Request.Params["date2"];
                string pdr = Request.Params["pdr"];
                string slz = Request.Params["slz"];
                int count = Convert.ToInt16(Request.Params["cnt"]);
                                
                switch (cat)
                {
                    case 0: // 1)
                        {
                            Table1.Visible = true;
                            Table2.Visible = false;

                            DataSet pers = new DataSet();
                            pers = (DataSet)Cache["pers"];
                            rc = pers.Tables[0].Rows;

                            DataSet[] list = new DataSet[count];
                            list = (DataSet[])Cache["list"];

                            TitleText.Text = "Список аттестованных сотрудников, назначенных в " + pdr + " в период с " + date1 + " по " + date2 + "<br>" + "(служба - " + slz.ToLower() + ")";

                            for (int i = 0; i < rc.Count; i++)
                            {
                                TableRow r = new TableRow();
                                TableCell c1 = new TableCell();
                                //c1.Text = "<a href='../DetailPage.aspx?id=" + rc[i]["KEY_1"].ToString() + "'>" + rc[i]["FAMILIYA"].ToString() + "</a>";
                                c1.Text = rc[i]["FAMILIYA"].ToString();
                                r.Cells.Add(c1);

                                TableCell c2 = new TableCell();
                                c2.Text = rc[i]["IMYA"].ToString();
                                r.Cells.Add(c2);

                                TableCell c3 = new TableCell();
                                c3.Text = rc[i]["OTCHECTVO"].ToString();
                                r.Cells.Add(c3);

                                TableCell c4 = new TableCell();
                                c4.HorizontalAlign = HorizontalAlign.Center;
                                c4.Text = rc[i]["VOIN_ZVAN"].ToString();
                                r.Cells.Add(c4);

                                DataRowCollection tc = list[i].Tables[0].Rows;

                                string str = tc[1]["NAM_OF_DOL"].ToString() + " - ";
                                if (tc[1]["GRUP"].ToString() != "9") str += "группы " + tc[1]["NAIMENOVAN5"].ToString();
                                if (tc[1]["OTDELENIE"].ToString() != "9") str += " отделения " + tc[1]["NAIMENOVAN4"].ToString();
                                if (tc[1]["PODOTDEL"].ToString() != "9") str += " подотдела " + tc[1]["NAIMENOVAN3"].ToString();
                                if (tc[1]["OTDEL"].ToString() != "9") str += " отдела " + tc[1]["NAIMENOVAN2"].ToString();
                                if (tc[1]["UPRAVLENIE"].ToString() != "9") str += " управление " + tc[1]["NAIMENOVAN1"].ToString();
                                if (tc[1]["PODR"].ToString() != "9") str += " " + tc[1]["NAIMENOVAN"].ToString();
                                if (tc[1]["PODRAZD"].ToString() != "9") str += " " + tc[1]["PODRAZDEL"].ToString();
                                str = kadry.GlobalTransform.TransformPdrNames(str);

                                TableCell c5 = new TableCell();
                                c5.HorizontalAlign = HorizontalAlign.Center;
                                c5.Text = str;
                                r.Cells.Add(c5);

                                TableCell c6 = new TableCell();

                                str = tc[0]["NAM_OF_DOL"].ToString() + " - ";
                                if (tc[0]["GRUP"].ToString() != "9") str += "группы " + tc[0]["NAIMENOVAN5"].ToString();
                                if (tc[0]["OTDELENIE"].ToString() != "9") str += " отделения " + tc[0]["NAIMENOVAN4"].ToString();
                                if (tc[0]["PODOTDEL"].ToString() != "9") str += " подотдела " + tc[0]["NAIMENOVAN3"].ToString();
                                if (tc[0]["OTDEL"].ToString() != "9") str += " отдела " + tc[0]["NAIMENOVAN2"].ToString();
                                if (tc[0]["UPRAVLENIE"].ToString() != "9") str += " управление " + tc[0]["NAIMENOVAN1"].ToString();
                                if (tc[0]["PODR"].ToString() != "9") str += " " + tc[0]["NAIMENOVAN"].ToString();
                                if (tc[0]["PODRAZD"].ToString() != "9") str += " " + tc[0]["PODRAZDEL"].ToString();

                                str = kadry.GlobalTransform.TransformPdrNames(str);

                                c6.Text = str;
                                r.Cells.Add(c6);


                                TableCell c7 = new TableCell();
                                c7.HorizontalAlign = HorizontalAlign.Center;
                                c7.Text = Convert.ToDateTime(rc[i]["DATA_VDOLZ"]).ToShortDateString();
                                r.Cells.Add(c7);

                                Table1.Rows.Add(r);
                            }
                            CountLabel.Text = "Всего назначено: " + count.ToString() + " сотрудников";

                            Cache.Remove("pers");
                            Cache.Remove("list");
                        }

                        break;
                    case 1:
                        {
                            Table2.Visible = true;
                            Table1.Visible = false;

                            bool Flag = true;

                            DataSet pers = new DataSet();
                            pers = (DataSet)Cache["pers"];
                            rc = pers.Tables[0].Rows;

                            DataSet[] list = new DataSet[count];
                            list = (DataSet[])Cache["list"];

                            TitleText.Text = "Список аттестованных сотрудников, перемещенных из службы в службу в " + pdr + " в период с " + date1 + " по " + date2 + "<br>)";

                            for (int i = 0; i < rc.Count; i++)
                            {
                                Flag = true;

                                TableRow r = new TableRow();

                                TableCell c1 = new TableCell();
                                //c1.Text = "<a href='../DetailPage.aspx?id=" + rc[i]["KEY_1"].ToString() + "'>" + rc[i]["FAMILIYA"].ToString() + "</a>";
                                c1.Text = rc[i]["FAMILIYA"].ToString();
                                r.Cells.Add(c1);

                                TableCell c2 = new TableCell();
                                c2.Text = rc[i]["IMYA"].ToString();
                                r.Cells.Add(c2);

                                TableCell c3 = new TableCell();
                                c3.Text = rc[i]["OTCHECTVO"].ToString();
                                r.Cells.Add(c3);

                                TableCell c4 = new TableCell();
                                c4.HorizontalAlign = HorizontalAlign.Center;
                                c4.Text = rc[i]["VOIN_ZVAN"].ToString();
                                r.Cells.Add(c4);

                                DataRowCollection tc = list[i].Tables[0].Rows;

                                if (tc.Count > 1)
                                {
                                    if (tc[0]["SLUZBA"].ToString() != tc[1]["SLUZBA"].ToString())
                                    {

                                        string str = tc[1]["NAM_OF_DOL"].ToString() + " - ";
                                        if (tc[1]["GRUP"].ToString() != "9") str += "группы " + tc[1]["NAIMENOVAN5"].ToString();
                                        if (tc[1]["OTDELENIE"].ToString() != "9") str += " отделения " + tc[1]["NAIMENOVAN4"].ToString();
                                        if (tc[1]["PODOTDEL"].ToString() != "9") str += " подотдела " + tc[1]["NAIMENOVAN3"].ToString();
                                        if (tc[1]["OTDEL"].ToString() != "9") str += " отдела " + tc[1]["NAIMENOVAN2"].ToString();
                                        if (tc[1]["UPRAVLENIE"].ToString() != "9") str += " управление " + tc[1]["NAIMENOVAN1"].ToString();
                                        if (tc[1]["PODR"].ToString() != "9") str += " " + tc[1]["NAIMENOVAN"].ToString();
                                        if (tc[1]["PODRAZD"].ToString() != "9") str += " " + tc[1]["PODRAZDEL"].ToString();
                                        str = kadry.GlobalTransform.TransformPdrNames(str);

                                        TableCell c5 = new TableCell();
                                        c5.HorizontalAlign = HorizontalAlign.Center;
                                        c5.Text = str;
                                        r.Cells.Add(c5);

                                        TableCell c6 = new TableCell();

                                        str = tc[0]["NAM_OF_DOL"].ToString() + " - ";
                                        if (tc[0]["GRUP"].ToString() != "9") str += "группы " + tc[0]["NAIMENOVAN5"].ToString();
                                        if (tc[0]["OTDELENIE"].ToString() != "9") str += " отделения " + tc[0]["NAIMENOVAN4"].ToString();
                                        if (tc[0]["PODOTDEL"].ToString() != "9") str += " подотдела " + tc[0]["NAIMENOVAN3"].ToString();
                                        if (tc[0]["OTDEL"].ToString() != "9") str += " отдела " + tc[0]["NAIMENOVAN2"].ToString();
                                        if (tc[0]["UPRAVLENIE"].ToString() != "9") str += " управление " + tc[0]["NAIMENOVAN1"].ToString();
                                        if (tc[0]["PODR"].ToString() != "9") str += " " + tc[0]["NAIMENOVAN"].ToString();
                                        if (tc[0]["PODRAZD"].ToString() != "9") str += " " + tc[0]["PODRAZDEL"].ToString();

                                        str = kadry.GlobalTransform.TransformPdrNames(str);

                                        c6.Text = str;
                                        r.Cells.Add(c6);

                                    }
                                    else
                                    {
                                        Flag = false;
                                        count--;
                                    }
                                }
                                else
                                {
                                    Flag = false;
                                    count--;
                                }
                                
                                TableCell c7 = new TableCell();
                                c7.HorizontalAlign = HorizontalAlign.Center;
                                c7.Text = Convert.ToDateTime(rc[i]["DATA_VDOLZ"]).ToShortDateString();
                                r.Cells.Add(c7);

                                if (Flag == true) Table2.Rows.Add(r);
                                
                            }
                            CountLabel.Text = "Всего перемещено: " + count.ToString() + " сотрудников";

                            Cache.Remove("pers");
                            Cache.Remove("list");
                        }
                        break;
                }


            }

        }
    }
}
