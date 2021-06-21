using PraksaMid;
using System;
using System.Web.Configuration;

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
            if (rv == 0)
                Response.Write("<script>alert('Email ili loznika nisu ispravni');</script>");
            else if (rv == 1)
                Response.Write("<script>alert('Korisnik još nije prihvaćen');</script>");
            else if (rv == 2)
                Response.Write("<script>alert('Dobrodošli');</script>");

            Session["uname"] = txtEmail.Text;
            Response.Redirect("About.aspx");

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("About.aspx");
        }
    }
}