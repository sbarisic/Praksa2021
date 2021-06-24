using PraksaMid;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{

    public partial class AdminPermits : System.Web.UI.Page
    {
        protected string EditFrameUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.See();

            if (!Page.IsPostBack)
            {
                PermitRepeater.DataSource = PermitName.GetPermitNames();
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
            PermitName.DeletePermitName(Convert.ToInt32(e.CommandArgument));
            Response.Redirect("AdminPermitNames.aspx");
        }
        protected void edit_Command(object sender, CommandEventArgs e)
        {
            EditFrameUrl = "EditPermitName.aspx?permitNameId=" + e.CommandArgument;
            EditModalPopupExtender.Show();
        }
    }
}