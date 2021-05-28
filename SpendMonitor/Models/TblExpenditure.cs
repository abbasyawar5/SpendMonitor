using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpendMonitor.Models
{
    public partial class TblExpenditure
    {
        [Key]
        public int Expid { get; set; }
        [Required]
        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        public decimal ExpAmount { get; set; }
        [Required]

        [Display(Name = "Category")]
        public int ExpCategory { get; set; }
        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }

        [Display(Name = "Shop Name")]
        public string ExpShop { get; set; }

        public virtual TblCategory ExpCategoryNavigation { get; set; }


    }
}
