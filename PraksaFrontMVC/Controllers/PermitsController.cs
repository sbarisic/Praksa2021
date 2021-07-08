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
            var person = await PeopleData.GetUser((int)id);
            ViewBag.userId = id;
            ViewBag.userName = person.FirstName + " " + person.LastName;

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(await PermitData.GetPermits((int)id));
            else
                return RedirectToAction("ErrorPage", "Home");

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

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(permit);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        public async Task<IActionResult> Add(int? userId, int? permitId)
        {
            var permit = await PermitNameData.GetPermitName((int)permitId);
            var person = await PeopleData.GetUser((int)userId);
            ViewBag.userName = person.FirstName + " " + person.LastName;
            ViewBag.userId = userId;
            ViewBag.permitId = permitId;
            ViewBag.permitName = permit.Name;

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View();
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,IdUser,IdPermit,ExpiryDate,FirstName,LastName,PermitName,PermitNumber")] Permit permit)
        {
            if (ModelState.IsValid)
            {
                PermitData.CreatePermit(permit);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Permits", new { @id = permit.IdUser });
            }

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(permit);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: Permits/Create
        public async Task<IActionResult> Create(int? userId)
        {
            var person = await PeopleData.GetUser((int)userId);
            ViewBag.userName = person.FirstName + " " + person.LastName;
            ViewBag.userId = userId;

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(await PermitNameData.GetPermitNames());
            else
                return RedirectToAction("ErrorPage", "Home");

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

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(permit);
            else
                return RedirectToAction("ErrorPage", "Home");

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
            var user = await PeopleData.GetUser((int)userId);
            ViewBag.userId = userId;
            ViewBag.permitName = permit.PermitName;
            ViewBag.userName = user.FirstName + " " + user.LastName;

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(permit);
            else
                return RedirectToAction("ErrorPage", "Home");

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

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(permit);
            else
                return RedirectToAction("ErrorPage", "Home");

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
            var user = await PeopleData.GetUser((int)userId);
            ViewBag.userId = userId;
            ViewBag.userName = user.FirstName + " " + user.LastName;

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(permit);
            else
                return RedirectToAction("ErrorPage", "Home");

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
