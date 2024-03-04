using System;
using System.Data;

namespace kadry.NZPolice
{
    public partial class nzp_dataform : System.Web.UI.Page
    {
        public static bool isEmpty;  // признак отсутствия знака
        public static string id;
        public static int status;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Request["id"];

                // Получаем персональные данные сотрудника
                DataTable dt = DataProvider._getDataODBC("SELECT FAMILIYA, IMYA, OTCHECTVO, LICH_NOM_1, LICH_NOM_2 FROM AAQQ WHERE KEY_1 = " + id);

                DataRowCollection pers = dt.Rows;

                dt.Dispose();

                // Отображаем заголовок
                TitleText.Text = String.Format("Операция с нагрудным знаком: <b><u>{0} {1} {2}</u> ({3}-{4})</b>", pers[0]["FAMILIYA"], pers[0]["IMYA"], pers[0]["OTCHECTVO"], pers[0]["LICH_NOM_1"], pers[0]["LICH_NOM_2"]);

                // Проверяем наличие данных о нагрудном знаке...
                dt = DataProvider._getDataSQL("SELECT NZPolice.id, NZPolice.znak_type, NZPolice.znak_number, NZPolice.data_prik, NZPolice.ovd_prik, NZPolice.num_prik, " +
                                              "NZPolice.date_lost, NZPolice.date_act, NZPolice.number_act, slv_NZPStatus.status, slv_NZPType.type " +
                                              "FROM NZPolice INNER JOIN slv_NZPStatus ON NZPolice.status = slv_NZPStatus.code " +
                                              "INNER JOIN slv_NZPType ON NZPolice.znak_type = slv_NZPType.code WHERE id = " + id);
                DataRowCollection nz = dt.Rows;

                dt.Dispose();

                if (nz.Count == 0) { Info.Text = "Нет присвоенных нагрудных знаков!"; isEmpty = true; status = 0; }
                else
                {
                    isEmpty = false;

                    nzTypeList.SelectedIndex = Convert.ToInt16(nz[0]["znak_type"]);

                    Status.Text = nz[0]["status"].ToString();
                    status = Convert.ToInt16(nz[0]["status"]);
                    nzNumber.Text = nz[0]["znak_number"].ToString();
                    //nzpGiveDate.Text = Convert.ToDateTime(nz[0]["data_prik"]).ToShortDateString();
                    nzPodrName.Text = nz[0]["ovd_prik"].ToString();
                    prNumber.Text = nz[0]["num_prik"].ToString();

                    if (nz[0]["date_lost"] != DBNull.Value) nzpLostDate.Text = Convert.ToDateTime(nz[0]["date_lost"]).ToShortDateString();


                }

            }

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Search/search.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Проверка дополнительной валидности данных
            if (nzTypeList.SelectedIndex == 0 ) Response.Write(" <script> alert('Некорректно выбран тип нагрудных знаков!'); </script>");
            else if (nzNumber.Text.Length == 4 && nzTypeList.SelectedIndex != 4) Response.Write(" <script> alert('Номер знака не соответствует типу знака!'); </script>");
            //else if (Convert.ToDateTime(nzpGiveDate.Text) > DateTime.Now) Response.Write(" <script> alert('Дата закрепления превышает текущую!'); </script>");
            else
            {
                int res = 0;
                string cmd = "";
                if (isEmpty)
                {
                    NZPoliceDataSource.InsertParameters.Clear();
                    
                    cmd = String.Format("INSERT INTO NZPolice VALUES({0},{1},'{2}',convert(date,'{3}', 104),'{4}','{5}',1,{6},{7},{8})",
                          id, nzTypeList.SelectedIndex, nzNumber.Text, nzpGiveDate.Text, nzPodrName.Text, prNumber.Text, null, null, null);
                    Response.Write(cmd);
                    res = DataProvider._insDataSQL(cmd);
                }
                else
                {
                   // res = DataProvider._updDataSQL("");
                }

                if ( res > 0 ) Response.Write(" <script> alert('Нагрудный знак успешно закреплен!'); </script>");
                else Response.Write(" <script> alert('Ошибка сервера!'); </script>");
            }
        }
    }
}