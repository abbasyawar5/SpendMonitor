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
    public class IncomesController : Controller
    {
        private readonly IIncomeService _incService;
        public IncomesController(SpendMonitorContext context, IIncomeService incService)
        {
            _incService = incService;
        }

        public IActionResult Index()
        {

            return View(_incService.GetAllIncomes().ToList());

        }

        public IActionResult Create()
        {
            ViewData["IncomeCategory"] = new SelectList(_incService.GetAllCategories(), "CategoryId", "CategoryName");
            ViewData["IncomeAccount"] = new SelectList(_incService.GetAllAccounts(), "AccountId", "AccountBankName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IncomeAmount,IncomeCategory,IncomeAccount,IncomeDate,IncomeSource")] TblIncome income)
        {
            if (ModelState.IsValid)
            {
                _incService.AddIncome(income);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IncomeCategory"] = new SelectList(_incService.GetAllCategories(), "CategoryId", "CategoryName", income.IncomeCategory);
            ViewData["IncomeAccount"] = new SelectList(_incService.GetAllAccounts(), "AccountId", "AccountBankName");
            return View(income);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIncome = _incService.FindIncomeById(id);
            if (tblIncome == null)
            {
                return NotFound();
            }
            ViewData["IncomeCategory"] = new SelectList(_incService.GetAllCategories(), "CategoryId", "CategoryName", tblIncome.IncomeCategory);
            ViewData["IncomeAccount"] = new SelectList(_incService.GetAllAccounts(), "AccountId", "AccountBankName");
            return View(tblIncome);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("IncomeId,IncomeAmount,IncomeCategory,IncomeAccount,IncomeDate,IncomeSource")] TblIncome tblIncome)
        {
            if (id != tblIncome.IncomeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _incService.UpdateIncome(tblIncome);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IncomeCategory"] = new SelectList(_incService.GetAllCategories(), "CategoryId", "CategoryName", tblIncome.IncomeCategory);
            ViewData["IncomeAccount"] = new SelectList(_incService.GetAllAccounts(), "AccountId", "AccountBankName");
            return View(tblIncome);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIncome = _incService.FindIncomeToDelete(id);

            if (tblIncome == null)
            {
                return NotFound();
            }

            return View(tblIncome);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tblIncome = _incService.FindIncomeById(id);
            _incService.RemoveIncome(tblIncome);
            return RedirectToAction(nameof(Index));
        }
        //private bool TblIncomeExists(int id)
        //{
        //    return _context.TblIncomes.Any(e => e.IncomeId == id);
        //}
    }
}
