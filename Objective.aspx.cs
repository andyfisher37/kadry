using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;


namespace UK
{
	/// <summary>
	/// Summary description for Objective.
	///
	/// </summary>
	public partial class Objective : System.Web.UI.Page
	{
		int id;
		protected System.Data.Odbc.OdbcConnection Conn;
		protected System.Data.Odbc.OdbcCommand selectCmd1;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected UK.viewDataSet viewDataSet;
		protected UK.tmpDataSet tmpDataSet;
		protected System.Web.UI.WebControls.DataGrid grGrid;
		protected System.Web.UI.WebControls.DataGrid pGrid;
		public static System.Data.DataRowCollection rc;
		protected System.Data.SqlClient.SqlCommand AddLogsCmd;

		public struct WorkStage
		{
			public string date1;
			public string date2;
			public string legend;
		}

		public string f_name;
		public string name;
		protected System.Data.SqlClient.SqlConnection LogsConn;
		public string s_name;
			
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                Security.Security s = new Security.Security();

                string LogText = "";
                string curIP = Convert.ToString(Context.Request.UserHostAddress);
                string sbase = "";
                                
                // �������� ���� ��������...
                id = Convert.ToInt16(Request.Params["id"]);

                // �������� �� ����� �������...
                if (!s.CheckSecurePage(User.Identity.Name, "objective.aspx")) Response.Redirect("AccessDenied.htm", true);
                if (!s.CheckSecureKey(User.Identity.Name, id)) Response.Redirect("AccessDenied.htm", true);

                // � ����� ���� ������...
                viewDataSet.Clear();
                selectCmd1.CommandText = "SELECT KEY_1 FROM AAQQ.DBF WHERE KEY_1 = " + id;
                DataAdapter.SelectCommand = selectCmd1;
                DataAdapter.Fill(viewDataSet);
                if (viewDataSet.Tables[0].Rows.Count > 0) sbase = "AAQQ.DBF";
                else
                {
                    viewDataSet.Clear();
                    selectCmd1.CommandText = "SELECT KEY_1 FROM ARCHIVE.DBF WHERE KEY_1 = " + id;
                    DataAdapter.SelectCommand = selectCmd1;
                    DataAdapter.Fill(viewDataSet);
                    if (viewDataSet.Tables[0].Rows.Count > 0) sbase = "ARCHIVE.DBF";
                    else
                    {
                        viewDataSet.Clear();
                        selectCmd1.CommandText = "SELECT KEY_1 FROM VYEZD.DBF WHERE KEY_1 = " + id;
                        DataAdapter.SelectCommand = selectCmd1;
                        DataAdapter.Fill(viewDataSet);
                        if (viewDataSet.Tables[0].Rows.Count > 0) sbase = "VYEZD.DBF";
                        else
                        {
                            viewDataSet.Clear();
                            selectCmd1.CommandText = "SELECT KEY_1 FROM RESERV.DBF WHERE KEY_1 = " + id;
                            DataAdapter.SelectCommand = selectCmd1;
                            DataAdapter.Fill(viewDataSet);
                            if (viewDataSet.Tables[0].Rows.Count > 0) sbase = "RESERV.DBF";
                        }
                    }
                }

                // �������� ��������
                selectCmd1.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, OBRAZ_LIC1, DAT_OKUZ, NACIONALN, ZVANIE " +
                    " FROM " + sbase + " WHERE KEY_1 = " + id;

                viewDataSet.Clear();
                DataAdapter.SelectCommand = selectCmd1;
                DataAdapter.Fill(viewDataSet);
                rc = viewDataSet.Tables[0].Rows;

                f_name = Convert.ToString(rc[0]["FAMILIYA"]);
                name = Convert.ToString(rc[0]["IMYA"]);
                s_name = Convert.ToString(rc[0]["OTCHECTVO"]);

                Response.AddHeader("Content-Disposition", "attachment;inline; filename=" + f_name + "_" + name + "_" + s_name + ".doc");
                Response.ContentType = "application/msword";

                LogText += f_name + "|" + name + "|" + s_name;

                text_fio.Text = f_name + " " + name + " " + s_name;

                string born_date = Fn.D2STR(rc[0]["DATA_ROZD"]);

