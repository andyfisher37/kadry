using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;

namespace kadry.Services
{
	
	public class TreeNode
	{
		// ����� ����
		// ��� ������������ � XML ������������ � ���� ��������
		[XmlAttribute(AttributeName = "Text")]
		public string Text;
		[XmlAttribute(AttributeName = "TreeNodeSrc")]
		public string TreeNodeSrc;
		// �����������, �������������� ����������� ������������
		public TreeNode() {}
		// "�����������" �����������
		public TreeNode(int parent, int id)
		{
			Text = "���� " + parent.ToString() + "-" + id.ToString();
			TreeNodeSrc = "Services/Struct.asmx/GetSubTree?id=" + id.ToString();
		}
	}

	// ������ ����� ������
	// ��� ������������ � XML ������������ � ���� ��������� ��������
	[XmlRoot("TREENODES")]
		
	public class TreeNodes
	{
		// ���� ������
		// ��� ������������ � XML ������������ � ���� ��������� ���������
		[XmlElement("TREENODE")]
		public TreeNode[] Nodes = new TreeNode[3];
		// �����������, �������������� ����������� ������������
		public TreeNodes() {}
		// "�����������" �����������
		public TreeNodes(int id)
		{
			for (int i = 0; i < 3; i++)
			{
				Nodes[i] = new TreeNode(id, i + 1);
			}
		}
	}
	
	[WebService (Namespace="kadry.Services")]
	
	public class Struct : System.Web.Services.WebService
	{
		public Struct()
		{
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		// ���������������� ������ �� ������������ �������� ����� 
		[WebMethod]
		public TreeNodes GetSubTree(int id)
		{
			return new TreeNodes(id);
		}
	}
}
