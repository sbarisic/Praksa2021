using PraksaMid;
using PraksaMid.Model;
using System;
using System.Collections.Generic;
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
        protected string emailUrl = "";
        protected string numberUrl = "";
        protected string roleUrl = "";
        protected List<RoleModel> roleList = new List<RoleModel>(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            roleList = Role.GetRoles(connectionString, userId); 
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
            PermitRepeater.DataSource = Permit.GetPermits(connectionString, userId);
            PermitRepeater.DataBind();

            NumberRepeater.DataSource = ContactNumber.GetContactNumbers(connectionString, userId);
            NumberRepeater.DataBind();

            EmailRepeater.DataSource = ContactEmail.GetContactEmails(connectionString, userId);
            EmailRepeater.DataBind();

            RoleRepeater.DataSource = Role.GetRoles(connectionString, userId);
            RoleRepeater.DataBind();

            PersonModel user = Person.GetUser(connectionString, userId);
            txtJmbc.Text = user.UniqueId;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtAdress.Text = user.Address;
            txtOib.Text = user.Oib;
            lblTitle.Text = "Uredi korisnika - " + user.FirstName + " " + user.LastName;
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Users.aspx");
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            PersonModel user = new PersonModel
            {
                Id = userId,
                IdRole = 2,
                UniqueId = txtJmbc.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Address = txtAdress.Text,
                Oib = txtOib.Text,
            };

            Person.EditUser(connectionString, user);
            Response.Redirect("Users.aspx");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }

        protected void deleteButton_Command(object sender, CommandEventArgs e)
        {
            Person.DeleteUser(connectionString, userId);
            Response.Redirect("Users.aspx");
        }
        protected void BtnDeletePermit_command(object sender, CommandEventArgs e)
        {
            Permit.DeletePermit(connectionString, Convert.ToInt32(e.CommandArgument));
            Response.Redirect(Request.RawUrl);
        }
        protected void BtnDeleteEmail_command(object sender, CommandEventArgs e)
        {
            ContactEmail.DeleteEmail(connectionString, Convert.ToInt32(e.CommandArgument));
            Response.Redirect(Request.RawUrl);
        }

        protected void BtnDeleteRole_command(object sender, CommandEventArgs e)
        {
            Role.DeleteRole(connectionString, Convert.ToInt32(e.CommandArgument));
            Response.Redirect(Request.RawUrl);
        }
        protected void BtnDeletePhoneNumber_command(object sender, CommandEventArgs e)
        {
            ContactNumber.DeleteContactNumber(connectionString, Convert.ToInt32(e.CommandArgument));
            Response.Redirect(Request.RawUrl);
        }

        protected void hdnBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnEditEmail_click(object sender, EventArgs e)
        {
            emailUrl = "EditUserEmail.aspx?userId=" + userId;
            emailPopupExtender.Show();
        }
        protected void btnEditNumber_click(object sender, EventArgs e)
        {
            numberUrl = "EditUserNumber.aspx?userId=" + userId;
            System.Diagnostics.Debug.WriteLine(emailUrl);
            numberPopupExtender.Show();
        }
        protected void btnAddRole_click(object sender, EventArgs e)
        {
            roleUrl = "EditUserRole.aspx?userId=" + userId;
            rolePopupExtender.Show();
        }
    }
}