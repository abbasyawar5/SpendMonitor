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
            return _context.TblExpenditures.Include(t => t.ExpCategoryNavigation).Include(t => t.ExpAccountNavigation).OrderByDescending(s => s.ExpDate).ToList();
        }
        public List<TblCategory> GetAllCategories()
        {
            return _context.TblCategories.ToList();
        }

        public List<TblAccount> GetAllAccounts()
        {
            return _context.TblAccounts.ToList();
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
    }
}
