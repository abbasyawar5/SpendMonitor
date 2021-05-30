using SpendMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Repositories.Interfaces
{
    public interface IExpenditureRepository
    {
        List<TblExpenditure> GetAllExpenditures(string sortOrder);

        bool AddExpense(TblExpenditure expense);
        bool GetExpense(TblExpenditure expense);
        bool RemoveExpense(TblExpenditure expense);
        bool UpdateExpense(TblExpenditure expense);

        TblExpenditure FindExopenseById(int? id);
    }
}