                text_borndate.Text = born_date;

                string obr_type = Convert.ToString(rc[0]["OBRAZ_LIC1"]);

                text_typeobr.Text = obr_type;

                string dat_okuz = Convert.ToString(rc[0]["DAT_OKUZ"]);

                string dateUCH = ", � " + Convert.ToString(rc[0]["DAT_OKUZ"]) + " �.,";

                int nac = Convert.ToInt16(rc[0]["NACIONALN"]);

                selectCmd1.CommandText = "SELECT STATUS FROM FAMILY WHERE (STATUS = 1) AND (KEY_1 = " + id.ToString() + ")";
                if (Conn.State != ConnectionState.Open) Conn.Open();
                int res = Convert.ToInt16(selectCmd1.ExecuteScalar());

                if (res == 1)
                {
                    if (nac < 51) text_family.Text = "�����";
                    else text_family.Text = "�������";
                }
                else
                {
                    if (nac < 51) text_family.Text = "������";
                    else text_family.Text = "�� �������";
                }

                text_lang.Text = " - ";
                
                text_sport.Text = " - ";

                int zvan_code = Convert.ToInt16(rc[0]["ZVANIE"]);
                
                //���� ������...
                if ((zvan_code >= 27 && zvan_code <= 35) || (zvan_code >= 47 && zvan_code <= 55) || (zvan_code >= 67 && zvan_code <= 75) || (zvan_code >= 107 && zvan_code <= 114))
                {
                    // ������ ������ (1-� � ���������)
                    tmpDataSet.Dispose();
                    rc.Clear();
                    selectCmd1.CommandText = "SELECT VOIN_ZVAN, DATA_PRIK, NOM_PRIK, P1 FROM PERSZVAN, ZVANIE, SLVPR2 WHERE OVD_PRIK = P2 AND ZVANIE = KEY_ZVAN AND ZVANIE IN (27,28,29,30,31,32,33,34,35,47,48,49,50,51,52,53,54,55,67,68,69,70,71,72,73,74,75,107,108,109,110,111,112,113,114) AND KEY_1 = " + id + " ORDER BY DATA_PRIK";
                    DataAdapter.SelectCommand = selectCmd1;
                    DataAdapter.Fill(tmpDataSet);
                    rc = tmpDataSet._Table.Rows;
                    if (rc.Count != 0)
                    {
                        text_zvan.Text = "1. " + rc[rc.Count - 1]["VOIN_ZVAN"].ToString() + ", ��. " + rc[rc.Count - 1]["P1"].ToString() + " �� " + Convert.ToDateTime(rc[rc.Count - 1]["DATA_PRIK"].ToString()).ToShortDateString() + " � " + rc[rc.Count - 1]["NOM_PRIK"].ToString() + " �/�; <br>";
                        text_zvan.Text += "2. " + rc[0]["VOIN_ZVAN"].ToString() + ", ��. " + rc[0]["P1"].ToString() + " �� " + Convert.ToDateTime(rc[0]["DATA_PRIK"].ToString()).ToShortDateString() + " � " + rc[0]["NOM_PRIK"].ToString() + " �/�;";
                    }
                }
                else // �������
                {
                    // ������� ������
                    tmpDataSet.Dispose();
                    rc.Clear();
                    selectCmd1.CommandText = "SELECT VOIN_ZVAN FROM ZVANIE.DBF WHERE KEY_ZVAN = " + zvan_code.ToString();
                    DataAdapter.SelectCommand = selectCmd1;
                    DataAdapter.Fill(tmpDataSet);
                    rc = tmpDataSet._Table.Rows;
                    if (rc.Count != 0) text_zvan.Text = rc[0]["VOIN_ZVAN"].ToString();
                }

                // ����� ��������
                tmpDataSet.Dispose();
                rc.Clear();
                selectCmd1.CommandText = "SELECT P1 FROM SLVMR.DBF, " + sbase + " WHERE KEY_1 = " + id + " AND M_ROZ = P2";
                DataAdapter.SelectCommand = selectCmd1;
                DataAdapter.Fill(tmpDataSet);
                rc = tmpDataSet._Table.Rows;
                if (rc.Count != 0) { text_bornplace.Text = Convert.ToString(rc[0]["P1"]); }

