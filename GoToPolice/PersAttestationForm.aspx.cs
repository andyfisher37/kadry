using System;
using System.Data;
using System.Web.UI;


namespace kadry.GoToPolice
{
    public partial class PersAttestationForm : System.Web.UI.Page
    {
        public static string id; // Ключ сотрудника
        public static string sbase; // База
        public DataRow rt;
        public DataRow r;
        public static string dolz;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                kadry.Security.Security s = new kadry.Security.Security();

                if (!s.CheckSecurePage(User.Identity.Name, "persattestationform.aspx")) Response.Redirect("\\AccessDenied.htm", true);
								
                id = Request["id"];
                sbase = Request["base"];
                
                // Выбираем сведения о сотруднике из АИС КАДРЫ
                DataView dv1 = new DataView();
                KDataSource.SelectCommand = "SELECT FAMILIYA, IMYA, OTCHECTVO, LICH_NOM_1, LICH_NOM_2, REAL_DOLZN FROM " + sbase + " WHERE KEY_1 = " + id;
                dv1 = (DataView)KDataSource.Select(DataSourceSelectArguments.Empty);
                rt = dv1.Table.Rows[0];
                TitleText.Text = rt["FAMILIYA"].ToString() + " " + rt["IMYA"].ToString() + " " + rt["OTCHECTVO"].ToString() + " (" + rt["LICH_NOM_1"].ToString() + "-" + rt["LICH_NOM_2"].ToString() + ")";
                dolz = rt["REAL_DOLZN"].ToString();

                // Выбираем записи об аттестации из БД Аттестаций
                DataView res = new DataView();
                res = (DataView)ADataSource.Select(DataSourceSelectArguments.Empty);

                //Response.Write(res.Table.Rows[0]["CNT"].ToString());
                                
