using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET: Attendants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Attendant.ToListAsync());
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

            return View(attendant);
        }

        // GET: Attendants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attendants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdJob,IdUser,IdInteres,IdAttendance,SelectionTime,UserFirstName,UserLastName,Job,Interes,Attendance")] Attendant attendant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attendant);
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
            return View(attendant);
        }

        // POST: Attendants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdJob,IdUser,IdInteres,IdAttendance,SelectionTime,UserFirstName,UserLastName,Job,Interes,Attendance")] Attendant attendant)
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
            return View(attendant);
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

            return View(attendant);
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
    }
}
