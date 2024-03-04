using System;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace kadry.Security
{
	public class Security
	{
		public System.Data.DataRowCollection rc;

		public Security() {}

		/// �������� �� ��������� ��������� � ������
		public bool IsInStr( string src, string cmp )
		{
			string[] separe = src.Split(Convert.ToChar(","));
			for( int i=0; i<separe.Length;i++)
			{
				if (separe[i] == cmp) return true;
			}
			return false;
		}


		// �������� �� ���������� ������ � ���� �����������
		public bool IsKeysSecure( string src, string cmp )
		{
			string[] separe1 = src.Split(Convert.ToChar(","));
			string[] separe2 = cmp.Split(Convert.ToChar(","));

			for( int i=0; i<separe1.Length;i++)
			{
				for( int j=0; j<separe2.Length; j++)
				{
					if (separe1[i] == separe2[j]) return true;
				}
			}
			return false;
		}


		/// ������ ���������� ��������� ������	
		public int getUsersCount()
		{
			SqlDataAdapter DataAdapter = new SqlDataAdapter();
			SqlConnection Conn = new SqlConnection();
			SqlCommand Command = new SqlCommand();
			DataSet tmpDataSet = new DataSet();
			DataAdapter.SelectCommand = Command;

			Command.CommandText = "[getUsersCount]";
			Command.CommandType = CommandType.StoredProcedure;
			Command.Connection = Conn;
            Conn.ConnectionString = "Data Source=URLS_SERVER\\SQLEXPRESS;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*";
            DataAdapter.Fill(tmpDataSet);
			Conn.Dispose();
			DataAdapter.Dispose();
			return Convert.ToInt16(tmpDataSet.Tables[0].Rows[0][0]);
		}


		/// �������� � �������������� ���������� ����...(����� ���������)
		
		public bool IsLocalNet( string IP )
		{
			if ( IP.Substring(0,5) == "10.22" ) return true;
			if ( IP.Substring(0,9) == "192.168.1" ) return true;
			if ( IP.Substring(0,5) == "194.1" ) return true;
            else return false;
		}

		/// �������� ����������� ������� � ������������ IP ������
		public int IsUserExist(string Name, string Pass, string IP)
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
			SqlConnection sqlConnection1 = new SqlConnection();
			SqlCommand sqlSelectCommand1 = new SqlCommand();
			kadry.PassDataSet passDataSet = new kadry.PassDataSet();

			sqlDataAdapter.SelectCommand = sqlSelectCommand1;
			sqlDataAdapter.TableMappings.AddRange(new DataTableMapping[] {
					  							  new DataTableMapping("Table", "checkUser",
												  new DataColumnMapping[] {
												  new DataColumnMapping("UserName", "UserName"),
												  new DataColumnMapping("UserPass", "UserPass"),
												  new DataColumnMapping("IP", "IP"),
												  new DataColumnMapping("UserRole", "UserRole"),
                                                  new DataColumnMapping("Status", "Status")})});
			
			sqlSelectCommand1.CommandText = "[checkUser]";
			sqlSelectCommand1.CommandType = CommandType.StoredProcedure;
			sqlSelectCommand1.Connection = sqlConnection1;
			sqlSelectCommand1.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			sqlSelectCommand1.Parameters.Add(new SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50));
			sqlSelectCommand1.Parameters.Add(new SqlParameter("@Pass", System.Data.SqlDbType.VarChar, 50));
            sqlConnection1.ConnectionString = "Data Source=URLS_SERVER\\SQLEXPRESS;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*";
			passDataSet.DataSetName = "PassDataSet";
			passDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");

			sqlSelectCommand1.Parameters["@Name"].Value = Name;
			sqlSelectCommand1.Parameters["@Pass"].Value = Pass;
		
			int result = sqlDataAdapter.Fill(passDataSet);

            if (result == 0)
            {
                passDataSet.Dispose();
                sqlConnection1.Dispose();
                sqlDataAdapter.Dispose();
                // ������������...
                AddLogText("������� ����� � �������: ��� ������������ [" + Name + "] ������ [" + Pass + "]", IP, 1, false);
                return 0;
            }
            else if (IP == Convert.ToString(passDataSet.Tables[0].Rows[0]["IP"]).TrimEnd())
            {
                passDataSet.Dispose();
                sqlConnection1.Dispose();
                sqlDataAdapter.Dispose();
                return 1;
            }
            else if (IP != Convert.ToString(passDataSet.Tables[0].Rows[0]["IP"]).TrimEnd())
            {
                passDataSet.Dispose();
                sqlConnection1.Dispose();
                sqlDataAdapter.Dispose();
                return 2;
            }
            else return -1;																	   
			
		}

        public bool IsUserGiveSign(string IP)
        {
            //SqlConnection Conn = new SqlConnection("Data Source=URLS_SERVER\SQLEXPRESS;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*");
            //SqlCommand Command = new SqlCommand("SELECT Confidense FROM Users WHERE IP = '" + IP.TrimEnd(Convert.ToChar(" ")) + "'", Conn);

            //if (Conn.State != ConnectionState.Open) Conn.Open();

            //int res = (int)Command.ExecuteScalar();

            //Conn.Dispose();

            //if (res == 0) return false;
            //else return true;

            return true;
        }

		/// ������� ���������� � ���-�������...
		public bool AddLogText(string text, string IP, int EventType, bool Status)
		{
			SqlConnection Conn = new SqlConnection("Data Source=URLS_SERVER\\SQLEXPRESS;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*");
			SqlCommand Cmd = new SqlCommand();
			Cmd.CommandText = "dbo.[AddToLogs]";
			Cmd.CommandType = CommandType.StoredProcedure;
			Cmd.Connection = Conn;
			Cmd.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", DataRowVersion.Current, null));
			Cmd.Parameters.Add(new SqlParameter("@Event", SqlDbType.Int, 4));
			Cmd.Parameters.Add(new SqlParameter("@EventTime", SqlDbType.DateTime, 8));
			Cmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.VarChar, 50));
			Cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.Bit, 1));
			Cmd.Parameters.Add(new SqlParameter("@Text", SqlDbType.VarChar, 256));

			Cmd.Parameters["@Event"].Value = EventType;
			Cmd.Parameters["@EventTime"].Value = System.DateTime.Now;
			Cmd.Parameters["@UserID"].Value = IP;
			Cmd.Parameters["@Status"].Value = Status;
			Cmd.Parameters["@Text"].Value = text;
			try
			{
				Conn.Open();
				Cmd.ExecuteScalar();
				Conn.Dispose();
				return true;
			} 
			catch
			{
				Conn.Dispose();
				return false;
			}
		}


		/// ���������� ������� ���� �������...
		private int FillSecureDataSet(string User)
		{
			SqlDataAdapter DataAdapter = new SqlDataAdapter();
			SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source=URLS_SERVER\\SQLEXPRESS;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*";
			DataSet secureDataSet = new secureDataSet();
			SqlCommand Cmd = new SqlCommand();
			Cmd.CommandText = "[getSecureRole]";
			Cmd.CommandType = CommandType.StoredProcedure;
			Cmd.Connection = Conn;
			Cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50));
			DataAdapter.SelectCommand = Cmd;
			secureDataSet.DataSetName = "secureDataSet";
			secureDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			Cmd.Parameters["@Name"].Value = User;
			int result = DataAdapter.Fill(secureDataSet,"Table");
			rc = secureDataSet.Tables["Table"].Rows;
			Conn.Dispose();
			secureDataSet.Dispose();
			DataAdapter.Dispose();
			return result;
		}


		// �������� �������
		#region 

		// �� ������...
		public string GetSecureSluzb( string UserName )
		{
			if (FillSecureDataSet(UserName) == 0) return "";
			
			return rc[0]["s_Sluzba"].ToString();
		}

		// �� �������������...
		public string GetSecurePodrazd( string UserName )
		{
			if (FillSecureDataSet(UserName) == 0) return "";
			
			return rc[0]["s_Podrazd"].ToString();
		}

		// �� ������������ �������������...
		public string GetSecurePodr( string UserName )
		{
			if (FillSecureDataSet(UserName) == 0) return "";
			
			return rc[0]["s_Podr"].ToString();
		}
		
        // �� ����� ����������...
		public bool CheckSecureKey( string UserName, int key )
		{
			if (FillSecureDataSet(UserName) == 0) return false;

            string sKeys = rc[0]["s_keys"].ToString();
            string IP = rc[0]["IP"].ToString();

            if (!IsKeysSecure(sKeys, key.ToString()))
            {
                return true;
            }
            else
            {
                AddLogText("����� � ������� �� �����:(" + key.ToString() + ")", IP, 47, false);
                return false;
            }

			
            //string sl = rc[0]["s_Sluzba"].ToString();
            //string podr = rc[0]["s_Podrazd"].ToString();
            //string pdr = rc[0]["s_Podr"].ToString();

            //if ( sl == "" && podr == "" && pdr == "" ) return true;
            //else
            //{              
            //    OdbcConnection Conn = new OdbcConnection("PageTimeout=0;FIL=dBase IV;MaxBufferSize=2048;DSN=KADRY;DefaultDir=C:\\KADRY;DriverId=277");

            //    string cmd_text = "SELECT DISTINCT KEY_1 FROM AAQQ.DBF WHERE KEY_1 <> 0 ";

            //    if (sl != "") cmd_text += " AND SLUZBA IN (" + sl + ") ";
            //    if (podr != "") cmd_text += " AND PODRAZD IN (" + podr + ") ";
            //    if (pdr != "") cmd_text += " AND PODR IN (" + pdr + ") ";

            //    cmd_text += " ORDER BY KEY_1";
 
            //    OdbcCommand Command = new OdbcCommand(cmd_text,Conn);
            //    OdbcDataAdapter adapter = new OdbcDataAdapter(Command);
            //    DataSet ds = new DataSet();
            //    adapter.Fill(ds);

            //    int flag = 0;
            //    for( int i = 0; i<ds.Tables[0].Rows.Count;i++)
            //    {
            //        if ( key == Convert.ToInt16(ds.Tables[0].Rows[i]["KEY_1"]) ) flag++;
            //    }
            //    if ( flag != 0 ) return false;
            //    else return true;
            //}
		}

		/// ������ � ��������
		public bool CheckSecurePage(string UserName, string PageName)
		{
			if (FillSecureDataSet(UserName) == 0) return false;
			
			string sPages		= rc[0]["s_Pages"].ToString();
			string IP			= rc[0]["IP"].ToString();
			            
			rc.Clear();

			if ( !IsInStr(sPages, PageName) ) 
			{
			 return true;
			} 
			else 
			{
				AddLogText("����� � ������� � ��������:(" + PageName + ")",IP,1,false);
				return false;
			}
			
		}

        /// ������ � ������������ ����...
        public bool CheckSecureContextMenu(string UserName)
        {
            if (FillSecureDataSet(UserName) == 0) return false;
            else return Convert.ToBoolean(rc[0]["ContextMenu"]);
        }

		/// ������ � ������
