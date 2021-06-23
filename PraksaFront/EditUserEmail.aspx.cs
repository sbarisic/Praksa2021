using PraksaMid;
using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class EditUserEmail : System.Web.UI.Page
    {
        protected int userId = 0;
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        List<ContactEmailModel> emails = new List<ContactEmailModel>();
        protected string addUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            userId = Convert.ToInt16(Request.QueryString["userId"]);

            Logic.SessionManager.Edit(userId);

            addUrl = "AddUserEmail.aspx?userId=" + userId.ToString();
            emails = ContactEmail.GetContactEmails(connectionString, userId);
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void LoadData()
        {
            EmailRepeater.DataSource = ContactEmail.GetContactEmails(connectionString, userId);
            EmailRepeater.DataBind();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (RepeaterItem item in EmailRepeater.Items)
            {
                TextBox txtEmail = (TextBox)item.FindControl("txtEmail");
                if (!txtEmail.Text.Equals(emails[i].Email))
                {
                    emails[i].Email = txtEmail.Text;
                    ContactEmail.EditEmail(connectionString, emails[i]);
                }
                i++;
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }
        protected void hdnBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
        protected void deleteButton_Command(object sender, CommandEventArgs e)
        {
            ContactEmail.DeleteEmail(connectionString, Convert.ToInt32(e.CommandArgument));
            Response.Redirect(Request.RawUrl);
        }
    }
}