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
    public partial class AddUserNumber : System.Web.UI.Page
    {
        protected int userId = 0;
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
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