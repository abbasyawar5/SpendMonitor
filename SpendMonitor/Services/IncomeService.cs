using SpendMonitor.Models;
using SpendMonitor.Repositories.Interfaces;
using SpendMonitor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Services
{
    public class IncomeService : IIncomeService
    {

        private readonly IIncomeRepository _incRepo;
        public IncomeService(IIncomeRepository incRepo)
        {
            _incRepo = incRepo;
        }
        public List<TblIncome> GetAllIncomes() => _incRepo.GetAllIncomes();
        public List<TblAccount> GetAllAccounts() => _incRepo.GetAllAccounts();
        public List<TblCategory> GetAllCategories() => _incRepo.GetAllCategories();
        public bool AddIncome(TblIncome income) => _incRepo.AddIncome(income);
        public List<TblIncome> GetAllIncomesForXMonth(int month) => _incRepo.GetAllIncomesForXMonth(month);
        public bool GetIncome(TblIncome income) => _incRepo.GetIncome(income);
        public bool RemoveIncome(TblIncome income) => _incRepo.RemoveIncome(income);
        public bool UpdateIncome(TblIncome income) => _incRepo.UpdateIncome(income);
    }
}
