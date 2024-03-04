using System;
using System.Web.UI.WebControls;
using System.Web.Caching;

namespace UK
{
	/// <summary>
	/// Summary description for DetailPage_txt.
	/// </summary>
	public partial class DetailPage_txt : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				Security.Security s = new Security.Security();
				
				// Получаем данные из кэша
				this.Response.ContentType = "Text/plain";
				UK.Details data = (UK.Details)Cache["detail"];

				// Протоколирую...
				s.AddLogText("Сл.карт.(версия для печати) " + data.FIO, (string)(Context.Request.UserHostAddress),36,true );
				
				// Вывод сведений...
				TitleText.Text = data.FIO;
				Label1.Text = data.Born;
				Label2.Text = data.BornPlace;
				Label3.Text = data.Nation;
				Label4.Text = data.PersonalNumber;
				Photo.ImageUrl = data.PhotoFile;
				Label5.Text = data.Learn;
				Label6.Text = data.Army;
				Label7.Text = data.PersonalFileNumber;
				
				// Гражданский стаж
				foreach(UK.OtherWork wrk in data.Work)
				{
					TableRow r = new TableRow();
					TableCell c1 = new TableCell();
					c1.Text = wrk.From;
					r.Cells.Add(c1);
					TableCell c2 = new TableCell();
					c2.Text = wrk.To;
					r.Cells.Add(c2);
					TableCell c3 = new TableCell();
					c3.Text = wrk.Legend;
					r.Cells.Add(c3);
					workTable.Rows.Add(r);
				}
				
				// Информация по званиям
				foreach(UK.SpecRank rank in data.Rank)
				{
					TableRow r = new TableRow();
					TableCell c1 = new TableCell();
					c1.Text = "&nbsp&nbsp&nbsp" + rank.Rank;
					c1.HorizontalAlign = HorizontalAlign.Left;
					r.Cells.Add(c1);
					TableCell c2 = new TableCell();
					c2.Text = rank.OVDPrik;
					c2.HorizontalAlign = HorizontalAlign.Center;
					r.Cells.Add(c2);
					TableCell c3 = new TableCell();
					c3.Text = rank.NumPrik;
					c3.HorizontalAlign = HorizontalAlign.Center;
					r.Cells.Add(c3);
					TableCell c4 = new TableCell();
					c4.Text = rank.DatePrik;
					c4.HorizontalAlign = HorizontalAlign.Center;
					r.Cells.Add(c4);
					TableCell c5 = new TableCell();
					c5.Text = rank.DateRank;
					c5.HorizontalAlign = HorizontalAlign.Center;
					r.Cells.Add(c5);
					zTable.Rows.Add(r);
				}

			  // Послужной список...
              Label8.Text = "в ОВД с: " + data.vOVD + ", в службе с: " + data.vSLU + ", в должности с: " + data.vDOL;

				foreach(UK.SpecWork swrk in data.Posl)
				{
					TableRow r = new TableRow();
					TableCell c1 = new TableCell();
					c1.Text = swrk.From;
					c1.HorizontalAlign = HorizontalAlign.Left;
					r.Cells.Add(c1);
					TableCell c2 = new TableCell();
					c2.Text = swrk.Zvan;
					c2.HorizontalAlign = HorizontalAlign.Center;
					r.Cells.Add(c2);
					TableCell c3 = new TableCell();
					c3.Text = swrk.Dolz;
					c3.HorizontalAlign = HorizontalAlign.Center;
					r.Cells.Add(c3);
					TableCell c4 = new TableCell();
					c4.Text = swrk.Podr;
					c4.HorizontalAlign = HorizontalAlign.Center;
					r.Cells.Add(c4);
					TableCell c5 = new TableCell();
					c5.Text = swrk.Status;
					c5.HorizontalAlign = HorizontalAlign.Center;
					r.Cells.Add(c5);
					TableCell c6 = new TableCell();
					c6.Text = swrk.OVDPrik;
					c6.HorizontalAlign = HorizontalAlign.Center;
					r.Cells.Add(c6);
					TableCell c7 = new TableCell();
					c7.Text = swrk.NumPrik;
					c7.HorizontalAlign = HorizontalAlign.Center;
					r.Cells.Add(c7);
					TableCell c8 = new TableCell();
					c8.Text = swrk.DatePrik;
					c8.HorizontalAlign = HorizontalAlign.Center;
					r.Cells.Add(c8);

					swTable.Rows.Add(r);
				}

				// Командировки...
				if ( data.Lgottime.Count == 0 )	Label9.Text = " нет ";
				else
				{
					foreach(UK.Komand k in data.Lgottime)
					{
						TableRow r = new TableRow();
						TableCell c1 = new TableCell();
						c1.Text = k.From;
						c1.HorizontalAlign = HorizontalAlign.Left;
						r.Cells.Add(c1);
						TableCell c2 = new TableCell();
						c2.Text = k.To;
						c2.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c2);
						TableCell c3 = new TableCell();
						c3.Text = k.Koeff;
						c3.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c3);
						TableCell c4 = new TableCell();
						c4.Text = k.Legend;
						c4.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c4);
						TableCell c5 = new TableCell();
						c5.Text = k.Prik;
						c5.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c5);
						TableCell c6 = new TableCell();
						c6.Text = k.Date_pr;
						c6.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c6);
						TableCell c7 = new TableCell();
						c7.Text = k.Num_pr;
						c7.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c7);
						
						kTable.Rows.Add(r);
					}

				}

				// Взыскания...
				if ( data.Nak.Count == 0 )	Label10.Text = " нет ";
				else
				{
					foreach(UK.Nakazan n in data.Nak)
					{
						TableRow r = new TableRow();
						TableCell c1 = new TableCell();
						c1.Text = n.Date;
						c1.HorizontalAlign = HorizontalAlign.Left;
						r.Cells.Add(c1);
						TableCell c2 = new TableCell();
						c2.Text = n.OVDPrik;
						c2.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c2);
						TableCell c3 = new TableCell();
						c3.Text = n.NumPrik;
						c3.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c3);
						TableCell c4 = new TableCell();
						c4.Text = n.Vzysk;
						c4.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c4);
						TableCell c5 = new TableCell();
						c5.Text = n.Legend;
						c5.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c5);
						TableCell c6 = new TableCell();
						c6.Text = n.DateSn;
						c6.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c6);
						TableCell c7 = new TableCell();
						c7.Text = n.WhoSn;
						c7.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c7);
						TableCell c8 = new TableCell();
						c8.Text = n.NumPrSn;
						c8.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c8);

						nakTable.Rows.Add(r);
					}
				}

				// Поощрения...
				if ( data.Nagr.Count == 0 )	Label11.Text = " нет ";
				else
				{
					foreach(UK.Poo p in data.Nagr)
					{
						TableRow r = new TableRow();
						TableCell c1 = new TableCell();
						c1.Text = p.Vid;
						c1.HorizontalAlign = HorizontalAlign.Left;
						r.Cells.Add(c1);
						TableCell c2 = new TableCell();
						c2.Text = p.Prich;
						c2.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c2);
						TableCell c3 = new TableCell();
						c3.Text = p.OVDPrik;
						c3.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c3);
						TableCell c4 = new TableCell();
						c4.Text = p.NumPrik;
						c4.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c4);
						TableCell c5 = new TableCell();
						c5.Text = p.DatePrik;
						c5.HorizontalAlign = HorizontalAlign.Center;
						r.Cells.Add(c5);

						pooTable.Rows.Add(r);
					}
				}

				Cache.Remove("detail");

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
