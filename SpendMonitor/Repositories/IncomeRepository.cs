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
            return _context.TblIncomes
                .Include(t => t.IncomeCategoryNavigation)
                .Include(t => t.IncomeAccountNavigation)
                .Where(t=> t.IncomeCategoryNavigation.CategoryIsExpenditure == false)
                .ToList();
        }
        public List<TblIncome> GetAllIncomesForXMonth(int month)
        {
            return _context.TblIncomes
                .Include(t => t.IncomeCategoryNavigation)
                .Where(t => t.IncomeDate.Month == month)
                .Where(t => t.IncomeCategoryNavigation.CategoryIsExpenditure == false)
                .ToList();
        }
        public List<TblCategory> GetAllCategories()
        {
            return _context.TblCategories.Where(t => t.CategoryIsExpenditure == false).ToList();
        }
        public List<TblAccount> GetAllAccounts()
        {
            return _context.TblAccounts
                .Where(t => t.AccountIsDebit == true)
                .ToList();
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
            try
            {
                _context.TblIncomes.Remove(income);
                _context.SaveChanges();

                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
        public bool UpdateIncome(TblIncome income)
        {
            try
            {
                _context.Update(income);
                _context.SaveChanges();

                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
        public TblIncome FindIncomeById(int? id) {
            var income = _context.TblIncomes.Find(id);
            return income;
        }
        public TblIncome FindIncomeToDelete(int? id) {
            var income = _context.TblIncomes
                       .Include(t => t.IncomeCategoryNavigation)
                       //.Include(t => t.Income)
                       .FirstOrDefault(m => m.IncomeId == id);

            return income;
        }
    }
}
