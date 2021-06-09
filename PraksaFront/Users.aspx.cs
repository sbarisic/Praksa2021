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
    public partial class Users : System.Web.UI.Page, IPostBackEventHandler
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
            UserRepeater.DataSource = user.GetUsers(connectionString);
            UserRepeater.DataBind();
        }


        protected void editButton_Command(object sender, CommandEventArgs e)
        {
            Console.WriteLine(e.CommandArgument);
            Response.Redirect("EditUser.aspx?userId=" + e.CommandArgument);
        }

        protected void deleteButton_Command(object sender, CommandEventArgs e)
        {
            int userId = Convert.ToInt16(e.CommandArgument);
            User user = new User();
            user.DeleteUser(connectionString, userId);
            Response.Redirect("Users.aspx");
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