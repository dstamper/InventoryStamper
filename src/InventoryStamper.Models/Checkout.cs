using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryStamper.Models
{
    public class Checkout
    {
        [Key]
        public int TransactionId { get; set; }
        [Required]
        public string Owner { get; set; }
        [Required]
        public InventoryItem Item { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public bool Out { get; set; }

        public DateTime End { get; set; }
    }
}
