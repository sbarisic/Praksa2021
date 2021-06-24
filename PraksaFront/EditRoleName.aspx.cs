using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.UI;

namespace PraksaFront
{
    public partial class EditRoleName : System.Web.UI.Page
    {
        protected int roleNameId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.See();

            if (Request.QueryString["PermitNameID"] != "")
                roleNameId = Convert.ToInt32(Request.QueryString["roleNameID"]);
            else
                Response.Redirect("Users.aspx");
            if (!IsPostBack)
            {
                FillPermitNamesData();
            }
        }

        private void FillPermitNamesData()
        {
            RoleNameModel roleName = RoleName.GetRoleName(roleNameId);
            txtRoleName.Text = roleName.Name;
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            RoleNameModel roleName = new RoleNameModel()
            {
                Id = roleNameId,
                Name = txtRoleName.Text
            };

            RoleName.EditRoleName(roleName);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }
    }
}