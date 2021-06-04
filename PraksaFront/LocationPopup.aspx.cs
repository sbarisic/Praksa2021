using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class LocationPopup : System.Web.UI.Page
    {
        static string urlStart = "https://www.google.com/maps/embed/v1/place?q=";
        static string urlEnd = "&key=AIzaSyC6FB2tRFJv8tK0k7t-KzY5GLsxFehcWeM";
        protected string url = urlStart + "Ul.%20%Ivana%20%Gundulica%20%6" + urlEnd;
        protected void Page_Load(object sender, EventArgs e)
        {
 
        }
    }
}