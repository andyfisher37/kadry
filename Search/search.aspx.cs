using System;
using System.Data;
using System.Web.UI;
using System.Web.Caching;
using System.Text;
using System.Collections.Generic;


namespace kadry
{
	/// <summary>
	/// ��������� ������� "�����"
	/// </summary>
	public class search : System.Web.UI.Page
	{
	
		protected System.Web.UI.WebControls.TextBox first_name;
		protected System.Web.UI.WebControls.TextBox name;
		protected System.Web.UI.WebControls.TextBox last_name;
		protected System.Web.UI.WebControls.DropDownList podrList;
        //protected System.Web.UI.WebControls.DropDownList podchList;
        protected System.Web.UI.WebControls.Label podchLabel;
        protected System.Web.UI.WebControls.DropDownList podchList2;
        protected System.Web.UI.WebControls.Label podchLabel2;
		protected System.Web.UI.WebControls.DropDownList nacList;
		protected System.Web.UI.WebControls.DropDownList dolzList;
		protected System.Web.UI.WebControls.DropDownList sluzList;
		protected kadry.nationDataSet nationDataSet;
		protected kadry.mainDataSet mainDataSet;
		protected kadry.sluzDataSet sluzDataSet;
		protected kadry.podrDataSet podrDataSet;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
        protected System.Web.UI.WebControls.SqlDataSource podchDataSource;
        protected System.Web.UI.WebControls.SqlDataSource istDataSource;
		protected System.Web.UI.WebControls.Label FindLabel;
		protected System.Web.UI.WebControls.RadioButton RB1;
		protected System.Web.UI.WebControls.RadioButton RB2;
		protected System.Web.UI.WebControls.RadioButton RadioButton1;
		protected System.Web.UI.WebControls.RadioButton RadioButton2;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Web.UI.WebControls.DropDownList zvanList;
		protected kadry.zvanDataSet zvanDataSet;
		protected System.Web.UI.WebControls.LinkButton ListBtn;
		protected System.Data.SqlClient.SqlConnection LogsConn;
		protected System.Data.SqlClient.SqlCommand AddLogsCmd;
		protected System.Web.UI.WebControls.ImageButton GoBtn;
		protected System.Web.UI.WebControls.DataGrid Grid;
		protected System.Data.Odbc.OdbcConnection odbcConnection;
		protected System.Web.UI.WebControls.RadioButton RadioButton3;
		protected System.Web.UI.WebControls.HyperLink secure_text;
		protected System.Web.UI.WebControls.DropDownList rznakList;
		protected eWorld.UI.MaskedTextBox DateBorn;
		protected System.Web.UI.WebControls.TextBox num_1;
		protected System.Web.UI.WebControls.TextBox num_2;
        protected System.Web.UI.WebControls.TextBox num_3;
		protected System.Web.UI.WebControls.DropDownList Obraz_List;
		protected System.Web.UI.WebControls.DropDownList Type_obr_list;
		protected System.Web.UI.WebControls.TextBox file_num;
		protected System.Web.UI.WebControls.ImageButton Photos_view;
        protected System.Web.UI.WebControls.ImageButton ExcelCopyButton;
        protected System.Web.UI.WebControls.ImageButton WordCopyButton;
        protected System.Web.UI.WebControls.Button ObjButton;
		protected System.Web.UI.WebControls.RadioButton RadioButton4;
		protected System.Web.UI.WebControls.DropDownList DolzList2;
		protected kadry.sluzDataSet phDataSet;
		protected System.Web.UI.WebControls.DropDownList sznakList;
        protected eWorld.UI.MaskedTextBox SDate;
		protected System.Web.UI.WebControls.Label SLabel;
		protected kadry.Search.dolzDataSet dolzDataSet;
        protected eWorld.UI.MaskedTextBox VDDate;
        //protected eWorld.UI.MaskedTextBox Att_Date;
        protected System.Web.UI.WebControls.DropDownList vdznakList;
        protected System.Web.UI.WebControls.DropDownList orderList;
        protected System.Web.UI.WebControls.DropDownList istList;
        //protected System.Web.UI.WebControls.DropDownList AttResList;
        //protected global::System.Web.UI.WebControls.SqlDataSource uvDataSource;
        //protected System.Web.UI.WebControls.CheckBox AttCheckBox;
        //protected System.Web.UI.WebControls.CheckBox NoAttCheckBox;
        protected System.Web.UI.WebControls.CheckBox CheckDecret;
        protected System.Web.UI.WebControls.CheckBox prizCheckBox;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
            if (this.RadioButton1.Checked) 
				{
					kadry.Vars.sbase = "AAQQ.DBF";
                    prizCheckBox.Enabled = true;
                    CheckDecret.Enabled = true;
                    SDate.Enabled = false;

				}
				if (this.RadioButton2.Checked) 
				{
				    kadry.Vars.sbase = "ARCHIVE.DBF";
                    prizCheckBox.Enabled = false;
                    CheckDecret.Enabled = false;
                    SDate.Enabled = true;
				}
				if (this.RadioButton3.Checked) 
				{
					kadry.Vars.sbase = "RESERV.DBF";
                    prizCheckBox.Enabled = true;
                    CheckDecret.Enabled = true;
                    SDate.Enabled = true;
				}
				if (this.RadioButton4.Checked) 
				{
					kadry.Vars.sbase = "VYEZD.DBF";
                    prizCheckBox.Enabled = false;
                    CheckDecret.Enabled = false;
                    SDate.Enabled = true;
				}

