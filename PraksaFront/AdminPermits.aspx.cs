using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class AdminPermits : System.Web.UI.Page
    {
        protected List<string> permitList = new List<string>(new string[] { "Dozvola za C kategoriju", "Dozvola za oružje" });
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PermitRepeater.DataSource = permitList;
                PermitRepeater.DataBind();
            }
        }
    }
}