using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraksaFrontMVC.Data;
using PraksaFrontMVC.Models;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Controllers
{
    public class PermitNamesController : Controller
    {
        private readonly PraksaFrontMVCContext _context;

        public PermitNamesController(PraksaFrontMVCContext context)
        {
            _context = context;
        }

        // GET: PermitNames
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("admin").Equals("true"))
                return View(await PermitNameData.GetPermitNames());
            else
                return RedirectToAction("Index", "Home");
        }

        // GET: PermitNames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permitName = await PermitNameData.GetPermitName((int)id);

            if (permitName == null)
            {
                return NotFound();
            }

            return View(permitName);
        }

        // GET: PermitNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PermitNames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PermitName permitName)
        {
            if (ModelState.IsValid)
            {
                PermitNameData.CreatePermitName(permitName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permitName);
        }

        // GET: PermitNames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permitName = await PermitNameData.GetPermitName((int)id);
            if (permitName == null)
            {
                return NotFound();
            }
            return View(permitName);
        }

        // POST: PermitNames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PermitName permitName)
        {
            if (id != permitName.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    PermitNameData.EditPermitName(permitName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(permitName);
        }

        // GET: PermitNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permitName = await PermitNameData.GetPermitName((int)id);

            if (permitName == null)
            {
                return NotFound();
            }

            return View(permitName);
        }

        // POST: PermitNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            PermitNameData.DeletePermitName(id);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
