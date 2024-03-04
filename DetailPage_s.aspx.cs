using System;
using System.Data;


namespace UK
{
	/// <summary>
	/// Summary description for DetailPage.
	/// </summary>
	public partial class DetailPage_s : System.Web.UI.Page
	{
		protected UK.viewDataSet viewDataSet;
		protected System.Web.UI.WebControls.Button PrintBtn;
		protected System.Web.UI.WebControls.Button SaveBtn;
		protected System.Web.UI.WebControls.ListBox PrintList;
		protected System.Data.SqlClient.SqlConnection LogsConn;
		protected System.Data.SqlClient.SqlCommand AddLogsCmd;
		private System.Data.DataRowCollection rc;
		public static string nom2;
		public static string nom1;
		public static string photo_name;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack) 
			{
				Security.Security s = new Security.Security();
		    
				// �������� ���� ��������...
				int id = Convert.ToInt16(Request.QueryString["id"]);

				string UserName = this.Context.User.Identity.Name;

				// �������� �� ����� �������...
				if ( !s.CheckSecurePage(UserName,"detailpage_s.aspx") ) Response.Redirect("AccessDenied.htm",true);
				if ( !s.CheckSecureKey(UserName,id) ) Response.Redirect("AccessDenied.htm",true);
				else
				{

					// �������� ��������
					DataTable dt = DataProvider._getDataODBC(String.Format("SELECT FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, LICH_NOM_1, LICH_NOM_2, OBRAZ_LIC1, DAT_OKUZ, " +
					                                                       "DATA_POST, VREMI_V_SL, DATA_VDOLZ, NOMLICHDEL FROM {0} WHERE KEY_1 = {1}",UK.Vars.sbase,id));
					rc = dt.Rows;
                    dt.Dispose();

					string f_name		= rc[0]["FAMILIYA"].ToString();
					string name			= rc[0]["IMYA"].ToString();
					string s_name		= rc[0]["OTCHECTVO"].ToString();
					string born_date	= Fn.D2STR(rc[0]["DATA_ROZD"]);
					string lnom1		= rc[0]["LICH_NOM_1"].ToString();
					nom1 = lnom1;
					string lnom2		= rc[0]["LICH_NOM_2"].ToString();
					nom2 = lnom2;
					string obr_type		= rc[0]["OBRAZ_LIC1"].ToString();
					string dat_okuz		= rc[0]["DAT_OKUZ"].ToString();
					string data_post	= Fn.D2STR(rc[0]["DATA_POST"]);
					string data_slu		= Fn.D2STR(rc[0]["VREMI_V_SL"]);
					string data_dol		= Fn.D2STR(rc[0]["DATA_VDOLZ"]);
                    string nfile		= rc[0]["NOMLICHDEL"].ToString();
					string m_roz		= "";
					string nation		= "";
					string obr_stage	= "";
					string obr_spec		= "";
					string uchzav		= "";
					string ucheba		= "";

					this.TitleText.Text += f_name + " ";
					
					// �������� �� ����� �������...
					rc.Clear();
					dt = DataProvider._getDataODBC(String.Format("SELECT FAMILIYA FROM WOMANFAM.DBF WHERE KEY_1 = {0}",id));
					rc = dt.Rows;
                    dt.Dispose();
					if ( rc.Count != 0) 
					{
						this.TitleText.Text += "(" + rc[0]["FAMILIYA"].ToString() + ")";
					}
			 
					this.TitleText.Text += " " + name + " " + s_name;
					
					// ����
					rc.Clear();
					dt = DataProvider._getDataODBC(String.Format("SELECT PHOTO FROM PHOTOS.DBF WHERE KEY_1 = {0}",id));
					rc = dt.Rows;
                    dt.Dispose();
					if ( rc.Count != 0) photo_name = "~/PhotoBank/" + rc[0]["PHOTO"].ToString();
					else { photo_name = "~/PhotoBank/000000.jpg"; }

					// ����� ��������
					rc.Clear();
					dt = DataProvider._getDataODBC(String.Format("SELECT P1 FROM SLVMR.DBF, {0} WHERE KEY_1 = {1} AND M_ROZ = P2",UK.Vars.sbase,id));
					rc = dt.Rows;
                    dt.Dispose();
					if (rc.Count != 0)
					{ 
						if ( (string)(rc[0]["P1"]) == "                   =+=") m_roz = "��� ������";
						else m_roz = (string)(rc[0]["P1"]);
					}
				 
					// ��������������
					rc.Clear();
					dt = DataProvider._getDataODBC(String.Format("SELECT NACION FROM NACIONAL.DBF, {0} WHERE NACIONALN = KEY_OF_NAC AND KEY_1 = {1}",UK.Vars.sbase,id));
					rc = dt.Rows;
                    dt.Dispose();
					if (rc.Count != 0) { nation = rc[0]["NACION"].ToString(); }

					// ������� ����������� 
					rc.Clear();
					dt = DataProvider._getDataODBC(String.Format("SELECT P1 FROM SLVLE2.DBF, {0} WHERE OBRAZ_LIC2 = P2 AND KEY_1 = {1}",UK.Vars.sbase,id));
					rc = dt.Rows;
                    dt.Dispose();
					if (rc.Count != 0) { obr_stage = rc[0]["P1"].ToString(); }

					// �������������
					rc.Clear();
					dt = DataProvider._getDataODBC(String.Format("SELECT P1 FROM SLVKVA.DBF, {0} WHERE OBRAZ_LIC3 = P2 AND KEY_1 = {1}",UK.Vars.sbase,id));
					rc = dt.Rows;
                    dt.Dispose();
					if (rc.Count != 0) { obr_spec = rc[0]["P1"].ToString(); }
			 
					// ������� ���������
					rc.Clear();
					dt = DataProvider._getDataODBC(String.Format("SELECT P1 FROM SLVUCZ.DBF, {0} WHERE UCHZAV = P2 AND KEY_1 = {1}",UK.Vars.sbase,id));
					rc = dt.Rows;
                    dt.Dispose();
					if (rc.Count != 0) { uchzav = rc[0]["P1"].ToString(); }

					// ���������� ��������...
					rc.Clear();
                    dt = DataProvider._getDataODBC(String.Format("SELECT UCHEBA, GDE_UCH, POSL_KURS, KURS, P1 FROM SLVUCZ.DBF, {0} WHERE GDE_UCH = P2 AND KEY_1 = {1}",UK.Vars.sbase,id));
					rc = dt.Rows;
                    dt.Dispose();
					if (rc.Count != 0 && Convert.ToBoolean(rc[0]["UCHEBA"]) != false )
					{
						ucheba = ", [���������: " + rc[0]["P1"].ToString(); 
						if ( Convert.ToBoolean(rc[0]["POSL_KURS"]) == false ) ucheba += " �� ��������� ����� ]";
						else ucheba += " �� " + rc[0]["KURS"].ToString() + " ����� ]";
					}

					L_learn.Text = obr_stage + " - " + obr_type + ", �������������: \"" + obr_spec + "\", " + dat_okuz + " �. - (" + uchzav + ")" + ucheba;
				
					// ������ � ��
					rc.Clear();
					dt = DataProvider._getDataODBC(String.Format("SELECT ARMY_BEGIN, ARMY_STOP, SOSTAV, VUS, WAR, GODEN, VOENKOMAT, VBILET, BILET_DATE, BILET_RVK, VOIN_ZVAN FROM VUCHET.DBF, ZVANIE.DBF WHERE ZVANIE = KEY_ZVAN AND KEY_1 = {0}",id));
					rc = dt.Rows;
                    dt.Dispose();
					if ( rc.Count != 0 ) 
					{
						if (rc.Count > 1 )
						{
							for (int i=0; i<=rc.Count-1; i++)
							{
								L_Vinfo1.Text += "� " + Fn.D2STR(rc[i]["ARMY_BEGIN"]) + " �� " + Fn.D2STR(rc[i]["ARMY_STOP"]) + "; ";
							}
						} 
						else
						{
							L_Vinfo1.Text = "c " + Fn.D2STR(rc[0]["ARMY_BEGIN"]) + " �� " + Fn.D2STR(rc[0]["ARMY_STOP"]);
						}
						string sostav		= rc[0]["SOSTAV"].ToString();
						string vus			= rc[0]["VUS"].ToString();
						string vzvan		= rc[0]["VOIN_ZVAN"].ToString();
						if (vzvan == "������������(�)" || vzvan == "") vzvan = "��� ������";

						string war			= "";
						string godnost		= rc[0]["GODEN"].ToString();
						string voenkomat	= rc[0]["VOENKOMAT"].ToString();
						string v_bilet		= rc[0]["VBILET"].ToString();
						string vb_date		= Fn.D2STR(rc[0]["BILET_DATE"]);
						string vb_rvk		= rc[0]["BILET_RVK"].ToString();

						if ( Convert.ToBoolean(rc[0]["WAR"]) == true ) { war = "��"; }
						else { war = "���"; }
					 
						L_Vinfo2.Text = "������:(" + sostav + "), ���:(" + vus + ")";
						L_Vinfo3.Text = "������(��������): " + vzvan;
						L_Vinfo4.Text = "������� � ������ ���������: " + war;
						L_Vinfo5.Text = "��������� ��������: " + godnost;
						L_Vinfo6.Text = "������ ��: " + voenkomat;
						L_Vinfo7.Text = "������� �����: " + v_bilet;
						L_Vinfo8.Text = "�����: " + vb_date + ", " + vb_rvk;
								 
					} 
					else L_Vinfo1.Text = "�� ������(�)...";

					// ������� ���������� ��������
					L_Born.Text = born_date + " �.";
					L_BornPlace.Text = m_roz;
					L_Nation.Text = nation;
					L_nom.Text = lnom1 + " - " + lnom2;
					
					if ( nfile != "0" )	L_nfile.Text = "������ ���� � " + nfile;
					else L_nfile.Text = "";

					// ����������� ����
                    rc.Clear();
					dt = DataProvider._getDataODBC(String.Format("select date_from, date_to, firm_dolzn, firma, adressfirm, osnovan from grazdank.dbf where main_key = {0}",id));
					rc = dt.Rows;
                    dt.Dispose();
					if ( rc.Count != 0 )
					{
						grGrid.DataBind();
						for( int i = 0; i<rc.Count; i++ )
						{
							grGrid.Items[i].Cells[2].Text = rc[i]["firm_dolzn"].ToString() + " " + rc[i]["firma"].ToString() + " " + rc[i]["adressfirm"].ToString();
						}
					} 
					else WorkLabel.Text = "������������ ����� ���...";

					// ������ ������
					rc.Clear();
					dt = DataProvider._getDataODBC(String.Format("SELECT DATA_PRSV, NOM_PRIK, P1, DATA_PRIK, VOIN_ZVAN FROM PERSZVAN.DBF, ZVANIE.DBF, SLVPR2.DBF WHERE OVD_PRIK = P2 AND ZVANIE = KEY_ZVAN AND KEY_1 = {0} ORDER BY DATA_PRSV",id));
					rc = dt.Rows;
                    dt.Dispose();
					if ( rc.Count != 0 )
					{
						zGrid.DataBind();
                     } 
					else
					{
						rc.Clear();
						dt = DataProvider._getDataODBC(String.Format("SELECT ZVANIE, DATA_PRSV, P1, DATA_PR_ZV AS DATA_PRIK, N_PR_ZVAN1 AS NOM_PRIK, N_PR_ZVAN2, VOIN_ZVAN FROM {0}, ZVANIE.DBF, SLVPR2.DBF WHERE N_PR_ZVAN2 = P2 AND ZVANIE = KEY_ZVAN AND KEY_1 = {1} ORDER BY DATA_PRSV",UK.Vars.sbase,id));
						rc = dt.Rows;
                        dt.Dispose();
						if ( rc.Count != 0 )
						{
							zGrid.DataBind();
						}
					}
			 
					// ��������� ������
					L_OVD.Text = data_post;
					L_vSlu.Text = data_slu;
					L_vDolz.Text = data_dol;
		 
					rc.Clear();
					dt = DataProvider._getDataODBC(String.Format("SELECT POSL.*, VOIN_ZVAN, D.NAM_OF_DOL, N6.NAIMENOVAN, " +
						"Pdr.PODRAZDEL, N1.NAIMENOVAN, N2.NAIMENOVAN, N3.NAIMENOVAN, N4.NAIMENOVAN, " +
						"N5.NAIMENOVAN, S1.P1 " +
						"FROM POSL_SPI.DBF POSL, PODRAZD.DBF Pdr, NAIMEN.DBF N1, NAIMEN.DBF N2, " +
						"NAIMEN.DBF N3, NAIMEN.DBF N4, NAIMEN.DBF N5, NAIMEN.DBF N6, ZVANIE.DBF, " +
						"OFIC_DOL.DBF D, SLVPR2.DBF S1 " +
						"WHERE (PODR = N6.KEY_OF_NAI) AND (GRUP = N5.KEY_OF_NAI) " +
						"AND (OTDELENIE = N4.KEY_OF_NAI) AND (PODOTDEL = N3.KEY_OF_NAI) " +
						"AND (OTDEL = N2.KEY_OF_NAI) AND (UPRAVLENIE = N1.KEY_OF_NAI) " +
						"AND (PODRAZD = KEY_OF_POD) AND (ZVANIE = KEY_ZVAN) " + 
						"AND (DOLZNOST = D.P3) AND (CHEI_PRIK = S1.P2) AND (KEY_POSL = {0} ORDER BY DATA_OT", id));
					rc = dt.Rows;
                    dt.Dispose();
					if ( rc.Count != 0 )
					{
						pGrid.DataBind();
						// �������������
						for (int i=0; i <= rc.Count - 1; i++)
						{
							string pdr = "";
							if (rc[i]["GRUP"].ToString() != "9" )		pdr += "������ " + rc[i]["NAIMENOVAN5"].ToString();
							if (rc[i]["OTDELENIE"].ToString() != "9" )	pdr += " ��������� " + rc[i]["NAIMENOVAN4"].ToString();
							if (rc[i]["PODOTDEL"].ToString() != "9" )	pdr += " ��������� " + rc[i]["NAIMENOVAN3"].ToString();
							if (rc[i]["OTDEL"].ToString() != "9" )		pdr += " ������ " + rc[i]["NAIMENOVAN2"].ToString();
							if (rc[i]["UPRAVLENIE"].ToString() != "9" )	pdr += " ���������� " + rc[i]["NAIMENOVAN1"].ToString();
							if (rc[i]["PODR"].ToString() != "9" )		pdr += " " + rc[i]["NAIMENOVAN"].ToString();
							if (rc[i]["PODRAZD"].ToString() != "9" )		pdr += " " + rc[i]["PODRAZDEL"].ToString();

							pGrid.Items[i].Cells[3].Text = pdr;
					
							// ��������� �������
							switch((string)(rc[i]["STATUS"]))
							{
								case "1000" : pGrid.Items[i].Cells[4].Text = "������(�) �� " + rc[i]["OPISANIE"].ToString(); break;
								case "2000" : pGrid.Items[i].Cells[4].Text = "������(�) " + rc[i]["OPISANIE"].ToString(); break;
								case "3000" : pGrid.Items[i].Cells[4].Text = ""; break;
								case "4000" : pGrid.Items[i].Cells[4].Text = "������(�) - " + rc[i]["OPISANIE"].ToString(); break;
								case "5000" : pGrid.Items[i].Cells[4].Text = "��������������(�) � " + rc[i]["OPISANIE"].ToString(); break;
								case "6000" : pGrid.Items[i].Cells[4].Text = "��������(�) � ������ "; break;
								case "7000" : pGrid.Items[i].Cells[4].Text = "��������(�) �� ������� " + rc[i]["OPISANIE"].ToString(); break;
								case "8000" : pGrid.Items[i].Cells[4].Text = "�������(�) �� ��������"; break;
								case "9000" : pGrid.Items[i].Cells[4].Text = "��������(�) �� ���������"; break;
								case "1200" : pGrid.Items[i].Cells[4].Text = "���������(�) � ����������"; break;
								case "1300" : pGrid.Items[i].Cells[4].Text = "�������(�) �� ����.�������"; break;
								case "1400" : pGrid.Items[i].Cells[4].Text = "�������(�) �������������"; break;
								case "1500" : pGrid.Items[i].Cells[4].Text = "��������(�) �� �.�������"; break;
								case "1600" : pGrid.Items[i].Cells[4].Text = "������������(�) �� ������"; break;
								case "1701" : pGrid.Items[i].Cells[4].Text = "���������� �����������"; break;
								case "9002" : pGrid.Items[i].Cells[4].Text = "��������(�) � ������.�������"; break;
								case "9004" : pGrid.Items[i].Cells[4].Text = "�������(�) � ������.�������"; break;
								case "6001" : pGrid.Items[i].Cells[4].Text = "��������� ������"; break;
							}

						}
			
					}
					else
					{
						rc.Clear();
						dt = DataProvider._getDataODBC(String.Format("SELECT DATA_UVOL AS DATA_OT, VOIN_ZVAN, NAM_OF_DOL, PODRAZDEL, P1, NOM_PR_UVO AS NOM_PRIK, DATA_PR_UV AS DATA_PRIK FROM {0}," +
							"ZVANIE.DBF, OFIC_DOL.DBF AS DOL, PODRAZD.DBF, SLVPR2.DBF " +
							"WHERE ZVANIE = KEY_ZVAN AND KTO_UVOLIL = P2 AND " +
                            "PODRAZD = KEY_OF_POD AND DOLZNOST = DOL.P3 AND KEY_1 = {1}", UK.Vars.sbase, id));
                        rc = dt.Rows;
                        dt.Dispose();
						if ( rc.Count != 0 )
						{
							pGrid.DataBind();
							pGrid.Items[0].Cells[3].Text = rc[0]["PODRAZDEL"].ToString();
							pGrid.Items[0].Cells[4].Text = "������";
						}
					}


					// �������� ������
					rc.Clear();
					dt = DataProvider._getDataODBC(String.Format("SELECT DATE_FROM, DATE_TO, KOEF_VISL, LEGEND, NUM_PRIK, SLVPR2.P1, PRIK_DATE FROM LGOTTIME.DBF, SLVPR2 WHERE OVD_PRIK = SLVPR2.P2 AND MAIN_KEY = {0}",id));
					rc = dt.Rows;
                    dt.Dispose();
					if ( rc.Count != 0 )
					{
						kGrid.DataBind();

					} 
					else L_komand.Text = " ��� ";

					// ���������...
					rc.Clear();
					dt = DataProvider._getDataODBC(String.Format("SELECT DAT_NALOZ, S1.P1, N_PRIK_NAL, S2.P1, SODERZANIE, DAT_SNIAT, N_PRIK_SN, WHO_SNIAL FROM NAKAZAN.DBF, SLVPR2.DBF S1, SLVNAK.DBF S2 WHERE (WHO_NALOZ = S1.P2) AND (VID_NAKAZ = S2.P2) AND KEY_1 = {0} ORDER BY DAT_NALOZ",id));
					rc = dt.Rows;
                    dt.Dispose();
					if ( rc.Count != 0 )
					{
						nakGrid.DataBind();
						for (int i=0; i <= rc.Count - 1; i++)
						{
							nakGrid.Items[i].Cells[1].Text = rc[i]["P1"].ToString();
							nakGrid.Items[i].Cells[3].Text = rc[i]["P11"].ToString();
							if ( rc[i]["WHO_SNIAL"] != DBNull.Value )
							{
								dt = DataProvider._getDataODBC(String.Format("SELECT * FROM SLVPR2.DBF WHERE P2 = '{0}'",rc[i]["WHO_SNIAL"].ToString()));
								nakGrid.Items[i].Cells[6].Text = dt.Rows[0]["P1"].ToString();
                                dt.Dispose();
							}
							
						}
						L_nak.Text = rc.Count.ToString();


					} 
					else L_nak.Text = " ��� ";

					// ���������...
					rc.Clear();
					dt = DataProvider._getDataODBC(String.Format("SELECT S1.P1, PRICHINA, S2.P1, NOM_PRIK, DATA_POO FROM POO.DBF, SLVPOO.DBF S1, SLVPR2.DBF S2 WHERE (TYPE_POO = S1.P2) AND (CHEI_PRIK = S2.P2) AND KEY_POO = {0} ORDER BY DATA_POO",id));
					rc = dt.Rows;
                    dt.Dispose();
					if ( rc.Count != 0 )
					{
					  L_poo.Text = rc.Count.ToString();
					} 
					else L_poo.Text = " ��� ";
			
					// ������������...
					s.AddLogText("�������� �/�: " + f_name + "|" + name + "|" + s_name, (string)(Context.Request.UserHostAddress),6,true );
				}
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
			this.viewDataSet = new UK.viewDataSet();
			this.LogsConn = new System.Data.SqlClient.SqlConnection();
			this.AddLogsCmd = new System.Data.SqlClient.SqlCommand();
			((System.ComponentModel.ISupportInitialize)(this.viewDataSet)).BeginInit();
			// 
			// viewDataSet
			// 
			this.viewDataSet.DataSetName = "viewDataSet";
			this.viewDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// LogsConn
			// 
            this.LogsConn.ConnectionString = "Data Source=URLS_SERVER;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*";
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
			this.Unload += new System.EventHandler(this.DetailPage_Unload);
			((System.ComponentModel.ISupportInitialize)(this.viewDataSet)).EndInit();

		}
		#endregion

		protected void DetailPage_Unload(object sender, System.EventArgs e)
		{
			//rc.Clear();
		}

			
		protected void PhotoBtn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("viewphoto.aspx?photo=" + photo_name);
		}

	}
}
