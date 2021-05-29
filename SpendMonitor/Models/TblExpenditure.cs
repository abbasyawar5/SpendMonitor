using System;
using System.Collections.Generic;

#nullable disable

namespace SpendMonitor.Models
{
    public partial class TblExpenditure
    {
        public int Expid { get; set; }
        public decimal ExpAmount { get; set; }
        public int ExpCategory { get; set; }
        public DateTime ExpDate { get; set; }
        public string ExpShop { get; set; }

        public virtual TblCategory ExpCategoryNavigation { get; set; }
    }
}
