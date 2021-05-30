using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpendMonitor.Models
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblExpenditures = new HashSet<TblExpenditure>();
            TblIncomes = new HashSet<TblIncome>();
        }

        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string CategoryDescription { get; set; }
        [Required]
        public bool CategoryIsExpenditure { get; set; }

        public virtual ICollection<TblExpenditure> TblExpenditures { get; set; }
        public virtual ICollection<TblIncome> TblIncomes { get; set; }
    }
}
