using PraksaMid;
using PraksaMid.Model;
using System;
using System.Collections.Generic;

namespace PraksaFront
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int rv = Authentication.LogIn(txtEmail.Text, txtPassword.Text);
            if (rv == 0)
                Response.Write("<script>alert('Email ili loznika nisu ispravni');</script>");
            else if (rv == 1)
                Response.Write("<script>alert('Korisnik još nije prihvaćen');</script>");
            else if (rv == 2)
            {
                Session["uname"] = txtEmail.Text;

                List<RoleModel> roleList = Role.GetRoles(Person.GetUserId(txtEmail.Text));
                foreach (RoleModel role in roleList)
                {
                    if (role.Name == "Admin")
                    {
                        Session["admin"] = "true";
                        Response.Redirect("About.aspx");
                        return;
                    }
                }
                Session["admin"] = "false";
                Response.Redirect("About.aspx");
            }
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