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
        /*protected List<PermitModel> permitList = new List<PermitModel>(); */
        protected void Page_Load(object sender, EventArgs e)
        {
            /*permitList = Permit.GetPermits(connectionString, userId); */
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

            /*PermitRepeater.DataSource = PermitName.GetPermitNames(connectionString);
            PermitRepeater.DataBind();

            LoadOwnedPermits(); */

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
           /* foreach (RepeaterItem item in PermitRepeater.Items) //item = dozvola
            {
                var checkbox = item.FindControl("permitCheckbox") as CheckBox;
                var hdnId = item.FindControl("hdnId") as HiddenField;
                TextBox txtDate = (TextBox)item.FindControl("txtDate");
                TextBox txtNumber = (TextBox)item.FindControl("txtNumber");
                PermitModel permit = new PermitModel();

                if (checkbox.Checked) //ako je oznacena dozvola
                {
                    if (!checkPermit(hdnId.Value)) // ako je oznacena dozvola i user nema tu dozvolu, dodaj ju
                    {
                        permit.IdUser = userId;
                        permit.ExpiryDate = txtDate.Text;
                        permit.IdPermit = Convert.ToInt32(hdnId.Value);
                        permit.PermitNumber = txtNumber.Text;
                        Permit.CreatePermit(connectionString, permit);
                    }
                }
                else
                {
                    if (checkDeletePermit(hdnId.Value, item)) // ako nije oznacena dozvola i user ju ima, makni ju
                    {
                        HiddenField hdn = (HiddenField)item.FindControl("hdnField");
                        Permit.DeletePermit(connectionString, Convert.ToInt32(hdn.Value));
                    }
                }

            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);*/

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

        protected void btnEditEmail_click(object sender, EventArgs e)
        {
            emailUrl = "EditUserEmail.aspx?userId=" + userId;
            emailPopupExtender.Show();
        }

        /*protected void LoadOwnedPermits()
        {
            if (permitList.Count != 0)
            {
                int i = 0;
                foreach (RepeaterItem item in PermitRepeater.Items)
                {
                    var checkbox = item.FindControl("permitCheckbox") as CheckBox;
                    var hdnId = item.FindControl("hdnId") as HiddenField;
                    checkbox.Checked = checkPermit(hdnId.Value);
                    TextBox txtDate = (TextBox)item.FindControl("txtDate");
                    TextBox txtNumber = (TextBox)item.FindControl("txtNumber");
                    txtDate.Enabled = checkbox.Checked;
                    txtNumber.Enabled = checkbox.Checked;

                    if (checkPermit(hdnId.Value))
                    {
                        txtDate.Text = permitList[i].ExpiryDate;
                        txtNumber.Text = permitList[i].PermitNumber;
                        i++;
                    }
                }
            }
        }

        protected Boolean checkPermit(string strPermit)
        {
            foreach (PermitModel prmt in permitList)
            {
                if (strPermit.Equals(prmt.IdPermit.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        protected Boolean checkDeletePermit(string strPermit, RepeaterItem item)
        {
            foreach (PermitModel prmt in permitList)
            {
                if (strPermit.Equals(prmt.IdPermit.ToString()))
                {

                    HiddenField hdn = (HiddenField)item.FindControl("hdnField");
                    hdn.Value = prmt.Id.ToString();
                    return true;
                }
            }
            return false;
        }

        protected void permitCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            RepeaterItem item = (RepeaterItem)chk.NamingContainer;
            TextBox txtDate = (TextBox)item.FindControl("txtDate");
            TextBox txtNumber = (TextBox)item.FindControl("txtNumber");

            txtDate.Enabled = chk.Checked;
            txtNumber.Enabled = chk.Checked;
        }*/
    }
}