using SpendMonitor.Models;
using SpendMonitor.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Repositories
{
    public class ExpenditureRepository : IExpenditureRepository
    {

        public List<Expenditure> GetAllExpenditures()
        {
            SpendMonitorContext _expendituresContext = new SpendMonitorContext();
            List<Expenditure> expenditures = _expendituresContext.TblExpenditures.ToList();
            return expenditures;
        }

    }
}
