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
        private readonly IIncomeRepository _incRepo;
        private readonly IAccountRepository _accRepo;
        public FinancialStatsModel _finStatsModel;

        public FinancialStatsService(IExpenditureRepository expRepo, IAccountRepository accRepo, IIncomeRepository incRepo)
        {
            _expRepo = expRepo;
            _incRepo = incRepo;
            _accRepo = accRepo;
        }
        public FinancialStatsModel GetStats()
        {
            _finStatsModel = new FinancialStatsModel();
            _finStatsModel.AverageMonthlyIncome = AvgMonthlyIncome();
            _finStatsModel.AverageMonthlyExpense = AvgMonthlyExpense();
            _finStatsModel.TotalCurrentMonthExpense = XMonthExpense(DateTime.Now.Month);
            _finStatsModel.TotalLastMonthExpense = XMonthExpense(DateTime.Now.Month - 1);
            _finStatsModel.TotalCurrentMonthIncome = XMonthIncome(DateTime.Now.Month);
            _finStatsModel.TotalLastMonthIncome = XMonthIncome(DateTime.Now.Month - 1);
            _finStatsModel.AccountBalances = AccountBalances();
            _finStatsModel.ExpenseByMonth = ExpenseByMonth();
            return _finStatsModel;
        }

        public decimal AvgMonthlyIncome()
        {

            var incomes = _incRepo.GetAllIncomes();
            List<string> months = (from n in incomes
                                       //where n.Year.Equals(yearSelected)
                                   select n.IncomeDate.ToString("MMM")).Distinct().ToList();
            var totalIncomes = incomes.Sum(x => x.IncomeAmount);
            var AverageMonthlyIncome = totalIncomes / months.Count();
            return AverageMonthlyIncome;
        }

        public decimal AvgMonthlyExpense()
        {

            var expenses = _expRepo.GetAllExpenditures();
            List<string> months = (from n in expenses
                                       //where n.Year.Equals(yearSelected)
                                   select n.ExpDate.ToString("MMM")).Distinct().ToList();
            var totalExpenses = expenses.Sum(x => x.ExpAmount);
            var AverageMonthlyExpense = totalExpenses / months.Count();
            return AverageMonthlyExpense;
        }

        public decimal XMonthExpense(int month)
        {
            var currentMonth = month;
            var expenses = _expRepo.GetAllExpensesForXMonth(currentMonth);
            var totalExpenses = expenses.Sum(x => x.ExpAmount);
            return totalExpenses;
        }

        public decimal XMonthIncome(int month)
        {
            var currentMonth = month;
            var expenses = _incRepo.GetAllIncomesForXMonth(currentMonth);
            var totalIncomes = expenses.Sum(x => x.IncomeAmount);
            return totalIncomes;
        }

        public List<TblAccount> AccountBalances() {

            var accounts = _accRepo.GetAllAccounts().ToList();

            return accounts;
        }
        public List<Dictionary<String, decimal>> ExpenseByMonth()
        {
            List<Dictionary<String, decimal>> expenseByMonthList = new List<Dictionary<string, decimal>>();
            var expenses = _expRepo.GetAllExpenditures();
            List<int> months = (from n in expenses
                                   select n.ExpDate.Date.Month).Distinct().ToList();

            foreach (var mnth in months)
            {
                var categories = _expRepo.GetAllCategories().ToList();
                Dictionary<String, decimal> expenseByCat = new Dictionary<string, decimal>();

                for (int i = 0; i < categories.Count; i++)
                {
                    expenseByCat.Add(categories[i].CategoryName, _expRepo.GetExpenseByCategory(categories[i].CategoryId, mnth).Sum(x => x.ExpAmount));
                }

                expenseByMonthList.Add(expenseByCat);
            }

            return expenseByMonthList;
        }

    }
}
