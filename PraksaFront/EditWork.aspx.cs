using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class EditWork : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected int workId = 0;
        protected string AttendanceFrameUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.See();

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
            WorkModel work = Work.GetWork(connectionString, workId);
            workText.Text = work.Name;
            descriptionText.Text = work.Description;
            dateText.Text = work.Date;
            timeText.Text = work.Time;
            locationText.Text = work.Location;
            lblHeader.Text = "Uredi akciju za datum - " + work.Date;
            if (work.Obligation == "Obavezno")
                obligationButton.SelectedValue = "1";
            else
                obligationButton.SelectedValue = "0";
        }
        protected void Submit_Command(object sender, CommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(timeText.Text);
            WorkModel work = new WorkModel
            {
                Id = workId,
                Name = workText.Text,
                Description = descriptionText.Text,
                Date = dateText.Text.ToString(),
                Time = timeText.Text,
                Location = locationText.Text,
                Obligation = obligationButton.SelectedValue
            };

            Work.EditWork(connectionString, work);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }
        protected void delete_Command(object sender, CommandEventArgs e)
        {
            Work.DeleteWork(connectionString, workId);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }

        protected void attendance_Command(object sender, CommandEventArgs e)
        {
            AttendanceFrameUrl = "Attendants.aspx?workId=" + workId;
            ModalPopupExtender3.Show();
        }
    }
}