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
    }
}
