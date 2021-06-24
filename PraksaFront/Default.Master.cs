using PraksaMid;
using System;

namespace PraksaFront
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Start();
            lnkuname.Text = (string)Session["uname"];
            if (lnkuname.Text != "")
            {
                int id = Person.GetUserId(lnkuname.Text);
                lnkuname.PostBackUrl = "EditUser.aspx?userId=" + id;
                Show();
            }
        }

        private void Show()
        {
            if (Session["admin"].Equals("true"))
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
                loginas.Visible = true;

                return;
            }

            work.Visible = true;
            userWork.Visible = true;
            userCalendar.Visible = true;
            logout.Visible = true;
            login.Visible = false;
            register.Visible = false;
            loginas.Visible = true;

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
            loginas.Visible = false;
        }
    }
}