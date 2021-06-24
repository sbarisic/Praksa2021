using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.UI;

namespace PraksaFront
{
    public partial class AddPermit : System.Web.UI.Page
    {
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

            PermitName.CreatePermitName(permit);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }
    }
}