                // ��������������
                tmpDataSet.Dispose();
                rc.Clear();
                selectCmd1.CommandText = "SELECT NACION FROM NACIONAL.DBF, " + sbase + " WHERE NACIONALN = KEY_OF_NAC AND KEY_1 = " + id;
                DataAdapter.SelectCommand = selectCmd1;
                DataAdapter.Fill(tmpDataSet);
                rc = tmpDataSet._Table.Rows;
                if (rc.Count != 0) { text_nation.Text = Convert.ToString(rc[0]["NACION"]); }

                // ������� ����������� 
                tmpDataSet.Dispose();
                rc.Clear();
                selectCmd1.CommandText = "SELECT P1 FROM SLVLE2.DBF, " + sbase + " WHERE OBRAZ_LIC2 = P2 AND KEY_1 = " + id;
                DataAdapter.SelectCommand = selectCmd1;
                DataAdapter.Fill(tmpDataSet);
                rc = tmpDataSet._Table.Rows;
                if (rc.Count != 0) 
                { 
                    text_typeobr.Text = Convert.ToString(rc[0]["P1"]);
                    if (text_typeobr.Text == "����.����.") text_typeobr.Text = "������� �����������"; 
                }

                // ������� ���������
                selectCmd1.CommandText = "SELECT COUNT(*) FROM LEARN.DBF WHERE KEY_1 = " + id;
                if (Conn.State != ConnectionState.Open) Conn.Open();
                int cnt = (int)selectCmd1.ExecuteScalar();
                if (cnt > 0) // ���� ���� ������ � LEARN
                {
                    tmpDataSet.Dispose();
                    rc.Clear();
                    selectCmd1.CommandText = "SELECT SLVLE2.P1 AS L_VID, TYPE, SLVUCZ.P1 AS UCZ, YEAR, SLVKVA.P1 AS SPEC, KVALIFIK FROM LEARN, SLVLE2, SLVUCZ, SLVKVA WHERE VID = SLVLE2.P2 AND UCH_ZAV = SLVUCZ.P2 AND SPECALNOST = SLVKVA.P2 AND STATUS = 1 AND KEY_1 = " + id + " ORDER BY YEAR";
                    DataAdapter.SelectCommand = selectCmd1;
                    DataAdapter.Fill(tmpDataSet);
                    rc = tmpDataSet._Table.Rows;
                    for (int i = 0; i < rc.Count; i++)
                    {
                        text_uchzav.Text += rc[i]["UCZ"].ToString() + " � " + rc[i]["YEAR"].ToString() + " �., �������������: " + rc[i]["SPEC"].ToString().ToLower() + ", ������������: " + rc[i]["KVALIFIK"].ToString().ToLower() + "<br>";
                    }
                }
                else
                {
                    // ������� ���������
                    tmpDataSet.Dispose();
                    rc.Clear();
                    selectCmd1.CommandText = "SELECT P1 FROM SLVUCZ.DBF, " + sbase + " WHERE UCHZAV = P2 AND KEY_1 = " + id;
                    DataAdapter.SelectCommand = selectCmd1;
                    DataAdapter.Fill(tmpDataSet);
                    rc = tmpDataSet._Table.Rows;
                    if (rc.Count != 0) { text_uchzav.Text = Convert.ToString(rc[0]["P1"]); }

                    text_uchzav.Text += dateUCH;

                    // �������������
                    tmpDataSet.Dispose();
                    rc.Clear();
                    selectCmd1.CommandText = "SELECT P1 FROM SLVKVA.DBF, " + sbase + " WHERE OBRAZ_LIC3 = P2 AND KEY_1 = " + id;
                    DataAdapter.SelectCommand = selectCmd1;
                    DataAdapter.Fill(tmpDataSet);
                    rc = tmpDataSet._Table.Rows;
                    if (rc.Count != 0) { text_uchzav.Text += " �������������: " + Convert.ToString(rc[0]["P1"]).ToLower(); }
                }

