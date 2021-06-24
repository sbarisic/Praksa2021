using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.UI;

namespace PraksaFront
{
    public partial class AddUserEmail : System.Web.UI.Page
    {
        protected int userId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.All();
            userId = Convert.ToInt16(Request.QueryString["userId"]);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ContactEmailModel email = new ContactEmailModel
            {
                IdUser = userId,
                Email = txtEmail.Text
            };
            ContactEmail.CreateEmail(email);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }
    }
}