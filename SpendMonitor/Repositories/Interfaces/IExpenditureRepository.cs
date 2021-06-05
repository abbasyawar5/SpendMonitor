﻿using SpendMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Repositories.Interfaces
{
    public interface IExpenditureRepository
    {
        List<TblExpenditure> GetAllExpenditures();
        List<TblCategory> GetAllCategories();
        List<TblAccount> GetAllAccounts();
        bool AddExpense(TblExpenditure expense);
        bool GetExpense(TblExpenditure expense);
        bool RemoveExpense(TblExpenditure expense);
        bool UpdateExpense(TblExpenditure expense);
        TblExpenditure FindExpenseToDelete(int? id);
        TblExpenditure FindExopenseById(int? id);
        List<TblExpenditure> GetExpenseByCategory(int? categoryId);
        List<TblExpenditure> GetExopenseForLastMonth();
        List<TblExpenditure> GetExopenseForLast3Months();
        List<TblExpenditure> GetExopenseForLast6Months();
    }
}
