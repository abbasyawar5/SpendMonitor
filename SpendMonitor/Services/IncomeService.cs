using SpendMonitor.Models;
using SpendMonitor.Repositories.Interfaces;
using SpendMonitor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Services
{
    public class IncomeService: IIncomeService

    {

        private readonly IIncomeRepository _incRepo;

        public IncomeService(IIncomeRepository incRepo)
        {
            _incRepo = incRepo;
        }
        public List<TblIncome> GetAllIncomes() => _incRepo.GetAllIncomes();
    }
}
