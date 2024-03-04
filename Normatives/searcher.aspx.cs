using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace UK.Normatives
{
	/// <summary>
	/// Summary description for searcher.
	/// </summary>
	public class searcher : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected string strText;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			strText = Request.QueryString["text"].ToString().Trim();
			Label1.Text = Search_Dir(strText, this.Server.MapPath("/Normatives/Store/Kad/"));

		}
		public string Search_Dir(string strS, string path)
		{
			//���������� ���������� ��� �����������
			StringBuilder strRes=new StringBuilder();
			//������ ��� �������� HTML-�����
			Regex rex=new Regex("<[^>]*>");
			//������ ��� ��������� TITLE-a
			Regex rex2=new Regex("<title>(.*)</title>", RegexOptions.IgnoreCase);
			//���������� ���������
			int nFound=0;
			DirectoryInfo di=new DirectoryInfo(path);
			foreach(FileInfo f in di.GetFiles("*.htm"))
			{
				//��������� ����
				StreamReader sr=new StreamReader(f.FullName, Encoding.Default);
				string strF=sr.ReadToEnd();
				sr.Close();
				//������� HTML-����
				string strContent=rex.Replace(strF,"");
				//���� �����
				int nStart=strContent.ToLower().IndexOf(strS.ToLower());
				if(nStart>0)//�����
				{
					nFound++;//���������� �������
					//���������
					strRes.Append("<p><a target=_blank href=\"/Normatives/Store/Kad/");
					strRes.Append(f.Name);
					strRes.Append("\">");
					strRes.Append(rex.Replace(rex2.Match(strF).Value,""));
					strRes.Append("</a><br>");
					//�����
					strRes.Append("<hr>");
					//��������
					int nApear=0;
					nStart=0;
					while((nStart=strContent.ToLower().IndexOf(strS.ToLower(),nStart+strS.Length))>0)
					{
						nApear++;
						if(nApear<7)
						{
							int nDo=Math.Min(50, nStart);
							int nPosle=Math.Min(50, strContent.Length -(strS.Length+nStart))-1;
							strRes.Append("...");
							strRes.Append(strContent.Substring(nStart-nDo, nDo));
							strRes.Append("<span style=\"background-color: yellow; font-weight: bold\">");
							strRes.Append(strContent.Substring(nStart,strS.Length));
							strRes.Append("</span>");
							strRes.Append(strContent.Substring(nStart+strS.Length, nPosle));
							strRes.Append("...<br>");
						}
					}
					strRes.Append("<br>");
					strRes.Append("���������� ���������� �� �������� "+nApear.ToString());
					strRes.Append("</p>");
  
				}
			}
			if(nFound==0)
				strRes.Insert(0,"<font face=\"verdana\" size=\"2\">������ �� �������</font>");
			else
				strRes.Insert(0,"<font face=\"verdana\" size=\"2\">����� ������� ����������: "+nFound.ToString() + "</font>");
			strRes.Insert(0,"<h3>�� ������ � ����������� ����: \"" + strText + "\"</h3>");
			return strRes.ToString();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
