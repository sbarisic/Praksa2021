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
    public partial class EditUser : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;

        int userId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["userId"] != "")
                userId = Convert.ToInt16(Request.QueryString["userId"]);
            else
                Response.Redirect("Users.aspx");
            if (!IsPostBack)
            {
                FillBookData();
            }
        }
        private void FillBookData()
        {
            User user = new User();
            user = user.GetUser(connectionString, userId);
            txtJmbc.Text = user.UniqueId;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtAdress.Text = user.Address;
            txtOib.Text = user.Oib;
            txtEmail.Text = user.Email;
            txtPhoneNumber.Text = user.PhoneNumber;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Users.aspx");
        }
    }
}