using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.Caching;
using System.Data.SqlClient;
using kadry.DurationCalculatorApp;



namespace kadry
{
	public partial class DetailPage : Page
	{
		protected System.Data.Odbc.OdbcConnection Conn;
		protected System.Data.Odbc.OdbcCommand selectCmd1;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected kadry.viewDataSet viewDataSet;
		protected System.Data.Odbc.OdbcCommand selectCmd2;
		protected kadry.tmpDataSet tmpDataSet;
		protected System.Web.UI.WebControls.Button PrintBtn;
		protected System.Web.UI.WebControls.Button SaveBtn;
		protected System.Web.UI.WebControls.ListBox PrintList;
		protected SqlConnection LogsConn;
		protected SqlCommand AddLogsCmd;
		protected kadry.certDataSet certDataSet;
		private System.Data.DataRowCollection rc;
		protected SqlDataAdapter certDataAdapter;
		protected SqlConnection certConn;
		protected SqlCommand certComm;
        protected SqlConnection attConn;
        protected SqlCommand attComm;
        public static string nom2;
		
		public static string nom1;
        public static string f_name;
        public static string name;
        public static string s_name;
        public TPeriod army = new TPeriod();
        public TPeriod posl = new TPeriod();
        
        public TPeriod itog = new TPeriod();
        

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack) 
			{
				//Security.Security s = new Security.Security();
		    
				// �������� ���� ��������...
				int id = Convert.ToInt16(Request.QueryString["id"]);

                //string ppath = "";

                //if (Request.Params.Count > 1) ppath = Request.QueryString["ppath"];

				string UserName = Context.User.Identity.Name;

				// �������� �� ����� �������...
                //if ( !s.CheckSecurePage(UserName,"detailpage.aspx") ) Response.Redirect("AccessDenied.htm",true);
                //if ( !s.CheckSecureKey(UserName,id) ) Response.Redirect("AccessDenied.htm",true);
                //else
                //{
                //    string IP = Context.Request.UserHostAddress;

                //    if (IP == "10.22.41.77" || IP == "10.22.41.75" || IP == "10.22.41.76" || IP == "192.168.10.2" || IP == "192.168.10.3" || IP == "192.168.10.4" || IP == "10.22.32.9")
                //    {
                //        PrnVerButton.Visible = true;
                //    }
                //    else
                //    {
                //        _literal.Text = "<script language='javascript'>\n document.onmousedown=disableclick;\n status='';\n Function disableclick(e) { if(event.button==2) { alert(status); return false; } } </script>\n";
                //        _literal.Text += "<script language='javascript'> window.setInterval('dropSelection()', 5); function dropSelection() { document.selection.empty(); } </script> ";
                //        PrnVerButton.Visible = false;
                //    }

                //    if (IP == "192.168.10.4" || IP == "192.168.10.2") TableLButton.Visible = true;

                    //string Hscript = "<script language='javascript'>\n document.onmousedown=disableclick;\n status='';\n Function disableclick(e) { if(event.button==2) { alert(status); return false; } } </script>";
                    //RegisterClientScriptBlock("Script1", Hscript);

                    //HtmlGenericControl body = Master.FindControl("_body") as HtmlGenericControl;
                    

					// �������� ��������
                    DataTable dt = DataProvider._getDataODBC(String.Format("SELECT FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, LICH_NOM_1, LICH_NOM_2, OBRAZ_LIC1, DAT_OKUZ, DATA_POST, VREMI_V_SL, DATA_VDOLZ, NOMLICHDEL FROM {0} WHERE KEY_1 = {1}", kadry.Vars.sbase, id));
					rc = dt.Rows;
                    dt.Dispose();

					f_name		= rc[0]["FAMILIYA"].ToString();
					name		= rc[0]["IMYA"].ToString();
					s_name		= rc[0]["OTCHECTVO"].ToString();
					string born_date	= Fn.D2STR(rc[0]["DATA_ROZD"]);
					string lnom1		= rc[0]["LICH_NOM_1"].ToString();
					nom1 = lnom1;
					string lnom2		= rc[0]["LICH_NOM_2"].ToString();
					nom2 = lnom2;
					string data_post	= Fn.D2STR(rc[0]["DATA_POST"]);
					string data_slu		= Fn.D2STR(rc[0]["VREMI_V_SL"]);
					string data_dol		= Fn.D2STR(rc[0]["DATA_VDOLZ"]);
					string obr_type		= rc[0]["OBRAZ_LIC1"].ToString();
					string dat_okuz		= rc[0]["DAT_OKUZ"].ToString();
					string nfile = "";
					if ( rc[0]["NOMLICHDEL"].ToString() != "0" ) nfile = rc[0]["NOMLICHDEL"].ToString();
					else nfile = "���";
					string m_roz		= "";
					string nation		= "";
					string obr_stage	= "";
					string obr_spec		= "";
					string uchzav		= "";
					string ucheba		= "";
					string sex = "";

                    if (nom1 == "" || nom2 == "")
                    {
                        FTrLabel.Visible = false;
                        FirstTrButton.Visible = false;
                    }

					//Title.Text += f_name + " ";

					// �������� �� ����� �������, �����, ��������...
					tmpDataSet.Dispose();
					rc.Clear();
                    selectCmd2.CommandText = String.Format("SELECT FAMILIYA, IMYA, OTCHECTVO FROM WOMANFAM.DBF WHERE KEY_1 = {0} ORDER BY DAT_REG DESC", id);
					DataAdapter.SelectCommand = selectCmd2;
					DataAdapter.Fill(tmpDataSet);
					rc = tmpDataSet.Tables[0].Rows;

                    string tmp1 = f_name;
                    string tmp2 = name;
                    string tmp3 = s_name;

					if ( rc.Count != 0) 
					{
                      for (int i = 0; i < rc.Count; i++)
                        {
                            if (rc[i]["FAMILIYA"].ToString() != "" )
                            {
                                if (i == 0) tmp1 += " (";
                                tmp1 += rc[i]["FAMILIYA"].ToString();
                                if (i < rc.Count-1) tmp1 += ",";
                                if (i == rc.Count - 1) tmp1 += ")";
                            }
                            if (rc[i]["IMYA"].ToString() != "" )
                            {
                                if (i == 0) tmp2 += " (";
                                tmp2 += rc[i]["IMYA"].ToString();
                                if (i < rc.Count - 1) tmp2 += ",";
                                if (i == rc.Count - 1) tmp2 += ")";
                                
                            }
                            if (rc[i]["OTCHECTVO"].ToString() != "" )
                            {
                                if (i == 0) tmp3 += " (";
                                tmp3 += rc[i]["OTCHECTVO"].ToString();
                                if (i < rc.Count - 1) tmp3 += ",";
                                if (i == rc.Count - 1) tmp3 += ")";
                            }
                        }
					}

                    TitleText.Text += tmp1 + " " + tmp2 + " " + tmp3;
			 
                    //HyperLink1.NavigateUrl = "..//Vysluga.aspx?id=" + id.ToString() + "&name=" + Title.Text;

					// ����
					tmpDataSet.Dispose();
					rc.Clear();
                    selectCmd2.CommandText = String.Format("SELECT PHOTO FROM PHOTOS.DBF WHERE KEY_1 = {0}", id);
					DataAdapter.SelectCommand = selectCmd2;
					DataAdapter.Fill(tmpDataSet);
					rc = tmpDataSet.Tables[0].Rows;
					if ( rc.Count != 0) 
					{
						string photo_name = rc[0]["PHOTO"].ToString();
						Image.ImageUrl += photo_name;
						Image.DataBind();
						Image.AlternateText = "����";
					} 
					else { Image.ImageUrl += "000000.jpg"; Image.AlternateText = "���� �����������"; }

                    // ��������������

                    //attConn = new SqlConnection("Data Source=URLS_SERVER;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*");
                    //attComm = new SqlCommand("SELECT COUNT(att_date) FROM PoliceAttestation WHERE ID = " + id.ToString(), attConn);
                    //if (attConn.State != ConnectionState.Open) attConn.Open();
                    //int res = (int)attComm.ExecuteScalar();
                    //if (res > 0) Att_Button.ImageUrl += "att_status1_small.gif";
                    //else Att_Button.ImageUrl += "att_status2_small.gif";
                    

					// ����� ��������
					tmpDataSet.Dispose();
					rc.Clear();
					selectCmd2.CommandText = "SELECT P1 FROM SLVMR.DBF, " + kadry.Vars.sbase + " WHERE KEY_1 = " + id + " AND M_ROZ = P2";
					DataAdapter.SelectCommand = selectCmd2;
					DataAdapter.Fill(tmpDataSet);
					rc = tmpDataSet.Tables[0].Rows;
					if (rc.Count != 0)
					{ 
						if ( (string)(rc[0]["P1"]) == "                   =+=") m_roz = "��� ������";
						else m_roz = (string)(rc[0]["P1"]);
					}
				 
					// ��������������
					tmpDataSet.Dispose();
					rc.Clear();
                    selectCmd2.CommandText = String.Format("SELECT KEY_OF_NAC, NACION FROM NACIONAL.DBF, {0} WHERE NACIONALN = KEY_OF_NAC AND KEY_1 = {1}", kadry.Vars.sbase, id);
					DataAdapter.SelectCommand = selectCmd2;
					DataAdapter.Fill(tmpDataSet);
					rc = tmpDataSet.Tables[0].Rows;
					if (rc.Count != 0)
					{
						nation = rc[0]["NACION"].ToString();
						if ( Convert.ToInt16(rc[0]["KEY_OF_NAC"]) > 50 ) sex = "�";
					}

					// ����������� 
					tmpDataSet.Dispose();
					rc.Clear();
                    selectCmd2.CommandText = String.Format("SELECT LEARN.TYPE, LEARN.YEAR, LEARN.KVALIFIK, LEARN.DOC_TYPE, LEARN.DOC_SER, LEARN.DOC_NUMBER, LEARN.KURS, SLVLE2.P1 AS STEP, SLVUCZ.P1 AS UCZ, SLVKVA.P1 AS SPEC, SLVSTLER.P1 AS STATUS FROM LEARN, SLVLE2, SLVUCZ, SLVKVA, SLVSTLER WHERE LEARN.VID = SLVLE2.P2 AND LEARN.UCH_ZAV = SLVUCZ.P2 AND LEARN.SPECALNOST = SLVKVA.P2 AND LEARN.STATUS = SLVSTLER.P2 AND (LEARN.KEY_1 = {0}) ORDER BY LEARN.YEAR", id);
					DataAdapter.SelectCommand = selectCmd2;
					DataAdapter.Fill(tmpDataSet);
					rc = tmpDataSet.Tables[0].Rows;
					L_learn.Text = "";

					if (rc.Count != 0)
					{
						for( int i = 0; i<rc.Count; i++ )
						{
                            L_learn.Text += String.Format("<br>{0}. {1} - ", i + 1, rc[i]["STEP"]);

							if ( rc[i]["STATUS"].ToString() == "�������" )
							{
                                L_learn.Text += String.Format("{0} �������{1} � {2} �.", rc[i]["UCZ"], sex, rc[i]["YEAR"]);
								
                                // ���� �� ������� (�����)
								if ( rc[i]["STEP"].ToString() == "������" || rc[i]["STEP"].ToString() == "����.����." || rc[i]["STEP"].ToString() == "���.������" )
								{
                                    L_learn.Text += String.Format(", �������������: \"{0}\", ������������: {1}", rc[i]["SPEC"], rc[i]["KVALIFIK"]);
								}
                                // ���� �� ��������� �� ���.
                                if ((rc[i]["DOC_TYPE"].ToString() != "" && rc[i]["DOC_TYPE"].ToString() != "?") || (rc[i]["DOC_SER"].ToString() != "?"))
                                {
                                    L_learn.Text += String.Format(", {0}: {1} �{2}", rc[i]["DOC_TYPE"], rc[i]["DOC_SER"], rc[i]["DOC_NUMBER"]);
                                }
							}
							if ( rc[i]["STATUS"].ToString() == "���������" )
							{
                                L_learn.Text += String.Format(" ��������� �� {0} ����� �{1}", rc[i]["KURS"], rc[i]["UCZ"]);
							}
							if ( rc[i]["STATUS"].ToString() == "��������� ����" )
							{
                                L_learn.Text += String.Format(" ��������� �� ��������� ����� � {0}", rc[i]["UCZ"]);
							}
							if ( rc[i]["STATUS"].ToString() == "��������" )
							{
                                L_learn.Text += String.Format(" ��������{0} �� {1} � {2}", sex, rc[i]["UCZ"], rc[i]["YEAR"]);
							}
						
						}
		
					}
					else
					{
						// ������� ����������� 
						tmpDataSet.Dispose();
						rc.Clear();
                        selectCmd2.CommandText = String.Format("SELECT P1 FROM SLVLE2.DBF, {0} WHERE OBRAZ_LIC2 = P2 AND KEY_1 = {1}", kadry.Vars.sbase, id);
						DataAdapter.SelectCommand = selectCmd2;
						DataAdapter.Fill(tmpDataSet);
						rc = tmpDataSet.Tables[0].Rows;
						if (rc.Count != 0) { obr_stage = rc[0]["P1"].ToString(); }

						// �������������
						tmpDataSet.Dispose();
						rc.Clear();
                        selectCmd2.CommandText = String.Format("SELECT P1 FROM SLVKVA.DBF, {0} WHERE OBRAZ_LIC3 = P2 AND KEY_1 = {1}", kadry.Vars.sbase, id);
						DataAdapter.SelectCommand = selectCmd2;
						DataAdapter.Fill(tmpDataSet);
						rc = tmpDataSet.Tables[0].Rows;
						if (rc.Count != 0) { obr_spec = rc[0]["P1"].ToString(); }
			 
						// ������� ���������
						tmpDataSet.Dispose();
						rc.Clear();
                        selectCmd2.CommandText = String.Format("SELECT P1 FROM SLVUCZ.DBF, {0} WHERE UCHZAV = P2 AND KEY_1 = {1}", kadry.Vars.sbase, id);
						DataAdapter.SelectCommand = selectCmd2;
						DataAdapter.Fill(tmpDataSet);
						rc = tmpDataSet.Tables[0].Rows;
						if (rc.Count != 0) { uchzav = rc[0]["P1"].ToString(); }

						// ���������� ��������...
						tmpDataSet.Dispose();
						rc.Clear();
                        selectCmd2.CommandText = String.Format("SELECT UCHEBA, GDE_UCH, POSL_KURS, KURS, P1 FROM SLVUCZ.DBF, {0} WHERE GDE_UCH = P2 AND KEY_1 = {1}", kadry.Vars.sbase, id);
						DataAdapter.SelectCommand = selectCmd2;
						DataAdapter.Fill(tmpDataSet);
						rc = tmpDataSet.Tables[0].Rows;
						if (rc.Count != 0 && Convert.ToBoolean(rc[0]["UCHEBA"]) != false )
						{
                            ucheba = String.Format(", [���������: {0}", rc[0]["P1"]); 
							if ( Convert.ToBoolean(rc[0]["POSL_KURS"]) == false ) ucheba += " �� ��������� ����� ]";
                            else ucheba += String.Format(" �� {0} ����� ]", rc[0]["KURS"]);
						}

                        L_learn.Text = String.Format("{0} - {1}, �������������: \"{2}\", {3} �. - ({4}){5}", obr_stage, obr_type, obr_spec, dat_okuz, uchzav, ucheba);
					}

					// ������������� ����
					selectCmd2.CommandText = "SELECT ISP_SROK FROM PRIEM.DBF WHERE KEY_1 = " + id.ToString();
					if ( Conn.State != ConnectionState.Open ) Conn.Open();
					int isp = Convert.ToInt16(selectCmd2.ExecuteScalar());
					if ( isp > 0 ) L_isp.Text = isp.ToString() + " ���.";
					else L_isp.Text = "��� ������";

				
					// ������ � ��
					tmpDataSet.Dispose();
					rc.Clear();
					selectCmd2.CommandText = "SELECT ARMY_BEGIN, ARMY_STOP, SOSTAV, VUS, WAR, GODEN, VOENKOMAT, VBILET, BILET_DATE, BILET_RVK, VOIN_ZVAN FROM VUCHET.DBF, ZVANIE.DBF WHERE ZVANIE = KEY_ZVAN AND KEY_1 = " + id;
					DataAdapter.SelectCommand = selectCmd2;
                    try
                    {
                        DataAdapter.Fill(tmpDataSet);
                    }
                    catch
                    {
                        Response.Write("������ � �����!");
                    }

					rc = tmpDataSet.Tables[0].Rows;
                    
                    if (rc.Count != 0)
                    {
                        vGrid.DataBind();
                        ArmyLabel.Text = "";

                        for (int i = 0; i < rc.Count; i++)
                        {
                            // ������� ������� � ��...
                            DateDifference dd;

                            if (rc[i]["ARMY_BEGIN"] != DBNull.Value)
                            {
                                dd = new DateDifference(Convert.ToDateTime(rc[i]["ARMY_BEGIN"]), Convert.ToDateTime(rc[i]["ARMY_STOP"]));
                                army.Add(dd.Days, dd.Months, dd.Years);
                            }
                            // ----------------------

                            vGrid.Items[i].Cells[2].Text = "������: " + rc[i]["SOSTAV"].ToString() + " (" + rc[i]["VOIN_ZVAN"].ToString() + ")," +
                                                            "���: " + rc[i]["VUS"].ToString() + ", " +
                                                            "��������� ��������: " + rc[i]["GODEN"].ToString() + ", " +
                                                            "������� �����: " + rc[i]["VBILET"].ToString() + " �� " +
                                                            Fn.D2STR(rc[0]["BILET_DATE"]) + " ����� " +
                                                            rc[i]["BILET_RVK"].ToString();


                        }
                        // ���� �� ������ - ������� ���
                        if (rc[0]["ARMY_BEGIN"] != DBNull.Value)
                        {
                            v_stag.Text = "������� � �� (�����������): " + army.ToLongString();
                        }
                        else v_stag.Visible = false;
                    }
                    else
                    {
                        ArmyLabel.Text = "�� ������(�)";
                        v_stag.Visible = false;
                    }
                    

					// ������� ���������� ��������
					L_Born.Text = born_date + " �.";
					L_BornPlace.Text = m_roz;
					L_Nation.Text = nation;
					L_nom.Text = lnom1 + " - " + lnom2;
					
					L_nfile.Text = "������ ���� � " + nfile;

					// ����������� ����

                    tmpDataSet.Dispose();
					rc.Clear();
					selectCmd2.CommandText = "select date_from, date_to, firm_dolzn, firma, adressfirm, osnovan from grazdank.dbf where main_key = " + id;
					DataAdapter.SelectCommand = selectCmd2;
					DataAdapter.Fill(tmpDataSet);
					rc = tmpDataSet.Tables[0].Rows;
					if ( rc.Count != 0 )
					{
						grGrid.DataBind();
						for( int i = 0; i < rc.Count; i++ )
						{
							grGrid.Items[i].Cells[2].Text = rc[i]["firm_dolzn"].ToString() + " " + rc[i]["firma"].ToString() + " " + rc[i]["adressfirm"].ToString();
                            if (rc[i]["osnovan"].ToString() != "") WorkBookLabel.Text = rc[i]["osnovan"].ToString();
						}
					} 
					else WorkLabel.Text = "������������ ����� ���...";

                    if (WorkBookLabel.Text == "") WorkBookLabel.Text = "��� ����������";

					// ������ ������
					tmpDataSet.Dispose();
					rc.Clear();
                    selectCmd2.CommandText = String.Format("SELECT DATA_PRSV, NOM_PRIK, P1, DATA_PRIK, VOIN_ZVAN FROM PERSZVAN.DBF, ZVANIE.DBF, SLVPR2.DBF WHERE OVD_PRIK = P2 AND ZVANIE = KEY_ZVAN AND KEY_1 = {0} ORDER BY DATA_PRIK", id);
					DataAdapter.SelectCommand = selectCmd2;
					DataAdapter.Fill(tmpDataSet);
					rc = tmpDataSet.Tables[0].Rows;
					if ( rc.Count != 0 )
					{
						zGrid.DataBind();
                     } 
					else
					{
						tmpDataSet.Dispose();
						rc.Clear();
                        selectCmd2.CommandText = String.Format("SELECT ZVANIE, DATA_PRSV, P1, DATA_PR_ZV AS DATA_PRIK, N_PR_ZVAN1 AS NOM_PRIK, N_PR_ZVAN2, VOIN_ZVAN FROM {0}, ZVANIE.DBF, SLVPR2.DBF WHERE N_PR_ZVAN2 = P2 AND ZVANIE = KEY_ZVAN AND KEY_1 = {1} ORDER BY DATA_PRSV", kadry.Vars.sbase, id);
						DataAdapter.SelectCommand = selectCmd2;
						DataAdapter.Fill(tmpDataSet);
						rc = tmpDataSet.Tables[0].Rows;
						if ( rc.Count != 0 )
						{
							zGrid.DataBind();
						}
					}
			 
					// ��������� ������
					L_OVD.Text = data_post;
					L_vSlu.Text = data_slu;
					L_vDolz.Text = data_dol;
		 
					//tmpDataSet.Dispose();
					rc.Clear();
					selectCmd2.CommandText = "SELECT POSL.*, VOIN_ZVAN, D.NAM_OF_DOL, N6.NAIMENOVAN, " +
						"Pdr.PODRAZDEL, N1.NAIMENOVAN, N2.NAIMENOVAN, N3.NAIMENOVAN, N4.NAIMENOVAN, " +
						"N5.NAIMENOVAN, S1.P1 " +
						"FROM POSL_SPI.DBF POSL, PODRAZD.DBF Pdr, NAIMEN.DBF N1, NAIMEN.DBF N2, " +
						"NAIMEN.DBF N3, NAIMEN.DBF N4, NAIMEN.DBF N5, NAIMEN.DBF N6, ZVANIE.DBF, " +
						"OFIC_DOL.DBF D, SLVPR2.DBF S1 " +
						"WHERE (PODR = N6.KEY_OF_NAI) AND (GRUP = N5.KEY_OF_NAI) " +
						"AND (OTDELENIE = N4.KEY_OF_NAI) AND (PODOTDEL = N3.KEY_OF_NAI) " +
						"AND (OTDEL = N2.KEY_OF_NAI) AND (UPRAVLENIE = N1.KEY_OF_NAI) " +
						"AND (PODRAZD = KEY_OF_POD) AND (ZVANIE = KEY_ZVAN) " + 
						"AND (DOLZNOST = D.P3) AND (CHEI_PRIK = S1.P2) AND (KEY_POSL = " + id + ") ORDER BY DATA_OT, POSL.NOM_PRIK";
					DataAdapter.SelectCommand = selectCmd2;
					DataAdapter.Fill(tmpDataSet);
					rc = tmpDataSet.Tables[0].Rows;
                    
					if ( rc.Count != 0 )
					{
						pGrid.DataBind();
                        
						// �������������
						for (int i=0; i <= rc.Count - 1; i++)
						{
							string pdr = "";
							if (rc[i]["GRUP"].ToString() != "9" )		pdr += "������ " + rc[i]["NAIMENOVAN5"];
							if (rc[i]["OTDELENIE"].ToString() != "9" )	pdr += " ��������� " + rc[i]["NAIMENOVAN4"].ToString();
							if (rc[i]["PODOTDEL"].ToString() != "9" )	pdr += " ��������� " + rc[i]["NAIMENOVAN3"].ToString();
							if (rc[i]["OTDEL"].ToString() != "9" )		pdr += " ������ " + rc[i]["NAIMENOVAN2"].ToString();
							if (rc[i]["UPRAVLENIE"].ToString() != "9" )	pdr += " ���������� " + rc[i]["NAIMENOVAN1"].ToString();
							if (rc[i]["PODR"].ToString() != "9" )		pdr += " " + rc[i]["NAIMENOVAN"].ToString();
                            pdr += " " + rc[i]["PODRAZDEL"].ToString();
                            //if (rc[i]["PODRAZD"].ToString() != "9" )		pdr += " " + rc[i]["PODRAZDEL"].ToString();

							pGrid.Items[i].Cells[3].Text = pdr;

                            // �����
                            if (rc[i]["OKLAD"].ToString() != "") pGrid.Items[i].Cells[8].Text = rc[i]["OKLAD"].ToString();
                            else pGrid.Items[i].Cells[8].Text = "-";
                            
							// ��������� �������
							switch((string)(rc[i]["STATUS"]))
							{
								case "1000" : pGrid.Items[i].Cells[4].Text = "������" + sex + " �� " + rc[i]["OPISANIE"].ToString(); break;
                                case "1100": pGrid.Items[i].Cells[4].Text = "���������" + sex + " �� ������������"; break;
                                case "1200" : pGrid.Items[i].Cells[4].Text = "���������" + sex + " � ����������"; break;
                                case "1300" : pGrid.Items[i].Cells[4].Text = "�������" + sex + " �� ����.�������"; break;
                                case "1400" : pGrid.Items[i].Cells[4].Text = "�������" + sex + " �������������"; break;
                                case "1500" : pGrid.Items[i].Cells[4].Text = "��������" + sex + " �� �.�������"; break;
                                case "1600" : pGrid.Items[i].Cells[4].Text = "������������" + sex + " �� ������"; break;
                                case "1701" : pGrid.Items[i].Cells[4].Text = "���������� �����������"; break;
                                case "2000" :
                                    {
                                        pGrid.Items[i].Cells[4].Text = "������" + sex + " " + rc[i]["OPISANIE"].ToString();
                                        //startDate.Add(Convert.ToDateTime(rc[i]["DATA_OT"]));
                                        break;
                                    }
								case "3000" : pGrid.Items[i].Cells[4].Text = ""; break;
                                case "4000" :
                                    {
                                        pGrid.Items[i].Cells[4].Text = "������" + sex + " - " + rc[i]["OPISANIE"].ToString();
                                        //endDate.Add(Convert.ToDateTime(rc[i]["DATA_OT"]));
                                        break;
                                    }
                                case "4001" : pGrid.Items[i].Cells[4].Text = "������" + sex; break;
								case "5000" : pGrid.Items[i].Cells[4].Text = "��������������" + sex + " � " + rc[i]["OPISANIE"].ToString(); break;
								case "6000" : pGrid.Items[i].Cells[4].Text = "��������" + sex + " � ������ "; break;
                                case "6001" : pGrid.Items[i].Cells[4].Text = "��������� ������"; break;
								case "7000" : pGrid.Items[i].Cells[4].Text = "��������" + sex + " �� ������� " + rc[i]["OPISANIE"].ToString(); break;
								case "8000" : pGrid.Items[i].Cells[4].Text = "�������" + sex + " �� ��������"; break;
								case "9000" : pGrid.Items[i].Cells[4].Text = "��������" + sex + " �� ���������"; break;
								case "9002" : pGrid.Items[i].Cells[4].Text = "��������" + sex + " � ������.�������"; break;
                                case "9003" : pGrid.Items[i].Cells[4].Text = "��������" + sex + " �� ������ �������"; break;
								case "9004" : pGrid.Items[i].Cells[4].Text = "�������" + sex + " � ������.�������"; break;
                                case "9005" : pGrid.Items[i].Cells[4].Text = "������ � ������ ��������� " + rc[i]["OPISANIE"].ToString(); break;
                                case "9006" : pGrid.Items[i].Cells[4].Text = "���������� ���������"; break;
                                case "9007" : pGrid.Items[i].Cells[4].Text = "�� ����������������"; break;
                                case "9008" : pGrid.Items[i].Cells[4].Text = "������ ����������������"; break;
							}


                            
						}

                        rc.Clear();
                        selectCmd2.CommandText = String.Format("SELECT DATA_OT, STATUS, DOLZNOST, NOM_PRIK FROM POSL_SPI.DBF POSL WHERE (DOLZNOST < '800000') AND (KEY_POSL = {0}) ORDER BY DATA_OT, NOM_PRIK", id);
                        DataAdapter.SelectCommand = selectCmd2;
                        DataAdapter.Fill(tmpDataSet);
                        rc = tmpDataSet.Tables[0].Rows;
                        // ������� ������� ���...
                        DateTime date1;
                        DateTime date2 = new DateTime();
                        DateDifference dd;

                            if (rc.Count > 0)
                            {
                                // ���� � ��������� 1 ������ � ������...
                                if (rc.Count == 1)
                                {
                                    // ���� 1 ������ � ��������� (������)
                                    if (rc[0]["STATUS"].ToString() == "2000")
                                    {
                                        date1 = Convert.ToDateTime(rc[0]["DATA_OT"]);
                                        date2 = DateTime.Now;
                                        // ��������� ������������ �������
                                        dd = new DateDifference(date1, date2);
                                        // ��������� � �������...
                                        posl.Add(dd.Days, dd.Months, dd.Years);
                                    }
                                }
                                else // ���� ������� � ��������� ����� 1
                                {
                                    // ���������� ������...
                                    // ��������� ���� �������
                                    date1 = Convert.ToDateTime(rc[0]["DATA_OT"]);
                                    int m = 1;
                                    string st = "";
                                    do
                                    {
                                        st = rc[m]["STATUS"].ToString();
                                        if (st == "4000" || st == "7000") // ���� ������ ��� ����...
                                        {
                                            date2 = Convert.ToDateTime(rc[m]["DATA_OT"]);
                                            // ��������� ������������ �������
                                            dd = new DateDifference(date1, date2);
                                            // ��������� � �������...
                                            posl.Add(dd.Days, dd.Months, dd.Years);
                                            m++;
                                            if (m != rc.Count) date1 = Convert.ToDateTime(rc[m]["DATA_OT"]);
                                        }
                                        else
                                        {
                                            m++;
                                        }
                                    } while (m < rc.Count);

                                    if (kadry.Vars.sbase == "AAQQ.DBF" || kadry.Vars.sbase == "RESERV.DBF")
                                    {
                                        date2 = DateTime.Now;
                                        // ��������� ������������ �������
                                        dd = new DateDifference(date1, date2);
                                        // ��������� � �������...
                                        posl.Add(dd.Days, dd.Months, dd.Years);
                                    }
                                    else
                                    {
                                        date2 = Convert.ToDateTime(rc[rc.Count - 1]["DATA_OT"]);
                                    }
                                    
                                    
                                }

                                itog.Add(army.d, army.m, army.y);
                                itog.Add(posl.d, posl.m, posl.y);

                                ovd_stag.Text = "������� � ��� �� " + date2.ToShortDateString() + " (�����������): " + posl.ToSpecLongString() +
                                                "<br>����� ����������� ������� � �� � ��� �� " + date2.ToShortDateString() + " ����������: " + itog.ToSpecLongString();
                            }
                                                        
                            //// ----------------------

					}
					else
					{
						tmpDataSet.Dispose();
						rc.Clear();
                        selectCmd2.CommandText = String.Format("SELECT DATA_UVOL AS DATA_OT, VOIN_ZVAN, NAM_OF_DOL, PODRAZDEL, P1, NOM_PR_UVO AS NOM_PRIK, DATA_PR_UV AS DATA_PRIK FROM {0}, ZVANIE.DBF, OFIC_DOL.DBF AS DOL, PODRAZD.DBF, SLVPR2.DBF  WHERE ZVANIE = KEY_ZVAN AND KTO_UVOLIL = P2 AND  PODRAZD = KEY_OF_POD AND DOLZNOST = DOL.P3 AND KEY_1 = {1}", kadry.Vars.sbase, id);
						DataAdapter.SelectCommand = selectCmd2;
						DataAdapter.Fill(tmpDataSet);
						rc = tmpDataSet.Tables[0].Rows;
						if ( rc.Count != 0 )
						{
							pGrid.DataBind();
							pGrid.Items[0].Cells[3].Text = rc[0]["PODRAZDEL"].ToString();
							pGrid.Items[0].Cells[4].Text = "������";
						}
					}


					// �������� ������
                    tmpDataSet.Dispose();
                    rc.Clear();
                    selectCmd2.CommandText = String.Format("SELECT DATE_FROM, DATE_TO, KOEF_VISL, LEGEND, NUM_PRIK, SLVPR2.P1, PRIK_DATE FROM LGOTTIME.DBF, SLVPR2 WHERE OVD_PRIK = SLVPR2.P2 AND MAIN_KEY = {0} ORDER BY DATE_FROM", id);
                    DataAdapter.SelectCommand = selectCmd2;
                    DataAdapter.Fill(tmpDataSet);
                    rc = tmpDataSet.Tables[0].Rows;

                    if (rc.Count != 0)
                    {
                        kGrid.DataBind();
                        L_komand.Text = "  " + rc.Count.ToString();
                    }
                    else
                    {
                        L_komand.Text = " ��� ";
                        TableLButton.Visible = false;
                    }

					// ���������...
					tmpDataSet.Dispose();
					rc.Clear();
                    selectCmd2.CommandText = String.Format("SELECT DAT_NALOZ, S1.P1, N_PRIK_NAL, S2.P1, SODERZANIE, DAT_SNIAT, N_PRIK_SN, WHO_SNIAL FROM NAKAZAN.DBF, SLVPR2.DBF S1, SLVNAK.DBF S2 WHERE (WHO_NALOZ = S1.P2) AND (VID_NAKAZ = S2.P2) AND KEY_1 = {0} ORDER BY DAT_NALOZ", id);
					DataAdapter.SelectCommand = selectCmd2;
					DataAdapter.Fill(tmpDataSet);
					rc = tmpDataSet.Tables[0].Rows;

					if ( rc.Count != 0 )
					{
						nakGrid.DataBind();
						for (int i=0; i <= rc.Count - 1; i++)
						{
							nakGrid.Items[i].Cells[1].Text = rc[i]["P1"].ToString();
							nakGrid.Items[i].Cells[3].Text = rc[i]["P11"].ToString();
							if ( rc[i]["WHO_SNIAL"] != DBNull.Value )
							{
								DataTable dp  = DataProvider._getDataODBC(String.Format("SELECT * FROM SLVPR2.DBF WHERE P2 = '{0}'", rc[i]["WHO_SNIAL"]));
								nakGrid.Items[i].Cells[6].Text = dp.Rows[0]["P1"].ToString();
                                dp.Dispose();
							}
							
						}
						L_nak.Text = rc.Count.ToString();


					} 
					else L_nak.Text = " �� ����� ";

					// ���������...
					tmpDataSet.Dispose();
					rc.Clear();
                    selectCmd2.CommandText = String.Format("SELECT S1.P1, PRICHINA, S2.P1, NOM_PRIK, DATA_POO FROM POO.DBF, SLVPOO.DBF S1, SLVPR2.DBF S2 WHERE (TYPE_POO = S1.P2) AND (CHEI_PRIK = S2.P2) AND KEY_POO = {0} ORDER BY DATA_POO", id);
					DataAdapter.SelectCommand = selectCmd2;
					DataAdapter.Fill(tmpDataSet);
					rc = tmpDataSet.Tables[0].Rows;

					if ( rc.Count != 0 )
					{
						pooGrid.DataBind();
						for (int i=0; i <= rc.Count - 1; i++)
						{
							pooGrid.Items[i].Cells[0].Text = rc[i]["P1"].ToString();
					 
							if (rc[i]["PRICHINA"].ToString() == "") 
							{
								pooGrid.Items[i].Cells[1].Text = "������� ������...";
							}
							else pooGrid.Items[i].Cells[1].Text = rc[i]["PRICHINA"].ToString();

							pooGrid.Items[i].Cells[2].Text = rc[i]["P11"].ToString();
						}
						L_poo.Text = rc.Count.ToString();


					} 
					else L_poo.Text = " �� ����� ";

                    #region ���������...
					selectCmd2.CommandText = "SELECT PRIKAZ_NAD FROM PROCNADB.DBF WHERE PERSKEY = " + id;
					if (Conn.State != ConnectionState.Open) Conn.Open();
                    try
                    {
                        ProcNadb.Text = "������� ��� ��� ���������� ���������� �������� � ������ ���������: " + selectCmd2.ExecuteScalar().ToString();
                    }
                    catch
                    {
                        ProcNadb.Text = "";
                    }

					// ������������...
                    //s.AddLogText("�������� �/�: " + f_name + "|" + name + "|" + s_name, (string)(Context.Request.UserHostAddress),6,true );

                    // ������� �� ����������� ����...
                    //if (!s.CheckSecureContextMenu(UserName))
                    //{
                    //    //string nomenu = "alert('����������� ���� ��������� ��� ���!'); return false;";
                    //    //HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("Form1");
                    //    //body.Attributes.Add("oncontextmenu", nomenu);
                    //}

                    #endregion

                    #region �������

                    dt = DataProvider._getDataSQL(String.Format("SELECT MainDate, Days, DopDate, Comment FROM GrafikVacations WHERE id = {0} ORDER BY MainDate", id));

                    if (dt.Rows.Count > 0)
                    {
                        string mtext = "<br>��������:<br>";
                        string dtext = "";
                        foreach (DataRow row in dt.Rows)
                        {
                            mtext += String.Format("- � {0} �. �� {1} ����������� ����<br>", ((DateTime)row["MainDate"]).ToShortDateString(), row["Days"]);
                            if (row["DopDate"] != DBNull.Value)  dtext += String.Format("��������������: c {0} �.", Convert.ToDateTime(row["DopDate"]).ToShortDateString());
                        }
                        Vacations.Text = String.Format("{0}<br>{1}", mtext, dtext);
                    }
                    else
                    {
                        Vacations.Text = "��� ������";
                    }

                    dt.Dispose();
                    #endregion
                }
			//}

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
			this.selectCmd2 = new System.Data.Odbc.OdbcCommand();
			this.viewDataSet = new kadry.viewDataSet();
			this.tmpDataSet = new kadry.tmpDataSet();
			this.LogsConn = new System.Data.SqlClient.SqlConnection();
			this.AddLogsCmd = new System.Data.SqlClient.SqlCommand();
			this.certDataSet = new kadry.certDataSet();
			this.certDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
			this.certComm = new System.Data.SqlClient.SqlCommand();
			this.certConn = new System.Data.SqlClient.SqlConnection();
			
