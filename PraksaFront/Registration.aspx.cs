using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using PraksaMid.Model;
using PraksaMid.Person;

namespace PraksaFront
{
    public partial class Registration : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected void btnReg_Click (object sender, EventArgs e)
        {
            if(txtLozinka.Text.Length < 8)
                errorPassword.Visible = true;
            else
            {
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