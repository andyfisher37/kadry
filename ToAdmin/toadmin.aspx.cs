using System;




namespace kadry.ToAdmin
{
	/// <summary>
	/// Summary description for toadmin.
	/// </summary>
    public partial class toadmin : System.Web.UI.Page
    {
        protected System.Data.SqlClient.SqlConnection Conn;
        protected System.Data.SqlClient.SqlCommand Command;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                //From.Value = Context.User.Identity.Name;
                //Info.Visible = false;
                //Text.Value = "";

                //List<PcapDevice> devices = Pcap.GetAllDevices();

                //string device = devices[0].Name;

                //System.Net.IPAddress ip;

                //System.Net.IPAddress.TryParse("192.168.10.3", out ip);

                //ARP arper = new ARP(device);

                //Response.Write(ip + " is at: " + arper.Resolve(ip));

            }
        }

        private void Page_Close(object sender, System.EventArgs e)
        {
            Conn.Dispose();
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
            this.Conn = new System.Data.SqlClient.SqlConnection();
            this.Command = new System.Data.SqlClient.SqlCommand();
            // 
            // Conn
            // 
            this.Conn.ConnectionString = "Data Source=URLS_SERVER\\SQLEXPRESS;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*";
            // 
            // Command
            // 
            this.Command.CommandText = "INSERT INTO MessageTable (UserFrom, SubjectText, Text, UserIP, ContactText, Time)" +
                " VALUES (@UserName, @Subject, @UserText, @IP, @Contact, @TimeIn)";
            this.Command.Connection = this.Conn;
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserName", System.Data.SqlDbType.VarChar, 100, "UserFrom"));
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Subject", System.Data.SqlDbType.VarChar, 256, "SubjectText"));
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserText", System.Data.SqlDbType.VarChar, 1024, "Text"));
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IP", System.Data.SqlDbType.VarChar, 15, "UserIP"));
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Contact", System.Data.SqlDbType.VarChar, 100, "ContactText"));
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TimeIn", System.Data.SqlDbType.VarChar, 8, "Time"));

        }
        #endregion


        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Security.Security s = new kadry.Security.Security();
            Command.Parameters["@UserName"].Value = From.Value;
            Command.Parameters["@Subject"].Value = Subject.Value;
            Command.Parameters["@UserText"].Value = Text.Value;
            Command.Parameters["@Contact"].Value = Contact.Value;
            Command.Parameters["@IP"].Value = Context.Request.UserHostAddress.ToString();
            Command.Parameters["@TimeIn"].Value = System.DateTime.Now.ToShortDateString();
            Conn.Open();
            Command.ExecuteScalar();
            Conn.Close();
            Info.Text = "<script>alert('���� ��������� ������� ����������...�������!');</script>";
            s.AddLogText("���������� ��������� ��������������", Context.Request.UserHostAddress, 22, true);
            Info.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          
            
        }

    }
}
