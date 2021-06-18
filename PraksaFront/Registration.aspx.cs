using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.Configuration;

namespace PraksaFront
{
    public partial class Registration : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected void btnReg_Click(object sender, EventArgs e)
        {
            if (txtLozinka.Text.Length < 8)
                errorPassword.Visible = true;
            else
            {
                errorPassword.Visible = false;
                if (txtLozinka.Text.Equals(txtLozinka2.Text))
                {
                    Random rnd = new Random();
                    PersonModel user = new PersonModel
                    {
                        UniqueId = rnd.Next().ToString(),
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Address = txtAdress.Text,
                        Oib = txtOib.Text,
                        Password = txtLozinka.Text,
                        Email = txtEmail.Text,
                        Number = txtPhoneNumber.Text,
                    };

                    Person.CreateUser(connectionString, user);
                    Response.Redirect("About.aspx");
                }
                else
                    Response.Write("<script>alert('Lozinke nisu identične');</script>");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("About.aspx");
        }

    }

}