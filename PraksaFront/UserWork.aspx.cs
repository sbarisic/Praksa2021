using PraksaMid;
using PraksaMid.Model;
using System;
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
            Logic.SessionManager.All();

            if (!Page.IsPostBack)
            {
                UserWorkList.DataSource = Work.GetWorks(connectionString);
                UserWorkList.DataBind();
            }
        }

        protected void yes_Command(object sender, CommandEventArgs e)
        {
            Attendance(Convert.ToInt32(e.CommandArgument), 3);
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.Green;
        }
        protected void no_Command(object sender, CommandEventArgs e)
        {
            Attendance(Convert.ToInt32(e.CommandArgument), 1);
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.Green;
        }
        protected void maybe_Command(object sender, CommandEventArgs e)
        {
            Attendance(Convert.ToInt32(e.CommandArgument), 2);
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.Green;
        }

        protected void locButton_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
            Button btn = (Button)sender;
            url = urlStart + btn.Text + urlEnd;
        }

        private void Attendance(int Idjob, int interes)
        {
            int iduser = Person.GetUserId(connectionString, (string)Session["uname"]);

            AttendantModel attendant = new AttendantModel
            {
                IdJob = Convert.ToInt32(Idjob),
                IdInteres = interes,
                IdUser = iduser,
                IdAttendance = 1
            };

            AttendantModel att = Attendant.GetAttendant(connectionString, Idjob, iduser);

            if (att.Id != 0)
            {
                attendant.Id = att.Id;
                Attendant.EditAttendant(connectionString, attendant);
            }
            else
                Attendant.CreateAttendant(connectionString, attendant);
        }

    }
}