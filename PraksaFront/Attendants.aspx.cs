using PraksaMid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

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