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
    public class PermitNamesController : Controller
    {
        private readonly PraksaFrontMVCContext _context;

        public PermitNamesController(PraksaFrontMVCContext context)
        {
            _context = context;
        }

        // GET: PermitNames
        public async Task<IActionResult> Index()
        {
            return View(await _context.PermitName.ToListAsync());
        }

        // GET: PermitNames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permitName = await _context.PermitName
                .FirstOrDefaultAsync(m => m.Id == id);
            if (permitName == null)
            {
                return NotFound();
            }

            return View(permitName);
        }

        // GET: PermitNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PermitNames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PermitName permitName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permitName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permitName);
        }

        // GET: PermitNames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permitName = await _context.PermitName.FindAsync(id);
            if (permitName == null)
            {
                return NotFound();
            }
            return View(permitName);
        }

        // POST: PermitNames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PermitName permitName)
        {
            if (id != permitName.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permitName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermitNameExists(permitName.Id))
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
            return View(permitName);
        }

        // GET: PermitNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permitName = await _context.PermitName
                .FirstOrDefaultAsync(m => m.Id == id);
            if (permitName == null)
            {
                return NotFound();
            }

            return View(permitName);
        }

        // POST: PermitNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permitName = await _context.PermitName.FindAsync(id);
            _context.PermitName.Remove(permitName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermitNameExists(int id)
        {
            return _context.PermitName.Any(e => e.Id == id);
        }
    }
}
