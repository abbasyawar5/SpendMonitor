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
        private readonly SpendMonitorContext _context;

        public ExpenditureRepository(SpendMonitorContext context)
        {
            _context = context;
        }
        public List<Expenditure> GetAllExpenditures()
        {

            return _context.TblExpenditures.ToList();
        }

    }
}
