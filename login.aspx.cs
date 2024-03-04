/// -------------------------------------------------
/// АИС КАДРЫ УРЛС УМВД России по Ивановской области
/// Copyright (c) Рыбаков А.Ю.
/// -------------------------------------------------
using System;
using System.Web.Security;

namespace kadry
{
	/// <summary>
	/// Страница авторизации пользователей...
	/// </summary>
	public partial class login : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            //Security.Security s = new kadry.Security.Security();

			//if ( s.IsLocalNet(Context.Request.UserHostAddress) == false ) Response.Redirect("BadNet.htm");

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

		}
		#endregion

		

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			
            //Security.Security s = new kadry.Security.Security();

            //// Проверка существования пользователя по БД
            //int result = s.IsUserExist(UserNameBox.Text, PasswordBox.Value, Context.Request.UserHostAddress);
		    
            //switch (result)
            //{
            //    case 0 : 
            //    {
            //        message.Visible = true;
            //        message.Text = "Неверное имя пользователеля или пароль. В доступе отказано! Попробуйте еще раз...";
            //        break;
            //    }
            //    case 1 :
            //    {
            //        kadry.Vars.CurrentUserName = UserNameBox.Text;

            //        s.AddLogText("Вход в систему: " + UserNameBox.Text,Convert.ToString(Context.Request.UserHostAddress), Security.Security.SuccInSys, true);

            //        FormsAuthentication.RedirectFromLoginPage(UserNameBox.Text, false);

            //        break;
            //    }
            //    case 2:
            //    {
            //        s.AddLogText("Несоответствие IP-адреса пользователя: " + UserNameBox.Text,Convert.ToString(Context.Request.UserHostAddress), Security.Security.ErrClientIP, false);
            //        message.Visible = true;
            //        message.Text = "Уважаемый: " + UserNameBox.Text +
            //            " Вы пытаетесь войти в систему не со своего компьютера! - извините, но это невозможно...";
            //        break;
            //    }
            //    //case 3:
            //    //{
            //    //    s.AddLogText("Регистрация даного пользователя не активна: " + UserNameBox.Text, Convert.ToString(Context.Request.UserHostAddress), Security.Security.ErrClientStatus, false);
            //    //    message.Visible = true;
            //    //    message.Text = "Уважаемый: " + UserNameBox.Text +
            //    //        " Ваша регистрация не активна! Возможные причины (отсутствие рапорта, нет данных об IP адресе, перемена места службы...)";
            //    //    break;
            //    //}
            //}
					
		}

        // Справочная информация о регистрации...
		protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
				Context.Response.Redirect("Guide\\howtoreg.htm",false);
		}

        protected void Login1_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
        {
            if (Membership.ValidateUser(Login1.UserName, Login1.Password)) e.Authenticated = true;
        }
	}
}
