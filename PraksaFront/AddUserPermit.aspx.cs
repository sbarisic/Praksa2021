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
            userId = Convert.ToInt16(Request.QueryString["userId"]);

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            PermitName allPermits = new PermitName();
            Permit permit = new Permit();
            System.Diagnostics.Debug.WriteLine("Getting permits for user id = " + userId);
            List<Permit> tmpList = permit.GetPermits(connectionString, userId);
            foreach(Permit prmt in tmpList)
            {
                System.Diagnostics.Debug.WriteLine(prmt.PermitName);
                permitList.Add(prmt.PermitName);
            }
            PermitRepeater.DataSource = allPermits.getPermitNames(connectionString);
            PermitRepeater.DataBind();

            LoadOwnedPermits();
        }

        protected void LoadOwnedPermits()
        {
            foreach(RepeaterItem item in PermitRepeater.Items)
            { 
                var checkbox = item.FindControl("permitCheckbox") as CheckBox;
                var hdnField = item.FindControl("hdnField") as HiddenField;

                checkbox.Checked = checkPermit(hdnField.Value);
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in PermitRepeater.Items) //item = dozvola
            {
                var checkbox = item.FindControl("permitCheckbox") as CheckBox;
                var hdnField = item.FindControl("hdnField") as HiddenField;
                var hdnId = item.FindControl("hdnId") as HiddenField;

                if (checkbox.Checked) //ako je oznacena dozvola
                {
                    if (!checkPermit(hdnField.Value)) // ako je oznacena dozvola i user nema tu dozvolu, dodaj ju
                    {
                        Permit permit = new Permit();
                        permit.IdUser = userId;
                        permit.ExpiryDate = "25.06.2021";
                        permit.IdPermit = Convert.ToInt32(hdnId.Value);
                        permit.CreatePermit(connectionString, permit);
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
            if (permitList != null)
                return permitList.Contains(prmt);
            else
                return false;
        }

        protected void permitCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            RepeaterItem item = (RepeaterItem)chk.NamingContainer;
            TextBox txtDate = (TextBox)item.FindControl("txtDate");
            TextBox txtNumber = (TextBox)item.FindControl("txtNumber");
            txtDate.Enabled = chk.Checked;
            txtNumber.Enabled = chk.Checked;
        }
    }
}