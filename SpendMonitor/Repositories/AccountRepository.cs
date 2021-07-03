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
    }
}
