using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class Attendants : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected int workId = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.See();
            if (Request.QueryString["workId"] != "")
                workId = Convert.ToInt16(Request.QueryString["workId"]);
            if (!IsPostBack)
            {
                GetAttendants();
            }
        }

        private void GetAttendants()
        {
            attendanceRepeater.DataSource = Attendant.GetAttendants(connectionString, workId);
            attendanceRepeater.DataBind();

            foreach(RepeaterItem itm in attendanceRepeater.Items)
            {
                Label lbl = (Label)itm.FindControl("lblAttendance");
                RadioButtonList rblist = (RadioButtonList)itm.FindControl("AttendanceRadio");
                if(lbl.Text.Equals("Nije upisano"))
                {
                    lbl.Visible = false;
                    rblist.Visible = true;
                }
                else
                {
                    lbl.Visible = true;
                    rblist.Visible = false;
                }
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            
            foreach (RepeaterItem itm in attendanceRepeater.Items)
            {
                RadioButtonList radioList = (RadioButtonList)itm.FindControl("AttendanceRadio");
                HiddenField hdnUser = (HiddenField)itm.FindControl("hdnUser");
                HiddenField hdnInteres = (HiddenField)itm.FindControl("hdnInteres");
                System.Diagnostics.Debug.WriteLine("USER ID = " + hdnUser.Value + " || USER INTERES = " + hdnInteres.Value);
                AttendantModel attendant = new AttendantModel
                {
                    IdJob = workId,
                    IdInteres = Convert.ToInt32(hdnInteres.Value),
                    IdUser = Convert.ToInt32(hdnUser.Value),
                    IdAttendance = Convert.ToInt32(radioList.SelectedIndex)
                };

                Attendant.EditAttendant(connectionString, attendant);
                System.Diagnostics.Debug.WriteLine(radioList.SelectedValue);
            }
        }
    }
}