			((System.ComponentModel.ISupportInitialize)(this.viewDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tmpDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.certDataSet)).BeginInit();
			
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
			this.DataAdapter.SelectCommand = this.selectCmd2;
			// 
			// selectCmd2
			// 
			this.selectCmd2.CommandText = @"SELECT LEARN.TYPE, LEARN.YEAR, LEARN.KVALIFIK, LEARN.DOC_TYPE, LEARN.DOC_SER, LEARN.DOC_NUMBER, LEARN.KURS, SLVLE2.P1 AS STEP, SLVUCZ.P1 AS UCZ, KVALIF.P1 AS SPEC, SLVSTLER.P1 AS STATUS FROM LEARN, SLVLE2, SLVUCZ, KVALIF, SLVSTLER WHERE LEARN.VID = SLVLE2.P2 AND LEARN.UCH_ZAV = SLVUCZ.P2 AND LEARN.SPECALNOST = KVALIF.P2 AND LEARN.STATUS = SLVSTLER.P2 AND (LEARN.KEY_1 = 8541) ORDER BY LEARN.YEAR";
			this.selectCmd2.Connection = this.Conn;
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
            this.LogsConn.ConnectionString = "Data Source=URLS_SERVER\\sqlexpress;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*";
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
			// 
			// certDataSet
			// 
			this.certDataSet.DataSetName = "certDataSet";
			this.certDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// certDataAdapter
			// 
			this.certDataAdapter.SelectCommand = this.certComm;
			// 
			// certComm
			// 
			this.certComm.Connection = this.certConn;
			// 
			// certConn
			// 
			this.certConn.ConnectionString = "packet size=4096;user id=ias_user;data source=Urls_SERVER\\sqlexpress;persist security info=Tr" +
				"ue;initial catalog=K2_certificate;password=*";
            
