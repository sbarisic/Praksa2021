using PraksaMid;
using PraksaMid.Model;
using PraksaMid.Permit;
using PraksaMid.Person;
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
            PermitRepeater.DataSource = Permit.GetPermits(connectionString, userId);
            PermitRepeater.DataBind();

            NumberRepeater.DataSource = ContactNumber.GetContactNumbers(connectionString, userId);
            NumberRepeater.DataBind();

            EmailRepeater.DataSource = ContactEmail.GetContactEmails(connectionString, userId);
            EmailRepeater.DataBind();

            GetRoles();

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
        }
        
        protected void deleteButton_Command(object sender, CommandEventArgs e)
        {
            Person.DeleteUser(connectionString, userId);
            Response.Redirect("Users.aspx");
        }
        protected void BtnDeletePermit_command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Users.aspx");
        }

        protected void hdnBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void GetRoles()
        {
            List<RoleModel> allRoles = Role.GetRoleNames(connectionString);
            PersonModel user = Person.GetUser(connectionString, userId);

            foreach(RoleModel rl in allRoles)
            {
                CheckBox chk = new CheckBox();
                chk.Text = rl.Name;

                if (user.RoleName.Equals(rl.Name))
                    chk.Checked = true;


                roleRow.Controls.Add(chk);
                roleRow.Controls.Add(new LiteralControl("<br>"));
            }
            
        }
    }
}