using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.UI;

namespace PraksaFront
{
    public partial class EditPermit : System.Web.UI.Page
    {
        protected int permitNameId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.All();

            if (Request.QueryString["PermitNameID"] != "")
                permitNameId = Convert.ToInt16(Request.QueryString["PermitNameID"]);
            else
                Response.Redirect("Users.aspx");
            if (!IsPostBack)
            {
                FillPermitNamesData();
            }
        }

        private void FillPermitNamesData()
        {
            PermitNameModel permitName = PermitName.GetPermitName(permitNameId);
            permitNameText.Text = permitName.Name;
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            PermitNameModel permit = new PermitNameModel()
            {
                Id = permitNameId,
                Name = permitNameText.Text
            };

            PermitName.EditPermitName(permit);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hidePopup", "callParentWindowHideMethod();", true);
        }


    }
}