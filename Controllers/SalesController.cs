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
    public class SalesController : Controller
    {
        private readonly AppDbContext _context;

        public SalesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Sales.Include(s => s.Client).Include(s => s.Salesman);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var salesModel = await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Salesman)
                .FirstOrDefaultAsync(m => m.SalesId == id);
            if (salesModel == null)
            {
                return NotFound();
            }

            return View(salesModel);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId");
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "SalesmanId", "SalesmanId");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesId,SalesDate,TotalAmount,SalesmanId,ClientId")] SalesModel salesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", salesModel.ClientId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "SalesmanId", "SalesmanId", salesModel.SalesmanId);
            return View(salesModel);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var salesModel = await _context.Sales.FindAsync(id);
            if (salesModel == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", salesModel.ClientId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "SalesmanId", "SalesmanId", salesModel.SalesmanId);
            return View(salesModel);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesId,SalesDate,TotalAmount,SalesmanId,ClientId")] SalesModel salesModel)
        {
            if (id != salesModel.SalesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesModelExists(salesModel.SalesId))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", salesModel.ClientId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "SalesmanId", "SalesmanId", salesModel.SalesmanId);
            return View(salesModel);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var salesModel = await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Salesman)
                .FirstOrDefaultAsync(m => m.SalesId == id);
            if (salesModel == null)
            {
                return NotFound();
            }

            return View(salesModel);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sales == null)
            {
                return Problem("Entity set 'AppDbContext.Sales'  is null.");
            }
            var salesModel = await _context.Sales.FindAsync(id);
            if (salesModel != null)
            {
                _context.Sales.Remove(salesModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesModelExists(int id)
        {
          return (_context.Sales?.Any(e => e.SalesId == id)).GetValueOrDefault();
        }
    }
}