                // ������ �������
                if (sbase != "VYEZD.DBF" && sbase != "RESERV.DBF")
                {
                    tmpDataSet.Dispose();
                    rc.Clear();
                    selectCmd1.CommandText = "SELECT UCH_STEP FROM " + sbase + " WHERE KEY_1 = " + id;
                    DataAdapter.SelectCommand = selectCmd1;
                    DataAdapter.Fill(tmpDataSet);
                    rc = tmpDataSet._Table.Rows;
                    if (rc.Count != 0)
                    {
                        if (rc[0]["UCH_STEP"].ToString() == "1") text_uchst.Text = "������ ����";
                        else if (rc[0]["UCH_STEP"].ToString() == "2") text_uchst.Text = "�������� ����";
                        else text_uchst.Text = " - ";
                    }
                }

                // ������ ������� ������
                tmpDataSet.Dispose();
                rc.Clear();
                selectCmd1.CommandText = "SELECT DATE_FROM, DATE_TO FROM LGOTTIME.DBF WHERE OVD_PRIK NOT IN ('4736','4517') AND MAIN_KEY = " + id;
                DataAdapter.SelectCommand = selectCmd1;
                DataAdapter.Fill(tmpDataSet);
                rc = tmpDataSet._Table.Rows;

                if (rc.Count != 0)
                {
                    for (int i = 0; i < rc.Count; i++)
                    {
                        text_komand.Text += " c " + Convert.ToDateTime(rc[i]["DATE_FROM"]).ToShortDateString() +
                            " �� " + Convert.ToDateTime(rc[i]["DATE_TO"]).ToShortDateString();
                        if (i < rc.Count - 1) text_komand.Text += ";<br>";
                    }
                }

                // ���.�������
                tmpDataSet.Dispose();
                rc.Clear();
                selectCmd1.CommandText = "SELECT S1.P1, PRICHINA, S2.P1, NOM_PRIK, DATA_POO FROM POO.DBF, SLVPOO.DBF S1, SLVPR2.DBF S2 WHERE (TYPE_POO = S1.P2) AND (CHEI_PRIK = S2.P2) AND (S2.P2 IN ('4405','4415','4584','4965','4967')) AND KEY_POO = " + id + " ORDER BY DATA_POO";
                DataAdapter.SelectCommand = selectCmd1;
                DataAdapter.Fill(tmpDataSet);
                rc = tmpDataSet._Table.Rows;

                if (rc.Count != 0)
                {
                    for (int i = 0; i <= rc.Count - 1; i++)
                    {
                        text_nagr.Text += Convert.ToString(rc[i]["P1"]) + "; ";
                    }
                }
                else text_nagr.Text = " - ";


                ArrayList stage = new ArrayList();
                

                // ������ � ��
                tmpDataSet.Dispose();
                rc.Clear();
                selectCmd1.CommandText = "SELECT ARMY_BEGIN, ARMY_STOP, SOSTAV, VUS, WAR, GODEN, VOENKOMAT, VBILET, BILET_DATE, BILET_RVK, VOIN_ZVAN FROM VUCHET.DBF, ZVANIE.DBF WHERE ZVANIE = KEY_ZVAN AND KEY_1 = " + id;
                DataAdapter.SelectCommand = selectCmd1;
                DataAdapter.Fill(tmpDataSet);
                rc = tmpDataSet._Table.Rows;
                if (rc.Count != 0)
                {
                    for (int i = 0; i < rc.Count; i++)
                    {
                        WorkStage tmp = new WorkStage();
                        if (rc[i]["ARMY_BEGIN"] != System.DBNull.Value) tmp.date1 = Convert.ToDateTime(rc[i]["ARMY_BEGIN"]).ToShortDateString();
                        else break;
                        if (rc[i]["ARMY_STOP"] != System.DBNull.Value) tmp.date2 = Convert.ToDateTime(rc[i]["ARMY_STOP"]).ToShortDateString();
                        else break;
                        tmp.legend = "������ � ��";
                        stage.Add(tmp);
                       
                    }

                }
                // ����������� ����
                tmpDataSet.Dispose();
                rc.Clear();
                selectCmd1.CommandText = "select date_from, date_to, firm_dolzn, firma from grazdank.dbf where main_key = " + id;
                DataAdapter.SelectCommand = selectCmd1;
                DataAdapter.Fill(tmpDataSet);
                rc = tmpDataSet._Table.Rows;

