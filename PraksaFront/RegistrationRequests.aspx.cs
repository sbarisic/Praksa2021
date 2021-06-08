using PraksaMid.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class RegistrationRequests : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUsers();
            }
        }

        private void GetUsers()
        {
            // user placeholder zasad, zamijeniti kasnije
            User user = new User();
            UserRepeater.DataSource = user.GetUsers(connectionString);
            UserRepeater.DataBind();
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }
    }
}