using PraksaMid;
using System;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class PastWork : System.Web.UI.Page
    {
        static readonly string urlStart = "https://www.google.com/maps/embed/v1/place?q=";
        static readonly string urlEnd = "&key=AIzaSyC6FB2tRFJv8tK0k7t-KzY5GLsxFehcWeM";
        protected string url;
        protected string AttendanceFrameUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.See();

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void LoadData()
        {
            UserWorkList.DataSource = Work.GetDoneWorks();
            UserWorkList.DataBind();
        }

        protected void locButton_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
            Button btn = (Button)sender;
            url = urlStart + btn.Text + urlEnd;
        }
        protected void hdnBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("PastWork.aspx");
        }

        protected void attendance_Command(object sender, CommandEventArgs e)
        {
            AttendanceFrameUrl = "Attendants.aspx?workId=" + e.CommandArgument;
            ModalPopupExtender3.Show();
        }
    }
}