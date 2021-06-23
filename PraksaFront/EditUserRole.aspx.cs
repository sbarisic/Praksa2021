using PraksaMid;
using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class EditUserRole : System.Web.UI.Page
    {
        protected int userId = 0;
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        List<RoleModel> roles = new List<RoleModel>();
        protected void Page_Load(object sender, EventArgs e)
        {

            Logic.SessionManager.See();

            userId = Convert.ToInt16(Request.QueryString["userId"]);
            roles = Role.GetRoles(connectionString, userId);
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void LoadData()
        {
            RoleRepeater.DataSource = RoleName.GetRoleNames(connectionString);
            RoleRepeater.DataBind();

            LoadOwnedRoles();
        }

        protected void LoadOwnedRoles()
        {
            if (roles.Count != 0)
            {
                foreach (RepeaterItem item in RoleRepeater.Items)
                {
                    var checkbox = item.FindControl("roleChk") as CheckBox;
                    var hdnId = item.FindControl("hdnId") as HiddenField;
                    System.Diagnostics.Debug.WriteLine(checkbox.Text);
                    checkbox.Checked = checkRole(hdnId.Value);
                }
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {


            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }

        protected void hdnBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void deleteButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected Boolean checkRole(string strRole)
        {
            foreach (RoleModel rl in roles)
            {
                System.Diagnostics.Debug.WriteLine(rl.Name + "| id: " + rl.Id + " | id name: " + rl.IdName + " >-< " + strRole);
                if (strRole.Equals(rl.IdName.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

    }
}