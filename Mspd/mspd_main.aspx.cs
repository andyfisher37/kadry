using System;
using System.IO;
using System.Text;



namespace kadry.Mspd
{
	/// <summary>
	/// Summary description for mspd_main.
	/// </summary>
	public partial class mspd_main : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlDataAdapter DataAdapter;
		protected System.Data.SqlClient.SqlConnection Connection;
		protected System.Data.SqlClient.SqlCommand sqlCommand;
		protected kadry.Mspd.emailDataSet emailDataSet2;
		protected kadry.Mspd.emailDataSet emailDataSet1;
		protected string StrFileName;
         
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				// ��������� ������...
                //kadry.Security.Security s = new kadry.Security.Security();

                //if (!s.CheckSecurePage(User.Identity.Name,"mspd_main.aspx")) Response.Redirect("\\AccessDenied.htm",true);
                //string IP = Convert.ToString(Context.Request.UserHostAddress);
                //// ������ ��� ����
                //if ( IP.Substring(0,10) == "192.168.10" )
                //{
					
                //}
                //else Response.Redirect("\\AccessDenied.htm",true);
								
				// ��������� e-mail
                sqlCommand.CommandText = "SELECT MSPDNAME, EMAIL FROM MSPDBook WHERE (MSPDNAME IS NOT NULL) AND EMAIL LIKE '%@iva.%' ORDER BY MSPDNAME";
				DataAdapter.SelectCommand = sqlCommand;
				emailDataSet1.Clear();
				DataAdapter.Fill(emailDataSet1);
				adrList1.DataBind();
				sqlCommand.CommandText = "SELECT MSPDNAME, EMAIL FROM MSPDBook WHERE (MSPDNAME IS NOT NULL) AND EMAIL NOT LIKE '%@iva.%' ORDER BY MSPDNAME";
				DataAdapter.SelectCommand = sqlCommand;
				emailDataSet2.Clear();
				DataAdapter.Fill(emailDataSet2);
				adrList2.DataBind();
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
			this.DataAdapter = new System.Data.SqlClient.SqlDataAdapter();
			this.Connection = new System.Data.SqlClient.SqlConnection();
			this.emailDataSet2 = new kadry.Mspd.emailDataSet();
			this.sqlCommand = new System.Data.SqlClient.SqlCommand();
			this.emailDataSet1 = new kadry.Mspd.emailDataSet();
			((System.ComponentModel.ISupportInitialize)(this.emailDataSet2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emailDataSet1)).BeginInit();
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.sqlCommand;
			this.DataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "MSPDBook", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("MSPDNAME", "MSPDNAME"),
																																																			  new System.Data.Common.DataColumnMapping("EMAIL", "EMAIL")})});
			// 
			// Connection
			// 
            this.Connection.ConnectionString = "Data Source=URLS_SERVER\\SQLEXPRESS;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*";
			// 
			// emailDataSet2
			// 
			this.emailDataSet2.DataSetName = "emailDataSet";
			this.emailDataSet2.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sqlCommand
			// 
			this.sqlCommand.Connection = this.Connection;
			// 
			// emailDataSet1
			// 
			this.emailDataSet1.DataSetName = "emailDataSet";
			this.emailDataSet1.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.emailDataSet2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emailDataSet1)).EndInit();

		}
		#endregion

		protected void BtnList_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
            
			kadry.Security.Security s = new kadry.Security.Security();
                        
            //NamedPipeClientStream pipe = new NamedPipeClientStream(".","The Bat!",PipeDirection.Out);

            //Response.Write(pipe.NumberOfServerInstances.ToString());
            //pipe.Connect();

            //if (!pipe.IsConnected)
            //{
                
            //    pipe.Connect();
            //    Response.Write("����� ������!\n");
            //}

            //using (StreamWriter sw = new StreamWriter(pipe))
            //{
            //    sw.AutoFlush = true;
            //    string cmd = " 1 ";

            //    cmd += "\"/MAILUSER=\"���� ���� ������ �� ���������� �������\";TO=kadryr@iva.mvd.ru\"";

            //    sw.WriteLine(cmd);
            //    sw.Close();
            //    Response.Write(cmd);

            //}

            // ���� ����� �� ������
            if (Author.Text == "") Info.Text = "��������� ���� [�����������] ";
            // ���� ������������ ����...
            else if (File1.Value == "") Info.Text += "��������� ���� [������������ ��������]";
            else
            {
                // ������������ ����
                StrFileName = File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf("\\") + 1);
                string StrFileType = File1.PostedFile.ContentType;
                int IntFileSize = File1.PostedFile.ContentLength;

                // ���� ���� ������
                if (IntFileSize <= 0)
                    Info.Text = "������������ �������� ������! (" + StrFileName + ")";
                else
                {
                    // ��������� � MAIL\*.*
                    string fname = System.IO.Path.GetFullPath("c:\\Program Files (x86)\\The Bat!\\Mail") + "\\" + StrFileName;
                    File1.PostedFile.SaveAs(fname);

                    // ������� �������� ���� ��� TheBAT!
                    string ipc = System.IO.Path.GetFullPath("c:\\Program Files (x86)\\The Bat!\\THEBAT.IPC");
                    string cmd = "";
                    string adr = "";

                    System.IO.StreamWriter writer = new StreamWriter(ipc, false, Encoding.Default, 1024);

                    cmd += "/MAILUSER=\"���� ���� ������ �� ���������� �������\";TO=";
                    for (int i = 0; i < adrList1.Items.Count; i++)
                    {
                        if (adrList1.Items[i].Selected)
                        {
                            cmd += adrList1.Items[i].Value;
                            adr += adrList1.Items[i].Text;
                            if (i < adrList1.Items.Count - 2) cmd += ",";
                        }
                    }
                    for (int i = 0; i < adrList2.Items.Count; i++)
                    {
                        if (adrList2.Items[i].Selected)
                        {
                            cmd += adrList2.Items[i].Value;
                            adr += adrList2.Items[i].Text;
                            if (i < adrList2.Items.Count - 2) cmd += ",";
                        }
                    }
                    // ��������� "������" �������...

                    if (manualURL.Text != "") cmd += manualURL.Text;

                    // ��������� "����" � "��������"
                    cmd += ";S=\"" + Subject.Text + " (" + Author.Text + ")\"";
                    cmd += ";A=\"" + fname + "\"";


                    // ����� � THEBAT.IPC
                    writer.WriteLine(cmd);
                    writer.Close();
                    Info.Text = "";

                    // �������������
                    //s.AddLogText("�������� ��������� �� ����:[" + fname + "],[" + Author.Text + "]", Convert.ToString(Context.Request.UserHostAddress), 33, true);

                    // �������������� �� �������
                    Response.Write("<script lang='JScript'> alert('��� �������� �� 99,9% ������� ���������! �� � ����� �������� �� ������ ��������� �� ���. 18-42'); </script>");
                    //Response.Redirect("..\\index.aspx");

                }
            }
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			for( int i = 0; i < adrList1.Items.Count; i++)
			{
				if ( !adrList1.Items[i].Selected ) adrList1.Items[i].Selected = true;
			}
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			for( int i = 0; i < adrList2.Items.Count; i++)
			{
				if ( !adrList2.Items[i].Selected ) adrList2.Items[i].Selected = true;
			}
		}

		
	}
}

            ////// ���� ����� �� ������
            ////if ( Author.Text == "" ) Info.Text = "��������� ���� [�����������] ";
            ////    // ���� ������������ ����...
            ////else if ( File1.Value == "" ) Info.Text += "��������� ���� [������������ ��������]";
            ////else
            ////{
            ////    // ������������ ����
            ////    StrFileName = File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf("\\") + 1) ;
            ////    string StrFileType = File1.PostedFile.ContentType ;
            ////    int IntFileSize = File1.PostedFile.ContentLength;
			
            ////    // ���� ���� ������
            ////    if (IntFileSize <=0)
            ////        Info.Text = "������������ �������� ������! (" + StrFileName + ")";
            ////    else
            ////    {
            ////        // ��������� � C:\MAIL\*.*
            ////        string fname = System.IO.Path.GetFullPath("C:\\Program Files\\The Bat!\\Mail") + "\\" + StrFileName;
            ////        File1.PostedFile.SaveAs(fname);

            ////        // ������� �������� ���� ��� TheBAT
            ////        string ipc =  System.IO.Path.GetFullPath("c:\\Program Files\\The Bat!\\THEBAT.IPC");
            ////        string cmd = "";
            ////        string adr = "";
            ////        System.IO.StreamWriter writer = new StreamWriter(ipc,false,Encoding.Default,1024);

            ////        cmd += "/MAILUSER=\"�� ���� ������ �� ���������� �������\";TO=";
            ////        for( int i = 0; i < adrList1.Items.Count; i++)
            ////        {
            ////            if ( adrList1.Items[i].Selected )
            ////            {
            ////                cmd += adrList1.Items[i].Value;
            ////                adr += adrList1.Items[i].Text;
            ////                if ( i < adrList1.Items.Count - 2 ) cmd += ",";
            ////            }
            ////        }
            ////        for( int i = 0; i < adrList2.Items.Count; i++)
            ////        {
            ////            if ( adrList2.Items[i].Selected )
            ////            {
            ////                cmd += adrList2.Items[i].Value;
            ////                adr += adrList2.Items[i].Text;
            ////                if ( i < adrList2.Items.Count - 2 ) cmd += ",";
            ////            }
            ////        }
            ////        cmd += ";S=\"" + Subject.Text + " (" + Author.Text + ")\"";
            ////        cmd += ";A=" + fname;
					

            ////        // ����� � THEBAT.IPC
            ////        writer.WriteLine(cmd);
            ////        writer.Close();
            ////        Info.Text = "";

            ////        // �������������
            ////        s.AddLogText("�������� ��������� �� ����:[" + fname + "],[" + Author.Text + "]",Convert.ToString(Context.Request.UserHostAddress),33,true); 

            ////        // �������������� �� �������
            ////        Response.Write("<script lang='JScript'> alert('��� �������� �� 99,9% ������� ���������! ��