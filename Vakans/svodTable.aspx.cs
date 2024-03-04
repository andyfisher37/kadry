using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.Caching;

namespace kadry.Vakans
{
	/// <summary>
	/// Summary description for svodTable.
	/// </summary>
	public partial class svodTable : System.Web.UI.Page
	{
		private System.Data.DataRowCollection rc;

		public void ChangeSluzb()
		{
			for( int i=0; i<rc.Count; i++)
			{
				string s = rc[i]["NAM_OF_SLU"].ToString();
				switch (s)
				{
					case "���� \"������\"" : rc[i]["NAM_OF_SLU"] = "������"; break;
					case "������������ �������" : rc[i]["NAM_OF_SLU"] = "��"; break;
					case "������� ���������.������������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "����������-�����������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "�����" : rc[i]["NAM_OF_SLU"] = "�����"; break;
					case "������� �����������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "���������" : rc[i]["NAM_OF_SLU"] = "��"; break;
					case "��������������� ���� ���������" : rc[i]["NAM_OF_SLU"] = "�����"; break;
					case "����������� ������������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "����" : rc[i]["NAM_OF_SLU"] = "����"; break;
					case "�������� �����" : rc[i]["NAM_OF_SLU"] = "��"; break;
					case "������������� �����" : rc[i]["NAM_OF_SLU"] = "�����"; break;
					case "���������� ������" : rc[i]["NAM_OF_SLU"] = "�.������"; break;
					case "���� ���. ������ �� ������" : rc[i]["NAM_OF_SLU"] = "�.�.������"; break;
					case "���������� ���, ���, ���" : rc[i]["NAM_OF_SLU"] = "�.���,���"; break;
					case "���������-������� ������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "���������-��������.���������-�" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "��������� ������" : rc[i]["NAM_OF_SLU"] = "��"; break;
					case "��������� ������ �� �/������" : rc[i]["NAM_OF_SLU"] = "��(�)"; break;
					case "�� ������ � ����.�������������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "�� ������ � �������.��������-�" : rc[i]["NAM_OF_SLU"] = "����"; break;
					case "���������-�������� ������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "�� �������. ��������.�/������." : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "����� ����. �������� �/� ����." : rc[i]["NAM_OF_SLU"] = "�����"; break;
					case "���������� ���������. �������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "������������� ��� ���.��������" : rc[i]["NAM_OF_SLU"] = "��.��."; break;
					case "�����������-�������������� ���" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "����������� ������ �����" : rc[i]["NAM_OF_SLU"] = "�/�.�����"; break;
					case "���" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "�������-� ����-� � ���.�������" : rc[i]["NAM_OF_SLU"] = "�����"; break;
					case "�������� �������-� ���" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "����������� ������������" : rc[i]["NAM_OF_SLU"] = "�/�"; break;
					case "�� ����������� ��������" : rc[i]["NAM_OF_SLU"] = "����."; break;
					case "��� �������������, ����������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "��������� ������������� ������" : rc[i]["NAM_OF_SLU"] = "����."; break;
					case "������ ������� ������� ������." : rc[i]["NAM_OF_SLU"] = "����"; break;
					case "�����-������" : rc[i]["NAM_OF_SLU"] = "���(�)"; break;
					case "�����-���" : rc[i]["NAM_OF_SLU"] = "���(�)"; break;
					case "�����-���������" : rc[i]["NAM_OF_SLU"] = "��(�)"; break;
					case "�����-�����" : rc[i]["NAM_OF_SLU"] = "�����.(�)"; break;
					case "�����-������" : rc[i]["NAM_OF_SLU"] = "����.(�)"; break;
					case "�����-����" : rc[i]["NAM_OF_SLU"] = "����(�)"; break;
					case "�����-���������������" : rc[i]["NAM_OF_SLU"] = "�/�(�)"; break;
					case "������������ ����������" : rc[i]["NAM_OF_SLU"] = "����."; break;
					case "�����-��" : rc[i]["NAM_OF_SLU"] = "��(�)"; break;
					case "�����-����� (��������)" : rc[i]["NAM_OF_SLU"] = "�����(�)"; break;
					case "���.������������ ���" : rc[i]["NAM_OF_SLU"] = "�� ���"; break;
					case "������ ������������� �������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "�� �-�� � �����.�� ����.�����" : rc[i]["NAM_OF_SLU"] = "����"; break;
					case "�� �-�� � �������. �����������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "����������� � ������������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "������ �������������� ������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "������������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "����������� ������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "���������� �������������" : rc[i]["NAM_OF_SLU"] = "���"; break;
					case "������� ������" : rc[i]["NAM_OF_SLU"] = "��"; break;
					case "�������������� ������" : rc[i]["NAM_OF_SLU"] = "��"; break;
					case "������������� ���������.������" : rc[i]["NAM_OF_SLU"] = "��"; break;
					case "�� ��������� �������������" : rc[i]["NAM_OF_SLU"] = "��"; break;
					case "��������� �����������" : rc[i]["NAM_OF_SLU"] = "��."; break;
				}
			}
			
		}
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			kadry.Security.Security s = new kadry.Security.Security();

