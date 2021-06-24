using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.UI;

namespace PraksaFront
{
    public partial class AddUserNumber : System.Web.UI.Page
    {
        protected int userId = 0;
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
            ContactNumber.CreateContactNumber(number);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }
    }
}