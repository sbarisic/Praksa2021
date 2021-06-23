using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.Configuration;
using System.Web.UI;

namespace PraksaFront
{
    public partial class AddPermit : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.See();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            PermitNameModel permit = new PermitNameModel()
            {
                Name = permitText.Text
            };

            PermitName.CreatePermitName(connectionString, permit);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }
    }
}