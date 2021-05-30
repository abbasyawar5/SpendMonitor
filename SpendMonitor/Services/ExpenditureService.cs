using SpendMonitor.Models;
using SpendMonitor.Repositories.Interfaces;
using SpendMonitor.Services.Interfaces;
using System.Collections.Generic;


namespace SpendMonitor.Services
{
    public class ExpenditureService : IExpenditureService
    {
        private readonly IExpenditureRepository _expRepo;

        public ExpenditureService(IExpenditureRepository expRepo)
        {
            _expRepo = expRepo;
        }

        public List<TblExpenditure> GetAllExpenditures(string sortOrder) => _expRepo.GetAllExpenditures(sortOrder);

        public bool AddExpense(TblExpenditure expense) => _expRepo.AddExpense(expense);
        public bool UpdateExpense(TblExpenditure expense) => _expRepo.UpdateExpense(expense);
        public bool GetExpense(TblExpenditure expense) => _expRepo.GetExpense(expense);
        public bool RemoveExpense(TblExpenditure expense) => _expRepo.RemoveExpense(expense);

        public TblExpenditure FindExopenseById(int? id) => _expRepo.FindExopenseById(id);
   }


}
