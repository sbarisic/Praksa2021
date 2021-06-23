using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.Configuration;
using System.Web.UI;

namespace PraksaFront
{
    public partial class AddUserNumber : System.Web.UI.Page
    {
        protected int userId = 0;
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.All();
            userId = Convert.ToInt16(Request.QueryString["userId"]);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ContactNumberModel number = new ContactNumberModel
            {
                IdUser = userId,
                Number = txtNumber.Text
            };
            ContactNumber.CreateContactNumber(connectionString, number);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }
    }
}