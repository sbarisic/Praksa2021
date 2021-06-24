using PraksaMid;
using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class EditUserNumber : System.Web.UI.Page
    {
        protected int userId = 0;
        List<ContactNumberModel> numbers = new List<ContactNumberModel>();
        protected string addUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            userId = Convert.ToInt16(Request.QueryString["userId"]);

            Logic.SessionManager.Edit(userId);

            addUrl = "AddUserNumber.aspx?userId=" + userId.ToString();
            numbers = ContactNumber.GetContactNumbers(userId);
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void LoadData()
        {
            NumberRepeater.DataSource = ContactNumber.GetContactNumbers(userId);
            NumberRepeater.DataBind();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (RepeaterItem item in NumberRepeater.Items)
            {
                TextBox txtNumber = (TextBox)item.FindControl("txtNumber");
                if (!txtNumber.Text.Equals(numbers[i].Number))
                {
                    numbers[i].Number = txtNumber.Text;
                    ContactNumber.EditContactNumber(numbers[i]);
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
            ContactNumber.DeleteContactNumber(Convert.ToInt32(e.CommandArgument));
            Response.Redirect(Request.RawUrl);
        }
    }
}