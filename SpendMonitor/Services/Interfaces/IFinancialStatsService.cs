using SpendMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Services.Interfaces
{
    public interface IFinancialStatsService
    {
        FinancialStatsModel GetStats();
        decimal GetTotalExpense();
        decimal GetTotalExpenseForLastMonth();
    }
}
