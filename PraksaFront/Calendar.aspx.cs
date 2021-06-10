﻿using PraksaMid.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PraksaFront
{
    public partial class Calendar : System.Web.UI.Page
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
                tasksList.Add(new ImproperCalendarEvent
                {
                    id = wrk.Id,
                    title = wrk.Name,
                    start = "2021-06-22", //test vrijednosti
                    end = "2021-06-23",

                    description = wrk.Description,
                    allDay = false,
                });
                idList.Add(wrk.Id);
            }


            //Serialize events to string
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(tasksList);

            Label1.Text = sJSON;
            System.Diagnostics.Debug.WriteLine(Label1.Text);
        }
    }
}