                if (rc.Count != 0)
                {
                    for (int i = 0; i < rc.Count; i++)
                    {
                        WorkStage tmp = new WorkStage();

                        if (rc[i]["DATE_FROM"] != DBNull.Value) tmp.date1 = Convert.ToDateTime(rc[i]["DATE_FROM"]).ToShortDateString();
                        else tmp.date1 = "";
                        if (rc[i]["DATE_TO"] != DBNull.Value) tmp.date2 = Convert.ToDateTime(rc[i]["DATE_TO"]).ToShortDateString();
                        else tmp.date2 = "";
                        tmp.legend = Convert.ToString(rc[i]["firm_dolzn"]) + " - " + Convert.ToString(rc[i]["firma"]);

                        stage.Add(tmp);
                        
                    }
                }

                // ���������...
                tmpDataSet.Dispose();
                rc.Clear();
                selectCmd1.CommandText = "SELECT POSL.*, VOIN_ZVAN, D.NAM_OF_DOL, " +
                    "Pdr.PODRAZDEL, N1.NAIMENOVAN AS n_upr, N2.NAIMENOVAN AS n_otdel, N3.NAIMENOVAN AS n_podotdel, N4.NAIMENOVAN AS n_otdelenie, " +
                    "N5.NAIMENOVAN AS n_grup, N6.NAIMENOVAN AS n_podch " +
                    "FROM POSL_SPI.DBF POSL, PODRAZD.DBF Pdr, NAIMEN.DBF N1, NAIMEN.DBF N2, " +
                    "NAIMEN.DBF N3, NAIMEN.DBF N4, NAIMEN.DBF N5, NAIMEN.DBF N6, ZVANIE.DBF, " +
                    "OFIC_DOL.DBF D, SLVPR2.DBF S1 " +
                    "WHERE (PODR = N6.KEY_OF_NAI) AND (GRUP = N5.KEY_OF_NAI) " +
                    "AND (OTDELENIE = N4.KEY_OF_NAI) AND (PODOTDEL = N3.KEY_OF_NAI) " +
                    "AND (OTDEL = N2.KEY_OF_NAI) AND (UPRAVLENIE = N1.KEY_OF_NAI) " +
                    "AND (PODRAZD = KEY_OF_POD) AND (ZVANIE = KEY_ZVAN) " +
                    "AND (DOLZNOST = D.P3) AND (CHEI_PRIK = S1.P2) AND (KEY_POSL = " + id + ") ORDER BY DATA_OT";
                DataAdapter.SelectCommand = selectCmd1;
                DataAdapter.Fill(tmpDataSet);
                rc = tmpDataSet.Tables[0].Rows;

                #region work
                //if (rc.Count > 0)
                //{
                //    string pdr = ""; // �������������

                //    for (int i = 0; i <= rc.Count; i++)
                //    {
                //        // ����� ������ � �������� �����...
                //        WorkStage tmp = new WorkStage();

                //        // ������������ �������� �������������
                //        pdr = GetPodrName(rc, i);

                //        // ���� ���� ������ ������� �� ������ - �������
                //        if (rc[i]["DATA_OT"] != DBNull.Value) tmp.date1 = Convert.ToDateTime(rc[i]["DATA_OT"]).ToShortDateString();
                //        else tmp.date1 = "";

                //        // ���� �� ��������� ������ � ��������� - ������� ���� ��������� ������� (��� �� ���� ������ ����.�������)
                //        if (i < rc.Count)
                //        {
                //            if (rc[i + 1]["DATA_OT"] != DBNull.Value) tmp.date2 = Convert.ToDateTime(rc[i + 1]["DATA_OT"]).ToShortDateString();
                //            else tmp.date2 = "";
                //        }
                //        else // ���� ��������� ������
                //        {
                //            // ���� ��������� �� ����������
                //            if (rc[i]["STATUS"].ToString() != "4000") tmp.date2 = "�� �/�����";
                //        }
                    
                //        // ���� ������
                //        if (Convert.ToInt16(rc[i]["ZVANIE"]) == 99) tmp.legend += "������ - ";

