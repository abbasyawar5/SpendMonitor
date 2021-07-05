using SpendMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        List<TblAccount> GetAllAccounts();
        bool AdjustExpAccountBalance(TblExpenditure expense, int adjust);

        bool AdjustIncAccountBalance(TblIncome income, int adjust);
    }
}
