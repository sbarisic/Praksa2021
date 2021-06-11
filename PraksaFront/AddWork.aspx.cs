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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Command(object sender, CommandEventArgs e)
        {
            bool isEmpty = String.IsNullOrEmpty(workText.Text) || String.IsNullOrEmpty(descriptionText.Text) || String.IsNullOrEmpty(dateText.Text.ToString()) ||
                            String.IsNullOrEmpty(timeText.Text.ToString()) && String.IsNullOrEmpty(cityText.Text) || String.IsNullOrEmpty(streetText.Text)
                            || obligationButton.SelectedIndex == -1;

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


    }
}