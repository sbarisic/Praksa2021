using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using PraksaFrontMVC.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Controllers
{
    public class CalendarController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetCalendarEvents(string start, string end)
        {
            List<Event> events = new List<Event>(); //get jobs -> events;

            return Json(events);
        }
    }
}