			this.Unload += new System.EventHandler(this.DetailPage_Unload);
			((System.ComponentModel.ISupportInitialize)(this.viewDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tmpDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.certDataSet)).EndInit();
			

		}
		#endregion

		protected void DetailPage_Unload(object sender, System.EventArgs e)
		{
			//rc.Clear();
		}

		public string ConvertBlankNumber( string num )
		{
			if ( num.Length == 6 ) return num;
			if ( num.Length == 5 ) return "0" + num;
			if ( num.Length == 4 ) return "00" + num;
			if ( num.Length == 3 ) return "000" + num;
			if ( num.Length == 2 ) return "0000" + num;
			else return "00000" + num;
		}

		protected void CertButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if ( nom2 != "" )
			{
				certComm.CommandText = "SELECT person.first_name, person.last_name, person.middle_name, crt_blank.blank_serie, crt_blank.blank_number, crt_certificate.date_given, crt_state.description FROM person INNER JOIN crt_certificate ON person.id_person = crt_certificate.id_person INNER JOIN crt_blank ON crt_certificate.id_blank = crt_blank.id_blank INNER JOIN crt_state ON crt_certificate.id_state = crt_state.id_state WHERE (crt_certificate.id_state NOT IN (4,5)) AND (person.personal_number = '" + nom1 + "-" + nom2 + "')";
				certDataAdapter.SelectCommand = certComm;
				certDataSet.Clear();
				certDataAdapter.Fill(certDataSet,"Table");

				if (certDataSet.Tables["Table"].Rows.Count > 0)
				{
					string msg = "";
					for( int i=0; i<certDataSet.Tables["Table"].Rows.Count; i++)
					{
						msg += certDataSet.Tables["Table"].Rows[i]["first_name"].ToString() + " " +
							   certDataSet.Tables["Table"].Rows[i]["last_name"].ToString() + " " + 
							   certDataSet.Tables["Table"].Rows[i]["middle_name"].ToString() + 
							   " ����� ��� � " + ConvertBlankNumber(certDataSet.Tables["Table"].Rows[i]["blank_number"].ToString()) + 
							   " �� " + Convert.ToDateTime(certDataSet.Tables["Table"].Rows[i]["date_given"]).ToShortDateString() +
							   " (������ - " + certDataSet.Tables["Table"].Rows[i]["description"].ToString() + ")\t\t";
					}
					Response.Write("<script> alert('"+ msg + "'); </script>");

				} else Response.Write("<script> alert('������ �� ������������� ���!'); </script>");
				certDataSet.Clear();
			}
		}

        protected void FirstTrButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\ProfPod\\first_education.aspx?numb=" + nom1 + "-" + nom2 + "&name=" + f_name + " " + name + " " + s_name, false);
        }

        protected void PrnVerButton_Click(object sender, ImageClickEventArgs e)
        {
            kadry.Details data = new kadry.Details();
            data.FIO = TitleText.Text;
            data.Born = L_Born.Text;
            data.BornPlace = L_BornPlace.Text;
            data.Nation = L_Nation.Text;
            data.PersonalNumber = L_nom.Text;
            data.Learn = L_learn.Text;
            data.PersonalFileNumber = L_nfile.Text;
            data.PhotoFile = Image.ImageUrl;

            for (int i = 0; i < vGrid.Items.Count; i++)
            {
                data.Army += (i + 1).ToString() + ") � " + vGrid.Items[i].Cells[0].Text + " �� " + vGrid.Items[i].Cells[1].Text + " (" + vGrid.Items[i].Cells[2].Text + ")<br>";
            }

            if (WorkLabel.Text == "������������ ����� ���...")
            {
                kadry.OtherWork wrk = new kadry.OtherWork();
                wrk.Legend = WorkLabel.Text;
                data.Work = new ArrayList();
                data.Work.Add(wrk);
            }
            else
            {
                data.Work = new ArrayList();
                for (int i = 0; i < grGrid.Items.Count; i++)
                {
                    kadry.OtherWork wrk = new kadry.OtherWork();
                    wrk.From = grGrid.Items[i].Cells[0].Text;
                    wrk.To = grGrid.Items[i].Cells[1].Text;
                    wrk.Legend = grGrid.Items[i].Cells[2].Text;
                    data.Work.Add(wrk);
                }
            }

            data.Rank = new ArrayList();
            for (int i = 0; i < zGrid.Items.Count; i++)
            {
                kadry.SpecRank rank = new kadry.SpecRank();
                rank.Rank = zGrid.Items[i].Cells[0].Text;
                rank.OVDPrik = zGrid.Items[i].Cells[1].Text;
                rank.NumPrik = zGrid.Items[i].Cells[2].Text;
                rank.DatePrik = zGrid.Items[i].Cells[3].Text;
                rank.DateRank = zGrid.Items[i].Cells[4].Text;
                data.Rank.Add(rank);
            }

            data.vOVD = L_OVD.Text;
            data.vSLU = L_vSlu.Text;
            data.vDOL = L_vDolz.Text;

            data.Posl = new ArrayList();
            for (int i = 0; i < pGrid.Items.Count; i++)
            {
                kadry.SpecWork swrk = new kadry.SpecWork();
                swrk.From = pGrid.Items[i].Cells[0].Text;
                swrk.Zvan = pGrid.Items[i].Cells[1].Text;
                swrk.Dolz = pGrid.Items[i].Cells[2].Text;
                swrk.Podr = pGrid.Items[i].Cells[3].Text;
                swrk.Status = pGrid.Items[i].Cells[4].Text;
                swrk.OVDPrik = pGrid.Items[i].Cells[5].Text;
                swrk.NumPrik = pGrid.Items[i].Cells[6].Text;
                swrk.DatePrik = pGrid.Items[i].Cells[7].Text;
                data.Posl.Add(swrk);
            }

            data.Lgottime = new ArrayList();

            if (L_komand.Text != " ��� ")
            {
                for (int i = 0; i < kGrid.Items.Count; i++)
                {
                    kadry.Komand kom = new kadry.Komand();
                    kom.From = kGrid.Items[i].Cells[0].Text;
                    kom.To = kGrid.Items[i].Cells[1].Text;
                    kom.Koeff = kGrid.Items[i].Cells[2].Text;
                    kom.Legend = kGrid.Items[i].Cells[3].Text;
                    kom.Prik = kGrid.Items[i].Cells[4].Text;
                    kom.Date_pr = kGrid.Items[i].Cells[5].Text;
                    kom.Num_pr = kGrid.Items[i].Cells[6].Text;
                    data.Lgottime.Add(kom);
                }
            }

            data.Nak = new ArrayList();

            if (L_nak.Text != " ��� ")
            {
                for (int i = 0; i < nakGrid.Items.Count; i++)
                {
                    kadry.Nakazan nak = new kadry.Nakazan();
                    nak.Date = nakGrid.Items[i].Cells[0].Text;
                    nak.OVDPrik = nakGrid.Items[i].Cells[1].Text;
                    nak.NumPrik = nakGrid.Items[i].Cells[2].Text;
                    nak.Vzysk = nakGrid.Items[i].Cells[3].Text;
                    nak.Legend = nakGrid.Items[i].Cells[4].Text;
                    nak.DateSn = nakGrid.Items[i].Cells[5].Text;
                    nak.WhoSn = nakGrid.Items[i].Cells[6].Text;
                    nak.NumPrSn = nakGrid.Items[i].Cells[7].Text;
                    data.Nak.Add(nak);
                }
            }

            data.Nagr = new ArrayList();

            if (L_poo.Text != " ��� ")
            {
                for (int i = 0; i < pooGrid.Items.Count; i++)
                {
                    kadry.Poo poo = new kadry.Poo() { Vid = pooGrid.Items[i].Cells[0].Text, Prich = pooGrid.Items[i].Cells[1].Text, OVDPrik = pooGrid.Items[i].Cells[2].Text, NumPrik = pooGrid.Items[i].Cells[3].Text, DatePrik = pooGrid.Items[i].Cells[4].Text };
                    data.Nagr.Add(poo);
                }
            }

            Cache.Add("detail", data, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null);
            Response.Redirect("DetailPage_txt.aspx", false);
        }

        protected void TableLButton_Click(object sender, ImageClickEventArgs e)
        {
            if (L_komand.Text == " ��� ") Response.Write("<script> alert('��� ������������ - ����� �����!!'); </script>");
            else Response.Redirect(String.Format("TableLgottime.aspx?id={0}", Request["id"]));
        }
	}
}
