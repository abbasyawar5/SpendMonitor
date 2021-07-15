using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpendMonitor.Models;
using SpendMonitor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Controllers
{
    public class SubCategoriesController : Controller
    {
        private readonly ISubCategoryService _subCatService;
        private readonly ICategoryService _catService;

        public SubCategoriesController(ISubCategoryService subCatService, ICategoryService catService)
        {
            _subCatService = subCatService;
            _catService = catService;
        }

        public IActionResult Index()
        {
            return View(_subCatService.GetAllSubCategories().ToList());
        }
        public IActionResult Create()
        {
            ViewData["ParentCategories"] = new SelectList(_catService.GetAllCategories(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("SubCategoryName,SubCategoryDescription,SubCategoryParentCategory")] TblSubcategory category)
        {
            if (ModelState.IsValid)
            {
               
                _subCatService.AddSubCategory(category);
                ViewData["ParentCategories"] = new SelectList(_catService.GetAllCategories(), "CategoryId", "CategoryName");
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
