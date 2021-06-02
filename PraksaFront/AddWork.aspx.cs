using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class AddWork : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Command(object sender, CommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(workText.Text + " | " + descriptionText.Text + " | " + dateText.Text + " | " + timeText.Text + " | " + RadioButton.SelectedValue);
        }
        protected void Cancel_Command(object sender, CommandEventArgs e)
        {
            workText.Text = "";
            descriptionText.Text = "";
            dateText.Text = "";
            timeText.Text = "";
            locationText.Text = "";
            RadioButton.SelectedIndex = -1;
            System.Diagnostics.Debug.WriteLine("test");
        }
    }
}