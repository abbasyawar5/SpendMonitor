using Microsoft.AspNetCore.Mvc.Rendering;
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
        public int ExpAccount { get; set; }
        public DateTime ExpDate { get; set; }
        public string ExpShop { get; set; }

        public virtual TblAccount ExpAccountNavigation { get; set; }
        public virtual TblCategory ExpCategoryNavigation { get; set; }
    }

}
