using System;
using System.Collections;

namespace kadry 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>

	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
			
				
		private System.ComponentModel.IContainer components = null;
		

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
			Session["nek"] = new ArrayList();
			Session["obraz1"] = new ArrayList();
			Session["obraz2"] = new ArrayList();
			Session["people"] = new People();
			Session["List"] = new ArrayList();
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		//------------------------------------------------------------------------//
		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
			
		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
			
		}
		#endregion


		
	}

	public class People
	{
		public int key;
		public string FirstName;
		public string Name;
		public string SecondName;
		public string Photo;
		public string Comment;
	}

	public class SecureFields
	{
		protected static string podrazd;
		protected static string podr;
		protected static string sluzba;
		protected static string dolznost;
	}

	public class Vars
	{
		public static string sbase; // Текущая база...
		public static string CmdText;
		public static string CurrentUserName;
		public static int UsersCount;
		public static string Keys;
		public static int CurID;
	
	}

	public struct OtherWork // Гражданский стаж
	{
		public string From;
		public string To;
		public string Legend;
	}

	public struct SpecRank // Информация по званиям
	{
		public string Rank;
		public string OVDPrik;
		public string NumPrik;
		public string DatePrik;
		public string DateRank;
	}
	
	public struct SpecWork // Послужной список
	{
		public string From;
		public string Zvan;
		public string Dolz;
		public string Podr;
		public string Status;
		public string OVDPrik;
		public string NumPrik;
		public string DatePrik;
	}
	
	public struct Komand // Командировки
	{
		public string From;
		public string To;
		public string Koeff;
		public string Legend;
		public string Prik;
		public string Date_pr;
		public string Num_pr;
	}

	public struct Nakazan // Взыскания
	{
		public string Date;
		public string OVDPrik;
		public string NumPrik;
		public string Vzysk;
		public string Legend;
		public string DateSn;
		public string WhoSn;
		public string NumPrSn;
	}

	public struct Poo // Поощрения
	{
		public string Vid;
		public string Prich;
		public string OVDPrik;
		public string NumPrik;
		public string DatePrik;
	}

	public struct Details  // Полная информация (форма-2) в текстовом виде
	{
		public string FIO;
		public string Born;
		public string BornPlace;
		public string Nation;
		public string PersonalNumber;
		public string Learn;
		public string PersonalFileNumber;
		public string PhotoFile;
		public string Army;
		public ArrayList Work;
		public ArrayList Rank;
		public string vOVD;
		public string vSLU;
		public string vDOL;
		public ArrayList Posl;
		public ArrayList Lgottime;
		public ArrayList Nak;
		public ArrayList Nagr;
	}

	public class Fn
	{

		public static string D2STR( object date ) // преобразование Даты в строку типа DD.MM.YYYY
		{
			string str = Convert.ToString(date);
			if ( str.Length != 0 )
			{ 
				str = str.Substring(0,10);
			} 
			else
			{ 
				str = "...";
			}
			return str;
		}
	
	}


}

