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
        private readonly IExpenditureService _expService;
        public ExpendituresController(IExpenditureService expService, SpendMonitorContext context)
        {
            _expService = expService;
        }
        public IActionResult Index()
        {

            return View(_expService.GetAllExpenditures().ToList());
        }
        public IActionResult Create()
        {
            ViewData["ExpCategory"] = new SelectList(_expService.GetAllCategories(), "CategoryId", "CategoryName");
            ViewData["ExpAccount"] = new SelectList(_expService.GetAllAccounts(), "AccountId", "AccountBankName");
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
            ViewData["ExpCategory"] = new SelectList(_expService.GetAllCategories(), "CategoryId", "CategoryName", expense.ExpCategory);
            ViewData["ExpAccount"] = new SelectList(_expService.GetAllAccounts(), "AccountId", "AccountBankName", expense.ExpAccount);
            return View(expense);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblExpenditure = _expService.FindExopenseById(id);
            if (tblExpenditure == null)
            {
                return NotFound();
            }
            ViewData["ExpCategory"] = new SelectList(_expService.GetAllCategories(), "CategoryId", "CategoryName", tblExpenditure.ExpCategory);
            ViewData["ExpAccount"] = new SelectList(_expService.GetAllAccounts(), "AccountId", "AccountBankName", tblExpenditure.ExpAccount);
            return View(tblExpenditure);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Expid,ExpAmount,ExpCategory,ExpAccount,ExpDate,ExpShop")] TblExpenditure expense)
        {
            if (ModelState.IsValid)
            {
                _expService.UpdateExpense(expense);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExpCategory"] = new SelectList(_expService.GetAllCategories(), "CategoryId", "CategoryName", expense.ExpCategory);
            ViewData["ExpAccount"] = new SelectList(_expService.GetAllAccounts(), "AccountId", "AccountBankName", expense.ExpAccount);
            return View(expense);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblExpenditure = _expService.FindExpenseToDelete(id);
            if (tblExpenditure == null)
            {
                return NotFound();
            }

            return View(tblExpenditure);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tblExpenditure = _expService.FindExopenseById(id);
            _expService.RemoveExpense(tblExpenditure);
            return RedirectToAction(nameof(Index));
        }

        //private bool TblExpenditureExists(int id)
        //{
        //    return _context.TblExpenditures.Any(e => e.Expid == id);
        //}
    }
}
