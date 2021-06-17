using System;

namespace PraksaFront
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbluname.Text = (string)Session["uname"];
        }
    }
}