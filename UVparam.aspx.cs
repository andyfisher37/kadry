using System;
using System.Data;
using System.Web.UI;

namespace UK
{
    public partial class UVparam : System.Web.UI.Page
    {
        public static string id;
        public static string dolz;
        public static bool ovo;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Request["id"];

                if (id == "0") Response.Write("<script> alert('Нет ключа у работника, невозможно зафиксировать. Обратитесь к Александрову Р.А.!'); window.close(); </script>");

                NowDate.Text = DateTime.Now.ToShortDateString();

                DataView dv = new DataView();
                kDataSource.SelectCommand = "SELECT FAMILIYA, IMYA, OTCHECTVO, LICH_NOM_1, LICH_NOM_2, DATA_SOKR, NOMPRSOKDO, SLUZBA, PODRAZD, OFIC_DOL.P3, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, Podrazd.PODRAZDEL, Sluzba.NAM_OF_SLU, Naimen.NAIMENOVAN as upr, Naimen_1.NAIMENOVAN as otdel, Naimen_2.NAIMENOVAN as podotdel, Naimen_3.NAIMENOVAN as otdelenie, Naimen_4.NAIMENOVAN as grup, Naimen_5.NAIMENOVAN as podr " +
                                            " FROM AAQQ, OFIC_DOL, ZVANIE, PODRAZD.DBF Podrazd, SLUZBA.dbf Sluzba, NAIMEN.dbf Naimen, NAIMEN.dbf Naimen_1, NAIMEN.dbf Naimen_2, NAIMEN.dbf Naimen_3, NAIMEN.dbf Naimen_4, NAIMEN.dbf Naimen_5 " +
                                            " WHERE (AAQQ.PODR = Naimen_5.KEY_OF_NAI) AND (AAQQ.OTDEL = Naimen_1.KEY_OF_NAI) AND (AAQQ.PODOTDEL = Naimen_2.KEY_OF_NAI) AND " +
                                            " (AAQQ.OTDELENIE = Naimen_3.KEY_OF_NAI) AND (AAQQ.GRUP = Naimen_4.KEY_OF_NAI) AND AAQQ.UPRAVLENIE = Naimen.KEY_OF_NAI AND AAQQ.SLUZBA = Sluzba.KEY_OF_SLU AND AAQQ.PODRAZD = Podrazd.KEY_OF_POD AND OFIC_DOL.P3 = AAQQ.REAL_DOLZN AND AAQQ.ZVANIE = ZVANIE.KEY_ZVAN AND AAQQ.KEY_1 = " + id;
                dv = (DataView)kDataSource.Select(DataSourceSelectArguments.Empty);

                DataRow r = dv.Table.Rows[0];

                dolz = r["P3"].ToString();

                if ((r["SLUZBA"].ToString() == "9" || r["SLUZBA"].ToString() == "52") && (r["PODRAZD"].ToString() != "1"))
                {
                    cheyPrik.Text = "УВО УМВД РФ по Ивановской области";
                    ovo = true;
                }
                else
                {
                    cheyPrik.Text = "УМВД РФ по Ивановской области";
                    ovo = false;
                }
                
                ZVANIE.Text = r["VOIN_ZVAN"].ToString();
                NAME.Text = r["FAMILIYA"].ToString() + " " + r["IMYA"].ToString() + " " + r["OTCHECTVO"].ToString();


                if ( r["DATA_SOKR"] != DBNull.Value ) DateEdit.Text = Convert.ToDateTime(r["DATA_SOKR"]).ToShortDateString();
                else DateEdit.Text = "";
                               
                PrikEdit.Text = r["NOMPRSOKDO"].ToString();

                string pdr = "";
                if (r["grup"].ToString() != "          - # -") pdr += "группы " + r["grup"].ToString();
                if (r["otdelenie"].ToString() != "          - # -") pdr += " отделения " + r["otdelenie"].ToString();
                if (r["podotdel"].ToString() != "          - # -") pdr += " подотдела " + r["podotdel"].ToString();
                if (r["otdel"].ToString() != "          - # -") pdr += " отдела " + r["otdel"].ToString();
                if (r["upr"].ToString() != "          - # -") pdr += " управление " + r["upr"].ToString();
                if (r["podr"].ToString() != "          - # -") pdr += " " + r["podr"].ToString();
                pdr += " " + r["PODRAZDEL"].ToString();


                DolzEdit.Text = r["NAM_OF_DOL"].ToString() + " " + UK.GlobalTransform.TransformPdrNames(pdr);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string param = "";
            //Response.Write(Convert.ToInt16(dolz.Substring(0,2)) + "\n");
            //Response.Write(dolz);

            if (Convert.ToInt16(dolz.Substring(0, 2)) < 80)
            {
                param += "Uvedom.aspx?id=" + id +
                               "&punkt=" + punktList.SelectedValue +
                               "&zv=" + ZVANIE.Text.ToLower() +
                               "&fio=" + NAME.Text +
                               "&sokrdate=" + DateEdit.Text +
                               "&sokrpr=" + PrikEdit.Text +
                               "&ovo=" + ovo.ToString();
            }
            else
            {
                param += "UvedomVN.aspx?id=" + id +
                               "&fio=" + NAME.Text +
                               "&sokrdate=" + DateEdit.Text +
                               "&sokrpr=" + PrikEdit.Text+
                               "&ovo=" + ovo.ToString();
            }

            if (CheckDol.Checked) param += "&dolz=" + DolzEdit.Text;
            else param += "&dolz=0";

            DataView r = new DataView();
            r = (DataView)nDataSource.Select(DataSourceSelectArguments.Empty);

            if ((int)r.Table.Rows[0]["Expr1"] > 0) nDataSource.Update();
            else nDataSource.Insert();

            Response.Redirect(param);
        }
        
    }
}
