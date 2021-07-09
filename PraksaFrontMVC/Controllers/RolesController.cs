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
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.userId = id;
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(await RoleData.GetRoles((int)id));
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: Roles/Create
        public async Task<IActionResult> Create(int? userId)
        {
            var person = await PeopleData.GetUser((int)userId);
            ViewBag.userName = person.FirstName + " " + person.LastName;
            ViewBag.userId = userId;

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(await RoleNameData.GetRoleNames());
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

        public async Task<IActionResult> Add(int? roleId, int? userId)
        {
            var role = await RoleNameData.GetRoleName((int)roleId);
            var person = await PeopleData.GetUser((int)userId);
            ViewBag.userName = person.FirstName + " " + person.LastName;
            ViewBag.userId = userId;
            ViewBag.roleId = roleId;
            ViewBag.roleName = role.Name;

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View();
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,Name,IdRole,IdUser")] Role role)
        {
            if (ModelState.IsValid)
            {
                RoleData.CreateRole(role);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Roles", new { @id = role.IdUser });
            }

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(role);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(string role, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (role == null)
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();
            ViewBag.userId = id;

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
