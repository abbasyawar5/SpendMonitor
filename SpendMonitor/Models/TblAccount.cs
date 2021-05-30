using System;
using System.Collections.Generic;

#nullable disable

namespace SpendMonitor.Models
{
    public partial class TblAccount
    {
        public TblAccount()
        {
            TblExpenditures = new HashSet<TblExpenditure>();
        }

        public int AccountId { get; set; }
        public string AccountBankName { get; set; }
        public bool AccountIsDebit { get; set; }
        public decimal? AccountBalance { get; set; }

        public virtual ICollection<TblExpenditure> TblExpenditures { get; set; }
    }
}
