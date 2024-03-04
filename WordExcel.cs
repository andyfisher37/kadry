using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kadry
{
    public class WordExcel
    {
        // Копирование GRID Таблицы в Excel...
        public static void ExportGridToExcel(System.Web.UI.Page p, DataGrid grdGridView, string fileName)
        {
            p.Response.Clear();
            p.Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xlsx", fileName));
            p.Response.Charset = "";
            p.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            grdGridView.RenderControl(htmlWrite);
            p.Response.Write(stringWrite.ToString());
            p.Response.End();
        }
        
        // Копирование GRID Таблицы в Word...
        public static void ExportGridToWord(System.Web.UI.Page p, DataGrid grdGridView, string fileName)
        {
            p.Response.Clear();
            p.Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.doc", fileName));
            p.Response.Charset = "";
            p.Response.ContentType = "application/vnd.doc";

            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            grdGridView.RenderControl(htmlWrite);
            p.Response.Write(stringWrite.ToString());
            p.Response.End();
        }

        // Копирование TABLE Таблицы в Excel...
        public static void ExportGridToExcel(System.Web.UI.Page p, Table table, string fileName)
        {
            p.Response.Clear();
            p.Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xlsx", fileName));
            p.Response.Charset = "Unicode";
            p.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            table.RenderControl(htmlWrite);
            p.Response.Write(stringWrite.ToString());
            p.Response.End();
        }
             

        // Копирование TABLE Таблицы в Word...
        public static void ExportGridToWord(System.Web.UI.Page p, Table table, string fileName)
        {
            p.Response.Clear();
            p.Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.doc", fileName));
            p.Response.Charset = "Unicode";
            p.Response.ContentType = "application/vnd.doc";

            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            table.RenderControl(htmlWrite);
            p.Response.Write(stringWrite.ToString());
            p.Response.End();
        }

//        public System.IO.StringWriter ExportToExcelXML(DataSet source)
//        {
//System.IO.StringWriter excelDoc;
//excelDoc = new System.IO.StringWriter();
//StringBuilder ExcelXML = new StringBuilder();
//ExcelXML.Append("<xml version>\r\n<Workbook");
//ExcelXML.Append("xmlns='urn:schemas-microsoft-com:office:spreadsheet'\r\n");
//ExcelXML.Append("xmlns:o='urn:schemas-microsoft-com:office:office'\r\n ");
//ExcelXML.Append("xmlns:x='urn:schemas- microsoft-com:office:");
//ExcelXML.Append("excel'\r\n xmlns:ss='urn:schemas-microsoft-com:");
//ExcelXML.Append("office:spreadsheet'>\r\n <Styles>\r\n ");
//ExcelXML.Append("<Style ss:ID='Default' ss:Name='Normal'>\r\n ");
//ExcelXML.Append("<Alignment ss:Vertical='Bottom'/>\r\n <Borders/>");
//ExcelXML.Append("\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>");
//ExcelXML.Append("\r\n <Protection/>\r\n </Style>\r\n ");
//ExcelXML.Append("<Style ss:ID='BoldColumn'>\r\n <Font ");
//ExcelXML.Append("x:Family='Swiss' ss:Bold='1'/>\r\n </Style>\r\n ");
//ExcelXML.Append("<Style ss:ID='StringLiteral'>\r\n <NumberFormat");
//ExcelXML.Append("ss:Format='@'/>\r\n </Style>\r\n <Style ");
//ExcelXML.Append("ss:ID='Decimal'>\r\n <NumberFormat ");
//ExcelXML.Append("ss:Format='0.0000'/>\r\n </Style>\r\n ");
//ExcelXML.Append("<Style ss:ID='Integer'>\r\n <NumberFormat ");
//ExcelXML.Append("ss:Format='0'/>\r\n </Style>\r\n <Style ");
//ExcelXML.Append("ss:ID='DateLiteral'>\r\n <NumberFormat ");
//ExcelXML.Append("ss:Format='mm/dd/yyyy;@'/>\r\n </Style>\r\n ");
//ExcelXML.Append("<Style ss:ID='s28'>\r\n");
//ExcelXML.Append("<Alignment ss:Horizontal='Left' ss:Vertical='Top\ss:ReadingOrder='LeftToRight' ss:WrapText='1'/>\r\n");
//ExcelXML.Append("<Font x:CharSet='1' ss:Size='9' ss:Color='#808080\ss:Underline='Single'/>\r\n");
//ExcelXML.Append("<Interior ss:Color='#FFFFFF' ss:Pattern='Solid'/></Style>\r\n");
//ExcelXML.Append("</Styles>\r\n ");

//string startExcelXML = ExcelXML.ToString();
//const string endExcelXML = "</Workbook>";
//int rowCount = 0;
//int sheetCount = 1;
//excelDoc.Write(startExcelXML);
//excelDoc.Write("<Worksheet ss:Name='Report_Sheet" + sheetCount + "'>");
//excelDoc.Write("<Table>");

///// Header Part
///// Add any Header for the report
/////
//excelDoc.Write("<Row ss:AutoFitHeight='0' ss:Height='6.75'/>\r\n");
//excelDoc.Write("<Row><Cell ss:MergeAcross='10' ss:StyleID='s34'><Data ss:Type='String'>");
//excelDoc.Write("HEADER TEXT");
//excelDoc.Write("</Data></Cell>");
//excelDoc.Write("<Cell ss:MergeAcross='1' ss:StyleID='BoldColumn'><Data ss:Type='String'>");
//excelDoc.Write("Report Date");
//excelDoc.Write("</Data></Cell>");
//excelDoc.Write("<Cell ss:MergeAcross='1' ss:StyleID='DateLiteral'><Data ss:Type='String'>");
//excelDoc.Write(DateTime.Now.ToShortDateString());
//excelDoc.Write("</Data></Cell></Row>"); 
//excelDoc.Write("<Row ss:AutoFitHeight='0' ss:Height='10'/>\r\n");

/////Complete

//excelDoc.Write("<Row>");

//for (int x = 0; x < source.Tables[0].Columns.Count; x++)
//{
//excelDoc.Write("<Cell ss:StyleID='BoldColumn'><Data ss:Type='String'>");
//excelDoc.Write(source.Tables[0].Columns[x].ColumnName);
//excelDoc.Write("</Data></Cell>");
//}

//excelDoc.Write("</Row>");

//foreach (DataRow x in source.Tables[0].Rows)
//{

//rowCount++;
////if the number of rows is > 63000 create a new page to continue output
//if (rowCount == 63000)
//{
//rowCount = 0;
//sheetCount++;
//excelDoc.Write("</Table>");
//excelDoc.Write(" </Worksheet>");
//excelDoc.Write("<Worksheet ss:Name='Report_Sheet" + sheetCount + "'>");
//excelDoc.Write("<Table>");
//excelDoc.Write("<Row>");

//for (int xi = 0; xi < source.Tables[0].Columns.Count; xi++)
//{
//excelDoc.Write("<Cell ss:StyleID='BoldColumn'><Data ss:Type='String'>");
//excelDoc.Write(source.Tables[0].Columns[xi].ColumnName);
//excelDoc.Write("</Data></Cell>");
//}

//excelDoc.Write("</Row>");

//}

//excelDoc.Write("<Row>"); 

//for (int y = 0; y < source.Tables[0].Columns.Count; y++)
//{
//string XMLstring = x[y].ToString();
//XMLstring = XMLstring.Trim();
//XMLstring = XMLstring.Replace("&", "&");
//XMLstring = XMLstring.Replace(">", ">");
//XMLstring = XMLstring.Replace("<", "<");
//excelDoc.Write("<Cell ss:StyleID='StringLiteral'><Data ss:Type='String'>");
//excelDoc.Write(XMLstring);
//excelDoc.Write("</Data></Cell>");
//}

//excelDoc.Write("</Row>");

//}

/////Ending Tag
/////
//excelDoc.Write("<Row ss:Height='15'><Cell ss:HRef='http://www.sachinkumark.com/'>http://www.sachinkumark.com\ss:MergeAcross='2' ss:StyleID='s28'><Data ss:Type='String'>");
//excelDoc.Write("www.sachinkumark.com");
//excelDoc.Write("</Data></Cell></Row>");
//excelDoc.Write("<Row ss:Height='15'><Cell ss:MergeAcross='6'ss:StyleID='s28'><Data ss:Type='String'>");
//excelDoc.Write("Copyright � 2007");
//excelDoc.Write("</Data></Cell></Row>"); 

/////Complete
//excelDoc.Write("</Table>");
//excelDoc.Write(" </Worksheet>");
//excelDoc.Write(endExcelXML);
//return excelDoc;

//        }


    }
}
