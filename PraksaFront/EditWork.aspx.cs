using PraksaMid.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class EditWork : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        int workId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["userId"] != "")
                workId = Convert.ToInt16(Request.QueryString["workId"]);
            else
                Response.Redirect("Users.aspx");
            if (!IsPostBack)
            {
                FillWorkData();
            }
        }

        private void FillWorkData()
        {
            Work work = new Work();
            work = work.GetWork(connectionString, workId);
            workText.Text = work.Name;
            descriptionText.Text = work.Description;
            dateText.Text = work.Date;
            timeText.Text = work.Time;
            locationText.Text = work.Location;
            if(work.Obligation == "Obavezno")
                obligationButton.SelectedValue = "1";
            else 
                obligationButton.SelectedValue = "0";
        }
        protected void Submit_Command(object sender, CommandEventArgs e)
        {
            Work work = new Work
            {
                Id = workId,
                Name = workText.Text,
                Description = descriptionText.Text,
                Date = dateText.Text.ToString(),
                Time = timeText.Text.ToString(),
                Location = locationText.Text,
                Obligation = obligationButton.SelectedValue
            };

            work.EditWork(connectionString, work);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }
        protected void Cancel_Command(object sender, CommandEventArgs e)
        {
            workText.Text = "";
            descriptionText.Text = "";
            dateText.Text = "";
            timeText.Text = "";
            locationText.Text = "";
            obligationButton.SelectedIndex = -1;
        }
    }
}