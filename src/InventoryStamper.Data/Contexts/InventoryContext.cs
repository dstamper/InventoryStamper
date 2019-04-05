using InventoryStamper.Data.Configuration;
using InventoryStamper.Models;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryStamper.Data.Contexts
{
    [DbConfigurationType(typeof(SQLiteDbContextConfiguration))]
    public class InventoryContext : DbContext
    {
        public DbSet<InventoryItem> Inventory { get; set; }
        public DbSet<Checkout> Transactions { get; set; }
        public DbSet<ItemCategory> Categories { get; set; }

        public InventoryContext()
            : base("ConnectionString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var output = Database.Connection.ConnectionString;
            Console.WriteLine(output);
            var connectionInit = new SqliteCreateDatabaseIfNotExists<InventoryContext>(modelBuilder);
            Database.SetInitializer(connectionInit);
        }

    }
}