                //        tmp.legend += Convert.ToString(rc[i]["NAM_OF_DOL"]) + " - " + pdr;
                //        stage.Add(tmp);
                        
                //    }
                    
                //    text_podr.Text = GetPodrName2(rc, rc.Count);
                //    text_dolz.Text = Convert.ToString(rc[rc.Count]["NAM_OF_DOL"]);
                #endregion

                    #region backup

                if (rc.Count != 0)
                {
                    string pdr; // �������������

                    int i = 0;

                    do
                    {
                        WorkStage tmp = new WorkStage();

                        pdr = GetPodrName(rc[i]);

                        if (rc[i]["STATUS"].ToString() == "4000")
                        {
                            pdr = GetPodrName(rc[i]);
                            //i++;
                        }

                        if (rc[i]["DATA_OT"] != DBNull.Value) tmp.date1 = Convert.ToDateTime(rc[i]["DATA_OT"]).ToShortDateString();
                        else tmp.date1 = "";

                        if (i < rc.Count - 1)
                        {
                            if (rc[i + 1]["DATA_OT"] != DBNull.Value) tmp.date2 = Convert.ToDateTime(rc[i + 1]["DATA_OT"]).ToShortDateString();
                            else tmp.date2 = "";
                        }
                        else if (rc[i]["STATUS"].ToString() == "4000")
                        {
                            tmp.date2 = "������";
                        }
                        else
                        {
                            tmp.date2 = "�� �/�����";
                        }

                        text_podr.Text = GetPodrName2(rc[i]);
                        text_dolz.Text = Convert.ToString(rc[i]["NAM_OF_DOL"]);

                        // ���� ������
                        if (Convert.ToInt16(rc[i]["ZVANIE"]) == 99) tmp.legend += "������ - ";

                        tmp.legend += Convert.ToString(rc[i]["NAM_OF_DOL"]) + " - " + pdr;
                        stage.Add(tmp);
                        i++;

                    } while (i < rc.Count);
#endregion

                    // ����� � ��������...

                    foreach (WorkStage item in stage)
                    {
                        TableRow r = new TableRow();

                        TableCell c1 = new TableCell();
                        c1.Text = Convert.ToDateTime(item.date1).ToShortDateString();
                        c1.HorizontalAlign = HorizontalAlign.Center;
                        r.Cells.Add(c1);

                        TableCell c2 = new TableCell();
                        c2.Text = item.date2;
                        c1.HorizontalAlign = HorizontalAlign.Center;
                        r.Cells.Add(c2);

                        TableCell c3 = new TableCell();
                        c3.Text = item.legend;
                        r.Cells.Add(c3);

                        PTable.Rows.Add(r);
                    }

                }

                string[] months = new string[] { " ", "������", "�������", "�����", "������", "���", "����", "����", "�������", "��������", "�������", "������", "�������" };

                now_date.Text = "\"" + DateTime.Now.Day + "\" " + months[DateTime.Now.Month] + " " + DateTime.Now.Year + " �.";

