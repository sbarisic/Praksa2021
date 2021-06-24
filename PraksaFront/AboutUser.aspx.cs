using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class AboutUser : System.Web.UI.Page
    {
        protected int userId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.See();
            if (Request.QueryString["userId"] != "")
                userId = Convert.ToInt16(Request.QueryString["userId"]);
            else
                Response.Redirect("Users.aspx");
            if (!IsPostBack)
            {
                FillUserData();
            }
        }
        private void FillUserData()
        {
            PermitRepeater.DataSource = Permit.GetPermits(userId);
            PermitRepeater.DataBind();

            PhoneNumberRepeater.DataSource = ContactNumber.GetContactNumbers(userId);
            PhoneNumberRepeater.DataBind();

            EmailRepeater.DataSource = ContactEmail.GetContactEmails(userId);
            EmailRepeater.DataBind();

            PersonModel user = Person.GetUser(userId);
            txtJmbc.Text = user.UniqueId;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtAdress.Text = user.Address;
            txtOib.Text = user.Oib;
            lblTitle.Text = "Informacije o korisniku - " + user.FirstName + " " + user.LastName;
        }

        protected void editButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("EditUser.aspx?userId=" + userId.ToString());
        }
        protected void deleteButton_Command(object sender, CommandEventArgs e)
        {
            Person.DeleteUser(userId);
            Response.Redirect("Users.aspx");
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Users.aspx");
        }
    }
}