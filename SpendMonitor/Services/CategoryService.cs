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
        
    }
}
