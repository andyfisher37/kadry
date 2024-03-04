using System;
using System.Data;
using System.Web.UI.WebControls;

namespace UK
{
	/// <summary>
	/// Summary description for PhotoList.
	/// </summary>
	public partial class PhotoList : System.Web.UI.Page
	{

		public System.Data.DataRowCollection rc;
				
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				DataSet ds = (DataSet)Cache["photos"];
				rc = ds.Tables[0].Rows;

                for (int i = 0; i < rc.Count; i++)
                {
                    TableRow r = new TableRow();
					
                    TableCell c1 = new TableCell();
                    if (rc[i]["PHOTO"] != DBNull.Value)
                        c1.Text = "<a href='\\PhotoBank\\" + rc[i]["PHOTO"].ToString() + "'><img src='\\PhotoBank\\" + rc[i]["PHOTO"].ToString() + "' width=50 height=70 border=0></a>"; 
                    else
                        c1.Text = "<img src='\\PhotoBank\\000000.jpg' width=50 height=70>";
                    
                    c1.HorizontalAlign = HorizontalAlign.Center;
                    
                    r.Cells.Add(c1);

                    TableCell c2 = new TableCell();
                    c2.Text = rc[i]["FAMILIYA"].ToString();
                    c2.HorizontalAlign = HorizontalAlign.Center;
                    c2.Font.Bold = true;
                    r.Cells.Add(c2);

                    TableCell c3 = new TableCell();
                    c3.Text = rc[i]["IMYA"].ToString();
                    c3.HorizontalAlign = HorizontalAlign.Center;
                    c3.Font.Bold = true;
                    r.Cells.Add(c3);

                    TableCell c4 = new TableCell();
                    c4.Text = rc[i]["OTCHECTVO"].ToString();
                    c4.HorizontalAlign = HorizontalAlign.Center;
                    c4.Font.Bold = true;
                    r.Cells.Add(c4);

                    Table.Rows.Add(r);
                }

				ds.Clear();
 			    Cache.Remove("photos");
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
		  Response.Redirect("\\Search\\Search.aspx");
		}
	}
}
