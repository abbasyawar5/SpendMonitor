using System;
using System.Collections.Generic;

#nullable disable

namespace SpendMonitor.Models
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblExpenditures = new HashSet<TblExpenditure>();
            TblIncomes = new HashSet<TblIncome>();
            TblSubcategories = new HashSet<TblSubcategory>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryIsExpenditure { get; set; }

        public virtual ICollection<TblExpenditure> TblExpenditures { get; set; }
        public virtual ICollection<TblIncome> TblIncomes { get; set; }
        public virtual ICollection<TblSubcategory> TblSubcategories { get; set; }
    }
}
