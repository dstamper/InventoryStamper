using InventoryStamper.Data.Contexts;
using InventoryStamper.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryStamper.Data
{
    public class SQLiteClient
    {
        public void TestAdd()
        {
            using (var context = new InventoryContext())
            {

                string assetTagString = Guid.NewGuid().ToString();
                var queryCat = context.Categories.First();
                context.Inventory.Add(new InventoryItem { AssetTag = assetTagString, Name="Test Item", Category = queryCat, Notes = "Notes go here" });
                context.SaveChanges();
                var currentPlace = context.Inventory.ToList();
                var queryItem = context.Inventory.Where(item => item.AssetTag == assetTagString).FirstOrDefault();
                context.Transactions.Add(new Checkout { Item = queryItem, Owner = "David", Start = DateTime.UtcNow, Out = true });
                context.SaveChanges();

            }
        }

        public void TestSeed()
        {

            using (var context = new InventoryContext())
            {
                context.Categories.Add(new ItemCategory { Category = "Laptop" });
                context.Categories.Add(new ItemCategory { Category = "Projector" });
                context.SaveChanges();

            }
        }
    }
    
}
