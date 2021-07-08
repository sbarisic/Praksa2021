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

namespace PraksaFrontMVC
{
    public class RolesController : Controller
    {
        private readonly PraksaFrontMVCContext _context;

        public RolesController(PraksaFrontMVCContext context)
        {
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(await _context.Role.ToListAsync());
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View();
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IdRole,IdUser")] Role role)
        {
            if (ModelState.IsValid)
            {
               RoleData.CreateRole(role);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(role);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(role);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IdRole,IdUser")] Role role)
        {
            if (id != role.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(role);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(role.Id))
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
                return View(role);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Role
                .FirstOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(role);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            RoleData.DeleteRole((int)id);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(int id)
        {
            return _context.Role.Any(e => e.Id == id);
        }
    }
}
