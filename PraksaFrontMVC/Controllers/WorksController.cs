using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraksaFrontMVC.Data;
using PraksaFrontMVC.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using Newtonsoft.Json;

namespace PraksaFrontMVC.Controllers
{
    public class WorksController : Controller
    {
        private readonly PraksaFrontMVCContext _context;

        public WorksController(PraksaFrontMVCContext context)
        {
            _context = context;
        }

        // GET: Works
        public async Task<IActionResult> Index()
        {
            return View(await WorkData.GetWorks());
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult GetCalendarEvents()
        {
            List<Work> list = Task.Run(() => WorkData.GetWorks()).Result;
            List<Event> events = new List<Event>();
            
            foreach (var w in list)
            {
                DateTime date;
                DateTime.TryParseExact(w.Date, "dd.M.yyyy.", null, System.Globalization.DateTimeStyles.None, out date);

                Event e = new Event
                {
                    EventId = w.Id,
                    Title = w.Name,
                    Description = w.Description,
                    Start = date.ToString("yyyy-MM-dd"),
                    End = w.Date,
                    AllDay = false
                };
                events.Add(e);
            }
            var j = Json(events);
            var s = JsonConvert.SerializeObject(events);
            ViewBag.Events = s;
            System.Diagnostics.Debug.WriteLine(s);
            return j;
        }


        // GET: Works
        public async Task<IActionResult> AdminIndex()
        {
            return View(await WorkData.GetWorks());
        }

        // GET: Works
        public async Task<IActionResult> UserIndex()
        {
            return View(await WorkData.GetWorks());
        }

        // Get: Done Works
        public async Task<IActionResult> DismissedWorks()
        {
            return View(await WorkData.GetWorks());
        }


        // GET: Works/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await WorkData.GetWork((int)id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }


        // GET: Works/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Date,Time,Description,Location,Obligation")] Work work)
        {
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine(work.Date);
                WorkData.CreateWork(work);
                await _context.SaveChangesAsync();
                return RedirectToAction("AdminIndex", "Works");
            }
            return View(work);
        }

        // POST: Works/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CalendarAdd([Bind("Id,Name,Date,Time,Description,Location,Obligation")] Work work)
        {
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine(work.Date);
                WorkData.CreateWork(work);
                await _context.SaveChangesAsync();
                return RedirectToAction("Calendar", "Works");
            }
            return View(work);
        }

        // GET: Works/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await WorkData.GetWork((int)id);
            if (work == null)
            {
                return NotFound();
            }
            return View(work);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date,Time,Description,Location,Obligation")] Work work)
        {
            if (work.Obligation.Equals("Obavezno"))
                work.Obligation = "1";
            else
                work.Obligation = "0";

            if (id != work.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    WorkData.EditWork(work);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("AdminIndex", "Works");
            }
            return View(work);
        }

        // GET: Works/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await WorkData.GetWork((int)id);

            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var work = await WorkData.GetWork((int)id);
            WorkData.DeleteWork(id);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminIndex", "Works");
        }

        private bool WorkExists(int id)
        {
            return _context.Work.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Popup(int? id)
        {
            var work = await WorkData.GetWork((int)id);
            return PartialView("Popup", work);
        }

        public async Task<IActionResult> EditPopup(int? id)
        {
            var work = await WorkData.GetWork((int)id);
            return PartialView("EditPopup", work);
        }

        public  ActionResult AddPopup(string date)
        {
            ViewBag.date = date;
            return PartialView("AddPopup");
        }
    }
}
