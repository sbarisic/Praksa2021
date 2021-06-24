using PraksaMid;
using System;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class RoleNames : System.Web.UI.Page
    {
        protected string EditFrameUrl;
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.See();

            if (!Page.IsPostBack)
            {
                RoleNameRepeater.DataSource = RoleName.GetRoleNames(connectionString);
                RoleNameRepeater.DataBind();
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
        }
        protected void BtnSample_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoleNames.aspx");
        }

        protected void BtnDelete_Command(object sender, CommandEventArgs e)
        {
            RoleName.DeleteRoleName(connectionString, Convert.ToInt32(e.CommandArgument));
            Response.Redirect("RoleNames.aspx");
        }
        protected void BtnEdit_Command(object sender, CommandEventArgs e)
        {
            EditFrameUrl = "EditRoleName.aspx?roleNameId=" + e.CommandArgument;
            EditModalPopupExtender.Show();
        }
    }
}