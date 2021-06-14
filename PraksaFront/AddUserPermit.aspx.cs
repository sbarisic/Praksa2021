using PraksaMid;
using PraksaMid.Permit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class AddUserPermit : System.Web.UI.Page
    {
        protected int userId = 0;
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected List<string> permitList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["userId"] != "")
                userId = Convert.ToInt16(Request.QueryString["userId"]);
            else
                Response.Redirect("Users.aspx");
            if (!IsPostBack)
            {
                GetPermits();
            }
        }

        private void GetPermits()
        {
            PermitName allPermits = new PermitName();
            Permit permit = new Permit();
            System.Diagnostics.Debug.WriteLine("Getting permits for user id = " + userId);


            PermitRepeater.DataSource = allPermits.getPermitNames(connectionString);
            PermitRepeater.DataBind();

            LoadOwnedPermits();
        }

        protected void LoadOwnedPermits()
        {
            foreach(RepeaterItem item in PermitRepeater.Items)
            {
                var checkbox = item.FindControl("permitCheckbox") as CheckBox;

            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in PermitRepeater.Items) //item = dozvola
            {
                var checkbox = item.FindControl("permitCheckbox") as CheckBox;
                var hdnField = item.FindControl("hdnField") as HiddenField;
                if (checkbox.Checked) //ako je oznacena dozvola
                {
                    if (!checkPermit(hdnField.Value)) // ako je oznacena dozvola i user nema tu dozvolu, dodaj ju
                    {
                        System.Diagnostics.Debug.WriteLine("DODAJ" + checkbox.Text);
                    }
                }
                else
                {
                    if (checkPermit(hdnField.Value)) // ako nije oznacena dozvola i user ju ima, makni ju
                    {
                        System.Diagnostics.Debug.WriteLine("MAKNI" + checkbox.Text);
                    }
                }
                
            }
        }
        protected Boolean checkPermit(string prmt)
        {
            return permitList.Contains(prmt);
        }


    }
}