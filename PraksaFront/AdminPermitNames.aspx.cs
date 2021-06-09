using PraksaMid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class AdminPermits : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PermitName permitName = new PermitName();
                PermitRepeater.DataSource = permitName.getPermitNames(connectionString);
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

        protected void deletePermitBtn_Command(object sender, CommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.CommandArgument);
            //Response.Redirect("EditUser.aspx?userId=" + e.CommandArgument);
        }

    }
}