using SpendMonitor.Models;
using SpendMonitor.Repositories.Interfaces;
using SpendMonitor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _cateRepo;

        public SubCategoryService(ISubCategoryRepository cateRepo)
        {
            _cateRepo = cateRepo;
        }

        public List<TblSubcategory> GetAllSubCategories() =>  _cateRepo.GetAllSubCategories();
        public bool RemoveSubCategory(int categoryId) => _cateRepo.RemoveSubCategory(categoryId);
        public bool AddSubCategory(TblSubcategory category) => _cateRepo.AddSubCategory(category);
        public bool UpdateSubCategory(TblSubcategory category) => _cateRepo.UpdateSubCategory(category);

        public bool RemoveSubCategory(int? categoryId) => _cateRepo.RemoveSubCategory(categoryId);
        public TblSubcategory FindSubCategoryById(int? categoryId) => _cateRepo.FindSubCategoryById(categoryId);

        public TblSubcategory GetSubCategory(int? categoryId) => _cateRepo.GetSubCategory(categoryId);
    }
}
