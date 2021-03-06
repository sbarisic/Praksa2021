using PraksaMid;
using System;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class DismissedUsers : System.Web.UI.Page
    {
        protected String _jsPostBackCall;

        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.See();

            _jsPostBackCall = ClientScript.GetPostBackEventReference(this, "RowClicked");
            if (!IsPostBack)
            {
                GetUsers();
            }
        }

        private void GetUsers()
        {
            UserRepeater.DataSource = Person.GetDismissedUsers();
            UserRepeater.DataBind();
        }


        protected void ActivateBtn_Command(object sender, CommandEventArgs e)
        {
            Person.ActivateUser(Convert.ToInt32(e.CommandArgument));
            Response.Redirect("DismissedUsers.aspx");

        }
    }
}