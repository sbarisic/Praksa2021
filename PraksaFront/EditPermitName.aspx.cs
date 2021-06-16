﻿using PraksaMid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class EditPermit : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected int permitNameId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PermitNameID"] != "")
                 permitNameId= Convert.ToInt16(Request.QueryString["PermitNameID"]);
            else
                Response.Redirect("Users.aspx");
            if (!IsPostBack)
            {
                FillPermitNamesData();
            }
        }

        private void FillPermitNamesData()
        {
            PermitName permitName = new PermitName();
            permitName = permitName.GetPermitName(connectionString, permitNameId);
            permitNameText.Text = permitName.Name;
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            PermitName permit = new PermitName()
            {
                Id = permitNameId,
                Name = permitNameText.Text
            };

            permit.EditPermitName(connectionString, permit);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }
        

    }
}