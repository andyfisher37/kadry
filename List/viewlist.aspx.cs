using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.Caching;

namespace kadry.List
{
	/// <summary>
	/// Summary description for viewlist.
	/// </summary>
	public partial class viewlist : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				string[] str = Request.Params["title"].Split(Convert.ToChar("|"));
				for(int i=0;i<str.Length;i++)
				{
					TitleText.Text += str[i] + "<br>";
				}

				CountLabel.Text = "По штату: " + Request.Params["st"] + ", по списку: "  + Request.Params["count"];

				DataSet ds = new DataSet();
				ds = (DataSet)Cache["listdata"];

				for( int i=0; i< ds.Tables[0].Rows.Count; i++)
				{
					TableRow r = new TableRow();
					TableCell c1 = new TableCell();
					c1.Text = ds.Tables[0].Rows[i]["PODRAZDEL"].ToString();
					r.Cells.Add(c1);
					TableCell c2 = new TableCell();
					c2.Text = ds.Tables[0].Rows[i]["NAM_OF_SLU"].ToString();
					r.Cells.Add(c2);
					TableCell c3 = new TableCell();
					c3.Text = ds.Tables[0].Rows[i]["NAM_OF_DOL"].ToString();
					r.Cells.Add(c3);
					TableCell c4 = new TableCell();
					c4.Text = ds.Tables[0].Rows[i]["FAMILIYA"].ToString();
					r.Cells.Add(c4);
					TableCell c5 = new TableCell();
					c5.Text = ds.Tables[0].Rows[i]["IMYA"].ToString();
					r.Cells.Add(c5);
					TableCell c6 = new TableCell();
					c6.Text = ds.Tables[0].Rows[i]["OTCHECTVO"].ToString();
					r.Cells.Add(c6);
					TableCell c61 = new TableCell();
					c61.HorizontalAlign = HorizontalAlign.Center;
					c61.Text = ds.Tables[0].Rows[i]["VOIN_ZVAN"].ToString();
					r.Cells.Add(c61);
					TableCell c7 = new TableCell();
					c7.HorizontalAlign = HorizontalAlign.Center;
					c7.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_ROZD"]).ToShortDateString();
					r.Cells.Add(c7);
					TableCell c8 = new TableCell();
					c8.HorizontalAlign = HorizontalAlign.Center;
					c8.Text = ds.Tables[0].Rows[i]["P1"].ToString();
					r.Cells.Add(c8);
					TableCell c9 = new TableCell();
					c9.Text = ds.Tables[0].Rows[i]["OBRAZ_LIC1"].ToString();
					r.Cells.Add(c9);
					TableCell c10 = new TableCell();
					c10.HorizontalAlign = HorizontalAlign.Center;
					c10.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_POST"]).ToShortDateString();
					r.Cells.Add(c10);
					TableCell c11 = new TableCell();
					c11.HorizontalAlign = HorizontalAlign.Center;
					c11.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATA_VDOLZ"]).ToShortDateString();
					r.Cells.Add(c11);
					
					Table.Rows.Add(r);
				}
				ds.Clear();
				Cache.Remove("listdata");
				Table.Visible = true;
				
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
	}
}
