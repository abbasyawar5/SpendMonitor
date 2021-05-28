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
    }


}
