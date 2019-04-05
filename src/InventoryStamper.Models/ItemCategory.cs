using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryStamper.Models
{
    public class ItemCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
