using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryStamper.Models
{
    public class InventoryItem
    {
        public Guid Id { get; set; }
        public string Serial { get; set; }
        public string ItemName { get; set; }
        public string ModelName { get; set; }
        public string Manufacturer { get; set; }
        public string Notes { get; set; }
    }
}