			if (!IsPostBack)
			{
				kadry.Security.Security s = new kadry.Security.Security();

				//if (!s.CheckSecurePage(User.Identity.Name,"search.aspx")) Response.Redirect("\\AccessDenied.htm",true);

				Command.CommandText = "SELECT * FROM PODRAZD.DBF WHERE KEY_OF_POD IN (SELECT DISTINCT PODRAZD FROM " + kadry.Vars.sbase + ")";
//				(KEY_OF_POD>=1 AND KEY_OF_POD<=31)OR(KEY_OF_POD IN (54,152,312))
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(podrDataSet);
				podrList.DataBind();
				podrList.Items.Add("��� �������������");
				podrList.Items.FindByText("��� �������������").Value = "0";
				podrList.Items.FindByText("��� �������������").Selected = true;

				Command.CommandText = "SELECT * FROM NACIONAL.DBF WHERE KEY_OF_NAC IN (SELECT DISTINCT NACIONALN FROM " + kadry.Vars.sbase + ") ORDER BY NACION";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(nationDataSet);
				nacList.DataBind();
				nacList.Items.Add("��� ��������������");
				nacList.Items.FindByText("��� ��������������").Value = "0";
				nacList.Items.FindByText("��� ��������������").Selected = true;

				Command.CommandText = "SELECT * FROM SLUZBA.DBF WHERE KEY_OF_SLU IN (SELECT DISTINCT SLUZBA FROM " + kadry.Vars.sbase + ") ORDER BY NAM_OF_SLU";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(sluzDataSet);
				sluzList.DataBind();
				sluzList.Items.Add("��� ������ (����� ���)");
				sluzList.Items.FindByText("��� ������ (����� ���)").Value = "-2";
                sluzList.Items.Add("��� ����������� ����������� ������");
                sluzList.Items.FindByText("��� ����������� ����������� ������").Value = "-3";
				sluzList.Items.Add("��� ������");
				sluzList.Items.FindByText("��� ������").Value = "-1";
				sluzList.Items.FindByText("��� ������").Selected = true;

				Command.CommandText = "SELECT * FROM ZVANIE.DBF WHERE KEY_ZVAN IN (SELECT DISTINCT ZVANIE FROM " + kadry.Vars.sbase + ") ORDER BY VOIN_ZVAN";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(zvanDataSet);
				zvanList.DataBind();
				zvanList.Items.Add("��� ������");
				zvanList.Items.FindByText("��� ������").Value = "-1";
				zvanList.Items.FindByText("��� ������").Selected = true;

				Command.CommandText = "SELECT NAM_OF_DOL, P3 FROM OFIC_DOL ORDER BY NAM_OF_DOL";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(dolzDataSet);
				DolzList2.DataBind();
				DolzList2.Items.Add("�� ����� ��������");
				DolzList2.Items.FindByText("�� ����� ��������").Value = "0";
				DolzList2.Items.FindByText("�� ����� ��������").Selected = true;

                // � 01.01.2012 - ��� �� �����������...
                //istDataSource.SelectCommand = "SELECT * FROM SLVISOD.DBF WHERE CODE IN (SELECT IST_SOD FROM " + kadry.Vars.sbase + ")";
                //istDataSource.DataBind();
                //istList.DataBind();
                //istList.Items.Add("���� �����������");
                //istList.Items.FindByText("���� �����������").Value = "-1";
                //istList.Items.Add("���� ���������");
                //istList.Items.FindByText("���� ���������").Value = "-2";
                //istList.Items.Add("��� ���������");
                //istList.Items.FindByText("��� ���������").Value = "0";
                //istList.Items.FindByText("��� ���������").Selected = true;
                                
                //podrList.Style.Add("Width","300px");			
                //nacList.Style.Add("Width","300px");
                //sluzList.Style.Add("Width","300px");
                //zvanList.Style.Add("Width","300px");
                //dolzList.Style.Add("Width","300px");
                //Obraz_List.Style.Add("Width","300px");
                //DolzList2.Style.Add("Width","300px");
                //Type_obr_list.Style.Add("Width","300px");
                //first_name.Style.Add("Width","152px");
                //name.Style.Add("Width","152px");
                //last_name.Style.Add("Width","152px");
                ////num_1.Style.Add("Width","32px");
                ////num_2.Style.Add("Width","103px");
                ////num_3.Style.Add("Width","100px");
                //file_num.Style.Add("Width","70px");
                //rznakList.Style.Add("Width","50px");
                //DateBorn.Style.Add("Width","100px");

				DateBorn.Text = "";
				Photos_view.Visible = false;
             
			}
			
		}

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
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.odbcConnection = new System.Data.Odbc.OdbcConnection();
			this.podrDataSet = new kadry.podrDataSet();
			this.nationDataSet = new kadry.nationDataSet();
			this.mainDataSet = new kadry.mainDataSet();
			this.sluzDataSet = new kadry.sluzDataSet();
			this.zvanDataSet = new kadry.zvanDataSet();
			this.LogsConn = new System.Data.SqlClient.SqlConnection();
			this.AddLogsCmd = new System.Data.SqlClient.SqlCommand();
			this.dolzDataSet = new kadry.Search.dolzDataSet();
			this.phDataSet = new kadry.sluzDataSet();
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nationDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.zvanDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dolzDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.phDataSet)).BeginInit();
			this.first_name.TextChanged += new System.EventHandler(this.first_name_TextChanged);
			this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
			this.last_name.TextChanged += new System.EventHandler(this.last_name_TextChanged);
			this.num_1.TextChanged += new System.EventHandler(this.num_1_TextChanged);
			this.rznakList.SelectedIndexChanged += new System.EventHandler(this.rznakList_SelectedIndexChanged);
			this.Photos_view.Click += new System.Web.UI.ImageClickEventHandler(this.Photos_view_Click);
			this.Grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.Grid_ItemDataBound);
            this.ObjButton.Click += new System.EventHandler(this.ObjButton_Click);
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// Command
			// 
			this.Command.Connection = this.odbcConnection;
			// 
			// odbcConnection
			// 
			this.odbcConnection.ConnectionString = "PageTimeout=0;FIL=dBase 5.0;MaxBufferSize=2048;DSN=KADRY;DefaultDir=C:\\KADRY;Driv" +
				"erId=533";
			// 
			// podrDataSet
			// 
			this.podrDataSet.DataSetName = "podrDataSet";
			this.podrDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// nationDataSet
			// 
			this.nationDataSet.DataSetName = "nationDataSet";
			this.nationDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// mainDataSet
			// 
			this.mainDataSet.DataSetName = "mainDataSet";
			this.mainDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sluzDataSet
			// 
			this.sluzDataSet.DataSetName = "sluzDataSet";
			this.sluzDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// zvanDataSet
			// 
			this.zvanDataSet.DataSetName = "zvanDataSet";
			this.zvanDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
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
			// 
			// dolzDataSet
			// 
			this.dolzDataSet.DataSetName = "dolzDataSet";
			this.dolzDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// phDataSet
			// 
			this.phDataSet.DataSetName = "phDataSet";
			this.phDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.Unload += new System.EventHandler(this.search_Unload);
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nationDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.zvanDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dolzDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.phDataSet)).EndInit();

		}
		

		 protected void GoBtn_Click1(object sender, ImageClickEventArgs e)
        {
        
			kadry.Security.Security s = new kadry.Security.Security();

			string LogText = "";
			secure_text.Text = "";
					
			this.first_name_TextChanged(sender, e);
			this.name_TextChanged(sender, e);
			this.last_name_TextChanged(sender, e);

			Command.CommandText = "SELECT KEY_1, FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, PODRAZD, REAL_DOLZN, PODRAZDEL, NAM_OF_SLU, dolz1.NAM_OF_DOL, dolz2.NAM_OF_DOL, VOIN_ZVAN, LICH_NOM_1, LICH_NOM_2, IST.`TEXT`, NOMLICHDEL FROM ";
 
			if (this.RadioButton1.Checked) 
			{
				Command.CommandText += " AAQQ.DBF ";
				kadry.Vars.sbase = "AAQQ.DBF";
				LogText += " (�����������) ";
			}
			if (this.RadioButton2.Checked) 
			{
				Command.CommandText += " ARCHIVE.DBF ";
				kadry.Vars.sbase = "ARCHIVE.DBF";
				LogText += " (���������) ";
			}
			if (this.RadioButton3.Checked) 
			{
				Command.CommandText += " RESERV.DBF ";
				kadry.Vars.sbase = "RESERV.DBF";
				LogText += " (� ������������) ";
			}
			if (this.RadioButton4.Checked) 
			{
				Command.CommandText += " VYEZD.DBF ";
				kadry.Vars.sbase = "VYEZD.DBF";
				LogText += " (�����������������) ";
			}

			Command.CommandText += ", PODRAZD.DBF, SLUZBA.DBF, ZVANIE.dbf, OFIC_DOL.dbf dolz1, ofic_dol.dbf dolz2, SLVISOD.dbf IST WHERE (IST_SOD = IST.CODE) AND (dolz2.P3 = REAL_DOLZN) AND (KEY_OF_POD = PODRAZD) AND (SLUZBA = KEY_OF_SLU) AND (ZVANIE = KEY_ZVAN) AND (dolz1.P3 = DOLZNOST) AND FAMILIYA <> \'\' ";

			// �.�.�.
			if (first_name.Text != "")
			{
				Command.CommandText += " AND FAMILIYA LIKE '" + first_name.Text + "%'";
				LogText += first_name.Text + "|";			
			} 
			
			if (name.Text != "") 
			{
				Command.CommandText += " AND IMYA LIKE '" + name.Text + "%'";
				LogText += name.Text + "|";				
			} 
			
			if (last_name.Text != "")
			{
				Command.CommandText += " AND OTCHECTVO LIKE '" + last_name.Text + "%'";
				LogText += last_name.Text + "|";				
			}

			// ������ �����
			if ( num_1.Text != "" )
			{
				Command.CommandText += " AND LICH_NOM_1 = '" + num_1.Text + "'";
				LogText += num_1.Text + "|";				
			}
			if ( num_2.Text != "" && num_3.Text == "")
			{
				Command.CommandText += " AND LICH_NOM_2 = '" + num_2.Text + "'";
				LogText += num_2.Text + "|";				
			}
            if (num_2.Text != "" && num_3.Text != "")
            {
                Command.CommandText += " AND (LICH_NOM_2 >= '" + num_2.Text + "' AND LICH_NOM_2 <= '" + num_3.Text + "')";
                LogText += "c " + num_2.Text + " �� " + num_3.Text;				
            }
			// � ������� ����
			if ( file_num.Text != "" )
			{
				Command.CommandText += " AND NOMLICHDEL = " + Convert.ToInt16(file_num.Text);
				LogText += file_num.Text + "|";				
			}
			// ���� ��������
			if ( rznakList.SelectedItem.Value != "0" )
			{
				Command.CommandText += " AND DATA_ROZD " + rznakList.SelectedItem.Text + " " + Convert.ToDateTime(DateBorn.Text).ToOADate();
				LogText += "���� �������� " + rznakList.SelectedItem.Text + " " + DateBorn.Text +  "|";
			}

			// ���� ���������� (����������������)
			if ( sznakList.SelectedItem.Value != "0" )
			{
                if (kadry.Vars.sbase == "RESERV.DBF")
                {
                    Command.CommandText += " AND PRIMECHAN <> '��������� ������' AND DATA_ZACH " + sznakList.SelectedItem.Text + " " + Convert.ToDateTime(SDate.Text).ToOADate();
                    LogText += "���� ������.� ��������." + sznakList.SelectedItem.Text + " " + SDate.Text + "|";
                }
                else
                {
                    Command.CommandText += " AND DATA_UVOL " + sznakList.SelectedItem.Text + " " + Convert.ToDateTime(SDate.Text).ToOADate();
                    LogText += "���� ���������� (��������.) " + sznakList.SelectedItem.Text + " " + SDate.Text + "|";
                }
			}

            // ���� � ���������
            if ( vdznakList.SelectedItem.Value != "0" )
            {
                Command.CommandText += " AND DATA_VDOLZ " + vdznakList.SelectedItem.Text + " " + Convert.ToDateTime(VDDate.Text).ToOADate();
                LogText += "� ��������� " + vdznakList.SelectedItem.Text + " " + VDDate.Text + "|";
            }

			// ����� �������������
			if ( podrList.SelectedItem.Value != "0" )
			{
				Command.CommandText += " AND PODRAZD IN (" + podrList.SelectedItem.Value + ") ";
				Grid.Columns[4].Visible = false;
				LogText += podrList.SelectedItem.Text + "|";				
			} 
			else Grid.Columns[4].Visible = true;

            // ����� ������������...
            //if (podchList.Visible)
            //{
            //    // ��������� �����������...
            //    if (podchList.SelectedItem.Value != "-1" && podchList.SelectedItem.Value != "-2")
            //    {
            //        Command.CommandText += " AND PODR = " + podchList.SelectedItem.Value;
            //        LogText += podchList.SelectedItem.Text + "|" + podchList.SelectedItem.Value;
            //    }
            //    // ������ ������� (��� �����������)
            //    else if (podchList.SelectedItem.Value == "-2")
            //    {
            //        Command.CommandText += " AND PODR = 9";
            //        LogText += podchList.SelectedItem.Text + "|";
            //    }
            //    else if (podchList.SelectedItem.Value != "-1")
            //    {
            //        //Command.CommandText += " AND PODR = " + podchList.SelectedItem.Value;
            //        LogText += podchList.SelectedItem.Text + "|���� �������";
            //    }
            //}
			
			// ����� ������
			if ( sluzList.SelectedItem.Value != "-1" )
			{
				if (sluzList.SelectedItem.Value != "-2" )
				{
                // ����������� ��������� ���������� �����...
				// ��
                    if (sluzList.SelectedItem.Value == "1") Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
                    else
                        // ���
                        if (sluzList.SelectedItem.Value == "2") Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
                        else
                            // �����
                            if (sluzList.SelectedItem.Value == "4") Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
                            else
                                // ���
                                if (sluzList.SelectedItem.Value == "5") Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) ";
                                else
                                    // ���
                                    if (sluzList.SelectedItem.Value == "9") Command.CommandText += " AND SLUZBA IN (9,52) ";
                                    else
                                        // ���������
                                        if (sluzList.SelectedItem.Value == "10") Command.CommandText += " AND SLUZBA IN (10,55) ";
                                        else
                                            // �����
                                            if (sluzList.SelectedItem.Value == "11") Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
                                            else
                                                // ��
                                                if (sluzList.SelectedItem.Value == "24") Command.CommandText += " AND SLUZBA IN (24,25) ";
                                                else
                                                    // ���
                                                    if (sluzList.SelectedItem.Value == "29") Command.CommandText += " AND SLUZBA IN (29,54) ";
                                                    else
                                                        // ���������
                                                        if (sluzList.SelectedItem.Value == "33") Command.CommandText += " AND SLUZBA IN (33,63) ";
                                                        else
                                                            // ���.�������
                                                            if (sluzList.SelectedItem.Value == "40") Command.CommandText += " AND SLUZBA IN (40,60) ";
                                                            else
                                                                // ������
                                                                if (sluzList.SelectedItem.Value == "43") Command.CommandText += " AND SLUZBA IN (43,58) ";
                                                                else
                                                                    // ����
                                                                    if (sluzList.SelectedItem.Value == "44") Command.CommandText += " AND SLUZBA IN (44,59) ";
                                                                    else
                                                                        // ��
                                                                        if (sluzList.SelectedItem.Value == "78") Command.CommandText += " AND SLUZBA IN (78,64) ";
                                                                        else
                                                                            // ���
                                                                            if (sluzList.SelectedItem.Value == "85") Command.CommandText += " AND SLUZBA IN (85,66) ";
                                                                            else
                                                                                if (sluzList.SelectedItem.Value == "-3") Command.CommandText += " AND (dolz2.nam_of_dol like '����������� ���������� ���%' or dolz2.nam_of_dol like '����������� ���������� ���%')";

                                                                                else Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
				} else 	Command.CommandText += " AND SLUZBA NOT IN (9,52) ";

				Grid.Columns[5].Visible = false;
				LogText += sluzList.SelectedItem.Text + "|";		
			} 
			else Grid.Columns[5].Visible = true;
			
			// ����� ��������� ���������
			if ( dolzList.SelectedValue != "0" )
			{
				LogText += dolzList.SelectedItem.Text + "|";
			
				if ( dolzList.SelectedValue == "-1" )
				{
					Command.CommandText += " AND DOLZNOST < '800000'";
				}
				if ( dolzList.SelectedValue == "1" )
				{
					Command.CommandText += " AND DOLZNOST < '200000'";
				}
				if ( dolzList.SelectedValue == "2" )
				{
					Command.CommandText += " AND DOLZNOST < '500000'";
				}
				if ( dolzList.SelectedValue == "3" )
				{
					Command.CommandText += " AND DOLZNOST BETWEEN '500000' AND '800000'";
				}
				if ( dolzList.SelectedValue == "4" )
				{
                    Command.CommandText += " AND DOLZNOST > '800000' AND POTOLOK NOT IN (80,81,82,83,84,85)";
				}
                if (dolzList.SelectedValue == "5")
                {
                    Command.CommandText += " AND DOLZNOST > '800000' AND POTOLOK IN (80,81,82,83,84,85)";
                }
			}

            // ����� ���������
            //if (istList.SelectedValue == "-1")
            //{
            //    Command.CommandText += " AND IST_SOD IN (1,5,15,21,97)";
            //}
            //else if (istList.SelectedValue == "-2")
            //{
            //    Command.CommandText += " AND IST_SOD IN (2,95,109)";
            //}
            //else if (istList.SelectedValue != "0")
            //{
            //    Command.CommandText += " AND IST_SOD = " + istList.SelectedItem.Value;
            //}

			// ����� ���������� ���������
			if ( DolzList2.SelectedValue != "0" )
			{
				LogText += DolzList2.SelectedItem.Text + "|";
				Command.CommandText += " AND DOLZNOST = '" + DolzList2.SelectedItem.Value + "' ";
			} 

				// ����� ��������������
				if ( nacList.SelectedValue != "0" )
			{
				Command.CommandText += " AND NACIONALN = " + nacList.SelectedValue;
				LogText += nacList.SelectedItem.Text + "|";
			}
			
			// ����� ������������ ������
			if ( zvanList.SelectedValue != "-1" )
			{
				Command.CommandText += " AND ZVANIE = " + zvanList.SelectedValue;
				LogText += zvanList.SelectedItem.Text;
			}

			// ������� �����������
			if ( Obraz_List.SelectedValue != "0" )
			{
				Command.CommandText += " AND OBRAZ_LIC2 = '" + Obraz_List.SelectedValue + "'";
				LogText += "|��� ����������� - " + Obraz_List.SelectedValue;
			}

			// ��� �����������
			if ( Type_obr_list.SelectedValue != "0" )
			{
				Command.CommandText += " AND OBRAZ_LIC1 = '" + Type_obr_list.SelectedValue + "'";
				LogText += "|��� ����������� - " + Type_obr_list.SelectedValue;
			}

            //// ���� ������������ ����������
            //if ((kadry.Vars.sbase == "AAQQ.DBF" || kadry.Vars.sbase == "RESERV.DBF") && (Att_Date.Text != ""))
            //{
            //    string att_keys = "";
            //    uvDataSource.SelectCommand = "SELECT id FROM PoliceAttestation WHERE att_date = convert(smalldatetime,'" + Att_Date.Text + "',104)";
            //    //uvDataSource.SelectParameters.Add("key", mainDataSet._Table.Rows[i]["KEY_1"].ToString());
            //    DataView dv = new DataView();
            //    dv = (DataView)uvDataSource.Select(DataSourceSelectArguments.Empty);
            //    if (dv.Table.Rows.Count > 0)
            //    {
            //        for (int n = 0; n < dv.Table.Rows.Count; n++)
            //        {
            //            att_keys += dv.Table.Rows[n][0].ToString();
            //            if (n <= dv.Table.Rows.Count) att_keys += ",";
            //        }
            //        Command.CommandText += " AND KEY_1 IN (" + att_keys + ") ";
            //    }
            //    dv.Dispose();
            //    uvDataSource.SelectParameters.Clear();
            //}

            //// ������������ ���������� (���������)
            //if ((kadry.Vars.sbase == "AAQQ.DBF" || kadry.Vars.sbase == "RESERV.DBF") && AttCheckBox.Checked)
            //{
            //    string att_keys = "";
            //    uvDataSource.SelectCommand = "SELECT id FROM PoliceAttestation WHERE att_date is not null";

            //    if (AttResList.SelectedValue != "0" ) uvDataSource.SelectCommand += " and resolution = " + AttResList.SelectedValue;

            //    DataView dv = new DataView();
            //    dv = (DataView)uvDataSource.Select(DataSourceSelectArguments.Empty);
            //    if (dv.Table.Rows.Count > 0)
            //    {
            //        for (int n = 0; n < dv.Table.Rows.Count; n++)
            //        {
            //            att_keys += dv.Table.Rows[n][0].ToString();
            //            if (n <= dv.Table.Rows.Count) att_keys += ",";
            //        }
            //        Command.CommandText += " AND KEY_1 IN (" + att_keys + ") ";
            //    }
            //    dv.Dispose();
            //    uvDataSource.SelectParameters.Clear();
            //}

            //// ������������ ���������� (�����������)
            //if ((kadry.Vars.sbase == "AAQQ.DBF" || kadry.Vars.sbase == "RESERV.DBF") && NoAttCheckBox.Checked)
            //{
            //    string att_keys = "";
            //    uvDataSource.SelectCommand = "SELECT id FROM PoliceAttestation WHERE att_date is not null";
            //    //uvDataSource.SelectParameters.Add("key", mainDataSet._Table.Rows[i]["KEY_1"].ToString());
            //    DataView dv = new DataView();
            //    dv = (DataView)uvDataSource.Select(DataSourceSelectArguments.Empty);
            //    if (dv.Table.Rows.Count > 0)
            //    {
            //        for (int n = 0; n < dv.Table.Rows.Count; n++)
            //        {
            //            att_keys += dv.Table.Rows[n][0].ToString();
            //            if (n <= dv.Table.Rows.Count) att_keys += ",";
            //        }
            //        Command.CommandText += " AND KEY_1 NOT IN (" + att_keys + ") ";
            //    }
            //    dv.Dispose();
            //    uvDataSource.SelectParameters.Clear();
            //}

            // ����������...
            if ((kadry.Vars.sbase == "AAQQ.DBF" || kadry.Vars.sbase == "RESERV.DBF") && CheckDecret.Checked)
            {
                Command.CommandText += " AND PRIMECHAN LIKE '%�����%'";
                LogText += "|������ ����������";
            }

            // ����������...
            if ((kadry.Vars.sbase == "AAQQ.DBF" || kadry.Vars.sbase == "RESERV.DBF") && prizCheckBox.Checked)
            {
                Command.CommandText += " AND DATA_ROZD > " + Convert.ToDateTime(DateTime.Now.AddYears(-27).ToShortDateString()).ToOADate() + " AND SLVARM_OT IS NULL AND KEY_1 NOT IN (SELECT DISTINCT KEY_1 FROM VUCHET WHERE SOSTAV <> 5) ";
                LogText += "|������ ����������";
            }

			// ����������� ����������� �� ������� � ��������������...
			string secure_sluzb = s.GetSecureSluzb(User.Identity.Name);
			if (secure_sluzb != "")	
			{
				Command.CommandText += " AND SLUZBA NOT IN (" + secure_sluzb + ") ";
				secure_text.Text = "!�����������! - �� �������";
			}
			string secure_podrazd = s.GetSecurePodrazd(User.Identity.Name);
			if (secure_podrazd != "")	
			{
				Command.CommandText += " AND PODRAZD NOT IN (" + secure_podrazd + ") ";
				secure_text.Text += ",�� ��������������";
			}

			string secure_podr = s.GetSecurePodr(User.Identity.Name);
			if (secure_podr != "")	
			{
				Command.CommandText += " AND PODR NOT IN (" + secure_podr + ") ";
				secure_text.Text += ",�� ����������� ��������������";
			}
			secure_text.NavigateUrl = "../denied_expl.aspx?User=" + User.Identity.Name +
										"&sl=" + secure_sluzb +
										"&podr=" + secure_podrazd +
										"&pdr=" + secure_podr;


            if (orderList.SelectedValue == "0") Command.CommandText += " ORDER BY FAMILIYA";
            if (orderList.SelectedValue == "1") Command.CommandText += " ORDER BY DATA_ROZD";
            if (orderList.SelectedValue == "2") Command.CommandText += " ORDER BY PODRAZD";
            if (orderList.SelectedValue == "3") Command.CommandText += " ORDER BY NAM_OF_SLU";
            if (orderList.SelectedValue == "4") Command.CommandText += " ORDER BY REAL_DOLZN";
            if (orderList.SelectedValue == "5") Command.CommandText += " ORDER BY VOIN_ZVAN";
            if (orderList.SelectedValue == "6") Command.CommandText += " ORDER BY LICH_NOM_1, LICH_NOM_2";

					
			// �������...
			//this.Page.Response.Write(Command.CommandText);
			
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(mainDataSet);
			    
   			    Grid.Visible = true;
			    Grid.Columns[9].HeaderText = "���.���.<br><a href='..//istsodhlp.htm'><img src='..//images//btn_help.gif' border=0 alt='����������� ���������� ��������������...'></a>";
			    			    
				
				if (mainDataSet._Table.Count !=0 ) // ���� ����-�� �����...
				{
					s.AddLogText("������ �� �����: " + LogText, Context.Request.UserHostAddress.ToString(),4,true);
					kadry.Vars.Keys = "";							
					FindLabel.CssClass = "maintext";
					FindLabel.Text = "�������: " + mainDataSet._Table.Count.ToString() + " �������(�)";
		
					// ���� �� ��������� ��������...��������������
//					if (Check1.Checked)
//					{
//						kadry.Vars.CmdText = Command.CommandText;
//						string Params = "";
//
////						if (Check2.Checked)	Params += "photo=1";
////						else Params += "photo=0";
//
//						if (podrList.SelectedValue != "0") Params += "&podr=false";
//						else Params += "&podr=true";
//
//						if (sluzList.SelectedValue != "-1") Params += "&sluz=false";
//						else Params += "&sluz=true";
//									
//						if (zvanList.SelectedValue != "-1") Params += "&zvan=false";
//						else Params += "&zvan=true";
//
//						if ( nacList.SelectedValue != "0" ) Params += "&nation=" + nacList.SelectedItem.Text;
//						else Params += "&nation=all";
//
//						if ( secure_text.Text != "" )
//						{
//							Params += "&s_text=" + secure_text.Text;
//						}
//					
//						Response.Redirect("../DetailList.aspx?" + Params,false);
//					
//					}
//					// ���� � ��������� ������� ����...
//					if (Check2.Checked)
//					{
//						// ��������� ��������� "����"
//						Grid.Columns.AddAt(9, new TemplateColumn());
//						Grid.Columns[9].HeaderText = "����";
//						Grid.Columns[9].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
//						Grid.Columns[9].ItemStyle.VerticalAlign = VerticalAlign.Middle;
//						Grid.Columns[9].ItemStyle.Font.Name = "Verdana";
//						Grid.Columns[9].ItemStyle.Font.Bold = true;
//						Grid.Columns[9].ItemStyle.Width = Unit.Percentage(3);
//
//						Grid.DataBind();
//
//						for (int i = 0; i <= mainDataSet._Table.Rows.Count - 1; i++ )
//						{
//							// ����������� ��������� ��� ���������...
//							if ( Convert.ToString(mainDataSet._Table.Rows[i]["nam_of_dol"]) != Convert.ToString(mainDataSet._Table.Rows[i]["nam_of_dol1"]) )
//							{
//								Grid.Items[i].Cells[6].Text = mainDataSet._Table.Rows[i]["nam_of_dol1"] + " (�� ���� - " +
//									mainDataSet._Table.Rows[i]["nam_of_dol"] + ")";
//							}
//							
//							kadry.Vars.Keys += mainDataSet._Table.Rows[i]["KEY_1"].ToString() + ",";
//
//							Command.CommandText = "SELECT PHOTO FROM photos WHERE KEY_1 = " + Convert.ToString(mainDataSet._Table.Rows[i]["KEY_1"]);
//							if ( odbcConnection.State != ConnectionState.Open ) odbcConnection.Open();
//							string ph = (string)Command.ExecuteScalar();
//							if ( ph != "")
//							{
//								Grid.Items[i].Cells[9].Text = "v";
//							}
//							else 
//							{
//								Grid.Items[i].Cells[9].Text = "";
//							}
//
//							// ��������� �������� ����� ������� ������...
//							Grid.Items[i].Cells[8].Text += "-" + mainDataSet._Table.Rows[i]["lich_nom_2"];
//												
//						}
//						
//					} 
//					else
//					{
				
						// ��������� �������� ����� ������� ������...
						Grid.DataBind();			
						for (int i = 0; i <= mainDataSet._Table.Rows.Count - 1; i++ )
						{
							// ����������� ��������� ��� ���������...
							if ( Convert.ToString(mainDataSet._Table.Rows[i]["nam_of_dol"]) != Convert.ToString(mainDataSet._Table.Rows[i]["nam_of_dol1"]) )
							{
								Grid.Items[i].Cells[6].Text = mainDataSet._Table.Rows[i]["nam_of_dol1"] + " (�� ���� - " +
									mainDataSet._Table.Rows[i]["nam_of_dol"] + ")";
								
							}
                            kadry.Vars.Keys += mainDataSet._Table.Rows[i]["KEY_1"].ToString() + ",";
							Grid.Items[i].Cells[8].Text += "-" + mainDataSet._Table.Rows[i]["lich_nom_2"];

                            //if (kadry.Vars.sbase == "AAQQ.DBF" || kadry.Vars.sbase == "RESERV.DBF")
                            //{
                            //    // ��������� ������� �����.����������...
                            //    Grid.Columns[11].Visible = true;
                            //    uvDataSource.SelectCommand = "SELECT att_date FROM PoliceAttestation WHERE id = @key";
                            //    uvDataSource.SelectParameters.Add("key", mainDataSet._Table.Rows[i]["KEY_1"].ToString());
                            //    DataView dv = new DataView();
                            //    dv = (DataView)uvDataSource.Select(DataSourceSelectArguments.Empty);
                            //    if (dv.Table.Rows.Count > 0)
                            //    {
                            //        if (dv.Table.Rows[0][0] != DBNull.Value)
                            //            Grid.Items[i].Cells[11].Text = Convert.ToDateTime(dv.Table.Rows[0][0]).ToShortDateString();
                            //    }
                                
                                //dv.Dispose();
                                //uvDataSource.SelectParameters.Clear();
                            //    }
                            //if (kadry.Vars.sbase == "AAQQ.DBF" || kadry.Vars.sbase == "RESERV.DBF")
                            //{
                            //    // ��������� ������� ����������� �� ����������...
                            //    Grid.Columns[11].Visible = true;
                            //    Grid.Columns[12].Visible = true;
                            //    uvDataSource.SelectCommand = "SELECT date_notification_print, date_notification_give FROM Notification WHERE id = @key";
                            //    uvDataSource.SelectParameters.Add("key", mainDataSet._Table.Rows[i]["KEY_1"].ToString());
                            //    DataView dv = new DataView();
                            //    dv = (DataView)uvDataSource.Select(DataSourceSelectArguments.Empty);
                            //    if (dv.Table.Rows.Count > 0)
                            //    {
                            //        if (dv.Table.Rows[0][0] != DBNull.Value)
                            //            Grid.Items[i].Cells[11].Text = Convert.ToDateTime(dv.Table.Rows[0][0]).ToShortDateString();
                            //        if (dv.Table.Rows[0][1] != DBNull.Value)
                            //            Grid.Items[i].Cells[12].Text = Convert.ToDateTime(dv.Table.Rows[0][1]).ToShortDateString();

                            //    }
                            //    dv.Dispose();
                            //    uvDataSource.SelectParameters.Clear();
                            //}
                            //else
                            //{
                            //    Grid.Columns[11].Visible = false;

                            //}
						}
						
//					}

					if ( nacList.SelectedValue != "0" ) FindLabel.Text += ", ������ (" + nacList.SelectedItem.Text + ")";
				
					// �������� �������� ������� � �������...
					if (podrList.SelectedValue != "0")
					{
						Grid.Columns[4].Visible = false;
						FindLabel.Text += ", ������ (" + podrList.SelectedItem.Text + ")";
					} 
					else Grid.Columns[4].Visible = true;

                    //if (podchList.Visible)
                    //{
                    //    FindLabel.Text += ", ������ (" + podchList.SelectedItem.Text + ")";
                    //}
                    
					if (sluzList.SelectedValue != "-1")
					{
						Grid.Columns[5].Visible = false;
						FindLabel.Text += ", ������ (" + sluzList.SelectedItem.Text + ")";
					} 
					else Grid.Columns[5].Visible = true;
				
					if (zvanList.SelectedValue != "-1")
					{
						Grid.Columns[7].Visible = false;
						FindLabel.Text += ", ������ (" + zvanList.SelectedItem.Text + ")";
					} 
					else Grid.Columns[7].Visible = true;

//					if (Check2.Checked && !Check3.Checked) Grid.Columns[10].Visible = false;

                    ExcelCopyButton.Visible = true;
                    WordCopyButton.Visible = true;

                    //if ( (kadry.Vars.Keys.Split(Convert.ToChar(","))).Length > 1)
                    //{
                    //    ObjButton.Visible = true;
                    //}
                    
				}
				else
				{
					s.AddLogText("������ �� �����: " + LogText, Convert.ToString(Context.Request.UserHostAddress),5,false);
		
					Grid.DataBind();
					FindLabel.CssClass = "Attantion";
					FindLabel.Text = "�� ������� �� ������ ����������, ���������� �������� ��������� �������...";
				
				}
			
			if ( mainDataSet._Table.Rows.Count != 0 )
			{
				kadry.Vars.Keys = kadry.Vars.Keys.Substring(0,kadry.Vars.Keys.Length-1);
				if ( mainDataSet._Table.Rows.Count > 1 ) Photos_view.Visible = true;
				else Photos_view.Visible = false;
			}

            s.Dispose();
            dolzDataSet.Dispose();
            mainDataSet.Dispose();
            nationDataSet.Dispose();
            sluzDataSet.Dispose();
            podrDataSet.Dispose();
            zvanDataSet.Dispose();
            phDataSet.Dispose();
		}


		private void last_name_TextChanged(object sender, System.EventArgs e)
		{
			if (last_name.Text.Length != 0)
			{
				string tmp = Convert.ToString(last_name.Text[0]);
				last_name.Text = tmp.ToUpper() + last_name.Text.Substring(1,last_name.Text.Length-1).ToLower();
			}
		}

		private void name_TextChanged(object sender, System.EventArgs e)
		{
			if (name.Text.Length != 0 )
			{
				string tmp = Convert.ToString(name.Text[0]);
				name.Text = tmp.ToUpper() + name.Text.Substring(1,name.Text.Length-1).ToLower();
			}
		}

		private void first_name_TextChanged(object sender, System.EventArgs e)
		{
			if (first_name.Text.Length != 0) 
			{
				string tmp = Convert.ToString(first_name.Text[0]);
				first_name.Text = tmp.ToUpper() + first_name.Text.Substring(1,first_name.Text.Length-1).ToLower();
			}
		}

		private void search_Unload(object sender, System.EventArgs e)
		{
			odbcConnection.Dispose();
		}

		private void rznakList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (rznakList.SelectedItem.Value == "0") DateBorn.Text = "";
		}

		private void num_1_TextChanged(object sender, System.EventArgs e)
		{
			if (num_1.Text != "") num_1.Text = num_1.Text.ToUpper();
		}

		private void Photos_view_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string[] keys = kadry.Vars.Keys.Split(Convert.ToChar(","));

            DataSet ds = new DataSet();
            ds.Tables.Add();
            ds.Tables[0].Columns.Add("KEY_1");
            ds.Tables[0].Columns.Add("FAMILIYA");
            ds.Tables[0].Columns.Add("IMYA");
            ds.Tables[0].Columns.Add("OTCHECTVO");
            ds.Tables[0].Columns.Add("PHOTO");
                                    
			for(int i=0; i < keys.Length; i++)
			{

				System.Data.DataRow row = ds.Tables[0].NewRow();

				row["KEY_1"] = keys[i];
                row["FAMILIYA"] = Grid.Items[i].Cells[0].Text;
                row["IMYA"] = Grid.Items[i].Cells[1].Text;
				row["OTCHECTVO"] = Grid.Items[i].Cells[2].Text;
				
                Command.CommandText = "SELECT PHOTO FROM photos WHERE KEY_1 = " + keys[i];
				
				if ( odbcConnection.State != ConnectionState.Open ) odbcConnection.Open();

				string ph = (string)Command.ExecuteScalar();
				
                if ( ph != "" ) row["PHOTO"] = ph;
				ds.Tables[0].Rows.Add(row);
			}
			
			Cache.Remove("photos");
			Cache.Add( "photos", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.High, null );
			Response.Redirect("../PhotoList.aspx");
		}

		private void Grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{	

//			if (e.Item.ItemType == ListItemType.AlternatingItem && e.Item.ItemIndex > 0 )
//			{
//				for(int i=0;i<e.Item.Cells.Count;i++)
//				{
//					e.Item.Cells[i].ToolTip = "�������-����������";
//				}

				//if ( e.Item.Cells[e.Item.ItemType = ListItemType.Cells.Count].Text == ">" )
				//	e.Item.Cells[e.Item.Cells.Count].ToolTip = " �������-���������� ";

				//for(int i=0;i<e.Item.Cells.Count;i++)
				//{
				//	e.Item.Cells[i].ToolTip = e.Item.Cells[i].Text;
				//}
			//}
		}

        // �������� �� ����������� � ������� ��������� 
        //protected void podrList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // ���� ������ ������� ��� ��� ���� -> ���������� ����������� �������������...
        //    if (podrList.SelectedItem.Value == "1")
        //    {
        //        podchLabel.Visible = true;
        //        podchList.Visible = true;
        //        podchDataSource.SelectCommand = "SELECT NAIMENOVAN, KEY_OF_NAI FROM NAIMEN WHERE KEY_OF_NAI IN (SELECT DISTINCT PODR FROM AAQQ WHERE PODR <> 9 AND PODRAZD = 1) ORDER BY NAIMENOVAN";
        //        podchDataSource.DataBind();
        //        podchList.DataBind();
        //        podchList.Items.Add("������ ������� ��� (��� �����������)");
        //        podchList.Items.FindByText("������ ������� ��� (��� �����������)").Value = "-2";
        //        podchList.Items.Add("���� ������� ���");
        //        podchList.Items.FindByText("���� ������� ���").Value = "-1";
        //        podchList.Items.FindByText("���� ������� ���").Selected = true;
        //    }
        //    else if (podrList.SelectedItem.Value == "54")
        //    {
        //        podchLabel.Visible = true;
        //        podchList.Visible = true;
        //        podchDataSource.SelectCommand = "SELECT NAIMENOVAN, KEY_OF_NAI FROM NAIMEN WHERE KEY_OF_NAI IN (SELECT DISTINCT PODR FROM AAQQ WHERE PODR <> 9 AND PODRAZD = 54) ORDER BY NAIMENOVAN";
        //        podchDataSource.DataBind();
        //        podchList.DataBind();
        //        podchList.Items.Add("������ ������� ��� (��� �����������)");
        //        podchList.Items.FindByText("������ ������� ��� (��� �����������)").Value = "-2";
        //        podchList.Items.Add("���� ������� ����");
        //        podchList.Items.FindByText("���� ������� ����").Value = "-1";
        //        podchList.Items.FindByText("���� ������� ����").Selected = true;
        //    }
        //    else if (podrList.SelectedItem.Value == "583")
        //    {
        //        podchLabel.Visible = true;
        //        podchList.Visible = true;
        //        podchLabel2.Visible = true;
        //        podchList2.Visible = true;

        //        podchDataSource.SelectCommand = "SELECT NAIMENOVAN, KEY_OF_NAI FROM NAIMEN WHERE KEY_OF_NAI IN (SELECT DISTINCT PODR FROM AAQQ WHERE (PODRAZD = 583 AND PODR <> 9)) ORDER BY NAIMENOVAN";
        //        podchDataSource.DataBind();
        //        podchList.DataBind();
        //        podchList.Items.Add("������ ������� ���� (��� �����������)");
        //        podchList.Items.FindByText("������ ������� ���� (��� �����������)").Value = "-2";
        //        podchList.Items.Add("���� ������� ���� �� �.�.");
        //        podchList.Items.FindByText("���� ������� ���� �� �.�.").Value = "-1";
        //        podchList.Items.FindByText("���� ������� ���� �� �.�.").Selected = true;
        //    }
        //    else if (podrList.SelectedItem.Value == "584")
        //    {
        //        podchLabel.Visible = true;
        //        podchList.Visible = true;
        //        podchDataSource.SelectCommand = "SELECT NAIMENOVAN, KEY_OF_NAI FROM NAIMEN WHERE KEY_OF_NAI IN (SELECT DISTINCT PODR FROM AAQQ WHERE PODR <> 9 AND PODRAZD = 584) ORDER BY NAIMENOVAN";
        //        podchDataSource.DataBind();
        //        podchList.DataBind();
        //        podchList.Items.Add("������ ������� ���� (��� �����������)");
        //        podchList.Items.FindByText("������ ������� ���� (��� �����������)").Value = "-2";
        //        podchList.Items.Add("���� ������� ���� �� �.�������");
        //        podchList.Items.FindByText("���� ������� ���� �� �.�������").Value = "-1";
        //        podchList.Items.FindByText("���� ������� ���� �� �.�������").Selected = true;
        //    }
        //    else
        //    {
        //        podchLabel.Visible = false;
        //        podchList.Visible = false;
        //    }
        //}

        protected void ExcelCopyButton_Click(object sender, ImageClickEventArgs e)
        {
            kadry.WordExcel.ExportGridToExcel(this, Grid, "������");
        }

        protected void WordCopyButton_Click(object sender, ImageClickEventArgs e)
        {
            kadry.WordExcel.ExportGridToWord(this, Grid, "������");
        }

        protected void ObjButton_Click(object sender, EventArgs e)
        {
            string[] keys = kadry.Vars.Keys.Split(Convert.ToChar(","));

            StringBuilder script = new StringBuilder();

            for (int i = 0; i < keys.Length; i++)
            {
                script.AppendLine("<script language=\"Javascript\"> window.open(\"http://192.168.10.2/Objective.aspx?id=" + keys[i] + "\",\"����������\",\"\"); </script>");//height=600,width=300,toolbar=no,directories=no, status=no,menubar=yes,scrollbars=yes,resizable=yes\"); </script>");
            }

            ClientScript.RegisterClientScriptBlock(GetType(), "obj", script.ToString());


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            podrList.Items.Clear();
            podrDataSet.Clear();
            Command.CommandText = "SELECT * FROM PODRAZD.DBF ORDER BY PODRAZDEL";
            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(podrDataSet);
            podrList.DataBind();
            podrList.Items.Add("��� �������������");
            podrList.Items.FindByText("��� �������������").Value = "0";
            podrList.Items.FindByText("��� �������������").Selected = true;
        }

        //protected void AttCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (AttCheckBox.Checked) AttResList.Enabled = true;
        //    else AttResList.Enabled = false;

        //}
		
	}
	
	

}
