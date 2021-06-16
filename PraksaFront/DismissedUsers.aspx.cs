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
    public partial class DismissedUsers : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected String _jsPostBackCall;

        protected void Page_Load(object sender, EventArgs e)
        {
            _jsPostBackCall = ClientScript.GetPostBackEventReference(this, "RowClicked");
            if (!IsPostBack)
            {
                GetUsers();
            }
        }

        private void GetUsers()
        {
            User user = new User();
            UserRepeater.DataSource = user.GetDismissedUsers(connectionString);
            UserRepeater.DataBind();
        }


        protected void ActivateBtn_Command(object sender, CommandEventArgs e)
        {
            Console.WriteLine(e.CommandArgument);
        }

        public void RaisePostBackEvent(string eventArgument)
        {
            switch (eventArgument)
            {
                case "RowClicked":
                    HandleRowClick();
                    break;

                // you can add other controls that need postback processing here

                default:
                    throw new ArgumentException();
            }
        }

        private void HandleRowClick()
        {
            Response.Redirect("AboutUser.aspx?userId=" + hiddenId.Value);
        }
    }
}