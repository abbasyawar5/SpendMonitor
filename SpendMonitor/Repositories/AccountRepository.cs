using Microsoft.EntityFrameworkCore;
using SpendMonitor.Models;
using SpendMonitor.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        private readonly SpendMonitorContext _context;
        public AccountRepository(SpendMonitorContext context)
        {
            _context = context;
        }
        public List<TblAccount> GetAllAccounts()
        {
            return _context.TblAccounts.ToList();
        }
        public bool AdjustAccountBalance(TblExpenditure expense, int adjust)
        {
            try
            {
                var account = _context.TblAccounts.AsNoTracking()
                .Where(t => t.AccountId == expense.ExpAccount).FirstOrDefault();

                switch (adjust)
                {
                    case < 0: account.AccountBalance -= expense.ExpAmount; break;
                    case > 0: account.AccountBalance += expense.ExpAmount; break;
                    default: break;
                }
                

                _context.Update(account);
                _context.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public bool AdjustExpAccountBalance(TblExpenditure expense, int adjust)
        {
            try
            {
                var account = _context.TblAccounts.AsNoTracking()
                .Where(t => t.AccountId == expense.ExpAccount).FirstOrDefault();

                switch (adjust)
                {
                    case < 0: account.AccountBalance -= expense.ExpAmount; break;
                    case > 0: account.AccountBalance += expense.ExpAmount; break;
                    default: break;
                }


                _context.Update(account);
                _context.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public bool AdjustIncAccountBalance(TblIncome income, int adjust)
        {
            try
            {
                var account = _context.TblAccounts.AsNoTracking()
                .Where(t => t.AccountId == income.IncomeAccount).FirstOrDefault();

                switch (adjust)
                {
                    case < 0: account.AccountBalance -= income.IncomeAmount; break;
                    case > 0: account.AccountBalance += income.IncomeAmount; break;
                    default: break;
                }


                _context.Update(account);
                _context.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
    }
}
