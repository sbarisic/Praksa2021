using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraksaFrontMVC.Data;
using PraksaFrontMVC.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;


namespace PraksaFrontMVC.Controllers
{
    public class WorksController : Controller
    {
        private readonly PraksaFrontMVCContext _context;

        public WorksController(PraksaFrontMVCContext context)
        {
            _context = context;
        }


        //Custom Methods
        public List<Work> GetWorks()
        {
            List<Work> works = new List<Work>();

            SqlConnection con = new SqlConnection("Server = 167.86.127.239; Database = Praksa2021; User Id = SerengetiUser; Password = Serengeti12345678910;");
            con.Open();

            SqlCommand cmd = new SqlCommand("getJobs", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    Work work = new Work
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Name = dr["Naziv akcije"].ToString(),
                        Description = dr["Opis"].ToString(),
                        Location = dr["Mjesto"].ToString(),
                        Date = DateTime.Parse(dr["Datum"].ToString()).ToString("d"),
                        Time = DateTime.Parse(dr["Datum"].ToString()).ToString("t"),
                        Obligation = dr["Obaveznost"].ToString()
                    };

                    works.Add(work);

                }
            }
            return works;

        }


        // GET: Works
        public async Task<IActionResult> Index()
        {
            return View(GetWorks());
        }

        // GET: Works/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Work
                .FirstOrDefaultAsync(m => m.Id == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // GET: Works/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Date,Time,Description,Location,Obligation,IdAttendant")] Work work)
        {
            if (ModelState.IsValid)
            {
                _context.Add(work);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(work);
        }

        // GET: Works/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Work.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }
            return View(work);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date,Time,Description,Location,Obligation,IdAttendant")] Work work)
        {
            if (id != work.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(work);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkExists(work.Id))
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
            return View(work);
        }

        // GET: Works/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Work
                .FirstOrDefaultAsync(m => m.Id == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var work = await _context.Work.FindAsync(id);
            _context.Work.Remove(work);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkExists(int id)
        {
            return _context.Work.Any(e => e.Id == id);
        }
    }
}
