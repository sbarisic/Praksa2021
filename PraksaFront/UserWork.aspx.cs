using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class RadneAkcije : System.Web.UI.Page
    {
        public List<string> actionList = new List<string>(new string[] { "Košnja trave", "Branje jabuka", "Test"});

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}