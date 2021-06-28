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
    public class ContactEmailsController : Controller
    {
        private readonly PraksaFrontMVCContext _context;

        public ContactEmailsController(PraksaFrontMVCContext context)
        {
            _context = context;
        }

        // GET: ContactEmails
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactEmail.ToListAsync());
        }

        // GET: ContactEmails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactEmail = await _context.ContactEmail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactEmail == null)
            {
                return NotFound();
            }

            return View(contactEmail);
        }

        // GET: ContactEmails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactEmails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,IdUser")] ContactEmail contactEmail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactEmail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactEmail);
        }

        // GET: ContactEmails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactEmail = await _context.ContactEmail.FindAsync(id);
            if (contactEmail == null)
            {
                return NotFound();
            }
            return View(contactEmail);
        }

        // POST: ContactEmails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,IdUser")] ContactEmail contactEmail)
        {
            if (id != contactEmail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactEmail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactEmailExists(contactEmail.Id))
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
            return View(contactEmail);
        }

        // GET: ContactEmails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactEmail = await _context.ContactEmail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactEmail == null)
            {
                return NotFound();
            }

            return View(contactEmail);
        }

        // POST: ContactEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactEmail = await _context.ContactEmail.FindAsync(id);
            _context.ContactEmail.Remove(contactEmail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactEmailExists(int id)
        {
            return _context.ContactEmail.Any(e => e.Id == id);
        }
    }
}
