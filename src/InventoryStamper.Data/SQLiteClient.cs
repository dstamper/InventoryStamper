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
            using (var context = new TestDBContext())
            {
                var freshItem = new InventoryItem
                {
                    Id = Guid.NewGuid(),
                    ItemName = "test"
                };
                context.Inventory.Add(freshItem);
                context.SaveChanges();
            }
        }

        private void FixEfProviderServicesProblem()
        {
            //https://stackoverflow.com/questions/25433298/entityframework-sqlserver-dll-not-is-getting-added-to-the-published-folder-only
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
