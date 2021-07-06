using SpendMonitor.Models;
using SpendMonitor.Repositories.Interfaces;
using SpendMonitor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Services
{
    public class AccountService: IAccountService
    {
        private readonly IAccountRepository _accRepo;
        public AccountService(IAccountRepository accRepo)
        {
            _accRepo = accRepo;
        }
        public bool AddAccount(TblAccount account) => _accRepo.AddAccount(account);
        public bool AdjustExpAccountBalance(TblExpenditure expense, int adjust) => _accRepo.AdjustExpAccountBalance(expense, adjust);
        public bool AdjustIncAccountBalance(TblIncome income, int adjust) => _accRepo.AdjustIncAccountBalance(income, adjust);
        public List<TblAccount> GetAllAccounts() => _accRepo.GetAllAccounts();

        public bool TransferBetweenAccounts(int fromAccount, int toAccount, decimal amount) => _accRepo.TransferBetweenAccounts(fromAccount, toAccount, amount);

        


    }
}
