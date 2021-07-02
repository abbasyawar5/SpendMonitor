using SpendMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Repositories.Interfaces
{
    public interface IIncomeRepository
    {
        List<TblIncome> GetAllIncomes();
        List<TblIncome> GetAllIncomesForXMonth(int month);
        List<TblCategory> GetAllCategories();
        List<TblAccount> GetAllAccounts();
        bool AddIncome(TblIncome income);
        bool GetIncome(TblIncome income);
        bool RemoveIncome(TblIncome income);
        bool UpdateIncome(TblIncome income);
    }
}
