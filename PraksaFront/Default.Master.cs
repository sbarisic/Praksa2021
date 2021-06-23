using PraksaMid;
using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web;
using System.Web.Security;

namespace PraksaFront
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        List<RoleModel> userRoles = new List<RoleModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            Start();
            lnkuname.Text = (string)Session["uname"];
            if (lnkuname.Text != "")
            {
                int id = Person.GetUserId(connectionString, lnkuname.Text);
                lnkuname.PostBackUrl = "EditUser.aspx?userId=" + id;
                userRoles = Role.GetRoles(connectionString, id);
                Show();
            }
        }

        


        private void Show()
        {
            foreach (RoleModel role in userRoles)
            {
                if (role.Name == "Admin")
                {
                    users.Visible = true;
                    work.Visible = true;
                    adminCalendar.Visible = true;
                    adminWork.Visible = true;
                    disUsers.Visible = true;
                    permits.Visible = true;
                    roles.Visible = true;
                    regReq.Visible = true;
                    logout.Visible = true;
                    login.Visible = false;
                    register.Visible = false;
                    pastWork.Visible = true;

                    return;
                }
            }

            work.Visible = true;
            userWork.Visible = true;
            userCalendar.Visible = true;
            logout.Visible = true;
            login.Visible = false;
            register.Visible = false;

        }

        private void Start()
        {
            users.Visible = false;
            work.Visible = false;
            userWork.Visible = false;
            userCalendar.Visible = false;
            adminCalendar.Visible = false;
            adminWork.Visible = false;
            disUsers.Visible = false;
            permits.Visible = false;
            roles.Visible = false;
            regReq.Visible = false;
            login.Visible = true;
            register.Visible = true;
            logout.Visible = false;
            pastWork.Visible = false;
        }

        




    }
}