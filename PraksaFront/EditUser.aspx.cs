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

            LoadOwnedRoles();

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
           foreach (RepeaterItem item in RoleRepeater.Items) //item = uloga
            {
                var checkbox = item.FindControl("roleCheckbox") as CheckBox;
                var hdnId = item.FindControl("hdnId") as HiddenField;
                RoleModel role = new RoleModel();

                if (checkbox.Checked) //ako je oznacena dozvola
                {
                    if (!CheckRole(hdnId.Value)) // ako je oznacena dozvola i user nema tu dozvolu, dodaj ju
                    {
                        role.IdUser = userId;
                        role.IdName = Convert.ToInt32(hdnId.Value);
                        Role.CreateRole(connectionString, role);
                    }
                }
                else
                {
                    if (CheckDeleteRole(hdnId.Value, item)) // ako nije oznacena uloga i user ju ima, makni ju
                    {
                        HiddenField hdn = (HiddenField)item.FindControl("hdnField");
                        Role.DeleteRole(connectionString, Convert.ToInt32(hdn.Value));
                    }
                }

            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);

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
        protected void BtnDeleteRole_command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Users.aspx");
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

        protected void LoadOwnedRoles()
        {
            if (roleList.Count != 0)
            {
                foreach (RepeaterItem item in PermitRepeater.Items)
                {
                    var checkbox = item.FindControl("roleCheckbox") as CheckBox;
                    var hdnId = item.FindControl("hdnId") as HiddenField;
                    checkbox.Checked = CheckRole(hdnId.Value);
                }
            }
        }

        protected Boolean CheckRole(string strRole)
        {
            foreach (RoleModel role in roleList)
            {
                if (strRole.Equals(role.IdName.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        protected Boolean CheckDeleteRole(string strRole, RepeaterItem item)
        {
            foreach (RoleModel role in roleList)
            {
                if (strRole.Equals(role.IdName.ToString()))
                {

                    HiddenField hdn = (HiddenField)item.FindControl("hdnField");
                    hdn.Value = role.Id.ToString();
                    return true;
                }
            }
            return false;
        }

        protected void RoleCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            RepeaterItem item = (RepeaterItem)chk.NamingContainer;
        }
    }
}