using SpendMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        List<TblCategory> GetAllCategories();
        TblCategory GetCategory(int? categoryId);
        bool RemoveCategory(int? categoryId);
        bool AddCategory(TblCategory category);
        bool UpdateCategory(TblCategory category);
        TblCategory FindCategoryById(int? categoryId);

    }
}
