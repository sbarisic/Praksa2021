using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Controllers
{
    public class Logout : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
