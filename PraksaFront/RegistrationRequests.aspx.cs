using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class RegistrationRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.See();

            if (!IsPostBack)
            {
                GetUsers();
            }
        }

        private void GetUsers()
        {
            UserRepeater.DataSource = Person.GetRegistartionsRequestUser();
            UserRepeater.DataBind();
        }

        protected void AcceptBtn_Command(object sender, CommandEventArgs e)
        {
            int userId = Convert.ToInt16(e.CommandArgument);
            PersonModel user = Person.GetUser(userId);
            user.Accepted = true;
            Person.VerificateUser(userId);
            Response.Redirect("RegistrationRequests.aspx");
        }

        protected void DeleteBtn_Command(object sender, CommandEventArgs e)
        {
            int userId = Convert.ToInt16(e.CommandArgument);
            Person.RejectUser(userId);
            Response.Redirect("RegistrationRequests.aspx");
        }
    }
}