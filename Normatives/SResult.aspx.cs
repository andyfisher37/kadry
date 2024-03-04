using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Cisso;
using ADODB;
using System.Data.OleDb;

namespace UK.Normatives
{
	/// <summary>
	/// Summary description for SResult.
	/// </summary>
	public class SResult : System.Web.UI.Page
	{
		protected System.Data.DataView dv;
		protected System.Web.UI.WebControls.Label FindLabel;
		protected System.Web.UI.WebControls.DataGrid Grid;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
			
				Cisso.CissoQuery query = new CissoQueryClass();
				
				string text = Request.QueryString["text"];

				text = text.Replace("\"","'");

				if ( text.Length != 0) 
				{
					query.Query = "@contents contains \"" + text + "\"";
				} 
				
				query.Columns = "Characterization, VPath, Size, DocComments";
				query.Catalog = "Web";
				ADODB._Recordset rs = new ADODB.RecordsetClass();
				rs.DataSource = query.CreateRecordset("nonsequential");

				if (rs.Properties.Count > 0)
				{ 

					OleDbDataAdapter myDA = new OleDbDataAdapter();
					DataSet myDS = new DataSet();

					myDA.Fill(myDS, rs, "MyTable");
								
					dv.Table = myDS.Tables["MyTable"];;
					Grid.DataSource = dv;
					if ( dv.Count > 0 )
					{
						Grid.DataBind();
			
						for(int i=0; i < dv.Count; i++ )
						{
							Grid.Items[i].Cells[0].Text = Convert.ToString(i+1);
							Grid.Items[i].Cells[1].Text = Convert.ToString(dv[i].Row[0]);
							Grid.Items[i].Cells[3].Text = Convert.ToString(dv[i].Row[2]);
							Grid.Items[i].Cells[4].Text = Convert.ToString(dv[i].Row[3]);
						}
					
						FindLabel.Text = "Найдено: " + Convert.ToString(dv.Count) + " документов";
						
					} else FindLabel.Text = "<a href=\"normatives.aspx\">По Вашему Запросу ничего не найдено, уточните запрос...</>";
				}
				else FindLabel.Text = "По Вашему Запросу ничего не найдено, уточните запрос...";
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
			this.dv = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.dv)).BeginInit();
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dv)).EndInit();

		}
		#endregion
	}
}
