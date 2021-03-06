using PraksaMid;
using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected int userId = 0;
        protected string permitUrl = "";
        protected string emailUrl = "";
        protected string numberUrl = "";
        protected string roleUrl = "";
        protected List<RoleModel> roleList = new List<RoleModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"].Equals("false"))
            {
                txtJmbc.Enabled = false;
                permitRow.Visible = false;
                deleteButton.Visible = false;
            }

                if (Request.QueryString["userId"] != "")
            {
                userId = Convert.ToInt16(Request.QueryString["userId"]);
                Logic.SessionManager.Edit(userId);
            }
            else
                Response.Redirect("Users.aspx");
            roleList = Role.GetRoles(userId);
            EditRole();
            if (!IsPostBack)
            {
                userIdField.Value = userId.ToString();
                FillUserData();
            }
        }

        private void FillUserData()
        {
            errorRole.Visible = false;
            PermitRepeater.DataSource = Permit.GetPermits(userId);
            PermitRepeater.DataBind();

            NumberRepeater.DataSource = ContactNumber.GetContactNumbers(userId);
            NumberRepeater.DataBind();

            EmailRepeater.DataSource = ContactEmail.GetContactEmails(userId);
            EmailRepeater.DataBind();

            RoleRepeater.DataSource = roleList;
            RoleRepeater.DataBind();

            PersonModel user = Person.GetUser(userId);
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

            Person.EditUser(user);
            Response.Redirect("Users.aspx");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }

        protected void deleteButton_Command(object sender, CommandEventArgs e)
        {
            Person.DeleteUser(userId);
            Response.Redirect("Users.aspx");
        }
        protected void BtnDeletePermit_command(object sender, CommandEventArgs e)
        {
            Permit.DeletePermit(Convert.ToInt32(e.CommandArgument));
            Response.Redirect(Request.RawUrl);
        }
        protected void BtnDeleteEmail_command(object sender, CommandEventArgs e)
        {
            int status = ContactEmail.DeleteEmail(Convert.ToInt32(e.CommandArgument));
            if (status == 1)
            {
                Response.Write("<script>alert('Ne možete obrisati defaultni email.');</script>");
            }
            else
            {
                Response.Redirect(Request.RawUrl);
            }


        }

        protected void BtnDeleteRole_command(object sender, CommandEventArgs e)
        {
            if (RoleRepeater.Items.Count > 1)
            {
                Role.DeleteRole(Convert.ToInt32(e.CommandArgument));
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                errorRole.Visible = true;
            }
        }
        protected void BtnDeletePhoneNumber_command(object sender, CommandEventArgs e)
        {
            ContactNumber.DeleteContactNumber(Convert.ToInt32(e.CommandArgument));
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

        private void EditRole()
        {
            if (Session["admin"].Equals("true"))
            {
                RoleRepeater.Visible = true;
                lblRole.Visible = true;
                BtnAddRole.Visible = true;

            }
            else
            {
                RoleRepeater.Visible = false;
                lblRole.Visible = false;
                BtnAddRole.Visible = false;
            }

        }
    }
}