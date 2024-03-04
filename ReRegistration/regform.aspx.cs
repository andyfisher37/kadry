using System;
using System.Data;

namespace kadry.ReRegistration
{
	/// <summary>
	/// Summary description for regform.
	/// </summary>
	public partial class regform : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlConnection Connection;
		protected System.Data.SqlClient.SqlCommand Command;
		protected System.Data.SqlClient.SqlDataAdapter DataAdapter;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if ( !IsPostBack )
			{
				Title.Text = "���������(��) <u>" + Context.User.Identity.Name + "</u> ��� ����������� �������������� ������������ �������� � ������ ������� ������� ���������� ��� ���������� �������, " +
				" � ������ ����� �������������-������������� ������ ����������� ����������� <u> ��������������� </u> �������������. <br>����� ��� ��������� � ������ ��������� � ������ ����������������!" +
				" <br>������������ �� ��������� ������ ��������� �� ����� ����� ������ � ��������������� �������...";

				DataSet ds = new DataSet();
				Command.CommandText = "SELECT UserName, UserPass, IP, NewReg, OldPass FROM Users WHERE UserName = '" + Context.User.Identity.Name + "'";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(ds);

				OldPassword.Text = ds.Tables[0].Rows[0]["UserPass"].ToString();
				Result.Text = "";
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
			this.Connection = new System.Data.SqlClient.SqlConnection();
			this.Command = new System.Data.SqlClient.SqlCommand();
			this.DataAdapter = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// Connection
			// 
            this.Connection.ConnectionString = "Data Source=COMP2\\SQLEXPRESS;Initial Catalog=IAS;Persist Security Info=True;User ID=sa;Password=*";
			// 
			// Command
			// 
			this.Command.Connection = this.Connection;
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;

		}
		#endregion

		protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Result.Text = "";

			bool check = true;

			if ( NewPassword1.Text == "" || NewPassword1.Text.Length < 6 ) check = false;
			if ( NewPassword2.Text == "" || NewPassword2.Text.Length < 6 ) check = false;
			if ( NewPassword1.Text != NewPassword2.Text ) check = false;

			if ( check )
			{
				Command.CommandText = "SELECT * FROM Users WHERE NewReg = 0"; 

			}
			else Result.Text = "������ ������ ��� ����� ������ �� ������������� �������� ������������!";
		}

		protected void GenPass_Click(object sender, System.EventArgs e)
		{
			System.Random rnd = new Random();
			string pass = "";
			int size = rnd.Next(6,10);

			do
			{
				int code = rnd.Next(48,175);
				
				if (( code >= 48 && code <= 57) || ( code >= 65 && code <= 90) || ( code >= 97 && code <= 122 ))
				{
					pass += Convert.ToChar(code);
				}
				
			} while(pass.Length != size);

			NewPassword1.Text = pass;
			NewPassword2.Text = pass;
		}
	}
}
