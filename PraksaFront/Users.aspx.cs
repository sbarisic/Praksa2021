using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using PraksaMid.Users;

namespace PraksaFront
{
    public partial class Users : System.Web.UI.Page
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
            User user = new User();
            UserRepeater.DataSource = user.GetUsers(connectionString);
            UserRepeater.DataBind();
        }
    }
}