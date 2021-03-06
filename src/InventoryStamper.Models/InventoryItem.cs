﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryStamper.Models
{
    public class InventoryItem
    {
        [Key]
        public string AssetTag { get; set; }
        public string Name { get; set; }
        public ItemCategory Category { get; set; }
        public string Notes { get; set; }
    }
}
