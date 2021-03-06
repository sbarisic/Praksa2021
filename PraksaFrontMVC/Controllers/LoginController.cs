using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PraksaFrontMVC.Data;
using PraksaFrontMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly PraksaFrontMVCContext _context;

        public LoginController(PraksaFrontMVCContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        // POST: Login
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Id,FirstName,LastName,Address,Oib,Accepted,Password,Dismissed,Email,Number")] Person person)
        {
            int rv = Authentication.LogIn(person.Email, person.Password);
            if (rv == 0)
            {
                ModelState.AddModelError("password", "Upisali ste krivi email ili lozinku.");
                return View("/Views/Login/Index.cshtml");
            }
            else if (rv == 1)
            {
                ModelState.AddModelError("password", "Korisnik nije prihvaćen.");
                return View("/Views/Login/Index.cshtml");
            }
            else if (rv == 2)
            {
                int userId = PeopleData.GetUserId(person.Email);
                HttpContext.Session.SetString("uname", person.Email);
                HttpContext.Session.SetInt32("uid", userId);
                List <Role> roleList = await RoleData.GetRoles(PeopleData.GetUserId(person.Email));

                foreach (Role role in roleList)
                {
                    if (role.Name == "Admin")
                    {
                        HttpContext.Session.SetString("admin", "true");
                        
                        return RedirectToAction("Index", "Home");
                    }
                }
                HttpContext.Session.SetString("admin", "false");
                System.Diagnostics.Debug.WriteLine(HttpContext.Session.GetString("admin"));

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
