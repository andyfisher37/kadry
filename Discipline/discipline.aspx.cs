using System;
using System.Web.UI;

namespace kadry.Discipline
{
	/// <summary>
	/// Summary description for discipline.
	/// </summary>
    public class discipline : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.DropDownList podrList;
        protected System.Web.UI.WebControls.DropDownList sluzList;
        protected System.Web.UI.WebControls.DropDownList pooList;
        protected System.Web.UI.WebControls.DropDownList nakList;
        protected System.Web.UI.WebControls.RadioButton RadioBtn1;
        protected System.Web.UI.WebControls.RadioButton RadioBtn2;
        protected System.Web.UI.WebControls.CheckBox Check1;
        protected System.Web.UI.WebControls.CheckBox Check2;
        protected System.Data.Odbc.OdbcConnection Connection;
        protected System.Data.Odbc.OdbcCommand Command;
        protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
        protected kadry.podrDataSet podrDataSet;
        protected kadry.sluzDataSet sluzDataSet;
        protected kadry.slvDataSet slvDataSet;
        protected System.Web.UI.WebControls.ImageButton pooBtn;
        protected System.Web.UI.WebControls.ImageButton nakBtn;
        protected System.Web.UI.WebControls.ImageButton statBtn;
        protected eWorld.UI.MaskedTextBox Date1;
        protected eWorld.UI.MaskedTextBox Date2;
        protected System.Web.UI.WebControls.ImageButton nak_sp_btn;
        protected System.Web.UI.WebControls.DropDownList dolzList;
        protected System.Web.UI.WebControls.Label FindLabel;
        protected System.Web.UI.WebControls.ImageButton ImageButton1;
        protected eWorld.UI.MaskedTextBox OVDDate;
        protected System.Web.UI.WebControls.CheckBox OVDCheck;
        protected System.Web.UI.WebControls.DropDownList podchList;
        protected System.Web.UI.WebControls.Label podchLabel;
        protected System.Web.UI.WebControls.SqlDataSource podchDataSource;

        public string TitleText;

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                //kadry.Security.Security s = new kadry.Security.Security();

                //if (!s.CheckSecurePage(User.Identity.Name, "discipline.aspx")) Response.Redirect("\\AccessDenied.htm", true);

                //s.AddLogText("Открытие страницы:[Дисциплина]", Context.Request.UserHostAddress.ToString(), 11, true);

                // Устанавливаем период
                System.DateTime tmp = System.DateTime.Now.Subtract(System.TimeSpan.FromDays(365));
                Date1.Text = tmp.ToShortDateString();

                Date2.Text = System.DateTime.Now.ToShortDateString();

                // Заполняем словари...
                Command.CommandText = "SELECT * FROM PODRAZD.DBF WHERE KEY_OF_POD IN (SELECT PODRAZD FROM AAQQ.DBF) ORDER BY PODRAZDEL ";
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(podrDataSet);
                podrList.DataBind();
                podrList.Items.Add("Все подразделения");
                podrList.Items.FindByText("Все подразделения").Value = "0";
                podrList.Items.FindByText("Все подразделения").Selected = true;

                Command.CommandText = "SELECT * FROM SLUZBA.DBF WHERE KEY_OF_SLU ORDER BY NAM_OF_SLU ";
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(sluzDataSet);
                sluzList.DataBind();
                sluzList.Items.Add("Все службы (кроме ОВО)");
                sluzList.Items.FindByText("Все службы (кроме ОВО)").Value = "-2";
                sluzList.Items.Add("Все заместители начальников ГРУОВД");
                sluzList.Items.FindByText("Все заместители начальников ГРУОВД").Value = "-3";
                sluzList.Items.Add("Все службы");
                sluzList.Items.FindByText("Все службы").Value = "-1";
                sluzList.Items.FindByText("Все службы").Selected = true;

                Command.CommandText = "SELECT * FROM SLVPOO.DBF ORDER BY P1 ";
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(slvDataSet);
                pooList.DataBind();
                pooList.Items.Add("Только государственные награды");
                pooList.Items.FindByText("Только государственные награды").Value = "-1";
                pooList.Items.FindByText("Только государственные награды").Selected = false;
                pooList.Items.Add("Только ведомственные награды и поощрения (МВД)");
                pooList.Items.FindByText("Только ведомственные награды и поощрения (МВД)").Value = "-2";
                pooList.Items.FindByText("Только ведомственные награды и поощрения (МВД)").Selected = false;
                pooList.Items.Add("Все поощрения");
                pooList.Items.FindByText("Все поощрения").Value = "0";
                pooList.Items.FindByText("Все поощрения").Selected = true;

