using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class AttendanceInterest : System.Web.UI.Page
    {
        protected int workId = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.See();
            if (Request.QueryString["workId"] != "")
                workId = Convert.ToInt16(Request.QueryString["workId"]);
            if (!IsPostBack)
            {
                GetAttendants();
            }
        }

        private void GetAttendants()
        {
            attendanceRepeater.DataSource = Attendant.GetAttendants(workId);
            attendanceRepeater.DataBind();

        }

    }
}