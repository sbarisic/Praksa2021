using PraksaMid;
using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class AddUserPermit : System.Web.UI.Page
    {
        protected int userId = 0;
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected List<PermitModel> permitList = new List<PermitModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            userId = Convert.ToInt16(Request.QueryString["userId"]);
            permitList = Permit.GetPermits(connectionString, userId);
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            PermitRepeater.DataSource = PermitName.GetPermitNames(connectionString);
            PermitRepeater.DataBind();

            LoadOwnedPermits();
        }

        protected void LoadOwnedPermits()
        {
            if (permitList.Count != 0)
            {
                int i = 0;
                foreach (RepeaterItem item in PermitRepeater.Items)
                {
                    var checkbox = item.FindControl("permitCheckbox") as CheckBox;
                    var hdnId = item.FindControl("hdnId") as HiddenField;
                    checkbox.Checked = checkPermit(hdnId.Value);
                    TextBox txtDate = (TextBox)item.FindControl("txtDate");
                    TextBox txtNumber = (TextBox)item.FindControl("txtNumber");
                    txtDate.Enabled = checkbox.Checked;
                    txtNumber.Enabled = checkbox.Checked;

                    if (checkPermit(hdnId.Value))
                    {
                        txtDate.Text = permitList[i].ExpiryDate;
                        txtNumber.Text = permitList[i].PermitNumber;
                        i++;
                    }
                }
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in PermitRepeater.Items) //item = dozvola
            {
                var checkbox = item.FindControl("permitCheckbox") as CheckBox;
                var hdnId = item.FindControl("hdnId") as HiddenField;
                TextBox txtDate = (TextBox)item.FindControl("txtDate");
                TextBox txtNumber = (TextBox)item.FindControl("txtNumber");
                PermitModel permit = new PermitModel();

                if (checkbox.Checked) //ako je oznacena dozvola
                {
                    if (!checkPermit(hdnId.Value)) // ako je oznacena dozvola i user nema tu dozvolu, dodaj ju
                    {
                        permit.IdUser = userId;
                        permit.ExpiryDate = txtDate.Text;
                        permit.IdPermit = Convert.ToInt32(hdnId.Value);
                        permit.PermitNumber = txtNumber.Text;
                        Permit.CreatePermit(connectionString, permit);
                    }
                }
                else
                {
                    if (checkDeletePermit(hdnId.Value, item)) // ako nije oznacena dozvola i user ju ima, makni ju
                    {
                        HiddenField hdn = (HiddenField)item.FindControl("hdnField");
                        Permit.DeletePermit(connectionString, Convert.ToInt32(hdn.Value));
                    }
                }

            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }
        protected Boolean checkPermit(string strPermit)
        {
            foreach (PermitModel prmt in permitList)
            {
                if (strPermit.Equals(prmt.IdPermit.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        protected Boolean checkDeletePermit(string strPermit, RepeaterItem item)
        {
            foreach (PermitModel prmt in permitList)
            {
                if (strPermit.Equals(prmt.IdPermit.ToString()))
                {

                    HiddenField hdn = (HiddenField)item.FindControl("hdnField");
                    hdn.Value = prmt.Id.ToString();
                    return true;
                }
            }
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