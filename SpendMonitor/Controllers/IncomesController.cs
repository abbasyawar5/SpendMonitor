﻿using System;
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
        private readonly SpendMonitorContext _context;
        private readonly IIncomeService _incService;
        public IncomesController(SpendMonitorContext context, IIncomeService incService)
        {
            _context = context;
            _incService = incService;
        }

        // GET: Incomes
        public async Task<IActionResult> Index()
        {
            
            return View(await _incService.GetAllIncomes().ToListAsync());
            
        }

        // GET: Incomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIncome = await _context.TblIncomes
                .Include(t => t.IncomeCategoryNavigation)
                .FirstOrDefaultAsync(m => m.IncomeId == id);
            if (tblIncome == null)
            {
                return NotFound();
            }

            return View(tblIncome);
        }

        // GET: Incomes/Create
        public IActionResult Create()
        {
            ViewData["IncomeCategory"] = new SelectList(_context.TblCategories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Incomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IncomeAmount,IncomeCategory,IncomeDate,ExpSource")]  TblIncome tblIncome)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblIncome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IncomeCategory"] = new SelectList(_context.TblCategories, "CategoryId", "CategoryName", tblIncome.IncomeCategory);
            return View(tblIncome);
        }

        // GET: Incomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIncome = await _context.TblIncomes.FindAsync(id);
            if (tblIncome == null)
            {
                return NotFound();
            }
            ViewData["IncomeCategory"] = new SelectList(_context.TblCategories, "CategoryId", "CategoryName", tblIncome.IncomeCategory);
            return View(tblIncome);
        }

        // POST: Incomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IncomeId,IncomeAmount,IncomeCategory,IncomeDate,ExpSource")] TblIncome tblIncome)
        {
            if (id != tblIncome.IncomeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblIncome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblIncomeExists(tblIncome.IncomeId))
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
            ViewData["IncomeCategory"] = new SelectList(_context.TblCategories, "CategoryId", "CategoryName", tblIncome.IncomeCategory);
            return View(tblIncome);
        }

        // GET: Incomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIncome = await _context.TblIncomes
                .Include(t => t.IncomeCategoryNavigation)
                .FirstOrDefaultAsync(m => m.IncomeId == id);
            if (tblIncome == null)
            {
                return NotFound();
            }

            return View(tblIncome);
        }

        // POST: Incomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblIncome = await _context.TblIncomes.FindAsync(id);
            _context.TblIncomes.Remove(tblIncome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblIncomeExists(int id)
        {
            return _context.TblIncomes.Any(e => e.IncomeId == id);
        }
    }
}