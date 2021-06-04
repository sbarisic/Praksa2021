using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class AdminWork : System.Web.UI.Page
    {

        protected List<string> actionList = new List<string>(new string[] { "Košnja trave", "Branje jabuka", "Test" });
        static string urlStart = "https://www.google.com/maps/embed/v1/place?q=";
        static string urlEnd = "&key=AIzaSyC6FB2tRFJv8tK0k7t-KzY5GLsxFehcWeM";
        protected string url;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UserWorkList.DataSource = actionList;
                UserWorkList.DataBind();
            }
        }
        protected void edit_Command(object sender, CommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("edit " + e.CommandArgument.ToString());
        }
        protected void delete_Command(object sender, CommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("delete " + e.CommandArgument.ToString());
        }
        protected void locButton_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
            Button btn = (Button)sender;
            url = urlStart + btn.Text + urlEnd;
        }

    }
}