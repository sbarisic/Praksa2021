using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class AboutWork : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected int workId = 0;
        static string urlStart = "https://www.google.com/maps/embed/v1/place?q=";
        static string urlEnd = "&key=AIzaSyC6FB2tRFJv8tK0k7t-KzY5GLsxFehcWeM";
        protected string url;
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.All();

            if (Request.QueryString["workId"] != "")
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
            WorkModel work = new WorkModel();
            work = Work.GetWork(connectionString, workId);
            workText.Text = work.Name;
            descriptionText.Text = work.Description;
            dateText.Text = work.Date;
            timeText.Text = work.Time;
            locButton.Text = work.Location;
            obligationText.Text = work.Obligation;
            SelectAttendanceButton();
        }

        protected void locButton_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
            Button btn = (Button)sender;
            url = urlStart + btn.Text + urlEnd;
        }

        protected void yes_Command(object sender, CommandEventArgs e)
        {
            Attendance(Convert.ToInt32(workId), 3);
            SelectAttendanceButton();
        }
        protected void no_Command(object sender, CommandEventArgs e)
        {
            Attendance(Convert.ToInt32(workId), 1);
            SelectAttendanceButton();
        }
        protected void maybe_Command(object sender, CommandEventArgs e)
        {
            Attendance(Convert.ToInt32(workId), 2);
            SelectAttendanceButton();
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

            switch (interes)
            {
                case 1:
                    noButton.BackColor = System.Drawing.Color.LimeGreen;
                    maybeButton.BackColor = System.Drawing.Color.White;
                    yesButton.BackColor = System.Drawing.Color.White;
                    break;
                case 2:
                    maybeButton.BackColor = System.Drawing.Color.LimeGreen;
                    noButton.BackColor = System.Drawing.Color.White;
                    yesButton.BackColor = System.Drawing.Color.White;
                    break;
                case 3:
                    yesButton.BackColor = System.Drawing.Color.LimeGreen;
                    maybeButton.BackColor = System.Drawing.Color.White;
                    noButton.BackColor = System.Drawing.Color.White;
                    break;
            }
        }

        void SelectAttendanceButton()
        {
            int iduser = Person.GetUserId(connectionString, (string)Session["uname"]);
            AttendantModel att = Attendant.GetAttendant(connectionString, workId, iduser);
            System.Diagnostics.Debug.WriteLine("work id - " + workId + "Id user" + iduser + " || idInteres " + att.IdInteres);

            switch (att.IdInteres)
            {
                case 1:
                    noButton.BackColor = System.Drawing.Color.LimeGreen;
                    break;
                case 2:
                    maybeButton.BackColor = System.Drawing.Color.LimeGreen;
                    break;
                case 3:
                    yesButton.BackColor = System.Drawing.Color.LimeGreen;
                    break;
            }
        }
    }
}