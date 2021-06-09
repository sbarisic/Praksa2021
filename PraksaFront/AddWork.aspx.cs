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
            Work work = new Work
            {
                Name = workText.Text,
                Description = descriptionText.Text,
                Date = dateText.Text.ToString(),
                Time = timeText.Text.ToString(),
                Location = locationText.Text
            };

            work.CreateWork(connectionString, work);
        }
        protected void Cancel_Command(object sender, CommandEventArgs e)
        {
            workText.Text = "";
            descriptionText.Text = "";
            dateText.Text = "";
            timeText.Text = "";
            locationText.Text = "";
            RadioButton.SelectedIndex = -1;
        }


    }
}