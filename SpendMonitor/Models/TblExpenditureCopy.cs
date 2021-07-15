using System;
using System.Collections.Generic;

#nullable disable

namespace SpendMonitor.Models
{
    public partial class TblExpenditureCopy
    {
        public int Expid { get; set; }
        public decimal ExpAmount { get; set; }
        public int ExpCategory { get; set; }
        public int ExpAccount { get; set; }
        public DateTime ExpDate { get; set; }
        public string ExpShop { get; set; }
        public int ExpSubCategory { get; set; }
    }
}
