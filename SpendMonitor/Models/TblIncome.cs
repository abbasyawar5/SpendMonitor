using System;
using System.Collections.Generic;

#nullable disable

namespace SpendMonitor.Models
{
    public partial class TblIncome
    {
        public int IncomeId { get; set; }
        public decimal IncomeAmount { get; set; }
        public int IncomeCategory { get; set; }
        public DateTime IncomeDate { get; set; }
        public string IncomeSource { get; set; }
        public int? IncomeAccount { get; set; }

        public virtual TblAccount IncomeAccountNavigation { get; set; }
        public virtual TblCategory IncomeCategoryNavigation { get; set; }
    }
}
