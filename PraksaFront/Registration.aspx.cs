﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using PraksaMid.Users;

namespace PraksaFront
{
    public partial class Registration : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;


        protected void btnReg_Click (object sender, EventArgs e)
        {
            Random rnd = new Random();
            User user = new User
            {
                IdRole = 2,
                UniqueId = rnd.Next().ToString(),
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Address = txtAdress.Text,
                Oib = txtOib.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text
            };

            user.CreateUser(connectionString, user);
            Response.Redirect("About.aspx");
        }

    }

}