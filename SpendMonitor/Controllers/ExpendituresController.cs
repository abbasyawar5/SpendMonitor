using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpendMonitor.Models;
using SpendMonitor.Services.Interfaces;
using X.PagedList;

namespace SpendMonitor.Controllers
{
    public class ExpendituresController : Controller
    {
        private readonly SpendMonitorContext _context;
        private readonly IExpenditureService _expenditureService;

        public ExpendituresController(IExpenditureService expenditureService, SpendMonitorContext context)
        {
            _expenditureService = expenditureService;
            _context = context;
        }

        // GET: Expenditures
        public async Task<IActionResult> Index(string sortOrder)
        {

            return View(await _expenditureService.GetAllExpenditures(sortOrder).ToListAsync());
        }

        // GET: Expenditures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblExpenditure = await _context.TblExpenditures
                .Include(t => t.ExpCategoryNavigation)
                .FirstOrDefaultAsync(m => m.Expid == id);
            if (tblExpenditure == null)
            {
                return NotFound();
            }

            return View(tblExpenditure);
        }

        // GET: Expenditures/Create
        public IActionResult Create()
        {
            ViewData["ExpCategory"] = new SelectList(_context.TblCategories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Expenditures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Expid,ExpAmount,ExpCategory,ExpDate,ExpShop")] TblExpenditure tblExpenditure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblExpenditure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExpCategory"] = new SelectList(_context.TblCategories, "CategoryId", "CategoryName", tblExpenditure.ExpCategory);
            return View(tblExpenditure);
        }

        // GET: Expenditures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblExpenditure = await _context.TblExpenditures.FindAsync(id);
            if (tblExpenditure == null)
            {
                return NotFound();
            }
            ViewData["ExpCategory"] = new SelectList(_context.TblCategories, "CategoryId", "CategoryName", tblExpenditure.ExpCategory);
            return View(tblExpenditure);
        }

        // POST: Expenditures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Expid,ExpAmount,ExpCategory,ExpDate,ExpShop")] TblExpenditure tblExpenditure)
        {
            if (id != tblExpenditure.Expid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblExpenditure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblExpenditureExists(tblExpenditure.Expid))
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
            ViewData["ExpCategory"] = new SelectList(_context.TblCategories, "CategoryId", "CategoryName", tblExpenditure.ExpCategory);
            return View(tblExpenditure);
        }

        // GET: Expenditures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblExpenditure = await _context.TblExpenditures
                .Include(t => t.ExpCategoryNavigation)
                .FirstOrDefaultAsync(m => m.Expid == id);
            if (tblExpenditure == null)
            {
                return NotFound();
            }

            return View(tblExpenditure);
        }

        // POST: Expenditures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblExpenditure = await _context.TblExpenditures.FindAsync(id);
            _context.TblExpenditures.Remove(tblExpenditure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblExpenditureExists(int id)
        {
            return _context.TblExpenditures.Any(e => e.Expid == id);
        }
    }
}
