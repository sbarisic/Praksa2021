using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using PraksaMid.Users;
using PraksaMid;

namespace PraksaFront
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int rv = Authentication.LogIn(connectionString, txtEmail.Text, txtPassword.Text);
            TextBox1.Text = txtEmail.Text;
            if (rv == 0)
                Response.Write("<script>alert('Email ili loznika nisu ispravni');</script>");
            else if(rv == 1)
                Response.Write("<script>alert('Korisnik još nije prihvaćen');</script>");
            else if(rv == 2)
                Response.Write("<script>alert('Dobrodošli');</script>");

                Session["uname"] = TextBox1.Text;
                Response.Redirect("About.aspx");
                
        }
    }
}