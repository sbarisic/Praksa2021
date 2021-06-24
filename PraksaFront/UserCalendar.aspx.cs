﻿using PraksaMid;
using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace PraksaFront
{
    public partial class UserCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic.SessionManager.All();

            if (!Page.IsPostBack)
            {
                GetWork();
            }
        }

        protected void GetWork()
        {
            List<int> idList = new List<int>();
            List<WorkModel> workList = Work.GetWorks();
            List<ImproperCalendarEvent> tasksList = new List<ImproperCalendarEvent>();
            //Generate JSON serializable events

            foreach (WorkModel wrk in workList)
            {
                DateTime tempDate = Convert.ToDateTime(wrk.Date);

                tasksList.Add(new ImproperCalendarEvent
                {
                    Id = wrk.Id,
                    Title = wrk.Name,
                    Start = tempDate.ToString("yyyy-MM-dd"),
                    End = tempDate.ToString("yyyy-MM-dd"),
                    Description = wrk.Description,
                    Location = wrk.Location,
                    Obligation = wrk.Obligation,
                    AllDay = true,
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