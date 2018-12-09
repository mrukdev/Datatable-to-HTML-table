using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace ShopApp.Extensions
{
    public class DatatableHtmlHelper
    {
        public static string HtmlFromDataTable(DataTable dt)
        {
            StringBuilder html = new StringBuilder();
            List<string> columnNames = new List<string>();
            var headerNames = dt.Columns;

            foreach (var colName in headerNames)
            {
                columnNames.Add(colName.ToString());
            }
            List<DataRow> rows = dt.AsEnumerable().ToList();

            //create html
            html.Append("<table class='table table-responsive table-stripped table-bordered'>"+Environment.NewLine);
            html.Append("<thead><tr>");
            foreach (var item in columnNames)
            {
                html.Append("<th>");
                html.Append(item);
                html.Append("</th>");
            }
            html.Append("</tr>");          
            html.Append("</thead>");      
            html.Append("<tbody>");

            foreach (var row in rows)
            {
                html.Append("<tr>");
                foreach (var item in row.ItemArray)
                {
                    html.Append("<td>");
                    html.Append(item.ToString());
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            html.Append("</tbody>");
            html.Append("</table>");
            return html.ToString();
        }
    }
}