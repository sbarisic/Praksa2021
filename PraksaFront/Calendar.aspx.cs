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
            dt.Columns.Add("Name");
            dt.Columns.Add("Time");
            dt.Rows.Add("07/June/2021 ", "party time", "16:45");
            dt.Rows.Add("02/July/2019", "holiday", "Bjelovar");
            dt.Rows.Add("30/June/2019", "holiday", "Bjelovar");
            dt.Rows.Add("15/August/2019", "holiday", "Bjelovar");
            return dt;
        }
 
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            System.Data.DataTable dt = GetData();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                if (Convert.ToDateTime(e.Day.Date) == Convert.ToDateTime(row["Date"]))
                    {
                    System.Web.UI.WebControls.Label Label2 = new System.Web.UI.WebControls.Label();
                    Label2.Text = "<br/>" + Convert.ToString(row["Name"]) + "<br/>" + Convert.ToString(row["Time"]);
                    e.Cell.Controls.Add(Label2);
                }
            }
        }

        protected void Selection_Change(Object sender, EventArgs e)
        {
            foreach (DateTime day in Calendar1.SelectedDates)
            {
                ModalPopupExtender1.Show();
                System.Diagnostics.Debug.WriteLine(day.Date.ToShortDateString());
            }

        }

        protected void actionBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("testing<<<<<");
            ModalPopupExtender1.Show();
            Button btn = (Button)sender;
        }
    }



}