                s.AddLogText("�������� �������-����������:" + LogText, Context.Request.UserHostAddress.ToString(), 7, true);

            }

			
		}

		public string GetPodrName( System.Data.DataRow c )
		{
			string pdr = "";

            if (c["GRUP"].ToString() != "9")
            {
                if (c["n_grup"].ToString().ToLower().IndexOf("������", 0) == -1) pdr += "������ " + c["n_grup"].ToString().ToLower();
                else pdr += c["n_grup"].ToString().ToLower();
            }
            if (c["OTDELENIE"].ToString() != "9")
            {
                if (c["n_otdelenie"].ToString().ToLower().IndexOf("���������", 0) == -1) pdr += " ��������� " + c["n_otdelenie"].ToString().ToLower();
                else pdr += c["n_otdelenie"].ToString().ToLower();
            }
            if (c["PODOTDEL"].ToString() != "9")
            {
                if (c["n_podotdel"].ToString().ToLower().IndexOf("���������", 0) == -1) pdr += " ��������� " + c["n_podotdel"].ToString().ToLower();
                else pdr += c["n_podotdel"].ToString().ToLower();
            }
            if (c["OTDEL"].ToString() != "9")
            {
                if (c["n_otdel"].ToString().ToLower().IndexOf("�����", 0) == -1) pdr += " ������ " + c["n_otdel"].ToString().ToLower();
                else pdr += c["n_otdel"].ToString().ToLower();
            }
            if (c["UPRAVLENIE"].ToString() != "9")
            {
                if (c["n_upr"].ToString().ToLower().IndexOf("����������") == -1) pdr += " ���������� " + c["n_upr"].ToString().ToLower();
                else pdr += c["n_upr"].ToString().ToLower();
            }
            if (c["PODR"].ToString() != "9") pdr += " " + c["n_podch"].ToString();
            pdr += " " + c["PODRAZDEL"].ToString();
            pdr.Replace("���", "����");
			

			return pdr;
		}
		
		public string GetPodrName2( System.Data.DataRow c )
		{
			string pdr = "";

			//if (c[j]["GRUP"].ToString() != "9" )		pdr += "������ " + c[j]["n_grup"].ToString();
			//if (c[j]["OTDELENIE"].ToString() != "9" )	pdr += " ��������� " + c[j]["n_otdelenie"].ToString();
			//if (c[j]["PODOTDEL"].ToString() != "9" )	pdr += " ��������� " + c[j]["n_podotdel"].ToString();
			//if (c[j]["OTDEL"].ToString() != "9" )		pdr += " ������ " + c[j]["n_otdel"].ToString();
			if (c["UPRAVLENIE"].ToString() != "9" )
			{
				if ( c["n_upr"].ToString().ToLower().IndexOf("����������") == -1 ) pdr += " ���������� " + c["n_upr"].ToString().ToLower();
				else pdr += c["n_upr"].ToString().ToLower();
			}
			if (c["PODR"].ToString() != "9" )		pdr += " " + c["n_podch"].ToString();
			
            pdr += " " + c["PODRAZDEL"].ToString();
			pdr.Replace("���","����");
			
			return pdr;
		}

		
		public bool isExistStr( string s1, string s2 )
		{
			if ( s1.IndexOf(s2) != -1 ) return true;
			else return false;
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
			this.Conn = new System.Data.Odbc.OdbcConnection();
			this.selectCmd1 = new System.Data.Odbc.OdbcCommand();
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.viewDataSet = new UK.viewDataSet();
			this.tmpDataSet = new UK.tmpDataSet();
			this.LogsConn = new System.Data.SqlClient.SqlConnection();
			this.AddLogsCmd = new System.Data.SqlClient.SqlCommand();
			((System.ComponentModel.ISupportInitialize)(this.viewDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tmpDataSet)).BeginInit();
			// 
			// Conn
			// 
			this.Conn.ConnectionString = "PageTimeout=0;FIL=dBase IV;MaxBufferSize=2048;DSN=KADRY;DefaultDir=C:\\KADRY;Drive" +
				"rId=277";
			// 
			// selectCmd1
			// 
			this.selectCmd1.Connection = this.Conn;
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.selectCmd1;
			// 
			// viewDataSet
			// 
			this.viewDataSet.DataSetName = "viewDataSet";
			this.viewDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// tmpDataSet
			// 
			this.tmpDataSet.DataSetName = "tmpDataSet";
			this.tmpDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// LogsConn
			// 
            this.LogsConn.ConnectionString = "Data Source=URLS_SERVER\\SQLEXPRESS;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*";
			// 
			// AddLogsCmd
			// 
			this.AddLogsCmd.CommandText = "dbo.[AddToLogs]";
			this.AddLogsCmd.CommandType = System.Data.CommandType.StoredProcedure;
			this.AddLogsCmd.Connection = this.LogsConn;
			this.AddLogsCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.AddLogsCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Event", System.Data.SqlDbType.Int, 4));
			this.AddLogsCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EventTime", System.Data.SqlDbType.DateTime, 8));
			this.AddLogsCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.VarChar, 50));
			this.AddLogsCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.Bit, 1));
			this.AddLogsCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.VarChar, 100));
			((System.ComponentModel.ISupportInitialize)(this.viewDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tmpDataSet)).EndInit();

		}
		#endregion

		
	}
}
