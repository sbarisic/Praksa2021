using PraksaMid;
using System;
using System.Web.Configuration;

namespace PraksaFront
{
    public partial class Attendants : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected int workId = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["workId"] != "")
                workId = Convert.ToInt16(Request.QueryString["workId"]);
            if (!IsPostBack)
            {
                GetAttendants();
            }
        }

        private void GetAttendants()
        {
            attendanceRepeater.DataSource = Attendant.GetAttendants(connectionString, workId);
            attendanceRepeater.DataBind();
        }
    }
}