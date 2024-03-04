using System;
using System.Web.UI;

namespace kadry.Education
{
	/// <summary>
	/// Summary description for obrazov.
	/// </summary>
	public class Education : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Web.UI.WebControls.DropDownList uczList;
		protected System.Web.UI.WebControls.DropDownList stepList;
		protected System.Web.UI.WebControls.DropDownList dolzList;
		protected System.Web.UI.WebControls.DropDownList profList;
		protected System.Web.UI.WebControls.DropDownList znakList;
		protected kadry.Quality.obrDataSet obrDataSet;
		protected System.Web.UI.WebControls.DropDownList kvaList;
		protected kadry.Quality.kvaDataSet kvaDataSet;
		protected kadry.Quality.listDataSet listDataSet;
		protected System.Web.UI.WebControls.DropDownList podrList;
		protected kadry.podrDataSet podrDataSet;
		protected System.Web.UI.WebControls.DropDownList sluzList;
		protected System.Web.UI.WebControls.DataGrid Grid;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected System.Web.UI.WebControls.TextBox YearBox;
		protected System.Web.UI.WebControls.Label ResLabel;
		protected System.Web.UI.WebControls.ImageButton ImageButton5;
		protected System.Web.UI.WebControls.RadioButton RadioButton4;
		protected System.Web.UI.WebControls.RadioButton RadioButton3;
		protected System.Web.UI.WebControls.RadioButton RadioButton2;
		protected System.Web.UI.WebControls.RadioButton RadioButton1;
		protected kadry.sluzDataSet sluzDataSet;
        		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
                //kadry.Security.Security s = new kadry.Security.Security();

                //if (!s.CheckSecurePage(User.Identity.Name,"Education.aspx")) Response.Redirect("\\AccessDenied.htm",true);

                //s.AddLogText("Открытие страницы:[Статистика по образованию]",Context.Request.UserHostAddress.ToString(),15,true);

				if (this.RadioButton1.Checked) 
				{
					kadry.Vars.sbase = "AAQQ.DBF";
				}
				if (this.RadioButton2.Checked) 
				{
					kadry.Vars.sbase = "ARCHIVE.DBF";
				}
				if (this.RadioButton3.Checked) 
				{
					kadry.Vars.sbase = "RESERV.DBF";
				}
				if (this.RadioButton4.Checked) 
				{
					kadry.Vars.sbase = "VYEZD.DBF";
				}

				Command.CommandText = "SELECT * FROM SLVUCZ ORDER BY P1";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(obrDataSet,"SLVUCZ");
				uczList.DataBind();
                uczList.Items.Add("Только УЗ МВД России");
                uczList.Items.FindByText("Только УЗ МВД России").Value = "-1";
                uczList.Items.Add("Только гражданские УЗ");
                uczList.Items.FindByText("Только гражданские УЗ").Value = "-2";
                uczList.Items.Add("Любое учебное заведение");
				uczList.Items.FindByText("Любое учебное заведение").Value = "0";
				uczList.Items.FindByText("Любое учебное заведение").Selected = true;

				Command.CommandText = "SELECT * FROM SLVKVA ORDER BY P1";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(kvaDataSet,"SLVKVA");
				kvaList.DataBind();
				kvaList.Items.Add("Любая специальность");
				kvaList.Items.FindByText("Любая специальность").Value = "0";
				kvaList.Items.FindByText("Любая специальность").Selected = true;

				Command.CommandText = "SELECT * FROM PODRAZD.DBF WHERE KEY_OF_POD IN (SELECT PODRAZD FROM " + kadry.Vars.sbase + ")";
				DataAdapter.SelectCommand = Command;
				object[] v = new object[2] {"Все подразделения",0};
				podrDataSet.Tables[0].Rows.Add(v);
				DataAdapter.Fill(podrDataSet);
				podrList.DataBind();
				podrList.Items.FindByText("Все подразделения").Value = "0";
				podrList.Items.FindByText("Все подразделения").Selected = true;

				Command.CommandText = "SELECT * FROM SLUZBA.DBF ORDER BY NAM_OF_SLU";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(sluzDataSet);
				sluzList.DataBind();
				sluzList.Items.Add("Все службы");
				sluzList.Items.FindByText("Все службы").Value = "-1";
				sluzList.Items.FindByText("Все службы").Selected = true;

