using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class AboutUser : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
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
            PermitRepeater.DataSource = Permit.GetPermits(connectionString, userId);
            PermitRepeater.DataBind();

            PhoneNumberRepeater.DataSource = ContactNumber.GetContactNumbers(connectionString, userId);
            PhoneNumberRepeater.DataBind();

            EmailRepeater.DataSource = ContactEmail.GetContactEmails(connectionString, userId);
            EmailRepeater.DataBind();

            PersonModel user = new PersonModel();
            user = Person.GetUser(connectionString, userId);
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
            Person.DeleteUser(connectionString, userId);
            Response.Redirect("Users.aspx");
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Users.aspx");
        }
    }
}