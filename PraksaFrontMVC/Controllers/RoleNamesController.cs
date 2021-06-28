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
    public class RoleNamesController : Controller
    {
        private readonly PraksaFrontMVCContext _context;

        public RoleNamesController(PraksaFrontMVCContext context)
        {
            _context = context;
        }

        // GET: RoleNames
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoleName.ToListAsync());
        }

        // GET: RoleNames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleName = await _context.RoleName
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roleName == null)
            {
                return NotFound();
            }

            return View(roleName);
        }

        // GET: RoleNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoleNames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] RoleName roleName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roleName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roleName);
        }

        // GET: RoleNames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleName = await _context.RoleName.FindAsync(id);
            if (roleName == null)
            {
                return NotFound();
            }
            return View(roleName);
        }

        // POST: RoleNames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RoleName roleName)
        {
            if (id != roleName.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roleName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleNameExists(roleName.Id))
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
            return View(roleName);
        }

        // GET: RoleNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleName = await _context.RoleName
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roleName == null)
            {
                return NotFound();
            }

            return View(roleName);
        }

        // POST: RoleNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roleName = await _context.RoleName.FindAsync(id);
            _context.RoleName.Remove(roleName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleNameExists(int id)
        {
            return _context.RoleName.Any(e => e.Id == id);
        }
    }
}
