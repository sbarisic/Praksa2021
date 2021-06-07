using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class Calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private System.Data.DataTable GetData()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Date");
            dt.Columns.Add("Desc");
            dt.Rows.Add("01/July/2019 ", "party time");
            dt.Rows.Add("02/July/2019", "holiday");
            dt.Rows.Add("30/June/2019", "holiday");
            dt.Rows.Add("15/August/2019", "holiday");
            return dt;
        }
 
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            System.Data.DataTable dt = GetData();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                if (Convert.ToDateTime(e.Day.Date) == Convert.ToDateTime(row["Date"]))
                    {
                    Label Label1 = new Label();
                    Label1.Text = "<br/>";
                    Label Label2 = new Label();
                    Label2.Text = "Desc";
                    e.Cell.Controls.Add(Label1);
                    e.Cell.Controls.Add(Label2);
                    }
            }
        }
    }



}