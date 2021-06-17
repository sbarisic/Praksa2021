using PraksaMid;
using PraksaMid.Model;
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
    public partial class UserWork : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        static string urlStart = "https://www.google.com/maps/embed/v1/place?q=";
        static string urlEnd = "&key=AIzaSyC6FB2tRFJv8tK0k7t-KzY5GLsxFehcWeM";
        protected string url;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Work work = new Work();
                UserWorkList.DataSource = work.GetWorks(connectionString);
                UserWorkList.DataBind();
            }
        }

        protected void yes_Command(object sender, CommandEventArgs e)
        {
            AttendantModel attendant = new AttendantModel();
            attendant.IdJob = Convert.ToInt32(e.CommandArgument.ToString());
            attendant.IdInteres = 3;
            attendant.IdUser = 11; //GET LOGGED IN USER ID
            attendant.IdAttendance = 1;
            Attendant.CreateAttendant(connectionString, attendant);
            
            System.Diagnostics.Debug.WriteLine("Dolazi na " + e.CommandArgument.ToString());
        }
        protected void no_Command(object sender, CommandEventArgs e)
        {
            AttendantModel attendant = new AttendantModel();
            attendant.IdJob = Convert.ToInt32(e.CommandArgument.ToString());
            attendant.IdInteres = 1;
            attendant.IdUser = 11; //GET LOGGED IN USER ID
            attendant.IdAttendance = 1;
            Attendant.CreateAttendant(connectionString, attendant);

            System.Diagnostics.Debug.WriteLine("Ne dolazi na " + e.CommandArgument.ToString());
        }
        protected void maybe_Command(object sender, CommandEventArgs e)
        {
            AttendantModel attendant = new AttendantModel();
            attendant.IdJob = Convert.ToInt32(e.CommandArgument.ToString());
            attendant.IdInteres = 2;
            attendant.IdUser = 11; //GET LOGGED IN USER ID
            attendant.IdAttendance = 1;
            Attendant.CreateAttendant(connectionString, attendant);

            System.Diagnostics.Debug.WriteLine("Mozda dolazi na " + e.CommandArgument.ToString());
        }

        protected void locButton_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
            Button btn = (Button)sender;
            url = urlStart + btn.Text + urlEnd;
        }

    }
}