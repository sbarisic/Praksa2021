using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.UI;

namespace PraksaFront
{
    public partial class AddRoleName : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.See();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            RoleNameModel roleName = new RoleNameModel()
            {
                Name = txtRole.Text
            };

            RoleName.CreateRoleName(roleName);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }
    }
}