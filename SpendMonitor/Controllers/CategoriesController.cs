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
    public class CategoriesController : Controller
    {

        private readonly ICategoryService _cateService;

        public CategoriesController(ICategoryService cateService)
        {
            _cateService = cateService;
        }

        public IActionResult Index()
        {
            return View(_cateService.GetAllCategories().ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CategoryName,CategoryDescription,CategoryIsExpenditure")] TblCategory category)
        {
            if (ModelState.IsValid)
            {
                _cateService.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var categoryFound = _cateService.FindCategoryById(id);
            return View(categoryFound);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CategoryId,CategoryName,CategoryDescription,CategoryIsExpenditure")] TblCategory category)
        {

            if (ModelState.IsValid)
            {
                _cateService.UpdateCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        public IActionResult Delete(int? id)
        {
            var tblCategory = _cateService.GetCategory(id);
            return View(tblCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _cateService.RemoveCategory(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
