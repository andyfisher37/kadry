using System;

namespace UK
{
    public partial class Stag : System.Web.UI.Page
    {
        private int[] monthDay = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private DateTime fromDate;
        private DateTime toDate;
        private int year;
        private int month;
        private int day; 


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


            }

        }
    }
}
