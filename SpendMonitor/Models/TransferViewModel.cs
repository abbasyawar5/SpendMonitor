using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Models
{
    public class TransferViewModel
    {
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        [Required]
        public decimal TransferAmount { get; set; }
    }
}
