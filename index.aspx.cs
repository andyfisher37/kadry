using System;
using System.Web.UI;
using OboutInc.Show;



namespace kadry
{
	
	public partial class Index : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.ImageButton Imagebutton9;
		protected System.Web.UI.WebControls.ImageButton Imagebutton6;
		protected System.Web.UI.WebControls.ImageButton Imagebutton5;
		protected System.Web.UI.WebControls.ImageButton Imagebutton4;
		protected System.Web.UI.WebControls.ImageButton ImageButton2;
		protected System.Web.UI.WebControls.ImageButton ImageButton3;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.ImageButton Imagebutton13;
		
		

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if (Context.User.Identity.IsAuthenticated)
			{
                //Security.Security s = new kadry.Security.Security();

                ////kadry.Vars.UsersCount = s.getUsersCount();
                ////UserCount.Text = kadry.Vars.UsersCount.ToString();

                ////if (Request.UserHostAddress.Substring(0, 9) != "192.168.1")
                ////{
                ////    ReservButton.Visible = false;
                ////    //WorkBookButton.Visible = false;
                ////    ZoneControlButton.Visible = false;
                ////}
                //else
                //{
                //    //Response.Write("<script>window.open('infopage.htm','','');</script>");
                //}

                //if (s.IsUserGiveSign(Request.UserHostAddress) == false)
                //{
                //   // Response.Write("<script>window.open('infopage.mht','','');</script>");
                //}

                //Show1.AddPanel(new OboutInc.Show.Panel("/News/news1.htm", PanelType.Url));
		}


		
			// Put user code to initialize the page here
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
        	

	

		protected void ImageButton8_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		   Response.Redirect("\\BornToday\\borntoday.aspx",false);
		}

		
		protected void ImageButton10_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\www.mvd.ru\\default.htm",false);
		}

	
		private void ImageButton12_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\mvd_inform\\index.aspx",false);
		}

		
		protected void ImageButton14_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("AdditionalServices.aspx");
		}

		protected void ImageButton15_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\Statist\\ItogyOSD.aspx");
		}

		protected void ImageButton16_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\Search\\TextSearch.aspx");
		}

		protected void ImageButton17_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if ( Request.UserHostAddress.Substring(0,3) != "192" )
				Response.Redirect("http:\\\\194.1.37.5");
			else Response.Write("<script> window.open('file://kadryr_server/CNTI/Onti/ZAGLAVIE.htm'); </script>");
		}

		protected void ImageButton18_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("\\Education\\Education.aspx");
		}

		

		protected void ReglamentButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
            Response.Redirect("\\Normatives\\Store\\KAD\\ZOP.doc");
		}

        protected void dko_banner_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\dko-mvd.ru\\index.html");
        }

        //protected void WorkBookButton_Click(object sender, ImageClickEventArgs e)
        //{
        //    Response.Redirect("\\WorkBook\\main.aspx");
        //}

        protected void ReservButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Reserv\\Res_main.aspx");
        }

        protected void ImageButton20_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\FreeDownload\\Firefox.exe");
        }

        protected void AllNagradButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Normatives\\nagradyAll.html");
        }

        protected void ImageButton21_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Education\\Medali\\Medali_Russia.pdf");
        }

        protected void ImageButton22_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Education\\History\\lubyanka.pdf");
        }

        protected void ImageButton23_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Zone\\main.aspx");
        }

        protected void ImageButton24_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Write("<script> window.open('oklady.htm'); </script>");
        }

        protected void ImageButton25_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Education\\History\\HystoryMVD.pdf");
        }

        protected void _77Button_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\77.xls");
        }

        protected void CZNButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\www.ivczn.ru\\default.htm");
        }

        protected void VideoButton1_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Write("<script> window.open('\\Education\\Video\\video1.avi'); </script>");
            Response.Redirect("\\Education\\Video\\video1.avi");
        }

        protected void ImageButton26_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Normatives\\Store\\UVD\\gotopolice.zip");
        }

        protected void ImageButton27_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Write("<script> alert('Форма расчета переделывается! К вечеру будет готова'); </script>");
            Response.Redirect("\\GoToPolice\\Report.xls");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UvedomReport.aspx");
        }

        protected void ImageButton28_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Normatives\\Store\\Other\\pamyatka.doc");
        }

        protected void ImageButton29_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Images\\shema.jpg");
        }

        protected void ImageButton30_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\GoToPolice\\concept.doc");
        }

        protected void ImageButton31_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("FZ342.doc");
        }

        protected void ImageButton32_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\FreeDownload\\Chrome.exe");
        }

        protected void ImageButton33_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("http://10.22.2.234/onti/zaglavie.htm", false);
        }

        protected void ImageButton34_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Education\\deloproizvodstvo.rtf");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Vacations\\grafik2013.pdf");
        }

        protected void ImageButtonPerDoc_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("\\Normatives\\Store\\KAD\\pr655.pdf");
        } 



		

	}
}
