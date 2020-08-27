using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DawApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace DawApp.Controllers
{
    
    public class CasesController : Controller
    {
        private readonly aspnetDawApp1A0EA8296B634A19A300D9D1031A2B76Context _context;

        public CasesController(aspnetDawApp1A0EA8296B634A19A300D9D1031A2B76Context context)
        {
            _context = context;
        }

        // GET: Cases
        public async Task<IActionResult> Index()
        {
            var aspnetDawApp1A0EA8296B634A19A300D9D1031A2B76Context = _context.Cases.Include(c => c.Country);
            return View(await aspnetDawApp1A0EA8296B634A19A300D9D1031A2B76Context.ToListAsync());
        }
        [Authorize(Roles = "Admin,Moderator")]
        // GET: Cases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cases = await _context.Cases
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.CaseId == id);
            if (cases == null)
            {
                return NotFound();
            }

            return View(cases);
        }
        [Authorize(Roles = "Admin,Moderator")]
        // GET: Cases/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Country, "CountryId", "Name");
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Moderator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaseId,NoCases,NoRecovered,NoDeath,CountryId")] Cases cases)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cases);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "CountryId", "Name", cases.CountryId);
            return View(cases);
        }
        [Authorize(Roles = "Admin,Moderator")]
        // GET: Cases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cases = await _context.Cases.FindAsync(id);
            if (cases == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "CountryId", "Name", cases.CountryId);
            return View(cases);
        }
        [Authorize(Roles = "Admin,Moderator")]
        // POST: Cases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaseId,NoCases,NoRecovered,NoDeath,CountryId")] Cases cases)
        {
            if (id != cases.CaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cases);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasesExists(cases.CaseId))
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
            ViewData["CountryId"] = new SelectList(_context.Country, "CountryId", "Name", cases.CountryId);
            return View(cases);
        }
        [Authorize(Roles = "Admin,Moderator")]
        // GET: Cases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cases = await _context.Cases
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.CaseId == id);
            if (cases == null)
            {
                return NotFound();
            }

            return View(cases);
        }
        [Authorize(Roles = "Admin,Moderator")]
        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cases = await _context.Cases.FindAsync(id);
            _context.Cases.Remove(cases);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasesExists(int id)
        {
            return _context.Cases.Any(e => e.CaseId == id);
        }
    }
}
