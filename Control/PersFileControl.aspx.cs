using System;
using System.Data;
using System.Web.UI;

namespace kadry.Control
{
	/// <summary>
	/// Summary description for pfile_control.
	/// </summary>
	public partial class pfile_control : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected kadry.Control.pfileDataSet pfileDataSet;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
                //kadry.Security.Security s = new kadry.Security.Security();
                //if (!s.CheckSecurePage(User.Identity.Name,"pfile_control.aspx")) Response.Redirect("\\AccessDenied.htm",true);
                //    else s.AddLogText("Работа с контролем регистрации личных дел",Context.Request.UserHostAddress,39,true);
				
				pfileDataSet.Clear();

				Command.CommandText = "SELECT COUNT(NOMLICHDEL) FROM AAQQ WHERE NOMLICHDEL <> 0 AND DOLZNOST < '800000'";
				if ( Connection.State != ConnectionState.Open ) Connection.Open();
				int res = (int)Command.ExecuteScalar();
				FindLabel.Text = "По состоянию на " + System.DateTime.Now.ToShortDateString() + " г. - всего зарегистрировано " + res.ToString() + " личных дел аттестованного состава.";
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
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.Connection = new System.Data.Odbc.OdbcConnection();
			this.pfileDataSet = new kadry.Control.pfileDataSet();
			((System.ComponentModel.ISupportInitialize)(this.pfileDataSet)).BeginInit();
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// Command
			// 
			this.Command.CommandText = @"SELECT Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, Aaqq.NOMLICHDEL, SLUZBA.NAM_OF_SLU, PODRAZD.PODRAZDEL, OFIC_DOL.NAM_OF_DOL, Aaqq.KEY_1, Aaqq.DATA_VDOLZ, ZVANIE.VOIN_ZVAN FROM Aaqq, SLUZBA, PODRAZD, OFIC_DOL, ZVANIE WHERE Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.REAL_DOLZN = OFIC_DOL.P3 AND Aaqq.ZVANIE = ZVANIE.KEY_ZVAN AND ((Aaqq.PODRAZD = 1) AND (Aaqq.SLUZBA NOT IN (9, 52, 39, 11, 36, 37, 38)) AND (Aaqq.DOLZNOST < '800000') AND (Aaqq.FAMILIYA <> '') OR (Aaqq.SLUZBA IN (4, 16, 18)) AND (Aaqq.DOLZNOST < '800000') AND (Aaqq.FAMILIYA <> '') OR (Aaqq.PODRAZD > 1) AND (Aaqq.DOLZNOST IN ('100162', '100168', '100169', '100170', '100171', '100185', '100204', '100215', '100236', '100327', '100333', '100335', '100338', '100341', '100342', '100344', '100349', '100381', '100395')) AND (Aaqq.FAMILIYA <> '') AND (Aaqq.DOLZNOST < '800000')) AND NOMLICHDEL = 0 ORDER BY Aaqq.NOMLICHDEL";
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase IV;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;Driv" +
				"erId=277";
			// 
			// pfileDataSet
			// 
			this.pfileDataSet.DataSetName = "pfileDataSet";
			this.pfileDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.pfileDataSet)).EndInit();

		}
		#endregion

        //protected void Button1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    pfileDataSet.Clear();
        //    Command.CommandText = "SELECT Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, Aaqq.NOMLICHDEL, SLUZBA.NAM_OF_SLU, PODRAZD.PODRAZDEL, OFIC_DOL.NAM_OF_DOL, Aaqq.KEY_1, Aaqq.DATA_VDOLZ, ZVANIE.VOIN_ZVAN FROM Aaqq, SLUZBA, PODRAZD, OFIC_DOL, ZVANIE WHERE Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.REAL_DOLZN = OFIC_DOL.P3 AND Aaqq.ZVANIE = ZVANIE.KEY_ZVAN AND ((Aaqq.PODRAZD = 1) AND (Aaqq.SLUZBA NOT IN (9, 52, 39, 11, 36, 37, 38)) AND (Aaqq.DOLZNOST < '800000') AND (Aaqq.FAMILIYA <> '') OR (Aaqq.SLUZBA IN (4, 16, 18,52,54,55,56,58,59,60,64,65)) AND (Aaqq.DOLZNOST < '800000') AND (Aaqq.FAMILIYA <> '') OR (Aaqq.PODRAZD > 1) AND (Aaqq.DOLZNOST IN ('100162', '100168', '100169', '100170', '100171', '100185', '100204', '100215', '100221', '100236', '100327', '100333', '100335', '100338', '100341', '100342', '100344', '100349', '100381', '100395')) AND (Aaqq.FAMILIYA <> '') AND (Aaqq.DOLZNOST < '800000')) ORDER BY Aaqq.NOMLICHDEL";
        //    //SELECT Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, Aaqq.NOMLICHDEL, SLUZBA.NAM_OF_SLU, PODRAZD.PODRAZDEL, OFIC_DOL.NAM_OF_DOL, Aaqq.KEY_1, ZVANIE.VOIN_ZVAN FROM Aaqq, SLUZBA, PODRAZD, OFIC_DOL, ZVANIE WHERE Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.REAL_DOLZN = OFIC_DOL.P3 AND Aaqq.ZVANIE = ZVANIE.KEY_ZVAN AND ((Aaqq.PODRAZD = 1) AND (Aaqq.SLUZBA NOT IN (9, 52, 39, 11, 36, 37, 38)) AND (Aaqq.DOLZNOST < '800000') AND (Aaqq.FAMILIYA <> '') OR (Aaqq.SLUZBA IN (4, 16, 18,54,55,56,58,59,60,64,65) ) AND (Aaqq.DOLZNOST < '800000') AND (Aaqq.FAMILIYA <> '') OR (Aaqq.PODRAZD > 1) AND (Aaqq.DOLZNOST IN ('100162', '100168', '100169', '100170', '100171', '100185', '100204', '100215', '100221', '100236', '100327', '100333', '100335', '100338', '100341', '100342', '100344', '100349', '100381', '100395')) AND (Aaqq.FAMILIYA <> '') AND (Aaqq.DOLZNOST < '800000')) ORDER BY Aaqq.NOMLICHDEL";
        //    DataAdapter.SelectCommand = Command;
        //    DataAdapter.Fill(pfileDataSet);

        //    Grid.DataBind();

        //    for( int i = 0; i<pfileDataSet.Tables[0].Rows.Count; i++ )
        //    {
        //        if ( Grid.Items[i].Cells[0].Text == "0" ) Grid.Items[i].Cells[0].Text = "нет";
        //    }

        //    FindLabel.Text = "Найден " + pfileDataSet.Tables[0].Rows.Count.ToString() + " сотрудник(а)...";
        //}

		protected void Button2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			pfileDataSet.Clear();
            Command.CommandText = "SELECT FAMILIYA, IMYA, OTCHECTVO, NOMLICHDEL, SLUZBA.NAM_OF_SLU, PODRAZD.PODRAZDEL, OFIC_DOL.NAM_OF_DOL, KEY_1, DATA_VDOLZ, ZVANIE.VOIN_ZVAN FROM Aaqq, SLUZBA, PODRAZD, OFIC_DOL, ZVANIE WHERE Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.REAL_DOLZN = OFIC_DOL.P3 AND Aaqq.ZVANIE = ZVANIE.KEY_ZVAN AND ((Aaqq.PODRAZD = 1) AND (Aaqq.SLUZBA NOT IN (9, 52, 39, 11, 36, 37, 38)) AND (Aaqq.DOLZNOST < '800000') AND (Aaqq.FAMILIYA <> '') OR (Aaqq.SLUZBA IN (4,16,17,18,54,55,58,59,60,64,65)) AND (Aaqq.DOLZNOST < '800000') AND (Aaqq.FAMILIYA <> '') OR (Aaqq.PODRAZD > 1) AND (Aaqq.DOLZNOST IN ('100162', '100168', '100169', '100170', '100171', '100185', '100204', '100215', '100221', '100236', '100327', '100333', '100335', '100338', '100341', '100342', '100344', '100349', '100381', '100395','100587','100586')) AND (Aaqq.FAMILIYA <> '') AND (Aaqq.DOLZNOST < '800000')) AND NOMLICHDEL = 0 AND (Aaqq.DOLZNOST NOT IN ('100439','100283','200328')) ORDER BY PODRAZD, SLUZBA, FAMILIYA"; //AND (PODRAZD = 1 AND Aaqq.DOLZNOST NOT IN ('100001','100341','100342','100349','100395','100475','100185') ) ORDER BY PODRAZD, SLUZBA, FAMILIYA";
			DataAdapter.SelectCommand = Command;
			DataAdapter.Fill(pfileDataSet);

			Grid.DataBind();

			for( int i = 0; i<pfileDataSet.Tables[0].Rows.Count; i++ )
			{
				if ( Grid.Items[i].Cells[0].Text == "0" ) Grid.Items[i].Cells[0].Text = "-";
			}

			FindLabel.Text = "Найден " + pfileDataSet.Tables[0].Rows.Count.ToString() + " сотрудник(а)...";
		
		}

        // Личные дела аттестованных, зарегестрированные в АИС "КАДРЫ"
        protected void Button3_Click(object sender, ImageClickEventArgs e)
        {
            pfileDataSet.Clear();
            Command.CommandText = "SELECT Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, Aaqq.NOMLICHDEL, SLUZBA.NAM_OF_SLU, PODRAZD.PODRAZDEL, OFIC_DOL.NAM_OF_DOL, Aaqq.KEY_1, Aaqq.DATA_VDOLZ, ZVANIE.VOIN_ZVAN FROM Aaqq, SLUZBA, PODRAZD, OFIC_DOL, ZVANIE WHERE Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.REAL_DOLZN = OFIC_DOL.P3 AND Aaqq.ZVANIE = ZVANIE.KEY_ZVAN AND Aaqq.DOLZNOST < '800000' AND Aaqq.FAMILIYA <> '' AND NOMLICHDEL <> 0 ORDER BY Aaqq.NOMLICHDEL";
            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(pfileDataSet);

            Grid.DataBind();

            FindLabel.Text = "Найдено " + pfileDataSet.Tables[0].Rows.Count.ToString() + " личных дел.";
            
        }

        // Личные дела вольнонаемных, зарегестрированные в АИС "КАДРЫ"
        protected void Button4_Click(object sender, ImageClickEventArgs e)
        {
            pfileDataSet.Clear();
            Command.CommandText = "SELECT Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, Aaqq.NOMLICHDEL, SLUZBA.NAM_OF_SLU, PODRAZD.PODRAZDEL, OFIC_DOL.NAM_OF_DOL, Aaqq.KEY_1, Aaqq.DATA_VDOLZ, ZVANIE.VOIN_ZVAN FROM Aaqq, SLUZBA, PODRAZD, OFIC_DOL, ZVANIE WHERE Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.REAL_DOLZN = OFIC_DOL.P3 AND Aaqq.ZVANIE = ZVANIE.KEY_ZVAN AND Aaqq.DOLZNOST > '800000' AND Aaqq.FAMILIYA <> '' AND NOMLICHDEL <> 0 ORDER BY Aaqq.NOMLICHDEL";
            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(pfileDataSet);

            Grid.DataBind();

            FindLabel.Text = "Найдено " + pfileDataSet.Tables[0].Rows.Count.ToString() + " личных дел.";
        }
	}
}