//		public bool CheckSecureSluzba(string UserName, string[] sluz1 )
//		{
//			if (FillSecureDataSet(UserName) == 0) return false;
//			
//			string tmp			= rc[0]["s_Sluzba"].ToString();
//			string IP			= rc[0]["IP"].ToString();
//			string[] sluz2 		= tmp.Split(Convert.ToChar(","));
//			            
//			rc.Clear();
//
//			bool ret_flag = true;
//
//			foreach( string s1 in sluz1)
//			{
//				foreach( string s2 in sluz2)
//				{
//					if (s1 == s2) ret_flag = false;
//				}
//			}
//
//			if (ret_flag == false) 
//			{
//				AddLogText("����� � ������� � ������:(" + sluz1 + ")",IP,1,false);
//				return false;
//			}
//			else
//			{
//				return true;
//			}
//			
//		}
//	
		#endregion

		/// ������ ����� � �������
		public static int ErrInSys
		{
			get
			{
				return 1;
			}
		}

		
		/// �������� ���� � �������
		public static int SuccInSys
		{
			get
			{
				return 2;
			}
		}

		
		/// ������������� IP ������ �������
		public static int ErrClientIP
		{
			get
			{
				return 3;
			}
		}

        /// ������ ���������
        public static int ErrClientStatus
        {
            get
            {
                return 48;
            }
        }

		public void Dispose()
		{
			rc.Clear();
		}
		
	}
}
