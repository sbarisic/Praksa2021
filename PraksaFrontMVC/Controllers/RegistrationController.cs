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
    public class RegistrationController : Controller
    {
        private readonly PraksaFrontMVCContext _context;

        public RegistrationController(PraksaFrontMVCContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // POST: Registration
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,Oib,Accepted,Password,Dismissed,Email,Number")] Person person)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new();
                person.UniqueId = rnd.Next().ToString();

                PeopleData.CreateUser(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(HomeController.Index));
            }
            return View(person);
        }
    }
}
