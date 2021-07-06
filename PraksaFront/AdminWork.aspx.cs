using PraksaMid;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class AdminWork : System.Web.UI.Page
    {
        static readonly string urlStart = "https://www.google.com/maps/embed/v1/place?q=";
        static readonly string urlEnd = "&key=AIzaSyC6FB2tRFJv8tK0k7t-KzY5GLsxFehcWeM";
        protected string url;
        protected string EditFrameUrl;
        protected string AttendanceFrameUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.See();

            if (!Page.IsPostBack)
            {
                GetWorks();
            }
        }

        private void GetWorks()
        {
            UserWorkList.DataSource = Work.GetWorks();
            UserWorkList.DataBind();
        }

        protected void edit_Command(object sender, CommandEventArgs e)
        {
            EditFrameUrl = "EditWork.aspx?workId=" + e.CommandArgument;
            EditModalPopupExtender.Show();
        }

        protected void delete_Command(object sender, CommandEventArgs e)
        {
            Work.DeleteWork(Convert.ToInt32(e.CommandArgument));
            Response.Redirect("AdminWork.aspx");
        }

        protected void locButton_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
            LinkButton btn = (LinkButton)sender;
            url = urlStart + btn.Text + urlEnd;
        }

        protected void attendance_Command(object sender, CommandEventArgs e)
        {
            AttendanceFrameUrl = "AttendanceInterest.aspx?workId=" + e.CommandArgument;
            ModalPopupExtender3.Show();
        }

        protected void hdnBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminWork.aspx");
        }
    }
}