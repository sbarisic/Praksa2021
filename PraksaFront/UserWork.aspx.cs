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
        }
        protected void no_Command(object sender, CommandEventArgs e)
        {
            Attendance(Convert.ToInt32(e.CommandArgument), 1);
        }
        protected void maybe_Command(object sender, CommandEventArgs e)
        {
            Attendance(Convert.ToInt32(e.CommandArgument), 2);
        }

        protected void locButton_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
            Button btn = (Button)sender;
            url = urlStart + btn.Text + urlEnd;
        }

        private void Attendance(int idjob, int interes)
        {
            int iduser = Person.GetUserId(connectionString, (string)Session["uname"]);

            AttendantModel att = Attendant.GetAttendantId(connectionString, idjob, iduser);

            if (att.Id != 0)
            {
                att = Attendant.GetAttendant(connectionString, idjob, iduser);
                att.IdInteres = interes;
                Attendant.EditAttendant(connectionString, att);
            }
            else
            {
                AttendantModel attendant = new AttendantModel
                {
                    IdJob = Convert.ToInt32(idjob),
                    IdInteres = interes,
                    IdUser = iduser
                };
                Attendant.CreateAttendant(connectionString, attendant);
            }
        }

    }
}