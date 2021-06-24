using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class UserWork : System.Web.UI.Page
    {
        static string urlStart = "https://www.google.com/maps/embed/v1/place?q=";
        static string urlEnd = "&key=AIzaSyC6FB2tRFJv8tK0k7t-KzY5GLsxFehcWeM";
        protected string url;

        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.All();

            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        void LoadData()
        {
            UserWorkList.DataSource = Work.GetWorks();
            UserWorkList.DataBind();
            SelectAttendanceButton();
        }

        private void SelectAttendanceButton()
        {
            foreach (RepeaterItem item in UserWorkList.Items)
            {
                HiddenField hdn = (HiddenField)item.FindControl("hdnId");
                LinkButton yesButton = (LinkButton)item.FindControl("yesButton");
                LinkButton noButton = (LinkButton)item.FindControl("noButton");
                LinkButton maybeButton = (LinkButton)item.FindControl("maybeButton");
                int iduser = Person.GetUserId((string)Session["uname"]);
                int workId = Convert.ToInt32(hdn.Value);
                AttendantModel att = Attendant.GetAttendant(workId, iduser);
                System.Diagnostics.Debug.WriteLine("work id - " + workId + "Id user" + iduser + " || idInteres " + att.IdInteres);

                switch (att.IdInteres)
                {
                    case 1:
                        noButton.BackColor = System.Drawing.Color.FromArgb(41, 194, 61);
                        maybeButton.BackColor = System.Drawing.Color.FromArgb(68, 141, 78);
                        yesButton.BackColor = System.Drawing.Color.FromArgb(68, 141, 78);
                        break;
                    case 2:
                        maybeButton.BackColor = System.Drawing.Color.FromArgb(41, 194, 61);
                        noButton.BackColor = System.Drawing.Color.FromArgb(68, 141, 78);
                        yesButton.BackColor = System.Drawing.Color.FromArgb(68, 141, 78);
                        break;
                    case 3:
                        yesButton.BackColor = System.Drawing.Color.FromArgb(41, 194, 61);
                        maybeButton.BackColor = System.Drawing.Color.FromArgb(68, 141, 78);
                        noButton.BackColor = System.Drawing.Color.FromArgb(68, 141, 78);
                        break;
                }
            }
        }

        protected void yes_Command(object sender, CommandEventArgs e)
        {
            Attendance(Convert.ToInt32(e.CommandArgument), 3);
            SelectAttendanceButton();
        }
        protected void no_Command(object sender, CommandEventArgs e)
        {
            Attendance(Convert.ToInt32(e.CommandArgument), 1);
            SelectAttendanceButton();
        }
        protected void maybe_Command(object sender, CommandEventArgs e)
        {
            Attendance(Convert.ToInt32(e.CommandArgument), 2);
            SelectAttendanceButton();
        }

        protected void locButton_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
            Button btn = (Button)sender;
            url = urlStart + btn.Text + urlEnd;
        }

        private void Attendance(int idjob, int interes)
        {
            int iduser = Person.GetUserId((string)Session["uname"]);

            AttendantModel attendant = new AttendantModel
            {
                IdJob = idjob,
                IdInteres = interes,
                IdUser = iduser,
                IdAttendance = 1
            };

            AttendantModel att = Attendant.GetAttendant(idjob, iduser);

            if (att.Id != 0)
            {
                attendant.Id = att.Id;
                Attendant.EditAttendant(attendant);
            }
            else
                Attendant.CreateAttendant(attendant);
        }

    }
}