			if (!s.CheckSecurePage(User.Identity.Name,"svodTable.aspx")) Response.Redirect("\\AccessDenied.htm",true);

			s.AddLogText("�������� ������� ������� ��������",Context.Request.UserHostAddress.ToString(),28,true);

			rc = (DataRowCollection)Cache["dataset"];
			ChangeSluzb();
			DataSet ds = new DataSet();
			ds.Tables.Add("Table");

			ArrayList sluzlist = new ArrayList(); // ������ ���������� �����
			ArrayList podrlist = new ArrayList(); // ������ ���������� ����-�
            
			for( int i=0; i<rc.Count; i++) // ���������...
			{
				if ( !sluzlist.Contains(rc[i]["NAM_OF_SLU"].ToString())) sluzlist.Add(rc[i]["NAM_OF_SLU"].ToString());
				if ( !podrlist.Contains(rc[i]["PODRAZDEL"].ToString())) podrlist.Add(rc[i]["PODRAZDEL"].ToString());
			}
			
			// �����
			string[] title = new string[sluzlist.Count + 1];
			title[0] = "  �������������/������  ";
			int index = 1;
            foreach( string slz in sluzlist ) { title[index] = slz; index++; }
			
			for( int j=0; j<sluzlist.Count + 1; j++) 
			{
				ds.Tables["Table"].Columns.Add(title[j]);
			}

			index = 0;
			int curPodr = 0;
			int prevPodr = 0;
			string[] row = new string[sluzlist.Count + 1];
			string[] bottom = new string[sluzlist.Count + 1];
            bottom[0] = "�����:";

			do
			{
				curPodr = Convert.ToInt16(rc[index]["PODRAZD"]);
				int pos = ds.Tables["Table"].Columns.IndexOf(rc[index]["NAM_OF_SLU"].ToString());
				row[pos] = "-" + rc[index]["VAK"].ToString();
				bottom[pos] = Convert.ToString(Convert.ToInt16(rc[index]["VAK"]) + Convert.ToInt16(bottom[pos]));

				if ( prevPodr != curPodr && prevPodr != 0 )
				{
					row[0] = rc[index-1]["PODRAZDEL"].ToString();
					for( int j=0; j<sluzlist.Count + 1;j++ ) if ( row[j] == null ) row[j] = " ";
					ds.Tables["Table"].Rows.Add(row);
					for( int j=0; j<sluzlist.Count + 1;j++ ) row[j] = null;
				} 
				prevPodr = curPodr;
				index++;
			
			} while ( index < rc.Count);

			ds.Tables["Table"].Rows.Add(bottom);
            									
			Grid.DataSource = ds;
			Grid.DataMember = "Table";
			Grid.DataBind();

			Grid.Items[Grid.Items.Count-2].Font.Bold = true;

			for( int i=0; i< Grid.Items.Count; i++ )
			{
				Grid.Items[i].Cells[0].HorizontalAlign = HorizontalAlign.Left;
				Grid.Items[i].Cells[0].Font.Bold = true;
			}

			Cache.Remove("dataset");

			TitleText.Text = "������� ������� �������� ���������� �������������� ������� ��� �� ���������� ������� �� ��������� �� " + System.DateTime.Today.ToShortDateString();

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
