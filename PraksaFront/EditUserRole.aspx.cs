using System;
using PraksaMid.Model;
using PraksaMid;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            userId = Convert.ToInt16(Request.QueryString["userId"]);
            System.Diagnostics.Debug.WriteLine(userId);
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
            foreach (RepeaterItem item in RoleRepeater.Items) //item = dozvola
            {
                var checkbox = item.FindControl("roleChk") as CheckBox;
                var hdnId = item.FindControl("hdnId") as HiddenField;
                var hdnField = item.FindControl("hdnField") as HiddenField;

                RoleModel role = new RoleModel();

                if (checkbox.Checked) //ako je oznacena dozvola
                {
                    if (!checkRole(hdnId.Value)) // ako je oznacena dozvola i user nema tu dozvolu, dodaj ju
                    {
                        role.IdUser = userId;
                        role.IdName = Convert.ToInt32(hdnId.Value);
                        role.Name = hdnField.Value;

                        Role.CreateRole(connectionString, role);
                    }
                }
                else
                {
                    if (checkDeletePermit(hdnId.Value, item) && numOfRoles() > 1) // ako nije oznacena dozvola i user ju ima, makni ju
                    {
                        HiddenField hdn = (HiddenField)item.FindControl("hdnDelete");
                        Role.DeleteRole(connectionString, Convert.ToInt32(hdn.Value));
                    }
                }

            }

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

        protected Boolean checkDeletePermit(string strRole, RepeaterItem item)
        {
            foreach (RoleModel rl in roles)
            {
                if (strRole.Equals(rl.IdName.ToString()))
                {
                    HiddenField hdn = (HiddenField)item.FindControl("hdnDelete");
                    hdn.Value = rl.Id.ToString();
                    return true;
                }
            }
            return false;
        }

        protected int numOfRoles()
        {
            int res = 0;
            foreach(RepeaterItem item in RoleRepeater.Items)
            {
                var checkbox = item.FindControl("roleChk") as CheckBox;
                if (checkbox.Checked)
                    res++;
            }
            return res;
        }
    }
}