using PraksaMid.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class UserCalendar : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetWork();
            }
        }

        protected void GetWork()
        {
            List<int> idList = new List<int>();
            Work work = new Work();
            List<Work> workList = new List<Work>();
            workList = work.GetWorks(connectionString);
            List<ImproperCalendarEvent> tasksList = new List<ImproperCalendarEvent>();
            //Generate JSON serializable events

            foreach (Work wrk in workList)
            {
                DateTime tempDate = new DateTime();
                tempDate = Convert.ToDateTime(wrk.Date);

                tasksList.Add(new ImproperCalendarEvent
                {
                    id = wrk.Id,
                    title = wrk.Name,
                    start = tempDate.ToString("yyyy-MM-dd"),
                    end = tempDate.ToString("yyyy-MM-dd"),
                    description = wrk.Description,
                    location = wrk.Location,
                    obligation = wrk.Obligation,
                    allDay = true,
                });
                idList.Add(wrk.Id);
            }

            //Serialize events to string
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(tasksList);

            jsonField.Text = sJSON;
        }

        protected void hdnBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Calendar.aspx");
        }
    }
}