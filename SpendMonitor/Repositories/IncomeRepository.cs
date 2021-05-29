using Microsoft.EntityFrameworkCore;
using SpendMonitor.Models;
using SpendMonitor.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly SpendMonitorContext _context;

        public IncomeRepository(SpendMonitorContext context)
        {
            _context = context;
        }
        public List<TblIncome> GetAllIncomes()
        {
            return _context.TblIncomes.Include(t => t.IncomeCategoryNavigation).ToList();
        }
    }
}
