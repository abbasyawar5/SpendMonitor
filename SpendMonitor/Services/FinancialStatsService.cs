using SpendMonitor.Models;
using SpendMonitor.Repositories.Interfaces;
using SpendMonitor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Services
{
    public class FinancialStatsService : IFinancialStatsService
    {
        private readonly IExpenditureRepository _expRepo;
        private readonly ICategoryRepository _catRepo;
        private readonly IIncomeRepository _incRepo;

        public FinancialStatsService(IExpenditureRepository expRepo, ICategoryRepository catRepo, IIncomeRepository incRepo) {
            _expRepo = expRepo;
            _catRepo = catRepo;
            _incRepo = incRepo;
        }
        public FinancialStatsModel GetStats()
        {
            FinancialStatsModel stats = new FinancialStatsModel();
            var expenses = _expRepo.GetAllExpenditures();
            stats.AverageMonthlyExpense = expenses.Sum(x => x.ExpAmount);


            stats.ExpenseByCategory = GetExpenseByCategory();
            return stats;
        }

        public decimal GetTotalExpense()
        {
            var totalExpense = _expRepo.GetAllExpenditures().Sum(x => x.ExpAmount);

            return totalExpense;
        }

        public decimal GetExpenseByCategory(int _catId)
        {
            var expense = _expRepo.GetExpenseByCategory(_catId).Sum(x => x.ExpAmount);

            return expense;
        }

        public Dictionary<String,decimal> GetExpenseByCategory()
        {
            var categories = _catRepo.GetAllCategories().ToList();
            Dictionary<String, decimal> expenseByCat = new Dictionary<string, decimal>();

            for (int i=0; i<categories.Count; i++)
            {
                expenseByCat.Add(categories[i].CategoryName, GetExpenseByCategory(categories[i].CategoryId));

            }


            return expenseByCat;
        }

        public decimal GetTotalExpenseForLastMonth()
        {
            var totalExpense = _expRepo.GetExopenseForLastMonth().Sum(x => x.ExpAmount);

            return totalExpense;
        }
    }
}
