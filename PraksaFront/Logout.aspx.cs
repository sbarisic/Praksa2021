using PraksaMid;
using PraksaMid.Model;
using System;
using System.Collections.Generic;


namespace PraksaFront
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.AppendHeader("Refresh", "5;url=about.aspx");
        }
    }
}