				stepList.Style.Add("Width","414");
				uczList.Style.Add("Width","414");
				podrList.Style.Add("Width","414");
				sluzList.Style.Add("Width","414");
				dolzList.Style.Add("Width","414");
				kvaList.Style.Add("Width","414");
				profList.Style.Add("Width","414");
				YearBox.Style.Add("Width","64");

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
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.Connection = new System.Data.Odbc.OdbcConnection();
            this.obrDataSet = new kadry.Quality.obrDataSet();
			this.kvaDataSet = new kadry.Quality.kvaDataSet();
			this.podrDataSet = new kadry.podrDataSet();
			this.sluzDataSet = new kadry.sluzDataSet();
            this.listDataSet = new kadry.Quality.listDataSet();
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			((System.ComponentModel.ISupportInitialize)(this.obrDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kvaDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.listDataSet)).BeginInit();
			this.ImageButton5.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton5_Click);
			// 
			// Command
			// 
			this.Command.CommandText = @"SELECT Aaqq.PODRAZD, Aaqq.FAMILIYA, Aaqq.IMYA, Aaqq.OTCHECTVO, Aaqq.DATA_ROZD, PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, Aaqq.DAT_OKUZ, SLVUCZ.P1 FROM Aaqq, PODRAZD, SLUZBA, OFIC_DOL, ZVANIE, SLVUCZ WHERE Aaqq.PODRAZD = PODRAZD.KEY_OF_POD AND Aaqq.SLUZBA = SLUZBA.KEY_OF_SLU AND Aaqq.REAL_DOLZN = OFIC_DOL.P3 AND Aaqq.ZVANIE = ZVANIE.KEY_ZVAN AND Aaqq.UCHZAV = SLVUCZ.P2";
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "MaxBufferSize=2048;FIL=dBase IV;DSN=KADRY;PageTimeout=0;DefaultDir=C:\\KADRY;Drive" +
				"rId=277";
			// 
			// obrDataSet
			// 
			this.obrDataSet.DataSetName = "obrDataSet";
			this.obrDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// kvaDataSet
			// 
			this.kvaDataSet.DataSetName = "kvaDataSet";
			this.kvaDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// podrDataSet
			// 
			this.podrDataSet.DataSetName = "podrDataSet";
			this.podrDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sluzDataSet
			// 
			this.sluzDataSet.DataSetName = "sluzDataSet";
			this.sluzDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// listDataSet
			// 
			this.listDataSet.DataSetName = "listDataSet";
			this.listDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.obrDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kvaDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.listDataSet)).EndInit();

		}
		#endregion

		private void ImageButton5_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string comment = "";

		 Command.CommandText = "SELECT KEY_1, PODRAZD, FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, " +
							   "PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, " +
							   "DAT_OKUZ, SLVUCZ.P1 FROM ";

			if (this.RadioButton1.Checked) 
			{
				Command.CommandText += " AAQQ.DBF ";
				kadry.Vars.sbase = "AAQQ.DBF";
				comment += " (действующие) ";
			}
			if (this.RadioButton2.Checked) 
			{
				Command.CommandText += " ARCHIVE.DBF ";
				kadry.Vars.sbase = "ARCHIVE.DBF";
				comment += " (уволенные) ";
			}
			if (this.RadioButton3.Checked) 
			{
				Command.CommandText += " RESERV.DBF ";
				kadry.Vars.sbase = "RESERV.DBF";
				comment += " (в распоряжении) ";
			}
			if (this.RadioButton4.Checked) 
			{
				Command.CommandText += " VYEZD.DBF ";
				kadry.Vars.sbase = "VYEZD.DBF";
				comment += " (откомандированные) ";
			}

			Command.CommandText += ", PODRAZD, SLUZBA, OFIC_DOL, ZVANIE, SLVUCZ WHERE (PODRAZD = PODRAZD.KEY_OF_POD) AND SLUZBA = SLUZBA.KEY_OF_SLU AND REAL_DOLZN = OFIC_DOL.P3 AND ZVANIE = ZVANIE.KEY_ZVAN AND UCHZAV = SLVUCZ.P2 AND FAMILIYA <> '' ";

			// Степень образования
			if ( stepList.SelectedValue == "10" )
			{
				Command.CommandText += " AND OBRAZ_LIC2 = '10' ";
				comment += "[только с высшим]";
			} 
			else if ( stepList.SelectedValue == "20" )
			{
				Command.CommandText += " AND OBRAZ_LIC2 = '20' ";
				comment += "[только со средним-специальным]";
			} 
			else if ( stepList.SelectedValue == "30" )
			{
				Command.CommandText += " AND OBRAZ_LIC2 = '30' ";
				comment += "[только со средним]";
			}

            // Подразделения
			if ( podrList.SelectedValue != "0" )
			{
				Command.CommandText += " AND PODRAZD = " + podrList.SelectedValue;
				comment += "[" + podrList.SelectedItem.Text + "]";
			}

			// Службы
			if ( sluzList.SelectedValue != "-1" )
			{
				Command.CommandText += " AND SLUZBA = " + sluzList.SelectedValue;
				comment += "["+ sluzList.SelectedItem.Text + "]";
			}

			// Учебные заведения
			if ( uczList.SelectedValue != "0" )
			{
                if (uczList.SelectedValue == "-1")
                {
                    Command.CommandText += " AND ((UCHZAV BETWEEN '200000' AND '300000') OR (UCHZAV BETWEEN '400000' AND '500000'))";
                    comment += "[Только УЗ системы МВД]";
                }
                else if (uczList.SelectedValue == "-2")
                {
                    Command.CommandText += " AND ((UCHZAV < '200000' AND UCHZAV > '300000') OR (UCHZAV < '400000' AND UCHZAV > '500000'))";
                    comment += "[Только гражданские УЗ]";
                }
                else
                {
                    Command.CommandText += " AND UCHZAV = '" + uczList.SelectedValue + "'";
                    comment += "[" + uczList.SelectedValue + "]";
                }
			}

			// Должности
			if ( dolzList.SelectedValue == "1" )
			{
				Command.CommandText += " AND DOLZNOST < '200000'";
				comment += "[только руководство]";
			} 
			else if ( dolzList.SelectedValue == "2" )
			{
				Command.CommandText += " AND DOLZNOST < '500000'";
				comment += "[только старш.и средний нач.состав]";
			} 
			else if ( dolzList.SelectedValue == "3" )
			{
				Command.CommandText += " AND DOLZNOST BETWEEN '500000' AND '800000'";
				comment += "[только младший нач.состав]";
			}
			else if ( dolzList.SelectedValue == "4" )
			{
				Command.CommandText += " AND DOLZNOST > '800000'";
				comment += "[только вольнонаемный состав]";
			}
			else if ( dolzList.SelectedValue == "5" )
			{
				Command.CommandText += " AND DOLZNOST < '800000'";
				comment += "[только аттестованный состав]";
			}

			// Год окончания
			if ( YearBox.Text != "" && znakList.SelectedValue != "?" )
			{
				Command.CommandText += " AND DAT_OKUZ " + znakList.SelectedValue + " '" + YearBox.Text + "'";
				comment += "[окончивших УЗ в " + YearBox.Text + "]";
			}

			// Профиль образования
			if ( profList.SelectedValue != "0" )
			{
				Command.CommandText += " AND OBRAZ_LIC1 = '" + profList.SelectedValue + "'";
			}

			// Специальность
			if ( kvaList.SelectedValue != "0" )
			{
				Command.CommandText += " AND OBRAZ_LIC3 = '" + kvaList.SelectedValue + "'";
			}

			Command.CommandText += " ORDER BY FAMILIYA";
			//Response.Write(Command.CommandText);

			DataAdapter.SelectCommand = Command;

			Grid.DataBind();

			DataAdapter.Fill(listDataSet);

			if (listDataSet.Tables[0].Rows.Count > 0 )
			{
				ResLabel.Text = "Найдено: " + listDataSet.Tables[0].Rows.Count.ToString() + " человек(а) " + comment;
			} 
			else ResLabel.Text = "По вашему запросу ничего не найдено!";

			Grid.DataBind();
			
            //if ( uczList.SelectedValue != "0" )
            //{
            //    Grid.Columns[8].Visible = false;
            //} 
            //else Grid.Columns[8].Visible = true;
            //if ( YearBox.Text != "" )
            //{
            //    Grid.Columns[9].Visible = false;
            //}
            //else Grid.Columns[9].Visible = true;
			if ( podrList.SelectedValue != "0" )
			{
				Grid.Columns[4].Visible = false;
			} 
			else Grid.Columns[4].Visible = true;
			if ( sluzList.SelectedValue != "0" )
			{
				Grid.Columns[5].Visible = false;
			} 
			else Grid.Columns[5].Visible = true;
			
		
		}

        protected void Button1_Click(object sender, ImageClickEventArgs e)
        {
        //    Command.CommandText = "SELECT KEY_1, PODRAZD, FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, " +
        //                          "PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, " +
        //                          "DAT_OKUZ, SLVUCZ.P1 FROM AAQQ, PODRAZD, OFIC_DOL, SLUZBA, ZVANIE, SLVUCZ  " +
        //                          "WHERE (PODRAZD = PODRAZD.KEY_OF_POD) AND SLUZBA = SLUZBA.KEY_OF_SLU AND " +
        //                          "REAL_DOLZN = OFIC_DOL.P3 AND ZVANIE = ZVANIE.KEY_ZVAN AND UCHZAV = SLVUCZ.P2 AND " +
        //                          "DOLZNOST < '800000' AND FAMILIYA <> '' AND LICH_NOM_2 <> 'совмещ' AND DATA_POST >= '" +
        //                          System.DateTime.Now.AddYears(-3).ToShortDateString() + "' ";

        //    // Подразделения
        //    if (podrList.SelectedValue != "0")
        //    {
        //        Command.CommandText += " AND PODRAZD = " + podrList.SelectedValue;
        //        comment += "[" + podrList.SelectedItem.Text + "]";
        //    }

        //    // Службы
        //    if (sluzList.SelectedValue != "-1")
        //    {
        //        Command.CommandText += " AND SLUZBA = " + sluzList.SelectedValue;
        //        comment += "[" + sluzList.SelectedItem.Text + "]";
        //    }

        //    // Учебные заведения
        //    if (uczList.SelectedValue != "0")
        //    {
        //        Command.CommandText += " AND UCHZAV = '" + uczList.SelectedValue + "' ";
        //        comment += "[" + uczList.SelectedItem.Text + "]";
        //    }
        //    else if (uczList.SelectedValue != "-1") // ВУЗы МВД
        //    {
        //        Command.CommandText += " AND UCHZAV BETWEEN '200000' AND '300000' ";
        //        comment += "[" + uczList.SelectedItem.Text + "]";
        //    }
        //    else if (uczList.SelectedValue != "-2") // гражданские
        //    {
        //        Command.CommandText += " AND UCHZAV BETWEEN '150000' AND '200000' ";
        //        comment += "[" + uczList.SelectedItem.Text + "]";
        //    }

        //    Command.CommandText += " ORDER BY FAMILIYA";
        //    //Response.Write(Command.CommandText);

        //    DataAdapter.SelectCommand = Command;
            
        //    DataAdapter.Fill(listDataSet);

        //    Grid.DataBind();

        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
        //    string comment = "";

        //    Command.CommandText = "SELECT KEY_1, PODRAZD, FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, " +
        //                          "PODRAZD.PODRAZDEL, SLUZBA.NAM_OF_SLU, OFIC_DOL.NAM_OF_DOL, ZVANIE.VOIN_ZVAN, " +
        //                          "LICH_NOM_1, LICH_NOM_2, SLVUCZ.P1 FROM AAQQ, PODRAZD, OFIC_DOL, SLUZBA, ZVANIE, SLVUCZ  " +
        //                          "WHERE (PODRAZD = PODRAZD.KEY_OF_POD) AND SLUZBA = SLUZBA.KEY_OF_SLU AND " +
        //                          "REAL_DOLZN = OFIC_DOL.P3 AND ZVANIE = ZVANIE.KEY_ZVAN AND UCHZAV = SLVUCZ.P2 AND " +
        //                          "DOLZNOST < '800000' AND FAMILIYA <> '' AND LICH_NOM_2 <> 'совмещ' AND DAT_OKUZ = '" + System.DateTime.Now.Year.ToString() + "' ";
            

        //    // Подразделения
        //    if (podrList.SelectedValue != "0")
        //    {
        //        Command.CommandText += " AND PODRAZD = " + podrList.SelectedValue;
        //        comment += "[" + podrList.SelectedItem.Text + "]";
        //    }

        //    // Службы
        //    if (sluzList.SelectedValue != "-1")
        //    {
        //        Command.CommandText += " AND SLUZBA = " + sluzList.SelectedValue;
        //        comment += "[" + sluzList.SelectedItem.Text + "]";
        //    }

        //    // Учебные заведения
        //    if (uczList.SelectedValue != "0")
        //    {
        //        Command.CommandText += " AND UCHZAV = '" + uczList.SelectedValue + "' ";
        //        comment += "[" + uczList.SelectedItem.Text + "]";
        //    }
        //    else if (uczList.SelectedValue != "-1") // ВУЗы МВД
        //    {
        //        Command.CommandText += " AND UCHZAV BETWEEN '200000' AND '300000' ";
        //        comment += "[" + uczList.SelectedItem.Text + "]";
        //    }
        //    else if (uczList.SelectedValue != "-2") // гражданские
        //    {
        //        Command.CommandText += " AND UCHZAV BETWEEN '150000' AND '200000' ";
        //        comment += "[" + uczList.SelectedItem.Text + "]";
        //    }

        //    Command.CommandText += " ORDER BY FAMILIYA";
        //    //Response.Write(Command.CommandText);

        //    DataAdapter.SelectCommand = Command;
            

        }
        
	}
}
