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
    public class ContactNumbersController : Controller
    {
        private readonly PraksaFrontMVCContext _context;

        public ContactNumbersController(PraksaFrontMVCContext context)
        {
            _context = context;
        }

        // GET: ContactNumbers
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.userId = id;
            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == id))
                return View(await ContactNumberData.GetContactNumbers((int)id));
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: ContactNumbers/Details/5
        public async Task<IActionResult> Details(int? id, int? userId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactNumber = await ContactNumberData.GetContactNumber((int)userId, (int)id);
            if (contactNumber == null)
            {
                return NotFound();
            }
            ViewBag.userId = userId;
            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == userId))
                return View(contactNumber);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: ContactNumbers/Create
        public IActionResult Create(int? userId)
        {
            ViewBag.userId = userId;
            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == userId))
                return View();
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // POST: ContactNumbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,IdUser")] ContactNumber contactNumber)
        {
            if (ModelState.IsValid)
            {
                ContactNumberData.CreateContactNumber(contactNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ContactNumbers", new { @id = contactNumber.IdUser });
            }
            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == contactNumber.IdUser))
                return View(contactNumber);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: ContactNumbers/Edit/5
        public async Task<IActionResult> Edit(int? id, int? userId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactNumber = await ContactNumberData.GetContactNumber((int)userId, (int)id);
            if (contactNumber == null)
            {
                return NotFound();
            }
            ViewBag.userId = userId;
            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == userId))
                return View(contactNumber);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // POST: ContactNumbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,IdUser")] ContactNumber contactNumber)
        {
            if (id != contactNumber.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ContactNumberData.EditContactNumber(contactNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactNumberExists(contactNumber.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "ContactNumbers", new { @id = contactNumber.IdUser });
            }
            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == contactNumber.IdUser))
                return View(contactNumber);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: ContactNumbers/Delete/5
        public async Task<IActionResult> Delete(int? id, int? userId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactNumber = await ContactNumberData.GetContactNumber((int)userId, (int)id);
            if (contactNumber == null)
            {
                return NotFound();
            }
            ViewBag.userId = userId;
            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == userId))
                return View(contactNumber);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // POST: ContactNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int userId, int id)
        {
            var numbers = await ContactNumberData.GetContactNumbers(userId);
            if (numbers.Count > 1)
            {
                var contactNumber = await ContactNumberData.GetContactNumber(userId, id);
                ContactNumberData.DeleteContactNumber(id);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ContactNumbers", new { @id = userId });
            }
            return RedirectToAction("DeleteError", "Home");
        }

        private bool ContactNumberExists(int id)
        {
            return _context.ContactNumber.Any(e => e.Id == id);
        }
    }
}
