using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PraksaFrontMVC.Data;
using PraksaFrontMVC.Models;

namespace PraksaFrontMVC
{
    public class PermitsController : Controller
    {
        private readonly PraksaFrontMVCContext _context;

        public PermitsController(PraksaFrontMVCContext context)
        {
            _context = context;
        }

        // GET: Permits
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.userId = id;
            return View(await PermitData.GetPermits((int)id));
        }

        // GET: Permits/Details/5
        public async Task<IActionResult> Details(int? id, int? userId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permit = await PermitData.GetPermit((int)userId, (int)id);
            if (permit == null)
            {
                return NotFound();
            }
            ViewBag.userId = userId;
            return View(permit);
        }

        // GET: Permits/Create
        public IActionResult Create(int? userId)
        {
            ViewBag.userId = userId;
            return View();
        }

        // POST: Permits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUser,IdPermit,ExpiryDate,FirstName,LastName,PermitName,PermitNumber")] Permit permit)
        {
            if (ModelState.IsValid)
            {
                PermitData.CreatePermit(permit);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Permits", new { @id = permit.IdUser });
            }
            return View(permit);
        }

        // GET: Permits/Edit/5
        public async Task<IActionResult> Edit(int? id, int? userId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permit = await PermitData.GetPermit((int)userId, (int)id);
            if (permit == null)
            {
                return NotFound();
            }
            ViewBag.userId = userId;
            return View(permit);
        }

        // POST: Permits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUser,IdPermit,ExpiryDate,FirstName,LastName,PermitName,PermitNumber")] Permit permit)
        {
            if (id != permit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    PermitData.EditPermit(permit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermitExists(permit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Permits", new { @id = permit.IdUser });
            }
            return View(permit);
        }

        // GET: Permits/Delete/5
        public async Task<IActionResult> Delete(int? id, int? userId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permit = await PermitData.GetPermit((int)userId, (int)id);
            if (permit == null)
            {
                return NotFound();
            }
            ViewBag.userId = userId;
            return View(permit);
        }

        // POST: Permits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int userId)
        {
            var permit = await PermitData.GetPermit((int)userId, (int)id);
            PermitData.DeletePermit(id);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Permits", new { @id = permit.IdUser });
        }

        private bool PermitExists(int id)
        {
            return _context.Permit.Any(e => e.Id == id);
        }
    }
}
