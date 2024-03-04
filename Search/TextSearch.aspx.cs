using System;

namespace UK.Search
{
	/// <summary>
	/// Summary description for TextSearch.
	/// </summary>
	public partial class TextSearch : System.Web.UI.Page
	{
		protected System.Data.Odbc.OdbcConnection odbcConnection;
		protected UK.podrDataSet podrDataSet;
		protected UK.mainDataSet mainDataSet;
		protected UK.sluzDataSet sluzDataSet;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected UK.Search.dolzDataSet dolzDataSet;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				UK.Security.Security s = new UK.Security.Security();

				if (!s.CheckSecurePage(User.Identity.Name,"textsearch.aspx")) Response.Redirect("\\AccessDenied.htm",true);
								
				Command.CommandText = "SELECT * FROM PODRAZD.DBF WHERE (KEY_OF_POD >= 1 AND KEY_OF_POD <=31 ) OR ( KEY_OF_POD IN (54,152,312) ) ";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(podrDataSet);
				podrList.DataBind();
				podrList.Items.Add("Все подразделения");
				podrList.Items.FindByText("Все подразделения").Value = "0";
				podrList.Items.FindByText("Все подразделения").Selected = true;

				Command.CommandText = "SELECT * FROM SLUZBA.DBF WHERE KEY_OF_SLU IN (SELECT DISTINCT SLUZBA FROM AAQQ.DBF) ORDER BY NAM_OF_SLU";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(sluzDataSet);
				sluzList.DataBind();
				sluzList.Items.Add("Все службы (кроме ОВО)");
				sluzList.Items.FindByText("Все службы (кроме ОВО)").Value = "-2";
				sluzList.Items.Add("Все службы");
				sluzList.Items.FindByText("Все службы").Value = "-1";
				sluzList.Items.FindByText("Все службы").Selected = true;

