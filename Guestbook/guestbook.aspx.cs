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
using System.Xml;
using System.Xml.Xsl;
using System.IO;

namespace kadry.Guestbook
{
	/// <summary>
	/// Summary description for guestbook.
	/// </summary>
	public partial class guestbook : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//Load guestbook database from the xml file
			XmlDocument doc = new XmlDocument();
			doc.Load( Server.MapPath("guestbook.xml"));

			// Get the page number asked
			string strPageAsked = Request.QueryString["page"];

			// If the page is not defined then set it to first one
			if ( strPageAsked == null )
			{
				strPageAsked = "1";
			}

			int nGuestPerPage = 5;
			int nGuests = doc.ChildNodes[1].ChildNodes.Count;

			int nPageAsked = System.Convert.ToInt32(strPageAsked);

			int lowerbound = 1 + ( nPageAsked - 1 ) * nGuestPerPage;
			int upperbound = lowerbound + nGuestPerPage - 1;

			//Do XSLT transformation
			XslTransform xslt = new XslTransform();
			xslt.Load("guestbook.xslt");

			//Build XLST Param list
			XsltArgumentList xsltArgs = new XsltArgumentList();
			xsltArgs.AddParam("lowerbound", "", lowerbound.ToString());
			xsltArgs.AddParam("upperbound", "", upperbound.ToString());

			//Transform XML to HTML
			MemoryStream ms = new MemoryStream();
			//xslt.Transform( doc, xsltArgs, ms );
			ms.Seek( 0, SeekOrigin.Begin );

			StreamReader sr = new StreamReader(ms);

			//Insert result in the View.aspx page
			LiteralGuests.Text = sr.ReadToEnd();

			//Insert the pages navigator at the bottom of the page
			int nPages = 0;
    
			if (( nGuests % nGuestPerPage) != 0 )
				nPages = 1 + (nGuests / nGuestPerPage);
			else
				nPages = (nGuests / nGuestPerPage);

			LiteralGuests.Text += "Page(s) ";

			for (int n = 1; n <= nPages; n++)
			{
				LiteralGuests.Text += "<font face='verdana' size='2'>";
				LiteralGuests.Text += "<a href='guestbook.aspx?page=";
				LiteralGuests.Text += n.ToString();
				LiteralGuests.Text += "'>";
				LiteralGuests.Text += n.ToString();
				LiteralGuests.Text += "</a></font> ";
			}

			sr.Close();
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

		private void addTextElement( XmlDocument doc, XmlElement nodeParent, 
			string strTag, string strValue )
		{
			XmlElement nodeElem = doc.CreateElement( strTag );
			XmlText nodeText = doc.CreateTextNode( strValue );
			nodeParent.AppendChild( nodeElem );
			nodeElem.AppendChild( nodeText );
		}

		protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//Load guestbook database
			XmlDocument xmldoc = new XmlDocument();
			xmldoc.Load("guestbook.xml");

			//Get private status
			string strPrivate;
			if ( CheckBoxPrivate.Checked )
				strPrivate = "yes";
			else
				strPrivate = "no";

			//Create a new element
			XmlElement elem = xmldoc.CreateElement("guest");
			elem.SetAttribute("private", strPrivate);

			//Add the new guest as the first node
			xmldoc.DocumentElement.PrependChild(elem);

			addTextElement( xmldoc, elem, "name", TextBoxName.Text );
			addTextElement( xmldoc, elem, "email", TextBoxEMail.Text );
			addTextElement( xmldoc, elem, "homepage", TextBoxHomepageTitle.Text );

			XmlAttribute newAttr = xmldoc.CreateAttribute("url");
			newAttr.Value = TextBoxHomepageURL.Text;

			elem.LastChild.Attributes.Append( newAttr );
    
			addTextElement( xmldoc, elem, "location", TextBoxLocation.Text );
			addTextElement( xmldoc, elem, "comment", TextBoxComments.Text );

			//Write date
			string strDate = DateTime.Now.ToLongDateString() + 
				" - " + 
				DateTime.Now.ToLongTimeString(); 

			addTextElement( xmldoc, elem, "date", strDate );

			xmldoc.Save("guestbook.xml");

			Response.Redirect("guestbook.aspx");
		}
	}
}
