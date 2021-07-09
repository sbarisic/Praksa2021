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
    public class ContactEmailsController : Controller
    {
        private readonly PraksaFrontMVCContext _context;
        public ContactEmailsController(PraksaFrontMVCContext context)
        {
            _context = context;
        }

        // GET: ContactEmails
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.userId = id;
            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == id))
                return View(await ContactEmailData.GetContactEmails((int)id));
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: ContactEmails/Details/5
        public async Task<IActionResult> Details(int? id, int? userId)
        {
            System.Diagnostics.Debug.WriteLine(userId);
            if (id == null && userId == null)
            {
                return NotFound();
            }

            var contactEmail = await ContactEmailData.GetEmail((int)userId, (int)id);
            if (contactEmail == null)
            {
                return NotFound();
            }
            ViewBag.userId = userId;

            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == userId))
                return View(contactEmail);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: ContactEmails/Create
        public IActionResult Create(int? userId)
        {
            ViewBag.userId = userId;

            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == userId))
                return View();
            else
                return RedirectToAction("ErrorPage", "Home");

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
                ContactEmailData.CreateEmail(contactEmail);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ContactEmails", new { @id = contactEmail.IdUser });
            }

            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == contactEmail.IdUser))
                return View(contactEmail);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: ContactEmails/Edit/5
        public async Task<IActionResult> Edit(int? id, int? userId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactEmail = await ContactEmailData.GetEmail((int)userId, (int)id);
            if (contactEmail == null)
            {
                return NotFound();
            }
            ViewBag.userId = userId;

            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == userId))
                return View(contactEmail);
            else
                return RedirectToAction("ErrorPage", "Home");

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
                    ContactEmailData.EditEmail(contactEmail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index", "ContactEmails", new { @id = contactEmail.IdUser });
            }

            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == contactEmail.IdUser))
                return View(contactEmail);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: ContactEmails/Delete/5
        public async Task<IActionResult> Delete(int? id, int? userId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactEmail = await ContactEmailData.GetEmail((int)userId, (int)id);
            if (contactEmail == null)
            {
                return NotFound();
            }
            ViewBag.userId = userId;
            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == userId))
                return View(contactEmail);
            else
                return RedirectToAction("ErrorPage", "Home");


        }

        // POST: ContactEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int userId, int id)
        {
            var contactEmail = await ContactEmailData.GetEmail(userId, id);
            int status = await ContactEmailData.DeleteEmail(id);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "ContactEmails", new { @id = contactEmail.IdUser });
        }

        private bool ContactEmailExists(int id)
        {
            return _context.ContactEmail.Any(e => e.Id == id);
        }
    }
}
