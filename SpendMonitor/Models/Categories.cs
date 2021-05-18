using System;
using System.Collections.Generic;

#nullable disable

namespace SpendMonitor.Models
{
    public partial class Categories
    {
        public Categories()
        {
            TblExpenditures = new HashSet<Expenditure>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public virtual ICollection<Expenditure> TblExpenditures { get; set; }
    }
}