                Command.CommandText = "SELECT * FROM SLVNAK.DBF ORDER BY P1 ";
                DataAdapter.SelectCommand = Command;
                slvDataSet._Table.Clear();
                DataAdapter.Fill(slvDataSet);
                nakList.DataBind();
                nakList.Items.Add("Все взыскания");
                nakList.Items.FindByText("Все взыскания").Value = "0";
                nakList.Items.FindByText("Все взыскания").Selected = true;

                podrList.Style.Add("Width", "432px");
                sluzList.Style.Add("Width", "432px");
                pooList.Style.Add("Width", "432px");
                nakList.Style.Add("Width", "432px");

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
            this.Connection = new System.Data.Odbc.OdbcConnection();
            this.Command = new System.Data.Odbc.OdbcCommand();
            this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
            this.podrDataSet = new kadry.podrDataSet();
            this.sluzDataSet = new kadry.sluzDataSet();
            this.slvDataSet = new kadry.slvDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slvDataSet)).BeginInit();
            // 
            // Connection
            // 
            this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase 5.0;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;Driv" +
                "erId=277";
            // 
            // Command
            // 
            this.Command.Connection = this.Connection;
            // 
            // DataAdapter
            // 
            this.DataAdapter.SelectCommand = this.Command;
            // 
            // podrDataSet
            // 
            this.podrDataSet.DataSetName = "podrDataSet";
            this.podrDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
            // 
            // sluzDataSet
            // 
            this.sluzDataSet.DataSetName = "sluzDataSet";
            this.sluzDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
            // 
            // slvDataSet
            // 
            this.slvDataSet.DataSetName = "slvDataSet";
            this.slvDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
            this.Unload += new System.EventHandler(this.discipline_Unload);
            this.Load += new System.EventHandler(this.Page_Load);
            ((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slvDataSet)).EndInit();

        }
        #endregion


        private void discipline_Unload(object sender, System.EventArgs e)
        {
            Connection.Dispose();
        }

  
        private void nak_sp_btn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("nak_list.aspx");
        }

        private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("BadPoo.aspx");
        }

        protected void podrList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Если выбран аппарат УВД или ГУВД -> показываем подчиненные подразделения...
            if (podrList.SelectedItem.Value == "1")
            {
                podchLabel.Visible = true;
                podchList.Visible = true;
                podchDataSource.SelectCommand = "SELECT NAIMENOVAN, KEY_OF_NAI FROM NAIMEN WHERE KEY_OF_NAI IN (SELECT DISTINCT PODR FROM AAQQ WHERE PODR <> 9 AND PODRAZD = 1) ORDER BY NAIMENOVAN";
                podchDataSource.DataBind();
                podchList.DataBind();
                podchList.Items.Add("Весь аппарат УВД");
                podchList.Items.FindByText("Весь аппарат УВД").Value = "-1";
                podchList.Items.FindByText("Весь аппарат УВД").Selected = true;
            }
            else if (podrList.SelectedItem.Value == "54")
            {
                podchLabel.Visible = true;
                podchList.Visible = true;
                podchDataSource.SelectCommand = "SELECT NAIMENOVAN, KEY_OF_NAI FROM NAIMEN WHERE KEY_OF_NAI IN (SELECT DISTINCT PODR FROM AAQQ WHERE PODR <> 9 AND PODRAZD = 54) ORDER BY NAIMENOVAN";
                podchDataSource.DataBind();
                podchList.DataBind();
                podchList.Items.Add("Весь аппарат ГУВД");
                podchList.Items.FindByText("Весь аппарат ГУВД").Value = "-1";
                podchList.Items.FindByText("Весь аппарат ГУВД").Selected = true;
            }
            else if (podrList.SelectedItem.Value == "583")
            {
                podchLabel.Visible = true;
                podchList.Visible = true;
                podchDataSource.SelectCommand = "SELECT NAIMENOVAN, KEY_OF_NAI FROM NAIMEN WHERE KEY_OF_NAI IN (SELECT DISTINCT PODR FROM AAQQ WHERE PODR <> 9 AND PODRAZD = 583) ORDER BY NAIMENOVAN";
                podchDataSource.DataBind();
                podchList.DataBind();
                podchList.Items.Add("Только аппарат УВД (без подчиненных)");
                podchList.Items.FindByText("Только аппарат УВД (без подчиненных)").Value = "-2";
                podchList.Items.Add("Весь аппарат УМВД по И.О.");
                podchList.Items.FindByText("Весь аппарат УМВД по И.О.").Value = "-1";
                podchList.Items.FindByText("Весь аппарат УМВД по И.О.").Selected = true;
            }
            else if (podrList.SelectedItem.Value == "584")
            {
                podchLabel.Visible = true;
                podchList.Visible = true;
                podchDataSource.SelectCommand = "SELECT NAIMENOVAN, KEY_OF_NAI FROM NAIMEN WHERE KEY_OF_NAI IN (SELECT DISTINCT PODR FROM AAQQ WHERE PODR <> 9 AND PODRAZD = 584) ORDER BY NAIMENOVAN";
                podchDataSource.DataBind();
                podchList.DataBind();
                podchList.Items.Add("Только аппарат УВД (без подчиненных)");
                podchList.Items.FindByText("Только аппарат УВД (без подчиненных)").Value = "-2";
                podchList.Items.Add("Весь аппарат УМВД по г.Иваново");
                podchList.Items.FindByText("Весь аппарат УМВД по г.Иваново").Value = "-1";
                podchList.Items.FindByText("Весь аппарат УМВД по г.Иваново").Selected = true;
            }
            else
            {
                podchLabel.Visible = false;
                podchList.Visible = false;
            }
        }


        protected void pooBtn_Click1(object sender, ImageClickEventArgs e)
        {
            if (Check2.Checked) Command.CommandText = "SELECT DISTINCT(KEY_POO)";
            else Command.CommandText = "SELECT KEY_POO";
            
            Command.CommandText += ", FAMILIYA, IMYA, OTCHECTVO, PODRAZDEL, NAM_OF_SLU, NAM_OF_DOL, Slvpoo.P1, DATA_POO, Poo.NOM_PRIK, Slvpr2.P1, Slvpr2.P2 FROM POO.DBF Poo, ";
            
            if ( RadioBtn1.Checked ) Command.CommandText += " Aaqq.dbf, ";
            else if ( RadioBtn2.Checked ) Command.CommandText += " Archive.dbf, ";

            Command.CommandText += "SLVPOO.DBF Slvpoo, SLVPR2.DBF Slvpr2, PODRAZD.DBF Podrazd, SLUZBA.DBF Sluzba, ofic_dol.DBF Ofic_dol WHERE (Poo.KEY_POO = KEY_1) AND (Poo.TYPE_POO = Slvpoo.P2) AND (Poo.CHEI_PRIK = Slvpr2.P2) AND (PODRAZD = Podrazd.KEY_OF_POD) AND (SLUZBA = Sluzba.KEY_OF_SLU) AND (REAL_DOLZN = Ofic_dol.P3) AND (FAMILIYA <> '') ";

            // Вид поощрения...
            if (pooList.SelectedValue != "0")
            {
                if (pooList.SelectedValue == "-1") // Только гос.награды
                {
                    Command.CommandText += "AND Slvpr2.P2 IN ('4405','4415','4584','4965','4967')";
                }
                else if (pooList.SelectedValue == "-2") // Только вед.награды
                {
                    Command.CommandText += "AND Slvpr2.P2 IN ('0001')";
                }
                else  Command.CommandText += "AND TYPE_POO = \'" + pooList.SelectedValue + "\'";
            }
            // Подразделение...
            if (podrList.SelectedValue != "0")
            {
                Command.CommandText += " AND PODRAZD = " + podrList.SelectedValue;
            }

            // Выбор подчиненного...
            if (podchList.Visible && podchList.SelectedItem.Value != "-1")
            {
                Command.CommandText += " AND PODR = " + podchList.SelectedItem.Value;
            }

            // Выбор категории должностей
            if (dolzList.SelectedValue != "0")
            {
                if (dolzList.SelectedValue == "-1")
                {
                    Command.CommandText += " AND DOLZNOST < '800000'";
                }
                if (dolzList.SelectedValue == "1")
                {
                    Command.CommandText += " AND DOLZNOST < '200000'";
                }
                if (dolzList.SelectedValue == "2")
                {
                    Command.CommandText += " AND DOLZNOST < '500000'";
                }
                if (dolzList.SelectedValue == "3")
                {
                    Command.CommandText += " AND DOLZNOST BETWEEN '500000' AND '800000'";
                }
            }

            // Выбор службы
            // Объединение некоторых глобальных служб...

            int s = Convert.ToInt16(sluzList.SelectedItem.Value);

            switch (s)
            {
                // Все кроме ОВО
                case -1: break;
                // Все кроме ОВО
                case -2: Command.CommandText += " AND SLUZBA NOT IN (9,52)"; break;
                // Все заместители нач.ГРУОВД
                case -3: Command.CommandText += " AND (Ofic_dol.NAM_OF_DOL like 'Заместитель начальника УВД%' or Ofic_dol.NAM_OF_DOL like 'Заместитель начальника ОВД%')"; break;
                // КМ
                case 1: Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) "; break;
                // МОБ
                case 2: Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) "; break;
                // Кадры
                case 4: Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) "; break;
                // Тыл
                case 5: Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) "; break;
                // ОВО
                case 9: Command.CommandText += " AND SLUZBA IN (9,52) "; break;
                // Следствие
                case 10: Command.CommandText += " AND SLUZBA IN (10,59) "; break;
                // ГИБДД
                case 11: Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) "; break;
                // УР
                case 24: Command.CommandText += " AND SLUZBA IN (24,25) "; break;
                // ППС
                case 29: Command.CommandText += " AND SLUZBA IN (29,54) "; break;
                // Приемники
                case 33: Command.CommandText += " AND SLUZBA IN (33,63) "; break;
                // Мед.вытрезв
                case 40: Command.CommandText += " AND SLUZBA IN (40,60) "; break;
                // Конвой
                case 43: Command.CommandText += " AND SLUZBA IN (43,58) "; break;
                // ОМОН
                case 44: Command.CommandText += " AND SLUZBA IN (44,59) "; break;
                // УЦ
                case 78: Command.CommandText += " AND SLUZBA IN (78,64) "; break;
                // УНП
                case 85: Command.CommandText += " AND SLUZBA IN (85,66) "; break;

                default: Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )"; break;
            }

            // Период...
            if (Date1.Text != Date2.Text)
            {
                Command.CommandText += " AND DATA_POO BETWEEN " + Convert.ToDateTime(Date1.Text).ToOADate() +
                    " AND " + Convert.ToDateTime(Date2.Text).ToOADate();
            }

            Command.CommandText += " ORDER BY FAMILIYA, IMYA, OTCHECTVO";
            kadry.Vars.CmdText = Command.CommandText;

            TitleText = "Список сотрудников, имеющих поощрения в период с " + Date1.Text + " по " + Date2.Text;
            TitleText += " (" + podrList.SelectedItem.Text + ", " + sluzList.SelectedItem.Text;
            if (dolzList.SelectedValue != "0") TitleText += ", " + dolzList.SelectedItem.Text;
            if (pooList.SelectedValue != "0") TitleText += ", только " + pooList.SelectedItem.Text;
            TitleText += ")";

            //Response.Write(Command.CommandText);
            Response.Redirect("DetailPoo.aspx?date1=" + Date1.Text + "&date2=" + Date2.Text +
                "&title=" + TitleText +
                "&podr=" + podrList.SelectedValue.ToString() +
                "&sluz=" + sluzList.SelectedValue.ToString() +
                "&poo=" + pooList.SelectedValue.ToString());
        }

        protected void nakBtn_Click1(object sender, ImageClickEventArgs e)
        {
            // Ищем в действующих...
            if (RadioBtn1.Checked)
            {
                Command.CommandText = "SELECT Aaqq.DATA_POST, Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, Podrazd.PODRAZDEL, Sluzba.NAM_OF_SLU, Ofic_dol.NAM_OF_DOL, Slvnak.P1, Nakazan.KEY_1, Nakazan.DAT_NALOZ, Slvpr2.P1, Nakazan.N_PRIK_NAL, Nakazan.SODERZANIE, Nakazan.DAT_SNIAT FROM NAKAZAN.DBF Nakazan, Aaqq.DBF Aaqq, SLVNAK.DBF Slvnak, SLVPR2.DBF Slvpr2, PODRAZD.DBF Podrazd, SLUZBA.DBF Sluzba, ofic_dol.DBF Ofic_dol WHERE (Nakazan.KEY_1 = Aaqq.KEY_1) AND (Nakazan.VID_NAKAZ = Slvnak.P2) AND (Nakazan.WHO_NALOZ = Slvpr2.P2) AND (Aaqq.PODRAZD = Podrazd.KEY_OF_POD) AND (Aaqq.SLUZBA = Sluzba.KEY_OF_SLU) AND (Aaqq.DOLZNOST = Ofic_dol.P3) AND (Aaqq.KEY_1 <> 0) ";

                // Только неснятые взыскания...
                if (Check1.Checked == true)
                {
                    Command.CommandText += " AND DAT_SNIAT IS NULL ";
                }
                // С учетом стажа в ОВД...
                if (OVDCheck.Checked == true)
                {
                    Command.CommandText += " AND DATA_POST >= " + Convert.ToDateTime(OVDDate.Text).ToOADate();
                }
                // Подразделение...
                if (podrList.SelectedValue != "0")
                {
                    Command.CommandText += " AND PODRAZD = " + podrList.SelectedValue;
                }
                // Выбор подчиненного...
                if (podchList.Visible && podchList.SelectedItem.Value != "-1")
                {
                    if (podchList.SelectedItem.Text == "Отдел милиции №1 (Ленинский)")
                    {
                        Command.CommandText += " AND PODR = " + podchList.SelectedItem.Value + " AND PODRAZD = 2 ";
                    } else
                    Command.CommandText += " AND PODR = " + podchList.SelectedItem.Value;
                }
                // Тип взыскания...
                if (nakList.SelectedValue != "0")
                {
                    Command.CommandText += " AND VID_NAKAZ = \'" + nakList.SelectedValue + "\'";
                }

                // Выбор категории должностей
                if (dolzList.SelectedValue != "0")
                {
                    if (dolzList.SelectedValue == "-1")
                    {
                        Command.CommandText += " AND DOLZNOST < '800000'";
                    }
                    if (dolzList.SelectedValue == "1")
                    {
                        Command.CommandText += " AND DOLZNOST < '200000'";
                    }
                    if (dolzList.SelectedValue == "2")
                    {
                        Command.CommandText += " AND DOLZNOST < '500000'";
                    }
                    if (dolzList.SelectedValue == "3")
                    {
                        Command.CommandText += " AND DOLZNOST BETWEEN '500000' AND '800000'";
                    }
                }

                // Выбор службы
                // Объединение некоторых глобальных служб...

                int s = Convert.ToInt16(sluzList.SelectedItem.Value);

                switch (s)
                {
                    // Все кроме ОВО
                    case -1: break;
                    // Все кроме ОВО
                    case -2: Command.CommandText += " AND SLUZBA NOT IN (9,52)"; break;
                    // Все заместители нач.ГРУОВД
                    case -3: Command.CommandText += " AND (Ofic_dol.NAM_OF_DOL like 'Заместитель начальника УВД%' or Ofic_dol.NAM_OF_DOL like 'Заместитель начальника ОВД%')"; break;
                    // КМ
                    case 1: Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) "; break;
                    // МОБ
                    case 2: Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) "; break;
                    // Кадры
                    case 4: Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) "; break;
                    // Тыл
                    case 5: Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) "; break;
                    // ОВО
                    case 9: Command.CommandText += " AND SLUZBA IN (9,52) "; break;
                    // Следствие
                    case 10: Command.CommandText += " AND SLUZBA IN (10,55) "; break;
                    // ГИБДД
                    case 11: Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) "; break;
                    // УР
                    case 24: Command.CommandText += " AND SLUZBA IN (24,25) "; break;
                    // ППС
                    case 29: Command.CommandText += " AND SLUZBA IN (29,54) "; break;
                    // Приемники
                    case 33: Command.CommandText += " AND SLUZBA IN (33,63) "; break;
                    // Мед.вытрезв
                    case 40: Command.CommandText += " AND SLUZBA IN (40,60) "; break;
                    // Конвой
                    case 43: Command.CommandText += " AND SLUZBA IN (43,58) "; break;
                    // ОМОН
                    case 44: Command.CommandText += " AND SLUZBA IN (44,59) "; break;
                    // УЦ
                    case 78: Command.CommandText += " AND SLUZBA IN (78,64) "; break;
                    // УНП
                    case 85: Command.CommandText += " AND SLUZBA IN (85,66) "; break;

                    default: Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )"; break;
                }

                // Период...
                if (Date1.Text != Date2.Text)
                {
                    Command.CommandText += " AND DAT_NALOZ BETWEEN " + Convert.ToDateTime(Date1.Text).ToOADate() +
                        " AND " + Convert.ToDateTime(Date2.Text).ToOADate();
                }

                Command.CommandText += " ORDER BY FAMILIYA, IMYA, OTCHECTVO";

                //this.Page.Response.Write(Command.CommandText);

                kadry.Vars.CmdText = Command.CommandText;

                TitleText = "Список действующих сотрудников, имеющих взыскания в период с " + Date1.Text + " по " + Date2.Text;
                TitleText += " (" + podrList.SelectedItem.Text + ", " + sluzList.SelectedItem.Text;
                if (dolzList.SelectedValue != "0") TitleText += ", " + dolzList.SelectedItem.Text;
                if (Check1.Checked == true) TitleText += ", только неснятые";
                if (nakList.SelectedValue != "0") TitleText += ", только " + nakList.SelectedItem.Text;
                if (OVDCheck.Checked) TitleText += ", по стажу в ОВД с " + OVDDate.Text;
                TitleText += ")";

                Response.Redirect("DetailNak.aspx?date1=" + Date1.Text +
                    "&date2=" + Date2.Text +
                    "&sn=" + Check1.Checked.ToString() + // Только неснятые
                    "&title=" + TitleText +
                    "&podr=" + podrList.SelectedValue.ToString() +
                    "&sluz=" + sluzList.SelectedValue.ToString() +
                    "&nakaz=" + nakList.SelectedValue.ToString() +
                    "&ovddate=" + OVDCheck.Checked.ToString());

            }

            // Ищем в уволенных...
            if (RadioBtn2.Checked)
            {
                Command.CommandText = "SELECT Archive.KEY_1, Archive.FAMILIYA, Archive.IMYA, Archive.OTCHECTVO, " +
                    "Podrazd.PODRAZDEL, Sluzba.NAM_OF_SLU, Ofic_dol.NAM_OF_DOL, Slvnak.P1, " +
                    "Nakazan.DAT_NALOZ, Slvpr2.P1, Nakazan.KEY_1, Nakazan.N_PRIK_NAL, Nakazan.SODERZANIE, Nakazan.DAT_SNIAT " +
                    "FROM NAKAZAN.DBF Nakazan, Archive.DBF Archive, SLVNAK.DBF Slvnak, SLVPR2.DBF Slvpr2, PODRAZD.DBF Podrazd, SLUZBA.DBF Sluzba, ofic_dol.DBF Ofic_dol " +
                    "WHERE (Nakazan.KEY_1 = Archive.KEY_1) AND " +
                    "(Nakazan.VID_NAKAZ = Slvnak.P2) AND " +
                    "(Nakazan.WHO_NALOZ = Slvpr2.P2) AND " +
                    "(Archive.PODRAZD = Podrazd.KEY_OF_POD) AND " +
                    "(Archive.SLUZBA = Sluzba.KEY_OF_SLU) AND " +
                    "(Archive.DOLZNOST = Ofic_dol.P3) AND " +
                    "(Archive.KEY_1 <> 0) ";

                // Только неснятые взыскания...
                if (Check1.Checked == true)
                {
                    Command.CommandText += " AND DAT_SNIAT IS NULL ";
                }
                // Подразделение...
                if (podrList.SelectedValue != "0")
                {
                    Command.CommandText += " AND PODRAZD = " + podrList.SelectedValue;
                }
                // Тип взыскания...
                if (nakList.SelectedValue != "0")
                {
                    Command.CommandText += " AND VID_NAKAZ = \'" + nakList.SelectedValue + "\'";
                }

                // Выбор категории должностей
                if (dolzList.SelectedValue != "0")
                {
                    if (dolzList.SelectedValue == "-1")
                    {
                        Command.CommandText += " AND DOLZNOST < '800000'";
                    }
                    if (dolzList.SelectedValue == "1")
                    {
                        Command.CommandText += " AND DOLZNOST < '200000'";
                    }
                    if (dolzList.SelectedValue == "2")
                    {
                        Command.CommandText += " AND DOLZNOST < '500000'";
                    }
                    if (dolzList.SelectedValue == "3")
                    {
                        Command.CommandText += " AND DOLZNOST BETWEEN '500000' AND '800000'";
                    }
                }

                // Выбор службы
                // Объединение некоторых глобальных служб...

                int s = Convert.ToInt16(sluzList.SelectedItem.Value);

                switch (s)
                {
                    // Все кроме ОВО
                    case -1: break;
                    // Все кроме ОВО
                    case -2: Command.CommandText += " AND SLUZBA NOT IN (9,52)"; break;
                    // Все заместители нач.ГРУОВД
                    case -3: Command.CommandText += " AND (Ofic_dol.NAM_OF_DOL like 'Заместитель начальника УВД%' or Ofic_dol.NAM_OF_DOL like 'Заместитель начальника ОВД%')"; break;
                    // КМ
                    case 1: Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) "; break;
                    // МОБ
                    case 2: Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) "; break;
                    // Кадры
                    case 4: Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) "; break;
                    // Тыл
                    case 5: Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) "; break;
                    // ОВО
                    case 9: Command.CommandText += " AND SLUZBA IN (9,52) "; break;
                    // Следствие
                    case 10: Command.CommandText += " AND SLUZBA IN (10,59) "; break;
                    // ГИБДД
                    case 11: Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) "; break;
                    // УР
                    case 24: Command.CommandText += " AND SLUZBA IN (24,25) "; break;
                    // ППС
                    case 29: Command.CommandText += " AND SLUZBA IN (29,54) "; break;
                    // Приемники
                    case 33: Command.CommandText += " AND SLUZBA IN (33,63) "; break;
                    // Мед.вытрезв
                    case 40: Command.CommandText += " AND SLUZBA IN (40,60) "; break;
                    // Конвой
                    case 43: Command.CommandText += " AND SLUZBA IN (43,58) "; break;
                    // ОМОН
                    case 44: Command.CommandText += " AND SLUZBA IN (44,59) "; break;
                    // УЦ
                    case 78: Command.CommandText += " AND SLUZBA IN (78,64) "; break;
                    // УНП
                    case 85: Command.CommandText += " AND SLUZBA IN (85,66) "; break;

                    default: Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )"; break;
                }

                // Период...
                if (Date1.Text != Date2.Text)
                {
                    Command.CommandText += " AND DAT_NALOZ BETWEEN " + Convert.ToDateTime(Date1.Text).ToOADate() +
                        " AND " + Convert.ToDateTime(Date2.Text).ToOADate();
                }

                Command.CommandText += " ORDER BY FAMILIYA";
                kadry.Vars.CmdText = Command.CommandText;

                TitleText = "Список уволенных сотрудников, имеющих взыскания в период с " + Date1.Text + " по " + Date2.Text;
                TitleText += " (" + podrList.SelectedItem.Text + ", " + sluzList.SelectedItem.Text;
                if (dolzList.SelectedValue != "0") TitleText += ", " + dolzList.SelectedItem.Text;
                if (Check1.Checked == true) TitleText += ", только неснятые";
                if (nakList.SelectedValue != "0") TitleText += ", только " + nakList.SelectedItem.Text;
                TitleText += ")";

                Response.Redirect("DetailNak.aspx?date1=" + Date1.Text +
                    "&date2=" + Date2.Text +
                    "&title=" + TitleText +
                    "&sn=" + Convert.ToString(Check1.Checked) +
                    "&podr=" + Convert.ToString(podrList.SelectedValue) +
                    "&sluz=" + Convert.ToString(sluzList.SelectedValue) +
                    "&nakaz=" + Convert.ToString(nakList.SelectedValue));

            }
        }

        protected void statBtn_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Disc_stat.aspx");
        }
    }
}
