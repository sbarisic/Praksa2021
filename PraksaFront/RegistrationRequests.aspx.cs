using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.Configuration;
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
            UserRepeater.DataSource = Person.GetRegistartionsRequestUser(connectionString);
            UserRepeater.DataBind();
        }

        protected void AcceptBtn_Command(object sender, CommandEventArgs e)
        {
            int userId = Convert.ToInt16(e.CommandArgument);
            PersonModel user = Person.GetUser(connectionString, userId);
            user.Accepted = true;
            Person.VerificateUser(connectionString, userId);
            Response.Redirect("RegistrationRequests.aspx");
        }

        protected void DeleteBtn_Command(object sender, CommandEventArgs e)
        {
            int userId = Convert.ToInt16(e.CommandArgument);
            Person.RejectUser(connectionString, userId);
            Response.Redirect("RegistrationRequests.aspx");
        }
    }
}