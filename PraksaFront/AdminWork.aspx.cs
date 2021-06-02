using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class AdminWork : System.Web.UI.Page
    {

        public List<string> actionList = new List<string>(new string[] { "Košnja trave", "Branje jabuka", "Test" });
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UserWorkList.DataSource = actionList;
                UserWorkList.DataBind();
            }
        }
        protected void edit_Command(object sender, CommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("edit " + e.CommandArgument.ToString());
        }
        protected void delete_Command(object sender, CommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("delete " + e.CommandArgument.ToString());
        }

    }
}