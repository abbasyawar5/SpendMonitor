using System;
using System.Collections.Generic;

#nullable disable

namespace SpendMonitor.Models
{
    public partial class TblSubcategory
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryDescription { get; set; }
        public int SubCategoryParentCategory { get; set; }

        public virtual TblCategory SubCategoryParentCategoryNavigation { get; set; }
    }
}
