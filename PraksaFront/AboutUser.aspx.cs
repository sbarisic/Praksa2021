﻿using PraksaMid.Users;
using PraksaMid.Permit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using PraksaMid;

namespace PraksaFront
{
    public partial class AboutUser : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected int userId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["userId"] != "")
                userId = Convert.ToInt16(Request.QueryString["userId"]);
            else
                Response.Redirect("Users.aspx");
            if (!IsPostBack)
            {
                FillUserData();
            }
        }
        private void FillUserData()
        {
            User user = new User();

            Permit permit = new Permit();
            PermitRepeater.DataSource = permit.GetPermits(connectionString, userId);
            PermitRepeater.DataBind();

            PhoneNumberRepeater.DataSource = ContactNumber.GetContactNumbers(connectionString, userId);
            PhoneNumberRepeater.DataBind();

            EmailRepeater.DataSource = ContactEmail.GetContactEmails(connectionString, userId);
            EmailRepeater.DataBind();

            user = user.GetUser(connectionString, userId);
            txtJmbc.Text = user.UniqueId;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtAdress.Text = user.Address;
            txtOib.Text = user.Oib;
            lblTitle.Text = "Informacije o korisniku - " + user.FirstName + " " + user.LastName;
        }

        protected void editButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("EditUser.aspx?userId=" + userId.ToString());
        }
        protected void deleteButton_Command(object sender, CommandEventArgs e)
        {
            User user = new User();
            user.DeleteUser(connectionString, userId);
            Response.Redirect("Users.aspx");
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Users.aspx");
        }
    }
}