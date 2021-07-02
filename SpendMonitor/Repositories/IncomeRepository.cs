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

        public List<TblIncome> GetAllIncomesForXMonth(int month)
        {
            return _context.TblIncomes.Include(t => t.IncomeCategoryNavigation).Where(t => t.IncomeDate.Month == month).ToList();
        }
        public List<TblCategory> GetAllCategories()
        {
            return _context.TblCategories.ToList();
        }
        public List<TblAccount> GetAllAccounts()
        {
            return _context.TblAccounts.ToList();
        }
        public bool AddIncome(TblIncome income)
        {
            try
            {
                _context.Add(income);
                _context.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }




        public bool GetIncome(TblIncome income)
        {
            throw new NotImplementedException();
        }

        public bool RemoveIncome(TblIncome income)
        {
            throw new NotImplementedException();
        }

        public bool UpdateIncome(TblIncome income)
        {
            throw new NotImplementedException();
        }
    }
}
