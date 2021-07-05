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
        public List<TblExpenditure> GetAllExpenditures()
        {
            return _context.TblExpenditures
                .Include(t => t.ExpCategoryNavigation)
                .Where(t => t.ExpCategoryNavigation.CategoryIsExpenditure == true)
                .Include(t => t.ExpAccountNavigation)
                .OrderByDescending(s => s.ExpDate)
                .ToList();
        }
        public List<TblExpenditure> GetAllExpensesForXMonth(int month)
        {
            return _context.TblExpenditures
                .Include(t => t.ExpCategoryNavigation)
                .Include(t => t.ExpAccountNavigation)
                .Where(t => t.ExpDate.Month == month)
                .OrderByDescending(s => s.ExpDate).ToList();
        }
        public List<TblCategory> GetAllCategories()
        {
            return _context.TblCategories
                .Where(t => t.CategoryIsExpenditure == true)
                .ToList();
        }
        public List<TblAccount> GetAllAccounts()
        {
            return _context.TblAccounts
                     .ToList();
        }
        public bool AddExpense(TblExpenditure expense)
        {
            try
            {
                _context.Add(expense);
                _context.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
        public bool UpdateExpense(TblExpenditure newExpense)
        {
            try
            {
                _context.Update(newExpense);
                _context.SaveChanges();

                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
        public bool GetExpense(TblExpenditure expense)
        {
            throw new NotImplementedException();
        }
        public bool RemoveExpense(TblExpenditure expense)
        {
            try
            {
                _context.TblExpenditures.Remove(expense);
                _context.SaveChanges();

                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }

        }
        public TblExpenditure FindExpenseToDelete(int? id)
        {
            var expense = _context.TblExpenditures
                    .Include(t => t.ExpCategoryNavigation)
                    .Include(t => t.ExpAccountNavigation)
                    .FirstOrDefault(m => m.Expid == id);

            return expense;
        }
        public TblExpenditure FindExopenseById(int? id)
        {
            var expense = _context.TblExpenditures.Find(id);
            return expense;
        }

        public List<TblExpenditure> GetExpenseByCategory(int? categoryId, int? month)
        {
            return _context.TblExpenditures
                .Include(t => t.ExpCategoryNavigation)
                .Include(t => t.ExpAccountNavigation)
                .Where(t => t.ExpCategoryNavigation.CategoryIsExpenditure == true)
                .Where(t => t.ExpDate.Month == month)
                .Where(t => t.ExpCategory == categoryId)
                .ToList();
        }
        public List<TblExpenditure> GetExopenseForLastMonth()
        {
            var expenseList = _context.TblExpenditures.Where(x =>
    DateTime.Compare(x.ExpDate, DateTime.Today.AddMonths(-1)) >= 0).ToList();

            return expenseList;
        }
        public List<TblExpenditure> GetExopenseForLast3Months()
        {
            var expenseList = _context.TblExpenditures.Where(x =>
    DateTime.Compare(x.ExpDate, DateTime.Today.AddMonths(-3)) >= 0).ToList();

            return expenseList;
        }
        public List<TblExpenditure> GetExopenseForLast6Months()
        {
            var expenseList = _context.TblExpenditures.Where(x =>
    DateTime.Compare(x.ExpDate, DateTime.Today.AddMonths(-6)) >= 0).ToList();

            return expenseList;
        }
    }
}
