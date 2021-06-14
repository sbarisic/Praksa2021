using PraksaMid;
using PraksaMid.Permit;
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
        protected int userId = 0;
        protected string permitUrl = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["userId"] != "")
                userId = Convert.ToInt16(Request.QueryString["userId"]);
            else
                Response.Redirect("Users.aspx");
            if (!IsPostBack)
            {
                userIdField.Value = userId.ToString();
                FillUserData();
            }
        }
        private void FillUserData()
        {
            User user = new User();
            user = user.GetUser(connectionString, userId);
            Permit permit = new Permit();
            PermitRepeater.DataSource = permit.GetPermits(connectionString, userId);
            PermitRepeater.DataBind();
            ContactNumber number = new ContactNumber();
            NumberRepeater.DataSource = number.GetContactNumbers(connectionString, userId);
            NumberRepeater.DataBind();
            txtJmbc.Text = user.UniqueId;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtAdress.Text = user.Address;
            txtOib.Text = user.Oib;
            txtEmail.Text = user.Email;
            lblTitle.Text = "Uredi korisnika - " + user.FirstName + " " + user.LastName;
            roleButton.SelectedValue = user.IdRole.ToString();
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Users.aspx");
        }
        
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                Id = userId,
                IdRole = 2,
                UniqueId = txtJmbc.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Address = txtAdress.Text,
                Oib = txtOib.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text
            };

            user.EditUser(connectionString, user);
            Response.Redirect("Users.aspx");
        }

        protected void BtnAddPermit_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
        }
        
        protected void deleteButton_Command(object sender, CommandEventArgs e)
        {
            User user = new User();
            user.DeleteUser(connectionString, userId);
            Response.Redirect("Users.aspx");
        }
        protected void BtnDeletePermit_command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Users.aspx");
        }
    }
}