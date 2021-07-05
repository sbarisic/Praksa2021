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
            List<Work> list = Task.Run(() => WorkData.GetWorks()).Result;
            List<Event> events = new List<Event>();
            foreach (var w in list)
            {
                Event e = new Event
                {
                    EventId = w.Id,
                    Title = w.Name,
                    Description = w.Description,
                    Start = w.Date,
                    End = w.Date,
                    AllDay = false
                };
                events.Add(e);
                System.Diagnostics.Debug.WriteLine(e.Start);
            }
            var j = Json(events);
            var s = JsonConvert.SerializeObject(events);
            System.Diagnostics.Debug.WriteLine(s);
            ViewBag.Events = s;

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
                WorkData.CreateWork(work);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Work");
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date,Time,Description,Location,Obligation,IdAttendant")] Work work)
        {
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
                return RedirectToAction(nameof(Index));
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
            return RedirectToAction(nameof(Index));
        }

        private bool WorkExists(int id)
        {
            return _context.Work.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Popup(int? id)
        {
            System.Diagnostics.Debug.WriteLine("id je --- " + id);
            var work = await WorkData.GetWork((int)id);
            return PartialView("Popup", work);
        }
    }
}
