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
        private readonly IExpenditureService _expService;

        public ExpendituresController(IExpenditureService expService, SpendMonitorContext context)
        {
            _expService = expService;
            _context = context;
        }

        public IActionResult Index(string sortOrder)
        {

            return View(_expService.GetAllExpenditures(sortOrder).ToList());
        }

        public IActionResult Create()
        {
            ViewData["ExpCategory"] = new SelectList(_context.TblCategories, "CategoryId", "CategoryName");
            ViewData["ExpAccount"] = new SelectList(_context.TblAccounts, "AccountId", "AccountBankName");
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ExpAmount,ExpCategory,ExpAccount,ExpDate,ExpShop")] TblExpenditure expense)
        {
            if (ModelState.IsValid)
            {
                _expService.AddExpense(expense);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExpCategory"] = new SelectList(_context.TblCategories, "CategoryId", "CategoryName", expense.ExpCategory);
            ViewData["ExpAccount"] = new SelectList(_context.TblAccounts, "AccountId", "AccountBankName", expense.ExpAccount);
            return View(expense);
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
            ViewData["ExpAccount"] = new SelectList(_context.TblAccounts, "AccountId", "AccountBankName", tblExpenditure.ExpAccount);
            return View(tblExpenditure);
        }

        // POST: Expenditures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Expid,ExpAmount,ExpCategory,ExpAccount,ExpDate,ExpShop")] TblExpenditure expense)
        {

            if (ModelState.IsValid)
            {

                _expService.UpdateExpense(expense);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExpCategory"] = new SelectList(_context.TblCategories, "CategoryId", "CategoryName", expense.ExpCategory);
            ViewData["ExpAccount"] = new SelectList(_context.TblAccounts, "AccountId", "AccountBankName", expense.ExpAccount);
            return View(expense);
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
                .Include(t => t.ExpAccountNavigation)
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
