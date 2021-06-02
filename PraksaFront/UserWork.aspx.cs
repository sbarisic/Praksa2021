using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class UserWork : System.Web.UI.Page
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

        protected void yes_Command(object sender, CommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Dolazi na " + e.CommandArgument.ToString());
        }
        protected void no_Command(object sender, CommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ne dolazi na " + e.CommandArgument.ToString());
        }
        protected void maybe_Command(object sender, CommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Mozda dolazi na " + e.CommandArgument.ToString());
        }
    }
}