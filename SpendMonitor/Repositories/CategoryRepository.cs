using SpendMonitor.Models;
using SpendMonitor.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SpendMonitorContext _context;

        public CategoryRepository(SpendMonitorContext context)
        {
            _context = context;
        }
        public List<TblCategory> GetAllCategories()
        {
            return _context.TblCategories.ToList();
        }

        public TblCategory FindCategoryById(int? categoryId)
        {

            var category = _context.TblCategories.Find(categoryId);

            return category;
        }
        public bool AddCategory(TblCategory category)
        {
            try
            {
                var isCateogryAdded = _context.Add(category);
                _context.SaveChanges();
                if (isCateogryAdded.State.ToString().Equals("Added"))
                    return true;
                else
                    return false;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
        public bool UpdateCategory(TblCategory category)
        {
            try
            {
                var isCategoryUpdated = _context.Update(category);
                _context.SaveChanges();
                if (isCategoryUpdated.State.ToString().Equals("Modified"))
                    return true;
                else
                    return false;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
        public bool RemoveCategory(int? categoryId)
        {
            try
            {
                var tblCategory = _context.TblCategories.Find(categoryId);
                var isCategoryRemoved = _context.TblCategories.Remove(tblCategory);
                _context.SaveChanges();
                if (isCategoryRemoved.State.ToString().Equals("Deleted"))
                    return true;
                else
                    return false;
            }
            catch (Exception Ex)
            {
                return false;
            }


        }

        private bool TblCategoryExists(int id)
        {
            return _context.TblCategories.Any(e => e.CategoryId == id);
        }

        public TblCategory GetCategory(int? categoryId)
        {
            return _context.TblCategories.FirstOrDefault(m => m.CategoryId == categoryId);
        }
    }
}
