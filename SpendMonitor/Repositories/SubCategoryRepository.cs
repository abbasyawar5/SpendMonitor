using Microsoft.EntityFrameworkCore;
using SpendMonitor.Models;
using SpendMonitor.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly SpendMonitorContext _context;

        public SubCategoryRepository(SpendMonitorContext context)
        {
            _context = context;
        }
        public List<TblSubcategory> GetAllSubCategories()
        {
            return _context.TblSubcategories
                 .Include(t => t.SubCategoryParentCategoryNavigation)
                .ToList();
        }

        public TblSubcategory FindSubCategoryById(int? categoryId)
        {

            var category = _context.TblSubcategories.Find(categoryId);

            return category;
        }
        public bool AddSubCategory(TblSubcategory category)
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
        public bool UpdateSubCategory(TblSubcategory category)
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
        public bool RemoveSubCategory(int? categoryId)
        {
            try
            {
                var tblCategory = _context.TblSubcategories.Find(categoryId);
                var isCategoryRemoved = _context.TblSubcategories.Remove(tblCategory);
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
            return _context.TblSubcategories.Any(e => e.SubCategoryId == id);
        }

        public TblSubcategory GetSubCategory(int? categoryId)
        {
            return _context.TblSubcategories.FirstOrDefault(m => m.SubCategoryId == categoryId);
        }
    }
}
