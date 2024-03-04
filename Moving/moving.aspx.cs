using System;

namespace kadry.Moving
{
	/// <summary>
	/// Summary description for moving.
	/// </summary>
	public class moving : System.Web.UI.Page
	{
		protected eWorld.UI.MaskedTextBox Date1;
		protected System.Web.UI.WebControls.DropDownList sluzList;
		protected kadry.sluzDataSet sluzDataSet;
		protected System.Data.Odbc.OdbcCommand Command;
		protected System.Data.Odbc.OdbcConnection Connection;
		protected System.Data.Odbc.OdbcDataAdapter DataAdapter;
		protected System.Web.UI.WebControls.ImageButton SpsButton1;
		protected System.Web.UI.WebControls.ImageButton SpsButton2;
		protected System.Web.UI.WebControls.ImageButton StatButton;
		protected System.Web.UI.WebControls.Label Info;
		protected eWorld.UI.MaskedTextBox Date2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				kadry.Security.Security s = new kadry.Security.Security();

				if (!s.CheckSecurePage(User.Identity.Name,"moving.aspx")) Response.Redirect("\\AccessDenied.htm",true);
										
				Command.CommandText = "SELECT * FROM SLUZBA.DBF WHERE KEY_OF_SLU IN (SELECT DISTINCT SLUZBA FROM AAQQ.DBF) ORDER BY NAM_OF_SLU";
				DataAdapter.SelectCommand = Command;
				DataAdapter.Fill(sluzDataSet);
				sluzList.DataBind();
				sluzList.Items.Add("Все службы (кроме ОВО)");
				sluzList.Items.FindByText("Все службы (кроме ОВО)").Value = "-2";
				sluzList.Items.Add("Все службы");
				sluzList.Items.FindByText("Все службы").Value = "-1";
				sluzList.Items.FindByText("Все службы").Selected = true;

				Date1.Text = "01.01." + System.DateTime.Now.Year.ToString();
				Date2.Text = System.DateTime.Now.ToShortDateString();

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
			this.sluzDataSet = new kadry.sluzDataSet();
			this.Command = new System.Data.Odbc.OdbcCommand();
			this.Connection = new System.Data.Odbc.OdbcConnection();
			this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).BeginInit();
			// 
			// sluzDataSet
			// 
			this.sluzDataSet.DataSetName = "sluzDataSet";
			this.sluzDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// Command
			// 
			this.Command.Connection = this.Connection;
			// 
			// Connection
			// 
			this.Connection.ConnectionString = "PageTimeout=0;FIL=dBase 5.0;MaxBufferSize=2048;DSN=KADRY;DefaultDir=C:\\KADRY;Dri" +
				"verId=533";
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.Command;
			this.SpsButton1.Click += new System.Web.UI.ImageClickEventHandler(this.SpsButton1_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.sluzDataSet)).EndInit();

		}
		#endregion

		private void SpsButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			kadry.Security.Security s = new kadry.Security.Security();
		
			string LogText = "Движение: ";

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
				LogText += sluzList.SelectedItem.Text + "|";		
			} 
			


			s.AddLogText(LogText,Context.Request.UserHostAddress,41,true);
		}
	}
}
