using System;

namespace UK
{
	/// <summary>
	/// Summary description for Exchange.
	/// </summary>
	public partial class Exchange : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if ( !IsPostBack )
			{
				// Проверяем доступ...
						
				string IP = Convert.ToString(Context.Request.UserHostAddress);
				// Только для УРЛС
				if ( IP.Substring(0,3) == "192" )
				{
					
				}
				else Response.Redirect("\\AccessDenied.htm",true);

				At_TextBox.Text = this.Context.User.Identity.Name;
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

		}
		#endregion

		protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if ( File1.Value != "" )
			{
				// Пересылаемый файл
				string StrFileName = File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf("\\") + 1);
				string StrFileType = File1.PostedFile.ContentType ;
				int IntFileSize = File1.PostedFile.ContentLength;
			
				string path = "";
				if ( AdrList.SelectedValue == "1" ) path = "\\\\Carhevski\\ОБЩАЯ ПАПКА\\";
				if ( AdrList.SelectedValue == "2" ) path = "\\\\Alexey\\Общая папка\\";
				if ( AdrList.SelectedValue == "3" ) path = "\\\\Comp405_2\\Общая папка\\";
				if ( AdrList.SelectedValue == "4" ) path = "\\\\Dubovcomp\\C\\Documents and Settings\\Дубов\\Рабочий стол\\";
			    if ( AdrList.SelectedValue == "5" ) path = "\\\\1wux9zjb5um3o9p\\сетевая папка\\";
			    if ( AdrList.SelectedValue == "6" ) path = "\\\\Comp4\\D\\";
				if ( AdrList.SelectedValue == "7" ) path = "\\\\Comp409\\Общая папка\\";
				if ( AdrList.SelectedValue == "8" ) path = "\\\\Инспекция\\общая папка\\";
				if ( AdrList.SelectedValue == "9" ) path = "\\\\Comp405_2\\Общая папка\\";
				if ( AdrList.SelectedValue == "10" ) path = "\\\\Comp409\\Общая папка\\";
				if ( AdrList.SelectedValue == "11" ) path = "\\\\Comp409\\Общая папка\\";
				if ( AdrList.SelectedValue == "12" ) path = "\\\\Психолог\\общая папка\\";
				if ( AdrList.SelectedValue == "13" ) path = "\\\\Куликов\\общая папка\\";


				
                
				string fname = System.IO.Path.GetFullPath(path) + StrFileName;
				File1.PostedFile.SaveAs(fname);

				// Протоколируем...
				UK.Security.Security s = new UK.Security.Security();
				s.AddLogText("[Пересылка файлов]:" + fname, Context.Request.UserHostAddress, 38, true );

				Response.Write("<script lang='JScript'> alert('Ваш документ успешно отправлен -> " + fname + "'); window.location = '..//index.aspx'; </script>");
			}
		}
	}
}
