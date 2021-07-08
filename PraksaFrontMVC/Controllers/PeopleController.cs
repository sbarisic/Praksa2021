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
    public class PeopleController : Controller
    {
        private readonly PraksaFrontMVCContext _context;

        public PeopleController(PraksaFrontMVCContext context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(await PeopleData.GetUsers());
            else
                return RedirectToAction("ErrorPage", "Home");
            
        }

        // GET: Registration Requests
        public async Task<IActionResult> RegistrationRequest()
        {
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(await PeopleData.GetRegistartionsRequestUser());
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: Dismissed Users 
        public async Task<IActionResult> DismissedUsers()
        {
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(await PeopleData.GetDismissedUsers());
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await PeopleData.GetUser((int)id);
            if (person == null)
            {
                return NotFound();
            }

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(person);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        public async Task<IActionResult> Accept(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await PeopleData.GetUser((int)id);
            if (person == null)
            {
                return NotFound();
            }

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(person);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await PeopleData.GetUser((int)id);
            if (person == null)
            {
                return NotFound();
            }

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(person);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        public async Task<IActionResult> Reject(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await PeopleData.GetUser((int)id);
            if (person == null)
            {
                return NotFound();
            }

            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(person);
            else
                return RedirectToAction("ErrorPage", "Home");

        }



        // GET: People/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View();
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UniqueId,FirstName,LastName,Address,Oib,Accepted,Password,Dismissed")] Person person)
        {
            if (ModelState.IsValid)
            {
                PeopleData.CreateUser(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin").Equals("true"))
                return View(person);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await PeopleData.GetUser((int)id);
            if (person == null)
            {
                return NotFound();
            }
            ViewBag.userId = id;
            ViewBag.email = person.Email;
            ViewBag.number = person.Number;

            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == id))
                return View(person);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UniqueId,FirstName,LastName,Address,Oib")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    PeopleData.EditUser(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == person.Id))
                return View(person);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await PeopleData.GetUser((int)id);
            if (person == null)
            {
                return NotFound();
            }

            if (HttpContext.Session.GetString("admin") != null && (HttpContext.Session.GetString("admin").Equals("true") || HttpContext.Session.GetInt32("uid") == id))
                return View(person);
            else
                return RedirectToAction("ErrorPage", "Home");

        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await PeopleData.GetUser((int)id);
            PeopleData.DeleteUser(id);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // POST: People/Accept
        [HttpPost, ActionName("Accept")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept(int id)
        {
            var person = await PeopleData.GetUser((int)id);
            PeopleData.VerificateUser(id);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: People/Reject
        [HttpPost, ActionName("Reject")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            var person = await PeopleData.GetUser((int)id);
            PeopleData.RejectUser(id);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(RegistrationRequest));
        }

        // POST: People/V
        [HttpPost, ActionName("Activate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Activate(int id)
        {
            var person = await PeopleData.GetUser((int)id);
            PeopleData.ActivateUser(id);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DismissedUsers));
        }


        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}
