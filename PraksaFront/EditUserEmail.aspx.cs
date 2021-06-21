using PraksaMid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class EditUserEmail : System.Web.UI.Page
    {
        protected int userId = 0;
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected string addUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            userId = Convert.ToInt16(Request.QueryString["userId"]);
            addUrl = "AddUserEmail.aspx?userId=" + userId.ToString();
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void LoadData()
        {
            EmailRepeater.DataSource = ContactEmail.GetContactEmails(connectionString, userId);
            EmailRepeater.DataBind();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
        }
    }
}