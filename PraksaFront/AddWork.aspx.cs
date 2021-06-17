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
    public partial class AddWork : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        string date = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            date = Request.QueryString["date"];
            System.Diagnostics.Debug.WriteLine(date);
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(date))
                {
                    dateRow.Visible = false;
                    dateText.Text = date;
                    lblHeader.Text = "Dodaj akciju za datum - " + date;
                }
            }
        }

        protected void Submit_Command(object sender, CommandEventArgs e)
        {
            bool isEmpty = CheckFields();

            if (!isEmpty)
            {
                Work work = new Work
                {
                    Name = workText.Text,
                    Description = descriptionText.Text,
                    Date = dateText.Text.ToString(),
                    Time = timeText.Text.ToString(),
                    Location = cityText.Text + ", " + streetText.Text,
                    Obligation = obligationButton.SelectedValue
                };

                work.CreateWork(connectionString, work);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
            }
        }
        protected void Cancel_Command(object sender, CommandEventArgs e)
        {
            workText.Text = "";
            descriptionText.Text = "";
            dateText.Text = "";
            timeText.Text = "";
            cityText.Text = "";
            streetText.Text = "";
            obligationButton.SelectedIndex = -1;
        }

        protected bool CheckFields()
        {
            errorTime.Visible = false; errorDate.Visible = false; errorObligation.Visible = false; errorName.Visible = false;
            errorDescription.Visible = false; errorCity.Visible = false; errorStreet.Visible = false;
            bool rtn = false;
            if (String.IsNullOrEmpty(timeText.Text)) {
                rtn = true;
                errorTime.Visible = true;
            }
            if (String.IsNullOrEmpty(dateText.Text)) {
                rtn = true;
                errorDate.Visible = true;
            }
            if (obligationButton.SelectedIndex == -1){
                rtn = true;
                errorObligation.Visible = true;
            }
            if (String.IsNullOrEmpty(workText.Text)){
                rtn = true;
                errorName.Visible = true;
            }
            if (String.IsNullOrEmpty(descriptionText.Text)){
                rtn = true;
                errorDescription.Visible = true;
            }
            if (String.IsNullOrEmpty(cityText.Text)){
                rtn = true;
                errorCity.Visible = true;
            }
            if (String.IsNullOrEmpty(streetText.Text)){
                rtn = true;
                errorStreet.Visible = true;
            }
            return rtn;
        }
    }
}