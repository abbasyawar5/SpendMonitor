using Microsoft.EntityFrameworkCore;
using SpendMonitor.Models;
using SpendMonitor.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Repositories
{
    public class ExpenditureRepository : IExpenditureRepository
    {
        private readonly SpendMonitorContext _context;

        public ExpenditureRepository(SpendMonitorContext context)
        {
            _context = context;
        }
        public List<TblExpenditure> GetAllExpenditures(string sortOrder)
        {

            return _context.TblExpenditures.Include(t => t.ExpCategoryNavigation).OrderByDescending(s => s.ExpDate).ToList();

        }

    }
}
