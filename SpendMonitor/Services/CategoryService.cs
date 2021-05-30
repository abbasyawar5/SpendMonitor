using SpendMonitor.Models;
using SpendMonitor.Repositories.Interfaces;
using SpendMonitor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _cateRepo;

        public CategoryService(ICategoryRepository cateRepo)
        {
            _cateRepo = cateRepo;
        }

        public List<TblCategory> GetAllCategories() =>  _cateRepo.GetAllCategories();
        public bool RemoveCategory(int categoryId) => _cateRepo.RemoveCategory(categoryId);
        public bool AddCategory(TblCategory category) => _cateRepo.AddCategory(category);
        public bool SaveCategory(TblCategory category) => _cateRepo.SaveCategory(category);

        public bool RemoveCategory(int? categoryId) => _cateRepo.RemoveCategory(categoryId);
        public TblCategory FindCategoryById(int? categoryId) => _cateRepo.FindCategoryById(categoryId);

        public TblCategory GetCategory(int? categoryId) => _cateRepo.GetCategory(categoryId);
    }
}
