using PraksaMid;
using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.UI;

namespace PraksaFront
{
    public partial class Calendar : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.See();

            if (!Page.IsPostBack)
            {
                GetWork();
            }
        }

        protected void GetWork()
        {
            List<int> idList = new List<int>();
            List<WorkModel> workList = Work.GetWorks(connectionString);
            List<ImproperCalendarEvent> tasksList = new List<ImproperCalendarEvent>();
            //Generate JSON serializable events

            foreach (WorkModel wrk in workList)
            {
                DateTime tempDate = new DateTime();
                tempDate = Convert.ToDateTime(wrk.Date);

                tasksList.Add(new ImproperCalendarEvent
                {
                    id = wrk.Id,
                    title = wrk.Name,
                    start = tempDate.ToString("yyyy-MM-dd"),
                    end = tempDate.ToString("yyyy-MM-dd"),
                    time = wrk.Time,
                    description = wrk.Description,
                    location = wrk.Location,
                    obligation = wrk.Obligation,
                    allDay = true,
                }) ;
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