                // Если что-то найдено...
                if (res.Table.Rows.Count > 0)
                {
                    // Получаем первую строчку выборки...
                    r = res.Table.Rows[0];

                    // Присваиваем дату аттестации...
                    if (r["att_date"].ToString() != "") Date1.Text = Convert.ToDateTime(r["att_date"]).ToShortDateString();
                    else Date1.Text = "";

                    // Вывод по аттестации...
                    if (r["resolution"] == DBNull.Value) Resolution.SelectedIndex = 0;
                    else if (r["resolution"].ToString() == "1") Resolution.SelectedIndex = 1;
                    else if (r["resolution"].ToString() == "2") Resolution.SelectedIndex = 2;
                    else if (r["resolution"].ToString() == "3") Resolution.SelectedIndex = 3;

                    // Наличие рапорта...
                    if (r["att_no_men"] != DBNull.Value)
                    {
                        if (Convert.ToBoolean(r["att_no_men"])) raport.Checked = true;
                        else raport.Checked = false;
                    }

                    // Не прошел и (или) отказался прод.службу...
                    if (r["att_negative"] != DBNull.Value)
                    {
                        if (Convert.ToBoolean(r["att_negative"])) negative.Checked = true;
                        else negative.Checked = false;
                    }

                    // Дата представления к увольнению...
                    if (r["predst_uvol"].ToString() != "") Date2.Text = Convert.ToDateTime(r["predst_uvol"]).ToShortDateString();
                    else Date2.Text = "";

                    // Увольнение по инициативе сотрудника/овд...
                    if (r["self_uvol"] != DBNull.Value)
                    {
                        if (Convert.ToBoolean(r["self_uvol"])) UV1.Checked = true;
                        else UV2.Checked = false;
                    }
                }

            }
        }

        protected void UV1_CheckedChanged(object sender, EventArgs e)
        {
            UV2.Checked = false;
        }

        protected void UV2_CheckedChanged(object sender, EventArgs e)
        {
            UV1.Checked = false;
        }

        // Отмена изменений...
        protected void CancelButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("<script> window.close(); </script>");
        }
        
        // Очистка формы...
        protected void ClearButton_Click(object sender, ImageClickEventArgs e)
        {
            Date1.Text = "";
            Resolution.SelectedIndex = 0;
            raport.Checked = false;
            negative.Checked = false;
            Date2.Text = "";
            UV1.Checked = false;
            UV2.Checked = false;
            Response.Write("<script> window.reload(); </script>");
        }

        // Сохранение изменений...
        protected void SaveButton_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                kadry.Security.Security s = new kadry.Security.Security();

                id = Request["id"];

                if (Resolution.SelectedIndex == 0) Response.Write("<script> alert('Должен быть вывод по аттестации!'); window.reload(); </script>");
                else
                {
                    // Выбираем имеющие записи об аттестации
                    DataView res = (DataView)ADataSource.Select(DataSourceSelectArguments.Empty);

                    // Если они есть вносим изменения..
                    if (res.Table.Rows.Count > 0)
                    {
                        // Очищаем параметры запроса...
                        ADataSource.UpdateParameters.Clear();
                        ADataSource.UpdateCommand = "UPDATE PoliceAttestation SET att_date = convert(smalldatetime, @date1, 104), resolution = @res, att_no_men = @att1, att_negative = @att2, predst_uvol = @predst, self_uvol = @self, category = @cat WHERE (id = @key )";
                        ADataSource.UpdateParameters.Add("key", id);
                        ADataSource.UpdateParameters.Add("date1", Convert.ToDateTime(Date1.Text).ToShortDateString());
                        ADataSource.UpdateParameters.Add("res", Resolution.SelectedIndex.ToString());
                        if (raport.Checked) ADataSource.UpdateParameters.Add("att1", "1");
                        else ADataSource.UpdateParameters.Add("att1", "0");
                        if (negative.Checked) ADataSource.UpdateParameters.Add("att2", "1");
                        else ADataSource.UpdateParameters.Add("att2", "0");
                        if (Date2.Text != "") ADataSource.UpdateParameters.Add("predst", Convert.ToDateTime(Date2.Text).ToShortDateString());
                        else ADataSource.UpdateParameters.Add("predst", DBNull.Value.ToString());
                        if (UV1.Checked) ADataSource.UpdateParameters.Add("self","0");
                        if (UV2.Checked) ADataSource.UpdateParameters.Add("self","1");
                        else ADataSource.UpdateParameters.Add("self", DBNull.Value.ToString());
                        if (Convert.ToInt16(dolz.Substring(0, 2)) < 50) ADataSource.UpdateParameters.Add("cat","нс");
                        if (Convert.ToInt16(dolz.Substring(0, 2)) >= 50 && Convert.ToInt16(dolz.Substring(0, 2)) < 80) ADataSource.UpdateParameters.Add("cat","рс");
                        // Вносим изменения...
                        ADataSource.Update();
                    }
                    else // Если нет добавляем новую запись...
                    {
                        // Очищаем параметры...
                        ADataSource.InsertParameters.Clear();
                        ADataSource.InsertCommand = "INSERT INTO PoliceAttestation VALUES (@key, convert(smalldatetime, @date1, 104), @res, @att1, @att2, @predst, @self, @cat)";
                        ADataSource.InsertParameters.Add("key", id);
                        ADataSource.InsertParameters.Add("date1", Convert.ToDateTime(Date1.Text).ToShortDateString());
                        ADataSource.InsertParameters.Add("res", Resolution.SelectedIndex.ToString());
                        ADataSource.InsertParameters.Add("att1", raport.Checked.ToString());
                        ADataSource.InsertParameters.Add("att2", negative.Checked.ToString());
                        if (Date2.Text != "") ADataSource.InsertParameters.Add("predst", Convert.ToDateTime(Date2.Text).ToShortDateString());
                        else ADataSource.InsertParameters.Add("predst", DBNull.Value.ToString());
                        if (UV1.Checked) ADataSource.InsertParameters.Add("self", "0");
                        if (UV2.Checked) ADataSource.InsertParameters.Add("self", "1");
                        else ADataSource.InsertParameters.Add("self", DBNull.Value.ToString());
                        if (Convert.ToInt16(dolz.Substring(0, 2)) < 50) ADataSource.InsertParameters.Add("cat", "нс");
                        if (Convert.ToInt16(dolz.Substring(0, 2)) >= 50 && Convert.ToInt16(dolz.Substring(0, 2)) < 80) ADataSource.InsertParameters.Add("cat", "рс");
                        // Добавляем новую запись...
                        ADataSource.Insert();
                    }
                    // Протоколируем...
                    s.AddLogText("Переаттестация: " + TitleText.Text, Convert.ToString(Context.Request.UserHostAddress), 49, true);

                    Response.Write("<script> alert('Изменения сохранены!'); window.close();</script>");
                }
            }
           
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            kadry.Security.Security s = new kadry.Security.Security();

            id = Request["id"];

            // Выбираем имеющие записи об аттестации
            DataView res = (DataView)ADataSource.Select(DataSourceSelectArguments.Empty);

            // Если они есть вносим изменения..
            if (res.Table.Rows.Count > 0)
            {
                // Очищаем параметры запроса...
                ADataSource.DeleteParameters.Clear();
                ADataSource.DeleteCommand = "DELETE FROM PoliceAttestation WHERE id = @key";
                ADataSource.DeleteParameters.Add("key", id);
                // Вносим изменения...
                ADataSource.Delete();
            }

            Response.Write("<script> alert('Запись удалена!'); window.close(); </script>");
        }
    }
}
