using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PraksaFrontMVC.Data;
using PraksaFrontMVC.Models;

namespace PraksaFrontMVC.Controllers
{
    public class AttendantsController : Controller
    {
        private readonly PraksaFrontMVCContext _context;

        public AttendantsController(PraksaFrontMVCContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(await AttendantData.GetAttendants((int)id));
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: Attendants
        public async Task<IActionResult> IndexActive(int? id)
        {
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(await AttendantData.GetAttendants((int)id));
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: Attendants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendant = await _context.Attendant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendant == null)
            {
                return NotFound();
            }

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(attendant);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: Attendants/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View();
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // POST: Attendants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdJob,IdUser,IdInteres,IdAttendance,SelectionTime")] Attendant attendant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(attendant);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: Attendants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendant = await _context.Attendant.FindAsync(id);
            if (attendant == null)
            {
                return NotFound();
            }
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(attendant);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // POST: Attendants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdJob,IdUser,IdInteres,IdAttendance,SelectionTime")] Attendant attendant)
        {
            if (id != attendant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendantExists(attendant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(attendant);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: Attendants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendant = await _context.Attendant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendant == null)
            {
                return NotFound();
            }
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(attendant);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // POST: Attendants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendant = await _context.Attendant.FindAsync(id);
            _context.Attendant.Remove(attendant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendantExists(int id)
        {
            return _context.Attendant.Any(e => e.Id == id);
        }

        // POST: People/Accept
        [HttpPost, ActionName("Coming")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Coming(int? id, int? isCalendar)
        {
            var email = HttpContext.Session.GetString("uname");
            var userId = PeopleData.GetUserId(email);
            System.Diagnostics.Debug.WriteLine(userId);
            Attendant att = new Attendant
            {
                IdJob = (int)id,
                IdInteres = 3,
                IdUser = Convert.ToInt32(userId),
                IdAttendance = 1
            };

            Attendant tempAtt = AttendantData.GetAttendant((int)id, userId);

            if (tempAtt.Id != 0)
            {
                att.Id = tempAtt.Id;
                AttendantData.EditAttendant(att);
            }
            else
            {
                AttendantData.CreateAttendant(att);
            }

            await _context.SaveChangesAsync();
            if((int)isCalendar == 1)
                return RedirectToAction("UserCalendar", "Works");
            else
                return RedirectToAction("UserIndex", "Works");
        }

        [HttpPost, ActionName("NotComing")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NotComing(int? id, int? isCalendar)
        {
            var email = HttpContext.Session.GetString("uname");
            var userId = PeopleData.GetUserId(email);
            System.Diagnostics.Debug.WriteLine(userId);
            Attendant att = new Attendant
            {
                IdJob = (int)id,
                IdInteres = 1,
                IdUser = Convert.ToInt32(userId),
                IdAttendance = 1
            };

            Attendant tempAtt = AttendantData.GetAttendant((int)id, userId);

            if (tempAtt.Id != 0)
            {
                att.Id = tempAtt.Id;
                AttendantData.EditAttendant(att);
            }
            else
            {
                AttendantData.CreateAttendant(att);
            }

            await _context.SaveChangesAsync();
            if ((int)isCalendar == 1)
                return RedirectToAction("UserCalendar", "Works");
            else
                return RedirectToAction("UserIndex", "Works");
        }

        [HttpPost, ActionName("MaybeComing")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MaybeComing(int? id, int? isCalendar)
        {
            var email = HttpContext.Session.GetString("uname");
            var userId = PeopleData.GetUserId(email);
            System.Diagnostics.Debug.WriteLine(userId);
            Attendant att = new Attendant
            {
                IdJob = (int)id,
                IdInteres = 2,
                IdUser = Convert.ToInt32(userId),
                IdAttendance = 1
            };

            Attendant tempAtt = AttendantData.GetAttendant((int)id, userId);

            if (tempAtt.Id != 0)
            {
                att.Id = tempAtt.Id;
                AttendantData.EditAttendant(att);
            }
            else
            {
                AttendantData.CreateAttendant(att);
            }

            await _context.SaveChangesAsync();
            if ((int)isCalendar == 1)
                return RedirectToAction("UserCalendar", "Works");
            else
                return RedirectToAction("UserIndex", "Works");
        }
    }

}
