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
        public FinancialStatsModel _finStatsModel;

        public FinancialStatsService(IExpenditureRepository expRepo, ICategoryRepository catRepo, IIncomeRepository incRepo)
        {
            _expRepo = expRepo;
            _catRepo = catRepo;
            _incRepo = incRepo;
        }
        public FinancialStatsModel GetStats()
        {
            _finStatsModel = new FinancialStatsModel();
            _finStatsModel.AverageMonthlyIncome = SetAvgMonthlyIncome();
            _finStatsModel.AverageMonthlyExpense = SetAvgMonthlyExpense();
            _finStatsModel.TotalCurrentMonthExpense = SetCurrentMonthExpense();
            _finStatsModel.ExpenseByCategory = SetExpenseByCategory();

            return _finStatsModel;
        }

        public decimal SetAvgMonthlyIncome()
        {

            var incomes = _incRepo.GetAllIncomes();
            List<string> months = (from n in incomes
                                       //where n.Year.Equals(yearSelected)
                                   select n.IncomeDate.ToString("MMM")).Distinct().ToList();
            var totalIncomes = incomes.Sum(x => x.IncomeAmount);
            var AverageMonthlyIncome = totalIncomes / months.Count();
            return AverageMonthlyIncome;
        }

        public decimal SetAvgMonthlyExpense()
        {

            var expenses = _expRepo.GetAllExpenditures();
            List<string> months = (from n in expenses
                                       //where n.Year.Equals(yearSelected)
                                   select n.ExpDate.ToString("MMM")).Distinct().ToList();
            var totalExpenses = expenses.Sum(x => x.ExpAmount);
            var AverageMonthlyExpense = totalExpenses / months.Count();
            return AverageMonthlyExpense;
        }

        public decimal SetCurrentMonthExpense()
        {
            var currentMonth = DateTime.Now.Month;
            var expenses = _expRepo.GetAllExpensesForXMonth(currentMonth);
            var totalExpenses = expenses.Sum(x => x.ExpAmount);
            return totalExpenses;
        }
        public Dictionary<String, decimal> SetExpenseByCategory()
        {
            var categories = _catRepo.GetAllCategories().ToList();
            Dictionary<String, decimal> expenseByCat = new Dictionary<string, decimal>();

            for (int i = 0; i < categories.Count; i++)
            {
                expenseByCat.Add(categories[i].CategoryName, _expRepo.GetExpenseByCategory(categories[i].CategoryId).Sum(x => x.ExpAmount));
            }
            return expenseByCat;
        }

    }
}
