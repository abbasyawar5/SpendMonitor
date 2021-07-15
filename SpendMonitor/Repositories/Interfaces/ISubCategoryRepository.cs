using SpendMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Repositories.Interfaces
{
    public interface ISubCategoryRepository
    {
        List<TblSubcategory> GetAllSubCategories();
        TblSubcategory GetSubCategory(int? categoryId);
        bool RemoveSubCategory(int? categoryId);
        bool AddSubCategory(TblSubcategory category);
        bool UpdateSubCategory(TblSubcategory category);
        TblSubcategory FindSubCategoryById(int? categoryId);

    }
}
