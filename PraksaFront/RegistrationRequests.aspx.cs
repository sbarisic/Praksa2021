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
            UserRepeater.DataSource = user.GetRegistartionsRequestUser(connectionString);
            UserRepeater.DataBind();
        }

        protected void AcceptBtn_Command(object sender, CommandEventArgs e)
        {
            User user = new User();
            var u = user.GetUser(connectionString, Convert.ToInt16(e.CommandArgument));
            //u.Accepted = true;
            user.EditUser(connectionString, u);
            Response.Redirect("RegistrationRequests.aspx");
        }
        protected void DeleteBtn_Command(object sender, CommandEventArgs e)
        {
            User user = new User();
            Response.Redirect("RegistrationRequests.aspx");
        }
    }
}