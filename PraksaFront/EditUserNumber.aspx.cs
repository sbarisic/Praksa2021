using PraksaMid.Model;
using PraksaMid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class EditUserNumber : System.Web.UI.Page
    {
        protected int userId = 0;
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        List<ContactNumberModel> numbers = new List<ContactNumberModel>();
        protected string addUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            userId = Convert.ToInt16(Request.QueryString["userId"]);
            addUrl = "AddUserNumber.aspx?userId=" + userId.ToString();
            numbers = ContactNumber.GetContactNumbers(connectionString, userId);
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void LoadData()
        {
            NumberRepeater.DataSource = ContactNumber.GetContactNumbers(connectionString, userId);
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
                    ContactNumber.EditContactNumber(connectionString, numbers[i]);
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
            ContactNumber.DeleteContactNumber(connectionString, Convert.ToInt32(e.CommandArgument));
            Response.Redirect(Request.RawUrl);
        }
    }
}