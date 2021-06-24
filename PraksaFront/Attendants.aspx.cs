using PraksaMid;
using PraksaMid.Model;
using System;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class Attendants : System.Web.UI.Page
    {
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
            attendanceRepeater.DataSource = Attendant.GetAttendants(workId);
            attendanceRepeater.DataBind();

            foreach (RepeaterItem itm in attendanceRepeater.Items)
            {
                Label lbl = (Label)itm.FindControl("lblAttendance");
                RadioButtonList rblist = (RadioButtonList)itm.FindControl("AttendanceRadio");
                if (lbl.Text.Equals("Nije upisano"))
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
                System.Diagnostics.Debug.WriteLine("USER ID = " + hdnUser.Value);

                AttendantModel attendant = Attendant.GetAttendant(workId, Convert.ToInt32(hdnUser.Value));
                attendant.IdAttendance = Convert.ToInt32(radioList.SelectedValue);

                Attendant.EditAttendant(attendant);
                System.Diagnostics.Debug.WriteLine(radioList.SelectedValue);
            }
        }
    }
}