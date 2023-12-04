using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sales_Management.Context;
using Sales_Management.Models;

namespace Sales_Management.Controllers
{
    public class SalesmanController : Controller
    {
        private readonly AppDbContext _context;

        public SalesmanController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Salesman
        public async Task<IActionResult> Index()
        {
              return _context.Salesmen != null ? 
                          View(await _context.Salesmen.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Salesmen'  is null.");
        }

        // GET: Salesman/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salesmen == null)
            {
                return NotFound();
            }

            var salesmanModel = await _context.Salesmen
                .FirstOrDefaultAsync(m => m.SalesmanId == id);
            if (salesmanModel == null)
            {
                return NotFound();
            }

            return View(salesmanModel);
        }

        // GET: Salesman/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salesman/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesmanId,FirstName,LastName,Email,Cellphone,Password")] SalesmanModel salesmanModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesmanModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesmanModel);
        }

        // GET: Salesman/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salesmen == null)
            {
                return NotFound();
            }

            var salesmanModel = await _context.Salesmen.FindAsync(id);
            if (salesmanModel == null)
            {
                return NotFound();
            }
            return View(salesmanModel);
        }

        // POST: Salesman/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesmanId,FirstName,LastName,Email,Cellphone,Password")] SalesmanModel salesmanModel)
        {
            if (id != salesmanModel.SalesmanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesmanModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesmanModelExists(salesmanModel.SalesmanId))
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
            return View(salesmanModel);
        }

        // GET: Salesman/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salesmen == null)
            {
                return NotFound();
            }

            var salesmanModel = await _context.Salesmen
                .FirstOrDefaultAsync(m => m.SalesmanId == id);
            if (salesmanModel == null)
            {
                return NotFound();
            }

            return View(salesmanModel);
        }

        // POST: Salesman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salesmen == null)
            {
                return Problem("Entity set 'AppDbContext.Salesmen'  is null.");
            }
            var salesmanModel = await _context.Salesmen.FindAsync(id);
            if (salesmanModel != null)
            {
                _context.Salesmen.Remove(salesmanModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesmanModelExists(int id)
        {
          return (_context.Salesmen?.Any(e => e.SalesmanId == id)).GetValueOrDefault();
        }
    }
}
