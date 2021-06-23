using PraksaMid;
using System;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{

    public partial class AdminPermits : System.Web.UI.Page
    {
        protected string EditFrameUrl;
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.See();

            if (!Page.IsPostBack)
            {
                PermitRepeater.DataSource = PermitName.GetPermitNames(connectionString);
                PermitRepeater.DataBind();
            }
        }

        protected void addPermitBtn_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
        }
        protected void btnSample_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPermitNames.aspx");
        }

        protected void deletePermitNameBtn_Command(object sender, CommandEventArgs e)
        {
            PermitName.DeletePermitName(connectionString, Convert.ToInt32(e.CommandArgument));
            Response.Redirect("AdminPermitNames.aspx");
        }
        protected void edit_Command(object sender, CommandEventArgs e)
        {
            EditFrameUrl = "EditPermitName.aspx?permitNameId=" + e.CommandArgument;
            EditModalPopupExtender.Show();
        }
    }
}