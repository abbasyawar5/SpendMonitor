
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpendMonitor.Models
{
    public partial class Expenditure
    {
        public int Expid { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal ExpAmount { get; set; }
        [Required]
        public int ExpCategory { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }
        public string ExpShop { get; set; } 

        public virtual Categories ExpCategoryNavigation { get; set; }
    }
}