				podrList.Style.Add("Width","240px");			
				sluzList.Style.Add("Width","240px");
				dolzList.Style.Add("Width","240px");
				first_name.Style.Add("Width","152px");
				name.Style.Add("Width","152px");
				last_name.Style.Add("Width","152px");
				num_1.Style.Add("Width","32px");
				num_2.Style.Add("Width","112px");
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
			this.odbcConnection = new System.Data.Odbc.OdbcConnection();
			this.podrDataSet = new UK.podrDataSet();
			this.mainDataSet = new UK.mainDataSet();
			this.sluzDataSet = new UK.sluzDataSet();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.dolzDataSet = new UK.Search.dolzDataSet();
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dolzDataSet)).BeginInit();
			// 
			// odbcConnection
			// 
			this.odbcConnection.ConnectionString = "PageTimeout=0;FIL=dBase 5.0;MaxBufferSize=2048;DSN=KADRY;DefaultDir=C:\\KADRY;Dri" +
				"verId=533";
			// 
			// podrDataSet
			// 
			this.podrDataSet.DataSetName = "podrDataSet";
			this.podrDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// mainDataSet
			// 
			this.mainDataSet.DataSetName = "mainDataSet";
			this.mainDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sluzDataSet
			// 
			this.sluzDataSet.DataSetName = "sluzDataSet";
			this.sluzDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// Command
			// 
			this.Command.Connection = this.odbcConnection;
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			// 
			// dolzDataSet
			// 
			this.dolzDataSet.DataSetName = "dolzDataSet";
			this.dolzDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.podrDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dolzDataSet)).EndInit();

		}
		#endregion

		protected void GoBtn_Click(object sender, System.EventArgs e)
		{
			UK.Security.Security s = new UK.Security.Security();

			string LogText = "";
			secure_text.Text = "";
					
			this.first_name_TextChanged(sender, e);
			this.name_TextChanged(sender, e);
			this.last_name_TextChanged(sender, e);

			Command.CommandText = "SELECT KEY_1, FAMILIYA, IMYA, OTCHECTVO, DATA_ROZD, REAL_DOLZN, PODRAZDEL, NAM_OF_SLU, dolz1.NAM_OF_DOL, dolz2.NAM_OF_DOL, VOIN_ZVAN, LICH_NOM_1, LICH_NOM_2, IST.`TEXT` FROM ";
 
			if (this.RadioButton1.Checked) 
			{
				Command.CommandText += " AAQQ.DBF ";
				UK.Vars.sbase = "AAQQ.DBF";
				LogText += " (действующие) ";
			}
			if (this.RadioButton2.Checked) 
			{
				Command.CommandText += " ARCHIVE.DBF ";
				UK.Vars.sbase = "ARCHIVE.DBF";
				LogText += " (уволенные) ";
			}
			if (this.RadioButton3.Checked) 
			{
				Command.CommandText += " RESERV.DBF ";
				UK.Vars.sbase = "RESERV.DBF";
				LogText += " (в распоряжении) ";
			}
			if (this.RadioButton4.Checked) 
			{
				Command.CommandText += " VYEZD.DBF ";
				UK.Vars.sbase = "VYEZD.DBF";
				LogText += " (откомандированные) ";
			}

			Command.CommandText += ", PODRAZD.DBF, SLUZBA.DBF, ZVANIE.dbf, OFIC_DOL.dbf dolz1, ofic_dol.dbf dolz2, SLVISOD.dbf IST WHERE (IST_SOD = IST.CODE) AND (dolz2.P3 = REAL_DOLZN) AND (KEY_OF_POD = PODRAZD) AND (SLUZBA = KEY_OF_SLU) AND (ZVANIE = KEY_ZVAN) AND (dolz1.P3 = DOLZNOST) AND FAMILIYA <> \'\' ";

			// Ф.И.О.
			if (first_name.Text != "")
			{
				Command.CommandText += " AND FAMILIYA LIKE '" + first_name.Text + "%'";
				LogText += first_name.Text + "|";			
			} 
			
			if (name.Text != "") 
			{
				Command.CommandText += " AND IMYA LIKE '" + name.Text + "%'";
				LogText += name.Text + "|";				
			} 
			
			if (last_name.Text != "")
			{
				Command.CommandText += " AND OTCHECTVO LIKE '" + last_name.Text + "%'";
				LogText += last_name.Text + "|";				
			}

			// Личный номер
			if ( num_1.Text != "" )
			{
				Command.CommandText += " AND LICH_NOM_1 = '" + num_1.Text + "'";
				LogText += num_1.Text + "|";				
			}
			if ( num_2.Text != "" )
			{
				Command.CommandText += " AND LICH_NOM_2 = '" + num_2.Text + "'";
				LogText += num_2.Text + "|";				
			}
			
			// Выбор подразделения
			if ( podrList.SelectedItem.Value != "0" )
			{
				Command.CommandText += " AND PODRAZD IN (" + podrList.SelectedItem.Value + ") ";
				Grid.Columns[4].Visible = false;
				LogText += podrList.SelectedItem.Text + "|";				
			} 
			else Grid.Columns[4].Visible = true;
			
			// Выбор службы
			if ( sluzList.SelectedItem.Value != "-1" )
			{
				if (sluzList.SelectedItem.Value != "-2" )
				{

					// Объединение некоторых глобальных служб...
					// КМ
					if (sluzList.SelectedItem.Value == "1" )	Command.CommandText += " AND SLUZBA IN (1,12,24,25,26,27,28,74,72,85,61,90) ";
					else
						// МОБ
						if (sluzList.SelectedItem.Value == "2" )	Command.CommandText += " AND SLUZBA IN (2,9,11,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,52,54,56,57,58,59,60,61,62,63,65,67,68,69,70) ";
					else
						// Кадры
						if (sluzList.SelectedItem.Value == "4" )	Command.CommandText += " AND SLUZBA IN (4,18,52,53,54,55,56,58,59,60,63,64,65) ";
					else
						// Тыл
						if (sluzList.SelectedItem.Value == "5" )	Command.CommandText += " AND SLUZBA IN (5,15,73,76,77) ";
					else
						// ОВО
						if (sluzList.SelectedItem.Value == "9" )	Command.CommandText += " AND SLUZBA IN (9,52) ";
					else
						// Следствие
						if (sluzList.SelectedItem.Value == "10" )	Command.CommandText += " AND SLUZBA IN (10,55) ";
					else
						// ГИБДД
						if (sluzList.SelectedItem.Value == "11" )	Command.CommandText += " AND SLUZBA IN (11,36,37,38,39,56,65) ";
					else
						// УР
						if (sluzList.SelectedItem.Value == "24" )	Command.CommandText += " AND SLUZBA IN (24,25) ";
					else
						// ППС
						if (sluzList.SelectedItem.Value == "29" )	Command.CommandText += " AND SLUZBA IN (29,54) ";
					else
						// Приемники
						if (sluzList.SelectedItem.Value == "33" )	Command.CommandText += " AND SLUZBA IN (33,63) ";
					else
						// Мед.вытрезв
						if (sluzList.SelectedItem.Value == "40" )	Command.CommandText += " AND SLUZBA IN (40,60) ";
					else
						// Конвой
						if (sluzList.SelectedItem.Value == "43" )	Command.CommandText += " AND SLUZBA IN (43,58) ";
					else
						// ОМОН
						if (sluzList.SelectedItem.Value == "44" )	Command.CommandText += " AND SLUZBA IN (44,59) ";
					else
						// УЦ
						if (sluzList.SelectedItem.Value == "78" )	Command.CommandText += " AND SLUZBA IN (78,64) ";
					else
						// УНП
						if (sluzList.SelectedItem.Value == "85" )	Command.CommandText += " AND SLUZBA IN (85,66) ";
					else Command.CommandText += " AND SLUZBA IN (" + sluzList.SelectedItem.Value + " )";
				} 
				else 	Command.CommandText += " AND SLUZBA NOT IN (9,52) ";
				Grid.Columns[5].Visible = false;
				LogText += sluzList.SelectedItem.Text + "|";		
			} 
			else Grid.Columns[5].Visible = true;
			
			// Выбор категории должности
			if ( dolzList.SelectedValue != "0" )
			{
				LogText += dolzList.SelectedItem.Text + "|";
			
				if ( dolzList.SelectedValue == "-1" )
				{
					Command.CommandText += " AND DOLZNOST < '800000'";
				}
				if ( dolzList.SelectedValue == "1" )
				{
					Command.CommandText += " AND DOLZNOST < '200000'";
				}
				if ( dolzList.SelectedValue == "2" )
				{
					Command.CommandText += " AND DOLZNOST < '500000'";
				}
				if ( dolzList.SelectedValue == "3" )
				{
					Command.CommandText += " AND DOLZNOST BETWEEN '500000' AND '800000'";
				}
				if ( dolzList.SelectedValue == "4" )
				{
					Command.CommandText += " AND DOLZNOST > '800000'";
				}
			} 
			
			
			// Накладываем ограничения по службам и подразделениям...
			string secure_sluzb = s.GetSecureSluzb(User.Identity.Name);
			if (secure_sluzb != "")	
			{
				Command.CommandText += " AND SLUZBA NOT IN (" + secure_sluzb + ") ";
				secure_text.Text = "!ограничения! - по службам";
			}
			string secure_podrazd = s.GetSecurePodrazd(User.Identity.Name);
			if (secure_podrazd != "")	
			{
				Command.CommandText += " AND PODRAZD NOT IN (" + secure_podrazd + ") ";
				secure_text.Text += ",по подразделениям";
			}

			string secure_podr = s.GetSecurePodr(User.Identity.Name);
			if (secure_podr != "")	
			{
				Command.CommandText += " AND PODR NOT IN (" + secure_podr + ") ";
				secure_text.Text += ",по структурным подразделениям";
			}
			secure_text.NavigateUrl = "../denied_expl.aspx?User=" + User.Identity.Name +
				"&sl=" + secure_sluzb +
				"&podr=" + secure_podrazd +
				"&pdr=" + secure_podr;

			Command.CommandText += " ORDER BY FAMILIYA";

					
			// Отладка...
			//this.Page.Response.Write(Command.CommandText);
			
			DataAdapter.SelectCommand = Command;
			DataAdapter.Fill(mainDataSet);
			    
			Grid.Visible = true;
				
			if (mainDataSet._Table.Count !=0 ) // Если кого-то нашли...
			{
				s.AddLogText("запрос на поиск: " + LogText, Convert.ToString(Context.Request.UserHostAddress),4,true);
				UK.Vars.Keys = "";							
				FindLabel.CssClass = "maintext";
				FindLabel.Text = "Найдено: " + Convert.ToString(mainDataSet._Table.Count) + " человек(а)";
		
				// Добавляем числовую часть личного номера...
				Grid.DataBind();			
				for (int i = 0; i <= mainDataSet._Table.Rows.Count - 1; i++ )
				{
						// Подстановка должности при замещении...
						if ( Convert.ToString(mainDataSet._Table.Rows[i]["nam_of_dol"]) != Convert.ToString(mainDataSet._Table.Rows[i]["nam_of_dol1"]) )
						{
							Grid.Items[i].Cells[6].Text = mainDataSet._Table.Rows[i]["nam_of_dol1"] + " (за счет - " +
								mainDataSet._Table.Rows[i]["nam_of_dol"] + ")";
								
						}
						UK.Vars.Keys += mainDataSet._Table.Rows[i]["KEY_1"].ToString() + ",";
						Grid.Items[i].Cells[8].Text += "-" + mainDataSet._Table.Rows[i]["lich_nom_2"];
				}
				
				
				// Скрываем ненужные столбцы в таблице...
				if (podrList.SelectedValue != "0")
				{
					Grid.Columns[4].Visible = false;
					FindLabel.Text += ", только (" + podrList.SelectedItem.Text + ")";
				} 
				else Grid.Columns[4].Visible = true;

				if (sluzList.SelectedValue != "-1")
				{
					Grid.Columns[5].Visible = false;
					FindLabel.Text += ", только (" + sluzList.SelectedItem.Text + ")";
				} 
				else Grid.Columns[5].Visible = true;
			}
			else
			{
				s.AddLogText("запрос на поиск: " + LogText, Convert.ToString(Context.Request.UserHostAddress),5,false);
		
				Grid.DataBind();
				FindLabel.CssClass = "Attantion";
				FindLabel.Text = "Не найдено ни одного сотрудника, попробуйте изменить параметры запроса...";
				
			}
		
		}

		protected void first_name_TextChanged(object sender, System.EventArgs e)
		{
			if (first_name.Text.Length != 0) 
			{
				string tmp = Convert.ToString(first_name.Text[0]);
				first_name.Text = tmp.ToUpper() + first_name.Text.Substring(1,first_name.Text.Length-1).ToLower();
			}
		}

		protected void name_TextChanged(object sender, System.EventArgs e)
		{
			if (name.Text.Length != 0 )
			{
				string tmp = Convert.ToString(name.Text[0]);
				name.Text = tmp.ToUpper() + name.Text.Substring(1,name.Text.Length-1).ToLower();
			}
		}

		protected void last_name_TextChanged(object sender, System.EventArgs e)
		{
			if (last_name.Text.Length != 0)
			{
				string tmp = Convert.ToString(last_name.Text[0]);
				last_name.Text = tmp.ToUpper() + last_name.Text.Substring(1,last_name.Text.Length-1).ToLower();
			}
		}
	}
}
